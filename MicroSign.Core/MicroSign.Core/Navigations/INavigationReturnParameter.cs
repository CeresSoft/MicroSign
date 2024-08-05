namespace MicroSign.Core.Navigations
{
    /// <summary>
    /// ナビゲーションコントローラー用返却パラメータ
    /// </summary>
    /// <remarks>戻り処理で、遷移先から遷移元に返却パラメータ</remarks>
    public interface INavigationReturnParameter
    {
        /// <summary>
        /// 返却パラメータ
        /// </summary>
        /// <param name="arg">パラメータ</param>
        void NavigationReturnParameter(object sender, object? arg);
    }
}
