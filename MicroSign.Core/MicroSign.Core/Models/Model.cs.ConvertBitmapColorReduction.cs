using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// BitmapSource減色結果
        /// </summary>
        /// <remarks>
        /// 2025.08.12:CS)杉原:パレット処理の流れを変更で追加
        /// </remarks>
        public struct ConvertBitmapColorReductionResult
        {
            /// <summary>
            /// 成功フラグ
            /// </summary>
            public readonly bool IsSuccess;

            /// <summary>
            /// メッセージ
            /// </summary>
            public readonly string? Message;

            /// <summary>
            /// 減色画像
            /// </summary>
            /// <remarks>
            /// 指定画像のBgra32データ
            /// </remarks>
            public readonly BitmapSource? ColorReductionImage;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="isSuccess">成功フラグ</param>
            /// <param name="message">メッセージ</param>
            /// <param name="colorReductionImage">減色画像</param>
            private ConvertBitmapColorReductionResult(bool isSuccess, string? message, BitmapSource? colorReductionImage)
            {
                this.IsSuccess = isSuccess;
                this.Message = message;
                this.ColorReductionImage = colorReductionImage;
            }

            /// <summary>
            ///  変換失敗
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <returns></returns>
            public static ConvertBitmapColorReductionResult Failed(string? message)
            {
                ConvertBitmapColorReductionResult result = new ConvertBitmapColorReductionResult(false, message, null);
                return result;
            }

            /// <summary>
            /// 成功
            /// </summary>
            /// <param name="colorReductionImage">減色画像</param>
            /// <returns></returns>
            public static ConvertBitmapColorReductionResult Success(BitmapSource? colorReductionImage)
            {
                ConvertBitmapColorReductionResult result = new ConvertBitmapColorReductionResult(true, null, colorReductionImage);
                return result;
            }
        }

        /// <summary>
        /// BitmapSource減色
        /// </summary>
        /// <param name="image">減色する画像</param>
        /// <returns>BitmapSource減色結果</returns>
        /// <remarks>
        /// 2025.08.12:CS)杉原:パレット処理の流れを変更で追加
        /// お手軽にGIFで保存して読込することで256色の画像に変換します
        /// https://learn.microsoft.com/ja-jp/dotnet/api/system.windows.media.imaging.gifbitmapencoder.-ctor?view=windowsdesktop-9.0&devlangs=csharp&f1url=%3FappId%3DDev17IDEF1%26l%3DJA-JP%26k%3Dk(System.Windows.Media.Imaging.GifBitmapEncoder.%23ctor)%3Bk(DevLang-csharp)%26rd%3Dtrue
        /// >> 2025.08.13:CS)杉原:FormatConvertedBitmapでDestinationFormatをPixelFormats.Indexed8と
        /// >> 指定する方法を試してみましたが、パレットの指定が必要(=Webセーフカラーなパレットで代用できるが)なことと
        /// >> Freeze()でで以外が発生したので諦めました
        /// </remarks>
        public ConvertBitmapColorReductionResult ConvertBitmapColorReduction(BitmapSource? image)
        {
            //減色する画像の有効判定
            if (image == null)
            {
                //無効の場合は何もせずに終了
                return ConvertBitmapColorReductionResult.Failed("減色する画像が無効");
            }
            else
            {
                //有効の場合は処理続行
            }

            try
            {
                //GifBitmapEncoderを作成する
                GifBitmapEncoder encoder = new GifBitmapEncoder();

                //ビットマップフレームを作成
                BitmapFrame bmpFrame = BitmapFrame.Create(image);

                //GifBitmapEncoderにビットマップフレームを追加
                encoder.Frames.Add(bmpFrame);

                //変換
                using (MemoryStream ms = new MemoryStream())
                {
                    //GifBitmapEncoderをメモリーストリームに保存
                    encoder.Save(ms);

                    //メモリーストリームを先頭に移動
                    ms.Seek(CommonConsts.Index.First, SeekOrigin.Begin);

                    //メモリーストリームからBitmapSourceを生成
                    BitmapImage colorReductionimage = new BitmapImage();

                    // >> https://pierre3.hatenablog.com/entry/2015/10/25/001207
                    // >> BitmapImage.StreamSourceに渡したStreamは解除できない(=nullを渡しても解除できない)ので
                    // >>  Streamをラップし、ラップしたStreamのDispose
                    using (ImageDataStream ids = new ImageDataStream(ms))
                    {
                        colorReductionimage.BeginInit();
                        colorReductionimage.CacheOption = BitmapCacheOption.OnLoad;
                        colorReductionimage.CreateOptions = BitmapCreateOptions.None;
                        colorReductionimage.StreamSource = ids;

                        colorReductionimage.EndInit();
                        colorReductionimage.Freeze();
                    }

                    //終了
                    return ConvertBitmapColorReductionResult.Success(colorReductionimage);
                }
            }
            catch (Exception ex)
            {
                //例外は握りつぶす
                return ConvertBitmapColorReductionResult.Failed(CommonLogger.Warn("減色処理で例外発生", ex));
            }
        }
    }
}
