namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// 色計算
        /// </summary>
        /// <param name="pixelValue">ピクセル値(R,G,Bいずれかの値)</param>
        /// <param name="alphaValue">ピクセルのアルファ値</param>
        /// <returns></returns>
        private int CalcColor(int pixelValue, int alphaValue)
        {
            int v = pixelValue * alphaValue;
            v /= (int)byte.MaxValue;
            return v;
        }
    }
}
