﻿using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// 256色カラー変換
        /// </summary>
        /// <param name="image">画像</param>
        /// <param name="name">クラス名</param>
        /// <param name="redThreshold">赤閾値</param>
        /// <param name="greenThreshold">緑閾値</param>
        /// <param name="blueThreshold">青閾値</param>
        /// <param name="matrixLedWidth">マトリクスLED横ドット数</param>
        /// <param name="matrixLedHeight">マトリクスLED縦ドット数</param>
        /// <param name="matrixLedBrightness">マトリクスLED明るさ</param>
        /// <returns></returns>
        private ConvertResult ConvertColor256(BitmapSource? image, string? name, int redThreshold, int greenThreshold, int blueThreshold, int matrixLedWidth, int matrixLedHeight, int matrixLedBrightness)
        {
            //R=3bit/G=3bit/B=2bitに変換
            ConvertResult result = this.ConvertColor(OutputColorFormatKind.Color256, image, name, MicroSignConsts.RGB.Color256MemberName, MicroSignConsts.RGB.Bit3, MicroSignConsts.RGB.Bit3, MicroSignConsts.RGB.Bit2, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
            return result;
        }
    }
}
