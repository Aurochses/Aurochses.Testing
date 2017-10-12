using System;
using System.Reflection;
using Xunit;

namespace Aurochses.Xunit
{
    /// <summary>
    /// AttributeAssert.
    /// </summary>
    public static class AttributeAssert
    {
        /// <summary>
        /// Validate property of the attribute.
        /// </summary>
        /// <param name="memberInfo">The member information.</param>
        /// <param name="attributeType">Type of the attribute.</param>
        /// <param name="attributePropertyName">Name of property of the attribute.</param>
        /// <param name="attributePropertyValue">Value of property of the attribute.</param>
        public static void ValidateProperty(MemberInfo memberInfo, Type attributeType, string attributePropertyName, object attributePropertyValue)
        {
            var attribute = memberInfo.GetCustomAttribute(attributeType);

            Assert.NotNull(attribute);

            var attributeProperty = attributeType
                .GetProperty(
                    attributePropertyName,
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance
                );

            Assert.NotNull(attributeProperty);
            Assert.Equal(attributePropertyValue, attributeProperty.GetValue(attribute));
        }
    }
}