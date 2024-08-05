namespace MicroSign.Core.Models.AnimationDatas
{
    public class AnimationData
    {
        /// <summary>
        /// アニメーション位置X
        /// </summary>
        public int X { get; protected set; } = CommonConsts.Values.Zero.I;

        /// <summary>
        /// アニメーション位置Y
        /// </summary>
        public int Y { get; protected set; } = CommonConsts.Values.Zero.I;

        /// <summary>
        /// アニメーション表示期間(ms)
        /// </summary>
        public int DisplayPeriodMillisecond { get; protected set; } = CommonConsts.Values.Zero.I;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x">アニメーション位置X</param>
        /// <param name="y">アニメーション位置Y</param>
        /// <param name="displayPeriodMillisecond">アニメーション表示期間(ms)</param>
        public AnimationData(int x, int y, int displayPeriodMillisecond)
        {
            X = x;
            Y = y;
            DisplayPeriodMillisecond = displayPeriodMillisecond;
        }
    }
}
