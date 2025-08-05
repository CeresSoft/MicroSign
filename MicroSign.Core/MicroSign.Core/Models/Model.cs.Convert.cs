using System;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// 変換結果
        /// </summary>
        public struct ConvertResult
        {
            /// <summary>
            /// 成功フラグ
            /// </summary>
            public readonly bool IsSuccess;

            /// <summary>
            /// 変換画像
            /// </summary>
            public readonly WriteableBitmap? ConvertImage;

            /// <summary>
            /// コード
            /// </summary>
            public readonly string Code;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="isSuccess">成功フラグ</param>
            /// <param name="convertImage"></param>
            /// <param name="code"></param>
            private ConvertResult(bool isSuccess, WriteableBitmap? convertImage, string code)
            {
                this.IsSuccess = isSuccess;
                this.ConvertImage = convertImage;
                this.Code = code;
            }

            /// <summary>
            /// 失敗
            /// </summary>
            /// <param name="code">エラーメッセージを入れる</param>
            /// <returns></returns>
            public static ConvertResult Failed(string code)
            {
                ConvertResult result = new ConvertResult(false, null, code);
                return result;
            }

            /// <summary>
            /// 成功
            /// </summary>
            /// <param name="convertImage">変換画像</param>
            /// <param name="code">コード</param>
            /// <returns></returns>
            public static ConvertResult Sucess(WriteableBitmap? convertImage, string code)
            {
                ConvertResult result = new ConvertResult(true, convertImage, code);
                return result;
            }
        }

        /// <summary>
        /// 変換
        /// </summary>
        /// <param name="image">画像</param>
        /// <param name="name">クラス名</param>
        /// <param name="formatKind">フォーマット種類</param>
        /// <param name="redThreshold">赤閾値</param>
        /// <param name="greenThreshold">緑閾値</param>
        /// <param name="blueThreshold">青閾値</param>
        /// <param name="matrixLedWidth">マトリクスLED横ドット数</param>
        /// <param name="matrixLedHeight">マトリクスLED縦ドット数</param>
        /// <param name="matrixLedBrightness">マトリクスLED明るさ</param>
        /// <returns></returns>
        public ConvertResult Convert(BitmapSource? image, string? name, FormatKinds formatKind, int redThreshold, int greenThreshold, int blueThreshold, int matrixLedWidth, int matrixLedHeight, int matrixLedBrightness)
        {
            switch(formatKind)
            {
                case FormatKinds.HighSpeed:
                    return this.ConvertHighSpeed(image, name, redThreshold, greenThreshold, blueThreshold, matrixLedWidth, matrixLedHeight, matrixLedBrightness);

                case FormatKinds.Color64:
                    return this.ConvertColor64(image, name, redThreshold, greenThreshold, blueThreshold, matrixLedWidth, matrixLedHeight, matrixLedBrightness);

                case FormatKinds.Color256:
                    return this.ConvertColor256(image, name, redThreshold, greenThreshold, blueThreshold, matrixLedWidth, matrixLedHeight, matrixLedBrightness);

                case FormatKinds.TestColor64:
                    return this.ConvertTestColor64(image, name, redThreshold, greenThreshold, blueThreshold, matrixLedWidth, matrixLedHeight, matrixLedBrightness);

                case FormatKinds.TestColor256:
                    return this.ConvertTestColor256(image, name, redThreshold, greenThreshold, blueThreshold, matrixLedWidth, matrixLedHeight, matrixLedBrightness);

                //2025.08.05:CS)土田:インデックスカラー対応 >>>>> ここから
                //----------
                case FormatKinds.IndexColor:
                    return this.ConvertIndexColor(image, name, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
                //2025.08.05:CS)土田:インデックスカラー対応 <<<<< ここまで

                default:
                    //不明な形式
                    return ConvertResult.Failed($"不明な変換フォーマット ({formatKind})");
            }
        }

    }
}
