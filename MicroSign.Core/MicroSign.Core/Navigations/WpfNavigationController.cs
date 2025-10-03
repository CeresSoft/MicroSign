using System.Windows;
using System.Windows.Controls;

namespace MicroSign.Core.Navigations
{
    /// <summary>
    /// WPFナビゲーションコントローラー
    /// </summary>
    public class WpfNavigationController
    {
        /// <summary>
        /// ナビゲーション有効依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.RegisterAttached(
                "Enabled",
                typeof(bool),
                typeof(WpfNavigationController),
                new PropertyMetadata(false, WpfNavigationController.OnEnabledChanged));

        /// <summary>
        /// ナビゲーション有効取得
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(WpfNavigationController.EnabledProperty);
        }

        /// <summary>
        /// ナビゲーション有効設定
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(WpfNavigationController.EnabledProperty, value);
        }

        /// <summary>
        /// 変更コールバック
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //パネル種痘
            Panel? p = d as Panel;
            if (p == null)
            {
                //パネルが無効の場合は何もしない
                return;
            }
            else
            {
                //パネルが有効の場合は処理続行
            }

            //メニュー項目を取得
            bool value = (bool)e.NewValue;
            if (value)
            {
                //有効の場合は処理続行
            }
            else
            {
                //無効の場合は何もしない
                return;
            }

            //ナビゲーション初期化
            NavigationController.Initialize(p);
        }
    }
}
