using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// 画像レンダリング
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="imageSource"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="imageWidth"></param>
        /// <param name="imageHeight"></param>
        /// <returns></returns>
        /// <remarks>
        /// DrawingVisualを使用するためUIスレッド以外でも実行可能
        /// </remarks>
        public (bool IsSuccess, string Message) RenderImage(RenderTargetBitmap? bmp, ImageSource? imageSource, double x, double y, double imageWidth, double imageHeight)
        {
            //ビットマップ有効判定
            if (bmp == null)
            {
                //レンダリングターゲットビットマップが無効の場合は処理できないので終了
                return (false, CommonLogger.Warn("レンダリングターゲットビットマップが無効です"));
            }
            else
            {
                //レンダリングターゲットビットマップが有効の場合は処理続行
                //ログが多いのでコメント化:CommonLogger.Debug("レンダリングターゲットビットマップが有効");
            }

            //横幅取得
            int width = bmp.PixelWidth;
            if (CommonConsts.Values.Zero.I < width)
            {
                //有効の場合は処理続行
                //ログが多いのでコメント化:CommonLogger.Debug($"横幅有効 ({width})");
            }
            else
            {
                //無効の場合は処理できないので終了
                return (false, CommonLogger.Warn($"レンダリングターゲットビットマップの横幅が無効です ({width})"));
            }

            //縦幅取得
            int height = bmp.PixelHeight;
            if (CommonConsts.Values.Zero.I < height)
            {
                //有効の場合は処理続行
                //ログが多いのでコメント化:CommonLogger.Debug($"縦幅有効 ({height})");
            }
            else
            {
                //無効の場合は処理できないので終了
                return (false, CommonLogger.Warn($"レンダリングターゲットビットマップの縦幅が無効です ({height})"));
            }

            //描写
            try
            {
                //ビジュアルを作成
                DrawingVisual visual = new DrawingVisual();

                //描画コンテキストを開く
                DrawingContext drawingContext = visual.RenderOpen();

                //画像を描画
                drawingContext.DrawImage(imageSource, new Rect(x, y, imageWidth, imageHeight));

                //描画コンテキストを閉じる
                drawingContext.Close();

                //ビットマップに描画
                bmp.Render(visual);
            }
            catch (Exception ex)
            {
                return (false, CommonLogger.Warn($"レンダリングターゲットビットマップの描写に失敗しました (Width={width}, Height={height}, X={x}, Y={y}, ImageWidth={imageWidth}, ImageHeight={imageHeight})", ex));
            }

            //ここまで来たら成功で終了
            return (true, string.Empty);
        }
    }
}
