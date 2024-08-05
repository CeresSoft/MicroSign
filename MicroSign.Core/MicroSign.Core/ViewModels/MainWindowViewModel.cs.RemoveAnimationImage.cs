using System.Windows;

namespace MicroSign.Core.ViewModels
{
    partial class MainWindowViewModel
    {
        /// <summary>
        /// 指定されたアニメーションを削除
        /// </summary>
        /// <param name="animationImageItem">削除するアニメーション画像</param>
        public void RemoveAnimationImage(AnimationImageItem? removeAnimationImageItem)
        {
            //指定されたアニメーション画像が有効か判定
            if (removeAnimationImageItem == null)
            {
                //無効の場合は即終了
                return;
            }
            else
            {
                //有効の場合は処理続行
            }

            //削除するアニメーション画像のインデックスを取得する
            // >> 削除したアニメーション画像の次のアニメーション画像を選択するのに使用する
            int removeAnimationImageIndex = this.GetAnimationImageIndex(removeAnimationImageItem);
            if (removeAnimationImageIndex < CommonConsts.Index.First)
            {
                //削除するアニメーション画像が無い場合は終了
                return;
            }
            else
            {
                //取得できた場合は処理続行
            }

            //リストから指定されたアニメーションを削除
            this.AnimationImages.Remove(removeAnimationImageItem);

            //削除した位置になったアニメーション画像を取得
            AnimationImageItem? selectAnimationImage = this.GetAnimationImage(removeAnimationImageIndex);
            if(selectAnimationImage == null)
            {
                //削除位置になったアニメーション画像が無い場合
                int c = this.GetAnimationImagesCount();
                if (CommonConsts.Collection.Empty < c)
                {
                    //アニメーション画像がある場合最後のアニメーション画像を取得
                    int lastAnimationImageIndex = CommonConsts.Collection.ToIndex(c);
                    selectAnimationImage = this.GetAnimationImage(lastAnimationImageIndex);
                }
                else
                {
                    //アニメーション画像が1つも無い場合はそのまま
                }
            }
            else
            {
                //削除位置になったアニメーションがある場合はそのまま
            }

            //選択する
            this.SetSelectAnimationImage(selectAnimationImage);
        }
    }
}
