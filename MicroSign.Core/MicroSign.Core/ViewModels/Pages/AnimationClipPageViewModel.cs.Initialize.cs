using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace MicroSign.Core.ViewModels.Pages
{
    partial class AnimationClipPageViewModel
    {
        /// <summary>
        /// ViewModel初期化
        /// </summary>
        public void Initialize()
        {
            //オリジナル画像を取得
            BitmapSource? originalImage = this.OriginalImage;
            if (originalImage == null)
            {
                //オリジナル画像が無効の場合は初期化失敗
                //TODO: 2025.09.22: this.SetStatus(AnimationTextPageStateKind.Failed, CommonLogger.Warn($"レンダリングターゲットビットマップの生成に失敗しました (理由={ret.Message})"));
                return;
            }
            else
            {
                //有効の場合は続行
            }

            //オリジナル画像の横幅を取得
            int imageWidth = originalImage.PixelWidth;

            //オリジナル画像の縦幅を取得
            int imageHeight = originalImage.PixelHeight;

            //マトリクスLEDの横幅を取得
            int matrixLedWidth = this.MatrixLedWidth;

            //マトリクスLEDの縦幅を取得
            int matrixLedHeight = this.MatrixLedHeight;

            //マトリクスLEDの横幅にあわせて画像を縮小
            {
                //オリジナル:マトリクスLEDの比率を計算
                double ratio = matrixLedWidth / (double)imageWidth;

                //プレビュー画像の縦幅を計算
                double previewHeightD = imageHeight * ratio;
                // >> 整数に丸める
                int previewHeight = (int)previewHeightD;

                //TODO: 2025.09.22: 縦幅がマトリクスLEDより小さい場合は現状は非対応とする
                if (previewHeight < matrixLedHeight)
                {
                    //TODO: 2025.09.22: this.SetStatus(AnimationTextPageStateKind.Failed, CommonLogger.Warn($"縦幅がマトリクスLEDの縦幅未満です"));
                    return;
                }
                else
                {
                    //大きい場合は続行
                }

                //レンダリングターゲットビットマップを生成
                var ret = this.Model.CreateRenderTargetBitmap(matrixLedWidth, previewHeight);
                if (ret.IsSuccess)
                {
                    //成功の場合は続行
                }
                else
                {
                    //失敗の場合
                    //TODO: 2025.09.22: this.SetStatus(AnimationTextPageStateKind.Failed, CommonLogger.Warn($"レンダリングターゲットビットマップの生成に失敗しました (理由={ret.Message})"));
                    return;
                }

                //レンダリングターゲットビットマップを取得
                RenderTargetBitmap? bmp = ret.RenderBitmap;

                //ビットマップ有効判定
                if (bmp == null)
                {
                    //レンダリングターゲットビットマップが無効の場合は処理できないので終了
                    //TODO: 2025.09.22: this.SetStatus(AnimationTextPageStateKind.Failed, CommonLogger.Warn($"レンダリングターゲットビットマップが無効です"));
                    return;
                }
                else
                {
                    //レンダリングターゲットビットマップが有効の場合は処理続行
                    CommonLogger.Debug("レンダリングターゲットビットマップが有効");
                }

                //プレビュー画像を描画
                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                image.Width = matrixLedWidth;
                image.Height = previewHeight;
                image.Stretch = System.Windows.Media.Stretch.Fill;
                image.Source = originalImage;
                image.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                image.Arrange(new Rect(CommonConsts.Points.Zero.X, CommonConsts.Points.Zero.Y, matrixLedWidth, previewHeight));

                //ビットマップに描写
                bmp.Render(image);

                //画像を保存
                this.PreviewImage = bmp;
            }

            //初期化完了にする
            //TODO: 2025.09.22: this.SetStatus(AnimationTextPageStateKind.Initialized, string.Empty);
        }
    }
}
