using System.Text.RegularExpressions;
using System.Windows;

namespace MicroSign.Core.ValueConverters
{
    /// <summary>
    /// 値変換定数定義
    /// </summary>
    public static class ValueConverterConsts
    {
        /// <summary>
        /// 非表示の名前
        /// </summary>
        public static readonly string HIDDEN_TEXT = Visibility.Hidden.ToString();

        /// <summary>
        /// 右辺デフォルト値 - Double
        /// </summary>
        public const double DEFAULT_RIGHT_VALUE_D = 0;

        /// <summary>
        /// 右辺デフォルト値 - Int
        /// </summary>
        public const int DEFAULT_RIGHT_VALUE_I = 0;

        /// <summary>
        /// 透明度
        /// </summary>
        public static class Opacitys
        {
            /// <summary>
            /// 表示状態の透明度
            /// </summary>
            public const double Show = 1.0;

            /// <summary>
            /// 非表示の透明度
            /// </summary>
            public const double Hide = 0.0;
        }

        /// <summary>
        /// 表示変換式
        /// </summary>
        /// <remarks>
        /// フォーマットの区切りをカンマとしていたがXAMLのConverterParameterで使えない(=XAMLのBindingの区切りとして認識されてしまう)ので「|」で分解
        /// >> 2020.10.02:CS)杉原:フォーマットでイコールをつかったが、XAMLのConverterParameterで「=」も使えないので
        /// >> イコールの代わりにHTMLのStyleのようにコロンを使うようにしました
        /// >> またフォーマットの区切りを「|」にしましたが、HTMLのStyle風に「;」を使うようにしました
        /// </remarks>
        public static class VisibilityConversion
        {
            /// <summary>
            /// 比較値キー
            /// </summary>
            public const string KEY_TEST = "TEST";

            /// <summary>
            /// 比較値区切り
            /// </summary>
            public const string KEY_MARK = "MARK";

            /// <summary>
            /// 表示キー
            /// </summary>
            public const string KEY_VISIBLE = "VISIBLE";

            /// <summary>
            /// フォーマット
            /// </summary>
            /// <remarks>
            /// </remarks>
            public static readonly Regex FORMAT = new Regex(@"^(\s*(?<TEST>[^:]*?)\s*(?<MARK>:?))?\s*(?<VISIBLE>(Visible|Collapsed|Hidden)?)\s*$", RegexOptions.IgnoreCase);

            /// <summary>
            /// 変換式区切り
            /// </summary>
            public const char SEPARETOR = ';';

        }
    }
}
