using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using ServicesLibrary.DTO;
using ServicesLibrary.Interfaces;
using ServicesLibrary.MapperFiles;

namespace ServicesLibrary.Tests.AuthService
{
    [TestFixture]
    public class SignUpTest
    {
        private readonly IAuthService _authService = new Services.AuthService();
        private static readonly Mapper Mapper = MapperFactory.GetMapperInstance();


        [Test]
        public void SignUp_Valid_Test()
        {
            // send code part
            const string phone = "782654268";
            const string countryCode = "PL";
            const string fingerPrint = "1337121111111";
            const string name = "test_name5";
            const int phoneCode = 22222;
            const bool accepted = true;
            var sendCodePayload = new SendCodePayload(phone, countryCode, fingerPrint);
            var authRequest = _authService.SendCode(sendCodePayload);
            authRequest.Should().NotBeNull();
            authRequest.PhoneNumber.Should().Be("+48" + phone);

            // sign up part
            var signUpPayload = Mapper.Map<SignUpPayload>(authRequest);
            signUpPayload.Name = name;
            signUpPayload.PhoneCode = phoneCode;
            signUpPayload.TermsOfServiceAccepted = accepted;
            var session = _authService.SignUp(signUpPayload);

            // check session data
            session.User.Name.Should().Be(name);
            session.AccessToken.Length.Should().BeGreaterThan(0);
            session.AccessToken.Should().NotBeNull();
            session.AccessToken.Should().NotBe(string.Empty);
            session.RefreshToken.Length.Should().BeGreaterThan(0);
            session.RefreshToken.Should().NotBeNull();
            session.RefreshToken.Should().NotBe(string.Empty);
        }

        [Test]
        public void SignUp_Terms_Of_Service_NotAccepted_Exception_Test()
        {
        }
    }
}