using MicroSign.Core.Navigations;

namespace MicroSign
{
    partial class MainWindow
    {
        /// <summary>
        /// 情報表示
        /// </summary>
        /// <param name="message"></param>
        private void ShowInfo(string message)
        {
            this.NaviPanel.NavigationOverwrap(new MicroSign.Core.Views.Overlaps.InfoMessageBox(message, this.Title));
        }
    }
}
