using MicroSign.Core.Navigations;
using MicroSign.Core.ViewModels.Overlaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MicroSign.Core.Views.Overlaps
{
    /// <summary>
    /// ConfirmMessageBox.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfirmMessageBox : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfirmMessageBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        public ConfirmMessageBox(string message)
            : this()
        {
            this.ViewModel.Message = message;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public ConfirmMessageBox(string message, string title)
            : this()
        {
            this.ViewModel.Message = message;
            this.ViewModel.Title = title;
        }

        /// <summary>
        /// OKクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOkClick(object sender, MicroSign.Core.Navigations.Events.OkClickEventArgs e)
        {
            //画面終了
            this.NavigationReturn(MicroSign.Core.Navigations.Enums.NavigationResultKind.Success);

            //成功で終了
            e.Success();
        }

        /// <summary>
        /// キャンセルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelClick(object sender, MicroSign.Core.Navigations.Events.CancelClickEventArgs e)
        {
            //画面終了
            this.NavigationReturn(MicroSign.Core.Navigations.Enums.NavigationResultKind.Cancel);
        }
    }
}
