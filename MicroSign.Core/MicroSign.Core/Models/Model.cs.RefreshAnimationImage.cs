using MicroSign.Core.ViewModels;
using System.Text;
using System.Windows.Media.Imaging;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// アニメーション画像リフレッシュ
        /// </summary>
        /// <returns></returns>
        /// <param name="animationImages">画像を更新するアニメーション画像コレクション</param>
        public (bool IsSuccess, string ErrorMessage) RefreshAnimationImage(AnimationImageItemCollection? animationImages)
        {
            if (animationImages == null)
            {
                //無効なら終了
                return (false,"アニメーション画像コレクションが無効です");
            }
            else
            {
                //有効の場合処理続行
            }

            //要素数を取得
            StringBuilder sb = new StringBuilder(CommonConsts.Text.STRING_BUILDER_CAPACITY);
            int n = animationImages.Count;
            for (int i = CommonConsts.Index.First; i < n; i += CommonConsts.Index.Step)
            {
                //アニメーション画像を取得
                AnimationImageItem? animationImage = animationImages[i];
                if(animationImage == null)
                {
                    //無効の場合は何もしない
                    if(CommonConsts.Collection.Empty < sb.Length)
                    {
                        //既に文字がある場合は改行を追加
                        sb.AppendLine();
                    }
                    else
                    {
                        //文字列が無い場合はそのまま
                    }
                    sb.Append("アニメーション画像[No.").Append(CommonConsts.Index.ToCollection(i)).Append("]が無効です");
                }
                else
                {
                    //有効の場合
                    // >> パスを取得
                    // >> >> nullでも良い。次の画像取得でエラーチェックする
                    string? imagePath = animationImage.Path;
                    // >> 画像を取得
                    BitmapSource? bmp = this.GetImage(imagePath);
                    if (bmp == null)
                    {
                        //取得出来ない場合は無視する
                        if (CommonConsts.Collection.Empty < sb.Length)
                        {
                            //既に文字がある場合は改行を追加
                            sb.AppendLine();
                        }
                        else
                        {
                            //文字列が無い場合はそのまま
                        }
                        sb.Append("アニメーション画像[No.").Append(CommonConsts.Index.ToCollection(i)).Append("]の画像パスに対応する画像がありません\npath='").Append(imagePath).Append("'").AppendLine();
                    }
                    else
                    {
                        //取得できた場合は設定する
                        animationImage.Image = bmp;
                    }
                }
            }

            //終了
            // >> エラーメッセージがあっても成功で返す(警告表示にする)
            return (true, sb.ToString());
        }
    }
}
