using System;

namespace MicroSign.Core.Models
{
    partial class Model
    {

        /// <summary>
        /// 比率変換
        /// </summary>
        /// <param name="sourceMinValue">変換元の最小値</param>
        /// <param name="sourceMaxValue">変換元の最大値</param>
        /// <param name="destinationMinValue">変換後の最小値</param>
        /// <param name="destinationMaxValue">変換後の最大値</param>
        /// <param name="value">変換値</param>
        /// <returns></returns>
        private double RatioConvertion(double sourceMinValue, double sourceMaxValue, double destinationMinValue, double destinationMaxValue, double value)
        {
            //範囲を計算
            // >> 変換元
            double sourceRange = sourceMaxValue - sourceMinValue;
            {
                double absSourceRange = Math.Abs(sourceRange);
                if (absSourceRange < CommonConsts.Values.Epsilon.D)
                {
                    //ほぼゼロの場合は計算できないとして0を返す
                    return CommonConsts.Values.Zero.D;
                }
                else
                {
                    //それ以外は計算するので処理続行
                }
            }

            // >> 変換先
            double destinationRange = destinationMaxValue - destinationMinValue;
            {
                double absDestinationRange = Math.Abs(destinationRange);
                if (absDestinationRange < CommonConsts.Values.Epsilon.D)
                {
                    //ほぼゼロの場合は計算できないとして0を返す
                    return CommonConsts.Values.Zero.D;
                }
                else
                {
                    //それ以外は計算するので処理続行
                }
            }

            //元の範囲が0～1となるようにvalueを変換
            //それ以外は計算する
            double v = value - sourceMinValue;
            double t = v / sourceRange;

            //変換後
            double r = t * destinationRange;
            double result = r + destinationMinValue;

            //終了
            return result;
        }
    }
}
