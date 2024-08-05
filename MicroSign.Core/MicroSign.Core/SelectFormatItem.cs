namespace MicroSign.Core
{
    public class SelectFormatItem
    {
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 値
        /// </summary>
        public FormatKinds Value { get; set; } = FormatKinds.HighSpeed;
    }
}
