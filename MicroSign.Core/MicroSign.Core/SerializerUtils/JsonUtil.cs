using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MicroSign.Core.SerializerUtils
{
    /// <summary>
    /// JSONシリアライズユーティリティクラス
    /// </summary>
    public static class JsonUtil
	{
		/// <summary>
		/// JSON読込
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="directory"></param>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static T? Load<T>(string directory, string filename) where T : class
		{
			Type vmType = typeof(T);
			return (T?)JsonUtil.Load(vmType, directory, filename);
		}

		/// <summary>
		/// Json読込
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="path"></param>
		/// <returns></returns>
		public static T? Load<T>(string path) where T : class
		{
			Type vmType = typeof(T);
			return (T?)JsonUtil.Load(vmType, path);
		}

		/// <summary>
		/// JSON読込
		/// </summary>
		/// <param name="t"></param>
		/// <param name="directory"></param>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static object? Load(Type t, string directory, string filename)
		{
			string jsonPath = System.IO.Path.Combine(directory, filename);
			return JsonUtil.Load(t, jsonPath);
		}

        /// <summary>
        /// JSON読込
        /// </summary>
        /// <param name="t"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private static object? Load(Type t, string path)
        {
            //パス有効判定
            if(string.IsNullOrEmpty(path))
            {
                //無効の場合は即終了
                //LOGGER.Warn("JSON Path Empty");
                return null;
            }

			//ファイルの存在確認
			{
				bool isExists = System.IO.File.Exists(path);
				if (isExists)
                {
					//存在する場合は処理続行
                }
				else
				{
					//存在しない場合NULLで終了
					//LOGGER.Warn($"Not Found JSON [Path='{path}']");
					return null;
				}
			}

            //JSONファイル読込
            try
			{
                //2023.10.17:CS)杉原:MSDNにSystem.Text.Jsonを使うようにあるので変更します >>>>> ここから
				////シリアライザー生成
				////DataContractJsonSerializer serializer = new DataContractJsonSerializer(t);
				//
				////2021.06.25:JSONコメント付きデシリアライズ対応 >>>>> ここから
				//////デシリアライズ
				////using (FileStream fs = new FileStream(path, FileMode.Open))
				////{
				////	object result = serializer.ReadObject(fs);
				////	LOGGER.Info($"JSON load success [Path='{path}']");
				////	return result;
				////}
				////----------
				//// >> .NET Core 3以上なら以下で出来るそうです
				//// >> JsonSerializerOptions options = new JsonSerializerOptions
				//// >> {
				//// >>     ReadCommentHandling = JsonCommentHandling.Skip
				//// >> };
				//// >> sSampleData sampleData = System.Text.Json.JsonSerializer.Deserialize<SampleData>(jsonString, options);
				//// >> .NET FrameworkにはSystem.Text.Json.JsonSerializerが無いので自分でコメントを削除します
				//{
				//  //全行取得
				//  string allText = System.IO.File.ReadAllText(path, System.Text.Encoding.UTF8);
				//
				//	//コメント削除
				//	// >> https://kazupon.org/csharp-delete-commnt-line/
				//	// >> 2021.06.25:CS)杉原:軽く確認したところ正しく動作してそうです
				//	// >> 内容を確認しようとしたのですが時間がかかりそうなので未調査です
				//	// >> 後で確認してください
				//	string json = System.Text.RegularExpressions.Regex.Replace(allText, @"(@(?:""[^""]*"")+|""(?:[^""\n\\]+|\\.)*""|'(?:[^'\n\\]+|\\.)*')|//.*|/\*(?s:.*?)\*/", "$1");
				//
				//	using (MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
				//	{
				//		object? result = serializer.ReadObject(ms);
				//	//	LOGGER.Info($"JSON load success [Path='{path}']");
				//		return result;
				//	}
				//}
                //2021.06.25:JSONコメント付きデシリアライズ対応 <<<<< ここまで
                //----------
                //全行取得
                string allText = System.IO.File.ReadAllText(path, System.Text.Encoding.UTF8);

				//コメントを読み飛ばすオプションを生成
                System.Text.Json.JsonSerializerOptions options = new System.Text.Json.JsonSerializerOptions
                {
                    ReadCommentHandling = System.Text.Json.JsonCommentHandling.Skip,

                    //Enumを名前でシリアライズ
                    // >> https://baba-s.hatenablog.com/entry/2022/08/23/140130
                    Converters = { new JsonStringEnumConverter() },

                    //すべての文字をシリアル化
                    // >> https://learn.microsoft.com/ja-jp/dotnet/standard/serialization/system-text-json/character-encoding
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true,
                };

				//JSONテキストをオブジェクトに変換
                object? result = System.Text.Json.JsonSerializer.Deserialize(allText, t, options);

				//終了
				return result;
				//2023.10.17:CS)杉原: MSDNにSystem.Text.Jsonを使うようにあるので変更します <<<<< ここまで
			}
            catch (Exception /*ex*/)
			{
                //LOGGER.Warn($"JSION load exception [Path='{path}']", ex);
				return null;
			}
		}

		/// <summary>
		/// XML書込
		/// </summary>
		/// <param name="path">ファイルパス</param>
		/// <param name="obj">出力オブジェクト</param>
		/// <returns>>true=成功/false=失敗</returns>
		public static bool Save<T>(string path, T obj) where T : class
		{
			try
            {
				//ディレクトリ生成
				CommonUtils.CreateFilepathFolder(path);

				//2023.10.17:CS)杉原:MSDNにSystem.Text.Jsonを使うようにあるので変更します >>>>> ここから
				////シリアライザー生成
				//DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
				//
				////シリアライズ
				//using (FileStream fs = new FileStream(path, FileMode.Create))
				//{
				//	serializer.WriteObject(fs, obj);
				//	//LOGGER.Info($"JSON save success [Path='{path}']");
				//	//2022.12.21:CS)杉原:ストレージに全書き込みを反映する
				//	fs.Flush();
				//	fs.Close();
				//	return true;
				//}
				//----------
				//シリアライズオプション
				System.Text.Json.JsonSerializerOptions option = new JsonSerializerOptions()
				{
                    //Enumを名前でシリアライズ
                    // >> https://baba-s.hatenablog.com/entry/2022/08/23/140130
                    Converters = { new JsonStringEnumConverter() },

                    //すべての文字をシリアル化
                    // >> https://learn.microsoft.com/ja-jp/dotnet/standard/serialization/system-text-json/character-encoding
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true,
                };

                //オブジェクトをJSONテキストに変換
                string jsonText = System.Text.Json.JsonSerializer.Serialize(obj, option);

				//ファイルにUTF8で保存
				System.IO.File.WriteAllText(path, jsonText, System.Text.Encoding.UTF8);

				//ここまで来たら成功
				return true;
                //2023.10.17:CS)杉原: MSDNにSystem.Text.Jsonを使うようにあるので変更します <<<<< ここまで
            }
            catch (Exception/*ex*/)
			{
				//LOGGER.Warn($"JSON save exception [Path='{path}']", ex);
				return false;
			}
		}

		/// <summary>
		/// ENUMを文字に変換
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <remarks>
		/// 以下を参考にしました
		/// <see cref="https://stackoverflow.com/questions/48820025/enummemberattribute-value-is-ignored-by-datacontractjsonserializer">EnumMemberAttribute Value is ignored by DataContractJsonSerializer</see>
		/// </remarks>
		public static string ToEnumString<T>(T value) where T:Enum
        {
			string? name = System.Enum.GetName(typeof(T), value);
			if(name == null)
			{
				//nullの場合は空文字を返す
				return string.Empty;
			}
			else
			{
				//先頭を1文字を小文字に変換して返す
				string result = name.FirstCharacterToLower();
                return result;
            }
        }

		/// <summary>
		/// 文字をENUMに変換
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <remarks>
		/// 以下を参考にしました
		/// <see cref="https://stackoverflow.com/questions/48820025/enummemberattribute-value-is-ignored-by-datacontractjsonserializer">EnumMemberAttribute Value is ignored by DataContractJsonSerializer</see>
		/// </remarks>
		public static T FromEnumString<T>(string value) where T : Enum
		{
			return (T)System.Enum.Parse(typeof(T), value, true);
		}

		/// <summary>
		/// 先頭1文字を小文字にする拡張メソッド
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		/// <remarks>
		/// 以下を参考にしました
		/// <see cref="https://stackoverflow.com/questions/48820025/enummemberattribute-value-is-ignored-by-datacontractjsonserializer">EnumMemberAttribute Value is ignored by DataContractJsonSerializer</see>
		/// </remarks>
		private static string FirstCharacterToLower(this string str)
		{
			//文字列が有効か判定
            {
				bool isNull = String.IsNullOrEmpty(str);
				if (isNull)
				{
					//無効の場合はそのまま
					return str;
				}
			}

            //先頭が小文字か判定
            {
				bool isLower = Char.IsLower(str, 0);
				if(isLower)
                {
					//小文字の場合はそのまま
					return str;
                }
			}

			//先頭を小文字に変換
            {
				string result = Char.ToLowerInvariant(str[0]) + str.Substring(1);
				return result;
			}
		}
	}
}
