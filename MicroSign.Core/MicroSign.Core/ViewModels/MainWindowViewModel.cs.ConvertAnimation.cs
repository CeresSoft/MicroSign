using MicroSign.Core.Models.PanelConfigs;

namespace MicroSign.Core.ViewModels
{
    partial class MainWindowViewModel
    {
        /// <summary>
        /// アニメーション変換
        /// </summary>
        /// <returns>true=成功/false=失敗</returns>
        public (bool IsSuccess, string? Code) ConvertAnimation()
        {
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

            //アニメーション画像コレクション
            // >> コンストラクタで生成しているのでnullチェック不要
            AnimationImageItemCollection animationImages = this.AnimationImages;

            //変換
            Models.Model.ConvertResult ret = this.Model.ConvertAnimation(name, formatKind, animationImages, redThreshold, greenThreshold, blueThreshold, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
            this.ConvertImage = ret.ConvertImage;
            this.Code = ret.Code;

            //終了
            return (ret.IsSuccess, ret.Code);
        }
    }
}
