using System;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;

namespace Aurochses.Testing
{
    /// <summary>
    /// ProjectHelpers.
    /// </summary>
    public static class ProjectHelpers
    {
        /// <summary>
        /// Gets the path of project's folder.
        /// </summary>
        /// <param name="solutionName">Name of the solution.</param>
        /// <param name="solutionRelativePath">The solution relative path.</param>
        /// <param name="projectName">Name of the project.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception"></exception>
        public static string GetFolderPath(string solutionName, string solutionRelativePath, string projectName)
        {
            // Get currently executing test project path
            var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;

            // Find the folder which contains the solution file. We then use this information to find the target
            // project which we want to test.
            var directoryInfo = new DirectoryInfo(applicationBasePath);
            do
            {
                var solutionFileInfo = new FileInfo(Path.Combine(directoryInfo.FullName, $"{solutionName}.sln"));
                if (solutionFileInfo.Exists)
                {
                    return Path.GetFullPath(Path.Combine(directoryInfo.FullName, solutionRelativePath, projectName));
                }

                directoryInfo = directoryInfo.Parent;
            }
            while (directoryInfo.Parent != null);

            throw new Exception($"Solution root could not be located using application root {applicationBasePath}.");
        }
    }
}