using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Mage
{
    internal sealed class DotNetToolResolver 
    {
        private readonly IFileSystem _fileSystem;
        private readonly ICakeEnvironment _environment;
        private readonly IRegistry _registry;
        private FilePath _toolPath;

        public DotNetToolResolver(IFileSystem fileSystem, ICakeEnvironment environment, IRegistry registry)
        {
            if (fileSystem == null) throw new ArgumentNullException(nameof(fileSystem));
            if (registry == null) throw new ArgumentNullException(nameof(registry));
            if (environment == null) throw new ArgumentNullException(nameof(environment));

            _fileSystem = fileSystem;
            _environment = environment;
            _registry = registry;
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
            var files = new List<FilePath>
            {
                // 64-bit
                programFiles64Bit.Combine(@"Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools").CombineWithFilePath(toolExecutable),
                programFiles64Bit.Combine(@"Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6 Tools").CombineWithFilePath(toolExecutable),
                programFiles64Bit.Combine(@"Windows Kits\8.1\bin\x64").CombineWithFilePath(toolExecutable),
                programFiles64Bit.Combine(@"Windows Kits\8.0\bin\x64").CombineWithFilePath(toolExecutable),
                programFiles64Bit.Combine(@"Microsoft SDKs\Windows\v7.1A\Bin").CombineWithFilePath(toolExecutable),

                // x86
                programFilesX86.Combine(@"Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools").CombineWithFilePath(toolExecutable),
                programFilesX86.Combine(@"Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6 Tools").CombineWithFilePath(toolExecutable),
                programFilesX86.Combine(@"Windows Kits\8.1\bin\x86").CombineWithFilePath(toolExecutable),
                programFilesX86.Combine(@"Windows Kits\8.0\bin\x86").CombineWithFilePath(toolExecutable),
                programFilesX86.Combine(@"Microsoft SDKs\Windows\v7.1A\Bin").CombineWithFilePath(toolExecutable)
            };

            // Return the first path that exist.
            return files.FirstOrDefault(file => _fileSystem.Exist(file));
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