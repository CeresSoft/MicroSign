using MicroSign.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models.AnimationImagePoints
{
    /// <summary>
    /// アニメーション画像位置コレクション
    /// </summary>
    /// <remarks>
    /// 重複している画像はマージ画像に1つしか出力しないしないようにするためのクラス。
    /// Dictionaryで作成しようとしたが、Dictionaryだと順番が保持されないのでListにしました
    /// </remarks>
    public class AnimationImagePointCollection : List<AnimationImagePoint>
    {
        /// <summary>
        /// アニメーション画像を追加
        /// </summary>
        /// <!--<param name="imagePath">画像パス</param>-->
        /// <param name="animationImageItem">アニメーション画像アイテム</param>
        /// <param name="outputData">出力データ</param>
        /// <param name="sourceImage">元画像</param>
        public void AddAnimationImage(/*string? imagePath,*/AnimationImageItem? animationImageItem, byte[] outputData, BitmapSource sourceImage)
        {
            //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する >>>>> ここから
            ////画像パス有効判定
            //if (imagePath == null)
            //{
            //    //無効の場合は何もせずに終了
            //    return;
            //}
            //else
            //{
            //    bool isNull = string.IsNullOrEmpty(imagePath);
            //    if (isNull)
            //    {
            //        //無効の場合は何もせずに終了
            //        return;
            //    }
            //    else
            //    {
            //        //有効の場合は処理続行
            //    }
            //}
            //----------
            if (animationImageItem == null)
            {
                //無効の場合は何もせずに終了
                return;
            }
            else
            {
                //有効の場合は処理続行
            }
            //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する <<<<< ここまで

            //出力データが有効か判定
            if (outputData == null)
            {
                //無効の場合は何もせずに終了
                return;
            }
            else
            {
                //有効の場合は処理続行
            }

            //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する >>>>> ここから
            ////同じパスが登録されているか判定
            //{
            //    AnimationImagePoint? existAnimationImagePoint = this.FindAnimationImagePoint(imagePath);
            //    if (existAnimationImagePoint == null)
            //    {
            //        //重複しない場合は処理続行
            //    }
            //    else
            //    {
            //        //存在する場合は何もしないで終了
            //        return;
            //    }
            //}
            //----------
            //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する <<<<< ここまで

            //同じ出力データが存在するか判定
            {
                AnimationImagePoint? existAnimationImagePoint = this.FirstOrDefault(x => x.IsSameData(outputData));
                if (existAnimationImagePoint == null)
                {
                    //重複しない場合は処理続行
                }
                else
                {
                    //存在する場合
                    //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する >>>>> ここから
                    //// >> パスを追加する
                    //existAnimationImagePoint.AddPath(imagePath);
                    //----------
                    // >> アニメーション画像アイテムを登録する
                    existAnimationImagePoint.AddAnimationImageItem(animationImageItem);
                    //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する <<<<< ここまで

                    // >> 終了
                    return;
                }
            }

            //インスタンス生成
            //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する >>>>> ここから
            //AnimationImagePoint point = new AnimationImagePoint(imagePath, outputData, sourceImage);
            //----------
            AnimationImagePoint point = new AnimationImagePoint(animationImageItem, outputData, sourceImage);
            //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する <<<<< ここまで

            //リストに追加
            Add(point);
        }

        //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する >>>>> ここから
        ///// <summary>
        ///// 画像パスから一致するアニメーション画像位置を返す
        ///// </summary>
        ///// <param name="imagePath"></param>
        ///// <returns></returns>
        //public AnimationImagePoint? FindAnimationImagePoint(string? imagePath)
        //{
        //    if(imagePath == null)
        //    {
        //        //無効の場合は終了
        //        return null;
        //    }
        //    else
        //    {
        //        bool isNull = string.IsNullOrEmpty(imagePath);
        //        if (isNull)
        //        {
        //            //画像パスが無効の場合は処理続行
        //            return null;
        //        }
        //        else
        //        {
        //            //画像パスが有効の場合は検索して結果を返す
        //            return this.FirstOrDefault(x => x.IsContainPath(imagePath));
        //        }
        //    }
        //}
        //----------
        //2023.12.24:CS)杉原:テキストの場合画像パスが無いので出力データだけで判定する <<<<< ここまで

        /// <summary>
        /// アニメーション画像アイテムから一致するアニメーション画像位置を返す
        /// </summary>
        /// <param name="animationImageItem">検索するアニメーション画像アイテム</param>
        /// <returns></returns>
        public AnimationImagePoint? FindAnimationImagePoint(AnimationImageItem? animationImageItem)
        {
            if (animationImageItem == null)
            {
                //無効の場合は終了
                return null;
            }
            else
            {
                //画像パスが有効の場合は検索して結果を返す
                return this.FirstOrDefault(x => x.IsContainAnimationImageItem(animationImageItem));
            }
        }
    }
}
