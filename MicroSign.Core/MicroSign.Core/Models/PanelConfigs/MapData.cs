namespace MicroSign.Core.Models.PanelConfigs
{
    /// <summary>
    /// マップデータ
    /// </summary>
    public class MapData
    {
        /// <summary>
        /// パネル行
        /// </summary>
        public int PanelRow { get; set; } = CommonConsts.Index.First;

        /// <summary>
        /// パネル列
        /// </summary>
        public int PanelColumn { get; set; } = CommonConsts.Index.First;

        /// <summary>
        /// マップ行
        /// </summary>
        public int MapRow { get; set; } = CommonConsts.Index.First;

        /// <summary>
        /// マップ列
        /// </summary>
        public int MapColumn { get; set; } = CommonConsts.Index.First;
    }
}
