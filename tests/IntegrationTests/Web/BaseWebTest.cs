using Academia.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;

namespace IntegrationTests.Web
{
    public abstract class BaseWebTest
    {

        protected readonly HttpClient _client;
        protected string _contentRoot;

        public BaseWebTest()
        {
            _client = GetClient();
        }

        private HttpClient GetClient()
        {
            var startUpAssembly = typeof(Startup).GetTypeInfo().Assembly;
            _contentRoot = GetProjectPath("src", startUpAssembly);
            var builder = new WebHostBuilder()
                .UseContentRoot(_contentRoot)
                .UseStartup<Startup>()
                .UseEnvironment("Testing");

            var server = new TestServer(builder);
            return server.CreateClient();
        }

        /// <summary>
        /// Gets the full path to the target project path that we wish to test
        /// </summary>
        /// <param name="solutionRelativePath">
        /// The parent directory of the target project.
        /// e.g. src, samples, test, or test/Websites
        /// </param>
        /// <param name="startupAssembly">The target project's assembly.</param>
        /// <returns>The full path to the target project.</returns>
        private static string GetProjectPath(string solutionRelativePath, Assembly startupAssembly)
        {
            // Get name of the target project which we want to test
            var projectName = startupAssembly.GetName().Name;

            // Get currently executing test project path
            var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;

            // Find the folder which contains the solution file. We then use this information to find the target
            // project which we want to test.
            var directoryInfo = new DirectoryInfo(applicationBasePath);
            do
            {
                var solutionFileInfo = new FileInfo(Path.Combine(directoryInfo.FullName, "Academia.sln"));
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
