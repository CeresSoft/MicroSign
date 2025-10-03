namespace MicroSign.Core.ViewModels.Pages
{
    /// <summary>
    /// AnimationClipPage状態
    /// </summary>
    public enum AnimationClipPageStateKind
    {
        /// <summary>
        /// 未初期化
        /// </summary>
        UnInitialize,

        /// <summary>
        /// 初期化済み
        /// </summary>
        Initialized,


        /// <summary>
        /// 失敗(=これ以上処理できない)
        /// </summary>
        Failed,

        /// <summary>
        /// 準備完了(=画面更新に成功した後)
        /// </summary>
        Ready,
    }
}
