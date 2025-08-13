using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media;

namespace MicroSign.Core.Models.IndexColors
{
    /// <summary>
    /// インデックスカラーコレクション
    /// </summary>
    public class IndexColorCollection : List<IndexColor>
    {
        /// <summary>
        /// 同一色インデックス取得
        /// </summary>
        /// <param name="targetColor"></param>
        /// <returns>
        /// 同一色のインデックス
        /// 同一色が存在しない場合は-1
        /// </returns>
        public int GetSameColorIndex(IndexColor targetColor)
        {
            if(targetColor == null)
            {
                //対象色が無効の場合は同一色なし
                return CommonConsts.Index.Invalid;
            }
            else
            {
                //続行
            }

            //全色と比較
            int n = this.Count;
            for (int i = CommonConsts.Index.First; i < n; i += CommonConsts.Index.Step)
            {
                IndexColor color = this[i];
                if (color == null)
                {
                    //色が無効の場合はスキップ
                }
                else
                {
                    //同一色判定
                    bool isSame = color.IsSameColor(targetColor);
                    if (isSame)
                    {
                        //同一色あり
                        return i;
                    }
                    else
                    {
                        //判定を続行
                    }
                }
            }

            //ここまできたら同一色なし
            return CommonConsts.Index.Invalid;
        }

        /// <summary>
        /// 色を追加
        /// </summary>
        /// <param name="color"></param>
        /// <returns>
        /// 色が追加された場合、追加した色のインデックス
        /// 同一色が登録済みの場合、登録されている色のインデックス
        /// 追加失敗の場合は-1
        /// </returns>
        public int AddColor(IndexColor color)
        {
            //登録済み判定
            int palleteIndex = this.GetSameColorIndex(color);
            if (palleteIndex < CommonConsts.Index.First)
            {
                //未登録の場合は続行
            }
            else
            {
                //既に登録されている色のインデックスを返す
                return palleteIndex;
            }

            //色数取得
            // >> 色追加前に取得すると、色追加後のIndexとなることを利用
            // >> >> 色追加後の「index = this.Count - 1」と同じ
            int index = this.Count;

            //新規登録
            this.Add(color);

            //追加した色のインデックスを返して終了
            return index;
        }
    }
}
