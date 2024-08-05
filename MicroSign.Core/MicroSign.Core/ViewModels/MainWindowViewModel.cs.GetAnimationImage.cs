namespace MicroSign.Core.ViewModels
{
    partial class MainWindowViewModel
    {
        /// <summary>
        /// 指定した位置のアニメーション画像を取得
        /// </summary>
        /// <param name="index">取得するアニメーション画像のインデックス</param>
        /// <returns></returns>
        public AnimationImageItem? GetAnimationImage(int index)
        {
            //指定されたインデックス位置が有効か判定
            if(index < CommonConsts.Index.First)
            {
                //無効の場合は無条件にnullを返す
                return null;
            }
            else
            {
                //有効の場合は処理続行
            }

            //現在のアニメーション数を取得
            int animationImagesCount = this.GetAnimationImagesCount();
            if (index < animationImagesCount)
            {
                //インデックス位置が有効の場合は処理続行
            }
            else
            {
                //インデックス位置が無効の場合はnullで終了
                return null;
            }

            //インデックス位置に対応するアニメーション画像を取得
            AnimationImageItem result = this.AnimationImages[index];
            return result;
        }
    }
}
