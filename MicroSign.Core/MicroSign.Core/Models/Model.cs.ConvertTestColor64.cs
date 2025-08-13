using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
        ///// <summary>
        ///// 64色テストカラー変換
        ///// </summary>
        ///// <param name="image">画像</param>
        ///// <param name="name">クラス名</param>
        ///// <param name="redThreshold">赤閾値</param>
        ///// <param name="greenThreshold">緑閾値</param>
        ///// <param name="blueThreshold">青閾値</param>
        ///// <param name="matrixLedWidth">マトリクスLED横ドット数</param>
        ///// <param name="matrixLedHeight">マトリクスLED縦ドット数</param>
        ///// <param name="matrixLedBrightness">マトリクスLED明るさ</param>
        ///// <returns></returns>
        //private ConvertResult ConvertTestColor64(BitmapSource? image, string? name, int redThreshold, int greenThreshold, int blueThreshold, int matrixLedWidth, int matrixLedHeight, int matrixLedBrightness)
        //{
        //    //テスト画像を生成
        //    WriteableBitmap testBitmap = this.CreateTestBitmap(matrixLedWidth, matrixLedHeight);
        //
        //    //R=2bit/G=2bit/B=2bitに変換
        //    // >> 入力画像を使わず、テスト画像で置き換える
        //    {
        //        ConvertResult result = this.ConvertColor(OutputColorFormatKind.Color64, testBitmap, name, MicroSignConsts.RGB.Color64MemberName, MicroSignConsts.RGB.Bit2, MicroSignConsts.RGB.Bit2, MicroSignConsts.RGB.Bit2, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
        //        return result;
        //    }
        //}
        //----------
        // >> 未使用になったので削除
        //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで
    }
}
