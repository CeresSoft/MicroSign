using System.Threading;

namespace MicroSign.Core.TaskUtils
{
    /// <summary>
    /// シグナルベース
    /// </summary>
    public abstract partial class SignalBase : MicroSign.Core.Disposables.ManageDisposable
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="signal"></param>
        public SignalBase(SignalInternal? signal)
        {
            this._Internal = signal;
            if (signal == null)
            {
                //シグナルが無効の場合は何もしない
            }
            else
            {
                //シグナルが有効の場合は参照カウンタを増やす
                signal.AddRef();
            }
        }

        /// <summary>
        /// 新しいシグナルトークンを取得
        /// </summary>
        /// <returns></returns>
        /// <remarks>取得したSignalTokenは必ずDispose()してください</remarks>
        public SignalToken GetNewToken()
        {
            SignalInternal? signal = this._Internal;
            SignalToken result = new SignalToken(signal);
            return result;
        }

        /// <summary>
        /// 新しいトークンを取得
        /// </summary>
        /// <remarks>取得したSignalTokenは必ずDispose()してください</remarks>
        public SignalToken Token
        {
            get
            {
                return this.GetNewToken();
            }
        }

        /// <summary>
        /// WaitHandle
        /// </summary>
        public WaitHandle? WaitHandle
        {
            get
            {
                SignalInternal? signal = this._Internal;
                if (signal == null)
                {
                    //シグナルが無効の場合はnullを返す
                    return null;
                }
                else
                {
                    //シグナルが有効の場合はハンドルを返す
                    return signal.WaitHandle;
                }
            }
        }

        /// <summary>
        /// シグナル設定
        /// </summary>
        public void Set()
        {
            SignalInternal? signal = this._Internal;
            if (signal == null)
            {
                //シグナルが無効の場合は何もしない
            }
            else
            {
                //シグナルが有効の場合は設定する
                signal.Set();
            }
        }

        /// <summary>
        /// シグナル解除
        /// </summary>
        public void Reset()
        {
            SignalInternal? signal = this._Internal;
            if (signal == null)
            {
                //シグナルが無効の場合は何もしない
            }
            else
            {
                //シグナルが有効の場合は解除する
                signal.Reset();
            }
        }

        /// <summary>
        /// シグナル待ち
        /// </summary>
        /// <returns>true=シグナル/false=タイムアウト</returns>
        public bool WaitOne()
        {
            SignalInternal? signal = this._Internal;
            if (signal == null)
            {
                //シグナルが無効の場合はシグナルで終了する
                return true;
            }
            else
            {
                //シグナルが有効の場合は待ち
                bool ret = signal.WaitOne();
                return ret;
            }
        }

        /// <summary>
        /// シグナル待ち
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns>true=シグナル/false=タイムアウト</returns>
        public bool WaitOne(int timeout)
        {
            SignalInternal? signal = this._Internal;
            if (signal == null)
            {
                //シグナルが無効の場合はシグナルで終了する
                return true;
            }
            else
            {
                //シグナルが有効の場合は待ち
                bool ret = signal.WaitOne(timeout);
                return ret;
            }
        }
    }
}
