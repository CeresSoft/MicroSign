namespace MicroSign.Core.ViewModels
{
    partial class MainWindowViewModel
    {
        /// <summary>
        /// 選択アニメーション画像に設定
        /// </summary>
        /// <param name="selectAnimationImageItem">選択するアニメーション画像</param>
        public void SetSelectAnimationImage(AnimationImageItem? selectAnimationImageItem)
        {
            this.SelectedAnimationImageItem = selectAnimationImageItem;
        }
    }
}
