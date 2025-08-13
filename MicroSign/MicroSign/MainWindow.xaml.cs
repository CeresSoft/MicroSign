﻿using MicroSign.Core;
using MicroSign.Core.Navigations;
using MicroSign.Core.Navigations.Enums;
using MicroSign.Core.ViewModels;
using MicroSign.Core.Views.Pages;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using static MicroSign.Core.Models.Model;

namespace MicroSign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// LOG4NETのロガー
        /// </summary>
        private static readonly log4net.ILog LOGGER = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

        /// <summary>
        /// アニメーション用タイマー
        /// </summary>
        /// <remarks>タイマーの精度は求めないのでDispatcherTimerを使います</remarks>
        private DispatcherTimer _AnimationTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            //ビットマップを拡大表示したときにグラデーションにならないようにする
            RenderOptions.SetBitmapScalingMode(this, BitmapScalingMode.NearestNeighbor);

            //アニメーションタイマーのイベント設定
            this._AnimationTimer.Tick += this._AnimationTimer_Tick;
        }

        /// <summary>
        /// 画像読込ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //画像パスを取得
                string? imagePath = this.SelectImagePath("画像読込");
                if (imagePath == null)
                {
                    //無効の場合は終了
                    return;
                }
                else
                {
                    bool isNull = string.IsNullOrEmpty(imagePath);
                    if (isNull)
                    {
                        //取得出来なかった場合は終了
                        return;
                    }
                    else
                    {
                        //有効の場合は処理続行
                    }
                }

                //画像を読込
                BitmapImage? image = this.ViewModel.GetImage(imagePath);
                if (image == null)
                {
                    //取得出来なかった場合は終了
                    return;
                }
                else
                {
                    //有効の場合は処理続行
                }

                //2023.10.17:CS)杉原:アニメーションが増えたので自動変換は無効にします
                ////変換
                //this.ViewModel.Convert(image);
                //----------
                // >> 設定する
                this.ViewModel.SetLoadImage(image);
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("読込で例外発生"), ex);
            }
        }

        /// <summary>
        /// 敷居値変更時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThresholdSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //2023.10.17:CS)杉原:アニメーションが増えたので自動変換は無効にします
            //try
            //{
            //    //ビットマップ取得
            //    BitmapSource? bmp = this.ViewModel.LoadImage;
            //
            //    //変換
            //    this.ViewModel.Convert(bmp);
            //}
            //catch (Exception ex)
            //{
            //    this.ShowError("閾値変更で例外発生", ex);
            //}
        }

        /// <summary>
        /// クラス名変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //2023.10.17:CS)杉原:アニメーションが増えたので自動変換は無効にします
            //try
            //{
            //    //ビットマップ取得
            //    BitmapSource? bmp = this.ViewModel.LoadImage;
            //
            //    //変換
            //    this.ViewModel.Convert(bmp);
            //}
            //catch (Exception ex)
            //{
            //    this.ShowError("クラス名変更で例外発生", ex);
            //}
        }

        /// <summary>
        /// フォーマット選択変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormatSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //2023.10.17:CS)杉原:アニメーションが増えたので自動変換は無効にします
            //try
            //{
            //    //ビットマップ取得
            //    BitmapSource? bmp = this.ViewModel.LoadImage;
            //
            //    //変換
            //    this.ViewModel.Convert(bmp);
            //}
            //catch (Exception ex)
            //{
            //    this.ShowError("フォーマット選択変更で例外発生", ex);
            //}
        }

        /// <summary>
        /// アニメーション画像追加ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAnimationImageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //画像パスを取得
                string[]? imagePaths = this.MultiSelectImagePath("アニメーション画像追加");

                //アニメーション画像追加
                this.AddAnimationImages(imagePaths);
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("アニメーション画像追加で例外発生"), ex);
            }
        }

        /// <summary>
        /// アニメーション文字追加ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAnimationTextButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //ViewModelから設定されているマトリクスLEDの情報を取得する
                MainWindowViewModel vm = this.ViewModel;
                int matrixLedWidth = vm.MatrixLedWidth;
                int matrixLedHeight = vm.MatrixLedHeight;
                string? animationName = vm.AnimationName;

                //アニメーション文字ページを表示
                MicroSign.Core.Views.Pages.AnimationTextPage page = new MicroSign.Core.Views.Pages.AnimationTextPage(matrixLedWidth, matrixLedHeight, animationName);
                this.NaviPanel.NavigationCall(page, null, this.AddAnimationTextButton_Result);
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("アニメーション文字追加で例外発生"), ex);
            }
        }

        /// <summary>
        /// アニメーション文字追加結果
        /// </summary>
        /// <param name="callArgs"></param>
        /// <param name="result"></param>
        private void AddAnimationTextButton_Result(object? callArgs, object? result)
        {
            try
            {
                if(result is AnimationTextPage.AnimationTextPageResult ret)
                {
                    //結果を判定
                    NavigationResultKind resultKind = ret.ResultKind;
                    switch(resultKind)
                    {
                        case NavigationResultKind.Success:
                            //成功の場合は処理続行
                            CommonLogger.Debug("アニメーション文字追加成功");
                            break;

                        case NavigationResultKind.Cancel:
                            //キャンセルの場合は何もせずに終了
                            CommonLogger.Info("アニメーション文字追加キャンセル");
                            return;

                        default:
                            //それ以外は失敗
                            this.ShowWarning(CommonLogger.Warn($"文字追加に失敗しました (理由={resultKind}')"));
                            return;
                    }

                    //ビットマップ取得
                    BitmapSource? image = ret.RenderBitmap;
                    if (image == null)
                    {
                        //取得出来なかった場合は終了
                        this.ShowError(CommonLogger.Error("文字画像が無効です"));
                        return;
                    }
                    else
                    {
                        //有効の場合は処理続行
                        CommonLogger.Info("文字画像有効");
                    }

                    //フォントサイズ取得
                    // >> サイズはいくつでもよい。再編集時にAnimationTextPageへ渡すだけ
                    int selectFontSize = ret.SelectFontSize;

                    //フォント色取得
                    // >> 色はいくつでもよい。再編集時にAnimationTextPageへ渡すだけ
                    int selectFontColor = ret.SelectFontColor;

                    //表示文字取得
                    // >> 表示文字はなんでもよい。再編集時にAnimationTextPageへ渡すだけ
                    string? displayText = ret.DisplayText;

                    //デフォルトの表示期間を取得
                    double defaultDisplayPeriod = this.ViewModel.DefaultDisplayPeriod;

                    //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
                    ////画像変換
                    //MicroSign.Core.Models.Model.ConvertImageResult convertImageResult = this.ViewModel.ConvertAnimationImage(image);
                    //if (convertImageResult.IsSuccess)
                    //{
                    //    //成功の場合は続行
                    //    CommonLogger.Debug($"画像変換成功");
                    //}
                    //else
                    //{
                    //    //変換失敗の場合は終了
                    //    this.ShowError(CommonLogger.Error("画像の変換に失敗しました"));
                    //    return;
                    //}
                    //
                    ////アニメーション画像アイテムを生成
                    //AnimationImageItem animationImageItem = AnimationImageItem.FromText(
                    //    defaultDisplayPeriod,
                    //    selectFontSize,
                    //    selectFontColor,
                    //    displayText,
                    //    image,
                    //    convertImageResult.OutputData,
                    //    convertImageResult.PreviewImage
                    //    );
                    //----------
                    // >> プレビュー画像が不要になったので変換した画像も不要となりました
                    //アニメーション画像アイテムを生成
                    AnimationImageItem animationImageItem = AnimationImageItem.FromText(
                        defaultDisplayPeriod,
                        selectFontSize,
                        selectFontColor,
                        displayText,
                        image
                        );
                    //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで

                    //リストに追加
                    this.ViewModel.AddAnimationImage(animationImageItem);
                }
                else
                {
                    //結果が取得できない場合は何もしない
                    this.ShowWarning(CommonLogger.Warn("アニメーション文字追加結果が確認出来ません"));
                }
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("アニメーション文字追加結果で例外発生"), ex);
            }
        }

        /// <summary>
        /// アニメーション画像削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveAnimationImageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //選択されているアニメーション画像を取得
                AnimationImageItem? selectedAnimationImage = this.ViewModel.GetSelectAnimationImage();
                if (selectedAnimationImage == null)
                {
                    //選択されているアニメーション画像が無い場合はメッセージを表示して終了
                    this.ShowWarning(CommonLogger.Warn("アニメーション画像が選択されていません"));
                    return;
                }
                else
                {
                    //選択されている場合は処理続行
                }

                //確認画面
                this.NaviPanel.NavigationOverwrap(new MicroSign.Core.Views.Overlaps.ConfirmMessageBox("選択されているアニメーション画像を削除します。\nよろしいですか?", this.Title), selectedAnimationImage, this.RemoveAnimationImageButton_Retrun);
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("アニメーション画像削除で例外発生"), ex);
            }
        }

        /// <summary>
        /// アニメーション画像削除確認結果
        /// </summary>
        /// <param name="callArgs">呼出引数(=AnimationImageItem)</param>
        /// <param name="result">戻り値(=MicroSign.Core.Navigations.Enums.NavigationResultKind)</param>
        private void RemoveAnimationImageButton_Retrun(object? callArgs, object? result)
        {
            if(result is MicroSign.Core.Navigations.Enums.NavigationResultKind resultKind)
            {
                //呼出時の引数の選択アニメーションを取得
                AnimationImageItem? selectedAnimationImage = callArgs as AnimationImageItem;

                //確認結果により分岐
                switch (resultKind)
                {
                    case NavigationResultKind.Success:
                        //成功(=Yes)の場合
                        //>> 選択アイテムを削除
                        this.ViewModel.RemoveAnimationImage(selectedAnimationImage);
                        break;

                    default:
                        //それ以外の場合は何もしない
                        break;
                }
            }
            else
            {
                //無効の場合は何もせずに終了
                CommonLogger.Warn($"アニメーション画像削除確認の結果が判定できませんでした (ret={result})");
            }
        }

        /// <summary>
        /// 全アニメーション画像削除ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveAllAnimationImageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //確認画面
                this.NaviPanel.NavigationOverwrap(new MicroSign.Core.Views.Overlaps.ConfirmMessageBox("全アニメーション画像を削除します。\nよろしいですか?", this.Title), null, this.RemoveAllAnimationImageButton_Retrun);
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("アニメーション画像削除で例外発生"), ex);
            }
        }

        /// <summary>
        /// アニメーション画像削除確認結果
        /// </summary>
        /// <param name="callArgs">呼出引数(=AnimationImageItem)</param>
        /// <param name="result">戻り値(=MicroSign.Core.Navigations.Enums.NavigationResultKind)</param>
        private void RemoveAllAnimationImageButton_Retrun(object? callArgs, object? result)
        {
            if (result is MicroSign.Core.Navigations.Enums.NavigationResultKind resultKind)
            {
                //呼出時の引数の選択アニメーションを取得
                AnimationImageItem? selectedAnimationImage = callArgs as AnimationImageItem;

                //確認結果により分岐
                switch (resultKind)
                {
                    case NavigationResultKind.Success:
                        //成功(=Yes)の場合
                        //>> 選択アイテムを削除
                        this.ViewModel.RemoveAllAnimationImage();
                        break;

                    default:
                        //それ以外の場合は何もしない
                        break;
                }
            }
            else
            {
                //無効の場合は何もせずに終了
                CommonLogger.Warn($"全アニメーション画像削除確認の結果が判定できませんでした (ret={result})");
            }
        }

        /// <summary>
        /// アニメーション画像上へ移動ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpAnimationImageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //選択されているアニメーション画像を取得
                AnimationImageItem? selectedAnimationImage = this.ViewModel.GetSelectAnimationImage();
                if (selectedAnimationImage == null)
                {
                    //選択されているアニメーション画像が無い場合はメッセージを表示して終了
                    this.ShowWarning("アニメーション画像が選択されていません");
                    return;
                }
                else
                {
                    //選択されている場合は処理続行
                }

                //選択されているアニメーション画像を上に移動
                this.ViewModel.UpAnimationImage(selectedAnimationImage);
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("アニメーション画像上移動で例外発生"), ex);
            }
        }

        /// <summary>
        /// アニメーション画像下へ移動ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownAnimationImageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //選択されているアニメーション画像を取得
                AnimationImageItem? selectedAnimationImage = this.ViewModel.GetSelectAnimationImage();
                if (selectedAnimationImage == null)
                {
                    //選択されているアニメーション画像が無い場合はメッセージを表示して終了
                    this.ShowWarning(CommonLogger.Warn("アニメーション画像が選択されていません"));
                    return;
                }
                else
                {
                    //選択されている場合は処理続行
                }

                //選択されているアニメーション画像を下に移動
                this.ViewModel.DownAnimationImage(selectedAnimationImage);
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("アニメーション画像下移動で例外発生"), ex);
            }
        }

        /// <summary>
        /// アニメーション画像変換ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //アニメーション数を確認
                int animationItemsCount = this.ViewModel.GetAnimationImagesCount();
                if (CommonConsts.Collection.Empty < animationItemsCount)
                {
                    //アニメーション画像がある場合は処理続行
                }
                else
                {
                    //アニメーション画像が空の場合はメッセージボックスを表示して終了
                    this.ShowWarning(CommonLogger.Warn("アニメーション画像が存在しません"));
                    return;
                }

                //2024.04.30:CS)杉原:リリース向けの機能追加 >>>>> ここから
                //----------
                // >> そのうちスクロール機能を入れようと思って画像サイズは2の累乗であればなんでも良い仕様にしていましたが
                // >> パネルが128x32の設定なのに64x64の画像を追加して変換できてしまうのは少々わかりにくい
                // >> とりあえずパネルのサイズと異なるサイズの画像が有った場合は変換できないようにします
                {
                    //設定されているパネルサイズを取得
                    int panelWidth = this.ViewModel.MatrixLedWidth;
                    int panelHeight = this.ViewModel.MatrixLedHeight;

                    //画像を判定
                    for (int i = CommonConsts.Index.First; i < animationItemsCount; i += CommonConsts.Index.Step)
                    {
                        AnimationImageItem? item = this.ViewModel.GetAnimationImage(i);
                        if(item == null)
                        {
                            //アニメーション画像が無効の場合は無視する
                        }
                        else
                        {
                            //アニメーション画像が有効の場合適合するか判定
                            bool isFit = item.IsFit(panelWidth, panelHeight);
                            if(isFit)
                            {
                                //適合した場合は処理続行
                            }
                            else
                            {
                                //適合しない場合は失敗にする
                                this.ShowWarning(CommonLogger.Warn($"アニメーション画像の変換に失敗しました。\n理由=パネルサイズに適合しない画像が存在します ({CommonConsts.Index.ToCount(i)}行目)"));
                                return;
                            }
                        }
                    }
                }
                //2024.04.30:CS)杉原:リリース向けの機能追加 <<<<< ここまで

                //アニメーション変換開始
                {
                    //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
                    //var ret = this.ViewModel.ConvertAnimation();
                    //----------
                    MainWindowViewModel.ConvertAnimationResult ret = this.ViewModel.ConvertAnimation();
                    //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで
                    if (ret.IsSuccess)
                    {
                        //成功の場合
                        this.ShowInfo(CommonLogger.Info("アニメーション画像を変換しました"));
                    }
                    else
                    {
                        //失敗の場合
                        //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
                        //this.ShowWarning(CommonLogger.Warn($"アニメーション画像の変換に失敗しました。\n理由={ret.Code}"));
                        //----------
                        this.ShowWarning(CommonLogger.Warn($"アニメーション画像の変換に失敗しました。\n理由={ret.Message}"));
                        //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("アニメーション画像変換で例外発生"), ex);
            }
        }

        /// <summary>
        /// アニメーション設定保存ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationSaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //アニメーション数を確認
                {
                    int animationItemsCount = this.ViewModel.GetAnimationImagesCount();
                    if (CommonConsts.Collection.Empty < animationItemsCount)
                    {
                        //アニメーション画像がある場合は処理続行
                    }
                    else
                    {
                        //アニメーション画像が空の場合はメッセージボックスを表示して終了
                        this.ShowWarning(CommonLogger.Warn("アニメーション画像が存在しません"));
                        return;
                    }
                }

                //保存先取得
                Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
                dialog.Title = "アニメーション設定を保存します";
                dialog.FileName = ""; // Default file name
                dialog.DefaultExt = ".json"; // Default file extension
                dialog.Filter = "Matrix LED設定(*.json)|*.json|すべてのファイル (*.*)|*.*"; // Filter files by extension               

                //保存ダイアログ表示
                {
                    bool ret = dialog.ShowDialog(this) ?? false;
                    if (ret)
                    {
                        //選択した場合は処理続行
                    }
                    else
                    {
                        //選択しなかった場合は終了
                        return;
                    }
                }

                //保存パスを取得
                string savePath = dialog.FileName;

                //アニメーション設定保存
                {
                    MicroSign.Core.Models.Model.SaveAnimationResult ret = this.ViewModel.SaveAnimation(savePath);
                    if (ret.IsSuccess)
                    {
                        //成功の場合
                        this.ShowInfo(CommonLogger.Info("アニメーション画像設定を保存しました"));
                    }
                    else
                    {
                        //失敗した場合
                        this.ShowWarning(CommonLogger.Warn($"アニメーション画像設定を保存に失敗しました\n{ret.Message}"));
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("アニメーション設定保存で例外発生"), ex);
            }
        }

        /// <summary>
        /// アニメーション設定読込ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationLoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //読込先取得
                Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
                dialog.Title = "アニメーション設定を読込します";
                dialog.FileName = ""; // Default file name
                dialog.DefaultExt = ".json"; // Default file extension
                dialog.Filter = "アニメーション設定(*.json)|*.json|すべてのファイル (*.*)|*.*"; // Filter files by extension               

                //読込ダイアログ表示
                {
                    bool ret = dialog.ShowDialog(this) ?? false;
                    if (ret)
                    {
                        //選択した場合は処理続行
                    }
                    else
                    {
                        //選択しなかった場合は終了
                        return;
                    }
                }

                //読込パスを取得
                string loadPath = dialog.FileName;

                //アニメーション設定読込
                {
                    MainWindowViewModel.LoadAnimationResult ret = this.ViewModel.LoadAnimation(loadPath);
                    if(ret.IsSuccess)
                    {
                        //成功した場合は処理続行
                    }
                    else
                    {
                        //失敗した場合はメッセージボックス表示
                        this.ShowWarning(CommonLogger.Warn($"アニメーション設定の読込に失敗しました\n失敗理由：{ret.ErrorMessage}"));
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("アニメーション設定読込で例外発生"), ex);
            }
        }

        /// <summary>
        /// アニメーション画像更新ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //アニメーション数を確認
                {
                    int animationItemsCount = this.ViewModel.GetAnimationImagesCount();
                    if (CommonConsts.Collection.Empty < animationItemsCount)
                    {
                        //アニメーション画像がある場合は処理続行
                    }
                    else
                    {
                        //アニメーション画像が空の場合はメッセージボックスを表示して終了
                        this.ShowWarning(CommonLogger.Warn("アニメーション画像が存在しません"));
                        return;
                    }
                }

                //アニメーション画像コレクション更新確認
                this.NaviPanel.NavigationOverwrap(new MicroSign.Core.Views.Overlaps.ConfirmMessageBox("全アニメーション画像を更新します。\nよろしいですか?", this.Title), null, this.RefreshButton_Return);
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("アニメーション画像更新で例外発生"), ex);
            }
        }

        /// <summary>
        /// アニメーション画像更新ボタン確認結果
        /// </summary>
        /// <param name="callArgs">呼出引数(=null)</param>
        /// <param name="result">戻り値(=MicroSign.Core.Navigations.Enums.NavigationResultKind)</param>
        private void RefreshButton_Return(object? callArgs, object? result)
        {
            if (result is MicroSign.Core.Navigations.Enums.NavigationResultKind resultKind)
            {
                //確認結果により分岐
                switch (resultKind)
                {
                    case NavigationResultKind.Success:
                        //成功(=Yes)の場合アニメーション画像を更新
                        {
                            var ret = this.ViewModel.RefreshAnimationImage();
                            if (ret.IsSuccess)
                            {
                                //成功の場合
                                // >> メッセージがあるか確認
                                string message = ret.ErrorMessage;
                                bool isNull = string.IsNullOrEmpty(message);
                                if (isNull)
                                {
                                    //エラーメッセージが無い場合は成功
                                    this.ShowInfo(CommonLogger.Info("アニメーション画像の更新に成功しました"));
                                }
                                else
                                {
                                    //エラーメッセージがある場合は警告表示
                                    this.ShowWarning(CommonLogger.Warn($"アニメーション画像の更新でエラーが発生しました\n{message}"));
                                }
                            }
                            else
                            {
                                //エラーの場合はエラー表示
                                this.ShowWarning(CommonLogger.Warn($"アニメーション画像の更新に失敗しました\n{ret.ErrorMessage}"));
                            }
                        }
                        break;

                    default:
                        //それ以外の場合は何もしない
                        break;
                }
            }
            else
            {
                //無効の場合は何もせずに終了
                CommonLogger.Warn($"アニメーション画像更新確認の結果が判定できませんでした (ret={result})");
            }
        }

        /// <summary>
        /// アニメーション再生開始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayAnimationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //再生中判定
                {
                    bool isPlay = this.ViewModel.IsPlayingAnimation;
                    if (isPlay)
                    {
                        //再生中は無視する
                        this.ShowWarning(CommonLogger.Warn("アニメーション再生中です"));
                        return;
                    }
                    else
                    {
                        //再生していない場合は処理続行
                    }
                }

                //選択しているアニメーションを取得
                AnimationImageItem? selectAnimationItem = this.ViewModel.GetSelectAnimationImage();
                if (selectAnimationItem == null)
                {
                    //無効の場合は終了
                    return;
                }
                else
                {
                    //有効の場合は処理続行
                }

                //アニメーションタイマー開始
                {
                    //表示期間取得
                    double displayPeriod = selectAnimationItem.DisplayPeriod;
                    if (CommonConsts.Intervals.Zero < displayPeriod)
                    {
                        //有効の場合タイマー開始
                        this._AnimationTimer.Interval = TimeSpan.FromSeconds(displayPeriod);
                        this._AnimationTimer.Start();
                    }
                    else
                    {
                        //0以下の場合は停止の意味なのでメッセージ表示して終了
                        this.ShowWarning(CommonLogger.Warn("再生を開始できません\n選択されているアニメーション画像は再生停止です"));
                        return;
                    }
                }

                //アニメーション再生中に設定
                this.ViewModel.IsPlayingAnimation = true;
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("アニメーション再生で例外発生"), ex);
            }
        }

        /// <summary>
        /// アニメーション停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopAnimationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //無条件にアニメーションを停止します
                this.ViewModel.IsPlayingAnimation = false;

                //タイマー停止
                this._AnimationTimer.Stop();
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("アニメーション停止で例外発生"), ex);
            }
        }

        /// <summary>
        /// アニメーションタイマー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _AnimationTimer_Tick(object? sender, EventArgs e)
        {
            try
            {
                //タイマーを無条件に止める
                this._AnimationTimer.Stop();

                //アニメーション再生中か判定
                {
                    bool isPlay = this.ViewModel.IsPlayingAnimation;
                    if (isPlay)
                    {
                        //再生中なら処理続行
                    }
                    else
                    {
                        //停止中なら終了
                        return;
                    }
                }

                //★★★ 再生状態は最後に設定します (デフォルトは停止にします)
                bool isPlaying = false;
                try
                {
                    //選択アニメーション画像を取得
                    AnimationImageItem? selectAnimationItem = this.ViewModel.GetSelectAnimationImage();
                    if (selectAnimationItem == null)
                    {
                        //無効の場合は再生終了
                        return;
                    }
                    else
                    {
                        //有効の場合は処理続行
                    }

                    //選択アニメーション画像のインデックスを取得
                    int selectAnimationItemIndex = this.ViewModel.GetAnimationImageIndex(selectAnimationItem);
                    if (selectAnimationItemIndex < CommonConsts.Index.First)
                    {
                        //無効の場合は再生終了
                        return;
                    }
                    else
                    {
                        //有効の場合は処理続行
                    }

                    //アニメーション画像数を取得
                    int animationItemCount = this.ViewModel.GetAnimationImagesCount();

                    //次のアニメーション画像を取得するためにインデックスを+1する
                    int nextAnimationItemIndex = selectAnimationItemIndex + CommonConsts.Index.Step;
                    if (nextAnimationItemIndex < animationItemCount)
                    {
                        //インデックスが有効の場合はそのまま
                    }
                    else
                    {
                        //インデックスが無効の場合は先頭にする
                        nextAnimationItemIndex = CommonConsts.Index.First;
                    }

                    //次のアニメーション画像を取得
                    AnimationImageItem? nextAnimationItem = this.ViewModel.GetAnimationImage(nextAnimationItemIndex);
                    if (nextAnimationItem == null)
                    {
                        //無効の場合は再生終了
                        return;
                    }
                    else
                    {
                        //有効の場合は処理続行
                    }

                    //次のアニメーションを選択にする
                    this.ViewModel.SetSelectAnimationImage(nextAnimationItem);

                    //アニメーションタイマー開始
                    {
                        //表示期間取得
                        double displayPeriod = nextAnimationItem.DisplayPeriod;
                        if (CommonConsts.Intervals.Zero < displayPeriod)
                        {
                            //有効の場合タイマー開始
                            this._AnimationTimer.Interval = TimeSpan.FromSeconds(displayPeriod);
                            this._AnimationTimer.Start();

                            //★★★再生状態にします
                            isPlaying = true;
                        }
                        else
                        {
                            //0以下の場合は停止の意味なので再生終了
                            return;
                        }
                    }
                }
                finally
                {
                    //再生状態を設定
                    this.ViewModel.IsPlayingAnimation = isPlaying;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("アニメーション停止で例外発生"), ex);
            }
        }

        /// <summary>
        /// アニメーション画像アイテムダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationImageItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //ダブルクリックされたListViewItemを取得
                ListViewItem? item = sender as ListViewItem;
                if (item == null)
                {
                    this.ShowWarning(CommonLogger.Warn("ダブルクリックされたListViewItemが取得できませんでした"));
                    return;
                }
                else
                {
                    //有効なら処理続行
                    CommonLogger.Debug("ダブルクリックされたListViewItem取得");
                }

                //アニメーション画像アイテムを取得
                AnimationImageItem? animationItem = item.DataContext as AnimationImageItem;
                if (animationItem == null)
                {
                    this.ShowWarning(CommonLogger.Warn("ダブルクリックされたアニメーション画像が取得できませんでした"));
                    return;
                }
                else
                {
                    //有効なら処理続行
                    CommonLogger.Debug("ダブルクリックされたアニメーション画像取得");
                }

                //アニメーション画像アイテムが文字か判定
                {
                    AnimationImageType t = animationItem.ImageType;
                    switch(t)
                    {
                        case AnimationImageType.Text:
                            //テキストの場合は処理続行
                            CommonLogger.Debug("ダブルクリックされたアニメーション画像はテキスト");
                            break;

                        default:
                            //それ以外の場合はダブルクリックできない
                            this.ShowWarning(CommonLogger.Warn($"ダブルクリックされたアニメーション画像は編集できません (type={t})"));
                            return;
                    }
                }

                //アニメーション文字ページを表示
                {
                    //ViewModelから設定されているマトリクスLEDの情報を取得する
                    MainWindowViewModel vm = this.ViewModel;
                    int matrixLedWidth = vm.MatrixLedWidth;
                    int matrixLedHeight = vm.MatrixLedHeight;
                    string? animationName = vm.AnimationName;

                    //設定されている内容を取得
                    int selectFontSize = animationItem.SelectFontSize;
                    int selectFontColor = animationItem.SelectFontColor;
                    string? displayText = animationItem.DisplayText;

                    //アニメーション文字追加ページを表示
                    MicroSign.Core.Views.Pages.AnimationTextPage page = new MicroSign.Core.Views.Pages.AnimationTextPage(matrixLedWidth, matrixLedHeight, animationName, selectFontSize, selectFontColor, displayText);
                    this.NaviPanel.NavigationCall(page, animationItem, this.EditAnimationTextButton_Result);
                }
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("アニメーション画像アイテムダブルクリックで例外発生"), ex);
            }
        }

        /// <summary>
        /// アニメーション文字編集結果
        /// </summary>
        /// <param name="callArgs"></param>
        /// <param name="result"></param>
        private void EditAnimationTextButton_Result(object? callArgs, object? result)
        {
            try
            {
                if (result is AnimationTextPage.AnimationTextPageResult ret)
                {
                    //結果を判定
                    NavigationResultKind resultKind = ret.ResultKind;
                    switch (resultKind)
                    {
                        case NavigationResultKind.Success:
                            //成功の場合は処理続行
                            CommonLogger.Debug("アニメーション文字追加成功");
                            break;

                        case NavigationResultKind.Cancel:
                            //キャンセルの場合は何もせずに終了
                            CommonLogger.Info("アニメーション文字追加キャンセル");
                            return;

                        default:
                            //それ以外は失敗
                            this.ShowWarning(CommonLogger.Warn($"文字追加に失敗しました (理由={resultKind}')"));
                            return;
                    }

                    //ビットマップ取得
                    BitmapSource? image = ret.RenderBitmap;
                    if (image == null)
                    {
                        //取得出来なかった場合は終了
                        this.ShowError(CommonLogger.Error("文字画像が無効です"));
                        return;
                    }
                    else
                    {
                        //有効の場合は処理続行
                        CommonLogger.Info("文字画像有効");
                    }

                    //編集前のアニメーション画像アイテムを取得
                    AnimationImageItem? animationImage = callArgs as AnimationImageItem;
                    if(animationImage == null)
                    {
                        //取得出来なかった場合は終了
                        this.ShowError(CommonLogger.Error("アニメーション画像が無効です"));
                        return;
                    }
                    else
                    {
                        //有効の場合は処理続行
                        CommonLogger.Info("アニメーション画像有効");
                    }

                    //フォントサイズ取得
                    // >> サイズはいくつでもよい。再編集時にAnimationTextPageへ渡すだけ
                    int selectFontSize = ret.SelectFontSize;

                    //フォント色取得
                    // >> 色はいくつでもよい。再編集時にAnimationTextPageへ渡すだけ
                    int selectFontColor = ret.SelectFontColor;

                    //表示文字取得
                    // >> 表示文字はなんでもよい。再編集時にAnimationTextPageへ渡すだけ
                    string? displayText = ret.DisplayText;

                    //デフォルトの表示期間を取得
                    double defaultDisplayPeriod = this.ViewModel.DefaultDisplayPeriod;

                    //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
                    ////画像変換
                    //MicroSign.Core.Models.Model.ConvertImageResult convertImageResult = this.ViewModel.ConvertAnimationImage(image);
                    //if (convertImageResult.IsSuccess)
                    //{
                    //    //成功の場合は続行
                    //    CommonLogger.Debug($"画像変換成功");
                    //}
                    //else
                    //{
                    //    //変換失敗の場合は終了
                    //    this.ShowError(CommonLogger.Error("画像の変換に失敗しました"));
                    //    return;
                    //}
                    //
                    ////アニメーション画像を変更する
                    //animationImage.UpdateText(
                    //    selectFontSize,
                    //    selectFontColor,
                    //    displayText,
                    //    image,
                    //    convertImageResult.OutputData,
                    //    convertImageResult.PreviewImage
                    //    );
                    //----------
                    // >> プレビュー画像が不要になったので変換した画像も不要となりました
                    //アニメーション画像アイテムを更新
                    animationImage.UpdateText(
                        selectFontSize,
                        selectFontColor,
                        displayText,
                        image
                        );
                    //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで
                }
                else
                {
                    //結果が取得できない場合は何もしない
                    this.ShowWarning(CommonLogger.Warn("アニメーション文字編集結果が確認出来ません"));
                }
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("アニメーション文字編集結果で例外発生"), ex);
            }
        }

        /// 表示期間一括反映ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyAllDisplayPeriodButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //ViewModelから設定されている表示期間を取得する
                MainWindowViewModel vm = this.ViewModel;
                double defaultDisplayPeriod = vm.DefaultDisplayPeriod;

                //全アニメーションアイテムに表示期間を適用
                AnimationImageItemCollection items = vm.AnimationImages;
                int n = CommonUtils.GetCount(items);
                for (int i = CommonConsts.Index.First; i < n; i += CommonConsts.Index.Step)
                {
                    AnimationImageItem item = items[i];

                    //表示期間を設定
                    item.DisplayPeriod = defaultDisplayPeriod;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("表示期間一括反映ボタンクリックで例外発生"), ex);
            }
        }

        /// <summary>
        /// ListViewにドロップイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_PreviewDrop(object sender, DragEventArgs e)
        {
            try
            {
                //ドロップされた内容からファイルの一覧を取得
                GetDropImageFilesResult ret = this.GetDropImageFiles(e);
                if (ret.IsSucess)
                {
                    //成功の場合は画像ファイルが存在するので処理続行
                }
                else
                {
                    //失敗の場合は画像ファイルが存在しないので終了
                    this.ShowError(CommonLogger.Error(ret.Message));
                    return;
                }

                //ファイルの一覧を取得
                string[]? imagePaths = ret.DropImageFiles;

                //アニメーション画像追加
                this.AddAnimationImages(imagePaths);
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("ドロップ処理で例外発生"), ex);
            }
            finally
            {
                //処理済みに設定
                e.Handled = true;
            }
        }

        /// <summary>
        /// ListView上でドラッグ中イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_PreviewDragOver(object sender, DragEventArgs e)
        {
            try
            {
                //ドラッグ内容が有効か判定
                GetDropImageFilesResult ret = this.GetDropImageFiles(e);
                if(ret.IsSucess)
                {
                    //成功の場合は画像ファイルが存在するのでCopyを設定
                    e.Effects = DragDropEffects.Copy;
                }
                else
                {
                    //失敗の場合は画像ファイルが存在しないのでNone(処理できない)を設定
                    e.Effects = DragDropEffects.None;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("ドラッグオーバー処理で例外発生"), ex);
            }
            finally
            {
                //処理済みに設定
                e.Handled = true;
            }
        }

        /// <summary>
        /// 画像読込ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GifLoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //画像パスを取得
                string? imagePath = this.SelectGifPath("GIF読込");
                {
                    bool isNull = string.IsNullOrEmpty(imagePath);
                    if (isNull)
                    {
                        //取得出来なかった場合は終了
                        return;
                    }
                    else
                    {
                        //有効の場合は処理続行
                    }
                }

                //GIFアニメーション読込
                {
                    var ret = this.ViewModel.LoadGifAnimation(imagePath);
                    if (ret.IsSuccess)
                    {
                        //成功した場合は処理続行
                    }
                    else
                    {
                        //失敗した場合はメッセージボックス表示
                        this.ShowWarning(CommonLogger.Warn($"GIFアニメーション設定の読込に失敗しました\n失敗理由：{ret.ErrorMessage}"));
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(CommonLogger.Error("読込で例外発生"), ex);
            }
        }

    }
}
