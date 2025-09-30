using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSign.Core.ViewModels.Pages
{
    /// <summary>
    /// AnimationTextPage状態
    /// </summary>
    public enum AnimationTextPageStateKind
    {
        /// <summary>
        /// 未初期化
        /// </summary>
        UnInitialize,

        /// <summary>
        /// 初期化済み
        /// </summary>
        Initialized,


        /// <summary>
        /// 失敗(=これ以上処理できない)
        /// </summary>
        Failed,

        /// <summary>
        /// 準備完了(=画面更新に成功した後)
        /// </summary>
        Ready,
    }
}
