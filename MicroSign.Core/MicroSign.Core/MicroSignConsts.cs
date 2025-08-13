using System;

namespace MicroSign.Core
{
    /// <summary>
    /// 定数
    /// </summary>
    public static class MicroSignConsts
    {
        /// <summary>
        /// パス
        /// </summary>
        public static class Path
        {
            /// <summary>
            /// マトリクスLED画像パス
            /// </summary>
            /// <remarks>ESP32のMatrixLedImageSD側のファイル名が「MicroSignImage.bin」で固定なので固定にします</remarks>
            public const string MatrixLedImagePath = @".\Temp\MicroSignImage.bin";

            /// <summary>
            /// マトリクスLEDパネル設定パス
            /// </summary>
            /// <remarks>
            /// ESP32のMatrixLedImageSD側のファイル名が「PanelConfig.bin」で固定なので固定にします
            /// この後SPIFFSに変換するのでDatasフォルダ配下になるように出力します
            /// </remarks>
            public const string MatrixLedPanelConfigPath = @".\Temp\Datas\PanelConfig.bin";

            /// <summary>
            /// SPIFFS生成パス
            /// </summary>
            public const string SPIFFSPath = @".\Temp\SPIFFS.bin";
        }

        /// <summary>
        /// 待ち時間
        /// </summary>
        public static class WaitTimes
        {
            /// <summary>
            /// SPIFFS生成の場合最大5分待つ
            /// </summary>
            public static readonly TimeSpan MKSPIFFS = TimeSpan.FromMinutes(5);

            /// <summary>
            /// ESPTOOLの場合最大5分待つ
            /// </summary>
            public static readonly TimeSpan ESPTOOL = TimeSpan.FromMinutes(5);
        }

        /// <summary>
        /// プロセス終了コード
        /// </summary>
        public static class ExitCodes
        {
            /// <summary>
            /// プロセス正常終了
            /// </summary>
            public const int Success = 0;
        }

        /// <summary>
        /// 表示期間
        /// </summary>
        public static class DisplayPeriods
        {
            /// <summary>
            /// 最小値
            /// </summary>
            public const int Min = UInt16.MinValue;

            /// <summary>
            /// 最大値
            /// </summary>
            /// <remarks>データサイズの都合でuint16で表現できる時間までにする</remarks>
            public const int Max = UInt16.MaxValue;
        }

        /// <summary>
        /// RGB
        /// </summary>
        public static class RGB
        {
            /// <summary>
            /// 黒色
            /// </summary>
            public const int Black = 0;

            /// <summary>
            /// 0-3の2ビット色
            /// </summary>
            public const int Bit2 = 2;

            /// <summary>
            /// 0-7の3ビット色
            /// </summary>
            public const int Bit3 = 3;

            /// <summary>
            /// 0-255の8ビット色
            /// </summary>
            public const int Bit8 = 8;

            /// <summary>
            /// 64色カラー変換メンバー名
            /// </summary>
            public const string Color64MemberName = "Data64";

            /// <summary>
            /// 256色カラー変換メンバー名
            /// </summary>
            public const string Color256MemberName = "Data256";

            /// <summary>
            /// インデックスカラー変換メンバー名
            /// </summary>
            public const string IndexColorMemberName = "DataIndex";

            /// <summary>
            /// インデックスカラー最大色数
            /// </summary>
            public const int MaxIndexColorCount = 256;

            /// <summary>
            /// 明るさ
            /// </summary>
            public static class Brightness
            {
                /// <summary>
                /// 明るさ最小値
                /// </summary>
                public const int Min = 0;

                /// <summary>
                /// 明るさ最大値(255)
                /// </summary>
                public const int Max255 = 255;
            }
        }

        public static class MatrixLed
        {
            /// <summary>
            /// HUB75
            /// </summary>
            public static class HUB75
            {
                /// <summary>
                /// 行アドレスサイズ
                /// </summary>
                /// <remarks>
                /// A,B,C,Dの4ビットなので0～15の16行です
                /// </remarks>
                public const int RowSize = 16;

                /// <summary>
                /// 行のパックサイズ
                /// </summary>
                /// <remarks>
                /// 上段と下段の2行
                /// </remarks>
                public const int RowPackSize = 2;
            }

            /// <summary>
            /// HUB75 EX
            /// </summary>
            public static class HUB75_EX
            {
                /// <summary>
                /// 行アドレスサイズ
                /// </summary>
                /// <remarks>
                /// A,B,C,D,Eの5ビットなので0～31の32行です
                /// </remarks>
                public const int RowSize = 32;

                /// <summary>
                /// 行のパックサイズ
                /// </summary>
                /// <remarks>
                /// 上段と下段の2行
                /// </remarks>
                public const int RowPackSize = 2;
            }

        }

        /// <summary>
        /// バージョン
        /// </summary>
        public static class Versions
        {
            /// <summary>
            /// version 1.0.0
            /// </summary>
            public const int V100 = 100;

            /// <summary>
            /// version 1.1.0
            /// </summary>
            public const int V110 = 110;
        }

        /// <summary>
        /// ファイル出力時のデータ
        /// </summary>
        public static class FileData
        {
            /// <summary>
            /// 空き
            /// </summary>
            public static readonly int Reserve = 0;
        }

        /// <summary>
        /// アニメーション
        /// </summary>
        public static class Animations
        {
            /// <summary>
            /// セルサイズ
            /// </summary>
            public static class CellSize
            {
                /// <summary>
                /// サイズ固定セル(+0=X, +1=Y, +2=表示期間 =3)
                /// </summary>
                public const int FixedSize = 3;
            }
        }
    }
}
