using Cake.Core;
using Cake.Core.IO;
using Cake.Testing;
using Shouldly;
using Xunit;

namespace Cake.Mage.Tests
{
    public class ResolverTests
    {
        //[Fact] doesn't work when mage.exe is not installed
        public void Can_resolve_mage()
        {
            var resolver = new DotNetToolResolver(new FileSystem(), new CakeEnvironment(new CakePlatform(), new CakeRuntime()), new WindowsRegistry(), new FakeLog());
            var path = resolver.GetPath("mage.exe");
            path.ShouldNotBe(null);
        }
    }
}