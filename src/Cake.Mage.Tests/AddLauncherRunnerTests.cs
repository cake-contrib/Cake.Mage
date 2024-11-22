using Shouldly;
using Xunit;

namespace Cake.Mage.Tests;

public class AddLauncherRunnerTests
{
    [Fact]
    public void Add_launcher_has_the_proper_command_line_switches()
    {
        var fixture = new AddLauncherMageFixture()
        {
            Settings = new LauncherSettings
            {
                EntryPoint = "some.dll",
                TargetDirectory = "dir"
            }
        };

        fixture.Run().Args.ShouldBe("Mage -AddLauncher \"some.dll\" -td \"/Working/dir\"");
    }
    [Fact]
    public void When_EntryPoint_is_not_set_throws()
    {
        var fixture = new AddLauncherMageFixture()
        {
            Settings = new LauncherSettings
            {
                TargetDirectory = "dir"
            }
        };

        Assert.Throws<ArgumentException>(() => fixture.Run());
    }
    [Fact]
    public void When_TargetDirectory_is_not_set_throws()
    {
        var fixture = new AddLauncherMageFixture()
        {
            Settings = new LauncherSettings
            {
                EntryPoint = "some.dll",
            }
        };

        Assert.Throws<ArgumentException>(() => fixture.Run());
    }
}