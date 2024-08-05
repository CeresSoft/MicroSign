using MicroSign.Core.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    /// <summary>
    /// モデル
    /// </summary>
    partial class Model
    {
        /// <summary>
        /// テキストをレンダリング
        /// </summary>
        /// <param name="bmp">レンダリング先のビットマップ</param>
        /// <param name="fontSize">フォントサイズ</param>
        /// <param name="fontColor">フォント色</param>
        /// <param name="displayText">表示文字</param>
        /// <returns></returns>
        public (bool IsSuccess, string Message) RenderText(RenderTargetBitmap? bmp, int fontSize, int fontColor, string? displayText)
        {
            //ビットマップ有効判定
            if (bmp == null)
            {
                //レンダリングターゲットビットマップが無効の場合は処理できないので終了
                return (false, CommonLogger.Warn("レンダリングターゲットビットマップが無効です"));
            }
            else
            {
                //レンダリングターゲットビットマップが有効の場合は処理続行
                //ログが多いのでコメント化:CommonLogger.Debug("レンダリングターゲットビットマップが有効");
            }

            //横幅取得
            int width = bmp.PixelWidth;
            if(CommonConsts.Values.Zero.I < width)
            {
                //有効の場合は処理続行
                //ログが多いのでコメント化:CommonLogger.Debug($"横幅有効 ({width})");
            }
            else
            {
                //無効の場合は処理できないので終了
                return (false, CommonLogger.Warn($"レンダリングターゲットビットマップの横幅が無効です ({width})"));
            }

            //縦幅取得
            int height = bmp.PixelHeight;
            if (CommonConsts.Values.Zero.I < height)
            {
                //有効の場合は処理続行
                //ログが多いのでコメント化:CommonLogger.Debug($"縦幅有効 ({height})");
            }
            else
            {
                //無効の場合は処理できないので終了
                return (false, CommonLogger.Warn($"レンダリングターゲットビットマップの縦幅が無効です ({height})"));
            }

            //表示文字色取得
            Brush brush = Brushes.White;
            {
                switch (fontColor)
                {
                    case 0: //黒
                        brush = Brushes.Black;
                        break;

                    case 1: //赤
                        brush = Brushes.Red;
                        break;

                    case 2: //緑
                        brush = Brushes.Green;
                        break;

                    case 3: //黄
                        brush = Brushes.Yellow;
                        break;

                    case 4: //青
                        brush = Brushes.Blue;
                        break;

                    case 5: //紫
                        brush = Brushes.Magenta;
                        break;

                    case 6: //水
                        brush = Brushes.Cyan;
                        break;

                    default:
                        //不明の場合は白(=初期値)とする
                        break;
                }
            }

            //描写
            try
            {
                //表示内容反映
                AnimationTextRenderUserControl animationText = new AnimationTextRenderUserControl();
                animationText.Width = width;
                animationText.Height = height;
                animationText.Text = displayText ?? string.Empty;
                animationText.DisplayTextFontSize = fontSize;
                animationText.DisplayTextColor = brush;
                animationText.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                animationText.Arrange(new Rect(CommonConsts.Points.Zero.X, CommonConsts.Points.Zero.Y, width, height));

                //ビットマップに描写
                bmp.Render(animationText);
            }
            catch(Exception ex)
            {
                return (false, CommonLogger.Warn($"レンダリングターゲットビットマップの描写に失敗しました (Width={width}, Height={height}, FontSize={fontSize}, FontColor={fontColor}, DisplayText='{displayText}')", ex));
            }

            //ここまで来たら成功で終了
            return (true, string.Empty);
        }
    }
}
