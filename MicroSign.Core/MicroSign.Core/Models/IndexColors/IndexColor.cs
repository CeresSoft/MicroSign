namespace MicroSign.Core.Models.IndexColors
{
    /// <summary>
    /// インデックスカラー
    /// </summary>
    public class IndexColor
    {
        /// <summary>
        /// 色A
        /// </summary>
        public int A { get; protected set; } = CommonConsts.Values.Zero.I;

        /// <summary>
        /// 色R
        /// </summary>
        public int R { get; protected set; } = CommonConsts.Values.Zero.I;

        /// <summary>
        /// 色G
        /// </summary>
        public int G { get; protected set; } = CommonConsts.Values.Zero.I;

        /// <summary>
        /// 色B
        /// </summary>
        public int B { get; protected set; } = CommonConsts.Values.Zero.I;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="a"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public IndexColor(int a, int r, int g, int b)
        {
            this.A = a;
            this.R = r;
            this.G = g;
            this.B = b;
        }

        /// <summary>
        /// 同一色判定
        /// </summary>
        /// <param name="targetColor"></param>
        /// <returns></returns>
        public bool IsSameColor(IndexColor? targetColor)
        {
            if (targetColor == null)
            {
                //比較対象の色が無効の場合は異なる色で終了
                return false;
            }
            else
            {
                //有効の場合は続行
            }

            //色比較
            // >> Alpha
            {
                int selfA = this.A;
                int targetA = targetColor.A;
                if (selfA == targetA)
                {
                    //一致の場合は続行
                }
                else
                {
                    //不一致の場合は異なる色で終了
                    return false;
                }
            }

            // >> Red
            {
                int selfR = this.R;
                int targetR = targetColor.R;
                if (selfR == targetR)
                {
                    //一致の場合は続行
                }
                else
                {
                    //不一致の場合は異なる色で終了
                    return false;
                }
            }

            // >> Green
            {
                int selfG = this.G;
                int targetG = targetColor.G;
                if (selfG == targetG)
                {
                    //一致の場合は続行
                }
                else
                {
                    //不一致の場合は異なる色で終了
                    return false;
                }
            }

            // >> Blue
            {
                int selfB = this.B;
                int targetB = targetColor.B;
                if (selfB == targetB)
                {
                    //一致の場合は続行
                }
                else
                {
                    //不一致の場合は異なる色で終了
                    return false;
                }
            }

            //ここまできたら同一色
            return true;
        }
    }
}
