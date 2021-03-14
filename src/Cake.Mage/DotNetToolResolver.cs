using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;

namespace Cake.Mage
{
    /// <summary>
    /// Class DotNetToolResolver. This class cannot be inherited.
    /// </summary>
    internal sealed class DotNetToolResolver 
    {
        private readonly IFileSystem _fileSystem;
        private readonly ICakeEnvironment _environment;
        private readonly IRegistry _registry;
        private readonly ICakeLog _log;
        private FilePath _toolPath;

        public DotNetToolResolver(IFileSystem fileSystem, ICakeEnvironment environment, IRegistry registry, ICakeLog log)
        {
            if (fileSystem == null) throw new ArgumentNullException(nameof(fileSystem));
            if (registry == null) throw new ArgumentNullException(nameof(registry));
            if (environment == null) throw new ArgumentNullException(nameof(environment));

            _fileSystem = fileSystem;
            _environment = environment;
            _registry = registry;
            _log = log;
        }

        public FilePath GetPath(string toolExecutable)
        {
            if (string.IsNullOrWhiteSpace(toolExecutable)) throw new ArgumentNullException(nameof(toolExecutable));

            if (_toolPath != null)
            {
                return _toolPath;
            }

            // Try look for the path.
            _toolPath = GetFromDisc(toolExecutable) ?? GetFromRegistry(toolExecutable);
            if (_toolPath == null)
            {
                throw new CakeException($"Failed to find {toolExecutable}.");
            }

            // Return the sign tool path.
            return _toolPath;
        }

        private FilePath GetFromDisc(string toolExecutable)
        {
            // Get the path to program files.
            var programFilesX86 = _environment.GetSpecialPath(SpecialPath.ProgramFilesX86);
            var programFiles64Bit = _environment.GetSpecialPath(SpecialPath.ProgramFiles);

            // Gets a list of the files we should check.
            var toolDirectories = new List<DirectoryPath>
            {
                // 64-bit
                programFiles64Bit.Combine(@"Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools"),
                programFiles64Bit.Combine(@"Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7.2 Tools"),
                programFiles64Bit.Combine(@"Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7.1 Tools"),
                programFiles64Bit.Combine(@"Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7 Tools"),
                programFiles64Bit.Combine(@"Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools"),
                programFiles64Bit.Combine(@"Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6 Tools"),
                programFiles64Bit.Combine(@"Windows Kits\8.1\bin\x64"),
                programFiles64Bit.Combine(@"Windows Kits\8.0\bin\x64"),
                programFiles64Bit.Combine(@"Microsoft SDKs\Windows\v7.1A\Bin"),

                // x86
                programFilesX86.Combine(@"Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools"),
                programFilesX86.Combine(@"Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7.2 Tools"),
                programFilesX86.Combine(@"Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7.1 Tools"),
                programFilesX86.Combine(@"Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7 Tools"),
                programFilesX86.Combine(@"Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools"),
                programFilesX86.Combine(@"Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6 Tools"),
                programFilesX86.Combine(@"Windows Kits\8.1\bin\x86"),
                programFilesX86.Combine(@"Windows Kits\8.0\bin\x86"),
                programFilesX86.Combine(@"Microsoft SDKs\Windows\v7.1A\Bin")
            };

            foreach(var toolDirectory in toolDirectories)
            {
                var toolDirectoryExists = _fileSystem.Exist(toolDirectory);
                _log.Debug($"{typeof(DotNetToolResolver)}: \"{toolDirectory}\" {(toolDirectoryExists ? "found" : "not found")}.");
                
                if (toolDirectoryExists)
                {
                    var toolFile = toolDirectory.CombineWithFilePath(toolExecutable);
                    var toolFileExists = _fileSystem.Exist(toolFile);
                    _log.Debug($"{typeof(DotNetToolResolver)}: \"{toolFile}\" {(toolFileExists ? "found" : "not found")}.");

                    if (toolFileExists)
                        return toolFile;
                }
            }

            return null;
        }

        private FilePath GetFromRegistry(string toolExecutable)
        {
            using (var root = _registry.LocalMachine.OpenKey("Software\\Microsoft\\Microsoft SDKs\\Windows"))
            {
                if (root == null)
                {
                    return null;
                }

                var keyName = root.GetSubKeyNames();
                foreach (var key in keyName)
                {
                    var sdkKey = root.OpenKey(key);
                    var installationFolder = sdkKey?.GetValue("InstallationFolder") as string;
                    if (string.IsNullOrWhiteSpace(installationFolder))
                        continue;

                    var installationPath = new DirectoryPath(installationFolder);
                    var toolPath = installationPath.CombineWithFilePath($"bin\\{toolExecutable}");

                    if (_fileSystem.Exist(toolPath))
                    {
                        return toolPath;
                    }
                }
            }

            return null;
        }
    }
}