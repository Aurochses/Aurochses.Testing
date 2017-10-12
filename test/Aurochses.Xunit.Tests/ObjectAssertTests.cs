using System.Collections.Generic;
using Aurochses.Xunit.Tests.Fakes;
using Xunit;
using Xunit.Sdk;

namespace Aurochses.Xunit.Tests
{
    public class ObjectAssertTests
    {
        public static IEnumerable<object[]> ValueEqualsMemberData => new[]
        {
            new object[]
            {
                new ObjectAssertValueEqualsMemberDataModel {Value = null},
                new ObjectAssertValueEqualsMemberDataModel {Value = null},
                true
            },
            new object[]
            {
                new ObjectAssertValueEqualsMemberDataModel {Value = "One"},
                new ObjectAssertValueEqualsMemberDataModel {Value = "One"},
                true
            },
            new object[]
            {
                new ObjectAssertValueEqualsMemberDataModel {Value = "One"},
                new ObjectAssertValueEqualsMemberDataModel {Value = "Two"},
                false
            },
            new object[]
            {
                new ObjectAssertValueEqualsMemberDataModel {Value = null},
                new ObjectAssertValueEqualsMemberDataModel {Value = ""},
                false
            },
            new object[]
            {
                new ObjectAssertValueEqualsMemberDataModel {Value = ""},
                new ObjectAssertValueEqualsMemberDataModel {Value = null},
                false
            }
        };

        [Theory]
        [MemberData(nameof(ValueEqualsMemberData))]
        public void ValueEquals_Success(object expected, object actual, bool isEqual)
        {
            // Arrange & Act & Assert
            if (isEqual)
            {
                ObjectAssert.ValueEquals(expected, actual);
            }
            else
            {
                Assert.Throws<TrueException>(() => ObjectAssert.ValueEquals(expected, actual));
            }
        }
    }
}