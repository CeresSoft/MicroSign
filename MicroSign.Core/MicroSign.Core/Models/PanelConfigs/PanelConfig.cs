namespace MicroSign.Core.Models.PanelConfigs
{
    /// <summary>
    /// マップ設定
    /// </summary>
    public class PanelConfig
    {
        /// <summary>
        /// パネル横ドット数
        /// </summary>
        public int Width { get; set; } = 128;

        /// <summary>
        /// パネル縦ドット数
        /// </summary>
        public int Height { get; set; } = 32;

        /// <summary>
        /// パネル制御タイプ
        /// </summary>
        public PanelControlTypes ControlType { get; set; } = PanelControlTypes.HUB75;

        /// <summary>
        /// マップデータ
        /// </summary>
        public MapDataCollection MapDatas { get; set; } = new MapDataCollection();
    }
}
