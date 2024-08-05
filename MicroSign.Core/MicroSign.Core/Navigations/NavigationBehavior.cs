using System.Windows;
using System.Windows.Controls;

namespace MicroSign.Core.Navigations
{
    /// <summary>
    /// ナビゲーションビヘイビア - Panel
    /// </summary>
    public class NavigationBehavior : Microsoft.Xaml.Behaviors.Behavior<System.Windows.Controls.Panel>
    {
        /// <summary>
        /// ナビゲーションコントローラー有効添付プロパティ
        /// </summary>
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.RegisterAttached("Enabled", typeof(bool), typeof(NavigationBehavior), new FrameworkPropertyMetadata(false, NavigationBehavior.OnEnabledChanged));

        /// <summary>
        /// ナビゲーションコントローラー有効添付プロパティ変更
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        public static void OnEnabledChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            //エレメント取得
            UIElement? element = obj as UIElement;
            if (element == null)
            {
                //エレメント無効の場合は処理できないので何もしない
                return;
            }
            else
            {
                //エレメント有効の場合添付プロパティを設定する
                // >> 新しい値を取得する
                object newValue = args.NewValue;
                bool enabled = false;
                if (newValue is bool)
                {
                    //boolの場合は値を取得する
                    enabled = (bool)newValue;
                }
                else
                {
                    //bool以外の場合はそのまま(=false)
                }
                // >> 新しい値が有効の場合
                if (enabled)
                {
                    //有効の場合
                    // >> ナビゲーション有効に設定
                    element.SetValue(NavigationBehavior.EnabledProperty, true);

                    // >> NavigationControllerを設定する
                    Panel? panel = obj as Panel;
                    if (panel == null)
                    {
                        //パネル以外の場合は処理できないのでそのまま
                    }
                    else
                    {
                        //パネルの場合新しいインスタンスを設定
                        NavigationController.SetNavigationController(element, new NavigationController(panel));
                    }
                }
                else
                {
                    //無効の場合
                    // >> 無効に設定
                    element.SetValue(NavigationBehavior.EnabledProperty, false);

                    // >> NavigationControllerを解除する
                    Panel? panel = obj as Panel;
                    if (panel == null)
                    {
                        //パネル以外の場合は処理できないのでそのまま
                    }
                    else
                    {
                        //パネルの場合初期化する
                        NavigationController.SetNavigationController(element, null);
                    }
                }
            }
        }

        /// <summary>
        /// ナビゲーションコントローラー有効取得
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetEnabled(DependencyObject obj)
        {
            object result = obj.GetValue(NavigationBehavior.EnabledProperty);
            if (result is bool)
            {
                //有効の場合は変換して返す
                bool result2 = (bool)result;
                return result2;
            }
            else
            {
                //無効の場合は無条件にfalseを返す
                return false;
            }
        }

        /// <summary>
        /// ナビゲーションコントローラー有効設定
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(NavigationBehavior.EnabledProperty, value);
        }
    }
}
