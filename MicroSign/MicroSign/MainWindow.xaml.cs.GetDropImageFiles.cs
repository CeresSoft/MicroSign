using MicroSign.Core;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;

namespace MicroSign
{
    partial class MainWindow
    {
        /// <summary>
        /// ドロップされたファイルの一覧を取得結果
        /// </summary>
        private struct GetDropImageFilesResult
        {
            /// <summary>
            /// 成功フラグ
            /// </summary>
            public readonly bool IsSucess;

            /// <summary>
            /// メッセージ
            /// </summary>
            public readonly string Message;

            /// <summary>
            /// ドロップされた画像ファイルの一覧
            /// </summary>
            public readonly string[]? DropImageFiles;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="isSuccess">成功フラグ</param>
            /// <param name="message">メッセージ</param>
            /// <param name="dropImageFiles">ドロップされた画像ファイルの一覧</param>
            private GetDropImageFilesResult(bool isSuccess, string message, string[]? dropImageFiles)
            {
                this.IsSucess = isSuccess;
                this.Message = message;
                this.DropImageFiles = dropImageFiles;
            }

            /// <summary>
            /// 失敗
            /// </summary>
            /// <param name="message">メッセージ</param>
            /// <returns></returns>
            public static GetDropImageFilesResult Failed(string message)
            {
                GetDropImageFilesResult result = new GetDropImageFilesResult(false, message, null);
                return result;
            }

            /// <summary>
            /// 成功
            /// </summary>
            /// <param name="dropImageFiles">ドロップされた画像ファイルの一覧</param>
            /// <returns></returns>
            public static GetDropImageFilesResult Success(string[]? dropImageFiles)
            {
                GetDropImageFilesResult result = new GetDropImageFilesResult(true, string.Empty, dropImageFiles);
                return result;
            }
        }

        /// <summary>
        /// ドロップされたファイルの一覧を取得
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private GetDropImageFilesResult GetDropImageFiles(DragEventArgs e)
        {
            //ファイルのドロップか判定
            {
                bool isFiles = e.Data.GetDataPresent(DataFormats.FileDrop);
                if (isFiles)
                {
                    //ファイルの場合は処理続行
                }
                else
                {
                    //それ以外は処理できないので終了
                    return GetDropImageFilesResult.Failed("ファイル以外のものがドロップされました");
                }
            }

            //ファイルの一覧を取得
            string[]? files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files == null)
            {
                //処理すべきファイルがないので終了
                return GetDropImageFilesResult.Failed("ファイル一覧がnullでした");
            }
            else
            {
                //有効の場合は処理続行
            }

            //ファイル数を取得
            int n = files.Length;
            if (CommonConsts.Collection.Empty < n)
            {
                //有効の場合は処理続行
                CommonLogger.Debug($"ドロップファイル数={n}");
            }
            else
            {
                //処理すべきファイルがないので終了
                return GetDropImageFilesResult.Failed("ファイル一覧が空でした");
            }

            //画像ファイルを抽出
            List<string> dropImageFiles = new List<string>();
            for (int i = CommonConsts.Index.First; i < n; i += CommonConsts.Index.Step)
            {
                //画像ファイル判定
                // >> ファイル名取得
                string file = files[i];

                // >> 拡張子判定
                try
                {
                    Match m = App.Consts.Files.VaridExtensions.Match(file);
                    if (m.Success)
                    {
                        //成功の場合はリストに追加
                        dropImageFiles.Add(file);
                    }
                    else
                    {
                        //失敗の場合は何もしない
                    }
                }
                catch (Exception ex)
                {
                    //例外は握りつぶす
                    CommonLogger.Warn($"ドロップされたファイルの拡張子判定で例外発生 path='{file}'", ex);
                }
            }

            //抽出したファイルが存在するか判定
            {
                int m = dropImageFiles.Count;
                if (CommonConsts.Collection.Empty < m)
                {
                    //存在する場合は処理続行
                    CommonLogger.Debug($"画像ファイル数={m}");
                }
                else
                {
                    //存在しない場合は失敗を返す
                    return GetDropImageFilesResult.Failed("画像ファイルが存在しません");
                }
            }

            //ここまで来たら成功で返す
            {
                string[] dropImageFileArray = dropImageFiles.ToArray();
                return GetDropImageFilesResult.Success(dropImageFileArray);
            }
        }
    }
}
