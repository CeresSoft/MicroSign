using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                //受け入れ可能なファイル拡張子
                public static Regex VaridExtensions = new Regex(@"(\.jpg|\.jpeg|\.png|\.gif)$", RegexOptions.IgnoreCase);
            }
        }
    }
}
