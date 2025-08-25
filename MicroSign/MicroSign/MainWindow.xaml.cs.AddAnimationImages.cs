using MicroSign.Core;
using MicroSign.Core.ViewModels;
using System.Linq;
using System.Windows.Media.Imaging;

namespace MicroSign
{
    partial class MainWindow
    {
        /// <summary>
        /// アニメーション画像追加
        /// </summary>
        /// <param name="imagePaths">追加するアニメーション画像一覧</param>
        protected void AddAnimationImages(string[]? imagePaths)
        {
            //アニメーション画像一覧有効判定
            if (imagePaths == null)
            {
                //無効の場合は終了
                CommonLogger.Warn("追加するアニメーション画像一覧が無効です");
                return;
            }
            else
            {
                //有効の場合は処理続行
            }

            //ファイル数を取得
            int count = imagePaths.Length;
            if (CommonConsts.Collection.Empty < count)
            {
                //1件以上場合は処理続行
            }
            else
            {
                //0件の場合は終了
                CommonLogger.Warn("追加するアニメーション画像一覧が空です");
                return;
            }

            //デフォルトの表示期間を取得
            double defaultDisplayPeriod = this.ViewModel.DefaultDisplayPeriod;

            //2024.04.30:CS)杉原:リリース向けの機能追加 >>>>> ここから
            //----------
            // >> そのうちスクロール機能を入れようと思って画像サイズは2の累乗であればなんでも良い仕様にしていましたが
            // >> パネルが128x32の設定なのに64x64の画像を追加して変換できてしまうのは少々わかりにくい
            // >> とりあえずパネルのサイズと異なるサイズの画像が有った場合は変換できないようにします
            //設定されているパネルサイズを取得
            int panelWidth = this.ViewModel.MatrixLedWidth;
            int panelHeight = this.ViewModel.MatrixLedHeight;
            //2024.04.30:CS)杉原:リリース向けの機能追加 <<<<< ここまで


            //ファイル名でソートしながら読込
            IOrderedEnumerable<string> sortedImagePaths = imagePaths.OrderBy(x => x);
            foreach (string imagePath in sortedImagePaths)
            {
                //拡張子を取得
                string? ext = System.IO.Path.GetExtension(imagePath);
                // >> 比較しやすいように小文字化
                string? extLower = CommonUtils.ToSafeLower(ext);

                //画像拡張子判定
                switch (extLower)
                {
                    case CommonConsts.File.GifExtension:
                        //GIFアニメーション追加
                        this.ViewModel.LoadGifAnimation(imagePath);
                        break;

                    default:
                        //通常のアニメーション画像追加
                        this.AddAnimationImagesImpl(imagePath, defaultDisplayPeriod, panelWidth, panelHeight);
                        break;
                }
            }
        }

        /// <summary>
        /// アニメーション画像追加
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="defaultDisplayPeriod"></param>
        /// <param name="panelWidth"></param>
        /// <param name="panelHeight"></param>
        private void AddAnimationImagesImpl(string imagePath, double defaultDisplayPeriod, int panelWidth, int panelHeight)
        {
            //画像を読込
            BitmapImage? image = this.ViewModel.GetImage(imagePath);
            if (image == null)
            {
                //取得出来なかった場合は終了
                this.ShowError(CommonLogger.Error($"画像ファイルの読込に失敗しました\npath='{imagePath}'"));
                return;
            }
            else
            {
                //有効の場合は処理続行
                CommonLogger.Info($"画像ファイル読込\npath='{imagePath}'");
            }

            //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
            ////2023.11.30:CS)土田:プレビュー表示の改造 >>>>> ここから
            ////----------
            ////読み込みと同時に変換する
            //MicroSign.Core.Models.Model.ConvertImageResult convertImageResult = this.ViewModel.ConvertAnimationImage(image);
            //if (convertImageResult.IsSuccess)
            //{
            //    //成功の場合は続行
            //    CommonLogger.Debug($"画像ファイル変換成功");
            //}
            //else
            //{
            //    //変換失敗の場合は終了
            //    this.ShowError(CommonLogger.Error($"画像ファイルの変換に失敗しました\npath='{imagePath}'"));
            //    return;
            //}
            ////2023.11.30:CS)土田:プレビュー表示の改造 <<<<< ここまで
            //
            ////アニメーション画像アイテムを生成
            ////2023.12.24:CS)杉原:アニメーション画像アイテム種類追加 >>>>> ここから
            ////AnimationImageItem animationImageItem = new AnimationImageItem()
            ////{
            ////    Name = System.IO.Path.GetFileName(imagePath),
            ////    Path = imagePath,
            ////    Image = image,
            ////    DisplayPeriod = defaultDisplayPeriod,
            ////    //2023.11.30:CS)土田:プレビュー表示の改造 >>>>> ここから
            ////    //----------
            ////    OutputData = convertImageResult.OutputData,
            ////    PreviewImage = convertImageResult.PreviewImage,
            ////    //2023.11.30:CS)土田:プレビュー表示の改造 <<<<< ここまで
            ////};
            ////----------
            //AnimationImageItem animationImageItem = AnimationImageItem.FromImageFile(
            //    defaultDisplayPeriod,
            //    imagePath,
            //    image,
            //    convertImageResult.OutputData,
            //    convertImageResult.PreviewImage
            //    );
            ////2023.12.24:CS)杉原:アニメーション画像アイテム種類追加 <<<<< ここまで
            //----------
            // >> プレビュー画像が不要になったので変換した画像も不要となりました
            //アニメーション画像アイテムを生成
            AnimationImageItem animationImageItem = AnimationImageItem.FromImageFile(
                defaultDisplayPeriod,
                imagePath,
                image
                );
            //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで

            //2024.04.30:CS)杉原:リリース向けの機能追加 >>>>> ここから
            //----------
            // >> そのうちスクロール機能を入れようと思って画像サイズは2の累乗であればなんでも良い仕様にしていましたが
            // >> パネルが128x32の設定なのに64x64の画像を追加して変換できてしまうのは少々わかりにくい
            // >> とりあえずパネルのサイズと異なるサイズの画像が有った場合は変換できないようにします
            {
                //アニメーション画像が有効の場合適合するか判定
                bool isFit = animationImageItem.IsFit(panelWidth, panelHeight);
                if (isFit)
                {
                    //適合した場合は処理続行
                }
                else
                {
                    //適合しない場合は失敗にする
                    this.ShowWarning(CommonLogger.Warn($"パネルサイズに適合しない画像です\npath='{imagePath}'"));
                    return;
                }
            }
            //2024.04.30:CS)杉原:リリース向けの機能追加 <<<<< ここまで

            //リストに追加
            this.ViewModel.AddAnimationImage(animationImageItem);
        }
    }
}
