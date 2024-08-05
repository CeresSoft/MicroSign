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

namespace MicroSign.Core.Views.Pages
{
    /// <summary>
    /// AnimationTextRenderUserControl.xaml の相互作用ロジック
    /// </summary>
    public partial class AnimationTextRenderUserControl : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AnimationTextRenderUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 表示テキスト
        /// </summary>
        public string Text
        {
            get
            {
                return this.DisplayText.Text;
            }
            set
            {
                this.DisplayText.Text = value;
            }
        }

        /// <summary>
        /// 表示フォントサイズ
        /// </summary>
        public double DisplayTextFontSize
        {
            get
            {
                return this.DisplayText.FontSize;
            }
            set
            {
                this.DisplayText.FontSize = value;
            }
        }

        /// <summary>
        /// 表示フォント色
        /// </summary>
        public Brush DisplayTextColor
        {
            get
            {
                return this.DisplayText.Foreground;
            }
            set
            {
                this.DisplayText.Foreground = value;
            }
        }
    }
}
