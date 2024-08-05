using System.Runtime.CompilerServices;

namespace MicroSign.Core.ViewModels
{
    public partial class MainWindowViewModel : NotifyPropertyChangedObject
    {
        /// <summary>
        /// モデル
        /// </summary>
        /// <remarks>
        /// 2023.11.23:CS)土田:Core.dllに分離するにあたり、ViewModelからModelへの参照を追加
        ///  >> モデルインスタンスの実装を変えるかもしれないので、プロパティを経由する形にしています
        /// </remarks>
        public Models.Model Model
        {
            get
            {
                return Models.Model.Instance;
            }
        }

        protected override void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            base.RaisePropertyChanged(propertyName);

            //追加の処理
            switch(propertyName)
            {
                case MainWindowViewModel.PropertyNames.SelectedAnimationImageItem:
                    //アニメーション画像の選択が変化したら画面に反映
                    {
                        AnimationImageItem? item = this.SelectedAnimationImageItem;
                        if(item == null)
                        {
                            //無効の場合は何もしない
                        }
                        else
                        {
                            //読込画像に設定し表示する
                            this.LoadImage = item.Image;
                        }
                    }
                    break;

                default:
                    //それ以外は何もしない
                    break;
            }
        }
    }
}
