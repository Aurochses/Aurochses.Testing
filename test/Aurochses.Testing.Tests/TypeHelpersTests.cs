using System;
using Xunit;

namespace Aurochses.Testing.Tests
{
    public class TypeHelpersTests
    {
        [Fact]
        public void GenerateEmail_Success()
        {
            // Arrange
            var type = GetType();
            const string name = "TestEmailName";
            const string localPart = "TestLocalPart";
            const string domain = "TestDomain";

            // Act & Assert
            Assert.Equal($"{localPart}+{type.FullName}+{name}@{domain}", type.GenerateEmail(name, localPart, domain));
        }

        [Fact]
        public void GenerateEmail_WithDefaultValues_Success()
        {
            // Arrange
            var type = GetType();
            const string name = "TestEmailName";

            // Act & Assert
            Assert.Equal($"test+{type.FullName}+{name}@aurochses.com", type.GenerateEmail(name));
        }

        [Fact]
        public void GenerateEmail_ThrowArgumentOutOfRangeException_IfEmailLengthMoreThan256()
        {
            // Arrange
            var type = GetType();
            var name = new string('a', 256);
            const string localPart = "TestLocalPart";
            const string domain = "TestDomain";

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => type.GenerateEmail(name, localPart, domain));
            Assert.Equal("email", exception.ParamName);
            Assert.Equal($"{localPart}+{type.FullName}+{name}@{domain}", exception.ActualValue);
            Assert.Equal($"Email length must be less than 256 characters.\r\nParameter name: email\r\nActual value was {localPart}+{type.FullName}+{name}@{domain}.", exception.Message);
        }
    }
}