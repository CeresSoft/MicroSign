namespace MicroSign.Core.TaskUtils
{
    /// <summary>
    /// シグナルベース - 破棄
    /// </summary>
    partial class SignalBase
    {
        /// <summary>
        /// マネージDispose
        /// </summary>
        protected override void ManegedDispose()
        {
            //シグナル内部クラスの参照を減らす
            SignalInternal? signal = this._Internal;
            this._Internal = null;
            if (signal == null)
            {
                //シグナルが無効の場合は何もしない
            }
            else
            {
                //シグナルが有効の場合は参照カウンタを減らす
                signal.Release();
            }
        }

        /// <summary>
        /// 大きなフィールドを null に設定
        /// </summary>
        protected override void HugeManegedSetNull()
        {
            //無し
        }
    }
}
