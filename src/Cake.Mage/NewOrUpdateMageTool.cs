using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Mage
{
    internal class NewOrUpdateMageTool : MageTool<BaseNewAndUpdateMageSettings>
    {
        /// <summary>
        /// Runs a new or update Mage.exe command
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void NewOrUpdate(BaseNewAndUpdateMageSettings settings) => Run(settings, GetNewOrUpdateArguments(settings));

        private ProcessArgumentBuilder GetNewOrUpdateArguments(BaseNewAndUpdateMageSettings settings)
        {
            if (string.IsNullOrWhiteSpace(settings.Password) == false && settings.CertFile == null)
                throw new ArgumentException("Password requires CertFile to be set", nameof(settings.CertFile));

            var builder = new ProcessArgumentBuilder();
            var newOrUpdateApplicationSettings = settings as BaseNewAndUpdateApplicationSettings;
            
            if (newOrUpdateApplicationSettings != null)
            {
                if (newOrUpdateApplicationSettings is NewApplicationSettings)
                {
                    builder = builder.Append("-new Application");
                }
                else
                {
                    var updatePath = ((UpdateApplicationSettings)newOrUpdateApplicationSettings).FileToUpdate.MakeAbsolute(Environment).FullPath;
                    builder = builder.AppendSwitchQuoted("-update", updatePath);
                }

                builder = builder.AppendNonNullDirectoryPathSwitch("-fd", newOrUpdateApplicationSettings.FromDirectory, Environment)
                    .AppendNonNullRelativeFilePathSwitch("-if", newOrUpdateApplicationSettings.IconFile, Environment)
                    .AppendIfNotDefaultSwitch("-tr", newOrUpdateApplicationSettings.TrustLevel, TrustLevel.Default)
                    .AppendIfNotDefaultSwitch("-um", newOrUpdateApplicationSettings.UseManifestForTrust, false);
            }
            else
            {
                var newOrUpdateDeploymentSettings = (BaseNewAndUpdateDeploymentSettings)settings;

                if (newOrUpdateDeploymentSettings.AppCodeBaseUri != null &&
                    newOrUpdateDeploymentSettings.AppCodeBaseFilePath != null)
                    throw new ArgumentException("Both AppCodeBaseUri and AppCodeBaseFilePath cannot be specified.");

                if (newOrUpdateDeploymentSettings is NewDeploymentSettings)
                {
                    builder = builder.Append("-new Deployment");
                }
                else
                {
                    var updatePath = ((UpdateDeploymentSettings)newOrUpdateDeploymentSettings).FileToUpdate.MakeAbsolute(Environment).FullPath;
                    builder = builder.AppendSwitchQuoted("-update", updatePath);
                }

                builder = builder
                    .AppendNonNullUriSwitch("-appc", newOrUpdateDeploymentSettings.AppCodeBaseUri)
                    .AppendNonNullRelativeFilePathSwitch("-appc", newOrUpdateDeploymentSettings.AppCodeBaseFilePath, Environment)
                    .AppendNonNullRelativeFilePathSwitch("-appm", newOrUpdateDeploymentSettings.AppManifest, Environment)
                    .AppendIfNotDefaultSwitch("-i", newOrUpdateDeploymentSettings.Install, false)
                    .AppendNonEmptySwitch("-mv", newOrUpdateDeploymentSettings.MinVersion)
                    .AppendIfNotDefaultSwitch("-ip", newOrUpdateDeploymentSettings.IncludeProviderUrl, true)
                    .AppendNonNullUriSwitch("-pu", newOrUpdateDeploymentSettings.ProviderUrl);
            }

            return builder
                .AppendIfNotDefaultSwitch("-a", settings.Algorithm, Algorithm.SHA1RSA)
                .AppendNonNullFilePathSwitch("-cf", settings.CertFile, Environment)
                .AppendNonEmptySwitch("-certHash", settings.CertHash)
                .AppendNonEmptyQuotedSwitch("-n", settings.Name)
                .AppendNonEmptySecretSwitch("-pwd", settings.Password)
                .AppendIfNotDefaultSwitch("-p", settings.Processor, Processor.Msil)
                .AppendNonEmptyQuotedSwitch("-pub", settings.Publisher)
                .AppendNonNullUriSwitch("-s", settings.SupportUrl)
                .AppendNonNullUriSwitch("-ti", settings.TimeStampUri)
                .AppendNonNullFilePathSwitch("-t", settings.ToFile, Environment)
                .AppendNonEmptySwitch("-v", settings.Version)
                .AppendIfNotDefaultSwitch("-w", settings.WpfBrowserApp, false);            
        }

        internal NewOrUpdateMageTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, IRegistry registry, ICakeLog log, DotNetToolResolver dotNetToolResolver) : base(fileSystem, environment, processRunner, tools, registry, log, dotNetToolResolver)
        {
        }
    }
}