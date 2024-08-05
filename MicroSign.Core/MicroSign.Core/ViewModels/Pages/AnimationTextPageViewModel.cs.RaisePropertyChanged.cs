using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace MicroSign.Core.ViewModels.Pages
{
    /// <summary>
    /// アニメーションテキストページViewModel
    /// </summary>
    partial class AnimationTextPageViewModel
    {
        /// <summary>
        /// プロパティ変更
        /// </summary>
        /// <param name="propertyName"></param>
        protected override void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            //ベースの処理を呼び出し
            base.RaisePropertyChanged(propertyName);

            //レンダリングターゲットを更新する
            switch(propertyName)
            {
                case AnimationTextPageViewModel.PropertyNames.RenderBitmap:
                    //ビットマップが変化した場合はレンダリングしない(=既に処理済みのはず)
                    break;

                default:
                    //それ以外の場合はレンダリングターゲットを更新
                    this.UpdateRenderBitmap();
                    break;
            }
        }
    }
}
