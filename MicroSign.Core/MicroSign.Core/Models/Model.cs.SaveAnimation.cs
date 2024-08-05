using MicroSign.Core.Models.AnimationSaveSettings;
using MicroSign.Core.SerializerUtils;
using MicroSign.Core.ViewModels;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// アニメーション保存
        /// </summary>
        /// <param name="path">保存先パス</param>
        /// <param name="name">アニメーション名</param>
        /// <param name="animationDatas">アニメーション画像コレクション</param>
        /// <param name="matrixLedWidth">マトリクスLED横幅</param>
        /// <param name="matrixLedHeight">マトリクスLED縦幅</param>
        /// <param name="matrixLedBrightness">マトリクスLED明るさ</param>
        /// <param name="defaultDisplayPeriod">デフォルト表示期間(秒)</param>
        /// <returns></returns>
        public (bool IsSuccess, string ErrorMessage) SaveAnimation(string path, string? name, AnimationImageItemCollection animationDatas, int matrixLedWidth, int matrixLedHeight, int matrixLedBrightness, double defaultDisplayPeriod)
        {
            //保存先パス有効判定
            {
                bool isNull = string.IsNullOrEmpty(path);
                if(isNull)
                {
                    //無効の場合は終了
                    return (false, "保存先パスが無効です");
                }
                else
                {
                    //有効の場合は処理続行
                }
            }

            //アニメーション画像データ数取得
            int animationDataCount = CommonUtils.GetCount(animationDatas);
            if(CommonConsts.Collection.Empty < animationDataCount)
            {
                //有効の場合は処理続行
            }
            else
            {
                //無効の場合は終了
                return (false, "アニメーション画像が空です");
            }

            //保存パスのディレクト入り部分を取得
            // >> 基準パスとします
            string? baseDir = System.IO.Path.GetDirectoryName(path);

            //保存用のデータを作成
            AnimationSaveSetting animationSaveSetting = new AnimationSaveSetting();
            if(name == null)
            {
                //無効の場合は何もしない(=デフォルト値)
            }
            else
            {
                bool isNull = string.IsNullOrEmpty (path);
                if(isNull)
                {
                    //無効の場合は何もしない(=デフォルト値)
                }
                else
                {
                    //有効の場合は設定
                    animationSaveSetting.Name = name;
                }
            }

            //マトリクスLEDの情報を設定
            animationSaveSetting.MatrixLedWidth = matrixLedWidth;
            animationSaveSetting.MatrixLedHeight = matrixLedHeight;
            animationSaveSetting.MatrixLedBrightness = matrixLedBrightness;

            //デフォルトの表示期間を設定
            animationSaveSetting.DefaultDisplayPeriod = defaultDisplayPeriod;

            //アニメーション画像アイテムコレクションを変換
            AnimationSaveDataCollection animationSaveDatas = animationSaveSetting.AnimationDatas;
            for (int i = CommonConsts.Index.First; i < animationDataCount; i += CommonConsts.Index.Step)
            {
                AnimationImageItem item = animationDatas[i];
                if(item == null)
                {
                    //無効の場合は無視する
                }
                else
                {
                    //有効の場合はコピーする
                    // >> 画像パスを取得
                    string? imagePath = item.Path;

                    // >> 相対パスに変換する
                    string? relativePath = CommonUtils.GetRelativePath(baseDir, imagePath);

                    // >> 保存
                    AnimationSaveData saveDatsa = new AnimationSaveData()
                    {
                        ImageType = item.ImageType,
                        ImagePath = relativePath,
                        DisplayPeriod = item.DisplayPeriod,
                        Kind = item.Kind,
                        RectX = item.RectX,
                        RectY = item.RectY,
                        RectWidth = item.RectWidth,
                        RectHeight = item.RectHeight,
                        OffsetX = item.OffsetX,
                        OffsetY = item.OffsetY,
                        TransparentRGB = item.TransparentRGB,
                        SelectFontSize = item.SelectFontSize,
                        SelectFontColor = item.SelectFontColor,
                        DisplayText = item.DisplayText,
                    };

                    // >> リストに追加
                    animationSaveDatas.Add(saveDatsa);
                }
            }

            //保存する
            {
                bool ret = JsonUtil.Save(path, animationSaveSetting);
                if(ret)
                {
                    //成功した場合は処理続行
                }
                else
                {
                    //失敗した場合は終了
                    return (false, "保存に失敗しました");
                }
            }


            //ここまで来たら成功
            return (true, string.Empty);
        }
    }
}
