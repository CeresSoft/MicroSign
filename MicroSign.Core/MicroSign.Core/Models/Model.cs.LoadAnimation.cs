using MicroSign.Core.Models.AnimationSaveSettings;
using MicroSign.Core.ViewModels;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// アニメーション設定読込
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public (bool IsSuccess, string ErrorMessage, AnimationImageItemCollection? AnimationImages, AnimationSaveSetting? saveSetting) LoadAnimation(string path)
        {
            //読込先パス有効判定
            {
                bool isNull = string.IsNullOrEmpty(path);
                if (isNull)
                {
                    //無効の場合は終了
                    return (false, "読込先パスが無効です", null, null);
                }
                else
                {
                    //有効の場合は処理続行
                }
            }

            //読込
            AnimationSaveSetting? saveSetting = MicroSign.Core.SerializerUtils.JsonUtil.Load<AnimationSaveSetting>(path);
            if(saveSetting == null)
            {
                //読込できなかった場合は終了
                return (false, "読込に失敗しました", null, null);
            }
            else
            {
                //読込できた場合は処理続行
            }

            //マトリクスLEDサイズを取得
            int matrixLedWidth = saveSetting.MatrixLedWidth;
            int matrixLedHeight = saveSetting.MatrixLedHeight;

            //アニメーションのコレクションを取得
            AnimationSaveDataCollection? saveDatas = saveSetting.AnimationDatas;

            //読込パスのディレクト入り部分を取得
            // >> 基準パスとします
            string? baseDir = System.IO.Path.GetDirectoryName(path);
            if(baseDir == null)
            {
                //ベースディレクトリが無効の場合は終了
                return (false, $"読込パスのディレクトリが取得出来ません", null, null);
            }
            else
            {
                //有効の場合は処理続行
            }

            //アニメーションリストにする
            AnimationImageItemCollection result = new AnimationImageItemCollection();
            {
                int c = CommonUtils.GetCount(saveDatas);
                for (int i = CommonConsts.Index.First; i < c; i += CommonConsts.Index.Step)
                {
                    //アニメーション画像アイテム読込
                    var ret = this.LoadAnimationImpl(baseDir, matrixLedWidth, matrixLedHeight, i, saveDatas[i]);
                    if(ret.IsSuccess)
                    {
                        //成功の場合は処理続行
                    }
                    else
                    {
                        //失敗の場合は終了
                        return (false, ret.Message, null, null);
                    }

                    // >> アニメーション画像コレクションに追加
                    AnimationImageItem? item = ret.AnimationImage;
                    if(item == null)
                    {
                        //アニメーション画像アイテムが無効の場合は無視する
                    }
                    else
                    {
                        //アニメーション画像アイテムが有効の場合は追加する
                        result.Add(item);
                    }
                }
            }

            //ここまで来たら成功
            return (true, string.Empty, result, saveSetting);
        }

        /// <summary>
        /// アニメーション設定読込実装
        /// </summary>
        /// <param name="baseDir">基準ディレクトリ</param>
        /// <param name="matrixLedWidth">マトリクスLED横幅</param>
        /// <param name="matrixLedHeight">マトリクスLED縦幅</param>
        /// <param name="index">インデックス</param>
        /// <param name="saveData">保存データ</param>
        /// <returns></returns>
        private (bool IsSuccess, string Message, AnimationImageItem? AnimationImage) LoadAnimationImpl(string baseDir, int matrixLedWidth, int matrixLedHeight, int index, AnimationSaveData? saveData)
        {
            //保存データ有効判定
            if (saveData == null)
            {
                //無効の場合は無視する
                CommonLogger.Debug($"[{index}]保存データ無効");
                return (true, string.Empty, null);
            }
            else
            {
                //有効の場合は処理続行
            }

            //アニメーション画像タイプを取得
            AnimationImageType imageType = saveData.ImageType;
            switch (imageType)
            {
                case AnimationImageType.ImageFile:
                    //画像ファイルの場合
                    CommonLogger.Debug($"[{index}]アニメーション画像タイプ =　画像ファイル");
                    return this.LoadAnimationImplByImageFile(baseDir, index, saveData);

                case AnimationImageType.Text:
                    //テキストの場合
                    CommonLogger.Debug($"[{index}]アニメーション画像タイプ =　テキスト");
                    return this.LoadAnimationImplByText(baseDir, matrixLedWidth, matrixLedHeight, index, saveData);

                default:
                    //それ以外の場合
                    return (false, CommonLogger.Warn($"[{index}]不明なアニメーション画像タイプです ({imageType})"), null);
            }
        }

        /// <summary>
        /// アニメーション設定読込実装 - 画像ファイル
        /// </summary>
        /// <param name="baseDir">基準ディレクトリ</param>
        /// <param name="index">インデックス</param>
        /// <param name="saveData">保存データ</param>
        /// <returns></returns>
        private (bool IsSuccess, string Message, AnimationImageItem? AnimationImage) LoadAnimationImplByImageFile(string baseDir, int index, AnimationSaveData? saveData)
        {
            //保存データ有効判定
            if (saveData == null)
            {
                //無効の場合は無視する
                CommonLogger.Debug($"[{index}]保存データ無効");
                return (true, string.Empty, null);
            }
            else
            {
                //有効の場合は処理続行
                CommonLogger.Debug($"[{index}]保存データ有効");
            }

            //有効の場合はコピーする
            // >> 画像パス取得
            string? imagePath = saveData.ImagePath;
            if (imagePath == null)
            {
                //画像パスが無効の場合は終了
                return (false, CommonLogger.Warn($"[{index}]読込した画像パスが無効です"), null);
            }
            else
            {
                bool isNull = string.IsNullOrEmpty(imagePath);
                if (isNull)
                {
                    //画像パスが無効の場合は終了
                    return (false, CommonLogger.Warn($"[{index}]読込した画像パスが空です"), null);
                }
                else
                {
                    //有効の場合は処理続行
                    CommonLogger.Debug($"[{index}]読込した画像パス有効 (path='{imagePath}')");
                }
            }

            // >> 画像パスをフルパスに変換
            string? imageFullPath = System.IO.Path.Combine(baseDir, imagePath);
            CommonLogger.Debug($"[{index}]読込した画像フルパス (path='{imageFullPath}')");

            // >> 画像を読込
            BitmapSource? bmp = this.GetImage(imageFullPath);
            if (bmp == null)
            {
                //読込出来ない場合は終了
                return (false, CommonLogger.Warn($"[{index}]画像が読みできませんでした (path='{imageFullPath}')"), null);
            }
            else
            {
                //有効の場合は処理続行
                CommonLogger.Debug($"[{index}]画像読込成功 (path='{imageFullPath}')");
            }

            //フォーマット
            FormatKinds formatKind = MainWindowViewModel.InitializeValues.FormatKind;
            Models.Model.ConvertImageResult ret = this.ConvertImage(bmp, formatKind);
            if(ret.IsSuccess)
            {
                //成功の場合は処理続行
                CommonLogger.Debug($"[{index}]画像変換成功");
            }
            else
            {
                //失敗の場合は終了
                return (false, CommonLogger.Warn($"[{index}]画像変換に失敗しました (理由='{ret.ErrorMessage}')"), null);
            }

            //表示期間を取得
            double displayPeriod = saveData.DisplayPeriod;

            // >> アニメーション画像インスタンス生成
            AnimationImageItem item = AnimationImageItem.FromImageFile(
                displayPeriod,
                imageFullPath,
                bmp,
                ret.OutputData,
                ret.PreviewImage
                );

            //成功で終了
            return (true, string.Empty, item);
        }


        /// <summary>
        /// アニメーション設定読込実装 - テキスト
        /// </summary>
        /// <param name="baseDir">基準ディレクトリ</param>
        /// <param name="matrixLedWidth">マトリクスLED横幅</param>
        /// <param name="matrixLedHeight">マトリクスLED縦幅</param>
        /// <param name="index">インデックス</param>
        /// <param name="saveData">保存データ</param>
        /// <returns></returns>
        private (bool IsSuccess, string Message, AnimationImageItem? AnimationImage) LoadAnimationImplByText(string baseDir, int matrixLedWidth, int matrixLedHeight, int index, AnimationSaveData? saveData)
        {
            //保存データ有効判定
            if (saveData == null)
            {
                //無効の場合は無視する
                CommonLogger.Debug($"[{index}]保存データ無効");
                return (true, string.Empty, null);
            }
            else
            {
                //有効の場合は処理続行
                CommonLogger.Debug($"[{index}]保存データ有効");
            }

            //レンダーターゲットビットマップを生成
            RenderTargetBitmap? renderBitmap = null;
            {
                var ret = this.CreateRenderTargetBitmap(matrixLedWidth, matrixLedHeight);
                if (ret.IsSuccess)
                {
                    //成功の場合は処理続行
                }
                else
                {
                    //失敗の場合は終了
                    return (false, CommonLogger.Warn($"[{index}]レンダーターゲットビットマップの生成に失敗 (理由='{ret.Message}')"), null);
                }

                //生成したレンダーターゲットビットマップを取得
                renderBitmap = ret.RenderBitmap;
            }

            //描写する文字の情報を取得
            int fontSize = saveData.SelectFontSize;
            int fontColor = saveData.SelectFontColor;
            string? displayText = saveData.DisplayText;

            //文字を描写
            {
                var ret = this.RenderText(renderBitmap, fontSize, fontColor, displayText);
                if (ret.IsSuccess)
                {
                    //成功の場合は処理続行
                }
                else
                {
                    //失敗の場合は終了
                    return (false, CommonLogger.Warn($"[{index}]文字の描写に失敗 (理由='{ret.Message}')"), null);
                }
            }

            //フォーマット
            FormatKinds formatKind = MainWindowViewModel.InitializeValues.FormatKind;

            //画像変換
            Models.Model.ConvertImageResult convertImage = this.ConvertImage(renderBitmap, formatKind);
            if (convertImage.IsSuccess)
            {
                //成功の場合は処理続行
                CommonLogger.Debug($"[{index}]画像変換成功");
            }
            else
            {
                //失敗の場合は終了
                return (false, CommonLogger.Warn($"[{index}]画像変換に失敗しました (理由='{convertImage.ErrorMessage}')"), null);
            }

            //表示期間を取得
            double displayPeriod = saveData.DisplayPeriod;

            // >> アニメーション画像インスタンス生成
            AnimationImageItem item = AnimationImageItem.FromText(
                displayPeriod,
                fontSize,
                fontColor,
                displayText,
                renderBitmap,
                convertImage.OutputData,
                convertImage.PreviewImage
                );

            //成功で終了
            return (true, string.Empty, item);
        }

    }
}
