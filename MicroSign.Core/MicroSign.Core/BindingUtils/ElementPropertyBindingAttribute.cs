using System;

namespace MicroSign.Core.BindingUtils
{
    /// <summary>
    /// エレメントプロパティバインディング
    /// </summary>
    /// <remarks>プロパティにバインドするエレメントのプロパティ情報を指定できる。VMのプロパティとしてクラスを公開する場合に使う。重複指定可能</remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ElementPropertyBindingAttribute : Attribute
    {
        /// <summary>
        /// ターゲットプロパティ名
        /// </summary>
        public string TargetPropertyName
        {
            get;
            protected set;
        }

        /// <summary>
        /// コンバーター型
        /// </summary>
        /// <remarks>IValueConverterをサポートするクラスの型を指定する</remarks>
        public Type? ConverterType
        {
            get;
            protected set;
        }

        /// <summary>
        /// コンバーターパラメータ
        /// </summary>
        public object? ConverterParameter
        {
            get;
            protected set;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="targetPropertyName"></param>
        public ElementPropertyBindingAttribute(string targetPropertyName)
            : this(targetPropertyName, null, null)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="targetPropertyName"></param>
        /// <param name="converterType"></param>
        public ElementPropertyBindingAttribute(string targetPropertyName, Type? converterType)
            : this(targetPropertyName, converterType, null)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="targetPropertyName"></param>
        /// <param name="converterType"></param>
        /// <param name="converterParameter"></param>
        public ElementPropertyBindingAttribute(string targetPropertyName, Type? converterType, object? converterParameter)
        {
            this.TargetPropertyName = targetPropertyName;
            this.ConverterType = converterType;
            this.ConverterParameter = converterParameter;
        }
    }
}
