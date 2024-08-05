using System;
using System.Threading;
using System.Threading.Tasks;

namespace MicroSign.Core.TaskUtils
{
    /// <summary>
    /// 実行中タスク制御 - 破棄
    /// </summary>
    partial class RunningTaskController
    {
        /// <summary>
        /// マネージ破棄
        /// </summary>
        protected override void ManegedDispose()
        {
            //キャンセル
            using (CancellationTokenSource? cancel = this._CancellationTokenSource)
            {
                //キャンセルする
                if (cancel == null)
                {
                    //キャンセルが無効の場合は何もしない
                }
                else
                {
                    //キャンセルが有効の場合はキャンセルする
                    try
                    {
                        cancel.Cancel();
                    }
                    catch (Exception)
                    {
                        //例外は握りつぶす
                    }
                }

                //タスクが停止するのを待つ
                {
                    Task? t = this.RunningTask;
                    if (t == null)
                    {
                        //タスクが無効の場合は何もしない
                    }
                    else
                    {
                        //タスクが有効の場合は停止するまで1秒待つ
                        try
                        {
                            t.Wait(CommonConsts.Intervals.OneSec);
                        }
                        catch (Exception)
                        {
                            //例外は握りつぶす
                        }
                        // >> タスクは破棄しない
                        ////タスク破棄
                        //try
                        //{
                        //    t.Dispose();
                        //}
                        //catch(Exception)
                        //{
                        //    //例外は握りつぶす
                        //}
                        // << タスクは破棄しない
                    }
                }
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
