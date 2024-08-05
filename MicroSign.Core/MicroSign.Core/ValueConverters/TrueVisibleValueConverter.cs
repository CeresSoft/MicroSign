using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace MicroSign.Core.ValueConverters
{
    /// <summary>
    /// True時に表示に変換
    /// </summary>
    /// <remarks>パラメータにHidden指定するとCollapsedではなくHiddenを返します</remarks>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class TrueVisibleValueConverter : IValueConverter
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
            //2015.10.02:杉原:Collapsed対応
            ////BOOL以外の場合
            //if (!(value is bool))
            //{
            //	//非表示にする
            //	return Visibility.Collapsed;
            //}
            ////BOOL値がFalseの場合
            //bool v = (bool)value;
            //if (!v)
            //{
            //	//非表示にする
            //	return Visibility.Collapsed;
            //}
            ////ここまで来たら終了
            //return Visibility.Visible;

            //BOOL値でTrueの場合
            bool v = ValueConverterUtils.ToBool(value);
            if (v)
            {
                //表示にする
                return Visibility.Visible;
            }
            else
            {
                //非表示の種類をパラメータから判定(標準はCollapsed)
                return ValueConverterUtils.ToHiddenOrCllapsed(parameter);
            }
            //2015.10.02:杉原:Collapsed対応
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
