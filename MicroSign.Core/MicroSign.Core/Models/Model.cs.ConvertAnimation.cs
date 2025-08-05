using MicroSign.Core.ViewModels;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// 変換
        /// </summary>
        /// <param name="name">クラス名</param>
        /// <param name="formatKind">フォーマット種類</param>
        /// <param name="animationImages">アニメーション画像</param>
        /// <param name="redThreshold">赤閾値</param>
        /// <param name="greenThreshold">緑閾値</param>
        /// <param name="blueThreshold">青閾値</param>
        /// <param name="matrixLedWidth">マトリクスLED横ドット数</param>
        /// <param name="matrixLedHeight">マトリクスLED縦ドット数</param>
        /// <param name="matrixLedBrightness">マトリクスLED明るさ</param>
        /// <returns></returns>
        public ConvertResult ConvertAnimation(string? name, FormatKinds formatKind, AnimationImageItemCollection animationImages, int redThreshold, int greenThreshold, int blueThreshold, int matrixLedWidth, int matrixLedHeight, int matrixLedBrightness)
        {
            switch (formatKind)
            {
                case FormatKinds.HighSpeed:
                case FormatKinds.TestColor64:
                case FormatKinds.TestColor256:
                    return ConvertResult.Failed($"アニメーション画像に変換できない変換フォーマットです ({formatKind})");

                case FormatKinds.Color64:
                    return this.ConvertAnimationColor64(animationImages, name, redThreshold, greenThreshold, blueThreshold, matrixLedWidth, matrixLedHeight, matrixLedBrightness);

                case FormatKinds.Color256:
                    return this.ConvertAnimationColor256(animationImages, name, redThreshold, greenThreshold, blueThreshold, matrixLedWidth, matrixLedHeight, matrixLedBrightness);

                //2025.08.05:CS)土田:インデックスカラー対応 >>>>> ここから
                //----------
                case FormatKinds.IndexColor:
                    return this.ConvertAnimationIndexColor(animationImages, name, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
                //2025.08.05:CS)土田:インデックスカラー対応 <<<<< ここまで

                default:
                    //不明な形式
                    return ConvertResult.Failed($"不明な変換フォーマット ({formatKind})");
            }
        }
    }
}
