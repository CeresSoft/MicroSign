using System.Windows;

namespace MicroSign.Core.Navigations
{
    /// <summary>
    /// ナビゲーションコントローラー用FrameworkElement拡張メソッド
    /// </summary>
    /// <remarks>現在表示しているエレメントを破棄し、新しいエレメントを表示します</remarks>
    public static class NavigationFrameworkElementExtention
    {
        /// <summary>
        /// 遷移
        /// </summary>
        /// <param name="currentElement">現在のエレメント</param>
        /// <param name="moveElement">遷移先のエレメント</param>
        public static void NavigationMove(this FrameworkElement currentElement, FrameworkElement moveElement)
        {
            //現在のエレメントからナビゲーションコントローラーを取得
            NavigationController? navi = NavigationController.GetNavigationController(currentElement);
            if (navi == null)
            {
                //取得できない場合は何もしない
                MicroSign.Core.CommonLogger.Warn("ナビゲーションコントローラーが無効です");
                return;
            }
            else
            {
                //遷移処理
                navi.Move(moveElement, null);
            }
        }

        /// <summary>
        /// 遷移
        /// </summary>
        /// <param name="currentElement">現在のエレメント</param>
        /// <param name="moveElement">遷移先のエレメント</param>
        /// <param name="arg">遷移先に渡すパラメータ</param>
        public static void NavigationMove(this FrameworkElement currentElement, FrameworkElement moveElement, object? arg)
        {
            //現在のエレメントからナビゲーションコントローラーを取得
            NavigationController? navi = NavigationController.GetNavigationController(currentElement);
            if (navi == null)
            {
                //取得できない場合は何もしない
                MicroSign.Core.CommonLogger.Warn("ナビゲーションコントローラーが無効です");
                return;
            }
            else
            {
                //遷移処理
                navi.Move(moveElement, arg);
            }
        }

        /// <summary>
        /// 呼出
        /// </summary>
        /// <param name="currentElement">現在のエレメント</param>
        /// <param name="callElement">呼出先のエレメント</param>
        /// <remarks>現在表示しているエレメントを非表示時にし、新しいエレメントを表示します</remarks>
        public static void NavigationCall(this FrameworkElement currentElement, FrameworkElement callElement)
        {
            //現在のエレメントからナビゲーションコントローラーを取得
            NavigationController? navi = NavigationController.GetNavigationController(currentElement);
            if (navi == null)
            {
                //取得できない場合は何もしない
                MicroSign.Core.CommonLogger.Warn("ナビゲーションコントローラーが無効です");
                return;
            }
            else
            {
                //呼出処理
                navi.Call(callElement, null, null);
            }
        }

        /// <summary>
        /// 呼出
        /// </summary>
        /// <param name="currentElement">現在のエレメント</param>
        /// <param name="callElement">呼出先のエレメント</param>
        /// <param name="arg">呼出先に渡すパラメータ</param>
        /// <remarks>現在表示しているエレメントを非表示時にし、新しいエレメントを表示します</remarks>
        public static void NavigationCall(this FrameworkElement currentElement, FrameworkElement callElement, object? arg)
        {
            //現在のエレメントからナビゲーションコントローラーを取得
            NavigationController? navi = NavigationController.GetNavigationController(currentElement);
            if (navi == null)
            {
                //取得できない場合は何もしない
                MicroSign.Core.CommonLogger.Warn("ナビゲーションコントローラーが無効です");
                return;
            }
            else
            {
                //呼出処理
                navi.Call(callElement, arg, null);
            }
        }

        /// <summary>
        /// 呼出
        /// </summary>
        /// <param name="currentElement">現在のエレメント</param>
        /// <param name="callElement">呼出先のエレメント</param>
        /// <param name="arg">呼出先に渡すパラメータ</param>
        /// <param name="returnCallback">戻り時に呼び出すコールバック</param>
        /// <remarks>現在表示しているエレメントを非表示時にし、新しいエレメントを表示します</remarks>
        public static void NavigationCall(this FrameworkElement currentElement, FrameworkElement callElement, object? arg, NavigationReturnCallback returnCallback)
        {
            //現在のエレメントからナビゲーションコントローラーを取得
            NavigationController? navi = NavigationController.GetNavigationController(currentElement);
            if (navi == null)
            {
                //取得できない場合は何もしない
                MicroSign.Core.CommonLogger.Warn("ナビゲーションコントローラーが無効です");
                return;
            }
            else
            {
                //呼出処理
                navi.Call(callElement, arg, returnCallback);
            }
        }

        /// <summary>
        /// オーバーラップ
        /// </summary>
        /// <param name="currentElement">現在のエレメント</param>
        /// <param name="callElement">呼出先のエレメント</param>
        /// <remarks>現在表示しているエレメントはそのままで、新しいエレメントをオーバーラップ表示します</remarks>
        public static void NavigationOverwrap(this FrameworkElement currentElement, FrameworkElement callElement)
        {
            //現在のエレメントからナビゲーションコントローラーを取得
            NavigationController? navi = NavigationController.GetNavigationController(currentElement);
            if (navi == null)
            {
                //取得できない場合は何もしない
                MicroSign.Core.CommonLogger.Warn("ナビゲーションコントローラーが無効です");
                return;
            }
            else
            {
                //呼出処理
                navi.Overwrap(callElement, null, null);
            }
        }

        /// <summary>
        /// オーバーラップ
        /// </summary>
        /// <param name="currentElement">現在のエレメント</param>
        /// <param name="callElement">呼出先のエレメント</param>
        /// <param name="arg">呼出先に渡すパラメータ</param>
        /// <remarks>現在表示しているエレメントはそのままで、新しいエレメントをオーバーラップ表示します</remarks>
        public static void NavigationOverwrap(this FrameworkElement currentElement, FrameworkElement callElement, object? arg)
        {
            //現在のエレメントからナビゲーションコントローラーを取得
            NavigationController? navi = NavigationController.GetNavigationController(currentElement);
            if (navi == null)
            {
                //取得できない場合は何もしない
                MicroSign.Core.CommonLogger.Warn("ナビゲーションコントローラーが無効です");
                return;
            }
            else
            {
                //オーバーラップ処理
                navi.Overwrap(callElement, arg, null);
            }
        }

        /// <summary>
        /// オーバーラップ
        /// </summary>
        /// <param name="currentElement">現在のエレメント</param>
        /// <param name="callElement">呼出先のエレメント</param>
        /// <param name="arg">呼出先に渡すパラメータ</param>
        /// <param name="returnCallback">戻り時に呼び出すコールバック</param>
        /// <remarks>現在表示しているエレメントはそのままで、新しいエレメントをオーバーラップ表示します</remarks>
        public static void NavigationOverwrap(this FrameworkElement currentElement, FrameworkElement callElement, object? arg, NavigationReturnCallback returnCallback)
        {
            //現在のエレメントからナビゲーションコントローラーを取得
            NavigationController? navi = NavigationController.GetNavigationController(currentElement);
            if (navi == null)
            {
                //取得できない場合は何もしない
                MicroSign.Core.CommonLogger.Warn("ナビゲーションコントローラーが無効です");
                return;
            }
            else
            {
                //オーバーラップ処理
                navi.Overwrap(callElement, arg, returnCallback);
            }
        }

        /// <summary>
        /// 戻り
        /// </summary>
        /// <param name="currentElement">現在のエレメント</param>
        public static void NavigationReturn(this FrameworkElement currentElement)
        {
            //現在のエレメントからナビゲーションコントローラーを取得
            NavigationController? navi = NavigationController.GetNavigationController(currentElement);
            if (navi == null)
            {
                //取得できない場合は何もしない
                MicroSign.Core.CommonLogger.Warn("ナビゲーションコントローラーが無効です");
                return;
            }
            else
            {
                //戻り処理
                navi.Return(null);
            }
        }

        /// <summary>
        /// 戻り
        /// </summary>
        /// <param name="arg">呼出元に渡すパラメータ</param>
        /// <param name="currentElement">現在のエレメント</param>
        public static void NavigationReturn(this FrameworkElement currentElement, object? arg)
        {
            //現在のエレメントからナビゲーションコントローラーを取得
            NavigationController? navi = NavigationController.GetNavigationController(currentElement);
            if (navi == null)
            {
                //取得できない場合は何もしない
                MicroSign.Core.CommonLogger.Warn("ナビゲーションコントローラーが無効です");
                return;
            }
            else
            {
                //戻り処理
                navi.Return(arg);
            }
        }
    }
}
