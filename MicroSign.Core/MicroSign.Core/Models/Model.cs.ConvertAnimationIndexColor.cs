using MicroSign.Core.Models.AnimationDatas;
using MicroSign.Core.ViewModels;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// インデックスカラーアニメーション変換
        /// </summary>
        /// <param name="animationImages"></param>
        /// <param name="name"></param>
        /// <param name="matrixLedWidth"></param>
        /// <param name="matrixLedHeight"></param>
        /// <param name="matrixLedBrightness"></param>
        /// <returns></returns>
        private ConvertResult ConvertAnimationIndexColor(AnimationImageItemCollection animationImages, string? name, int matrixLedWidth, int matrixLedHeight, int matrixLedBrightness)
        {
            //アニメーション画像からマージしたアニメーション用画像を生成
            CreateAnimationBitmapResult ret = this.CreateAnimationBitmap(animationImages, OutputColorFormatKind.IndexColor, MicroSignConsts.RGB.Bit8, MicroSignConsts.RGB.Bit8, MicroSignConsts.RGB.Bit8);
            if (ret.IsSuccess)
            {
                //成功した場合は処理続行
            }
            else
            {
                //失敗した場合は終了
                return ConvertResult.Failed(ret.Message);
            }

            //インデックスカラーに変換
            {
                BitmapSource? margeImage = ret.MargeImage;
                AnimationDataCollection? animationDatas = ret.AnimationDatas;
                ConvertResult result = this.ConvertColor(OutputColorFormatKind.IndexColor, margeImage, name, MicroSignConsts.RGB.IndexColorMemberName, MicroSignConsts.RGB.Bit8, MicroSignConsts.RGB.Bit8, MicroSignConsts.RGB.Bit8, animationDatas, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
                return result;
            }
        }
    }
}
