namespace MicroSign.Core.Navigations
{
    /// <summary>
    /// ナビゲーションコントローラー用遷移検出
    /// </summary>
    /// <remarks>遷移処理で、遷移元が画面から消える直前に呼び出します</remarks>
    public interface INavigationMove
    {
        /// <summary>
        /// 遷移
        /// </summary>
        /// <param name="next">遷移先のエレメント</param>
        /// <param name="arg">パラメータ</param>
        void NavigationMove(object next, object arg);
    }
}
