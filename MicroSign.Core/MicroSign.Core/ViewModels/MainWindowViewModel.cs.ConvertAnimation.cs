using MicroSign.Core.Models.PanelConfigs;

namespace MicroSign.Core.ViewModels
{
    partial class MainWindowViewModel
    {
        /// <summary>
        /// アニメーション変換結果
        /// </summary>
        /// <remarks>
        /// 2025.08.12:CS)杉原:パレット処理の流れを変更
        /// </remarks>
        public struct ConvertAnimationResult
        {
            /// <summary>
            /// 成功フラグ
            /// </summary>
            public readonly bool IsSuccess;

            /// <summary>
            /// メッセージ
            /// </summary>
            public readonly string? Message;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="isSuccess"></param>
            /// <param name="message"></param>
            private ConvertAnimationResult(bool isSuccess, string? message)
            {
                this.IsSuccess = isSuccess;
                this.Message = message;
            }

            /// <summary>
            /// 失敗
            /// </summary>
            /// <param name="message"></param>
            /// <returns></returns>
            public static ConvertAnimationResult Failed(string message)
            {
                ConvertAnimationResult result = new ConvertAnimationResult(false, message);
                return result;
            }

            /// <summary>
            /// 成功
            /// </summary>
            /// <returns></returns>
            public static ConvertAnimationResult Success()
            {
                ConvertAnimationResult result = new ConvertAnimationResult(true, null);
                return result;
            }
        }

        /// <summary>
        /// アニメーション変換
        /// </summary>
        /// <returns>アニメーション変換結果</returns>
        public ConvertAnimationResult ConvertAnimation()
        {
            //クラス名
            string? name = this.Name;

            //閾値取得
            int redThreshold = this.RedThreshold;
            int greenThreshold = this.GreenThreshold;
            int blueThreshold = this.BlueThreshold;

            //フォーマット
            FormatKinds formatKind = this.FormatKind;

            //マトリクスLEDの設定値取得
            int matrixLedWidth = this.MatrixLedWidth;
            int matrixLedHeight = this.MatrixLedHeight;
            int matrixLedBrightness = this.MatrixLedBrightness;

            //アニメーション画像コレクション
            // >> コンストラクタで生成しているのでnullチェック不要
            AnimationImageItemCollection animationImages = this.AnimationImages;

            //変換
            Models.Model.ConvertResult ret = this.Model.ConvertAnimation(name, formatKind, animationImages, redThreshold, greenThreshold, blueThreshold, matrixLedWidth, matrixLedHeight, matrixLedBrightness);
            this.ConvertImage = ret.ConvertImage;
            //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
            //this.Code = ret.Code;
            //----------
            // >> 変換コードは無くなりました
            //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで

            //終了
            //2025.08.12:CS)杉原:パレット処理の流れを変更 >>>>> ここから
            //return (ret.IsSuccess, ret.Code);
            //----------
            if (ret.IsSuccess)
            {
                //成功の場合は処理続行
            }
            else
            {
                //失敗の場合は失敗で終了する
                string msg = ret.Message ?? "不明なエラー";
                return ConvertAnimationResult.Failed(msg);
            }

            //ここまで来たら成功で終了
            return ConvertAnimationResult.Success();
            //2025.08.12:CS)杉原:パレット処理の流れを変更 <<<<< ここまで
        }
    }
}
