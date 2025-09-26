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

                //レンダーターゲットビットマップを生成
                RenderTargetBitmap? renderBitmap = null;
                {
                    var ret = this.Model.CreateRenderTargetBitmap(matrixLedWidth, previewHeight);
                    if (ret.IsSuccess)
                    {
                        //成功の場合は続行
                    }
                    else
                    {
                        //失敗の場合は終了
                        //TODO: 2025.09.22: this.SetStatus(AnimationTextPageStateKind.Failed, CommonLogger.Warn($"レンダリングターゲットビットマップの生成に失敗しました (理由={ret.Message})"));
                        return;
                    }

                    //生成したレンダーターゲットビットマップを取得
                    renderBitmap = ret.RenderBitmap;
                }

                //プレビュー画像を描画
                {
                    var ret = this.Model.RenderImage(renderBitmap, originalImage, CommonConsts.Points.Zero.X, CommonConsts.Points.Zero.Y, matrixLedWidth, previewHeight);
                    if (ret.IsSuccess)
                    {
                        //成功の場合は処理続行
                    }
                    else
                    {
                        //失敗の場合は終了
                        //TODO: 2025.09.22: this.SetStatus(AnimationTextPageStateKind.Failed, CommonLogger.Warn($"プレビュー画像を描画に失敗しました (理由={ret.Message})"));
                        return;
                    }
                }

                //内容が確定したのでフリーズする
                renderBitmap?.Freeze();

                //画像を保存
                this.PreviewImage = renderBitmap;
            }

            //初期化完了にする
            //TODO: 2025.09.22: this.SetStatus(AnimationTextPageStateKind.Initialized, string.Empty);
        }
    }
}
