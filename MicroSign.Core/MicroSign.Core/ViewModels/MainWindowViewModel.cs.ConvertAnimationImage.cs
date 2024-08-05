using System.Windows.Media.Imaging;

namespace MicroSign.Core.ViewModels
{
    partial class MainWindowViewModel
    {
        /// <summary>
        /// アニメーション画像変換
        /// </summary>
        /// <param name="image">変換する画像</param>
        /// <returns>変換結果</returns>
        /// <remarks>
        /// 2023.11.30:CS)土田:プレビュー表示の改造
        /// 画像を読み込んだ時点でカラー変換まで行うため、単独で変換処理を呼べるようにする
        /// </remarks>
        public Models.Model.ConvertImageResult ConvertAnimationImage(BitmapSource? image)
        {
            //閾値取得
            //TODO: 2023.11.30:CS)土田:HightSpeedは現状未対応
            //int redThreshold = this.RedThreshold;
            //int greenThreshold = this.GreenThreshold;
            //int blueThreshold = this.BlueThreshold;

            //フォーマット
            FormatKinds formatKind = this.FormatKind;

            //モデルにリレー
            return this.Model.ConvertImage(image, formatKind);
        }
    }
}
