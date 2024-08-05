using MicroSign.Core.Navigations;
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
    /// ErrorMessageBox.xaml の相互作用ロジック
    /// </summary>
    public partial class ErrorMessageBox : UserControl
    {
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public ErrorMessageBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        public ErrorMessageBox(string message)
            : this()
        {
            this.ViewModel.Message = message;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public ErrorMessageBox(string message, string title)
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
            this.NavigationReturn();

            //成功で終了
            e.Success();
        }
    }
}
