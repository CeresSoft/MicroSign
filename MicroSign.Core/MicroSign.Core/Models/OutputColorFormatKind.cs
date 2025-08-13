using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSign.Core.Models
{
    /// <summary>
    /// 出力色形式
    /// </summary>
    public enum OutputColorFormatKind
    {
        /// <summary>
        /// 64色
        /// </summary>
        Color64 = 64,

        /// <summary>
        /// 256色
        /// </summary>
        Color256 = 256,

        /// <summary>
        /// インデックスカラー
        /// </summary>
        IndexColor = 0xFFFF,
    }
}
