using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// 画像サイズ検証結果
        /// </summary>
        public struct ValidateImageSizeResult
        {
            /// <summary>
            /// 有効
            /// </summary>
            public readonly bool IsValid;

            /// <summary>
            /// 画像横ビット数
            /// </summary>
            public readonly int ImageWidthBits;

            /// <summary>
            /// 画像縦ビット数
            /// </summary>
            public readonly int ImageHeightBits;

            /// <summary>
            /// エラーメッセージ
            /// </summary>
            public readonly string ErrorMessage;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="isValid"></param>
            /// <param name="imageWidthBits"></param>
            /// <param name="imageHeightBits"></param>
            /// <param name="errorMessage"></param>
            private ValidateImageSizeResult(bool isValid, int imageWidthBits, int imageHeightBits, string errorMessage)
            {
                this.IsValid = isValid;
                this.ImageWidthBits = imageWidthBits;
                this.ImageHeightBits = imageHeightBits;
                this.ErrorMessage = errorMessage;
            }

            /// <summary>
            /// 無効
            /// </summary>
            /// <returns></returns>
            /// <param name="errorMessage"></param>
            public static ValidateImageSizeResult Invalid(string errorMessage)
            {
                ValidateImageSizeResult result = new ValidateImageSizeResult(false, CommonConsts.Values.Zero.I, CommonConsts.Values.Zero.I, errorMessage);
                return result;
            }

            /// <summary>
            /// 有効
            /// </summary>
            /// <param name="imageWidthBits"></param>
            /// <param name="imageHeightBits"></param>
            /// <returns></returns>
            public static ValidateImageSizeResult Valid(int imageWidthBits, int imageHeightBits)
            {
                ValidateImageSizeResult result = new ValidateImageSizeResult(true, imageWidthBits, imageHeightBits, "Valid");
                return result;
            }
        }

        /// <summary>
        /// 画像サイズ検証
        /// </summary>
        /// <param name="imagePixelWidth">画像横ピクセル数</param>
        /// <param name="imagePixelHeight">画像縦ピクセル数</param>
        /// <returns></returns>
        public ValidateImageSizeResult ValidateImageSize(int imagePixelWidth, int imagePixelHeight)
        {

            //2023.10.15:CS)杉原:画像サイズの確認方法変更 >>>>> ここから
            ////画像サイズを確認
            //{
            //    // >> 横幅
            //    {
            //        if (CommonConsts.Values.Zero.I < imagePixelWidth)
            //        {
            //            //1以上なら続行
            //        }
            //        else
            //        {
            //            //0以下は無効
            //            return ValidateImageResult.Invalid($"画像横幅が無効です");
            //        }
            //
            //        int mod = imagePixelWidth % Model.Consts.ImageDataUnitSize;
            //        if (mod == CommonConsts.Values.Zero.I)
            //        {
            //            //データ単位に揃っていれば続行
            //        }
            //        else
            //        {
            //            //中途半端な幅の場合は無効
            //            return ValidateImageResult.Invalid($"画像横幅が{Model.Consts.ImageDataUnitSize}px単位ではありません");
            //        }
            //    }
            //
            //    //縦幅
            //    {
            //        if (CommonConsts.Values.Zero.I < imagePixelHeight)
            //        {
            //            //1以上なら続行
            //        }
            //        else
            //        {
            //            //0以下は無効
            //            return ValidateImageResult.Invalid($"画像縦幅が無効です");
            //        }
            //
            //        int mod = imagePixelHeight % Model.Consts.ImageDataUnitSize;
            //        if (mod == CommonConsts.Values.Zero.I)
            //        {
            //            //データ単位に揃っていれば続行
            //        }
            //        else
            //        {
            //            //中途半端な幅の場合は無効
            //            return ValidateImageResult.Invalid($"画像縦幅が{Model.Consts.ImageDataUnitSize}px単位ではありません");
            //        }
            //    }
            //}
            //
            ////画像ピクセルからビット数取得
            //int imageWidthBits = this.CalcPixelBits((uint)imagePixelWidth);
            //int ImageHeightBits = this.CalcPixelBits((uint)imagePixelHeight);
            //----------
            //縦幅
            int imageWidthBits = CommonConsts.Values.Zero.I;
            {
                //keyがピクセル数、valueがビット数の辞書を引く
                bool ret = Model.Consts.ImagePixelSizeDic.TryGetValue(imagePixelWidth, out imageWidthBits);
                if (ret)
                {
                    //取得できた場合は処理続行
                }
                else
                {
                    //取得出来なかった場合は異常
                    string pxs = string.Join(", ", Model.Consts.ImagePixelSizeDic.Keys.OrderBy(x => x));
                    return ValidateImageSizeResult.Invalid($"画像横幅が無効です。{pxs}pixelにしてください");
                }
            }

            //縦幅
            int imageHeightBits = CommonConsts.Values.Zero.I;
            {
                //keyがピクセル数、valueがビット数の辞書を引く
                bool ret = Model.Consts.ImagePixelSizeDic.TryGetValue(imagePixelHeight, out imageHeightBits);
                if (ret)
                {
                    //取得できた場合は処理続行
                }
                else
                {
                    //取得出来なかった場合は異常
                    string pxs = string.Join(", ", Model.Consts.ImagePixelSizeDic.Keys.OrderBy(x => x));
                    return ValidateImageSizeResult.Invalid($"画像縦幅が無効です。{pxs}pixelにしてください");
                }
            }
            //2023.10.15:CS)杉原:画像サイズの確認方法変更 <<<<< ここまで

            //画像データサイズ確認
            {
                int imageDataSize = imagePixelWidth * imagePixelHeight;
                if( Model.Consts.MaxImageDataSize < imageDataSize)
                {
                    //最大画像データサイズを超える場合は終了
                    return ValidateImageSizeResult.Invalid($"画像データサイズが最大値{Model.Consts.MaxImageDataSize / CommonConsts.Values.Size.M}Mbyteを超えています");
                }
                else
                {
                    //最大画像データサイズ以内の場合は続行
                }
            }

            //終了
            return ValidateImageSizeResult.Valid(imageWidthBits, imageHeightBits);
        }

        //2023.10.15:CS)杉原:画像サイズの確認方法変更 >>>>> ここから
        ///// <summary>
        ///// ピクセルビット数を計算
        ///// </summary>
        ///// <param name="val"></param>
        ///// <returns></returns>
        //private int CalcPixelBits(uint val)
        //{
        //    //最上位ビットの位置を調整する
        //    // >> 2の累乗数の場合
        //    // >> >>   256
        //    //       = 0b_0001_0000_0000
        //    // >> >> 1を引くと最上位ビットがずれる
        //    // >> >> 255を表現できればよいので、これでOK
        //    // >> >>   256 - 1
        //    //       = 255
        //    //       = 0b_0000_1111_1111
        //    // >> 非累乗数の場合
        //    // >> >>   100
        //    //       = 0b_0000_0110_0011
        //    // >> >> 1を引いても最上位ビットは動かない
        //    // >> >> 127が表現できればよいので、0b_0000_0111_1111と最上位ビット位置が同じでOK
        //    // >> >>   100 - 1
        //    //       = 99
        //    //       = 0b_0000_0110_0011
        //    uint bitTemp = val - CommonConsts.Values.One.I;
        //
        //    //計算結果
        //    int bits = CommonConsts.Values.Zero.I;
        //
        //    //1bitずつシフトして、0になるまでにシフトした回数が必要なビット数
        //    // >> 2の累乗数の場合
        //    // >> >>     0b_1111_1111
        //    // >> >> [1] 0b_0111_1111
        //    // >> >> [2] 0b_0011_1111
        //    // >> >> …
        //    // >> >> [7] 0b_0000_0001
        //    // >> >> [8] 0b_0000_0000 -> 8bit
        //    // >> 非累乗数の場合
        //    // >> >>     0b_0110_0011
        //    // >> >> [1] 0b_0011_0001
        //    // >> >> [2] 0b_0001_1000
        //    // >> >> …
        //    // >> >> [6] 0b_0000_0001
        //    // >> >> [7] 0b_0000_0000 -> 7bit
        //    // >> 0の場合、1回もシフトしないので0bitとなるが、そもそも無効な数なのでガードしなくてもよい
        //    while (CommonConsts.Values.Zero.I < bitTemp)
        //    {
        //        bitTemp >>= CommonConsts.Values.One.I;
        //        bits += CommonConsts.Values.One.I;
        //    }
        //
        //    return bits;
        //}
        //----------
        //2023.10.15:CS)杉原:画像サイズの確認方法変更 <<<<< ここまで

    }
}
