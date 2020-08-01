using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing.Fixtures;
using NSubstitute;

namespace Cake.Mage.Tests
{
    internal abstract class MageFixture<TSettings> : ToolFixture<TSettings> where TSettings : ToolSettings, new()
    {
        public IRegistry Registry { get; }

        public ICakeLog Log { get; }

        public DotNetToolResolver DotNetToolResolver { get; }

        protected MageFixture(string toolFilename) : base(toolFilename)
        {
            Registry = Substitute.For<IRegistry>();
            Log = Substitute.For<ICakeLog>();
            DotNetToolResolver = new DotNetToolResolver(FileSystem, Environment, Registry, Log);
        }
    }
}