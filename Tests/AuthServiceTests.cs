using System;
using FluentAssertions;
using NUnit.Framework;
using ServicesLibrary.DTO;
using ServicesLibrary.Exceptions.Auth;
using ServicesLibrary.Implementations;
using ServicesLibrary.Interfaces;

namespace ServicesLibrary.Tests
{
    [TestFixture]
    public class AuthServiceTests
    {
        private readonly IAuthService _authService = new AuthService();

        [Test]
        public void SendCodeValidTest()
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
        public void SendCodeInvalidPhoneExceptionTest()
        {
            var sendDto = new SendCodePayload("12312", "PL", "1337121111111");
            Action a = () => _authService.SendCode(sendDto);
            a.Should().Throw<InvalidPhoneNumberFormatException>()
                .WithMessage("Phone must be 9 digits long");
        }

        [Test]
        public void SendCodeInvalidCountryCodeExceptionTest()
        {
            var sendDto = new SendCodePayload("789654123", "", "1337121111111");
            Action a = () => _authService.SendCode(sendDto);
            a.Should().Throw<InvalidCountryCodeException>()
                .WithMessage("Country code cannot be null or empty");
        }

        [Test]
        public void SendCodeInvalidFingerprintExceptionTest()
        {
            var sendDto = new SendCodePayload("789654123", "PL", "");
            Action a = () => _authService.SendCode(sendDto);
            a.Should().Throw<InvalidFingerprintFormatException>()
                .WithMessage("Fingerprint length must be 10 or more digits");
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