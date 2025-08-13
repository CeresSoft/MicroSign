using System.Windows.Media.Imaging;

namespace MicroSign.Core.ViewModels
{
    partial class AnimationImageItem
    {
        //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
        ///// <summary>
        ///// テキストを更新する
        ///// </summary>
        ///// <param name="selectFontSize">選択フォントサイズ</param>
        ///// <param name="selectFontColor">選択フォント色</param>
        ///// <param name="displayText">表示テキスト</param>
        ///// <param name="image">読込した画像</param>
        ///// <param name="outputData">出力データ(=byte配列)</param>
        ///// <param name="previewImage">出力データを画像にしたもの(プレビュー用)</param>
        //public void UpdateText(int selectFontSize, int selectFontColor, string? displayText, BitmapSource? image, byte[]? outputData, BitmapSource? previewImage)
        //----------
        // >> プレビュー画像が不要になりました
        /// <summary>
        /// テキストを更新する
        /// </summary>
        /// <param name="selectFontSize">選択フォントサイズ</param>
        /// <param name="selectFontColor">選択フォント色</param>
        /// <param name="displayText">表示テキスト</param>
        /// <param name="image">読込した画像</param>
        public void UpdateText(int selectFontSize, int selectFontColor, string? displayText, BitmapSource? image)
        //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで
        {
            this.SelectFontSize = selectFontSize;
            this.SelectFontColor = selectFontColor;
            this.DisplayText = displayText;
            this.Image = image;
            //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
            //this.OutputData = outputData;
            //this.PreviewImage = previewImage;
            //----------
            //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで
        }
    }
}
