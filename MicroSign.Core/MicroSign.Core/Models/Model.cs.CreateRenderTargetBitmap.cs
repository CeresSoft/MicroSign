using System;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    /// <summary>
    /// モデル
    /// </summary>
    partial class Model
    {
        /// <summary>
        /// レンダリングターゲットビットマップ生成
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public (bool IsSuccess, string Message, RenderTargetBitmap? RenderBitmap) CreateRenderTargetBitmap(int width, int height)
        {
            //横幅有効判定
            if (CommonConsts.Values.Zero.I < width)
            {
                //横幅が0超過なら正常
                CommonLogger.Debug($"横幅={width} 有効");
            }
            else
            {
                //横幅が0未満の場合は異常なので、状態を失敗にして終了
                return (false, CommonLogger.Warn($"横幅={width} 異常"), null);
            }

            //縦幅有効判定
            if (CommonConsts.Values.Zero.I < height)
            {
                //横幅が0超過なら正常
                CommonLogger.Debug($"縦幅={height} 有効");
            }
            else
            {
                //横幅が0未満の場合は異常なので、状態を失敗にして終了
                return (false, CommonLogger.Warn($"縦幅={height} 異常"), null);
            }

            //レンダリングターゲットビットマップを生成
            // >> 2023.12.24:CS)杉原:子のビットマップはRender()を使うのでPixelFormatはPbgra32でなければならない
            try
            {
                CommonLogger.Debug("レンダリングターゲットビットマップを生成 - 開始");
                RenderTargetBitmap bmp = new RenderTargetBitmap(width, height, CommonConsts.DPIs.DIP, CommonConsts.DPIs.DIP, System.Windows.Media.PixelFormats.Pbgra32);
                CommonLogger.Debug("レンダリングターゲットビットマップを生成 - 完了");
                return (true, string.Empty, bmp);
            }
            catch(Exception ex)
            {
                return (false, CommonLogger.Warn($"レンダリングターゲットビットマップを生成で例外発生 (横幅={width}, 縦幅={height})", ex), null);
            }
        }
    }
}
