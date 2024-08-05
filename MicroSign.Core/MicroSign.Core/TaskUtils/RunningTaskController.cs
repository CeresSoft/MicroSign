using System;
using System.Threading;
using System.Threading.Tasks;

namespace MicroSign.Core.TaskUtils
{
    /// <summary>
    /// 実行中タスク制御
    /// </summary>
    public abstract partial class RunningTaskController : MicroSign.Core.Disposables.ManageDisposable
    {
        /// <summary>
        /// 実行
        /// </summary>
        public Task? Run()
        {
            return this.Run(null);
        }

        /// <summary>
        /// 実行
        /// </summary>
        /// <param name="cancel"></param>
        public virtual Task? Run(CancellationTokenSource? cancel)
        {
            CancellationTokenSource? source = cancel;
            if (cancel == null)
            {
                //キャンセルが指定されない場合生成する
                cancel = new CancellationTokenSource();
                //生成した場合はキャンセルを保存しておく
                // >> キャンセルできるようにする
                this._CancellationTokenSource = source;
            }
            else
            {
                //キャンセルが指定された場合は何もせず処理続行
            }

            //キャンセルトークン取得
            // >> ここに来た時はsourceは非nullになっている
            CancellationToken token = source!.Token;

            //タスク関数実行
            try
            {
                Task result = Task.Run(() => this.TaskFunc(token), token);
                this.RunningTask = result;

                //終了
                return result;
            }
            catch(Exception)
            {
                //タスク実行に失敗した場合は握りつぶして終了
                return null;
            }
        }

        /// <summary>
        /// タスク関数
        /// </summary>
        /// <param name="token"></param>
        /// <remarks>派生クラスでオーバーライドする</remarks>
        protected abstract void TaskFunc(CancellationToken token);
    }
}
