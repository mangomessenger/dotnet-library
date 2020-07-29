using System;
using FluentAssertions;
using NUnit.Framework;
using ServicesLibrary.DTO;
using ServicesLibrary.Exceptions.Auth;
using ServicesLibrary.Interfaces;

namespace ServicesLibrary.Tests.AuthService
{
    [TestFixture]
    public class SendCodeTest
    {
        private readonly IAuthService _authService = new Services.AuthService();

        [Test]
        public void SendCode_Valid_Test()
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
        public void SendCode_Invalid_Phone_Exception_Test()
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
        public void SendCode_Invalid_CountryCode_Exception_Test()
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
        public void SendCode_Invalid_Fingerprint_Exception_Test()
        {
            const string phone = "789654154";
            const string countryCode = "PL";
            const string fingerPrint = "";

            var sendCodePayload = new SendCodePayload(phone, countryCode, fingerPrint);
            Action a = () => _authService.SendCode(sendCodePayload);
            a.Should().Throw<InvalidFingerprintFormatException>()
                .WithMessage("Fingerprint length must be 10 or more digits");
        }
    }
}