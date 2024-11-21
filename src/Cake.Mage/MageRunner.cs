using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

[assembly: InternalsVisibleTo("Cake.Mage.Tests")]
namespace Cake.Mage
{
    /// <summary>
    /// The Mage tool runner.
    /// </summary>
    /// <typeparam name="TSettings">The type of the tool settings.</typeparam>
    /// <seealso cref="Cake.Core.Tooling.Tool{TSettings}" />
    internal abstract class MageTool<TSettings> : Tool<TSettings> where TSettings : ToolSettings
    {
        private const string Executable = "mage.exe";
        private readonly DotNetToolResolver _resolver;
        protected readonly ICakeEnvironment Environment;

        protected MageTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, IRegistry registry, ICakeLog log, DotNetToolResolver dotNetToolResolver) : base(fileSystem, environment, processRunner, tools)
        {
            Environment = environment;
            _resolver = dotNetToolResolver ?? new DotNetToolResolver(fileSystem, Environment, registry, log);
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override string GetToolName()
        {
            return "Mage.exe (Manifest Generation and Editing Tool)";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "dotnet", "dotnet.exe" };
        }

        /// <summary>
        /// Gets alternative file paths which the tool may exist in
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The default tool path.</returns>
        protected override IEnumerable<FilePath> GetAlternativeToolPaths(TSettings settings)
        {
            var path = _resolver.GetPath(Executable);
            return path != null
                ? new[] { path }
                : Enumerable.Empty<FilePath>();
        }
    }
}