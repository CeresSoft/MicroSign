namespace MicroSign.Core.ViewModels
{
    partial class MainWindowViewModel
    {
        /// <summary>
        /// アニメーション画像のリスト内インデックスを取得
        /// </summary>
        /// <param name="animationImageItem">インデックスを取得するアニメーション画像</param>
        /// <returns></returns>
        public int GetAnimationImageIndex(AnimationImageItem animationImageItem)
        {
            //指定されたアニメーション画像が有効か判定
            if(animationImageItem == null)
            {
                //無効の場合は常にInvalidを返す
                return CommonConsts.Index.Invalid;
            }
            else
            {
                //有効の場合は処理続行
            }

            //インデックスを取得
            int result = this.AnimationImages.IndexOf(animationImageItem);
            return result;
        }
    }
}
