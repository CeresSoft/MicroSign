using System.Runtime.Serialization;

namespace MicroSign.Core.ViewModels
{
    /// <summary>
    /// アニメーション画像アイテム
    /// </summary>
    [DataContract]
    public partial class AnimationImageItem : NotifyPropertyChangedObject
    {
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>FromImageFile()かFromText()以外で生成できないようにprivateにします</remarks>
        private AnimationImageItem() { }

    }
}
