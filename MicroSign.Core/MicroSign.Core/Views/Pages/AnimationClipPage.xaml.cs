using MicroSign.Core.Navigations;
using MicroSign.Core.Navigations.Enums;
using MicroSign.Core.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using static MicroSign.Core.ViewModels.Pages.AnimationClipPageViewModel;

namespace MicroSign.Core.Views.Pages
{
    /// <summary>
    /// ImageClipPage.xaml の相互作用ロジック
    /// </summary>
    public partial class AnimationClipPage : UserControl
    {
        /// <summary>
        /// AnimationClipPage結果
        /// </summary>
        public class AnimationClipPageResult
        {
            /// <summary>
            /// 結果
            /// </summary>
            public readonly NavigationResultKind ResultKind;

            /// <summary>
            /// 出力パス一覧
            /// </summary>
            public readonly List<string>? OutputPaths;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="resultKind">結果</param>
            /// <param name="outputPaths">出力パス一覧</param>
            private AnimationClipPageResult(NavigationResultKind resultKind, List<string>? outputPaths)
            {
                this.ResultKind = resultKind;
                this.OutputPaths = outputPaths;
            }

            /// <summary>
            /// キャンセルの場合
            /// </summary>
            /// <returns></returns>
            public static AnimationClipPageResult Cancel()
            {
                AnimationClipPageResult result = new AnimationClipPageResult(NavigationResultKind.Cancel, null);
                return result;
            }

            /// <summary>
            /// 成功の場合
            /// </summary>
            /// <param name="outputPaths">出力パス一覧</param>
            /// <returns></returns>
            public static AnimationClipPageResult Success(List<string>? outputPaths)
            {
                AnimationClipPageResult result = new AnimationClipPageResult(NavigationResultKind.Success, outputPaths);
                return result;
            }

            /// <summary>
            /// 失敗の場合
            /// </summary>
            /// <returns></returns>
            public static AnimationClipPageResult Failed()
            {
                AnimationClipPageResult result = new AnimationClipPageResult(NavigationResultKind.Failed, null);
                return result;
            }
        }

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
        /// <param name="originalImagePath">オリジナル画像のパス</param>
        public AnimationClipPage(int matrixLedWidth, int matrixLedHeight, BitmapSource? originalImage, string? originalImagePath)
            : this()
        {
            this.ViewModel.MatrixLedWidth = matrixLedWidth;
            this.ViewModel.MatrixLedHeight = matrixLedHeight;
            this.ViewModel.OriginalImage = originalImage;
            this.ViewModel.OriginalImagePath = originalImagePath;
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

            //操作不可
            this.IsEnabled = false;

            //アニメーション切り抜き開始
            vm.ClipAnimation(this.OnClipAnimationFinish);

            //成功で終了
            e.Success();
        }

        /// <summary>
        /// アニメーション切り抜き完了
        /// </summary>
        /// <param name="taskResult"></param>
        private void OnClipAnimationFinish(ClipAnimationResult taskResult)
        {
            System.Diagnostics.Debug.WriteLine("OnClipAnimationFinish");

            //操作可能
            this.IsEnabled = true;

            //画面を閉じる
            {
                bool isSuccess = taskResult.IsSuccess;
                if (isSuccess)
                {
                    //成功で終了
                    List<string>? outputPaths = taskResult.OutputPaths;
                    AnimationClipPageResult result = AnimationClipPageResult.Success(outputPaths);
                    this.NavigationReturn(result);
                }
                else
                {
                    //失敗で終了
                    AnimationClipPageResult result = AnimationClipPageResult.Failed();
                    this.NavigationReturn(result);
                }
            }
        }

        /// <summary>
        /// キャンセルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelClick(object sender, MicroSign.Core.Navigations.Events.CancelClickEventArgs e)
        {
            //画面を閉じる
            AnimationClipPageResult result = AnimationClipPageResult.Cancel();
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
                //TODO: 2025.09.22: this.ViewModel.SetStatus(AnimationClipPageStateKind.Failed, CommonLogger.Warn("Loadedで例外が発生しました", ex));
            }
        }
    }
}
