using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSign.Core.ViewModels.Pages
{
    /// <summary>
    /// アニメーションテキストページViewModel
    /// </summary>
    partial class AnimationTextPageViewModel
    {
        /// <summary>
        /// 状態設定
        /// </summary>
        /// <param name="statusKind">設定する状態</param>
        public void SetStatus(AnimationTextPageStateKind statusKind)
        {
            this.SetStatus(statusKind, null);
        }

        /// <summary>
        /// 状態設定
        /// </summary>
        /// <param name="statusKind">設定する状態区分</param>
        /// <param name="statusText">設定する状態テキスト</param>
        public void SetStatus(AnimationTextPageStateKind statusKind, string? statusText)
        {
            this.StatusKind = statusKind;
            this.StatusText = statusText;
        }
    }
}
