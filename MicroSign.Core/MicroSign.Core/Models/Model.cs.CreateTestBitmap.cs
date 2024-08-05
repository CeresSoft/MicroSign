using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// テスト画像を生成
        /// </summary>
        /// <param name="imagePixelWidth"></param>
        /// <param name="imagePixelHeight"></param>
        /// <returns></returns>
        private WriteableBitmap CreateTestBitmap(int imagePixelWidth, int imagePixelHeight)
        {
            //1ピクセルのバイト数
            // >> RGBA 32bit固定の書き方 32/8=4になります
            // >> ほかのピクセルフォーマットに対応する場合はここのコードを変更してください
            int byteParPixel = PixelFormats.Bgra32.BitsPerPixel / CommonConsts.BitCount.BYTE;

            //画像ピクセル取得
            int imagePixelStride = imagePixelWidth * byteParPixel;

            //テスト画像生成先
            int bgra32Size = imagePixelStride * imagePixelHeight;
            byte[] testImage = new byte[bgra32Size];

            //Y座標ループ
            for (int y = CommonConsts.Index.First; y < imagePixelHeight; y += CommonConsts.Index.Step)
            {
                //X軸ループ
                for (int x = CommonConsts.Index.First; x < imagePixelWidth; x += CommonConsts.Index.Step)
                {
                    //テストデータ
                    // >> 0～(画像横幅-1)を255～0に変換
                    double v = this.RatioConvertion(MicroSignConsts.RGB.Brightness.Min, imagePixelWidth, MicroSignConsts.RGB.Brightness.Max255, MicroSignConsts.RGB.Brightness.Min, x);
                    int B = CommonConsts.Values.Zero.I;
                    int G = CommonConsts.Values.Zero.I;
                    int R = CommonConsts.Values.Zero.I;
                    if (y < (imagePixelHeight / 3))
                    {
                        //上～1/3は赤
                        R = (int)v;
                    }
                    else if (y < ((imagePixelHeight * 2) / 3))
                    {
                        //1/3～2/3は緑
                        G = (int)v;
                    }
                    else
                    {
                        //2/3～下は青
                        B = (int)v;
                    }

                    //インデックス計算
                    int index = (y * imagePixelStride) + (x * byteParPixel);
                    int blueIndex = index;
                    int greenIndex = blueIndex + CommonConsts.Index.Step;
                    int redIndex = greenIndex + CommonConsts.Index.Step;
                    int alphaIndex = redIndex + CommonConsts.Index.Step;

                    //設定
                    testImage[blueIndex] = (byte)B;
                    testImage[greenIndex] = (byte)G;
                    testImage[redIndex] = (byte)R;
                    testImage[alphaIndex] = byte.MaxValue;
                }
            }

            //画像を設定
            WriteableBitmap testBitmap = new WriteableBitmap(imagePixelWidth, imagePixelHeight, CommonConsts.DPIs.DIP, CommonConsts.DPIs.DIP, PixelFormats.Bgra32, null);
            {
                Int32Rect rect = new Int32Rect((int)CommonConsts.Points.Zero.X, (int)CommonConsts.Points.Zero.Y, imagePixelWidth, imagePixelHeight);
                testBitmap.WritePixels(rect, testImage, imagePixelStride, CommonConsts.Index.First);
            }

            return testBitmap;
        }
    }
}
