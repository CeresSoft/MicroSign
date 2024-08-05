using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroSign.Core.Models
{
    /// <summary>
    /// モデル
    /// </summary>
    public partial class Model
    {
        /// <summary>
        /// モデルインスタンス
        /// </summary>
        /// <remarks>
        /// 2023.11.23:CS)土田:Core.dllに分離するにあたり、どこからでも参照できる単一インスタンスを追加
        ///  >> 分離前はAppクラスにstaticプロパティを定義していました
        /// </remarks>
        public static MicroSign.Core.Models.Model Instance { get; private set; } = new MicroSign.Core.Models.Model();
    }
}
