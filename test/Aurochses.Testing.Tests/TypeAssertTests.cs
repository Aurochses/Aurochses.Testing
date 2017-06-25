using System.Reflection;
using Aurochses.Testing.Tests.Fakes;
using Xunit;
using Xunit.Sdk;

namespace Aurochses.Testing.Tests
{
    public class TypeAssertTests
    {
        [Fact]
        public void HasAttribute_ThrowsTrueExceptionIfNoAttribute()
        {
            // Arrange & Act & Assert
            Assert.Throws<TrueException>(
                () => TypeAssert.HasAttribute<FakeClassModel>(
                    typeof(FakePropertyAttribute)
                )
            );
        }

        [Fact]
        public void HasAttribute_Success()
        {
            // Arrange & Act & Assert
            var typeInfo = TypeAssert.HasAttribute<FakeClassModel>(typeof(FakeClassAttribute));

            Assert.NotNull(typeInfo);
            Assert.IsAssignableFrom<TypeInfo>(typeInfo);
        }

        [Fact]
        public void HasAttributeGeneric_Success()
        {
            // Arrange & Act & Assert
            var attribute = TypeAssert.HasAttribute<FakeClassModel, FakeClassAttribute>();

            Assert.NotNull(attribute);
            Assert.IsAssignableFrom<FakeClassAttribute>(attribute);
        }

        [Fact]
        public void PropertyHasAttribute_ThrowsNotNullExceptionIfNoProperty()
        {
            // Arrange & Act & Assert
            Assert.Throws<NotNullException>(
                () => TypeAssert.PropertyHasAttribute<FakeClassModel>(
                    "NoSuchProperty",
                    typeof(FakePropertyAttribute)
                )
            );
        }

        [Fact]
        public void PropertyHasAttribute_ThrowsTrueExceptionIfNoAttribute()
        {
            // Arrange & Act & Assert
            Assert.Throws<TrueException>(
                () => TypeAssert.PropertyHasAttribute<FakeClassModel>(
                    nameof(FakeClassModel.Value),
                    typeof(FakeClassAttribute)
                )
            );
        }

        [Fact]
        public void PropertyHasAttribute_Success()
        {
            // Arrange & Act & Assert
            var propertyInfo = TypeAssert.PropertyHasAttribute<FakeClassModel>(nameof(FakeClassModel.Value), typeof(FakePropertyAttribute));

            Assert.NotNull(propertyInfo);
            Assert.IsAssignableFrom<PropertyInfo>(propertyInfo);
        }

        [Fact]
        public void PropertyHasAttributeGeneric_Success()
        {
            // Arrange & Act & Assert
            var attribute = TypeAssert.PropertyHasAttribute<FakeClassModel, FakePropertyAttribute>(nameof(FakeClassModel.Value));

            Assert.NotNull(attribute);
            Assert.IsAssignableFrom<FakePropertyAttribute>(attribute);
        }

        [Fact]
        public void MethodHasAttribute_WithNullMethodParametersTypes_Success()
        {
            // Arrange & Act & Assert
            var methodInfo = TypeAssert.MethodHasAttribute<FakeClassModel>(nameof(FakeClassModel.Get), null, typeof(FakeMethodAttribute));

            Assert.NotNull(methodInfo);
            Assert.IsAssignableFrom<MethodInfo>(methodInfo);
        }

        [Fact]
        public void MethodHasAttribute_ThrowsNotNullExceptionIfNoMethod()
        {
            // Arrange & Act & Assert
            Assert.Throws<NotNullException>(
                () => TypeAssert.MethodHasAttribute<FakeClassModel>(
                    "NoSuchMethod",
                    null,
                    typeof(FakeMethodAttribute)
                )
            );
        }

        [Fact]
        public void MethodHasAttribute_ThrowsTrueExceptionIfNoAttribute()
        {
            // Arrange & Act & Assert
            Assert.Throws<TrueException>(
                () => TypeAssert.MethodHasAttribute<FakeClassModel>(
                    nameof(FakeClassModel.Get),
                    null,
                    typeof(FakeClassAttribute)
                )
            );
        }

        [Fact]
        public void MethodHasAttribute_Success()
        {
            // Arrange & Act & Assert
            var methodInfo = TypeAssert.MethodHasAttribute<FakeClassModel>(nameof(FakeClassModel.Get), new[] { typeof(string) }, typeof(FakeMethodAttribute));

            Assert.NotNull(methodInfo);
            Assert.IsAssignableFrom<MethodInfo>(methodInfo);
        }

        [Fact]
        public void MethodHasAttributeGeneric_Success()
        {
            // Arrange & Act & Assert
            var attribute = TypeAssert.MethodHasAttribute<FakeClassModel, FakeMethodAttribute>(nameof(FakeClassModel.Get), new[] { typeof(string) });

            Assert.NotNull(attribute);
            Assert.IsAssignableFrom<FakeMethodAttribute>(attribute);
        }

        [Fact]
        public void MethodHasAttributeGeneric_WithNullMethodParametersTypes_Success()
        {
            // Arrange & Act & Assert
            var attribute = TypeAssert.MethodHasAttribute<FakeClassModel, FakeMethodAttribute>(nameof(FakeClassModel.Get));

            Assert.NotNull(attribute);
            Assert.IsAssignableFrom<FakeMethodAttribute>(attribute);
        }
    }
}