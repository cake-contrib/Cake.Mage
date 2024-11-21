using Cake.Core.IO;

namespace Cake.Mage;

/// <summary>
/// Class AddLauncherSettings.
/// </summary>
/// <seealso cref="Core.Tooling.ToolSettings" />
public class LauncherSettings : BaseNewAndUpdateMageSettings
{

    /// <summary>
    /// Gets or sets the launcher exe's folder.
    /// </summary>
    /// <value>To file.</value>
    public DirectoryPath? TargetDirectory { get; set; }

    /// <summary>
    /// Launchers entry point is DLL or EXE for .net6+ UI projects.
    /// </summary>
    public string? EntryPoint { get; set; }
}