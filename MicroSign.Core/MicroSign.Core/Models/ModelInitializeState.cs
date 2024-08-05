namespace MicroSign.Core.Models
{
    /// <summary>
    /// モデル初期化状態
    /// </summary>
    public enum ModelInitializeState
    {
        /// <summary>
        /// 未初期化
        /// </summary>
        Uninitialized,

        /// <summary>
        /// 初期化中
        /// </summary>
        Initializing,

        /// <summary>
        /// 初期化済み
        /// </summary>
        Initialized,

        /// <summary>
        /// 初期化失敗
        /// </summary>
        Failed,
    }
}
