using System;
using System.Reflection;
using Xunit;

namespace Aurochses.Xunit
{
    /// <summary>
    /// TypeAssert.
    /// </summary>
    public static class TypeAssert
    {
        /// <summary>
        /// Check if class has attribute.
        /// </summary>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <param name="attributeType">Type of the attribute.</param>
        /// <returns>TypeInfo.</returns>
        public static TypeInfo HasAttribute<TClass>(Type attributeType)
        {
            var typeInfo = typeof(TClass).GetTypeInfo();

            Assert.True(typeInfo.IsDefined(attributeType));

            return typeInfo;
        }

        /// <summary>
        /// Check if class has attribute.
        /// </summary>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <returns>TAttribute.</returns>
        public static TAttribute HasAttribute<TClass, TAttribute>()
            where TAttribute : Attribute
        {
            return HasAttribute<TClass>(typeof(TAttribute)).GetCustomAttribute<TAttribute>();
        }

        /// <summary>
        /// Check if property has attribute.
        /// </summary>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="attributeType">Type of the attribute.</param>
        /// <returns>PropertyInfo.</returns>
        public static PropertyInfo PropertyHasAttribute<TClass>(string propertyName, Type attributeType)
        {
            var propertyInfo = typeof(TClass).GetProperty(propertyName);

            Assert.NotNull(propertyInfo);

            Assert.True(propertyInfo.IsDefined(attributeType));

            return propertyInfo;
        }

        /// <summary>
        /// Check if property has attribute.
        /// </summary>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>TAttribute.</returns>
        public static TAttribute PropertyHasAttribute<TClass, TAttribute>(string propertyName)
            where TAttribute : Attribute
        {
            return PropertyHasAttribute<TClass>(propertyName, typeof(TAttribute)).GetCustomAttribute<TAttribute>();
        }

        /// <summary>
        /// Check if method has attribute.
        /// </summary>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="methodParametersTypes">The types of method parameters.</param>
        /// <param name="attributeType">Type of the attribute.</param>
        /// <returns>MethodInfo.</returns>
        public static MethodInfo MethodHasAttribute<TClass>(string methodName, Type[] methodParametersTypes, Type attributeType)
        {
            if (methodParametersTypes == null) methodParametersTypes = new Type[0];

            var methodInfo = typeof(TClass).GetMethod(methodName, methodParametersTypes);

            Assert.NotNull(methodInfo);

            Assert.True(methodInfo.IsDefined(attributeType));

            return methodInfo;
        }

        /// <summary>
        /// Check if method has attribute.
        /// </summary>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="methodParametersTypes">The types of method parameters.</param>
        /// <returns>TAttribute.</returns>
        public static TAttribute MethodHasAttribute<TClass, TAttribute>(string methodName, Type[] methodParametersTypes = null)
            where TAttribute : Attribute
        {
            return MethodHasAttribute<TClass>(methodName, methodParametersTypes, typeof(TAttribute)).GetCustomAttribute<TAttribute>();
        }
    }
}