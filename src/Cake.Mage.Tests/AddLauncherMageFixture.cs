namespace Cake.Mage.Tests;

internal class AddLauncherMageFixture : MageFixture<LauncherSettings>
{
    public AddLauncherMageFixture() : base("dotnet.exe")
    {
    }

    protected override void RunTool()
    {
        var runner = new LauncherMageTool(FileSystem, Environment, ProcessRunner, Tools, Registry, Log);
        runner.AddLauncher(Settings);
    }
}