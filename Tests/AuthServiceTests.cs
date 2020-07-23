using System;
using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using ServicesLibrary.DTO;
using ServicesLibrary.Exceptions.Auth;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Services;
using static ServicesLibrary.MapperFiles.MapperFactory;

namespace ServicesLibrary.Tests
{
    [TestFixture]
    public class AuthServiceTests
    {
        private readonly IAuthService _authService = new AuthService();
        private static readonly Mapper Mapper = GetMapperInstance();

        [Test]
        public void SendCodeValidTest()
        {
            const string phone = "789654154";
            const string countryCode = "PL";
            const string fingerPrint = "1337121111111";

            var sendCodePayload = new SendCodePayload(phone, countryCode, fingerPrint);

            var authRequest = _authService.SendCode(sendCodePayload);
            authRequest.Should().NotBeNull();
            authRequest.PhoneNumber.Should().Be("+48" + phone);
            authRequest.IsNew.Should().BeFalse(); // test is run not first time
            authRequest.Timeout.Should().Be(120);
            authRequest.CountryCode.Should().Be(countryCode);
            authRequest.PhoneCodeHash.Should().NotBe(null);
            authRequest.PhoneCodeHash.Should().NotBe(string.Empty);
        }

        [Test]
        public void SendCodeInvalidPhoneExceptionTest()
        {
            const string phone = "78";
            const string countryCode = "PL";
            const string fingerPrint = "1337121111111";

            var sendCodePayload = new SendCodePayload(phone, countryCode, fingerPrint);

            Action a = () => _authService.SendCode(sendCodePayload);
            a.Should().Throw<InvalidPhoneNumberFormatException>()
                .WithMessage("Phone must be 9 digits long, w/o country code");
        }

        [Test]
        public void SendCodeInvalidCountryCodeExceptionTest()
        {
            const string phone = "789654154";
            const string countryCode = "";
            const string fingerPrint = "1337121111111";

            var sendCodePayload = new SendCodePayload(phone, countryCode, fingerPrint);

            Action a = () => _authService.SendCode(sendCodePayload);
            a.Should().Throw<InvalidCountryCodeException>()
                .WithMessage("Country code cannot be null or empty");
        }

        [Test]
        public void SendCodeInvalidFingerprintExceptionTest()
        {
            const string phone = "789654154";
            const string countryCode = "PL";
            const string fingerPrint = "";

            var sendCodePayload = new SendCodePayload(phone, countryCode, fingerPrint);
            Action a = () => _authService.SendCode(sendCodePayload);
            a.Should().Throw<InvalidFingerprintFormatException>()
                .WithMessage("Fingerprint length must be 10 or more digits");
        }

        [Test]
        public void SignUpValidTest()
        {
            const string phone = "782654168";
            const string countryCode = "PL";
            const string fingerPrint = "1337121111111";
            const string name = "test_name5";
            const int phoneCode = 22222;
            const bool accepted = true;

            var sendCodePayload = new SendCodePayload(phone, countryCode, fingerPrint);

            var authRequest = _authService.SendCode(sendCodePayload);
            authRequest.Should().NotBeNull();
            authRequest.PhoneNumber.Should().Be("+48" + phone);

            // map auth request response
            var signUpPayload = Mapper.Map<SignUpPayload>(authRequest);

            // fill missing fields
            signUpPayload.Name = name;
            signUpPayload.PhoneCode = phoneCode;
            signUpPayload.TermsOfServiceAccepted = accepted;

            // use created object with endpoint
            var session = _authService.SignUp(signUpPayload);

            // check data
            session.User.Name.Should().Be(name);
            session.AccessToken.Length.Should().BeGreaterThan(0);
            session.AccessToken.Should().NotBeNull();
            session.AccessToken.Should().NotBe(string.Empty);
            session.RefreshToken.Length.Should().BeGreaterThan(0);
            session.RefreshToken.Should().NotBeNull();
            session.RefreshToken.Should().NotBe(string.Empty);
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

            var sendCodePayload = new SendCodePayload(phone, countryCode, fingerPrint);

            var authRequest = _authService.SendCode(sendCodePayload);
            authRequest.Should().NotBeNull();
            authRequest.PhoneNumber.Should().Be("+48" + phone);
            authRequest.IsNew.Should().BeFalse(); // test is run not first time
            authRequest.Timeout.Should().Be(120);
            authRequest.CountryCode.Should().Be(countryCode);
            authRequest.PhoneCodeHash.Should().NotBe(null);
            authRequest.PhoneCodeHash.Should().NotBe(string.Empty);

            // sign in try
            var signInPayload = Mapper.Map<SignInPayload>(authRequest);
            signInPayload.PhoneCode = 22222;

            var session = _authService.SignIn(signInPayload);
            session.Should().NotBeNull();
            session.User.Should().NotBeNull();
            session.User.Name.Should().Be("test_name4");
            session.User.Id.Should().Be(13);
        }

        [Test]
        public void LogoutValidTest()
        {
            // phone has to be changed each time
            const string phone = "783654168";
            const string countryCode = "PL";
            const string fingerPrint = "1337121111111";
            const string name = "test_name5";
            const int phoneCode = 22222;
            const bool accepted = true;

            var sendCodePayload = new SendCodePayload(phone, countryCode, fingerPrint);

            var authRequest = _authService.SendCode(sendCodePayload);
            authRequest.Should().NotBeNull();
            authRequest.PhoneNumber.Should().Be("+48" + phone);

            // map auth request response
            var signUpPayload = Mapper.Map<SignUpPayload>(authRequest);

            // fill missing fields
            signUpPayload.Name = name;
            signUpPayload.PhoneCode = phoneCode;
            signUpPayload.TermsOfServiceAccepted = accepted;

            // use created object with endpoint
            var session = _authService.SignUp(signUpPayload);

            // check data
            session.User.Name.Should().Be(name);
            session.AccessToken.Length.Should().BeGreaterThan(0);
            session.AccessToken.Should().NotBeNull();
            session.AccessToken.Should().NotBe(string.Empty);
            session.RefreshToken.Length.Should().BeGreaterThan(0);
            session.RefreshToken.Should().NotBeNull();
            session.RefreshToken.Should().NotBe(string.Empty);

            var logout = _authService.Logout(session);
            logout.Should().BeTrue();
        }

        [Test]
        public void RefreshTokenValidTest()
        {
            const string phone = "789654154";
            const string countryCode = "PL";
            const string fingerPrint = "1337121111111";

            var sendCodePayload = new SendCodePayload(phone, countryCode, fingerPrint);

            var authRequest = _authService.SendCode(sendCodePayload);
            authRequest.Should().NotBeNull();
            authRequest.PhoneNumber.Should().Be("+48" + phone);
            authRequest.IsNew.Should().BeFalse(); // test is run not first time
            authRequest.Timeout.Should().Be(120);
            authRequest.CountryCode.Should().Be(countryCode);
            authRequest.PhoneCodeHash.Should().NotBe(null);
            authRequest.PhoneCodeHash.Should().NotBe(string.Empty);

            // sign in try
            var signInPayload = Mapper.Map<SignInPayload>(authRequest);
            signInPayload.PhoneCode = 22222;

            var session = _authService.SignIn(signInPayload);
            session.Should().NotBeNull();
            session.User.Should().NotBeNull();
            session.User.Name.Should().Be("test_name4");
            session.User.Id.Should().Be(13);
            session.AccessToken.Should().NotBeNullOrEmpty();
            session.RefreshToken.Should().NotBeNullOrEmpty();

            var tokenPayload = new TokenPayload(session.RefreshToken, fingerPrint);
            var token = _authService.RefreshToken(tokenPayload);
            token.AccessToken.Should().NotBeNullOrEmpty();
            token.RefreshToken.Should().NotBeNullOrEmpty();
            token.RefreshTokenExpiresIn.Should().BeGreaterThan(0);
        }
    }
}