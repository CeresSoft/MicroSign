using System.Runtime.Serialization;
using System.Windows.Media.Imaging;
using static MicroSign.Core.Models.Model;

namespace MicroSign.Core.ViewModels
{
    /// <summary>
    /// アニメーション画像アイテム
    /// </summary>
    [DataContract]
    public partial class AnimationImageItem : NotifyPropertyChangedObject
    {
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>FromImageFile()かFromText()以外で生成できないようにprivateにします</remarks>
        private AnimationImageItem() { }

        /// <summary>
        /// 画像ファイルからインスタンスを生成
        /// </summary>
        /// <param name="displayPeriod">表示期間(秒)</param>
        /// <param name="imagePath">画像パス</param>
        /// <param name="image">読込した画像</param>
        /// <param name="outputData">出力データ(=byte配列)</param>
        /// <param name="previewImage">出力データを画像にしたもの(プレビュー用)</param>
        /// <returns></returns>
        public static AnimationImageItem FromImageFile(double displayPeriod, string imagePath, BitmapSource? image, byte[]? outputData, BitmapSource? previewImage)
        {
            //インスタンス生成
            AnimationImageItem animationImageItem = new AnimationImageItem()
            {
                Name = System.IO.Path.GetFileName(imagePath),
                Path = imagePath,
                Image = image,
                DisplayPeriod = displayPeriod,
                //2023.11.30:CS)土田:プレビュー表示の改造 >>>>> ここから
                //----------
                OutputData = outputData,
                PreviewImage = previewImage,
                //2023.11.30:CS)土田:プレビュー表示の改造 <<<<< ここまで
                //2023.12.24:CS)杉原:アニメーション画像タイプ追加 >>>>> ここから
                //----------
                // >> 画像ファイルにする
                ImageType = AnimationImageType.ImageFile,
                //2023.12.24:CS)杉原:アニメーション画像タイプ追加 <<<<< ここまで
            };

            //終了
            return animationImageItem;
        }

        /// <summary>
        /// テキストからインスタンスを生成
        /// </summary>
        /// <param name="displayPeriod">表示期間(秒)</param>
        /// <param name="selectFontSize">選択フォントサイズ</param>
        /// <param name="selectFontColor">選択フォント色</param>
        /// <param name="displayText">表示テキスト</param>
        /// <param name="image">読込した画像</param>
        /// <param name="outputData">出力データ(=byte配列)</param>
        /// <param name="previewImage">出力データを画像にしたもの(プレビュー用)</param>
        /// <returns></returns>
        public static AnimationImageItem FromText(double displayPeriod, int selectFontSize, int selectFontColor, string? displayText, BitmapSource? image, byte[]? outputData, BitmapSource? previewImage)
        {
            //インスタンス生成
            AnimationImageItem animationImageItem = new AnimationImageItem()
            {
                Name = displayText,
                SelectFontSize = selectFontSize,
                SelectFontColor = selectFontColor,
                DisplayText = displayText,
                Image = image,
                DisplayPeriod = displayPeriod,
                //2023.11.30:CS)土田:プレビュー表示の改造 >>>>> ここから
                //----------
                OutputData = outputData,
                PreviewImage = previewImage,
                //2023.11.30:CS)土田:プレビュー表示の改造 <<<<< ここまで
                //2023.12.24:CS)杉原:アニメーション画像タイプ追加 >>>>> ここから
                //----------
                // >> テキストにする
                ImageType = AnimationImageType.Text,
                //2023.12.24:CS)杉原:アニメーション画像タイプ追加 <<<<< ここまで
            };

            //終了
            return animationImageItem;
        }

        /// <summary>
        /// テキストを更新する
        /// </summary>
        /// <param name="selectFontSize">選択フォントサイズ</param>
        /// <param name="selectFontColor">選択フォント色</param>
        /// <param name="displayText">表示テキスト</param>
        /// <param name="image">読込した画像</param>
        /// <param name="outputData">出力データ(=byte配列)</param>
        /// <param name="previewImage">出力データを画像にしたもの(プレビュー用)</param>
        public void UpdateText(int selectFontSize, int selectFontColor, string? displayText, BitmapSource? image, byte[]? outputData, BitmapSource? previewImage)
        {
            this.SelectFontSize = selectFontSize;
            this.SelectFontColor = selectFontColor;
            this.DisplayText = displayText;
            this.Image = image;
            this.OutputData = outputData;
            this.PreviewImage = previewImage;
        }

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
