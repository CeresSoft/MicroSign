namespace MicroSign.Core.ViewModels.Pages
{
    /// <summary>
    /// アニメーション切り抜きページViewModel
    /// </summary>
    partial class AnimationClipPageViewModel
    {
        /// <summary>
        /// 状態設定
        /// </summary>
        /// <param name="statusKind">設定する状態</param>
        public void SetStatus(AnimationClipPageStateKind statusKind)
        {
            this.SetStatus(statusKind, null);
        }

        /// <summary>
        /// 状態設定
        /// </summary>
        /// <param name="statusKind">設定する状態区分</param>
        /// <param name="statusText">設定する状態テキスト</param>
        public void SetStatus(AnimationClipPageStateKind statusKind, string? statusText)
        {
            this.StatusKind = statusKind;
            this.StatusText = statusText;
        }
    }
}
