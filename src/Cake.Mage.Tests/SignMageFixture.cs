namespace Cake.Mage.Tests
{
    internal class SignMageFixture : MageFixture<SignSettings>
    {
        public SignMageFixture(string toolFilename) : base(toolFilename)
        {
        }

        protected override void RunTool()
        {
            var runner = new SignMageTool(FileSystem, Environment, ProcessRunner, Tools, Registry, Log);
            runner.Sign(Settings);
        }
    }
}