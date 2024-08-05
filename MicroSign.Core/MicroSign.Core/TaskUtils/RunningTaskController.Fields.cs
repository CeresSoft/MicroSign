using System.Threading;

namespace MicroSign.Core.TaskUtils
{
    /// <summary>
    /// 実行中タスク制御 - フィールド定義
    /// </summary>
    partial class RunningTaskController
    {
        /// <summary>
        /// キャンセルトークンソース保持変数
        /// </summary>
        /// <remarks>コンストラクタで設定。CancellationTokenSourceが指定された場合はnullになります</remarks>
        private volatile CancellationTokenSource? _CancellationTokenSource = null;
    }
}
