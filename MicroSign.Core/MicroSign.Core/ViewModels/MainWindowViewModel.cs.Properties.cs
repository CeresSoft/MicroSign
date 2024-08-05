using MicroSign.Core.Models;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.ViewModels
{
    partial class MainWindowViewModel
    {
        //「Documents\ViewModelプロパティ作成テンプレート.xlsx」の「MainWindowViewModel」をコピー >>>>> ここから
        #region 読込画像
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 読込画像初期値
            /// </summary>
            public const BitmapSource? LoadImage = null;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 読込画像プロパティ名
            /// </summary>
            public const string LoadImage = "LoadImage";
        }

        /// <summary>
        /// 読込画像保持変数
        /// </summary>
        protected BitmapSource? _LoadImage = InitializeValues.LoadImage;

        /// <summary>
        /// 読込画像
        /// </summary>
        public BitmapSource? LoadImage
        {
            get
            {
                return this._LoadImage;
            }
            set
            {
                BitmapSource? now = this._LoadImage;
                if (now == value)
                {
                    return;
                }
                this._LoadImage = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region 変換画像
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 変換画像初期値
            /// </summary>
            public const WriteableBitmap? ConvertImage = null;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 変換画像プロパティ名
            /// </summary>
            public const string ConvertImage = "ConvertImage";
        }

        /// <summary>
        /// 変換画像保持変数
        /// </summary>
        protected WriteableBitmap? _ConvertImage = InitializeValues.ConvertImage;

        /// <summary>
        /// 変換画像
        /// </summary>
        public WriteableBitmap? ConvertImage
        {
            get
            {
                return this._ConvertImage;
            }
            set
            {
                WriteableBitmap? now = this._ConvertImage;
                if (now == value)
                {
                    return;
                }
                this._ConvertImage = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region クラス名
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// クラス名初期値
            /// </summary>
            public const string? Name = "MatrixLedImage";
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// クラス名プロパティ名
            /// </summary>
            public const string Name = "Name";
        }

        /// <summary>
        /// クラス名保持変数
        /// </summary>
        protected string? _Name = InitializeValues.Name;

        /// <summary>
        /// クラス名
        /// </summary>
        public string? Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                string? now = this._Name;
                if (now == value)
                {
                    return;
                }
                this._Name = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region 赤閾値
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 赤閾値初期値
            /// </summary>
            public const int RedThreshold = 128;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 赤閾値プロパティ名
            /// </summary>
            public const string RedThreshold = "RedThreshold";
        }

        /// <summary>
        /// 赤閾値保持変数
        /// </summary>
        protected int _RedThreshold = InitializeValues.RedThreshold;

        /// <summary>
        /// 赤閾値
        /// </summary>
        public int RedThreshold
        {
            get
            {
                return this._RedThreshold;
            }
            set
            {
                int now = this._RedThreshold;
                if (now == value)
                {
                    return;
                }
                this._RedThreshold = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region 緑閾値
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 緑閾値初期値
            /// </summary>
            public const int GreenThreshold = 128;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 緑閾値プロパティ名
            /// </summary>
            public const string GreenThreshold = "GreenThreshold";
        }

        /// <summary>
        /// 緑閾値保持変数
        /// </summary>
        protected int _GreenThreshold = InitializeValues.GreenThreshold;

        /// <summary>
        /// 緑閾値
        /// </summary>
        public int GreenThreshold
        {
            get
            {
                return this._GreenThreshold;
            }
            set
            {
                int now = this._GreenThreshold;
                if (now == value)
                {
                    return;
                }
                this._GreenThreshold = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region 青閾値
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 青閾値初期値
            /// </summary>
            public const int BlueThreshold = 128;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 青閾値プロパティ名
            /// </summary>
            public const string BlueThreshold = "BlueThreshold";
        }

        /// <summary>
        /// 青閾値保持変数
        /// </summary>
        protected int _BlueThreshold = InitializeValues.BlueThreshold;

        /// <summary>
        /// 青閾値
        /// </summary>
        public int BlueThreshold
        {
            get
            {
                return this._BlueThreshold;
            }
            set
            {
                int now = this._BlueThreshold;
                if (now == value)
                {
                    return;
                }
                this._BlueThreshold = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region 変換コード
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 変換コード初期値
            /// </summary>
            public const string? Code = null;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 変換コードプロパティ名
            /// </summary>
            public const string Code = "Code";
        }

        /// <summary>
        /// 変換コード保持変数
        /// </summary>
        protected string? _Code = InitializeValues.Code;

        /// <summary>
        /// 変換コード
        /// </summary>
        public string? Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                string? now = this._Code;
                if (now == value)
                {
                    return;
                }
                this._Code = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region 変換フォーマット
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 変換フォーマット初期値
            /// </summary>
            public const FormatKinds FormatKind = FormatKinds.Color256;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 変換フォーマットプロパティ名
            /// </summary>
            public const string FormatKind = "FormatKind";
        }

        /// <summary>
        /// 変換フォーマット保持変数
        /// </summary>
        protected FormatKinds _FormatKind = InitializeValues.FormatKind;

        /// <summary>
        /// 変換フォーマット
        /// </summary>
        public FormatKinds FormatKind
        {
            get
            {
                return this._FormatKind;
            }
            set
            {
                FormatKinds now = this._FormatKind;
                if (now == value)
                {
                    return;
                }
                this._FormatKind = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region アニメーション画像コレクション
        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// アニメーション画像コレクションプロパティ名
            /// </summary>
            public const string AnimationImages = "AnimationImages";
        }

        /// <summary>
        /// アニメーション画像コレクション保持変数
        /// </summary>
        protected AnimationImageItemCollection _AnimationImages = new AnimationImageItemCollection();

        /// <summary>
        /// アニメーション画像コレクション
        /// </summary>
        public AnimationImageItemCollection AnimationImages
        {
            get
            {
                return this._AnimationImages;
            }
            set
            {
                AnimationImageItemCollection now = this._AnimationImages;
                if (now == value)
                {
                    return;
                }
                this._AnimationImages = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region 選択アニメーション画像
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 選択アニメーション画像初期値
            /// </summary>
            public const AnimationImageItem? SelectedAnimationImageItem = null;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 選択アニメーション画像プロパティ名
            /// </summary>
            public const string SelectedAnimationImageItem = "SelectedAnimationImageItem";
        }

        /// <summary>
        /// 選択アニメーション画像保持変数
        /// </summary>
        protected AnimationImageItem? _SelectedAnimationImageItem = InitializeValues.SelectedAnimationImageItem;

        /// <summary>
        /// 選択アニメーション画像
        /// </summary>
        public AnimationImageItem? SelectedAnimationImageItem
        {
            get
            {
                return this._SelectedAnimationImageItem;
            }
            set
            {
                AnimationImageItem? now = this._SelectedAnimationImageItem;
                if (now == value)
                {
                    return;
                }
                this._SelectedAnimationImageItem = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

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

        #region マトリクスLED明るさ
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// マトリクスLED明るさ初期値
            /// </summary>
            public const int MatrixLedBrightness = 156;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// マトリクスLED明るさプロパティ名
            /// </summary>
            public const string MatrixLedBrightness = "MatrixLedBrightness";
        }

        /// <summary>
        /// マトリクスLED明るさ保持変数
        /// </summary>
        protected int _MatrixLedBrightness = InitializeValues.MatrixLedBrightness;

        /// <summary>
        /// マトリクスLED明るさ
        /// </summary>
        public int MatrixLedBrightness
        {
            get
            {
                return this._MatrixLedBrightness;
            }
            set
            {
                int now = this._MatrixLedBrightness;
                if (now == value)
                {
                    return;
                }
                this._MatrixLedBrightness = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region アニメーション再生中
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// アニメーション再生中初期値
            /// </summary>
            public const bool IsPlayingAnimation = false;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// アニメーション再生中プロパティ名
            /// </summary>
            public const string IsPlayingAnimation = "IsPlayingAnimation";
        }

        /// <summary>
        /// アニメーション再生中保持変数
        /// </summary>
        protected bool _IsPlayingAnimation = InitializeValues.IsPlayingAnimation;

        /// <summary>
        /// アニメーション再生中
        /// </summary>
        public bool IsPlayingAnimation
        {
            get
            {
                return this._IsPlayingAnimation;
            }
            set
            {
                bool now = this._IsPlayingAnimation;
                if (now == value)
                {
                    return;
                }
                this._IsPlayingAnimation = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region デフォルト表示期間(秒)
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// デフォルト表示期間(秒)初期値
            /// </summary>
            public const double DefaultDisplayPeriod = 0.1;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// デフォルト表示期間(秒)プロパティ名
            /// </summary>
            public const string DefaultDisplayPeriod = "DefaultDisplayPeriod";
        }

        /// <summary>
        /// デフォルト表示期間(秒)保持変数
        /// </summary>
        protected double _DefaultDisplayPeriod = InitializeValues.DefaultDisplayPeriod;

        /// <summary>
        /// デフォルト表示期間(秒)
        /// </summary>
        public double DefaultDisplayPeriod
        {
            get
            {
                return this._DefaultDisplayPeriod;
            }
            set
            {
                double now = this._DefaultDisplayPeriod;
                if (now == value)
                {
                    return;
                }
                this._DefaultDisplayPeriod = value;
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

        //「Documents\ViewModelプロパティ作成テンプレート.xlsx」の「MainWindowViewModel」をコピー <<<<< ここまで
    }
}
