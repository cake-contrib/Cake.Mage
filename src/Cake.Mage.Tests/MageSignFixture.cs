using Cake.Core.Tooling;
using NSubstitute;

namespace Cake.Mage.Tests
{
    internal abstract class MageFixture<TSettings> : ToolFixture<TSettings> where TSettings : ToolSettings, new()
    {
        public IRegistry Registry { get; }

        public ICakeLog Log { get; }


        protected MageFixture(string toolFilename) : base(toolFilename)
        {
            Registry = Substitute.For<IRegistry>();
            Log = Substitute.For<ICakeLog>();
        }
    }
}