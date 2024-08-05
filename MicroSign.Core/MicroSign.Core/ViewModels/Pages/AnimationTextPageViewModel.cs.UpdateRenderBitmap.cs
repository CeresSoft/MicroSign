using System.Windows.Media.Imaging;

namespace MicroSign.Core.ViewModels.Pages
{
    /// <summary>
    /// アニメーションテキストページViewModel
    /// </summary>
    partial class AnimationTextPageViewModel
    {
        /// <summary>
        /// 設定されている内容で描写ビットマップを更新する
        /// </summary>
        public void UpdateRenderBitmap()
        {
            //状態判定
            {
                AnimationTextPageStateKind status = this.StatusKind;
                switch (status)
                {
                    case AnimationTextPageStateKind.Initialized:
                        //初期化済みなら処理続行
                        //ログが多いのでコメント化:CommonLogger.Debug("初期化済み");
                        break;

                    default:
                        //それ以外の場合は処理できないので終了
                        CommonLogger.Warn($"初期化されていないか、初期化失敗 (Status={status})");
                        return;
                }
            }

            //レンダリングターゲットビットマップを取得
            RenderTargetBitmap? bmp = this.RenderBitmap;

            //表示文章取得
            string displayText = this.DisplayText ?? string.Empty;

            //フォントサイズ取得
            int fontSize = this.SelectFontSize;

            //フォント色取得
            int fontColor = this.SelectFontColor;

            //描写
            var ret = this.Model.RenderText(bmp, fontSize, fontColor, displayText);
            if(ret.IsSuccess)
            {
                //成功の場合そのまま
            }
            else
            {
                //失敗の場合もそのまま
                // >> 画面に反映されないだけ
            }
        }
    }
}
