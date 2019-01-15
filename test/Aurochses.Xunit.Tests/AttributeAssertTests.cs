using Aurochses.Xunit.Tests.Fakes;
using Xunit;
using Xunit.Sdk;

namespace Aurochses.Xunit.Tests
{
    public class AttributeAssertTests
    {
        [Fact]
        public void ValidateProperty_ThrowsNotNullExceptionIfNoAttribute()
        {
            // Arrange & Act & Assert
            Assert.Throws<NotNullException>(
                () => AttributeAssert.ValidateProperty(
                    typeof(FakeClassModel).GetProperty(nameof(FakeClassModel.Value)),
                    typeof(FakeClassAttribute),
                    "NoSuchProperty",
                    "TestValue"
                )
            );
        }

        [Fact]
        public void ValidateProperty_ThrowsNotNullExceptionIfNoAttributeProperty()
        {
            // Arrange & Act & Assert
            Assert.Throws<NotNullException>(
                () => AttributeAssert.ValidateProperty(
                    typeof(FakeClassModel).GetProperty(nameof(FakeClassModel.Value)),
                    typeof(FakePropertyAttribute),
                    "NoSuchProperty",
                    "TestValue"
                )
            );
        }

        [Fact]
        public void ValidateProperty_ThrowsEqualExceptionIfAttributePropertyValueNotEqual()
        {
            // Arrange & Act & Assert
            Assert.Throws<EqualException>(
                () => AttributeAssert.ValidateProperty(
                    typeof(FakeClassModel).GetProperty(nameof(FakeClassModel.Value)),
                    typeof(FakePropertyAttribute),
                    "Value",
                    "OtherValue"
                )
            );
        }

        [Fact]
        public void ValidateProperty_PublicProperty_Success()
        {
            // Arrange & Act & Assert
            AttributeAssert.ValidateProperty(
                typeof(FakeClassModel).GetProperty(nameof(FakeClassModel.Value)),
                typeof(FakePropertyAttribute),
                "Value",
                "TestValue"
            );
        }

        [Fact]
        public void ValidateProperty_ProtectedProperty_Success()
        {
            // Arrange & Act & Assert
            AttributeAssert.ValidateProperty(
                typeof(FakeClassModel).GetProperty(nameof(FakeClassModel.Value)),
                typeof(FakePropertyAttribute),
                "ProtectedValue",
                "TestProtectedValue"
            );
        }
    }
}