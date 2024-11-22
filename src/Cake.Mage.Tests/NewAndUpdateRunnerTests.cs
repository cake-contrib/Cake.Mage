using System;
using Shouldly;
using Xunit;

namespace Cake.Mage.Tests
{
    public class NewAndUpdateRunnerTests
    {
        [Fact]
        public void Algorithm_should_not_be_included_if_notSha256Rsa()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewDeploymentSettings
                {
                    Algorithm = Algorithm.SHA256RSA
                }
            };

            fixture.Run().Args.ShouldBe("Mage -New Deployment");
        }

        [Fact]
        public void Password_requires_certfile_to_be_set()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewDeploymentSettings
                {
                    Password = "P@ssw0rd"
                }
            };

            Should.Throw<ArgumentException>(() => fixture.Run());
        }

        [Fact]
        public void Password_and_certfile_should_be_included()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewDeploymentSettings
                {
                    CertFile = "./example.pfx",
                    Password = "P@ssw0rd"
                }
            };

            fixture.Run().Args.ShouldBe("Mage -New Deployment -cf \"/Working/example.pfx\" -pwd \"P@ssw0rd\"");
        }

        [Fact]
        public void Cert_hash_should_be_included()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewDeploymentSettings
                {
                    CertHash = "12345abcdef"
                }
            };

            fixture.Run().Args.ShouldBe("Mage -New Deployment -certHash 12345abcdef");
        }

        [Fact]
        public void Name_should_be_included()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewDeploymentSettings
                {
                    Name = "My example app"
                }
            };

            fixture.Run().Args.ShouldBe("Mage -New Deployment -n \"My example app\"");
        }

        [Fact]
        public void Processor_should_be_included_if_not_MSIL()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewDeploymentSettings
                {
                    Processor = Processor.X86
                }
            };

            fixture.Run().Args.ShouldBe("Mage -New Deployment -p X86");
        }

        [Fact]
        public void Publisher_should_be_included()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewDeploymentSettings
                {
                    Publisher = "Example Co."
                }
            };

            fixture.Run().Args.ShouldBe("Mage -New Deployment -pub \"Example Co.\"");
        }

        [Fact]
        public void Support_url_should_be_included()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewDeploymentSettings
                {
                    SupportUrl = new Uri("http://localhost/support")
                }
            };

            fixture.Run().Args.ShouldBe("Mage -New Deployment -s \"http://localhost/support\"");
        }

        [Fact]
        public void Timestamp_should_be_included()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewDeploymentSettings
                {
                    TimeStampUri = new Uri("http://localhost/timestamp")
                }
            };

            fixture.Run().Args.ShouldBe("Mage -New Deployment -ti \"http://localhost/timestamp\"");
        }

        [Fact]
        public void To_file_should_be_included()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewDeploymentSettings
                {
                    ToFile = "./output.application"
                }
            };

            fixture.Run().Args.ShouldBe("Mage -New Deployment -t \"/Working/output.application\"");
        }

        [Fact]
        public void Version_should_be_included()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewDeploymentSettings
                {
                    Version = "1.2.3.4"
                }
            };

            fixture.Run().Args.ShouldBe("Mage -New Deployment -v 1.2.3.4");
        }

        [Fact]
        public void Wpf_browser_app_should_be_included_if_true()
        {
            var fixture = new NewAndUpdateMageFixture
            {
                Settings = new NewDeploymentSettings
                {
                    WpfBrowserApp = true
                }
            };

            fixture.Run().Args.ShouldBe("Mage -New Deployment -w True");
        }
    }
}