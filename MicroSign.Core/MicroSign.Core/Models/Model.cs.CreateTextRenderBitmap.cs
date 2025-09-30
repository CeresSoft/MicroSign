using MicroSign.Core.Views.Pages;
using System;
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
        /// 文字レンダリングビットマップ生成
        /// </summary>
        /// <param name="fontSize">フォントサイズ</param>
        /// <param name="fontColor">フォント色</param>
        /// <param name="displayText">表示文字</param>
        /// <param name="minWidth">最小横幅</param>
        /// <param name="minHeight">最小縦幅</param>
        /// <returns></returns>
        public (bool IsSuccess, string Message, RenderTargetBitmap? RenderBitmap) CreateTextRenderBitmap(int fontSize, int fontColor, string? displayText, double minWidth, double minHeight)
        {
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

            //文字列コントロールを生成
            AnimationTextRenderUserControl? animationText = null;
            try
            {
                //表示内容反映
                animationText = new AnimationTextRenderUserControl();
                animationText.Text = displayText ?? string.Empty;
                animationText.DisplayTextFontSize = fontSize;
                animationText.DisplayTextColor = brush;
                animationText.MinWidth = minWidth;
                animationText.MinHeight = minHeight;

                //表示内容から必要サイズを計算
                animationText.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                Size desiredSize = animationText.DesiredSize;

                //コントロールサイズを確定
                animationText.Arrange(new Rect(CommonConsts.Points.Zero.X, CommonConsts.Points.Zero.Y, desiredSize.Width, desiredSize.Height));
            }
            catch (Exception ex)
            {
                return (false, CommonLogger.Warn($"文字列コントロールの生成に失敗しました (FontSize={fontSize}, FontColor={fontColor}, DisplayText='{displayText}')", ex), null);
            }

            //文字列コントロールが収まるビットマップのサイズを計算
            // >> コントロールのWidth/Heightは小数の場合があるので、繰り上げた整数を使用する
            int width = (int)Math.Ceiling(animationText.ActualWidth);
            int height = (int)Math.Ceiling(animationText.ActualHeight);

            //レンダリングターゲットビットマップを生成
            RenderTargetBitmap? renderBitmap = null;
            {
                //レンダリングターゲットビットマップを生成
                var ret = this.CreateRenderTargetBitmap(width, height);
                if (ret.IsSuccess)
                {
                    //成功の場合はレンダリングターゲットビットマップを取得
                    renderBitmap = ret.RenderBitmap;
                }
                else
                {
                    //失敗の場合
                    CommonLogger.Warn($"レンダリングターゲットビットマップの生成に失敗しました (Width={width}, Height={height})");
                    return (false, ret.Message, null);
                }
            }

            //レンダリングターゲットビットマップ有効判定
            if (renderBitmap == null)
            {
                //無効の場合は失敗で終了
                return (false, CommonLogger.Warn("レンダリングターゲットビットマップが無効です"), null);
            }
            else
            {
                //有効の場合は続行
            }

            //描写
            try
            {
                //ビットマップに描写
                renderBitmap.Render(animationText);
            }
            catch (Exception ex)
            {
                return (false, CommonLogger.Warn($"レンダリングターゲットビットマップの描写に失敗しました", ex), null);
            }

            //ここまで来たら成功で終了
            return (true, string.Empty, renderBitmap);
        }
    }
}
