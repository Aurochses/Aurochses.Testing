using System.Collections.Generic;
using Aurochses.Xunit.Tests.Fakes;
using Xunit;
using Xunit.Sdk;

namespace Aurochses.Xunit.Tests
{
    public class ObjectAssertTests
    {
        public static IEnumerable<object[]> ValueEqualsSuccessMemberData => new[]
        {
            new object[]
            {
                new ObjectAssertValueEqualsMemberDataModel {Value = null},
                new ObjectAssertValueEqualsMemberDataModel {Value = null}
            },
            new object[]
            {
                new ObjectAssertValueEqualsMemberDataModel {Value = "One"},
                new ObjectAssertValueEqualsMemberDataModel {Value = "One"}
            }
        };

        [Theory]
        [MemberData(nameof(ValueEqualsSuccessMemberData))]
        public void ValueEquals_Success(object expected, object actual)
        {
            // Arrange & Act & Assert
            ObjectAssert.DeepEquals(expected, actual);
        }

        public static IEnumerable<object[]> ValueEqualsThrowsAssertActualExpectedExceptionMemberData => new[]
        {
            new object[]
            {
                new ObjectAssertValueEqualsMemberDataModel {Value = "One"},
                new ObjectAssertValueEqualsMemberDataModel {Value = "Two"},
                @"
Begin Differences (1 differences):
Types [String,String], Item Expected.Value != Actual.Value, Values (One,Two)
End Differences (Maximum of 1 differences shown).
Expected: ObjectAssertValueEqualsMemberDataModel { Value = ""One"" }
Actual:   ObjectAssertValueEqualsMemberDataModel { Value = ""Two"" }"
            },
            new object[]
            {
                new ObjectAssertValueEqualsMemberDataModel {Value = null},
                new ObjectAssertValueEqualsMemberDataModel {Value = ""},
                @"
Begin Differences (1 differences):
Types [null,String], Item Expected.Value != Actual.Value, Values ((null),)
End Differences (Maximum of 1 differences shown).
Expected: ObjectAssertValueEqualsMemberDataModel { Value = null }
Actual:   ObjectAssertValueEqualsMemberDataModel { Value = """" }"
            },
            new object[]
            {
                new ObjectAssertValueEqualsMemberDataModel {Value = ""},
                new ObjectAssertValueEqualsMemberDataModel {Value = null},
                @"
Begin Differences (1 differences):
Types [String,null], Item Expected.Value != Actual.Value, Values (,(null))
End Differences (Maximum of 1 differences shown).
Expected: ObjectAssertValueEqualsMemberDataModel { Value = """" }
Actual:   ObjectAssertValueEqualsMemberDataModel { Value = null }"
            }
        };

        [Theory]
        [MemberData(nameof(ValueEqualsThrowsAssertActualExpectedExceptionMemberData))]
        public void ValueEquals_ThrowsAssertActualExpectedException(object expected, object actual, string exceptionMessage)
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<AssertActualExpectedException>(() => ObjectAssert.DeepEquals(expected, actual));

            Assert.Equal(exceptionMessage, exception.Message);
        }
    }
}