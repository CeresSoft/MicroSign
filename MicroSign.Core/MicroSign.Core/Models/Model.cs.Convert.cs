using System;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using MicroSign.Core.Models.AnimationDatas;

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
            /// メッセージ
            /// </summary>
            /// <remarks>
            /// 2025.08.12:CS)杉原:パレット処理の流れを変更で追加
            /// 最初期はファイルでは無くファームウエア埋込用のプログラムコードに
            /// 変換する処理であったためCodeという名前であったが
            /// 現在はメッセージしか入れないので名称を変更しました
            /// </remarks>
            public readonly string? Message;

            //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
            ///// <summary>
            ///// 変換画像
            ///// </summary>
            //public readonly WriteableBitmap? ConvertImage;
            //----------
            //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで

            /// <summary>
            /// アニメーション用マージ画像
            /// </summary>
            /// <remarks>
            /// 2025.08.12:CS)杉原:パレット処理の流れを変更で
            /// 引数の「変換画像」を「アニメーション用マージ画像」に名称変更しました
            /// </remarks>
            public readonly BitmapSource? AnimationMergedBitmap;

            /// <summary>
            /// アニメーションデータ
            /// </summary>
            /// <remarks>
            /// 2025.08.12:CS)杉原:パレット処理の流れを変更で追加
            /// </remarks>
            public readonly AnimationDataCollection? AnimationDatas;

            //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
            ///// <summary>
            ///// コード
            ///// </summary>
            //public readonly string Code;
            //----------
            //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="isSuccess">成功フラグ</param>
            /// <param name="message">メッセージ</param>
            /// <param name="convertImage">変換画像</param>
            /// <param name="animationDatas">アニメーションデータ</param>
            private ConvertResult(bool isSuccess, string? message, BitmapSource? animationMergedBitmap, AnimationDataCollection? animationDatas)
            {
                this.IsSuccess = isSuccess;
                this.AnimationMergedBitmap = animationMergedBitmap;
                //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
                //this.Code = code;
                //----------
                this.Message = message;
                this.AnimationDatas = animationDatas;
                //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで
            }

            /// <summary>
            /// 失敗
            /// </summary>
            /// <param name="message">エラーメッセージを入れる</param>
            /// <returns></returns>
            public static ConvertResult Failed(string message)
            {
                ConvertResult result = new ConvertResult(false, message, null, null);
                return result;
            }

            //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
            ///// <summary>
            ///// 成功
            ///// </summary>
            ///// <param name="convertImage">変換画像</param>
            ///// <param name="code">コード</param>
            ///// <returns></returns>
            //public static ConvertResult Sucess(WriteableBitmap? convertImage, string code)
            //{
            //    ConvertResult result = new ConvertResult(true, convertImage, code);
            //    return result;
            //}
            //----------
            // >> コードは無くなりました
            //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで

            /// <summary>
            /// 成功
            /// </summary>
            /// <param name="animationMergedBitmap">アニメーション用マージ画像</param>
            /// <param name="animationDatas">アニメーションデータ</param>
            /// <returns></returns>
            /// <remarks>
            /// 2025.08.12:CS)杉原:パレット処理の流れを変更で追加
            /// 引数の「コード」を削除しました
            /// 引数の「変換画像」を「アニメーション用マージ画像」に名称変更しました
            /// 引数の「アニメーションデータ」を追加しました
            /// </remarks>
            public static ConvertResult Sucess(BitmapSource? animationMergedBitmap, AnimationDataCollection? animationDatas)
            {
                ConvertResult result = new ConvertResult(true, null, animationMergedBitmap, animationDatas);
                return result;
            }
        }

        //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
        ///// <summary>
        ///// 変換
        ///// </summary>
        ///// <param name="image">画像</param>
        ///// <param name="name">クラス名</param>
        ///// <param name="formatKind">フォーマット種類</param>
        ///// <param name="redThreshold">赤閾値</param>
        ///// <param name="greenThreshold">緑閾値</param>
        ///// <param name="blueThreshold">青閾値</param>
        ///// <param name="matrixLedWidth">マトリクスLED横ドット数</param>
        ///// <param name="matrixLedHeight">マトリクスLED縦ドット数</param>
        ///// <param name="matrixLedBrightness">マトリクスLED明るさ</param>
        ///// <returns></returns>
        //public ConvertResult Convert(BitmapSource? image, string? name, FormatKinds formatKind, int redThreshold, int greenThreshold, int blueThreshold, int matrixLedWidth, int matrixLedHeight, int matrixLedBrightness)
        //{
        //    switch(formatKind)
        //    {
        //        //2025.08.05:CS)土田:インデックスカラー対応 >>>>> ここから
        //        //case FormatKinds.HighSpeed:
        //        //    return this.ConvertHighSpeed(image, name, redThreshold, greenThreshold, blueThreshold, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
        //
        //        //case FormatKinds.Color64:
        //        //    return this.ConvertColor64(image, name, redThreshold, greenThreshold, blueThreshold, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
        //
        //        //case FormatKinds.Color256:
        //        //    return this.ConvertColor256(image, name, redThreshold, greenThreshold, blueThreshold, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
        //
        //        //case FormatKinds.TestColor64:
        //        //    return this.ConvertTestColor64(image, name, redThreshold, greenThreshold, blueThreshold, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
        //
        //        //case FormatKinds.TestColor256:
        //        //    return this.ConvertTestColor256(image, name, redThreshold, greenThreshold, blueThreshold, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
        //        //----------
        //        case FormatKinds.HighSpeed:
        //        case FormatKinds.Color64:
        //        case FormatKinds.Color256:
        //        case FormatKinds.TestColor64:
        //        case FormatKinds.TestColor256:
        //            return ConvertResult.Failed($"フォーマット'{formatKind}'は現在のバージョンでは非対応です");
        //
        //        case FormatKinds.IndexColor:
        //            return this.ConvertIndexColor(image, name, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
        //        //2025.08.05:CS)土田:インデックスカラー対応 <<<<< ここまで
        //
        //        default:
        //            //不明な形式
        //            return ConvertResult.Failed($"不明な変換フォーマット ({formatKind})");
        //    }
        //}
        //----------
        // >> 未使用なので削除
        //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで

    }
}
