using System.Windows.Media.Imaging;

namespace MicroSign.Core.ViewModels
{
    partial class AnimationImageItem
    {
        /// <summary>
        /// 指定された横・縦サイズか判定する
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public bool IsFit(int width, int height)
        {
            // >> 画像を取得
            BitmapSource? bmp = this.Image;
            if (bmp == null)
            {
                //画像がない場合は失敗にする
                return false;
            }
            else
            {
                //画像が有効の場合は処理続行
            }

            //画像ピクセルサイズを取得
            int pixelWidth = bmp.PixelWidth;
            int pixelHeight = bmp.PixelHeight;

            //判定
            //2025.07.20:CS)杉原:静的関数を用意 >>>>> ここから
            //// >> 横幅
            //if(pixelWidth == width)
            //{
            //    //適合する場合は処理続行
            //}
            //else
            //{
            //    //適合しない場合は失敗にする
            //    return false;
            //}
            //
            //// >> 縦幅
            //if (pixelHeight == height)
            //{
            //    //適合する場合は処理続行
            //}
            //else
            //{
            //    //適合しない場合は失敗にする
            //    return false;
            //}
            //
            ////ここまで来たら適合する
            //return true;
            //----------
            return AnimationImageItem.IsFit(width, height, pixelWidth, pixelHeight);
            //2025.07.20:CS)杉原:静的関数を用意 <<<<< ここまで
        }

        /// <summary>
        /// 指定された横・縦サイズか判定する
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="pixelWidth"></param>
        /// <param name="pixelHeight"></param>
        /// <returns></returns>
        public static bool IsFit(int width, int height, int pixelWidth, int pixelHeight)
        {
            //判定
            // >> 横幅
            if (pixelWidth == width)
            {
                //適合する場合は処理続行
            }
            else
            {
                //適合しない場合は失敗にする
                return false;
            }

            // >> 縦幅
            if (pixelHeight == height)
            {
                //適合する場合は処理続行
            }
            else
            {
                //適合しない場合は失敗にする
                return false;
            }

            //ここまで来たら適合する
            return true;
        }
    }
}
