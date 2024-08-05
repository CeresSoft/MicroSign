using System.Windows.Media.Imaging;

namespace MicroSign.Core.ViewModels
{
    partial class MainWindowViewModel
    {
        /// <summary>
        /// 変換
        /// </summary>
        /// <param name="image">変換する画像</param>
        /// <returns>true=成功/false=失敗</returns>
        public bool Convert(BitmapSource? image)
        {
            //ここに来た場合は選択アニメーション画像を未選択(=null)にする
            this.SetSelectAnimationImage(null);

            //初期化
            this.LoadImage = image;
            this.ConvertImage = null;
            this.Code = null;

            //クラス名
            string? name = this.Name;

            //閾値取得
            int redThreshold = this.RedThreshold;
            int greenThreshold = this.GreenThreshold;
            int blueThreshold = this.BlueThreshold;

            //フォーマット
            FormatKinds formatKind = this.FormatKind;

            //マトリクスLEDの設定値取得
            int matrixLedWidth = this.MatrixLedWidth;
            int matrixLedHeight = this.MatrixLedHeight;
            int matrixLedBrightness = this.MatrixLedBrightness;

            //変換
            Models.Model.ConvertResult ret = this.Model.Convert(image, name, formatKind, redThreshold, greenThreshold, blueThreshold, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
            this.ConvertImage = ret.ConvertImage;
            this.Code = ret.Code;

            //終了
            return ret.IsSuccess;
        }
    }
}
