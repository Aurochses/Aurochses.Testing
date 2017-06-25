using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Extensions.PlatformAbstractions;
using Xunit;

namespace Aurochses.Testing.Tests
{
    public class ProjectHelpersTests
    {
        private readonly string _applicationBasePath;

        public ProjectHelpersTests()
        {
            _applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;
        }

        [Fact]
        public void GetPath_Success()
        {
            // Arrange
            const string solutionName = "Aurochses.Testing";

            var path = new Regex($@"\S+\\{solutionName}\\").Match(_applicationBasePath).Value;
            if (string.IsNullOrWhiteSpace(path))
            {
                path = new Regex(@"\S+\\Aurochses.Testing.Tests").Match(_applicationBasePath).Value;
                path = path.Replace(@"\test\Aurochses.Testing.Tests", string.Empty);
            }

            // Act & Assert
            Assert.Equal(Path.Combine(path, "src", "Aurochses.Testing"), ProjectHelpers.GetPath(solutionName, "src", "Aurochses.Testing"));
        }

        [Fact]
        public void GetPath_ThrowException_WhenSolutionNotFound()
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<Exception>(() => ProjectHelpers.GetPath("Test", "src", "Test"));
            Assert.Equal($"Solution root could not be located using application root {_applicationBasePath}.", exception.Message);
        }
    }
}