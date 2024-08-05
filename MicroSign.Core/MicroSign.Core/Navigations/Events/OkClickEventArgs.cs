using MicroSign.Core.Navigations.Enums;
using System;

namespace MicroSign.Core.Navigations.Events
{
    /// <summary>
    /// OKクリックイベントハンドラ定義
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OkClickEventHandler(object sender, OkClickEventArgs e);

    /// <summary>
    /// OKクリックイベント引数
    /// </summary>
    public class OkClickEventArgs : EventArgs
    {
        /// <summary>
        /// 処理結果
        /// </summary>
        public NavigationResultKind Result { get; private set; } = NavigationResultKind.Failed;

        /// <summary>
        /// メッセージ
        /// </summary>
        public string? Message { get; private set; } = null;

        /// <summary>
        /// 例外
        /// </summary>
        public Exception? Error { get; private set; } = null;

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        /// <param name="entity"></param>
        public OkClickEventArgs()
        {
        }

        /// <summary>
        /// 成功
        /// </summary>
        public void Success()
        {
            this.Result = NavigationResultKind.Success;
        }

        /// <summary>
        /// 失敗
        /// </summary>
        /// <param name="message"></param>
        public string Failed(string message)
        {
            this.Result = NavigationResultKind.Failed;
            this.Message = message;
            return message;
        }

        /// <summary>
        /// 失敗
        /// </summary>
        /// <param name="message"></param>
        /// <param name="error"></param>
        public string Failed(string message, Exception error)
        {
            this.Result = NavigationResultKind.Failed;
            this.Message = message;
            this.Error = error;
            return message;
        }

        /// <summary>
        /// キャンセル
        /// </summary>
        public void Cancel()
        {
            this.Result = NavigationResultKind.Cancel;
        }
    }
}
