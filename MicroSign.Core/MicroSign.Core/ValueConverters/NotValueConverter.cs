using System;
using System.Windows.Data;

namespace MicroSign.Core.ValueConverters
{
    /// <summary>
    /// Bool値の逆を返す
    /// </summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    public class NotValueConverter : IValueConverter
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
            //BOOL値でTrueの場合
            bool v = ValueConverterUtils.ToBool(value);
            if (v)
            {
                //Trueの場合はFalseを返す
                return false;
            }
            else
            {
                //それ以外は全てTrueを返す
                return true;
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
