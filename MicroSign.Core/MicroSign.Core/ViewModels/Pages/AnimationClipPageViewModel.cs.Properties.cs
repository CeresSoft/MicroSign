using System.Windows.Media.Imaging;

namespace MicroSign.Core.ViewModels.Pages
{
    partial class AnimationClipPageViewModel
    {
        //「Documents\ViewModelプロパティ作成テンプレート.xlsx」の「ImageClipPageViewModel」をコピー >>>>> ここから
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
        #region オリジナル画像
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// オリジナル画像初期値
            /// </summary>
            public const BitmapSource? OriginalImage = null;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// オリジナル画像プロパティ名
            /// </summary>
            public const string OriginalImage = "OriginalImage";
        }

        /// <summary>
        /// オリジナル画像保持変数
        /// </summary>
        protected BitmapSource? _OriginalImage = InitializeValues.OriginalImage;

        /// <summary>
        /// オリジナル画像
        /// </summary>
        public BitmapSource? OriginalImage
        {
            get
            {
                return this._OriginalImage;
            }
            set
            {
                BitmapSource? now = this._OriginalImage;
                if (now == value)
                {
                    return;
                }
                this._OriginalImage = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion
        #region オリジナル画像パス
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// オリジナル画像パス初期値
            /// </summary>
            public const string? OriginalImagePath = null;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// オリジナル画像パスプロパティ名
            /// </summary>
            public const string OriginalImagePath = "OriginalImagePath";
        }

        /// <summary>
        /// オリジナル画像パス保持変数
        /// </summary>
        protected string? _OriginalImagePath = InitializeValues.OriginalImagePath;

        /// <summary>
        /// オリジナル画像パス
        /// </summary>
        /// <remarks>
        /// 同じフォルダに切り抜き画像を出力します
        /// </remarks>
        public string? OriginalImagePath
        {
            get
            {
                return this._OriginalImagePath;
            }
            set
            {
                string? now = this._OriginalImagePath;
                if (now == value)
                {
                    return;
                }
                this._OriginalImagePath = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region プレビュー画像
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// プレビュー画像初期値
            /// </summary>
            public const BitmapSource? PreviewImage = null;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// プレビュー画像プロパティ名
            /// </summary>
            public const string PreviewImage = "PreviewImage";
        }

        /// <summary>
        /// プレビュー画像保持変数
        /// </summary>
        protected BitmapSource? _PreviewImage = InitializeValues.PreviewImage;

        /// <summary>
        /// プレビュー画像
        /// </summary>
        /// <remarks>
        /// マトリクスLED横幅にあわせて縮小した画像
        /// </remarks>
        public BitmapSource? PreviewImage
        {
            get
            {
                return this._PreviewImage;
            }
            set
            {
                BitmapSource? now = this._PreviewImage;
                if (now == value)
                {
                    return;
                }
                this._PreviewImage = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion
        #region 移動方向
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 移動方向初期値
            /// </summary>
            public const AnimationMoveDirection MoveDirection = AnimationMoveDirection.Up;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 移動方向プロパティ名
            /// </summary>
            public const string MoveDirection = "MoveDirection";
        }

        /// <summary>
        /// 移動方向保持変数
        /// </summary>
        protected AnimationMoveDirection _MoveDirection = InitializeValues.MoveDirection;

        /// <summary>
        /// 移動方向
        /// </summary>
        /// <remarks>
        /// 自動アニメーションでスクロールする方向
        /// </remarks>
        public AnimationMoveDirection MoveDirection
        {
            get
            {
                return this._MoveDirection;
            }
            set
            {
                AnimationMoveDirection now = this._MoveDirection;
                if (now == value)
                {
                    return;
                }
                this._MoveDirection = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion
        #region 移動速度
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 移動速度初期値
            /// </summary>
            public const int MoveSpeed = 1;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 移動速度プロパティ名
            /// </summary>
            public const string MoveSpeed = "MoveSpeed";
        }

        /// <summary>
        /// 移動速度保持変数
        /// </summary>
        protected int _MoveSpeed = InitializeValues.MoveSpeed;

        /// <summary>
        /// 移動速度
        /// </summary>
        /// <remarks>
        /// 1フレームあたりの移動量をpxで指定
        /// </remarks>
        public int MoveSpeed
        {
            get
            {
                return this._MoveSpeed;
            }
            set
            {
                int now = this._MoveSpeed;
                if (now == value)
                {
                    return;
                }
                this._MoveSpeed = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion
        #region 表示期間(ミリ秒)
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 表示期間(ミリ秒)初期値
            /// </summary>
            public const int DisplayPeriodMillisecond = 50;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 表示期間(ミリ秒)プロパティ名
            /// </summary>
            public const string DisplayPeriodMillisecond = "DisplayPeriodMillisecond";
        }

        /// <summary>
        /// 表示期間(ミリ秒)保持変数
        /// </summary>
        protected int _DisplayPeriodMillisecond = InitializeValues.DisplayPeriodMillisecond;

        /// <summary>
        /// 表示期間(ミリ秒)
        /// </summary>
        /// <remarks>
        /// 秒数*1000の整数を設定する
        /// </remarks>
        public int DisplayPeriodMillisecond
        {
            get
            {
                return this._DisplayPeriodMillisecond;
            }
            set
            {
                int now = this._DisplayPeriodMillisecond;
                if (now == value)
                {
                    return;
                }
                this._DisplayPeriodMillisecond = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region 移動方向選択コマンド
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// 移動方向選択コマンド初期値
            /// </summary>
            public const DelegateCommand? MoveDirectionSelectCommand = null;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// 移動方向選択コマンドプロパティ名
            /// </summary>
            public const string MoveDirectionSelectCommand = "MoveDirectionSelectCommand";
        }

        /// <summary>
        /// 移動方向選択コマンド保持変数
        /// </summary>
        protected DelegateCommand? _MoveDirectionSelectCommand = InitializeValues.MoveDirectionSelectCommand;

        /// <summary>
        /// 移動方向選択コマンド
        /// </summary>
        public DelegateCommand? MoveDirectionSelectCommand
        {
            get
            {
                return this._MoveDirectionSelectCommand;
            }
            set
            {
                DelegateCommand? now = this._MoveDirectionSelectCommand;
                if (now == value)
                {
                    return;
                }
                this._MoveDirectionSelectCommand = value;
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
            public const AnimationClipPageStateKind StatusKind = AnimationClipPageStateKind.UnInitialize;
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
        protected AnimationClipPageStateKind _StatusKind = InitializeValues.StatusKind;

        /// <summary>
        /// 状態区分
        /// </summary>
        public AnimationClipPageStateKind StatusKind
        {
            get
            {
                return this._StatusKind;
            }
            set
            {
                AnimationClipPageStateKind now = this._StatusKind;
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

        //「Documents\ViewModelプロパティ作成テンプレート.xlsx」の「ImageClipPageViewModel」をコピー <<<<< ここまで
    }
}
