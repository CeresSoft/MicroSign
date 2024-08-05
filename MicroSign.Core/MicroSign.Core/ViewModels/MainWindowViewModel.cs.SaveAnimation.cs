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
        /// アニメーション設定保存
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public (bool IsSuccess, string ErrorMessage) SaveAnimation(string path)
        {
            return this.Model.SaveAnimation(path, this.AnimationName, this.AnimationImages, this.MatrixLedWidth, this.MatrixLedHeight, this.MatrixLedBrightness, this.DefaultDisplayPeriod);
        }
    }
}
