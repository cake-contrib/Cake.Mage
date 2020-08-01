using Cake.Core;
using Cake.Core.IO;
using Cake.Testing;
using Shouldly;
using Xunit;

namespace Cake.Mage.Tests
{
    public class ResolverTests
    {
        [Fact]
        public void Can_resolve_mage()
        {
            var resolver = new DotNetToolResolver(new FileSystem(), new CakeEnvironment(new CakePlatform(), new CakeRuntime(), new FakeLog()), new WindowsRegistry(), new FakeLog());
            var path = resolver.GetPath("mage.exe");
            path.ShouldNotBe(null);
        }
    }
}