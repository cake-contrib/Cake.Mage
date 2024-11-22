using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Mage;

internal class LauncherMageTool : MageTool<LauncherSettings>
{
    public LauncherMageTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, IRegistry registry, ICakeLog log) : base(fileSystem, environment, processRunner, tools, registry, log)
    {
    }
    public void AddLauncher(LauncherSettings settings) => Run(settings, GetAddLauncherArguments(settings));
    private ProcessArgumentBuilder GetAddLauncherArguments(LauncherSettings settings)
    {
        if (string.IsNullOrWhiteSpace(settings.EntryPoint) || settings.TargetDirectory is null)
        {
            throw new ArgumentException(nameof(settings));
        }
        return new ProcessArgumentBuilder()
                .Append("Mage -AddLauncher")
                .AppendQuoted(settings.EntryPoint)
                .AppendNonNullDirectoryPathSwitch("-td", settings.TargetDirectory, Environment);

    }
}
