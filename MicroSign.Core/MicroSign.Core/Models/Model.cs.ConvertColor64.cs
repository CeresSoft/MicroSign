using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
        ///// <summary>
        ///// 64色カラー変換
        ///// </summary>
        ///// <param name="image">画像</param>
        ///// <param name="name">クラス名</param>
        ///// <param name="redThreshold">赤閾値</param>
        ///// <param name="greenThreshold">緑閾値</param>
        ///// <param name="blueThreshold">青閾値</param>
        ///// <returns></returns>
        //private ConvertResult ConvertColor64(BitmapSource? image, string? name, int redThreshold, int greenThreshold, int blueThreshold, int matrixLedWidth, int matrixLedHeight, int matrixLedBrightness)
        //{
        //    //R=2bit/G=2bit/B=2bitに変換
        //    ConvertResult result = this.ConvertColor(OutputColorFormatKind.Color64, image, name, MicroSignConsts.RGB.Color64MemberName, MicroSignConsts.RGB.Bit2, MicroSignConsts.RGB.Bit2, MicroSignConsts.RGB.Bit2, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
        //    return result;
        //}
        //----------
        // >> 未使用になったので削除
        //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで
    }
}
