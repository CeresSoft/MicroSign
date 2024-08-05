using System;

namespace MicroSign.Core.TaskUtils
{
    /// <summary>
    /// シグナル操作
    /// </summary>
    public static class SignalSafe
    {
        /// <summary>
        /// 安全に閉じる
        /// </summary>
        /// <param name="signal"></param>
        public static void SafeDispose(SignalBase signal)
        {
            if (signal == null)
            {
                return;
            }
            try
            {
                signal.Dispose();
            }
            catch (Exception)
            {
                //例外は握りつぶす
            }
        }

        /// <summary>
        /// 安全にセット
        /// </summary>
        /// <param name="signal"></param>
        public static void SafeSet(SignalBase signal)
        {
            if (signal == null)
            {
                return;
            }
            try
            {
                signal.Set();
            }
            catch (Exception)
            {
                //例外は握りつぶす
            }
        }

        /// <summary>
        /// 安全にリセット
        /// </summary>
        /// <param name="signal"></param>
        public static void SafeReset(SignalBase signal)
        {
            if (signal == null)
            {
                return;
            }
            try
            {
                signal.Reset();
            }
            catch (Exception)
            {
                //例外は握りつぶす
            }
        }

        /// <summary>
        /// 安全に待ち
        /// </summary>
        /// <param name="signal"></param>
        /// <param name="timeout"></param>
        public static bool SafeWaitOne(SignalBase signal, int timeout)
        {
            if (signal == null)
            {
                //無効の場合はシグナルで終了
                return true;
            }
            try
            {
                bool result = signal.WaitOne(timeout);
                return result;
            }
            catch (Exception)
            {
                //例外は握りつぶしてシグナルで終了
                return true;
            }
        }
    }
}
