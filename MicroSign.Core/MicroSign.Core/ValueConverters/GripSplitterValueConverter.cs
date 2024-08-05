using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MicroSign.Core.ValueConverters
{
    public class GripSplitterValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                //入力値がdoubleか判定
                if (value is double)
                {
                    //処理続行
                }
                else
                {
                    //無効の場合は制限なしの無限大を返す
                    return double.PositiveInfinity;
                }

                //入力値をdoubleに変換
                double v = (double)value;

                //パラメータ判定
                double d = 0;
                if (parameter == null)
                {
                    //パラメータが指定されていない場合何もしない
                }
                else
                {
                    //パラメータが指定されている場合
                    string? t = parameter.ToString();    //文字列化
                    bool ret = double.TryParse(t, out d);   //数値化
                    if (ret)
                    {
                        //成功した場合そのまま
                    }
                    else
                    {
                        //失敗した場合は0にする
                        d = 0;
                    }
                }

                //サイズを計算
                double result = v - d;
                if (result < 0)
                {
                    //0以下になった場合は0に制限する
                    result = 0;
                }
                else
                {
                    //0以上ならそのまま
                }

                //終了
                return result;
            }
            catch (Exception)
            {
                //例外発生時は制限なしの無限大を返す
                return double.PositiveInfinity;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
