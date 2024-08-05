using System.Threading;

namespace MicroSign.Core.TaskUtils
{
    /// <summary>
    /// シグナル内部クラス - フィールド定義
    /// </summary>
    partial class SignalInternal
    {
        /// <summary>
        /// シグナル本体
        /// </summary>
        /// <remarks>コンストラクタで生成する。参照カウンタで管理する</remarks>
        protected ManualResetEvent _Signal;

        /// <summary>
        /// 参照カウンタ
        /// </summary>
        protected volatile int _ReferenceCount = CommonConsts.Count.Zero;
    }
}
