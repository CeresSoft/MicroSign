namespace MicroSign.Core.ViewModels
{
    /// <summary>
    /// 実行関数定義
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public delegate void DelegateCommandExecuteDelegate(object? parameter);

    /// <summary>
    /// 実行許可関数定義
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public delegate bool DelegateCommandCanExecuteDelegate(object? parameter);

    /// <summary>
    /// デリゲートコマンド - フィールド定義
    /// </summary>
    partial class DelegateCommand
    {
        /// <summary>
        /// 実行関数
        /// </summary>
        protected DelegateCommandExecuteDelegate? _ExecuteAction = null;

        /// <summary>
        /// 実行許可関数
        /// </summary>
        protected DelegateCommandCanExecuteDelegate? _CanExecuteAction = null;
    }
}
