namespace MicroSign.Core.Navigations
{
    /// <summary>
    /// ナビゲーションコントローラー用受取パラメータ
    /// </summary>
    /// <remarks>遷移か呼出で、遷移元から遷移先に渡すパラメータ</remarks>
    public interface INavigationReceiveParameter
    {
        /// <summary>
        /// 受取パラメータ
        /// </summary>
        /// <param name="action">ナビゲーション動作(遷移・呼出・オーバーラップ)</param>
        /// <param name="sender">呼出元</param>
        /// <param name="arg">パラメータ</param>
        void NavigationReceiveParameter(NavigationActions action, object? sender, object? arg);
    }
}
