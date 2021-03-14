namespace Cake.Mage.Tests
{
    internal class NewAndUpdateMageFixture : MageFixture<BaseNewAndUpdateMageSettings>
    {
        public NewAndUpdateMageFixture() : base("mage.exe")
        {
        }

        protected override void RunTool()
        {
            var runner = new NewOrUpdateMageTool(FileSystem, Environment, ProcessRunner, Tools, Registry, Log, DotNetToolResolver);
            runner.NewOrUpdate(Settings);
        }
    }
}