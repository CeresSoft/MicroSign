using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
        ///// <summary>
        ///// 画像変換結果
        ///// </summary>
        //public struct ConvertImageResult
        //{
        //    /// <summary>
        //    /// 成功フラグ
        //    /// </summary>
        //    public readonly bool IsSuccess;
        //
        //    /// <summary>
        //    /// エラーメッセージ
        //    /// </summary>
        //    public readonly string? ErrorMessage;
        //
        //    /// <summary>
        //    /// 出力データ
        //    /// </summary>
        //    public readonly byte[]? OutputData;
        //
        //    /// <summary>
        //    /// 変換画像
        //    /// </summary>
        //    public readonly BitmapSource? PreviewImage;
        //
        //    /// <summary>
        //    /// コンストラクタ
        //    /// </summary>
        //    /// <param name="isSuccess">成功フラグ</param>
        //    /// <param name="errorMessage">エラーメッセージ</param>
        //    /// <param name="outputData">出力データ</param>
        //    /// <param name="previewImage">プレビュー画像</param>
        //    private ConvertImageResult(bool isSuccess, string? errorMessage, byte[]? outputData, BitmapSource? previewImage)
        //    {
        //        this.IsSuccess = isSuccess;
        //        this.ErrorMessage = errorMessage;
        //        this.OutputData = outputData;
        //        this.PreviewImage = previewImage;
        //    }
        //
        //    /// <summary>
        //    /// 失敗
        //    /// </summary>
        //    /// <param name="errorMessage">エラーメッセージ</param>
        //    /// <returns></returns>
        //    public static ConvertImageResult Failed(string? errorMessage)
        //    {
        //        ConvertImageResult result = new ConvertImageResult(false, errorMessage, null, null);
        //        return result;
        //    }
        //
        //    /// <summary>
        //    /// 成功
        //    /// </summary>
        //    /// <param name="outputData">出力データ</param>
        //    /// <param name="previewImage">プレビュー画像</param>
        //    /// <returns></returns>
        //    public static ConvertImageResult Sucess(byte[]? outputData, BitmapSource? previewImage)
        //    {
        //        ConvertImageResult result = new ConvertImageResult(true, null, outputData, previewImage);
        //        return result;
        //    }
        //}
        //----------
        // >> 未使用になったので削除
        //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで

        //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
        ///// <summary>
        ///// 画像変換
        ///// </summary>
        ///// <param name="image"></param>
        ///// <param name="formatKind"></param>
        ///// <returns></returns>
        ///// <remarks>
        ///// 2023.11.30:CS)土田:プレビュー表示の改造
        ///// 画像を読み込んだ時点でカラー変換まで行うため、ConvertColorImplを単独で実行する関数を追加
        ///// </remarks>
        //public ConvertImageResult ConvertImage(BitmapSource? image, FormatKinds formatKind)
        //{
        //    switch (formatKind)
        //    {
        //        //2025.08.05:CS)土田:インデックスカラー対応 >>>>> ここから
        //        //case FormatKinds.Color64:
        //        //    return this.ConvertImageImpl(image, MicroSignConsts.RGB.Bit2, MicroSignConsts.RGB.Bit2, MicroSignConsts.RGB.Bit2);
        //
        //        //case FormatKinds.Color256:
        //        //    return this.ConvertImageImpl(image, MicroSignConsts.RGB.Bit3, MicroSignConsts.RGB.Bit3, MicroSignConsts.RGB.Bit2);
        //        //----------
        //        case FormatKinds.Color64:
        //        case FormatKinds.Color256:
        //            return ConvertImageResult.Failed($"フォーマット'{formatKind}'は現在のバージョンでは非対応です");
        //
        //        case FormatKinds.IndexColor:
        //            return this.ConvertImageImpl(image, MicroSignConsts.RGB.Bit8, MicroSignConsts.RGB.Bit8, MicroSignConsts.RGB.Bit8);
        //        //2025.08.05:CS)土田:インデックスカラー対応 <<<<< ここまで
        //
        //        default:
        //            //不明な形式
        //            return ConvertImageResult.Failed($"不明な変換フォーマット ({formatKind})");
        //    }
        //}
        //----------
        // >> 未使用になったので削除
        //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで

        //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
        ///// <summary>
        ///// 画像変換
        ///// </summary>
        ///// <param name="image">変換する画像</param>
        ///// <param name="redBits">赤ビット数</param>
        ///// <param name="greenBits">緑ビット数</param>
        ///// <param name="blueBits">青ビット数</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// 2023.11.30:CS)土田:プレビュー表示の改造
        ///// </remarks>
        //private ConvertImageResult ConvertImageImpl(BitmapSource? image, int redBits, int greenBits, int blueBits)
        //{
        //    //画像有効判定
        //    if (image == null)
        //    {
        //        //画像無しは失敗
        //        return ConvertImageResult.Failed("変換画像無し");
        //    }
        //    else
        //    {
        //        //画像有りの場合は処理続行
        //    }
        //
        //    //画像ピクセル取得
        //    // >> 検証済の値を取得
        //    int imagePixelWidth = image.PixelWidth;
        //    int imagePixelHeight = image.PixelHeight;
        //
        //    //画像サイズ検証
        //    ValidateImageSizeResult validateRet = this.ValidateImageSize(imagePixelWidth, imagePixelHeight);
        //    if (validateRet.IsValid)
        //    {
        //        //検証OKの場合は続行
        //    }
        //    else
        //    {
        //        //検証NGの場合は終了
        //        return ConvertImageResult.Failed(validateRet.ErrorMessage);
        //    }
        //
        //    //画像データを変換
        //    byte[]? outputData = null;
        //    byte[]? outputImage = null;
        //    int outputImageStride = CommonConsts.Collection.Empty;
        //    {
        //        //画像データを出力データに変換
        //        //2025.08.05:CS)土田:インデックスカラー対応 >>>>> ここから
        //        //var convertColorImplResult = this.ConvertColorImpl(image, redBits, greenBits, blueBits);
        //        //----------
        //        var convertColorImplResult = this.ConvertColorImpl(image);
        //        //2025.08.05:CS)土田:インデックスカラー対応 <<<<< ここまで
        //        if (convertColorImplResult.IsSuccess)
        //        {
        //            //成功した場合は処理続行
        //        }
        //        else
        //        {
        //            //失敗した場合は終了
        //            return ConvertImageResult.Failed("色変換失敗");
        //        }
        //
        //        //出力データ取得
        //        outputData = convertColorImplResult.OutputData;
        //        if (outputData == null)
        //        {
        //            //無効の場合は終了
        //            return ConvertImageResult.Failed("出力データ無効");
        //        }
        //        else
        //        {
        //            //有効の場合は処理続行
        //        }
        //
        //        //出力画像取得
        //        outputImage = convertColorImplResult.OutputImage;
        //        if (outputImage == null)
        //        {
        //            //無効の場合は終了
        //            return ConvertImageResult.Failed("出力画像無効");
        //        }
        //        else
        //        {
        //            //有効の場合は処理続行
        //        }
        //
        //        //出力画像ストライド取得
        //        outputImageStride = convertColorImplResult.OutputImageStride;
        //    }
        //
        //    //変換画像をWPF用に変換
        //    WriteableBitmap previewBitmap = new WriteableBitmap(imagePixelWidth, imagePixelHeight, CommonConsts.DPIs.DIP, CommonConsts.DPIs.DIP, PixelFormats.Bgra32, null);
        //    {
        //        Int32Rect rect = new Int32Rect((int)CommonConsts.Points.Zero.X, (int)CommonConsts.Points.Zero.Y, imagePixelWidth, imagePixelHeight);
        //        previewBitmap.WritePixels(rect, outputImage, outputImageStride, CommonConsts.Index.First);
        //    }
        //
        //    //ここまできたら成功
        //    return ConvertImageResult.Sucess(outputData, previewBitmap);
        //}
        //----------
        // >> 未使用になったので削除
        //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで
    }
}
