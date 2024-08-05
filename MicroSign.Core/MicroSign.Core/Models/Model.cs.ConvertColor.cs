using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MicroSign.Core.Models.AnimationDatas;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// 色変換
        /// </summary>
        /// <param name="formatKind">出力色形式</param>
        /// <param name="image">入力画像
        /// 画像ファイル(BitmapImage)とテスト画像(WriteableBitmap)を受け入れるため、基底クラス(BitmapSource)にする</param>
        /// <param name="name">画像データクラス名</param>
        /// <param name="memberName">画像データメンバー名</param>
        /// <param name="redBits">Rビット数</param>
        /// <param name="greenBits">Gビット数</param>
        /// <param name="blueBits">Bビット数</param>
        /// <param name="matrixLedWidth">マトリクスLED横ドット数</param>
        /// <param name="matrixLedHeight">マトリクスLED縦ドット数</param>
        /// <param name="matrixLedBrightness">マトリクスLED明るさ</param>
        /// <returns></returns>
        private ConvertResult ConvertColor(OutputColorFormatKind formatKind, BitmapSource? image, string? name, string? memberName, int redBits, int greenBits, int blueBits, int matrixLedWidth, int matrixLedHeight, int matrixLedBrightness)
        {
            //アニメーションデータが1つのインスタンスを生成
            AnimationDataCollection animationDatas = new AnimationDataCollection();
            animationDatas.AddAnimation((int)CommonConsts.Points.Zero.X, (int)CommonConsts.Points.Zero.Y, MicroSignConsts.DisplayPeriods.Min);

            return this.ConvertColor(formatKind, image, name, memberName, redBits, greenBits, blueBits, animationDatas, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
        }

        /// <summary>
        /// 色変換
        /// </summary>
        /// <param name="formatKind">出力色形式(64色か256色)</param>
        /// <param name="image">入力画像。画像ファイル(BitmapImage)とテスト画像(WriteableBitmap)を受け入れるため、基底クラス(BitmapSource)にする</param>
        /// <param name="name">画像データクラス名</param>
        /// <param name="memberName">画像データメンバー名</param>
        /// <param name="redBits">Rビット数</param>
        /// <param name="greenBits">Gビット数</param>
        /// <param name="blueBits">Bビット数</param>
        /// <param name="animationDatas">アニメーションデータコレクション</param>
        /// <param name="matrixLedWidth">マトリクスLED横ドット数</param>
        /// <param name="matrixLedHeight">マトリクスLED縦ドット数</param>
        /// <param name="matrixLedBrightness">マトリクスLED明るさ</param>
        /// <returns></returns>
        private ConvertResult ConvertColor(OutputColorFormatKind formatKind, BitmapSource? image, string? name, string? memberName, int redBits, int greenBits, int blueBits, AnimationDataCollection? animationDatas, int matrixLedWidth, int matrixLedHeight, int matrixLedBrightness)
        {
            //テキスト
            ConvertResult retText = this.ConvertColorText(formatKind, image, name, memberName, redBits, greenBits, blueBits, animationDatas, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
            if (retText.IsSuccess)
            {
                //成功の場合は処理続行
            }
            else
            {
                //失敗の場合は終了
                return retText;
            }

            //ファイル
            ConvertResult retFile = this.ConvertColorFile(formatKind, image, name, memberName, redBits, greenBits, blueBits, animationDatas, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
            if (retText.IsSuccess)
            {
                //成功の場合は処理続行
            }
            else
            {
                //失敗の場合は終了
                return retFile;
            }

            //ここまで来たらすべて成功なのでテキストの結果を返す
            return retText;
        }

        /// <summary>
        /// 色変換テキスト
        /// </summary>
        /// <param name="formatKind">出力色形式(64色か256色)</param>
        /// <param name="image">入力画像。画像ファイル(BitmapImage)とテスト画像(WriteableBitmap)を受け入れるため、基底クラス(BitmapSource)にする</param>
        /// <param name="name">画像データクラス名</param>
        /// <param name="memberName">画像データメンバー名</param>
        /// <param name="redBits">Rビット数</param>
        /// <param name="greenBits">Gビット数</param>
        /// <param name="blueBits">Bビット数</param>
        /// <param name="animationDatas">アニメーションデータコレクション</param>
        /// <param name="matrixLedWidth">マトリクスLED横ドット数</param>
        /// <param name="matrixLedHeight">マトリクスLED縦ドット数</param>
        /// <param name="matrixLedBrightness">マトリクスLED明るさ</param>
        /// <returns></returns>
        private ConvertResult ConvertColorText(OutputColorFormatKind formatKind, BitmapSource? image, string? name, string? memberName, int redBits, int greenBits, int blueBits, AnimationDataCollection? animationDatas, int matrixLedWidth, int matrixLedHeight, int matrixLedBrightness)
        {
            //画像有効判定
            if (image == null)
            {
                //画像無しは失敗
                return ConvertResult.Failed("変換画像無し");
            }
            else
            {
                //画像有りの場合は処理続行
            }

            //クラス名有効判定
            {
                bool isNull = string.IsNullOrEmpty(name);
                if (isNull)
                {
                    //クラス名が無効の場合は失敗
                    return ConvertResult.Failed("クラス名無効");
                }
                else
                {
                    //クラス名が有効の場合は処理続行
                }
            }

            //アニメーションデータ数取得
            int animationDataCount = CommonConsts.Collection.Empty;
            if (animationDatas == null)
            {
                //アニメーションデータ無しは失敗
                return ConvertResult.Failed("アニメーションデータ無効");
            }
            else
            {
                animationDataCount = animationDatas.Count;
                if (CommonConsts.Collection.Empty < animationDataCount)
                {
                    //アニメーションデータ有りの場合は処理続行
                }
                else
                {
                    //アニメーションデータ無しは失敗
                    return ConvertResult.Failed("アニメーションデータ無し");
                }
            }

            //画像ピクセル取得
            // >> 検証済の値を取得
            int imagePixelWidth = image.PixelWidth;
            int imagePixelHeight = image.PixelHeight;

            //画像サイズ検証
            ValidateImageSizeResult validateRet = this.ValidateImageSize(imagePixelWidth, imagePixelHeight);
            if (validateRet.IsValid)
            {
                //検証OKの場合は続行
            }
            else
            {
                //検証NGの場合は終了
                return ConvertResult.Failed(validateRet.ErrorMessage);
            }

            //画像ビット数取得
            // >> 検証済の値を取得
            int imageWidthBits = validateRet.ImageWidthBits;
            int imageHeightBits = validateRet.ImageHeightBits;

            //画像データを変換
            byte[]? outputData = null;
            byte[]? outputImage = null;
            int outputImageStride = CommonConsts.Collection.Empty;
            {
                //画像データを出力データに変換
                var convertColorImplResult = this.ConvertColorImpl(image, redBits, greenBits, blueBits);
                if (convertColorImplResult.IsSuccess)
                {
                    //成功した場合は処理続行
                }
                else
                {
                    //失敗した場合は終了
                    return ConvertResult.Failed("色変換失敗");
                }

                //出力データ取得
                outputData = convertColorImplResult.OutputData;
                if (outputData == null)
                {
                    //無効の場合は終了
                    return ConvertResult.Failed("出力データ無効");
                }
                else
                {
                    //有効の場合は処理続行
                }

                //出力画像取得
                outputImage = convertColorImplResult.OutputImage;
                if (outputImage == null)
                {
                    //無効の場合は終了
                    return ConvertResult.Failed("出力画像無効");
                }
                else
                {
                    //有効の場合は処理続行
                }

                //出力画像ストライド取得
                outputImageStride = convertColorImplResult.OutputImageStride;
            }

            //画像データを変換
            StringBuilder sb = new StringBuilder(CommonConsts.Text.STRING_BUILDER_CAPACITY);

            //クラス
            {
                sb.Append("//画像データのフォーマットの定義").AppendLine();
                sb.Append("#define IMAGE_DATA_FORMAT_").Append((int)formatKind).AppendLine();
                sb.AppendLine();
                sb.Append("//IoTImageConverterで変換した画像").AppendLine();
                sb.Append("class ").Append(name).AppendLine();
                sb.Append("{").AppendLine();
                sb.Append("\tpublic:").AppendLine();

                sb.Append("\t\t/// @brief マトリクスLED - 横ドット数").AppendLine();
                sb.Append("\t\tconst static uint16_t MatrixLedWidth = ").Append(matrixLedWidth).Append(";").AppendLine();
                sb.AppendLine();
                sb.Append("\t\t/// @brief マトリクスLED - 縦ドット数").AppendLine();
                sb.Append("\t\tconst static uint16_t MatrixLedHeight = ").Append(matrixLedHeight).Append(";").AppendLine();
                sb.AppendLine();
                sb.Append("\t\t/// @brief マトリクスLED 明るさ").AppendLine();
                sb.Append("\t\tconst static uint16_t MatrixLedBrightness = ").Append(matrixLedBrightness).Append(";").AppendLine();

                sb.AppendLine();

                sb.Append("\t\t/// @brief 画像 - 横ピクセル数").AppendLine();
                sb.Append("\t\tconst static uint16_t ImageWidthPixels = ").Append(imagePixelWidth).Append(";").AppendLine();
                sb.AppendLine();
                sb.Append("\t\t/// @brief 画像 - 縦ピクセル数").AppendLine();
                sb.Append("\t\tconst static uint16_t ImageHeightPixels = ").Append(imagePixelHeight).Append(";").AppendLine();
                sb.AppendLine();
                sb.Append("\t\t/// @brief 画像 - 横ビット数").AppendLine();
                sb.Append("\t\tconst static uint16_t ImageWidthBits = ").Append(imageWidthBits).Append(";").AppendLine();
                sb.AppendLine();
                sb.Append("\t\t/// @brief 画像 - 縦ビット数").AppendLine();
                sb.Append("\t\tconst static uint16_t ImageHeightBits = ").Append(imageHeightBits).Append(";").AppendLine();

                sb.AppendLine();

                sb.Append("\t\t/// @brief アニメーション - データ数").AppendLine();
                sb.Append("\t\tconst static uint16_t AnimationDataCount = ").Append(animationDataCount).Append(";").AppendLine();
                sb.AppendLine();
                sb.Append("\t\t/// @brief アニメーション - セルサイズ").AppendLine();
                sb.Append("\t\t/// >> +0=X座標,+1=Y座標,+2=表示(ms)の3つで1データ").AppendLine();
                sb.Append("\t\tconst static uint16_t AnimationCellCount = 3;").AppendLine();

                sb.AppendLine();

                sb.Append("\t\t/// @brief 画像データ (高速化のために1次元配列にします)").AppendLine();
                sb.Append("\t\tconst static PROGMEM uint8_t ").Append(memberName).Append("[").Append(imagePixelHeight).Append(" * ").Append(imagePixelWidth).Append("];").AppendLine();

                sb.AppendLine();

                sb.Append("\t\t/// @brief アニメーションデータ (高速化のために1次元配列にします。+0=X座標,+1=Y座標,+2=表示(ms))").AppendLine();
                sb.Append("\t\tconst static PROGMEM uint16_t AnimationData").Append("[").Append(animationDataCount).Append(" * 3];").AppendLine();

                //クラスの最後
                sb.Append("};").AppendLine();
            }

            //出力データ
            {
                //出力データ配列の先頭
                sb.AppendLine();
                sb.Append("/// @brief 画像データ").AppendLine();
                sb.Append("const PROGMEM uint8_t ").Append(name).Append("::").Append(memberName).Append("[").Append(imagePixelHeight).Append(" * ").Append(imagePixelWidth).Append("] = {").AppendLine();

                //画像データのインデックス
                int i = CommonConsts.Index.First;

                //Y座標ループ
                for (int y = CommonConsts.Index.First; y < imagePixelHeight; y += CommonConsts.Index.Step)
                {
                    if (CommonConsts.Index.First < y)
                    {
                        //最初の行ではない場合
                        sb.Append("\t,");
                    }
                    else
                    {
                        //最初の行の場合
                        sb.Append("\t");
                    }

                    //X軸ループ
                    for (int x = CommonConsts.Index.First; x < imagePixelWidth; x += CommonConsts.Index.Step)
                    {
                        //出力データ取得
                        int margeData = outputData[i];
                        i += CommonConsts.Index.Step;

                        //出力データを書込み
                        if (CommonConsts.Index.First < x)
                        {
                            //最初の列ではない場合
                            sb.Append(",\t");
                        }
                        else
                        {
                            //最初の行の場合
                        }
                        sb.Append("0x").Append(margeData.ToString("X2"));
                    }

                    sb.Append("\t//Line").Append(y).AppendLine();
                }

                //出力データ配列の最後
                sb.Append("};").AppendLine();
            }

            //アニメーションデータ
            {
                //アニメーションデータ配列の先頭
                sb.AppendLine();
                sb.Append("/// @brief アニメーションデータ (高速化のために1次元配列にします。+0=X座標,+1=Y座標,+2=表示(ms))").AppendLine();
                sb.Append("const PROGMEM uint16_t ").Append(name).Append("::AnimationData").Append("[").Append(animationDataCount).Append(" * 3] = {").AppendLine();

                for (int i = CommonConsts.Index.First; i < animationDataCount; i += CommonConsts.Index.Step)
                {
                    //先頭にTABを1つ入れる
                    sb.Append("\t");

                    AnimationData? animationData = animationDatas[i];
                    if (animationData == null)
                    {
                        //無効の場合
                        sb.Append("0, 0, 0, //Index=").Append(i).Append(" [無効] [停止]");
                    }
                    else
                    {
                        //有効の場合
                        int x = animationData.X;
                        int y = animationData.Y;
                        int t = animationData.DisplayPeriodMillisecond;
                        sb.Append(x).Append(", ").Append(y).Append(", ").Append(t).Append(", //Index={i}");
                        if (t == MicroSignConsts.DisplayPeriods.Min)
                        {
                            //表示期間が最低値の場合はアニメーション停止なので停止を追加
                            sb.Append(" [停止]");
                        }
                        else
                        {
                            //それ以外の場合は説明を付ける
                            sb.Append("[X=").Append(x).Append(", Y=").Append(y).Append(" 表示=").Append(t).Append("ms]");
                        }
                    }

                    //改行
                    sb.AppendLine();
                }

                //アニメーションデータ配列の最後
                sb.Append("};").AppendLine();
            }

            //画像を設定
            WriteableBitmap convertBitmap = new WriteableBitmap(imagePixelWidth, imagePixelHeight, CommonConsts.DPIs.DIP, CommonConsts.DPIs.DIP, PixelFormats.Bgra32, null);
            {
                Int32Rect rect = new Int32Rect((int)CommonConsts.Points.Zero.X, (int)CommonConsts.Points.Zero.Y, imagePixelWidth, imagePixelHeight);
                convertBitmap.WritePixels(rect, outputImage, outputImageStride, CommonConsts.Index.First);
            }

            //終了
            return ConvertResult.Sucess(convertBitmap, sb.ToString());
        }

        /// <summary>
        /// 色変換ファイル
        /// </summary>
        /// <param name="formatKind">出力色形式(64色か256色)</param>
        /// <param name="image">入力画像。画像ファイル(BitmapImage)とテスト画像(WriteableBitmap)を受け入れるため、基底クラス(BitmapSource)にする</param>
        /// <param name="name">画像データクラス名</param>
        /// <param name="memberName">画像データメンバー名</param>
        /// <param name="redBits">Rビット数</param>
        /// <param name="greenBits">Gビット数</param>
        /// <param name="blueBits">Bビット数</param>
        /// <param name="animationDatas">アニメーションデータコレクション</param>
        /// <param name="matrixLedWidth">マトリクスLED横ドット数</param>
        /// <param name="matrixLedHeight">マトリクスLED縦ドット数</param>
        /// <param name="matrixLedBrightness">マトリクスLED明るさ</param>
        /// <returns></returns>
        private ConvertResult ConvertColorFile(OutputColorFormatKind formatKind, BitmapSource? image, string? name, string? memberName, int redBits, int greenBits, int blueBits, AnimationDataCollection? animationDatas, int matrixLedWidth, int matrixLedHeight, int matrixLedBrightness)
        {
            //画像有効判定
            if (image == null)
            {
                //画像無しは失敗
                return ConvertResult.Failed("変換画像無し");
            }
            else
            {
                //画像有りの場合は処理続行
            }

            //クラス名有効判定
            {
                bool isNull = string.IsNullOrEmpty(name);
                if (isNull)
                {
                    //クラス名が無効の場合は失敗
                    return ConvertResult.Failed("クラス名無効");
                }
                else
                {
                    //クラス名が有効の場合は処理続行
                }
            }

            //アニメーションデータ数取得
            int animationDataCount = CommonConsts.Collection.Empty;
            if (animationDatas == null)
            {
                //アニメーションデータ無しは失敗
                return ConvertResult.Failed("アニメーションデータ無効");
            }
            else
            {
                animationDataCount = animationDatas.Count;
                if (CommonConsts.Collection.Empty < animationDataCount)
                {
                    //アニメーションデータ有りの場合は処理続行
                }
                else
                {
                    //アニメーションデータ無しは失敗
                    return ConvertResult.Failed("アニメーションデータ無し");
                }
            }

            //画像ピクセル取得
            // >> 検証済の値を取得
            int imagePixelWidth = image.PixelWidth;
            int imagePixelHeight = image.PixelHeight;

            //画像サイズ検証
            ValidateImageSizeResult validateRet = this.ValidateImageSize(imagePixelWidth, imagePixelHeight);
            if (validateRet.IsValid)
            {
                //検証OKの場合は続行
            }
            else
            {
                //検証NGの場合は終了
                return ConvertResult.Failed(validateRet.ErrorMessage);
            }

            //画像ビット数取得
            // >> 検証済の値を取得
            int imageWidthBits = validateRet.ImageWidthBits;
            int imageHeightBits = validateRet.ImageHeightBits;

            //画像データを変換
            byte[]? outputData = null;
            byte[]? outputImage = null;
            int outputImageStride = CommonConsts.Collection.Empty;
            {
                //画像データを出力データに変換
                var convertColorImplResult = this.ConvertColorImpl(image, redBits, greenBits, blueBits);
                if (convertColorImplResult.IsSuccess)
                {
                    //成功した場合は処理続行
                }
                else
                {
                    //失敗した場合は終了
                    return ConvertResult.Failed("色変換失敗");
                }

                //出力データ取得
                outputData = convertColorImplResult.OutputData;
                if (outputData == null)
                {
                    //無効の場合は終了
                    return ConvertResult.Failed("出力データ無効");
                }
                else
                {
                    //有効の場合は処理続行
                }

                //出力画像取得
                outputImage = convertColorImplResult.OutputImage;
                if (outputImage == null)
                {
                    //無効の場合は終了
                    return ConvertResult.Failed("出力画像無効");
                }
                else
                {
                    //有効の場合は処理続行
                }

                //出力画像ストライド取得
                outputImageStride = convertColorImplResult.OutputImageStride;
            }

            //2023.10.16:CS)杉原バイナリデータとして保存
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(ms))
            {
                //@@ ヘッダ(uint16 x 8のサイズ)
                //バージョン(uint16)
                bw.Write((UInt16)100); //TODO:後で定数定義する

                //マトリクスLED
                {
                    // >> 横幅(uint16)
                    bw.Write((UInt16)matrixLedWidth);

                    // >> 縦幅(uint16)
                    bw.Write((UInt16)matrixLedHeight);

                    // >> 明るさ
                    bw.Write((UInt16)matrixLedBrightness);

                    //空き
                    bw.Write((UInt16)0);
                }

                //画像
                {
                    // >> 横ピクセルビット数(uint16)
                    bw.Write((UInt16)imageWidthBits);

                    // >> 横ピクセルビット数(uint16)
                    bw.Write((UInt16)imageHeightBits);

                    // >> フォーマット(uint16)
                    switch (formatKind)
                    {
                        case OutputColorFormatKind.Color64:
                            bw.Write((UInt16)OutputColorFormatKind.Color64);
                            break;

                        default:
                            //それ以外はすべて256にする
                            bw.Write((UInt16)OutputColorFormatKind.Color256);
                            break;
                    }

                    //空き
                    bw.Write((UInt16)0);

                }

                //アニメーション
                {
                    // >> アニメーション数(uint16)
                    bw.Write((UInt16)animationDataCount);

                    // >> アニメーションセルサイズ(uint16) 現在は(+0=X, +1=Y, +2=表示期間の3のみ)
                    // >> 将来の拡張で高度なアニメーションを作るときは増えると思います
                    bw.Write((UInt16)3); //TODO:後で定数定義する

                    //空き
                    bw.Write((UInt16)0);

                    //空き
                    bw.Write((UInt16)0);
                }

                //空き領域
                {
                    //空き
                    bw.Write((UInt16)0);

                    //空き
                    bw.Write((UInt16)0);

                    //空き
                    bw.Write((UInt16)0);

                    //空き
                    bw.Write((UInt16)0);
                }

                //出力データを書込み
                bw.Write(outputData);

                //@@ アニメーションデータ (uint16 * animationDataCount * 3のサイズ)
                for (int i = CommonConsts.Index.First; i < animationDataCount; i += CommonConsts.Index.Step)
                {
                    //アニメーションデータ取得
                    UInt16 x = (UInt16)CommonConsts.Points.Zero.X;
                    UInt16 y = (UInt16)CommonConsts.Points.Zero.Y;
                    UInt16 t = (UInt16)CommonConsts.Intervals.Zero;
                    AnimationData? animationData = animationDatas[i];
                    if (animationData == null)
                    {
                        //無効の場合初期値のままとする
                    }
                    else
                    {
                        //有効の場合
                        x = (UInt16)animationData.X;
                        y = (UInt16)animationData.Y;
                        t = (UInt16)(animationData.DisplayPeriodMillisecond);
                    }

                    //出力
                    // >> X
                    bw.Write(x);

                    // >> Y
                    bw.Write(y);

                    // >> 表示期間
                    bw.Write(t);
                }

                //@@ 書込みを完了する
                bw.Flush();

                //@@ ファイルに書き込み
                try
                {
                    //ESP32側のファイル名は固定なので、あえて名前は変更しない
                    string fname = MicroSignConsts.Path.MatrixLedImagePath;
                    string path = CommonUtils.GetFullPath(fname);
                    CommonLogger.Debug($"アニメーションファイルパス='{path}'");

                    //ディレクトリ取得
                    string? dir = System.IO.Path.GetDirectoryName(path);
                    if (dir == null)
                    {
                        //ディレクトリがnullの場合は何もしない
                        CommonLogger.Debug("アニメーションファイルディレクトリ無し");
                    }
                    else
                    {
                        //ディレクトリ有効判定
                        bool isNull = string.IsNullOrEmpty(dir);
                        if (isNull)
                        {
                            //無効の場合は何もしない
                            CommonLogger.Debug("アニメーションファイルディレクトリ無効");
                        }
                        else
                        {
                            //有効の場合はディレクトリを作成
                            CommonLogger.Debug($"アニメーションファイルディレクトリ='{dir    }'");
                            System.IO.Directory.CreateDirectory(dir);
                        }
                    }

                    //ファイルを出力
                    CommonLogger.Debug("アニメーションファイル書込み - 開始");
                    using (System.IO.FileStream fs = new System.IO.FileStream(path, FileMode.Create))
                    {
                        ms.WriteTo(fs);
                    }
                    CommonLogger.Debug("アニメーションファイル書込み - 完了");

                    //出力先のフォルダをエクスプローラーで表示
                    if (dir == null)
                    {
                        //ディレクトリがnullの場合は何もしない
                    }
                    else
                    {
                        //ディレクトリ有効判定
                        bool isNull = string.IsNullOrEmpty(dir);
                        if (isNull)
                        {
                            //無効の場合は何もしない
                        }
                        else
                        {
                            //有効の場合はディレクトリを表示
                            System.Diagnostics.Process.Start("explorer.exe", dir);
                        }
                    }
                }
                catch(Exception ex)
                {
                    //例外発生時は終了
                    return ConvertResult.Failed(CommonLogger.Warn($"アニメーションファイル書込み失敗", ex));
                }
            }

            //変換後の画像を生成
            WriteableBitmap convertBitmap = new WriteableBitmap(imagePixelWidth, imagePixelHeight, CommonConsts.DPIs.DIP, CommonConsts.DPIs.DIP, PixelFormats.Bgra32, null);
            {
                Int32Rect rect = new Int32Rect((int)CommonConsts.Points.Zero.X, (int)CommonConsts.Points.Zero.Y, imagePixelWidth, imagePixelHeight);
                convertBitmap.WritePixels(rect, outputImage, outputImageStride, CommonConsts.Index.First);
            }

            //終了
            return ConvertResult.Sucess(convertBitmap, "成功");
        }

        /// <summary>
        /// 色変換実装
        /// </summary>
        /// <param name="image">変換する画像</param>
        /// <param name="redBits">Rビット数</param>
        /// <param name="greenBits">Gビット数</param>
        /// <param name="blueBits">Bビット数</param>
        /// <returns>色変換実装結果</returns>
        private (bool IsSuccess, byte[]? OutputData, byte[]? OutputImage, int OutputImageStride) ConvertColorImpl(BitmapSource? image, int redBits, int greenBits, int blueBits)
        {
            //変換する画像の有効判定
            if(image == null)
            {
                //無効の場合は何もせずに終了
                return (false, null, null, CommonConsts.Collection.Empty);
            }
            else
            {
                //有効の場合は処理続行
            }

            //画像ピクセル取得
            // >> 検証済の値を取得
            int imagePixelWidth = image.PixelWidth;
            int imagePixelHeight = image.PixelHeight;

            //画像フォーマットを変換
            // >> https://learn.microsoft.com/ja-jp/dotnet/desktop/wpf/graphics-multimedia/how-to-convert-a-bitmapsource-to-a-different-pixelformat?view=netframeworkdesktop-4.8&viewFallbackFrom=netdesktop-6.0
            FormatConvertedBitmap newFormatedBitmapSource = new FormatConvertedBitmap();
            newFormatedBitmapSource.BeginInit();
            newFormatedBitmapSource.Source = image;
            newFormatedBitmapSource.DestinationFormat = PixelFormats.Bgra32;
            newFormatedBitmapSource.EndInit();
            newFormatedBitmapSource.Freeze();

            //1ピクセルのバイト数
            // >> RGBA 32bit固定の書き方 32/8=4になります
            // >> ほかのピクセルフォーマットに対応する場合はここのコードを変更してください
            int byteParPixel = newFormatedBitmapSource.DestinationFormat.BitsPerPixel / CommonConsts.BitCount.BYTE;

            //画像のストライドを計算
            int imagePixelStride = imagePixelWidth * byteParPixel;

            //画像取得
            int bgra32Size = imagePixelStride * imagePixelHeight;
            byte[] bgra32 = new byte[bgra32Size];
            newFormatedBitmapSource.CopyPixels(bgra32, imagePixelStride, CommonConsts.Index.First);

            //変換後の画像生成先
            byte[] outputImage = new byte[bgra32Size];

            //出力データ生成先
            int outputSize = imagePixelHeight * imagePixelWidth;
            byte[] outputData = new byte[outputSize];

            //Y座標ループ
            for (int y = CommonConsts.Index.First; y < imagePixelHeight; y += CommonConsts.Index.Step)
            {
                //X軸ループ
                for (int x = CommonConsts.Index.First; x < imagePixelWidth; x += CommonConsts.Index.Step)
                {
                    //マージデータ
                    int margeData = CommonConsts.Values.Zero.I;

                    //インデックス計算
                    int index = (y * imagePixelStride) + (x * byteParPixel);
                    int blueIndex = index;
                    int greenIndex = blueIndex + CommonConsts.Index.Step;
                    int redIndex = greenIndex + CommonConsts.Index.Step;
                    int alphaIndex = redIndex + CommonConsts.Index.Step;

                    //透明値
                    int alphaValue = bgra32[alphaIndex];

                    //色値
                    int B = this.CalcColor(bgra32[blueIndex], alphaValue);
                    int G = this.CalcColor(bgra32[greenIndex], alphaValue);
                    int R = this.CalcColor(bgra32[redIndex], alphaValue);

                    //Fullカラーを256色に変換
                    // >> 色明度0～255を-0.5～+3.5に変換し、四捨五入する
                    // >> >> これは色明度0～255を0～3に変換すると以下のように
                    // >> >> 0は0～0.5、3は2.5～3の範囲と、他の明度の範囲に比べて小さくなる
                    // >> >> 丸め前  -1    0     1     2     3     4
                    // >> >>         |     |     |     |     |     |
                    // >> >> 丸め後        |0-|--1--|--2--|-3|
                    // >> >>
                    // >> >> これを避けるための色明度0～255を-0.5～3.5にすることによって
                    // >> >> 他の明度の範囲都同じになる
                    // >> >> 丸め前  -1    0     1     2     3     4
                    // >> >>         |     |     |     |     |     |
                    // >> >> 丸め後     |--0--|--1--|--2--|--3--|
                    // >> >> >> ---------------------
                    // >> >> >> 四捨五入は「ちょうど0.5」の場合の扱いが面倒(-0.5だと-1になったりする)なので
                    // >> >> >> -0.5～+3.5に+0.5した0.0～3.9999(切り捨てしたら常に3になる値)に変換して切り捨てする
                    // 0.0～7.999(切り捨てしたら常に7になる値)に変換して切り捨てする
                    // >> RGB毎の使用ビット数から目標値を求める
                    // > 3bitの場合、0～7で表現するので、0～0.79999に変換して切り捨てする
                    // >> 目標最大値 = (1 << ビット数) - 0.0001
                    // >>            = (1 << 3) - 0.0001
                    // >>            = 8 - 0.0001
                    // >>            = 7.9999
                    double destMaxRed = (1 << redBits) - Model.Consts.RatioConvertionCorrection;
                    double destMaxGreen = (1 << greenBits) - Model.Consts.RatioConvertionCorrection;
                    double destMaxBlue = (1 << blueBits) - Model.Consts.RatioConvertionCorrection;
                    int vRed = (int)Math.Floor(this.RatioConvertion(MicroSignConsts.RGB.Brightness.Min, MicroSignConsts.RGB.Brightness.Max255, MicroSignConsts.RGB.Brightness.Min, destMaxRed, R));
                    int vGreen = (int)Math.Floor(this.RatioConvertion(MicroSignConsts.RGB.Brightness.Min, MicroSignConsts.RGB.Brightness.Max255, MicroSignConsts.RGB.Brightness.Min, destMaxGreen, G));
                    int vBlue = (int)Math.Floor(this.RatioConvertion(MicroSignConsts.RGB.Brightness.Min, MicroSignConsts.RGB.Brightness.Max255, MicroSignConsts.RGB.Brightness.Min, destMaxBlue, B));

                    //１バイトにマージする
                    // >> R=3bit,G=3bit,B=2bit
                    int cr = MicroSignConsts.RGB.Black;
                    // >> 赤
                    cr |= vRed;
                    // >> 緑
                    cr <<= greenBits;
                    cr |= vGreen;
                    // >> 青
                    cr <<= blueBits;
                    cr |= vBlue;

                    //上位バイトにシフト
                    // >> 8bitのフラットな配列に変えたので不要
                    //cr <<= CommonConsts.BitCount.BYTE;

                    //マージデータにマージ
                    margeData |= cr;

                    //マージ値(byte)を変換後データ設定先に設定
                    {
                        int i = (y * imagePixelWidth) + x;
                        outputData[i] = (byte)margeData;
                    }

                    //変換後の画像に反映
                    // >> RGB毎の使用ビット数から入力値を求める
                    // >> 3bitの場合、入力値は0～7となる
                    // >> 入力最大値 = (1 << ビット数) - 1
                    // >>            = (1 << 3) - 1
                    // >>            = 8 - 1
                    // >>            = 7
                    if (outputImage == null)
                    {
                        //変換後画像設定先が無効の場合は何もしない
                    }
                    else
                    {
                        //変換後画像設定先が有効の場合は設定する
                        // >> 赤
                        {
                            double srcMax = (1 << redBits) - 1;
                            double redColor = this.RatioConvertion(MicroSignConsts.RGB.Brightness.Min, srcMax, MicroSignConsts.RGB.Brightness.Min, MicroSignConsts.RGB.Brightness.Max255, vRed);
                            outputImage[redIndex] = (byte)redColor;
                        }

                        // >> 緑
                        {
                            double srcMax = (1 << greenBits) - 1;
                            double greenColor = this.RatioConvertion(MicroSignConsts.RGB.Brightness.Min, srcMax, MicroSignConsts.RGB.Brightness.Min, MicroSignConsts.RGB.Brightness.Max255, vGreen);
                            outputImage[greenIndex] = (byte)greenColor;
                        }

                        // >> 青
                        {
                            double srcMax = (1 << blueBits) - 1;
                            double blueColor = this.RatioConvertion(MicroSignConsts.RGB.Brightness.Min, srcMax, MicroSignConsts.RGB.Brightness.Min, MicroSignConsts.RGB.Brightness.Max255, vBlue);
                            outputImage[blueIndex] = (byte)blueColor;
                        }

                        // >> 透明度
                        outputImage[alphaIndex] = byte.MaxValue;
                    }
                }
            }

            //終了
            return (true, outputData, outputImage, imagePixelStride);
        }
    }
}
