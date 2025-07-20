﻿using System.Text.RegularExpressions;

namespace MicroSign
{
    partial class App
    {
        /// <summary>
        /// アプリケーション定数定義
        /// </summary>
        public static class Consts
        {
            /// <summary>
            /// ファイル関連
            /// </summary>
            public class Files
            {
                /// <summary>
                /// 受け入れ可能なファイル拡張子
                /// </summary>
                public static Regex VaridExtensions = new Regex(@"(\.jpg|\.jpeg|\.png|\.gif)$", RegexOptions.IgnoreCase);

                /// <summary>
                /// デフォルト拡張子
                /// </summary>
                public const string DefaultExt = ".png";

                /// <summary>
                /// フィルター
                /// </summary>
                public const string Filter = "Image(*.png,*.jpg,*.jpeg,*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|すべてのファイル (*.*)|*.*";

                /// <summary>
                /// GIF拡張子
                /// </summary>
                public const string GifExt = ".gif";
                
                /// <summary>
                /// GIFフィルター
                /// </summary>
                public const string GifFilter = "GIF Image(*.gif)|*.gif|すべてのファイル (*.*)|*.*";
            }
        }
    }
}
