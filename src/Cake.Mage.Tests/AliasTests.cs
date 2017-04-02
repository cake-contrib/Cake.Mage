using System;
using Cake.Core;
using NSubstitute;
using Shouldly;
using Xunit;

namespace Cake.Mage.Tests
{
    public class AliasTests : IClassFixture<AliasTests.AliasFixture>
    {
        private readonly ICakeContext _context;

        public class AliasFixture
        {
            public AliasFixture()
            {
                var fixture = new NewAndUpdateMageFixture();

                FakeContext = Substitute.For<ICakeContext>();
                FakeContext.Environment.Returns(fixture.Environment);
                FakeContext.FileSystem.Returns(fixture.FileSystem);
                FakeContext.Globber.Returns(fixture.Globber);
                FakeContext.ProcessRunner.Returns(fixture.ProcessRunner);
                FakeContext.Registry.Returns(fixture.Registry);
                FakeContext.Tools.Returns(fixture.Tools);
            }

            public ICakeContext FakeContext { get; set; }
        }

        public AliasTests(AliasFixture aliasFixture)
        {
            _context = aliasFixture.FakeContext;
        }

        [Fact]
        public void Can_create_new_application()
        {
            _context.MageNewApplication(new NewApplicationSettings());
        }

        [Fact]
        public void Can_create_new_deployment()
        {
            _context.MageNewDeployment(new NewDeploymentSettings());
        }

        [Fact]
        public void Can_update_deployment()
        {
            _context.MageUpdateDeployment(new UpdateDeploymentSettings("./application.deployment"));
        }

        [Fact]
        public void Can_update_application()
        {
            _context.MageUpdateApplication(new UpdateApplicationSettings("./application.application"));
        }

        [Fact]
        public void Can_sign()
        {
            _context.MageSign(new SignSettings("./file.deployment"));
        }

        [Fact]
        public void New_application_throws_if_no_settings()
        {
            Should.Throw<ArgumentNullException>(() => _context.MageNewApplication(null));
        }

        [Fact]
        public void Update_application_throws_if_no_settings()
        {
            Should.Throw<ArgumentNullException>(() => _context.MageUpdateApplication(null));
        }

        [Fact]
        public void New_deployment_throws_if_no_settings()
        {
            Should.Throw<ArgumentNullException>(() => _context.MageNewDeployment(null));
        }

        [Fact]
        public void Update_delpoyment_throws_if_no_settings()
        {
            Should.Throw<ArgumentNullException>(() => _context.MageUpdateDeployment(null));
        }

        [Fact]
        public void Sign_throws_if_no_settings()
        {
            Should.Throw<ArgumentNullException>(() => _context.MageSign(null));
        }
    }
}