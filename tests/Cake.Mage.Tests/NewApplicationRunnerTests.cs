using Shouldly;
using Xunit;

namespace Cake.Mage.Tests
{
    public class NewAndUpdateApplicationRunnerTests
    {
        [Fact]
        public void New_application_has_the_proper_command_line_switches()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewApplicationSettings()
            };

            fixture.Run().Args.ShouldBe("-new Application");
        }

        [Fact]
        public void Update_application_has_the_proper_command_line_switches()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new UpdateApplicationSettings("output.application")
            };

            fixture.Run().Args.ShouldBe("-update \"/Working/output.application\"");
        }

        [Fact]
        public void From_directory_should_be_included()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewApplicationSettings
                {
                    FromDirectory = "./source"
                }
            };

            fixture.Run().Args.ShouldBe("-new Application -fd \"/Working/source\"");
        }

        [Fact]
        public void To_file_should_be_included()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewApplicationSettings
                {
                    ToFile = "example.application"
                }
            };

            fixture.Run().Args.ShouldBe("-new Application -t \"/Working/example.application\"");
        }

        [Fact]
        public void Icon_file_should_be_included()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewApplicationSettings
                {
                    IconFile = "example.ico"
                }
            };

            fixture.Run().Args.ShouldBe("-new Application -if \"/Working/example.ico\"");
        }

        [Fact]
        public void Trust_level_should_be_included()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewApplicationSettings
                {
                    TrustLevel = TrustLevel.FullTrust
                }
            };

            fixture.Run().Args.ShouldBe("-new Application -tr FullTrust");
        }

        [Fact]
        public void Use_manifest_for_trust_should_be_included_if_true()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewApplicationSettings
                {
                    UseManifestForTrust = true
                }
            };

            fixture.Run().Args.ShouldBe("-new Application -um True");
        }
    }
}