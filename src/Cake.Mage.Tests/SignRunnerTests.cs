using System;
using Shouldly;
using Xunit;

namespace Cake.Mage.Tests
{
    public class SignRunnerTests
    {
        [Fact]
        public void File_to_sign_is_required()
        {
            var fixture = new SignMageFixture("mage.exe")
            {
                Settings = new SignSettings()
            };

            Should.Throw<ArgumentNullException>(() => fixture.Run());
        }

        [Fact]
        public void CertFile_must_be_specified_with_password()
        {
            var fixture = new SignMageFixture("mage.exe")
            {
                Settings = new SignSettings("example.application")
                {
                    Password = "P@ssw0rd"
                }
            };

            Should.Throw<ArgumentException>(() => fixture.Run());
        }

        [Fact]
        public void Should_call_mage_with_certFile_and_password_if_specified()
        {
            var fixture = new SignMageFixture("mage.exe")
            {
                Settings = new SignSettings("./example.application")
                {
                    CertFile = "./file.pfx",
                    Password = "P@ssw0rd"
                }
            };

            fixture.Run().Args.ShouldBe("-sign \"/Working/example.application\" -pwd \"P@ssw0rd\" -certFile \"/Working/file.pfx\"");
        }

        [Fact]
        public void Should_call_mage_with_certHash_if_specified()
        {
            var fixture = new SignMageFixture("mage.exe")
            {
                Settings = new SignSettings("./example.application")
                {
                    CertHash = "abcdefg"
                }
            };

            fixture.Run().Args.ShouldBe("-sign \"/Working/example.application\" -certHash \"abcdefg\"");
        }

        [Fact]
        public void Should_call_mage_with_certFile_without_a_password()
        {
            var fixture = new SignMageFixture("mage.exe")
            {
                Settings = new SignSettings("./example.application")
                {
                    CertFile = "./file.pfx"
                }
            };

            fixture.Run().Args.ShouldBe("-sign \"/Working/example.application\" -certFile \"/Working/file.pfx\"");
        }

        [Fact]
        public void Shoud_call_mage_with_to_file_if_specified()
        {
            var fixture = new SignMageFixture("mage.exe")
            {
                Settings = new SignSettings("./example.application")
                {
                    ToFile = "./other-example.application"
                }
            };

            fixture.Run().Args.ShouldBe("-sign \"/Working/example.application\" -toFile \"/Working/other-example.application\"");
        }
    }
}