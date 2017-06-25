using System;
using Xunit;

namespace Aurochses.Testing.Tests
{
    public class EmailHelpersTests
    {
        [Fact]
        public void Create_Success()
        {
            // Arrange
            var type = GetType();
            const string name = "TestEmailName";
            const string localPart = "TestLocalPart";
            const string domain = "TestDomain";

            // Act & Assert
            Assert.Equal($"{localPart}+{type.FullName}+{name}@{domain}", EmailHelpers.Create(type, name, localPart, domain));
        }

        [Fact]
        public void Create_WithDefaultValues_Success()
        {
            // Arrange
            var type = GetType();
            const string name = "TestEmailName";

            // Act & Assert
            Assert.Equal($"test+{type.FullName}+{name}@aurochses.com", EmailHelpers.Create(type, name));
        }

        [Fact]
        public void Create_ThrowArgumentOutOfRangeException_IfEmailLengthMoreThan256()
        {
            // Arrange
            var type = GetType();
            var name = new string('a', 256);

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => EmailHelpers.Create(type, name));
            Assert.Equal("email", exception.ParamName);
            Assert.Equal($"test+{type.FullName}+{name}@aurochses.com", exception.ActualValue);
            Assert.Equal($"Email length must be less than 256 characters.\r\nParameter name: email\r\nActual value was test+{type.FullName}+{name}@aurochses.com.", exception.Message);
        }
    }
}