using System;
using System.Threading;

namespace MicroSign.Core.Disposables
{
    /// <summary>
    /// マネージ用Dispose実装クラス
    /// </summary>
    public abstract class ManageDisposable : IDisposable
    {
        /// <summary>
        /// Disposeフラグ
        /// </summary>
        private volatile int _Disposed = CommonConsts.FlagValue.FALSE;

        /// <summary>
        /// Dispose済み判定
        /// </summary>
        public bool IsDisposed()
        {
            int nDisposed = this._Disposed;
            bool result = CommonConsts.FlagValue.FromFalgValue(nDisposed);
            return result;
        }

        //'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        ///// <summary>
        /////	ファイナライザ
        ///// </summary>
        //~ManageDisposable()
        //{
        //    this.Dispose(false);
        //}

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 実際のDispose処理
        /// </summary>
        /// <param name="isDisposing">Dispose()呼び出し=true/ファイナライザ呼び出し=false</param>
        protected virtual void Dispose(bool isDisposing)
        {
            // Disposeフラグを破棄済みに設定
            int nDisposed = Interlocked.Exchange(ref this._Disposed, CommonConsts.FlagValue.TRUE);

            // Disposeしていない場合(=初期値の場合)だけ実施
            bool isDisposed = CommonConsts.FlagValue.FromFalgValue(nDisposed);
            if (isDisposed)
            {
                //Dispose済みは何もしない
            }
            else
            {
                // Maneged Resourceを解放
                if (isDisposing)
                {
                    try
                    {
                        this.ManegedDispose();
                    }
                    catch(Exception)
                    {
                        //例外は握りつぶす
                    }
                }
                // Huge Managed Resourceを解放
                try
                {
                    this.HugeManegedSetNull();
                }
                catch(Exception)
                {
                    //例外は握りつぶす
                }
            }
        }

        /// <summary>
        /// マネージリソースのDispose
        /// </summary>
        protected abstract void ManegedDispose();

        /// <summary>
        /// 巨大なマネージリソースをNULLに設定
        /// </summary>
        protected abstract void HugeManegedSetNull();
    }
}
