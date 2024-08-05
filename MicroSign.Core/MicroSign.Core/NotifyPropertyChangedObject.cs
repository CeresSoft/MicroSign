using System.ComponentModel;

namespace MicroSign.Core
{
    /// <summary>
    /// INotifyPropertyChanged共通
    /// </summary>
    public abstract class NotifyPropertyChangedObject : INotifyPropertyChanged
	{
		/// <summary>
		/// 初期値
		/// </summary>
		/// <remarks>
		/// 2021.02.25:CS)杉原
		/// NotifyPropertyChangedObjectの派生クラス(主にViewModelとModel)で
		/// ViewModel作成Excelから張り付けたときに「new partial class InitializeValues」
		/// と書くのだが、ViewModelBaseの親にInitializeValuesが無いとVisualStudioから
		/// 隠すクラスは無い警告が出てしまうので内容は無いがInitializeValuesを記述します
		/// </remarks>
		public static partial class InitializeValues
		{
		}

		/// <summary>
		/// プロパティ名
		/// </summary>
		/// <remarks>
		/// 2021.02.25:CS)杉原
		/// NotifyPropertyChangedObjectの派生クラス(主にViewModelとModel)で
		/// ViewModel作成Excelから張り付けたときに「new partial class PropertyNames」
		/// と書くのだが、ViewModelBaseの親にPropertyNamesが無いとVisualStudioから
		/// 隠すクラスは無い警告が出てしまうので内容は無いがPropertyNamesを記述します
		/// </remarks>
		public static partial class PropertyNames
		{
		}

		/// <summary>
		/// プロパティ値が変更されたことを通知
		/// </summary>
		public event PropertyChangedEventHandler? PropertyChanged;

		/// <summary>
		/// PropertyChangedイベント発生
		/// </summary>
		/// <param name="propertyName">変更されたプロパティの名前(CallerMemberName属性を指定しているので自動設定される)</param>
		protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
		{
            //プロパティ変更イベント発行
            {
				PropertyChangedEventHandler? handler = this.PropertyChanged;
				if (handler != null)
				{
					handler(this, new PropertyChangedEventArgs(propertyName));
				}
			}
		}
	}
}
