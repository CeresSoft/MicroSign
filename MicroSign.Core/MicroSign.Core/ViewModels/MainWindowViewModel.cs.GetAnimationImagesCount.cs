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
        /// アニメーション画像コレクション数を返す
        /// </summary>
        /// <returns></returns>
        public int GetAnimationImagesCount()
        {
            return this.AnimationImages.Count;
		}
    }
}
