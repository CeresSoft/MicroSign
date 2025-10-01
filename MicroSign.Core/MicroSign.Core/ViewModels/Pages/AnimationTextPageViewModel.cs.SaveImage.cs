using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.ViewModels.Pages
{
    partial class AnimationTextPageViewModel
    {
        /// <summary>
        /// 画像保存結果
        /// </summary>
        public struct SaveImageResult
        {
            /// <summary>
            /// 成功フラグ
            /// </summary>
            public readonly bool IsSuccess;

            /// <summary>
            /// エラーメッセージ
            /// </summary>
            public readonly string? ErrorMessage;

            /// <summary>
            /// 出力パス
            /// </summary>
            public readonly List<string>? OutputPaths;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="isSuccess"></param>
            /// <param name="message"></param>
            /// <param name="outputFolder"></param>
            private SaveImageResult(bool isSuccess, string? message, List<string>? outputFolder)
            {
                this.IsSuccess = isSuccess;
                this.ErrorMessage = message;
                this.OutputPaths = outputFolder;
            }

            /// <summary>
            /// 失敗
            /// </summary>
            /// <param name="message"></param>
            /// <returns></returns>
            public static SaveImageResult Failed(string message)
            {
                SaveImageResult result = new SaveImageResult(false, message, null);
                return result;
            }

            /// <summary>
            /// 成功
            /// </summary>
            /// <param name="outputPaths"></param>
            /// <returns></returns>
            public static SaveImageResult Success(List<string>? outputPaths)
            {
                SaveImageResult result = new SaveImageResult(true, null, outputPaths);
                return result;
            }
        }

        /// <summary>
        /// 画像を保存
        /// </summary>
        /// <param name="savePath"></param>
        /// <returns></returns>
        public SaveImageResult SaveImage(string savePath)
        {
            //スクロール有無を取得
            bool isScrollEnabled = this.IsScrollEnabled;
            if (isScrollEnabled)
            {
                //スクロールした連番画像を保存
                return this.SaveScrollImage(savePath);
            }
            else
            {
                //単体画像を保存
                return this.SaveSingleImage(savePath);
            }
        }

        /// <summary>
        /// 単体画像を保存
        /// </summary>
        /// <param name="savePath"></param>
        /// <returns></returns>
        protected SaveImageResult SaveSingleImage(string savePath)
        {
            //レンダリング画像を取得
            // >> 単体画像の場合はプレビューがそのまま出力内容になる
            RenderTargetBitmap? renderBitmap = this.RenderBitmap;
            if (renderBitmap == null)
            {
                //画像無効の場合は失敗
                return SaveImageResult.Failed(CommonLogger.Warn("レンダリング画像が無効です"));
            }
            else
            {
                //有効の場合は続行
            }

            //PNGで保存
            try
            {
                PngBitmapEncoder png = new PngBitmapEncoder();
                BitmapFrame frame = BitmapFrame.Create(renderBitmap);
                png.Frames.Add(frame);
                using (System.IO.Stream stm = System.IO.File.Create(savePath))
                {
                    png.Save(stm);
                }
            }
            catch (Exception ex)
            {
                //例外は握りつぶす
                string msg = $"PNG保存で例外が発生しました (path='{savePath}') ({ex})";
                CommonLogger.Warn(msg, ex);
                return SaveImageResult.Failed(msg);
            }

            //出力パス一覧を作成
            List<string>? outputPaths = new List<string>();
            // >> 出力したPNGのパスを追加
            outputPaths.Add(savePath);

            //ここまできたら成功
            return SaveImageResult.Success(outputPaths);
        }

        /// <summary>
        /// スクロール画像を保存
        /// </summary>
        /// <param name="savePath"></param>
        /// <returns></returns>
        protected SaveImageResult SaveScrollImage(string savePath)
        {
            //出力フォルダーを生成
            string? outputFolder = null;
            try
            {
                //拡張子をのぞいたファイル名を取得
                string? fname = System.IO.Path.GetFileNameWithoutExtension(savePath);
                {
                    bool isNull = string.IsNullOrEmpty(fname);
                    if (isNull)
                    {
                        //無効の場合は修了
                        string msg = $"ファイル名の取得に失敗しました (path='{savePath}')";
                        CommonLogger.Warn(msg);
                        return SaveImageResult.Failed(msg);
                    }
                    else
                    {
                        //取得できた場合は処理続行
                        CommonLogger.Debug($"ファイル名の取得成功  (path='{savePath}' -> '{fname}')");
                    }
                }

                //ディレクトリ部を取得
                string? dir = System.IO.Path.GetDirectoryName(savePath);
                {
                    bool isNull = string.IsNullOrEmpty(dir);
                    if (isNull)
                    {
                        //無効の場合は修了
                        string msg = $"ディレクトリの取得に失敗しました (path='{savePath}')";
                        CommonLogger.Warn(msg);
                        return SaveImageResult.Failed(msg);
                    }
                    else
                    {
                        //取得できた場合は処理続行
                        CommonLogger.Debug($"ディレクトリの取得成功  (path='{savePath}' -> '{dir}')");
                    }
                }

                //出力フォルダ名を生成
                outputFolder = System.IO.Path.Combine(dir!, fname!);
                CommonLogger.Debug($"出力先フォルダ ('{dir}' + '{fname}' -> '{outputFolder}')");
            }
            catch (Exception ex)
            {
                //例外は握りつぶす
                string msg = $"出力フォルダの作成で例外が発生しました (path='{savePath}' / outputFolder='{outputFolder}') ({ex})";
                CommonLogger.Warn(msg, ex);
                return SaveImageResult.Failed(msg);
            }

            //プロパティ取得
            int matrixLedWidth = this.MatrixLedWidth;
            int matrixLedHeight = this.MatrixLedHeight;
            int moveSpeed = 1;

            //スクロール用テキスト画像を生成
            RenderTargetBitmap? textBitmap = null;
            {
                int fontSize = this.SelectFontSize;
                int fontColor = this.SelectFontColor;
                string? displayText = this.DisplayText;

                //移動方向の前後にマトリクスLEDと同じ幅の余白を追加する
                Thickness padding = new Thickness(matrixLedWidth, CommonConsts.Values.Zero.D, matrixLedWidth, CommonConsts.Values.Zero.D);

                //横幅=未指定、縦幅=マトリクスLED縦幅、スクロール分の余白ありで生成する
                var ret = this.Model.CreateTextRenderBitmap(fontSize, fontColor, displayText, double.NaN, matrixLedHeight, padding);
                if (ret.IsSuccess)
                {
                    //成功の場合はレンダリングターゲットビットマップを取得
                    textBitmap = ret.RenderBitmap;
                    
                    //内容が確定したのでフリーズする
                    textBitmap?.Freeze();
                }
                else
                {
                    //失敗の場合は終了
                    string msg = ret.Message;
                    CommonLogger.Warn(msg);
                    return SaveImageResult.Failed(msg);
                }
            }

            //アニメーション切り抜き
            Models.Model.ClipAnimationResult clipResult = this.Model.ClipAnimation(outputFolder, textBitmap, AnimationMoveDirection.Left, moveSpeed, matrixLedWidth, matrixLedHeight);
            if (clipResult.IsSuccess)
            {
                //成功の場合は続行
            }
            else
            {
                //失敗の場合は終了
                string msg = clipResult.ErrorMessage!;
                CommonLogger.Warn(msg);
                return SaveImageResult.Failed(msg);
            }

            //出力パス一覧を取得
            List<string>? outputPaths = clipResult.OutputPaths;

            //ここまできたら成功
            return SaveImageResult.Success(outputPaths);
        }
    }
}
