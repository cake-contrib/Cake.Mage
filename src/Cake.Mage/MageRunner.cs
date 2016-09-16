using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Mage
{
    /// <summary>
    /// The Mage tool runner.
    /// </summary>
    internal abstract class MageTool<TSettings> : Tool<TSettings> where TSettings : ToolSettings
    {
        private const string Executable = "mage.exe";
        private readonly DotNetToolResolver _resolver;
        protected readonly ICakeEnvironment Environment;

        protected MageTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, IRegistry registry, DotNetToolResolver dotNetToolResolver) : base(fileSystem, environment, processRunner, tools)
        {
            Environment = environment;
            _resolver = dotNetToolResolver ?? new DotNetToolResolver(fileSystem, Environment, registry);
        }
        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override string GetToolName()
        {
            return "Mage.exe (Manifest Generation and Editing Tool)";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new [] { Executable };
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

    internal class NewOrUpdateMageTool : MageTool<BaseNewAndUpdateMageSettings>
    {
        /// <summary>
        /// Runs a new or update Mage.exe command
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void NewOrUpdate(BaseNewAndUpdateMageSettings settings) => Run(settings, GetArguments(settings));

        private ProcessArgumentBuilder GetArguments( BaseNewAndUpdateMageSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            var newOrUpdateApplicationSettings = settings as BaseNewAndUpdateApplicationSettings;
            
            if (newOrUpdateApplicationSettings != null)
            {
                if (newOrUpdateApplicationSettings is NewApplicationSettings)
                    builder = builder.Append("-new Application");
                else
                    builder = builder.Append("-update");

                builder = builder.AppendNonNullDirectoryPathSwitch("-fd", newOrUpdateApplicationSettings.FromDirectory, Environment)
                        .AppendNonNullFilePathSwitch("-if", newOrUpdateApplicationSettings.IconFile, Environment)
                        .AppendIfNotDefaultSwitch("-tr", newOrUpdateApplicationSettings.TrustLevel, TrustLevel.Default)
                        .AppendIfNotDefaultSwitch("-um", newOrUpdateApplicationSettings.UseManifestForTrust, false);
            }
            else
            {
                var newOrUpdateDeploymentSettings = (BaseNewAndUpdateDeploymentSettings) settings;
                if (newOrUpdateDeploymentSettings is NewDeploymentSettings)
                    builder = builder.Append("-new Deployment");
                else
                    builder = builder.Append("-update");
                builder = builder
                    .AppendNonEmptySwitch("-appc", newOrUpdateDeploymentSettings.AppCodeBase)
                    .AppendNonNullFilePathSwitch("-appm", newOrUpdateDeploymentSettings.AppManifest, Environment)
                    .AppendIfNotDefaultSwitch("-i", newOrUpdateDeploymentSettings.Install, true)
                    .AppendNonEmptySwitch("-mv", newOrUpdateDeploymentSettings.MinVersion)
                    .AppendNonNullSwitch("-pu", newOrUpdateDeploymentSettings.ProviderUrl);
            }

            return builder
                .AppendIfNotDefaultSwitch("-a", settings.Algorithm, Algorithm.SHA1RSA)
                .AppendNonNullFilePathSwitch("-cf", settings.CertFile, Environment)
                .AppendNonEmptySwitch("-certHash", settings.CertHash)
                .AppendNonEmptyQuotedSwitch("-n", settings.Name)
                .AppendNonEmptySecretSwitch("-pwd", settings.Password)
                .AppendIfNotDefaultSwitch("-p", settings.Processor, Processor.Msil)
                .AppendNonEmptySwitch("-pub", settings.Publisher)
                .AppendNonNullSwitch("-s", settings.SupportUrl)
                .AppendNonNullSwitch("-ti", settings.TimeStampUri)
                .AppendNonNullFilePathSwitch("-t", settings.ToFile, Environment)
                .AppendNonEmptySwitch("-v", settings.Version)
                .AppendIfNotDefaultSwitch("-w", settings.WpfBrowserApp, false);            
        }

        internal NewOrUpdateMageTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, IRegistry registry, DotNetToolResolver dotNetToolResolver) : base(fileSystem, environment, processRunner, tools, registry, dotNetToolResolver)
        {
        }
    }
}