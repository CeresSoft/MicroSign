namespace MicroSign.Core.ViewModels
{
    partial class MainWindowViewModel
    {
        /// <summary>
        /// アニメーション画像リフレッシュ
        /// </summary>
        /// <returns></returns>
        public (bool IsSuccess, string ErrorMessage) RefreshAnimationImage()
        {
            //モデルを呼び出し
            return this.Model.RefreshAnimationImage(this.AnimationImages);
        }
    }
}
