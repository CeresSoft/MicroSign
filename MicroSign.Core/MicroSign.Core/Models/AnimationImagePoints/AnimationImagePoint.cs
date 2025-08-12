using MicroSign.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models.AnimationImagePoints
{
    /// <summary>
    /// アニメーション画像位置
    /// </summary>
    /// <remarks>
    /// 重複している画像はマージ画像に1つしか出力しないしないようにするためのクラス
    /// </remarks>
    public class AnimationImagePoint
    {
        /// <summary>
        /// 画像配置場所X
        /// </summary>
        public int X { get; protected set; } = (int)CommonConsts.Points.Zero.X;

        /// <summary>
        /// 画像配置場所Y
        /// </summary>
        public int Y { get; protected set; } = (int)CommonConsts.Points.Zero.Y;

        //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する >>>>> ここから
        ///// <summary>
        ///// 画像パスリスト
        ///// </summary>
        //public List<string> ImagePaths { get; protected set; } = new List<string>();
        //----------
        /// <summary>
        /// アニメーション画像アイテムリスト
        /// </summary>
        public List<AnimationImageItem> ImageItems { get; protected set; } = new List<AnimationImageItem>();
        //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する <<<<< ここまで

        /// <summary>
        /// 出力画像
        /// </summary>
        public byte[] OutputData { get; protected set; }

        /// <summary>
        /// 元画像
        /// </summary>
        public BitmapSource SourceImage { get; protected set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <!--<param name="imagePath">アニメーション画像アイテム</param>-->
        /// <param name="animationImageItem">アニメーション画像アイテム</param>
        /// <param name="outputData">出力データ</param>
        /// <param name="sourceImage">元画像</param>
        public AnimationImagePoint(/*string imagePath,*/ AnimationImageItem animationImageItem, byte[] outputData, BitmapSource sourceImage)
        {
            //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する >>>>> ここから
            //this.ImagePaths.Add(imagePath);
            //----------
            ImageItems.Add(animationImageItem);
            //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する <<<<< ここまで
            OutputData = outputData;
            SourceImage = sourceImage;
        }

        //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する >>>>> ここから
        ///// <summary>
        ///// パスが含まれているか判定
        ///// </summary>
        ///// <param name="path"></param>
        ///// <returns></returns>
        //public bool IsContainPath(string path)
        //{
        //    if (path == null)
        //    {
        //        //パスが無効の場合は存在しない終了
        //        return false;
        //    }
        //    else
        //    {
        //        bool isNull = string.IsNullOrEmpty(path);
        //        if (isNull)
        //        {
        //            //パスが無効の場合は存在しない
        //            return false;
        //        }
        //        else
        //        {
        //            //画像パスが有効の場合は検索して結果を返す
        //            return this.ImagePaths.Any(x => x == path);
        //        }
        //    }
        //}
        //----------
        //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する <<<<< ここまで

        /// <summary>
        /// アニメーション画像アイテムが含まれているか判定
        /// </summary>
        /// <param name="animationImageItem">検索するアニメーション画像アイテム</param>
        /// <returns></returns>
        public bool IsContainAnimationImageItem(AnimationImageItem? animationImageItem)
        {
            if (animationImageItem == null)
            {
                //無効の場合は存在しない終了
                return false;
            }
            else
            {
                //有効の場合は検索して結果を返す
                return ImageItems.Any(x => x == animationImageItem);
            }
        }

        /// <summary>
        /// 同じ出力データか判定
        /// </summary>
        /// <param name="outputData"></param>
        /// <returns></returns>
        public bool IsSameData(byte[] outputData)
        {
            //出力データが有効か判定
            if (outputData == null)
            {
                //無効の場合は無条件に異なる(=false)
                return false;
            }
            else
            {
                //有効の場合は処理続行
            }

            //配列が同じか判定
            return outputData.SequenceEqual(this.OutputData);
        }

        //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する >>>>> ここから
        ///// <summary>
        ///// パスを追加
        ///// </summary>
        ///// <param name="path"></param>
        //public void AddPath(string path)
        //{
        //    this.ImagePaths.Add(path);
        //}
        //----------
        //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する <<<<< ここまで

        //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する >>>>> ここから
        //----------
        /// <summary>
        /// パスを追加
        /// </summary>
        /// <param name="animationImageItem"></param>
        public void AddAnimationImageItem(AnimationImageItem animationImageItem)
        {
            ImageItems.Add(animationImageItem);
        }
        //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する <<<<< ここまで

        /// <summary>
        /// 位置を設定
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
