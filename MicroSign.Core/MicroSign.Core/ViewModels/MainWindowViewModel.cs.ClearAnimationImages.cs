namespace MicroSign.Core.ViewModels
{
    partial class MainWindowViewModel
    {
        /// <summary>
        /// アニメーション画像リストをクリア
        /// </summary>
        public void ClearAnimationImages()
        {
            //アニメーション画像コレクション
            // >> コンストラクタで生成しているのでnullチェック不要
            AnimationImageItemCollection animationImages = this.AnimationImages;

            //アニメーション画像リストをクリア
            // >> イベント処理した場合にRemoveとして扱いたいのでClear()を使わずRemoveAt()で削除します
            {
                int c = CommonUtils.GetCount(animationImages);
                for (int i = CommonConsts.Index.First; i < c; i += CommonConsts.Index.Step)
                {
                    animationImages.RemoveAt(CommonConsts.Index.First);
                }
            }
        }
    }
}
