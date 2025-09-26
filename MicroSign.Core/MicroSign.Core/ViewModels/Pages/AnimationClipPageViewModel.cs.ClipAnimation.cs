using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.ViewModels.Pages
{
    public partial class AnimationClipPageViewModel
    {
        /// <summary>
        /// アニメーション切り抜き結果
        /// </summary>
        public struct ClipAnimationResult
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
            /// 出力パス一覧
            /// </summary>
            public readonly List<string>? OutputPaths;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="isSuccess"></param>
            /// <param name="message"></param>
            /// <param name="outputFolder"></param>
            private ClipAnimationResult(bool isSuccess, string? message, List<string>? outputFolder)
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
            public static ClipAnimationResult Failed(string message)
            {
                ClipAnimationResult result = new ClipAnimationResult(false, message, null);
                return result;
            }

            /// <summary>
            /// 成功
            /// </summary>
            /// <param name="outputPaths"></param>
            /// <returns></returns>
            public static ClipAnimationResult Success(List<string>? outputPaths)
            {
                ClipAnimationResult result = new ClipAnimationResult(true, null, outputPaths);
                return result;
            }
        }

        /// <summary>
        /// アニメーション切り抜きコールバックデリゲート
        /// </summary>
        /// <param name="outputPath"></param>
        public delegate void ClipAnimationCallbackDelegate(ClipAnimationResult result);

        /// <summary>
        /// アニメーション切り抜き
        /// </summary>
        /// <param name="callback"></param>
        public void ClipAnimation(ClipAnimationCallbackDelegate callback)
        {
            //タスクスケジューラを取得
            TaskScheduler taskScheduler = TaskScheduler.Current;
            if (SynchronizationContext.Current == null)
            {
                //同期コンテキストが無効の場合はそのまま(=非UIスレッドからの呼び出し)
            }
            else
            {
                //同期コンテキストが有効の場合はFromCurrentSynchronizationContext()を使う(=UIスレッドからの呼び出し)
                // >> UIスレッドで呼び出しされるようにします
                taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            }

            //呼び出し
            this.ClipAnimation(callback, taskScheduler);
        }

        /// <summary>
        /// アニメーション切り抜き
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="scheduler"></param>
        public void ClipAnimation(ClipAnimationCallbackDelegate callback, TaskScheduler scheduler)
        {
            //プロパティ取得
            int matrixLedWidth = this.MatrixLedWidth;
            int matrixLedHeight = this.MatrixLedHeight;
            string? originalImagePath = this.OriginalImagePath;
            BitmapSource? image = this.PreviewImage;
            AnimationMoveDirection moveDirection = this.MoveDirection;
            int moveSpeed = this.MoveSpeed;

            //コールバックを保存
            this._Callback = callback;

            //現スレッドの継続タスクでアニメーション切り抜き完了処理を行う
            // >> 完了処理を実行するスケジューラーを決定する
            TaskScheduler taskScheduler = scheduler;
            if (taskScheduler == null)
            {
                //無効の場合はカレントを使う
                taskScheduler = TaskScheduler.Current;
            }
            else
            {
                //有効の場合は指定されたものを使う
            }

            //タスク準備
            Task<ClipAnimationResult> t1 = Task.Run(() => { return this.ClipAnimationTask(image, originalImagePath, matrixLedWidth, matrixLedHeight, moveDirection, moveSpeed); });
            // >> 切り抜き処理の継続タスクに登録
            Task t2 = t1.ContinueWith(this.OnClipAnimationTaskFinish, taskScheduler);
        }

        /// <summary>
        /// アニメーション切り抜きタスク
        /// </summary>
        /// <param name="image"></param>
        /// <param name="path"></param>
        /// <param name="matrixLedWidth"></param>
        /// <param name="matrixLedHeight"></param>
        /// <param name="moveDirection"></param>
        /// <param name="moveSpeed"></param>
        /// <returns>切り抜きされた画像の出力パス</returns>
        private ClipAnimationResult ClipAnimationTask(BitmapSource? image, string? path, int matrixLedWidth, int matrixLedHeight, AnimationMoveDirection moveDirection, int moveSpeed)
        {
            //画像有効判定
            if (image == null)
            {
                //画像が無効の場合は処理できないので終了
                string msg = $"切り抜き対象の画像が無効です";
                CommonLogger.Warn(msg);
                return ClipAnimationResult.Failed(msg);
            }
            else
            {
                //画像が有効の場合は処理続行
                CommonLogger.Debug("切り抜き対象の画像が有効");
            }

            //出力フォルダーを生成
            string? outputFolder = null;
            try
            {
                //拡張子をのぞいたファイル名を取得
                string? fname = System.IO.Path.GetFileNameWithoutExtension(path);
                {
                    bool isNull = string.IsNullOrEmpty(fname);
                    if (isNull)
                    {
                        //無効の場合は修了
                        string msg = $"ファイル名の取得に失敗しました (path='{path}')";
                        CommonLogger.Warn(msg);
                        return ClipAnimationResult.Failed(msg);
                    }
                    else
                    {
                        //取得できた場合は処理続行
                        CommonLogger.Debug($"ファイル名の取得成功  (path='{path}' -> '{fname}')");
                    }
                }

                //ディレクトリ部を取得
                string? dir = System.IO.Path.GetDirectoryName(path);
                {
                    bool isNull = string.IsNullOrEmpty(dir);
                    if (isNull)
                    {
                        //無効の場合は修了
                        string msg = $"ディレクトリの取得に失敗しました (path='{path}')";
                        CommonLogger.Warn(msg);
                        return ClipAnimationResult.Failed(msg);
                    }
                    else
                    {
                        //取得できた場合は処理続行
                        CommonLogger.Debug($"ディレクトリの取得成功  (path='{path}' -> '{dir}')");
                    }
                }

                //出力フォルダ名を生成
                outputFolder = System.IO.Path.Combine(dir!, fname!);
                CommonLogger.Debug($"出力先フォルダ ('{dir}' + '{fname}' -> '{outputFolder}')");

                //出力フォルダを作成
                CommonLogger.Debug($"出力先フォルダの生成  ('{outputFolder}')");
                System.IO.Directory.CreateDirectory(outputFolder);
            }
            catch (Exception ex)
            {
                //例外は握りつぶす
                string msg = $"出力フォルダの作成で例外が発生しました (path='{path}' / outputFolder='{outputFolder}') ({ex})";
                CommonLogger.Warn(msg, ex);
                return ClipAnimationResult.Failed(msg);
            }

            //画像サイズを取得
            int imageWidth = image.PixelWidth;
            int imageHeight = image.PixelHeight;

            //移動速度から必要なフレーム数を計算
            // >> フレーム数 = (画像縦幅 - LED縦幅) / 移動速度
            // >> ただし余りが出る場合はコマ数を+1する必要がある
            // >> 画像縦幅は必ず整数なので、1を引くことで必ず[必要なコマ数-1]にしてから、最後に+1する
            int frameCount = ((imageHeight - matrixLedHeight - CommonConsts.Values.One.I) / moveSpeed) + CommonConsts.Values.One.I;
            CommonLogger.Debug($"フレーム数='{frameCount}'");

            //ファイル番号フォーマットを取得
            string fileNumberFormat = string.Empty;
            {
                int log = (int)Math.Log10(frameCount);
                int m = log + CommonConsts.Collection.Step;
                StringBuilder sb = new StringBuilder();
                for (int i = CommonConsts.Index.First; i < m; i += CommonConsts.Index.Step)
                {
                    sb.Append(CommonConsts.File.ZeroPrace);
                }
                fileNumberFormat = sb.ToString();
            }

            //TODO:  2025.09.26: 移動方向から開始位置と移動量を計算
            int startY = (int)CommonConsts.Points.Zero.Y;
            int moveY = moveSpeed;

            //出力画像パスを保存するリスト
            List<string> outputPaths = new List<string>();

            //モデル取得(シングルトンで生成してnullにならないためnullチェック省略)
            Models.Model model = this.Model;

            //レンダーターゲットビットマップを生成
            RenderTargetBitmap? renderBitmap = null;
            {
                var ret = model.CreateRenderTargetBitmap(matrixLedWidth, matrixLedHeight);
                if (ret.IsSuccess)
                {
                    //成功の場合は続行
                    CommonLogger.Debug("レンダーターゲットビットマップの生成に成功");
                }
                else
                {
                    //失敗の場合は終了
                    string msg = $"レンダーターゲットビットマップの生成に失敗しました (Width={matrixLedWidth}, Height={matrixLedHeight})";
                    CommonLogger.Warn(msg);
                    return ClipAnimationResult.Failed(msg);
                }

                //生成したレンダーターゲットビットマップを取得
                renderBitmap = ret.RenderBitmap;
            }

            //アニメーション切り抜き
            for (int i = CommonConsts.Index.First; i < frameCount; i += CommonConsts.Index.Step)
            {
                //切り抜き座標を計算
                // >> 2025.09.26:現状は縦方向のみ対応のため、Xは固定
                int x = (int)CommonConsts.Points.Zero.X;
                int y = startY - (moveY * i);

                //切り抜いた画像を描写
                {
                    var ret = model.RenderImage(renderBitmap, image, x, y, imageWidth, imageHeight);
                    if (ret.IsSuccess)
                    {
                        //成功の場合は続行
                        //CommonLogger.Debug("レンダーターゲットビットマップの描写に成功");
                    }
                    else
                    {
                        //失敗の場合は終了
                        string msg = $"レンダリングターゲットビットマップの描写に失敗しました (X={x}, Y={y}, ImageWidth={imageWidth}, ImageHeight={imageHeight})";
                        CommonLogger.Warn(msg);
                        return ClipAnimationResult.Failed(msg);
                    }
                }

                //切り抜いた画像を連番で保存
                string? savePath = null;
                try
                {
                    //ファイル名を決定
                    string fileNumberText = i.ToString(fileNumberFormat);
                    string saveName = string.Format(CommonConsts.File.PngFileFormat, fileNumberText);
                    savePath = System.IO.Path.Combine(outputFolder, saveName);

                    //PNGで保存
                    PngBitmapEncoder png = new PngBitmapEncoder();
                    BitmapFrame frame = BitmapFrame.Create(renderBitmap);
                    png.Frames.Add(frame);
                    using (System.IO.Stream stm = System.IO.File.Create(savePath))
                    {
                        png.Save(stm);
                    }

                    //保存したファイルのパスをリストに追加
                    outputPaths.Add(savePath);
                }
                catch (Exception ex)
                {
                    //例外は握りつぶす
                    string msg = $"PNG保存で例外が発生しました (path='{savePath}') ({ex})";
                    CommonLogger.Warn(msg, ex);
                    return ClipAnimationResult.Failed(msg);
                }
            }

            //ここまできたら成功
            return ClipAnimationResult.Success(outputPaths);
        }

        /// <summary>
        /// アニメーション切り抜きタスク完了
        /// </summary>
        /// <param name="task"></param>
        private void OnClipAnimationTaskFinish(Task<ClipAnimationResult> task)
        {
            //タスク実行結果を取得
            ClipAnimationResult result = task.Result;

            //完了コールバック
            ClipAnimationCallbackDelegate? callback = this._Callback;
            if (callback == null)
            {
                //無効の場合は何もしない
                return;
            }
            else
            {
                //続行
            }

            //コールバック実行
            callback(result);
        }
    }
}
