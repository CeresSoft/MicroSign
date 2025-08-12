using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
        ///// <summary>
        ///// インデックスカラー変換
        ///// </summary>
        ///// <param name="image">画像</param>
        ///// <param name="name">クラス名</param>
        ///// <param name="matrixLedWidth">マトリクスLED横ドット数</param>
        ///// <param name="matrixLedHeight">マトリクスLED縦ドット数</param>
        ///// <param name="matrixLedBrightness">マトリクスLED明るさ</param>
        ///// <returns></returns>
        //private ConvertResult ConvertIndexColor(BitmapSource? image, string? name, int matrixLedWidth, int matrixLedHeight, int matrixLedBrightness)
        //{
        //    //R=8bit/G=8bit/B=8bitに変換
        //    ConvertResult result = this.ConvertColor(
        //        OutputColorFormatKind.IndexColor,   //フォーマット種類
        //        image,                              //変換画像
        //        name,
        //        MicroSignConsts.RGB.IndexColorMemberName,
        //        MicroSignConsts.RGB.Bit8,
        //        MicroSignConsts.RGB.Bit8,
        //        MicroSignConsts.RGB.Bit8,
        //        matrixLedWidth,
        //        matrixLedHeight,
        //        matrixLedBrightness);
        //    return result;
        //}
        //----------
        // >> 未使用なので削除
        //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで
    }
}
