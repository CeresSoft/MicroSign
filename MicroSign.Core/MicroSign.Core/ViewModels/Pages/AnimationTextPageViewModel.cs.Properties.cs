using System.Windows.Media.Imaging;

namespace MicroSign.Core.ViewModels.Pages
{
    /// <summary>
    /// アニメーションテキストページViewModel
    /// </summary>
    partial class AnimationTextPageViewModel
    {
        //「Documents\ViewModelプロパティ作成テンプレート.xlsx」の「AnimationTextPageViewModel」をコピー >>>>> ここから
        #region マトリクスLED横幅
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// マトリクスLED横幅初期値
            /// </summary>
            public const int MatrixLedWidth = 128;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// マトリクスLED横幅プロパティ名
            /// </summary>
            public const string MatrixLedWidth = "MatrixLedWidth";
        }

        /// <summary>
        /// マトリクスLED横幅保持変数
        /// </summary>
        protected int _MatrixLedWidth = InitializeValues.MatrixLedWidth;

        /// <summary>
        /// マトリクスLED横幅
        /// </summary>
        public int MatrixLedWidth
        {
            get
            {
                return this._MatrixLedWidth;
            }
            set
            {
                int now = this._MatrixLedWidth;
                if (now == value)
                {
                    return;
                }
                this._MatrixLedWidth = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region マトリクスLED縦幅
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// マトリクスLED縦幅初期値
            /// </summary>
            public const int MatrixLedHeight = 32;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// マトリクスLED縦幅プロパティ名
            /// </summary>
            public const string MatrixLedHeight = "MatrixLedHeight";
        }

        /// <summary>
        /// マトリクスLED縦幅保持変数
        /// </summary>
        protected int _MatrixLedHeight = InitializeValues.MatrixLedHeight;

        /// <summary>
        /// マトリクスLED縦幅
        /// </summary>
        public int MatrixLedHeight
        {
            get
            {
                return this._MatrixLedHeight;
            }
            set
            {
                int now = this._MatrixLedHeight;
                if (now == value)
                {
                    return;
                }
                this._MatrixLedHeight = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region アニメーション名
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// アニメーション名初期値
            /// </summary>
            public const string? AnimationName = "アニメーション";
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// アニメーション名プロパティ名
            /// </summary>
            public const string AnimationName = "AnimationName";
        }

        /// <summary>
        /// アニメーション名保持変数
        /// </summary>
        protected string? _AnimationName = InitializeValues.AnimationName;

        /// <summary>
        /// アニメーション名
        /// </summary>
        public string? AnimationName
        {
            get
            {
                return this._AnimationName;
            }
            set
            {
                string? now = this._AnimationName;
                if (now == value)
                {
                    return;
                }
                this._AnimationName = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region 選択フォントサイズ
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 選択フォントサイズ初期値
            /// </summary>
            public const int SelectFontSize = 16;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 選択フォントサイズプロパティ名
            /// </summary>
            public const string SelectFontSize = "SelectFontSize";
        }

        /// <summary>
        /// 選択フォントサイズ保持変数
        /// </summary>
        protected int _SelectFontSize = InitializeValues.SelectFontSize;

        /// <summary>
        /// 選択フォントサイズ
        /// </summary>
        /// <remarks>
        /// WPFのフォントサイズであるdip単位で入る
        /// </remarks>
        public int SelectFontSize
        {
            get
            {
                return this._SelectFontSize;
            }
            set
            {
                int now = this._SelectFontSize;
                if (now == value)
                {
                    return;
                }
                this._SelectFontSize = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region 選択フォント色
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 選択フォント色初期値
            /// </summary>
            public const int SelectFontColor = 7;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 選択フォント色プロパティ名
            /// </summary>
            public const string SelectFontColor = "SelectFontColor";
        }

        /// <summary>
        /// 選択フォント色保持変数
        /// </summary>
        protected int _SelectFontColor = InitializeValues.SelectFontColor;

        /// <summary>
        /// 選択フォント色
        /// </summary>
        /// <remarks>
        /// 1=赤色・2=緑色・3=黄色・4=青色・5=紫色・6=水色・7=白色
        /// </remarks>
        public int SelectFontColor
        {
            get
            {
                return this._SelectFontColor;
            }
            set
            {
                int now = this._SelectFontColor;
                if (now == value)
                {
                    return;
                }
                this._SelectFontColor = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region 表示文章
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 表示文章初期値
            /// </summary>
            public const string? DisplayText = null;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 表示文章プロパティ名
            /// </summary>
            public const string DisplayText = "DisplayText";
        }

        /// <summary>
        /// 表示文章保持変数
        /// </summary>
        protected string? _DisplayText = InitializeValues.DisplayText;

        /// <summary>
        /// 表示文章
        /// </summary>
        public string? DisplayText
        {
            get
            {
                return this._DisplayText;
            }
            set
            {
                string? now = this._DisplayText;
                if (now == value)
                {
                    return;
                }
                this._DisplayText = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region 状態区分
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 状態区分初期値
            /// </summary>
            public const AnimationTextPageStateKind StatusKind = AnimationTextPageStateKind.UnInitialize;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 状態区分プロパティ名
            /// </summary>
            public const string StatusKind = "StatusKind";
        }

        /// <summary>
        /// 状態区分保持変数
        /// </summary>
        protected AnimationTextPageStateKind _StatusKind = InitializeValues.StatusKind;

        /// <summary>
        /// 状態区分
        /// </summary>
        public AnimationTextPageStateKind StatusKind
        {
            get
            {
                return this._StatusKind;
            }
            set
            {
                AnimationTextPageStateKind now = this._StatusKind;
                if (now == value)
                {
                    return;
                }
                this._StatusKind = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region 状態テキスト
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 状態テキスト初期値
            /// </summary>
            public const string? StatusText = null;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 状態テキストプロパティ名
            /// </summary>
            public const string StatusText = "StatusText";
        }

        /// <summary>
        /// 状態テキスト保持変数
        /// </summary>
        protected string? _StatusText = InitializeValues.StatusText;

        /// <summary>
        /// 状態テキスト
        /// </summary>
        public string? StatusText
        {
            get
            {
                return this._StatusText;
            }
            set
            {
                string? now = this._StatusText;
                if (now == value)
                {
                    return;
                }
                this._StatusText = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region 描写先ビットマップ
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 描写先ビットマップ初期値
            /// </summary>
            public const RenderTargetBitmap? RenderBitmap = null;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 描写先ビットマッププロパティ名
            /// </summary>
            public const string RenderBitmap = "RenderBitmap";
        }

        /// <summary>
        /// 描写先ビットマップ保持変数
        /// </summary>
        protected RenderTargetBitmap? _RenderBitmap = InitializeValues.RenderBitmap;

        /// <summary>
        /// 描写先ビットマップ
        /// </summary>
        public RenderTargetBitmap? RenderBitmap
        {
            get
            {
                return this._RenderBitmap;
            }
            set
            {
                RenderTargetBitmap? now = this._RenderBitmap;
                if (now == value)
                {
                    return;
                }
                this._RenderBitmap = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        //「Documents\ViewModelプロパティ作成テンプレート.xlsx」の「AnimationTextPageViewModel」をコピー <<<<< ここまで
    }
}
