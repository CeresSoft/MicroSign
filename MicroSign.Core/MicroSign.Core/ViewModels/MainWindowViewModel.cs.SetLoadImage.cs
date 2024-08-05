using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.ViewModels
{
    partial class MainWindowViewModel
    {
        /// <summary>
        /// LoadImageに設定
        /// </summary>
        /// <param name="image">設定する画像</param>
        public void SetLoadImage(BitmapSource? image)
        {
            this.LoadImage = image;
        }
    }
}
