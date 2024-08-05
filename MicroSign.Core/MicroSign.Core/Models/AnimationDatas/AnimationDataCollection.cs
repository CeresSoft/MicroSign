using System.Collections.Generic;

namespace MicroSign.Core.Models.AnimationDatas
{
    /// <summary>
    /// アニメーションデータコレクション
    /// </summary>
    public class AnimationDataCollection : List<AnimationData>
    {
        /// <summary>
        /// アニメーション追加
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="displayPeriodMillisecond"></param>
        public void AddAnimation(int x, int y, int displayPeriodMillisecond)
        {
            AnimationData data = new AnimationData(x, y, displayPeriodMillisecond);
            Add(data);
        }
    }
}
