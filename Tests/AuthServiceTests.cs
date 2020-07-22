using FluentAssertions;
using NUnit.Framework;
using ServicesLibrary.DTO;
using ServicesLibrary.Implementations;
using ServicesLibrary.Interfaces;

namespace ServicesLibrary.Tests
{
    [TestFixture]
    public class AuthServiceTests
    {
        private readonly IAuthService _authService = new AuthService();

        [Test]
        public void SendCodeTests()
        {
            var sendDto = new SendCodePayload
            {
                PhoneNumber = "789654123",
                CountryCode = "PL",
                Fingerprint = "1337121111111"
            };

            var sendCodeResult = _authService.SendCode(sendDto);
            sendCodeResult.Should().NotBeNull();
            sendCodeResult.PhoneNumber.Should().Be("+48789654123");
        }

        [Test]
        public void SignUpTests()
        {
        }

        [Test]
        public void SignInTests()
        {
        }
    }
}