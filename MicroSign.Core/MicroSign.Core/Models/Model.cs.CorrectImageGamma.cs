using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// 画像のガンマ補正結果
        /// </summary>
        private struct CorrectImageGammaResult
        {
            /// <summary>
            /// 成功フラグ
            /// </summary>
            public bool IsSuccess;

            /// <summary>
            /// メッセージ
            /// </summary>
            public string? Message;

            /// <summary>
            /// 補正画像
            /// </summary>
            public WriteableBitmap? CorrectedImage;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="isSuccess">成功フラグ</param>
            /// <param name="message">メッセージ</param>
            /// <param name="correctedImage">補正画像</param>
            private CorrectImageGammaResult(bool isSuccess, string? message, WriteableBitmap? correctedImage)
            {
                this.IsSuccess = isSuccess;
                this.Message = message;
                this.CorrectedImage = correctedImage;
            }

            /// <summary>
            /// 失敗
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <returns></returns>
            public static CorrectImageGammaResult Failed(string message)
            {
                CorrectImageGammaResult result = new CorrectImageGammaResult(false, message, null);
                return result;
            }

            /// <summary>
            /// 成功
            /// </summary>
            /// <param name="correctedImage">補正画像</param>
            /// <returns></returns>
            public static CorrectImageGammaResult Success(WriteableBitmap? correctedImage)
            {
                CorrectImageGammaResult result = new CorrectImageGammaResult(true, null, correctedImage);
                return result;
            }
        }

        /// <summary>
        /// 画像のガンマ補正
        /// </summary>
        /// <param name="image">入力画像</param>
        /// <param name="gamma">ガンマ値</param>
        /// <returns>補正後の画像</returns>
        private CorrectImageGammaResult CorrectImageGamma(BitmapSource? image, double gamma)
        {
            //入力画像有効判定
            if (image == null)
            {
                //画像が無効の場合は終了
                return CorrectImageGammaResult.Failed($"入力画像が無効です");
            }
            else
            {
                //有効の場合は処理続行
            }

            //画像ピクセル取得
            // >> 検証済の値を取得
            int imagePixelWidth = image.PixelWidth;
            int imagePixelHeight = image.PixelHeight;

            //画像フォーマットを変換
            // >> https://learn.microsoft.com/ja-jp/dotnet/desktop/wpf/graphics-multimedia/how-to-convert-a-bitmapsource-to-a-different-pixelformat?view=netframeworkdesktop-4.8&viewFallbackFrom=netdesktop-6.0
            FormatConvertedBitmap newFormatedBitmapSource = new FormatConvertedBitmap();
            newFormatedBitmapSource.BeginInit();
            newFormatedBitmapSource.Source = image;
            newFormatedBitmapSource.DestinationFormat = PixelFormats.Bgra32;
            newFormatedBitmapSource.EndInit();
            newFormatedBitmapSource.Freeze();

            //1ピクセルのバイト数
            // >> RGBA 32bit固定の書き方 32/8=4になります
            // >> ほかのピクセルフォーマットに対応する場合はここのコードを変更してください
            int byteParPixel = newFormatedBitmapSource.DestinationFormat.BitsPerPixel / CommonConsts.BitCount.BYTE;

            //画像のストライドを計算
            int imagePixelStride = imagePixelWidth * byteParPixel;

            //画像取得
            int bgra32Size = imagePixelStride * imagePixelHeight;
            byte[] bgra32 = new byte[bgra32Size];
            newFormatedBitmapSource.CopyPixels(bgra32, imagePixelStride, CommonConsts.Index.First);

            //Y座標ループ
            for (int y = CommonConsts.Index.First; y < imagePixelHeight; y += CommonConsts.Index.Step)
            {
                //X軸ループ
                for (int x = CommonConsts.Index.First; x < imagePixelWidth; x += CommonConsts.Index.Step)
                {
                    //インデックス計算
                    int index = (y * imagePixelStride) + (x * byteParPixel);
                    int blueIndex = index;
                    int greenIndex = blueIndex + CommonConsts.Index.Step;
                    int redIndex = greenIndex + CommonConsts.Index.Step;

                    //色を取得
                    // >> Alphaは補正しない
                    int redValue = bgra32[redIndex];
                    int greenValue = bgra32[greenIndex];
                    int blueValue = bgra32[blueIndex];

                    //ガンマ補正
                    int correctedRedValue = CommonUtils.CorrectGamma8bit(redValue, gamma);
                    int correctedGreenValue = CommonUtils.CorrectGamma8bit(greenValue, gamma);
                    int correctedBlueValue = CommonUtils.CorrectGamma8bit(blueValue, gamma);

                    //色を置き換え
                    bgra32[redIndex] = (byte)correctedRedValue;
                    bgra32[greenIndex] = (byte)correctedGreenValue;
                    bgra32[blueIndex] = (byte)correctedBlueValue;
                }
            }

            //補正画像生成先
            // >> 入力画像と同じサイズにする
            WriteableBitmap correctedBitmap = new WriteableBitmap(imagePixelWidth, imagePixelHeight, CommonConsts.DPIs.DIP, CommonConsts.DPIs.DIP, PixelFormats.Bgra32, null);

            //補正後の画像を設定
            {
                Int32Rect rect = new Int32Rect((int)CommonConsts.Points.Zero.X, (int)CommonConsts.Points.Zero.Y, imagePixelWidth, imagePixelHeight);
                correctedBitmap.WritePixels(rect, bgra32, imagePixelStride, CommonConsts.Index.First);
            }

            //ここまできたら成功で終了
            return CorrectImageGammaResult.Success(correctedBitmap);
        }
    }
}
