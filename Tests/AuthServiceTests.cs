using System;
using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using ServicesLibrary.DTO;
using ServicesLibrary.Exceptions.Auth;
using ServicesLibrary.Implementations;
using ServicesLibrary.Interfaces;
using static ServicesLibrary.Auxiliaries.AuthServiceAuxiliaries;

namespace ServicesLibrary.Tests
{
    [TestFixture]
    public class AuthServiceTests
    {
        private readonly IAuthService _authService = new AuthService();
        private static readonly Mapper Mapper = CreateMapper();

        [Test]
        public void SendCodeValidTest()
        {
            const string phone = "789654154";
            const string countryCode = "PL";
            const string fingerPrint = "1337121111111";

            var sendCodeDto = new SendCodePayload(phone, countryCode, fingerPrint);

            var sendCodeResult = _authService.SendCode(sendCodeDto);
            sendCodeResult.Should().NotBeNull();
            sendCodeResult.PhoneNumber.Should().Be("+48" + phone);
            sendCodeResult.IsNew.Should().BeFalse(); // test is run not first time
            sendCodeResult.Timeout.Should().Be(120);
            sendCodeResult.CountryCode.Should().Be(countryCode);
            sendCodeResult.PhoneCodeHash.Should().NotBe(null);
            sendCodeResult.PhoneCodeHash.Should().NotBe(string.Empty);
        }

        [Test]
        public void SendCodeInvalidPhoneExceptionTest()
        {
            const string phone = "78";
            const string countryCode = "PL";
            const string fingerPrint = "1337121111111";

            var sendCodeDto = new SendCodePayload(phone, countryCode, fingerPrint);
            Action a = () => _authService.SendCode(sendCodeDto);
            a.Should().Throw<InvalidPhoneNumberFormatException>()
                .WithMessage("Phone must be 9 digits long, w/o country code");
        }

        [Test]
        public void SendCodeInvalidCountryCodeExceptionTest()
        {
            const string phone = "789654154";
            const string countryCode = "";
            const string fingerPrint = "1337121111111";

            var sendCodeDto = new SendCodePayload(phone, countryCode, fingerPrint);

            Action a = () => _authService.SendCode(sendCodeDto);
            a.Should().Throw<InvalidCountryCodeException>()
                .WithMessage("Country code cannot be null or empty");
        }

        [Test]
        public void SendCodeInvalidFingerprintExceptionTest()
        {
            const string phone = "789654154";
            const string countryCode = "PL";
            const string fingerPrint = "";

            var sendCodeDto = new SendCodePayload(phone, countryCode, fingerPrint);
            Action a = () => _authService.SendCode(sendCodeDto);
            a.Should().Throw<InvalidFingerprintFormatException>()
                .WithMessage("Fingerprint length must be 10 or more digits");
        }

        [Test]
        public void SignUpValidTest()
        {
            const string phone = "789654168";
            const string countryCode = "PL";
            const string fingerPrint = "1337121111111";
            const string name = "test_name4";
            const int phoneCode = 22222;
            const bool accepted = true;

            var sendCodeDto = new SendCodePayload(phone, countryCode, fingerPrint);

            var sendCodeResult = _authService.SendCode(sendCodeDto);
            sendCodeResult.Should().NotBeNull();
            sendCodeResult.PhoneNumber.Should().Be("+48" + phone);

            // map auth request response
            var signUpDto = Mapper.Map<SignUpPayload>(sendCodeResult);

            // fill missing fields
            signUpDto.Name = name;
            signUpDto.PhoneCode = phoneCode;
            signUpDto.TermsOfServiceAccepted = accepted;

            // use created object with endpoint
            var signUpResult = _authService.SignUp(signUpDto);

            // check data
            signUpResult.User.Name.Should().Be(name);
            signUpResult.AccessToken.Length.Should().BeGreaterThan(0);
            signUpResult.AccessToken.Should().NotBeNull();
            signUpResult.AccessToken.Should().NotBe(string.Empty);
            signUpResult.RefreshToken.Length.Should().BeGreaterThan(0);
            signUpResult.RefreshToken.Should().NotBeNull();
            signUpResult.RefreshToken.Should().NotBe(string.Empty);
        }

        [Test]
        public void SignUpTermsOfServiceNotAcceptedExceptionTest()
        {
        }

        [Test]
        public void SignInValidTest()
        {
            const string phone = "789654154";
            const string countryCode = "PL";
            const string fingerPrint = "1337121111111";

            var sendCodeDto = new SendCodePayload(phone, countryCode, fingerPrint);

            var sendCodeResult = _authService.SendCode(sendCodeDto);
            sendCodeResult.Should().NotBeNull();
            sendCodeResult.PhoneNumber.Should().Be("+48" + phone);
            sendCodeResult.IsNew.Should().BeFalse(); // test is run not first time
            sendCodeResult.Timeout.Should().Be(120);
            sendCodeResult.CountryCode.Should().Be(countryCode);
            sendCodeResult.PhoneCodeHash.Should().NotBe(null);
            sendCodeResult.PhoneCodeHash.Should().NotBe(string.Empty);
            
            // sign in try
            var signInDto = Mapper.Map<SignInPayload>(sendCodeResult);
            signInDto.PhoneCode = 22222;

            var signInResult = _authService.SignIn(signInDto);
            signInResult.Should().NotBeNull();
            signInResult.User.Should().NotBeNull();
            signInResult.User.Name.Should().Be("test_name4");
            signInResult.User.Id.Should().Be(13);
        }
    }
}