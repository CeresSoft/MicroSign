using MicroSign.Core.Navigations.ViewModels;

namespace MicroSign.Core.ViewModels.Pages
{
    /// <summary>
    /// 画像切り抜きページViewModel
    /// </summary>
    public partial class AnimationClipPageViewModel : OkCancelNavigationViewModelBase
    {
        /// <summary>
        /// モデル
        /// </summary>
        public Models.Model Model
        {
            get
            {
                return Models.Model.Instance;
            }
        }
    }
}
