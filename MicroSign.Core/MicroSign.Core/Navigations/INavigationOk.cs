namespace MicroSign.Core.Navigations
{
    /// <summary>
    /// ナビゲーションコントローラー用OK
    /// </summary>
    /// <remarks>ナビゲーションの外からOKを通知する</remarks>
    public interface INavigationOk
    {
        /// <summary>
        /// OK
        /// </summary>
        /// <param name="arg">パラメータ</param>
        void NavigationOk(object arg);
    }
}
