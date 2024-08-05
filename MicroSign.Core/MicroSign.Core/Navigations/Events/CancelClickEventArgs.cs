using System;

namespace MicroSign.Core.Navigations.Events
{
    /// <summary>
    /// キャンセルクリックイベントハンドラ定義
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void CancelClickEventHandler(object sender, CancelClickEventArgs e);

    /// <summary>
    /// キャンセルクリックイベント引数
    /// </summary>
    public class CancelClickEventArgs : EventArgs
    {
    }
}
