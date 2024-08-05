using System.Collections.Generic;
using System.Threading;

namespace MicroSign.Core.TaskUtils
{
    /// <summary>
    /// 実行中タスク制御管理 - フィールド定義
    /// </summary>
    partial class RunningTaskControllerManager
    {
        /// <summary>
        /// キャンセルトークンソース
        /// </summary>
        protected CancellationTokenSource _CancellationTokenSource = new CancellationTokenSource();

        /// <summary>
        /// 実行中タスクコレクション
        /// </summary>
        protected List<RunningTaskController> _RunningTaskCollection = new List<RunningTaskController>();

        /// <summary>
        /// 実行中タスクコレクションロックオブジェクト
        /// </summary>
        protected object _RunningTaskCollectionLockObject = new object();
    }
}
