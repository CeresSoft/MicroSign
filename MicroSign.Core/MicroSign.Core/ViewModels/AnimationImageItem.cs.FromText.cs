using System.Windows.Media.Imaging;

namespace MicroSign.Core.ViewModels
{
    partial class AnimationImageItem
    {
        //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
        ///// <summary>
        ///// テキストからインスタンスを生成
        ///// </summary>
        ///// <param name="displayPeriod">表示期間(秒)</param>
        ///// <param name="selectFontSize">選択フォントサイズ</param>
        ///// <param name="selectFontColor">選択フォント色</param>
        ///// <param name="displayText">表示テキスト</param>
        ///// <param name="image">読込した画像</param>
        ///// <param name="outputData">出力データ(=byte配列)</param>
        ///// <param name="previewImage">出力データを画像にしたもの(プレビュー用)</param>
        ///// <returns></returns>
        //public static AnimationImageItem FromText(double displayPeriod, int selectFontSize, int selectFontColor, string? displayText, BitmapSource? image, byte[]? outputData, BitmapSource? previewImage)
        //----------
        /// <summary>
        /// テキストからインスタンスを生成
        /// </summary>
        /// <param name="displayPeriod">表示期間(秒)</param>
        /// <param name="selectFontSize">選択フォントサイズ</param>
        /// <param name="selectFontColor">選択フォント色</param>
        /// <param name="displayText">表示テキスト</param>
        /// <param name="image">読込した画像</param>
        /// <returns></returns>
        /// <remarks>
        /// 2025.08.12:CS)杉原:パレット処理の流れを変更
        /// 不要な引数を削除しました
        /// </remarks>
        public static AnimationImageItem FromText(double displayPeriod, int selectFontSize, int selectFontColor, string? displayText, BitmapSource? image)
        //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで
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

                //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
                ////2023.11.30:CS)土田:プレビュー表示の改造 >>>>> ここから
                ////----------
                //OutputData = outputData,
                //PreviewImage = previewImage,
                ////2023.11.30:CS)土田:プレビュー表示の改造 <<<<< ここまで
                //----------
                // >> 削除
                //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで

                //2023.12.24:CS)杉原:アニメーション画像タイプ追加 >>>>> ここから
                //----------
                // >> テキストにする
                ImageType = AnimationImageType.Text,
                //2023.12.24:CS)杉原:アニメーション画像タイプ追加 <<<<< ここまで
            };

            //終了
            return animationImageItem;
        }
    }
}
