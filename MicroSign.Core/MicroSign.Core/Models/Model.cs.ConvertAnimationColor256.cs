﻿using MicroSign.Core.Models.AnimationDatas;
using MicroSign.Core.ViewModels;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// 256色カラーアニメーション変換
        /// </summary>
        /// <param name="animationImages"></param>
        /// <param name="name"></param>
        /// <param name="redThreshold"></param>
        /// <param name="greenThreshold"></param>
        /// <param name="blueThreshold"></param>
        /// <param name="matrixLedWidth">マトリクスLED横ドット数</param>
        /// <param name="matrixLedHeight">マトリクスLED縦ドット数</param>
        /// <param name="matrixLedBrightness">マトリクスLED明るさ</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private ConvertResult ConvertAnimationColor256(AnimationImageItemCollection animationImages, string? name, int redThreshold, int greenThreshold, int blueThreshold, int matrixLedWidth, int matrixLedHeight, int matrixLedBrightness)
        {
            //アニメーション画像からマージしたアニメーション用画像を生成
            CreateAnimationBitmapResult ret = this.CreateAnimationBitmap(animationImages, OutputColorFormatKind.Color256, MicroSignConsts.RGB.Bit3, MicroSignConsts.RGB.Bit3, MicroSignConsts.RGB.Bit2);
            if (ret.IsSuccess)
            {
                //成功した場合は処理続行
            }
            else
            {
                //失敗した場合は終了
                return ConvertResult.Failed(ret.Message);
            }

            //R=2bit/G=2bit/B=2bitに変換
            {
                BitmapSource? margeImage = ret.MargeImage;
                AnimationDataCollection? animationDatas = ret.AnimationDatas;
                ConvertResult result = this.ConvertColor(OutputColorFormatKind.Color256, margeImage, name, MicroSignConsts.RGB.Color256MemberName, MicroSignConsts.RGB.Bit3, MicroSignConsts.RGB.Bit3, MicroSignConsts.RGB.Bit2, animationDatas, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
                return result;
            }
        }
    }
}
