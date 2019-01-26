using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Aurochses.Xunit
{
    /// <summary>
    /// Configuration Fixture
    /// </summary>
    public class ConfigurationFixture
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFixture"/> class.
        /// </summary>
        /// <param name="defaultEnvironmentName">Default ASPNETCORE_ENVIRONMENT value.</param>
        public ConfigurationFixture(string defaultEnvironmentName = "Test")
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (string.IsNullOrWhiteSpace(environmentName))
            {
                environmentName = defaultEnvironmentName;
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfigurationRoot Configuration { get; set; }
    }
}