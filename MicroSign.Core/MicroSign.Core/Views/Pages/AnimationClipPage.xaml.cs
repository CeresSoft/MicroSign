using MicroSign.Core.Navigations;
using MicroSign.Core.ViewModels.Pages;
using MicroSign.Core.Views.Overlaps;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Views.Pages
{
    /// <summary>
    /// ImageClipPage.xaml の相互作用ロジック
    /// </summary>
    public partial class AnimationClipPage : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AnimationClipPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="matrixLedWidth">マトリクスLED横幅</param>
        /// <param name="matrixLedHeight">マトリクスLED縦幅</param>
        /// <param name="originalImage">オリジナル画像</param>
        public AnimationClipPage(int matrixLedWidth, int matrixLedHeight, BitmapSource? originalImage)
            : this()
        {
            this.ViewModel.MatrixLedWidth = matrixLedWidth;
            this.ViewModel.MatrixLedHeight = matrixLedHeight;
            this.ViewModel.OriginalImage = originalImage;
        }

        /// <summary>
        /// OKクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOkClick(object sender, MicroSign.Core.Navigations.Events.OkClickEventArgs e)
        {
            //ViewModelを取得
            AnimationClipPageViewModel vm = this.ViewModel;

            //エラーチェック

            //TODO: 2025.09.22: 画面を閉じる
            {
                //int fontSize = vm.SelectFontSize;
                //int fontColor = vm.SelectFontColor;
                //string? displayText = vm.DisplayText;
                //RenderTargetBitmap? renderBitmap = vm.RenderBitmap;
                //AnimationTextPageResult result = AnimationTextPageResult.Success(fontSize, fontColor, displayText, renderBitmap);
                this.NavigationReturn(/*result*/);
            }

            //成功で終了
            e.Success();
        }

        /// <summary>
        /// キャンセルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelClick(object sender, MicroSign.Core.Navigations.Events.CancelClickEventArgs e)
        {
            //TODO: 2025.09.22: 画面を閉じる
            //AnimationTextPageResult result = AnimationTextPageResult.Cancel();
            this.NavigationReturn(/*result*/);
        }

        /// <summary>
        /// 画面が表示される時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Root_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //ViewModel初期化
                this.ViewModel.Initialize();
            }
            catch (Exception ex)
            {
                //TODO: 2025.09.22: this.ViewModel.SetStatus(AnimationTextPageStateKind.Failed, CommonLogger.Warn("Loadedで例外が発生しました", ex));
            }
        }
    }
}
