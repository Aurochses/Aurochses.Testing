using System;
using Xunit;

namespace Aurochses.Xunit.Tests
{
    public class ConfigurationFixtureTests
    {
        [Fact]
        public void Configuration_ItemIsValue_WhenTestEnvironmentIsNotSet()
        {
            // Arrange & Act
            var fixture = new ConfigurationFixture();

            // Assert
            Assert.Equal("Value", fixture.Configuration["Item"]);
        }

        [Fact]
        public void Configuration_ItemIsTestValue_WhenTestEnvironmentIsTest()
        {
            // Arrange
            var currentAspNetCoreEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");

            // Act
            var fixture = new ConfigurationFixture();

            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", currentAspNetCoreEnvironment);

            // Assert
            Assert.Equal("TestValue", fixture.Configuration["Item"]);
        }
    }
}