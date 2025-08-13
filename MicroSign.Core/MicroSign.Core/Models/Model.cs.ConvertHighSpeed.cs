using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
        ///// <summary>
        ///// 高速変換
        ///// </summary>
        ///// <param name="image">画像</param>
        ///// <param name="name">クラス名</param>
        ///// <param name="redThreshold">赤閾値</param>
        ///// <param name="greenThreshold">緑閾値</param>
        ///// <param name="blueThreshold">青閾値</param>
        ///// <param name="matrixLedWidth">マトリクスLED横ドット数</param>
        ///// <param name="matrixLedHeight">マトリクスLED縦ドット数</param>
        ///// <param name="matrixLedBrightness">マトリクスLED明るさ</param>
        ///// <returns></returns>
        //private ConvertResult ConvertHighSpeed(BitmapSource? image, string? name, int redThreshold, int greenThreshold, int blueThreshold, int matrixLedWidth, int matrixLedHeight, int matrixLedBrightness)
        //{
        //    //画像有効判定
        //    if (image == null)
        //    {
        //        //画像無しは失敗
        //        return ConvertResult.Failed("変換画像無し");
        //    }
        //    else
        //    {
        //        //画像有りの場合は処理続行
        //    }
        //
        //    //クラス名有効判定
        //    {
        //        bool isNull = string.IsNullOrEmpty(name);
        //        if(isNull)
        //        {
        //            //クラス名が無効の場合は失敗
        //            return ConvertResult.Failed("クラス名無効");
        //        }
        //        else
        //        {
        //            //クラス名が有効の場合は処理続行
        //        }
        //    }
        //
        //    //画像サイズを確認
        //    {
        //        //横幅
        //        {
        //            int imageWidth = image.PixelWidth;
        //            int requiredWidth = matrixLedWidth;
        //            if (imageWidth == requiredWidth)
        //            {
        //                //規定サイズの場合は処理続行
        //            }
        //            else
        //            {
        //                //異なる場合は終了
        //                return ConvertResult.Failed($"画像横幅が{requiredWidth}pxではありません");
        //            }
        //        }
        //
        //        //縦幅
        //        {
        //            int imageHeight = image.PixelHeight;
        //            int requiredHeight = matrixLedHeight;
        //            if (imageHeight == requiredHeight)
        //            {
        //                //規定サイズの場合は処理続行
        //            }
        //            else
        //            {
        //                //異なる場合は終了
        //                return ConvertResult.Failed($"画像縦幅が{requiredHeight}pxではありません");
        //            }
        //        }
        //    }
        //
        //    //画像フォーマットを変換
        //    // >> https://learn.microsoft.com/ja-jp/dotnet/desktop/wpf/graphics-multimedia/how-to-convert-a-bitmapsource-to-a-different-pixelformat?view=netframeworkdesktop-4.8&viewFallbackFrom=netdesktop-6.0
        //    FormatConvertedBitmap newFormatedBitmapSource = new FormatConvertedBitmap();
        //    newFormatedBitmapSource.BeginInit();
        //    newFormatedBitmapSource.Source = image;
        //    newFormatedBitmapSource.DestinationFormat = PixelFormats.Bgra32;
        //    newFormatedBitmapSource.EndInit();
        //    newFormatedBitmapSource.Freeze();
        //
        //    //1ピクセルのバイト数
        //    // >> RGBA 32bit固定の書き方 32/8=4になります
        //    // >> ほかのピクセルフォーマットに対応する場合はここのコードを変更してください
        //    int byteParPixel = newFormatedBitmapSource.DestinationFormat.BitsPerPixel / CommonConsts.BitCount.BYTE;
        //
        //    //画像ピクセル取得
        //    int imagePixelWidth = newFormatedBitmapSource.PixelWidth;
        //    int imagePixelHeight = newFormatedBitmapSource.PixelHeight;
        //    int imagePixelStride = imagePixelWidth * byteParPixel;
        //
        //    //画像取得
        //    int bgra32Size = imagePixelStride * imagePixelHeight;
        //    byte[] bgra32 = new byte[bgra32Size];
        //    newFormatedBitmapSource.CopyPixels(bgra32, imagePixelStride, CommonConsts.Index.First);
        //
        //    //変換後の画像生成先
        //    byte[] convertImage = new byte[bgra32Size];
        //
        //    //データのX座標はそのままのサイズ
        //    int dataWidth = imagePixelWidth;
        //
        //    // データのY座標は上段(0～31行目R1,G1,B1)と下段(32～63行目R2,G2,B2)の2ピクセルを1byteにするので半分にします
        //    // >> バイト内のフォーマット(FM6126Aサンプルコードに合わせました)
        //    // >> bit    7, 6, 5, 4, 3, 2, 1, 0
        //    // >> Color B2,G2,R2,B1,G1,R1 ,0 ,0
        //    int dataHeight = imagePixelHeight / MicroSignConsts.MatrixLed.HUB75.RowPackSize;
        //
        //    //画像データを変換
        //    StringBuilder sb = new StringBuilder(CommonConsts.Text.STRING_BUILDER_CAPACITY);
        //
        //    //クラス
        //    {
        //        sb.Append("//画像データのフォーマットの定義").AppendLine();
        //        sb.Append("#define ImageFormat_HIGH_SPEED").AppendLine();
        //        sb.AppendLine();
        //        sb.Append("//IoTImageConverterで変換した画像").AppendLine();
        //        sb.Append("class ").Append(name).AppendLine();
        //        sb.Append("{").AppendLine();
        //        sb.Append("\tpublic:").AppendLine();
        //
        //        sb.Append("\t\t/// @brief マトリクスLED - 横ドット数").AppendLine();
        //        sb.Append("\t\tconst static uint16_t MatrixLedWidth = ").Append(matrixLedWidth).Append(";").AppendLine();
        //        sb.AppendLine();
        //        sb.Append("\t\t/// @brief マトリクスLED - 縦ドット数").AppendLine();
        //        sb.Append("\t\tconst static uint16_t MatrixLedHeight = ").Append(matrixLedHeight).Append(";").AppendLine();
        //        sb.AppendLine();
        //        sb.Append("\t\t/// @brief マトリクスLED 明るさ").AppendLine();
        //        sb.Append("\t\tconst static uint16_t MatrixLedBrightness = ").Append(matrixLedBrightness).Append(";").AppendLine();
        //
        //        sb.AppendLine();
        //
        //        sb.Append("\t\t/// @brief 画像 - 横ピクセル数").AppendLine();
        //        sb.Append("\t\tconst static uint16_t ImageWidthPixels = ").Append(imagePixelWidth).Append(";").AppendLine();
        //        sb.AppendLine();
        //        sb.Append("\t\t/// @brief 画像 - 縦ピクセル数").AppendLine();
        //        sb.Append("\t\tconst static uint16_t ImageHeightPixels = ").Append(imagePixelHeight).Append(";").AppendLine();
        //
        //        sb.AppendLine();
        //
        //        sb.Append("\t\t/// @brief 画像データ - 横サイズ").AppendLine();
        //        sb.Append("\t\tconst static uint16_t DataWidth = ").Append(dataWidth).Append(";").AppendLine();
        //        sb.AppendLine();
        //        sb.Append("\t\t/// @brief 画像データ - 縦サイズ").AppendLine();
        //        sb.Append("\t\tconst static uint16_t DataHeight = ").Append(dataHeight).Append(";").AppendLine();
        //        sb.AppendLine();
        //
        //        sb.Append("\t\t//pgm_read_byte()を使うので1次元の配列にします").AppendLine();
        //        sb.Append("\t\tconst static PROGMEM uint8_t HighSpeedData[").Append(dataHeight).Append(" * ").Append(dataWidth).Append("];").AppendLine();
        //        //クラスの最後
        //        sb.Append("};").AppendLine();
        //    }
        //
        //    //配列の先頭
        //    sb.Append("const static PROGMEM uint8_t ").Append(name).Append("::HighSpeedData[").Append(dataHeight).Append(" * ").Append(dataWidth).Append("] = {").AppendLine();
        //
        //    //Y座標ループ
        //    for (int y = CommonConsts.Index.First; y < dataHeight; y += CommonConsts.Index.Step)
        //    {
        //        if (CommonConsts.Index.First < y)
        //        {
        //            //最初の行ではない場合
        //            sb.Append("\t,");
        //        }
        //        else
        //        {
        //            //最初の行の場合
        //            sb.Append("\t");
        //        }
        //
        //        //X軸ループ
        //        for (int x = CommonConsts.Index.First; x < dataWidth; x += CommonConsts.Index.Step)
        //        {
        //            //合成値
        //            int value = CommonConsts.Values.Zero.I;
        //
        //            //上段
        //            {
        //                //インデックス計算
        //                int index = (y * imagePixelStride) + (x * byteParPixel);
        //                int blueIndex = index;
        //                int greenIndex = blueIndex + CommonConsts.Index.Step;
        //                int redIndex = greenIndex + CommonConsts.Index.Step;
        //                int alphaIndex = redIndex + CommonConsts.Index.Step;
        //
        //                //点灯か消灯を決める
        //                int alphaValue = bgra32[alphaIndex];
        //
        //                int B1 = this.TestThreshold(bgra32[blueIndex], alphaValue, blueThreshold, (byte)(1 << 4));
        //                int G1 = this.TestThreshold(bgra32[greenIndex], alphaValue, greenThreshold, (byte)(1 << 3));
        //                int R1 = this.TestThreshold(bgra32[redIndex], alphaValue, redThreshold, (byte)(1 << 2));
        //
        //                //データに合成
        //                value |= B1;
        //                value |= G1;
        //                value |= R1;
        //
        //                //変換後の画像に反映
        //                if (CommonConsts.Values.Zero.I < B1)
        //                {
        //                    convertImage[blueIndex] = MicroSignConsts.RGB.Brightness.Max255;
        //                }
        //                else
        //                {
        //                    convertImage[blueIndex] = MicroSignConsts.RGB.Brightness.Min;
        //                }
        //                if (CommonConsts.Values.Zero.I < G1)
        //                {
        //                    convertImage[greenIndex] = MicroSignConsts.RGB.Brightness.Max255;
        //                }
        //                else
        //                {
        //                    convertImage[greenIndex] = MicroSignConsts.RGB.Brightness.Min;
        //                }
        //                if (CommonConsts.Values.Zero.I < R1)
        //                {
        //                    convertImage[redIndex] = MicroSignConsts.RGB.Brightness.Max255;
        //                }
        //                else
        //                {
        //                    convertImage[redIndex] = MicroSignConsts.RGB.Brightness.Min;
        //                }
        //                convertImage[alphaIndex] = MicroSignConsts.RGB.Brightness.Max255;
        //            }
        //
        //            //下段
        //            {
        //                //インデックス計算
        //                int index = ((y + dataHeight) * imagePixelStride) + (x * byteParPixel);
        //                int blueIndex = index;
        //                int greenIndex = blueIndex + CommonConsts.Index.Step;
        //                int redIndex = greenIndex + CommonConsts.Index.Step;
        //                int alphaIndex = redIndex + CommonConsts.Index.Step;
        //
        //                //点灯か消灯を決める
        //                int alphaValue = bgra32[alphaIndex];
        //                int B2 = this.TestThreshold(bgra32[blueIndex], alphaValue, blueThreshold, (byte)(1 << 7));
        //                int G2 = this.TestThreshold(bgra32[greenIndex], alphaValue, greenThreshold, (byte)(1 << 6));
        //                int R2 = this.TestThreshold(bgra32[redIndex], alphaValue, redThreshold, (byte)(1 << 5));
        //
        //                //データに合成
        //                value |= B2;
        //                value |= G2;
        //                value |= R2;
        //
        //                //変換後の画像に反映
        //                if (CommonConsts.Values.Zero.I < B2)
        //                {
        //                    convertImage[blueIndex] = MicroSignConsts.RGB.Brightness.Max255;
        //                }
        //                else
        //                {
        //                    convertImage[blueIndex] = MicroSignConsts.RGB.Brightness.Min;
        //                }
        //                if (CommonConsts.Values.Zero.I < G2)
        //                {
        //                    convertImage[greenIndex] = MicroSignConsts.RGB.Brightness.Max255;
        //                }
        //                else
        //                {
        //                    convertImage[greenIndex] = MicroSignConsts.RGB.Brightness.Min;
        //                }
        //                if (CommonConsts.Values.Zero.I < R2)
        //                {
        //                    convertImage[redIndex] = MicroSignConsts.RGB.Brightness.Max255;
        //                }
        //                else
        //                {
        //                    convertImage[redIndex] = MicroSignConsts.RGB.Brightness.Min;
        //                }
        //                convertImage[alphaIndex] = MicroSignConsts.RGB.Brightness.Max255;
        //            }
        //
        //            //書込み
        //            if (CommonConsts.Index.First < x)
        //            {
        //                //最初の列ではない場合
        //                sb.Append(",\t");
        //            }
        //            else
        //            {
        //                //最初の行の場合
        //            }
        //            sb.Append("0x").Append(value.ToString("X2"));
        //        }
        //
        //        sb.Append("\t//Line").Append(y).AppendLine();
        //    }
        //
        //    //配列の最後
        //    sb.Append("};").AppendLine();
        //
        //    //画像を設定
        //    WriteableBitmap convertBitmap = new WriteableBitmap(imagePixelWidth, imagePixelHeight, 75, 75, PixelFormats.Bgra32, null);
        //    convertBitmap.WritePixels(new Int32Rect(0, 0, imagePixelWidth, imagePixelHeight), convertImage, imagePixelStride, CommonConsts.Index.First);
        //
        //    //終了
        //    return ConvertResult.Sucess(convertBitmap, sb.ToString());
        //}
        //----------
        // >> 不要な関数を削除
        //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで
    }
}
