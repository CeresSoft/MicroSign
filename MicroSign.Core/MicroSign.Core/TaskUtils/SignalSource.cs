namespace MicroSign.Core.TaskUtils
{
    /// <summary>
    /// シグナルソース
    /// </summary>
    /// <remarks>ManualResetEventのラップクラス。複数タスクで動作させる</remarks>
    public partial class SignalSource : SignalBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SignalSource()
            : this (false)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="initialSignal">初期シグナル状態(通常はfalse)</param>
        public SignalSource(bool initialSignal)
            : base(new SignalInternal(initialSignal))
        {
        }
    }
}
