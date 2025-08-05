using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// インデックスカラー変換
        /// </summary>
        /// <param name="image"></param>
        /// <param name="name"></param>
        /// <param name="matrixLedWidth"></param>
        /// <param name="matrixLedHeight"></param>
        /// <param name="matrixLedBrightness"></param>
        /// <returns></returns>
        private ConvertResult ConvertIndexColor(BitmapSource? image, string? name, int matrixLedWidth, int matrixLedHeight, int matrixLedBrightness)
        {
            //R=3bit/G=3bit/B=2bitに変換
            ConvertResult result = this.ConvertColor(OutputColorFormatKind.IndexColor, image, name, MicroSignConsts.RGB.IndexColorMemberName, MicroSignConsts.RGB.Bit8, MicroSignConsts.RGB.Bit8, MicroSignConsts.RGB.Bit8, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
            return result;
        }
    }
}
