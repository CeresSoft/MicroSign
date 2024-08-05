using System;

namespace MicroSign.Core.BindingUtils
{
    /// <summary>
    /// エレメントバインディング
    /// </summary>
    /// <remarks>プロパティにバインドするエレメントの情報を指定できる。重複指定可能</remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ElementBindingAttribute : Attribute
    {
        /// <summary>
        /// ターゲットエレメント名
        /// </summary>
        public string TargetElementName
        {
            get;
            protected set;
        }

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
        /// <param name="targetElementName"></param>
        /// <param name="targetPropertyName"></param>
        public ElementBindingAttribute(string targetElementName, string targetPropertyName)
            : this(targetElementName, targetPropertyName, null, null)
        {
            TargetElementName = targetElementName;
            TargetPropertyName = targetPropertyName;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="targetElementName"></param>
        /// <param name="targetPropertyName"></param>
        /// <param name="converterType"></param>
        public ElementBindingAttribute(string targetElementName, string targetPropertyName, Type? converterType)
            : this(targetElementName, targetPropertyName, converterType, null)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="targetElementName"></param>
        /// <param name="targetPropertyName"></param>
        /// <param name="converterType"></param>
        /// <param name="converterParameter"></param>
        public ElementBindingAttribute(string targetElementName, string targetPropertyName, Type? converterType, object? converterParameter)
        {
            this.TargetElementName = targetElementName;
            this.TargetPropertyName = targetPropertyName;
            this.ConverterType = converterType;
            this.ConverterParameter = converterParameter;
        }
    }
}
