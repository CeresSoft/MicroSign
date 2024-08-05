namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// [高速用]閾値判定
        /// </summary>
        /// <param name="pixelValue">ピクセル値(R,G,Bいずれかの値)</param>
        /// <param name="alphaValue">ピクセルのアルファ値</param>
        /// <param name="threshold">0にするか1にするかの閾値</param>
        /// <param name="returnValue">ピクセル値が閾値以上の場合に返す値</param>
        /// <returns></returns>
        private int TestThreshold(int pixelValue, int alphaValue, int threshold, int returnValue)
        {
            //実際の表示色
            int v = this.CalcColor(pixelValue, alphaValue);

            //閾値判定
            if (v < threshold)
            {
                return CommonConsts.Values.Zero.I;
            }
            else
            {
                return returnValue;
            }
        }
    }
}
