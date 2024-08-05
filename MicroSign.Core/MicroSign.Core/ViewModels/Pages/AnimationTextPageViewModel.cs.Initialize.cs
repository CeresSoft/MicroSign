using System.Windows.Media.Imaging;

namespace MicroSign.Core.ViewModels.Pages
{
    /// <summary>
    /// アニメーションテキストページViewModel
    /// </summary>
    partial class AnimationTextPageViewModel
    {
        /// <summary>
        /// ViewModel初期化
        /// </summary>
        public void Initialize()
        {
            //マトリクスLEDの横幅を取得
            int matrixLedWidth = this.MatrixLedWidth;

            //マトリクスLEDの縦幅を取得
            int matrixLedHeight = this.MatrixLedHeight;

            //レンダリングターゲットビットマップを生成
            var ret = this.Model.CreateRenderTargetBitmap(MatrixLedWidth, matrixLedHeight);
            if(ret.IsSuccess)
            {
                //成功の場合
                this.RenderBitmap = ret.RenderBitmap;
            }
            else
            {
                //失敗の場合
                this.SetStatus(AnimationTextPageStateKind.Failed, CommonLogger.Warn($"レンダリングターゲットビットマップの生成に失敗しました (理由={ret.Message})"));
                return;
            }

            //初期化完了にする
            this.SetStatus(AnimationTextPageStateKind.Initialized, string.Empty);

            //続けて設定されている内容でビットマップを反映
             this.UpdateRenderBitmap();
        }
    }
}
