using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSign.Core.Models
{
    partial class Model
    {
        /// <summary>
        /// パネル設定をアップロードする
        /// </summary>
        /// <param name="mkspiffsPath">MKSPIFFSパス</param>
        /// <param name="esptoolPath">EXPTOOLパス</param>
        /// <param name="com">COMポート</param>
        /// <param name="bardrate">ボーレート</param>
        /// <param name="frequency">フラッシュ動作周波数</param>
        /// <param name="mode">フラッシュ動作モード</param>
        /// <param name="size">SPIFFSサイズ</param>
        /// <param name="offset">SPIFFSオフセット</param>
        /// <returns></returns>
        public (bool IsSuccess, string Message) UploadPanelConfig(string mkspiffsPath, string esptoolPath, string com, int bardrate, string frequency, string mode, string size, string offset)
        {
            //パネル設定のあるディレクトリを取得
            string targetDir = string.Empty;
            {
                //パネル設定ファイル名を取得
                string filename = MicroSignConsts.Path.MatrixLedPanelConfigPath;

                //フルパスに変換
                string fullPath = CommonUtils.GetFullPath(filename);
                CommonLogger.Debug($"パネル設定パス='{fullPath}'");

                //ファイルが存在するか判定
                {
                    bool isExists = System.IO.File.Exists(fullPath);
                    if(isExists)
                    {
                        //存在する場合は処理続行
                        CommonLogger.Debug($"パネル設定存在 (path='{fullPath}')");
                    }
                    else
                    {
                        //存在しない場合は終了
                        return (false, CommonLogger.Warn($"パネル設定がありません (path='{fullPath}')"));
                    }
                }

                //ディレクトリ部分だけを取得
                string? dir = System.IO.Path.GetDirectoryName(fullPath);
                if(dir == null)
                {
                    return (false, CommonLogger.Warn($"ディレクトリが取得できませんでした (path='{fullPath}')"));
                }
                else
                {
                    bool isNull = string.IsNullOrEmpty(dir);
                    if (isNull)
                    {
                        //無効の場合はエラーで終了
                        return (false, CommonLogger.Warn($"ディレクトリが空です (path='{fullPath}')"));
                    }
                    else
                    {
                        //有効の場合はターゲットディレクトリにする
                        targetDir = dir;
                        CommonLogger.Debug($"処理ターゲットディレクトリ (dir='{dir}')");
                    }
                }
            }

            //SPIFFSのバイナリファイルを生成するパスを生成
            string spiffsPath = CommonUtils.GetFullPath(MicroSignConsts.Path.SPIFFSPath);

            //SPIFFSを生成
            {
                //引数を生成
                string arg = $"-c \"{targetDir}\" -s {size} \"{spiffsPath}\"";

                //実行
                var ret = this.ExecuteProcess("SPIFFS生成", mkspiffsPath, arg, MicroSignConsts.WaitTimes.MKSPIFFS);
                if (ret.IsSuccess)
                {
                    //成功の場合処理続行
                    CommonLogger.Debug("SPIFFS生成成功");
                }
                else
                {
                    //失敗の場合は終了
                    return (false, CommonLogger.Warn($"SPIFFS生成失敗 (理由={ret.Message})"));
                }
            }

            //ESPTOOLで書込み
            {
                //引数を生成
                string arg = $"-p {com} -b {bardrate} write_flash -ff {frequency} -fm {mode} {offset} \"{spiffsPath}\"";

                //実行
                var ret = this.ExecuteProcess("SPIFFS書込", esptoolPath, arg, MicroSignConsts.WaitTimes.ESPTOOL);
                if(ret.IsSuccess)
                {
                    //成功の場合処理続行
                    CommonLogger.Debug("SPIFFS書込成功");
                }
                else
                {
                    //失敗の場合は終了
                    return (false, CommonLogger.Warn($"SPIFFS書込失敗 (理由={ret.Message})"));
                }
            }

            //ここまで来たら成功で終了
            return (true, CommonLogger.Info("パネル設定アップロード成功"));
        }

        /// <summary>
        /// 外部プロセスを実行
        /// </summary>
        /// <param name="name">処理名</param>
        /// <param name="path">実行パス</param>
        /// <param name="args">引数</param>
        /// <param name="timeout">タイムアウト値</param>
        /// <returns></returns>
        private (bool IsSuccess, string Message) ExecuteProcess(string name, string path, string args, TimeSpan timeout)
        {
            try
            {
                ProcessStartInfo psInfo = new ProcessStartInfo();
                psInfo.FileName = path;
                psInfo.Arguments = args;
                psInfo.CreateNoWindow = true;
                psInfo.RedirectStandardOutput = true;
                psInfo.RedirectStandardError = true;

                CommonLogger.Info($"{name} - 開始 (file='{path}' arg='{args}')");
                using (Process? p = Process.Start(psInfo))
                {
                    if (p == null)
                    {
                        //プロセスの起動に失敗した場合
                        return (false, CommonLogger.Warn($"{name} プロセスの起動に失敗しました"));
                    }
                    else
                    {
                        try
                        {
                            //プロセスの起動に成功した場合終わるまで待つ
                            // >> 標準出力都標準エラーをマージして取得する
                            StringBuilder sb = new StringBuilder(MicroSign.Core.CommonConsts.Text.STRING_BUILDER_CAPACITY);
                            object lockObj = new object();
                            p.ErrorDataReceived += (s, e) => { lock (lockObj) { sb.AppendLine(e.Data); } };
                            p.OutputDataReceived += (s, e) => { lock (lockObj) { sb.AppendLine(e.Data); } };
                            p.BeginOutputReadLine();
                            p.BeginErrorReadLine();

                            // >> プロセス終了待ち
                            int waitTime = (int)timeout.TotalMilliseconds;
                            CommonLogger.Info($"{name} - プロセス終了待ち開始 ({waitTime}ms) (file='{path}' arg='{args}')");
                            p.WaitForExit(waitTime);
                            CommonLogger.Info($"{name} - プロセス終了待ち完了 ({waitTime}ms) (file='{path}' arg='{args}')");

                            // >>  標準出力の読み取り(エラーでも読込する)
                            string outputText = string.Empty;
                            lock (lockObj)
                            {
                                outputText = sb.ToString();
                            }
                            //ログに出力
                            CommonLogger.Info($"{name} >>>{outputText}<<<");

                            // >> 終了したか判定
                            if (p.HasExited)
                            {
                                //終了したので処理続行
                                CommonLogger.Debug($"{name} - プロセス終了しました (file='{path}' arg='{args}')");
                            }
                            else
                            {
                                //終了しなかったのでエラーで終了
                                return (false, CommonLogger.Warn($"{name} - 時間内に終了しませんでした (file='{path}' arg='{args}')"));
                            }

                            //終了コード判定
                            {
                                int n = p.ExitCode;
                                if(n == MicroSignConsts.ExitCodes.Success)
                                {
                                    //成功の場合処理続行
                                    CommonLogger.Debug($"{name} - プロセス終了コード正常 Exit={n} (file='{path}' arg='{args}')");
                                }
                                else
                                {
                                    //それ以外はエラーとみなす
                                    return (false, CommonLogger.Warn($"{name} - プロセス終了コード異常 Exit={n} (file='{path}' arg='{args}')"));
                                }
                            }

                            //ここまで来たら成功
                            // >> メッセージに出力された内容を出力する
                            return (true, CommonLogger.Info($"{name} - 成功 (file='{path}' arg='{args}')"));
                        }
                        finally
                        {
                            p.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //例外が発生したら終了
                return (false, CommonLogger.Warn($"{name}で例外発生", ex));
            }
        }
    }
}
