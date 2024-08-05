using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace MicroSign.Core.ValueConverters
{
    /// <summary>
    /// 値変換ユーティリティ
    /// </summary>
    public static partial class ValueConverterUtils
    {
        /// <summary>
        /// 安全に文字列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToSafeString(object? obj)
        {
            if(obj == null)
            {
                //オブジェクトが無効の場合はnullを返す
                //return null;
                // >> nullではなく空文字を返すように変更
                return string.Empty;
            }
            else
            {
                //オブジェクトが有効な場合文字列化して終了
                // >> obj.ToString()はstring?を返す
                string? result = obj.ToString();
                if(result == null)
                {
                    return string.Empty;
                }
                else
                {
                    return result;
                }
            }
        }

        /// <summary>
        /// HiddenかCollapsedに変換
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static Visibility ToHiddenOrCllapsed(object parameter)
        {
            //非表示の種類をパラメータから判定(標準はCollapsed)
            string txt = ValueConverterUtils.ToSafeString(parameter);
            bool bCollapsed = CommonUtils.IsIgnoreCase(ValueConverterConsts.HIDDEN_TEXT, txt);
            if (bCollapsed)
            {
                //Hidden指定されている場合はHiddenを返す
                return Visibility.Hidden;
            }
            else
            {
                //それ以外はCollapsedを返す
                return Visibility.Collapsed;
            }
        }

        /// <summary>
        /// BOOLに変換
        /// </summary>
        /// <param name="value">変換値</param>
        /// <returns></returns>
        public static bool ToBool(object value)
        {
            if (value is bool)
            {
                bool v = (bool)value;
                if (v)
                {
                    //Trueにする
                    return true;
                }
            }
            //それ以外はFalse
            return false;
        }

        /// <summary>
        /// BOOLに変換
        /// </summary>
        /// <param name="value">変換値</param>
        /// <param name="defaultValue">変換できなかった場合のデフォルト値</param>
        /// <returns></returns>
        public static bool TryParseBool(object value, bool defaultValue)
        {
            string param = ValueConverterUtils.ToSafeString(value);
            bool isNull = string.IsNullOrEmpty(param);
            if (isNull)
            {
                //NULLの場合はデフォルト値
                return defaultValue;
            }
            else
            {
                bool ret = bool.TryParse(param, out bool result);
                if (ret)
                {
                    //変換できた場合は変換結果を返す
                    return result;
                }
                else
                {
                    //変換できなかった場合デフォルト値
                    return defaultValue;
                }
            }
        }

        /// <summary>
        /// Doubleに変換
        /// </summary>
        /// <param name="value">変換値</param>
        /// <param name="defaultValue">変換できなかった場合のデフォルト値</param>
        /// <returns></returns>
        public static double TryParseDouble(object value, double defaultValue)
        {
            string param = ValueConverterUtils.ToSafeString(value);
            bool isNull = string.IsNullOrEmpty(param);
            if (isNull)
            {
                //NULLの場合はデフォルト値
                return defaultValue;
            }
            else
            {
                bool ret = double.TryParse(param, out double result);
                if (ret)
                {
                    //変換できた場合は変換結果を返す
                    return result;
                }
                else
                {
                    //変換できなかった場合デフォルト値
                    return defaultValue;
                }
            }
        }

        /// <summary>
        /// Intに変換
        /// </summary>
        /// <param name="value">変換値</param>
        /// <param name="defaultValue">変換できなかった場合のデフォルト値</param>
        /// <returns></returns>
        public static int TryParseInt32(object value, int defaultValue)
        {
            string param = ValueConverterUtils.ToSafeString(value);
            bool isNull = string.IsNullOrEmpty(param);
            if (isNull)
            {
                //NULLの場合はデフォルト値
                return defaultValue;
            }
            else
            {
                bool ret = int.TryParse(param, out int result);
                if (ret)
                {
                    //変換できた場合は変換結果を返す
                    return result;
                }
                else
                {
                    //変換できなかった場合デフォルト値
                    return defaultValue;
                }
            }
        }

        /// <summary>
        /// テキストマッチで表示
        /// </summary>
        /// <param name="value">指定値</param>
        /// <param name="parameter">パラメータ</param>
        /// <returns></returns>
        public static Visibility ToMatchVisibility(object value, object parameter)
        {
            //値を文字列化
            string valueText = ValueConverterUtils.ToSafeString(value);

            //パラメータから変換式取得
            string[] conversions = Array.Empty<string>();
            {
                string txt = ValueConverterUtils.ToSafeString(parameter);
                bool isNull = string.IsNullOrEmpty(txt);
                if (isNull)
                {
                    //パラメータテキストが空の場合は何もしない
                }
                else
                {
                    //複数変換式を個別の変換式に分解
                    conversions = txt.Split(ValueConverterConsts.VisibilityConversion.SEPARETOR);
                }
            }

            //変換式数を取得
            int n = CommonUtils.GetCount(conversions);

            //ループ
            // >> 階層が６段になっているが、階層を減らす方法がすぐに思いつかなかったので
            // >> とりあえず６段のままとします。(Impl関数にしてもよいが戻り値が複雑になる)
            Visibility otherResult = Visibility.Collapsed;
            for (int i = CommonConsts.Index.First; i < n; i += CommonConsts.Index.Step)
            {
                //変換式取得
                string conversion = conversions[i];
                bool isNull = string.IsNullOrEmpty(conversion);
                if (isNull)
                {
                    //変換式が空の場合は何もしない
                }
                else
                {
                    //正規表現で解析
                    Match m = ValueConverterConsts.VisibilityConversion.FORMAT.Match(conversion);
                    if (m.Success)
                    {
                        //マッチした場合
                        string testText = m.Groups[ValueConverterConsts.VisibilityConversion.KEY_TEST].Value;
                        string markText = m.Groups[ValueConverterConsts.VisibilityConversion.KEY_MARK].Value;
                        string visibleText = m.Groups[ValueConverterConsts.VisibilityConversion.KEY_VISIBLE].Value;

                        bool isMarkNull = string.IsNullOrEmpty(markText);
                        if (isMarkNull)
                        {
                            //比較値区切りが無い場合はその他指定の場合
                            bool ret = Enum.TryParse<Visibility>(visibleText, out Visibility result);
                            if (ret)
                            {
                                //変換できた場合はその値をその他の値にする
                                otherResult = result;
                            }
                            else
                            {
                                //変換できない場合は何もしない
                            }
                        }
                        else
                        {
                            //比較値区切りが有る場合
                            if (testText == valueText)
                            {
                                //値が一致した場合
                                bool ret = Enum.TryParse<Visibility>(visibleText, out Visibility result);
                                if (ret)
                                {
                                    //変換できた場合はその値で終了    
                                    return result;
                                }
                                else
                                {
                                    //変換できない場合は何もしない
                                }
                            }
                            else
                            {
                                //値が一致しない場合は何もしない
                            }
                        }
                    }
                    else
                    {
                        //マッチしない場合何もしない
                    }
                }
            }

            //ここまで来たら該当なしなのでその他を返す
            return otherResult;
        }

        /// <summary>
        /// ブラシ変換
        /// </summary>
        private static System.Windows.Media.BrushConverter _BrushConverter = new System.Windows.Media.BrushConverter();

        /// <summary>
        /// ブラシを取得
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static System.Windows.Media.Brush? GetBrush(object value)
        {
            //値が有効か判定
            if(value == null)
            {
                //無効の場合は常にnullを返す
                return null;
            }
            else
            {
                //有効の場合は処理続行
            }

            //まずはブラシに変換
            {
                System.Windows.Media.Brush? brush = value as System.Windows.Media.Brush;
                if(brush == null)
                {
                    //ブラシに変換できない場合は処理続行
                }
                else
                {
                    //ブラシに変換できた場合は変換できたブラシで終了
                    return brush;
                }
            }

            //Colorに変換
            {
                if(value is System.Windows.Media.Color)
                {
                    //色の場合
                    // >> 色を取得
                    System.Windows.Media.Color cr = (System.Windows.Media.Color)value;

                    // >> ブラシ生成
                    System.Windows.Media.SolidColorBrush result = new System.Windows.Media.SolidColorBrush(cr);

                    // >> 終了
                    return result;
                }
                else
                {
                    //色以外の場合は処理続行
                }
            }

            //それ以外の場合は文字にしてみる
            try
            {
                string? txt = value.ToString();
                if(txt == null)
                {
                    //文字列が取得できない場合は何もしない(=nullを返す)
                }
                else
                {
                    System.Windows.Media.BrushConverter converter = ValueConverterUtils._BrushConverter;
                    System.Windows.Media.Brush? brush = converter.ConvertFrom(txt) as System.Windows.Media.Brush;
                    if (brush == null)
                    {
                        //変換できない場合は何もしない(=nullを返す)
                    }
                    else
                    {
                        //変換できた場合は終了
                        return brush;
                    }
                }
            }
            catch(Exception)
            {
                //例外は握りつぶす
            }

            //ここまで来たら変換できないのでnullで終了
            return null;
        }
    }
}
