using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// 定数定義
        /// </summary>
        public static class Consts
        {
            /// <summary>
            /// 比率変換補正値
            /// </summary>
            /// <remarks>
            /// doubleで計算した比率値を切り捨てて整数化するための補正値
            /// できるだけ0に近く、計算精度が落ちないくらいの値にします
            /// </remarks>
            public const double RatioConvertionCorrection = 0.0001;

            /// <summary>
            /// 最大画像データ量
            /// </summary>
            /// <remarks>
            /// とりあえず 1Mbyte に制限する
            ///  >> 2023.10.26:CS)土田:マイコンのメモリ容量にあわせて 4Mbyte に変更
            /// </remarks>
            public const int MaxImageDataSize = 4 * CommonConsts.Values.Size.M;


            //2023.10.15:CS)杉原:画像サイズの確認方法変更 >>>>> ここから
            ///// <summary>
            ///// 画像データ単位
            ///// </summary>
            //public const int ImageDataUnitSize = 16;
            //----------
            /// <summary>
            /// 画像ピクセル辞書
            /// </summary>
            /// <remarks>keyがピクセル数、valueがビット数</remarks>
            public static Dictionary<int, int> ImagePixelSizeDic = new Dictionary<int, int>()
            {
                //1/4 Scan及び1/8CScan用に追加 >>>>> ここから
                {4, 2 },
                {8, 3 },
                //1/4 Scan及び1/8CScan用に追加 <<<<< ここまで
                {16, 4 },
                {32, 5 },
                {64, 6 },
                {128, 7 },
                {256, 8 },
                {512, 9 },
                {1024, 10 },
                {2048, 11 },
                {4096, 12 },
            };
            //2023.10.15:CS)杉原:画像サイズの確認方法変更 <<<<< ここまで
        }
    }
}
