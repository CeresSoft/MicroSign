using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSign.Core.ViewModels
{
    partial class MainWindowViewModel
    {
        /// <summary>
        /// 選択アニメーション画像を取得
        /// </summary>
        /// <returns></returns>
        public AnimationImageItem? GetSelectAnimationImage()
        {
            return this.SelectedAnimationImageItem;
        }
    }
}
