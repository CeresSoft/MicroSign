using MicroSign.Core.ViewModels;

namespace MicroSign.Core.Models.AnimationSaveSettings
{
    /// <summary>
    /// 保存用アニメーションデータ
    /// </summary>
    public class AnimationSaveData
    {
        /// <summary>
        /// 画像タイプ
        /// </summary>
        /// <remarks>画像ファイルかテキスかを区別する型。本来派生で対応するべきだが.NET6ではJSONシリアライザーが対応していないので値にしました</remarks>
        public AnimationImageType ImageType { get; set; } = AnimationImageItem.InitializeValues.ImageType;

        /// <summary>
        /// 画像パス
        /// </summary>
        /// <remarks>画像タイプが画像ファイルの場合だけ</remarks>
        public string? ImagePath { get; set; } = null;

        /// <summary>
        /// 表示期間(秒)
        /// </summary>
        public double DisplayPeriod { get; set; } = AnimationImageItem.InitializeValues.DisplayPeriod;

        /// <summary>
        /// 画像種類
        /// </summary>
        public AnimationImageKinds Kind { get; set; } = AnimationImageItem.InitializeValues.Kind;

        /// <summary>
        /// 画像範囲X
        /// </summary>
        public ushort RectX { get; set; } = AnimationImageItem.InitializeValues.RectX;

        /// <summary>
        /// 画像範囲Y
        /// </summary>
        public ushort RectY { get; set; } = AnimationImageItem.InitializeValues.RectY;

        /// <summary>
        /// 画像範囲横幅
        /// </summary>
        public ushort RectWidth { get; set; } = AnimationImageItem.InitializeValues.RectWidth;

        /// <summary>
        /// 画像範囲縦幅
        /// </summary>
        public ushort RectHeight { get; set; } = AnimationImageItem.InitializeValues.RectHeight;

        /// <summary>
        /// 描写先X
        /// </summary>
        public ushort OffsetX { get; set; } = AnimationImageItem.InitializeValues.OffsetX;

        /// <summary>
        /// 描写先Y
        /// </summary>
        public ushort OffsetY { get; set; } = AnimationImageItem.InitializeValues.OffsetY;

        /// <summary>
        /// 透明色
        /// </summary>
        public uint TransparentRGB { get; set; } = AnimationImageItem.InitializeValues.TransparentRGB;

        /// <summary>
        /// 選択文字サイズ
        /// </summary>
        /// <remarks>画像タイプがテキストの場合だけ</remarks>
        public int SelectFontSize { get; set; } = AnimationImageItem.InitializeValues.SelectFontSize;

        /// <summary>
        /// 選択文字色
        /// </summary>
        /// <remarks>画像タイプがテキストの場合だけ</remarks>
        public int SelectFontColor { get; set; } = AnimationImageItem.InitializeValues.SelectFontColor;

        /// <summary>
        /// 表示文字
        /// </summary>
        /// <remarks>画像タイプがテキストの場合だけ</remarks>
        public string? DisplayText { get; set; } = AnimationImageItem.InitializeValues.DisplayText;
    }
}
