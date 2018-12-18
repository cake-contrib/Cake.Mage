using System;
using Shouldly;
using Xunit;

namespace Cake.Mage.Tests
{
    public class NewAndUpdateDeploymentRunnerTests
    {
        [Fact]
        public void New_deployment_has_the_proper_command_line_switches()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewDeploymentSettings()
            };

            fixture.Run().Args.ShouldBe("-new Deployment");
        }
        [Fact]
        public void Install_switch_should_be_omitted_when_false_or_default()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewDeploymentSettings { Install = false }
            };

            fixture.Run().Args.ShouldBe("-new Deployment");
        }
        [Fact]
        public void Install_switch_should_be_present_when_true()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewDeploymentSettings { Install = true }
            };

            fixture.Run().Args.ShouldBe("-new Deployment -i True");
        }

        [Fact]
        public void Update_deployment_has_the_proper_command_line_switches()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new UpdateDeploymentSettings("output.deployment")
            };

            fixture.Run().Args.ShouldBe("-update \"/Working/output.deployment\"");
        }

        [Fact]
        public void App_code_base_cannot_be_specified_as_both_a_uri_and_file_path()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new UpdateDeploymentSettings("output.deployment")
                {
                    AppCodeBaseFilePath = "./appcodebase/v1.0.0.0",
                    AppCodeBaseUri = new Uri("http://localhost/appcodebase")
                }
            };

            Should.Throw<ArgumentException>(() => fixture.Run());
        }

        [Fact]
        public void App_code_base_should_be_included_if_provided_and_file_path()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new UpdateDeploymentSettings("output.deployment")
                {
                    AppCodeBaseFilePath = "./appcodebase/v1.0.0.0"
                }
            };

            fixture.Run().Args.ShouldBe("-update \"/Working/output.deployment\" -appc \"appcodebase/v1.0.0.0\"");
        }

        [Fact]
        public void App_code_base_should_be_included_if_provided_and_uri()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new UpdateDeploymentSettings("output.deployment")
                {
                    AppCodeBaseUri = new Uri("http://localhost/appcodebase")
                }
            };

            fixture.Run().Args.ShouldBe("-update \"/Working/output.deployment\" -appc \"http://localhost/appcodebase\"");
        }

        [Fact]
        public void App_manifest_should_be_included()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new UpdateDeploymentSettings("output.deployment")
                {
                    AppManifest = "./app.manifest"
                }
            };

            fixture.Run().Args.ShouldBe("-update \"/Working/output.deployment\" -appm \"app.manifest\"");
        }

        [Fact]
        public void Min_version_should_be_included()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new UpdateDeploymentSettings("output.deployment")
                {
                    MinVersion = "1.0.0.0"
                }
            };

            fixture.Run().Args.ShouldBe("-update \"/Working/output.deployment\" -mv 1.0.0.0");
        }

        [Fact]
        public void Include_provider_url_should_be_included_if_false()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new UpdateDeploymentSettings("output.deployment")
                {
                    IncludeProviderUrl = false
                }
            };

            fixture.Run().Args.ShouldBe("-update \"/Working/output.deployment\" -ip False");
        }

        [Fact]
        public void Provider_url_should_be_included()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new UpdateDeploymentSettings("output.deployment")
                {
                    ProviderUrl = new Uri("http://localhost/provider")
                }
            };

            fixture.Run().Args.ShouldBe("-update \"/Working/output.deployment\" -pu \"http://localhost/provider\"");
        }
    }
}