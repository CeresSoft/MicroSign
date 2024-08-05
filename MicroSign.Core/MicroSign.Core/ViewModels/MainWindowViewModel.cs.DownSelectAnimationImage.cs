using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSign.Core.ViewModels
{
    partial class MainWindowViewModel
    {
        /// <summary>
        /// アニメーション画像を下に移動
        /// </summary>
        /// <param name="animationImage">下に移動するアニメーション画像</param>
        public void DownAnimationImage(AnimationImageItem? animationImage)
        {
            //アニメーション画像有効判定
            if (animationImage == null)
            {
                //無効の場合は何もせずに終了
                return;
            }
            else
            {
                //有効の場合は処理続行
            }

            //指定された画像のインデックスを取得
            int nowIndex = this.GetAnimationImageIndex(animationImage);
            if (nowIndex < CommonConsts.Index.First)
            {
                //無効の場合は何もせずに終了
                return;
            }
            else
            {
                //有効の場合は処理続行
            }

            //アニメーション画像の要素数を取得
            int animationImagesCount = this.GetAnimationImagesCount();

            //新しい位置(一つ後の位置)を取得
            int newIndex = nowIndex + CommonConsts.Index.Step;
            if (newIndex < animationImagesCount)
            {
                //有効の場合は処理続行
            }
            else
            {
                //無効の場合は何もせずに終了
                return;
            }

            //アニメーション画像を削除
            this.AnimationImages.Remove(animationImage);

            //新しい位置に追加
            this.AnimationImages.Insert(newIndex, animationImage);

            //選択画像にする
            this.SetSelectAnimationImage(animationImage);
        }
    }
}
