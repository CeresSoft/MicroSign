using MicroSign.Core.ViewModels;

namespace MicroSign.Core.Navigations.ViewModels
{
    /// <summary>
    /// OK/キャンセルナビゲーションViewModel
    /// </summary>
    partial class OkCancelNavigationViewModelBase
    {
        //「Documents\ViewModelプロパティ作成テンプレート.xlsx」の「AnimationTextPageViewModel」をコピー >>>>> ここから
        #region タイトル
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// タイトル初期値
            /// </summary>
            public const string? Title = null;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// タイトルプロパティ名
            /// </summary>
            public const string Title = "Title";
        }

        /// <summary>
        /// タイトル保持変数
        /// </summary>
        protected string? _Title = InitializeValues.Title;

        /// <summary>
        /// タイトル
        /// </summary>
        public string? Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                string? now = this._Title;
                if (now == value)
                {
                    return;
                }
                this._Title = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region メッセージ
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// メッセージ初期値
            /// </summary>
            public const string? Message = null;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// メッセージプロパティ名
            /// </summary>
            public const string Message = "Message";
        }

        /// <summary>
        /// メッセージ保持変数
        /// </summary>
        protected string? _Message = InitializeValues.Message;

        /// <summary>
        /// メッセージ
        /// </summary>
        public string? Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                string? now = this._Message;
                if (now == value)
                {
                    return;
                }
                this._Message = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region OKテキスト
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// OKテキスト初期値
            /// </summary>
            public const string? OkText = "OK";
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// OKテキストプロパティ名
            /// </summary>
            public const string OkText = "OkText";
        }

        /// <summary>
        /// OKテキスト保持変数
        /// </summary>
        protected string? _OkText = InitializeValues.OkText;

        /// <summary>
        /// OKテキスト
        /// </summary>
        public string? OkText
        {
            get
            {
                return this._OkText;
            }
            set
            {
                string? now = this._OkText;
                if (now == value)
                {
                    return;
                }
                this._OkText = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region キャンセルテキスト
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// キャンセルテキスト初期値
            /// </summary>
            public const string? CancelText = "キャンセル";
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// キャンセルテキストプロパティ名
            /// </summary>
            public const string CancelText = "CancelText";
        }

        /// <summary>
        /// キャンセルテキスト保持変数
        /// </summary>
        protected string? _CancelText = InitializeValues.CancelText;

        /// <summary>
        /// キャンセルテキスト
        /// </summary>
        public string? CancelText
        {
            get
            {
                return this._CancelText;
            }
            set
            {
                string? now = this._CancelText;
                if (now == value)
                {
                    return;
                }
                this._CancelText = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region OKコマンド
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// OKコマンド初期値
            /// </summary>
            public const DelegateCommand? OkCommand = null;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// OKコマンドプロパティ名
            /// </summary>
            public const string OkCommand = "OkCommand";
        }

        /// <summary>
        /// OKコマンド保持変数
        /// </summary>
        protected DelegateCommand? _OkCommand = InitializeValues.OkCommand;

        /// <summary>
        /// OKコマンド
        /// </summary>
        public DelegateCommand? OkCommand
        {
            get
            {
                return this._OkCommand;
            }
            set
            {
                DelegateCommand? now = this._OkCommand;
                if (now == value)
                {
                    return;
                }
                this._OkCommand = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        #region キャンセルコマンド
        /// <summary>
        /// 初期値
        /// </summary>
        public static new partial class InitializeValues
        {
            /// <summary>
            /// キャンセルコマンド初期値
            /// </summary>
            public const DelegateCommand? CancelCommand = null;
        }

        /// <summary>
        /// プロパティ名
        /// </summary>
        public static new partial class PropertyNames
        {
            /// <summary>
            /// キャンセルコマンドプロパティ名
            /// </summary>
            public const string CancelCommand = "CancelCommand";
        }

        /// <summary>
        /// キャンセルコマンド保持変数
        /// </summary>
        protected DelegateCommand? _CancelCommand = InitializeValues.CancelCommand;

        /// <summary>
        /// キャンセルコマンド
        /// </summary>
        public DelegateCommand? CancelCommand
        {
            get
            {
                return this._CancelCommand;
            }
            set
            {
                DelegateCommand? now = this._CancelCommand;
                if (now == value)
                {
                    return;
                }
                this._CancelCommand = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        //「Documents\ViewModelプロパティ作成テンプレート.xlsx」の「AnimationTextPageViewModel」をコピー <<<<< ここまで
    }
}
