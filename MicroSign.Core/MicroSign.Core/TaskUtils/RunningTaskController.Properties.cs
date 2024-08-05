using System.Threading.Tasks;

namespace MicroSign.Core.TaskUtils
{
    /// <summary>
    /// 実行中タスク制御 - プロパティ
    /// </summary>
    partial class RunningTaskController
    {
        /// <summary>
        /// 実行中タスク保持
        /// </summary>
        private volatile Task? _RunningTask = null;

        /// <summary>
        /// 実行中タスク
        /// </summary>
        public Task? RunningTask
        {
            get
            {
                return this._RunningTask;
            }
            protected set
            {
                this._RunningTask = value;
            }
        }
    }
}
