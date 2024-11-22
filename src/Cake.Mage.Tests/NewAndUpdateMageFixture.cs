namespace Cake.Mage.Tests;

internal class NewAndUpdateMageFixture : MageFixture<BaseNewAndUpdateMageSettings>
{
    public NewAndUpdateMageFixture() : base("dotnet.exe")
    {
    }

    protected override void RunTool()
    {
        var runner = new NewOrUpdateMageTool(FileSystem, Environment, ProcessRunner, Tools, Registry, Log);
        runner.NewOrUpdate(Settings);
    }
}
