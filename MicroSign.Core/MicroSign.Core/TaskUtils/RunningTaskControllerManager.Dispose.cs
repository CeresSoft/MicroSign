using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MicroSign.Core.TaskUtils
{
    /// <summary>
    /// 実行中タスク制御管理 - 破棄
    /// </summary>
    partial class RunningTaskControllerManager
    {
        /// <summary>
        /// マネージ破棄
        /// </summary>
        protected override void ManegedDispose()
        {
            //実行中の全タスクを得る
            System.Collections.Generic.List<Task> taskList = new System.Collections.Generic.List<Task>();
            lock(this._RunningTaskCollectionLockObject)
            {
                foreach(RunningTaskController runningTaskController in this._RunningTaskCollection)
                {
                    Task? t = runningTaskController.RunningTask;
                    if(t == null)
                    {
                        //タスクが無効の場合は何もしない
                    }
                    else
                    {
                        //タスクが有効の場合はリストに追加
                        taskList.Add(t);
                    }
                }
            }

            //タスク配列を取得
            Task[] tasks = taskList.ToArray();

            //キャンセル
            using (CancellationTokenSource cancel = this._CancellationTokenSource)
            {
                //キャンセルする
                try
                {
                    cancel.Cancel();
                }
                catch (Exception)
                {
                    //例外は握りつぶす
                }

                //全タスクが停止するのを待つ
                Task.WaitAll(tasks, CommonConsts.Intervals.OneSec);
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
