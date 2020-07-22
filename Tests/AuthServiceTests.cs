using System;
using AutoMapper;
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

        private readonly MapperConfiguration _sendCodeToSignUp = new MapperConfiguration(
            cfg => cfg.CreateMap<SendCodeResult, SignUpPayload>());

        [Test]
        public void SendCodeValidTest()
        {
            var sendDto = new SendCodePayload
            {
                PhoneNumber = "789654124",
                CountryCode = "PL",
                Fingerprint = "1337121111111"
            };

            var sendCodeResult = _authService.SendCode(sendDto);
            sendCodeResult.Should().NotBeNull();
            sendCodeResult.PhoneNumber.Should().Be("+48789654124");
        }

        [Test]
        public void SendCodeInvalidPhoneExceptionTest()
        {
            var sendDto = new SendCodePayload("12312", "PL", "1337121111111");
            Action a = () => _authService.SendCode(sendDto);
            a.Should().Throw<InvalidPhoneNumberFormatException>()
                .WithMessage("Phone must be 9 digits long, w/o country code");
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
        public void SignUpValidTest()
        {
            // create auth request
            var sendDto = new SendCodePayload
            {
                PhoneNumber = "789654127",
                CountryCode = "PL",
                Fingerprint = "1337121111111"
            };

            var sendCodeResult = _authService.SendCode(sendDto);
            sendCodeResult.Should().NotBeNull();
            sendCodeResult.PhoneNumber.Should().Be("+48789654127");

            // map auth request response
            var mapper = new Mapper(_sendCodeToSignUp);
            var signUpDto = mapper.Map<SendCodeResult, SignUpPayload>(sendCodeResult);

            // fill missing fields
            signUpDto.Name = "test_name3";
            signUpDto.PhoneCode = 22222;
            signUpDto.TermsOfServiceAccepted = true;

            // use created object with endpoint
            var signUpResult = _authService.SignUp(signUpDto);

            // check data
            signUpResult.User.Name.Should().Be("test_name3");
            signUpResult.AccessToken.Length.Should().BeGreaterThan(0);
            signUpResult.AccessToken.Should().NotBeNull();
            signUpResult.RefreshToken.Length.Should().BeGreaterThan(0);
            signUpResult.RefreshToken.Should().NotBeNull();
        }

        [Test]
        public void SignInTests()
        {
        }
    }
}