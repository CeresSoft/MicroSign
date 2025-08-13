namespace MicroSign.Core.ViewModels
{
    partial class MainWindowViewModel
    {
        /// <summary>
        /// アニメーション設定保存
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Models.Model.SaveAnimationResult SaveAnimation(string path)
        {
            return this.Model.SaveAnimation(path, this.AnimationName, this.AnimationImages, this.MatrixLedWidth, this.MatrixLedHeight, this.MatrixLedBrightness, this.DefaultDisplayPeriod);
        }
    }
}
