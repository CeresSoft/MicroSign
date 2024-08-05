using System;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// 画像読込
        /// </summary>
        /// <param name="imagePath">画像パス</param>
        /// <returns></returns>
        public BitmapImage? GetImage(string? imagePath)
        {
            //画像パス有効判定
            if(imagePath == null)
            {
                //無効の場合は即終了
                return null;
            }
            else
            {
                //有効の場合は空チェック
                bool isNull = string.IsNullOrWhiteSpace(imagePath);
                if (isNull)
                {
                    //パスが無効の場合は即終了
                    return null;
                }
                else
                {
                    //パス無効の場合は処理続行
                }
            }

            //画像ファイル読込
            byte[] imageData = imageData = System.IO.File.ReadAllBytes(imagePath);

            //画像データ有効判定
            {
                int n = CommonUtils.GetCount(imageData);
                if (CommonConsts.Collection.Empty < n)
                {
                    //データがある場合は処理続行
                }
                else
                {
                    //データが無い場合は終了
                    return null;
                }
            }

            //画像データに変換
            BitmapImage image = new BitmapImage();

            // >> https://pierre3.hatenablog.com/entry/2015/10/25/001207
            // >> BitmapImage.StreamSourceに渡したStreamは解除できない(=nullを渡しても解除できない)ので
            // >>  Streamをラップし、ラップしたStreamのDispose
            using (ImageDataStream ids = new ImageDataStream(imageData))
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.CreateOptions = BitmapCreateOptions.None;
                image.StreamSource = ids;

                image.EndInit();
                image.Freeze();
            }

            //終了
            return image;
        }
    }
}
