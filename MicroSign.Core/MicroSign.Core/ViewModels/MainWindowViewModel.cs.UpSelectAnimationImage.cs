namespace MicroSign.Core.ViewModels
{
    partial class MainWindowViewModel
    {
        /// <summary>
        /// アニメーション画像を上に移動
        /// </summary>
        /// <param name="animationImage">上に移動するアニメーション画像</param>
        public void UpAnimationImage(AnimationImageItem? animationImage)
        {
            //アニメーション画像有効判定
            if(animationImage == null)
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
            if(nowIndex < CommonConsts.Index.First)
            {
                //無効の場合は何もせずに終了
                return;
            }
            else
            {
                //有効の場合は処理続行
            }

            //新しい位置(一つ前の位置)を取得
            int newIndex = nowIndex - CommonConsts.Index.Step;
            if (newIndex < CommonConsts.Index.First)
            {
                //無効の場合は何もせずに終了
                return;
            }
            else
            {
                //有効の場合は処理続行
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
