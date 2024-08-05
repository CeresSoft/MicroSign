using System;
using System.Windows;
using System.Windows.Data;

namespace MicroSign.Core.ValueConverters
{
    /// <summary>
    /// not NULLの場合表示する
    /// </summary>
    /// <remarks>パラメータにHiddenを指定した場合はClappsedではなくHiddenを返します</remarks>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class NotNullVisibleValueConverter : IValueConverter
    {
		/// <summary>
		/// 変換
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			//ValueがNULLの場合
			if (value == null)
			{
				//非表示の種類をパラメータから判定(標準はCollapsed)
				return ValueConverterUtils.ToHiddenOrCllapsed(parameter);
			}
			else
			{
				//表示
				return Visibility.Visible;
			}
		}

		/// <summary>
		/// 逆変換
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			//OneWay用なので実装不要
			throw new NotImplementedException();
		}
	}
}
