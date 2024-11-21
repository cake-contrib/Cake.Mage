using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Mage
{
    internal class SignMageTool : MageTool<SignSettings>
    {
        /// <summary>
        /// Signs a mage deployment or application.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Sign(SignSettings settings) => Run(settings, GetSignArguments(settings));

        private ProcessArgumentBuilder GetSignArguments(SignSettings settings)
        {
            if (!string.IsNullOrWhiteSpace(settings.Password) && settings.CertFile == null)
            {
                throw new ArgumentException("Password requires CertFile to be set", nameof(settings.CertFile));
            }

            if (settings.FileToSign == null)
            {
                throw new ArgumentNullException(nameof(settings.FileToSign), "File to sign is required");
            }

            var builder = new ProcessArgumentBuilder();
            builder.Append("mage -Sign");
            builder.AppendQuoted(settings.FileToSign.MakeAbsolute(Environment).ToString());
            builder.AppendNonEmptySecretSwitch("-pwd", settings.Password);
            builder.AppendNonNullFilePathSwitch("-certFile", settings.CertFile, Environment);
            builder.AppendNonNullFilePathSwitch("-toFile", settings.ToFile, Environment);
            builder.AppendNonEmptyQuotedSwitch("-certHash", settings.CertHash);

            return builder;
        }

        internal SignMageTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools, IRegistry registry, ICakeLog log)
            : base(fileSystem, environment, processRunner, tools, registry, log)
        {
        }
    }
}