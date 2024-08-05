namespace MicroSign.Core.Navigations
{
    /// <summary>
    /// ナビゲーションコントローラー用キャンセル
    /// </summary>
    /// <remarks>ナビゲーションの外からキャンセルを通知する</remarks>
    public interface INavigationCancel
    {
        /// <summary>
        /// キャンセル
        /// </summary>
        /// <param name="arg">パラメータ</param>
        void NavigationCancel(object arg);
    }
}
