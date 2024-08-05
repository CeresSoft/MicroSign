using MicroSign.Core.Navigations;
using MicroSign.Core.Navigations.Enums;
using MicroSign.Core.ViewModels.Pages;
using MicroSign.Core.Views.Overlaps;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Views.Pages
{
    /// <summary>
    /// AnimationTextPage.xaml の相互作用ロジック
    /// </summary>
    public partial class AnimationTextPage : UserControl
    {

        /// <summary>
        /// AnimationTextPage結果
        /// </summary>
        public class AnimationTextPageResult
        {
            /// <summary>
            /// 結果
            /// </summary>
            public readonly NavigationResultKind ResultKind;

            /// <summary>
            /// 選択フォントサイズ
            /// </summary>
            public readonly int SelectFontSize;

            /// <summary>
            /// 選択フォント色
            /// </summary>
            public readonly int SelectFontColor;

            /// <summary>
            /// 表示文章
            /// </summary>
            public readonly string? DisplayText;

            /// <summary>
            /// レンダリング結果
            /// </summary>
            public readonly RenderTargetBitmap? RenderBitmap;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="resultKind">結果</param>
            /// <param name="selectFontSize">選択フォントサイズ</param>
            /// <param name="selectFontColor">選択フォント色</param>
            /// <param name="displayText">表示テキスト</param>
            /// <param name="renderBitmap">レンダリング結果</param>
            private AnimationTextPageResult(NavigationResultKind resultKind, int selectFontSize, int selectFontColor, string? displayText, RenderTargetBitmap? renderBitmap)
            {
                this.ResultKind = resultKind;
                this.SelectFontSize = selectFontSize;
                this.SelectFontColor = selectFontColor;
                this.DisplayText = displayText;
                this.RenderBitmap = renderBitmap;
            }

            /// <summary>
            /// キャンセルの場合
            /// </summary>
            /// <returns></returns>
            public static AnimationTextPageResult Cancel()
            {
                AnimationTextPageResult result = new AnimationTextPageResult(NavigationResultKind.Cancel, CommonConsts.Values.Zero.I, CommonConsts.Values.Zero.I, null, null);
                return result;
            }

            /// <summary>
            /// 成功の場合
            /// </summary>
            /// <param name="selectFontSize">選択フォントサイズ</param>
            /// <param name="selectFontColor">選択フォント色</param>
            /// <param name="displayText">表示テキスト</param>
            /// <param name="renderBitmap">レンダリング結果</param>
            /// <returns></returns>
            public static AnimationTextPageResult Success(int selectFontSize, int selectFontColor, string? displayText, RenderTargetBitmap? renderBitmap)
            {
                AnimationTextPageResult result = new AnimationTextPageResult(NavigationResultKind.Success, selectFontSize, selectFontColor, displayText, renderBitmap);
                return result;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AnimationTextPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="matrixLedWidth">マトリクスLED横幅</param>
        /// <param name="matrixLedHeight">マトリクスLED縦幅</param>
        /// <param name="animationName">アニメーション名</param>
        public AnimationTextPage(int matrixLedWidth, int matrixLedHeight, string? animationName)
            :this()
        {
            this.ViewModel.MatrixLedWidth = matrixLedWidth;
            this.ViewModel.MatrixLedHeight = matrixLedHeight;
            this.ViewModel.AnimationName = animationName;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="matrixLedWidth">マトリクスLED横幅</param>
        /// <param name="matrixLedHeight">マトリクスLED縦幅</param>
        /// <param name="animationName">アニメーション名</param>
        /// <param name="selectFontSize">選択フォントサイズ</param>
        /// <param name="selectFontColor">選択フォント色</param>
        /// <param name="displayText">表示文章</param>
        public AnimationTextPage(int matrixLedWidth, int matrixLedHeight, string? animationName, int selectFontSize, int selectFontColor, string? displayText)
            : this(matrixLedWidth, matrixLedHeight, animationName)
        {
            this.ViewModel.SelectFontSize = selectFontSize;
            this.ViewModel.SelectFontColor = selectFontColor;
            this.ViewModel.DisplayText = displayText;
        }


        /// <summary>
        /// OKクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOkClick(object sender, MicroSign.Core.Navigations.Events.OkClickEventArgs e)
        {
            //ViewModelを取得
            AnimationTextPageViewModel vm = this.ViewModel;

            //エラーチェック
            {
                AnimationTextPageStateKind status = this.ViewModel.StatusKind;
                switch(status)
                {
                    case AnimationTextPageStateKind.Initialized:
                        //初期化済みなら何等かの画面が表示されているはずなので
                        //常に成功として処理続行する
                        break;

                    default:
                        //それ以外は何らかのエラーなのでエラーメッセージを表示して終了
                        this.NavigationCall(new WarnMessageBox($"エラー '{this.ViewModel.StatusText}'"));
                        return;
                }
            }

            //画面を閉じる
            {
                int fontSize = vm.SelectFontSize;
                int fontColor = vm.SelectFontColor;
                string? displayText = vm.DisplayText;
                RenderTargetBitmap? renderBitmap = vm.RenderBitmap;
                AnimationTextPageResult result = AnimationTextPageResult.Success(fontSize, fontColor, displayText, renderBitmap);
                this.NavigationReturn(result);
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
            //画面を閉じる
            AnimationTextPageResult result = AnimationTextPageResult.Cancel();
            this.NavigationReturn(result);
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
                this.ViewModel.SetStatus(AnimationTextPageStateKind.Failed, CommonLogger.Warn("Loadedで例外が発生しました", ex));
            }
        }
    }
}
