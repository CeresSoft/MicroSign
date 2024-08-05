using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace MicroSign.Core.ValueConverters
{
    /// <summary>
    /// EnumをVisibilityに変換
    /// </summary>
    /// <remarks>
    /// プロパティに「Enum名=Visible; ... ;Enum名=Collapsed;Hidden」(最後のHiddenはその他のEnum値はHiddenになる)のように記述する
    /// [定義例]
    /// Value="{Binding MainAlarmKind, Converter={StaticResource EnumMatchVisibilityValueConverter}, ConverterParameter=Force:Visible;Hidden, Mode=OneWay}"
    /// </remarks>
    [ValueConversion(typeof(Enum), typeof(Visibility))]
    public class EnumMatchVisibilityValueConverter : IValueConverter
    {
        /// <summary>
        /// 変換
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility result = ValueConverterUtils.ToMatchVisibility(value, parameter);
            return result;
        }

        /// <summary>
        /// 逆変換
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //OneWay用なので実装不要
            throw new NotImplementedException();
        }
    }
}
