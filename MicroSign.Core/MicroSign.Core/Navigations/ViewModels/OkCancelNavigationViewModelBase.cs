namespace MicroSign.Core.Navigations.ViewModels
{
    /// <summary>
    /// OK/キャンセルナビゲーションViewModel
    /// </summary>
    public partial class OkCancelNavigationViewModelBase : NotifyPropertyChangedObject
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public OkCancelNavigationViewModelBase()
        {
            //OKコマンド
            this.OkCommand = new MicroSign.Core.ViewModels.DelegateCommand(this.OnOk);

            //キャンセルコマンド
            this.CancelCommand = new MicroSign.Core.ViewModels.DelegateCommand(this.OnCancel);
        }

        /// <summary>
        /// OKクリック
        /// </summary>
        /// <param name="parameter"></param>
        private void OnOk(object? parameter)
        {
            //OKを発行
            this.RaiseOkClick();
        }

        /// <summary>
        /// キャンセルクリック
        /// </summary>
        /// <param name="parameter"></param>
        private void OnCancel(object? parameter)
        {
            this.RaiseCancelClick();
        }
    }
}
