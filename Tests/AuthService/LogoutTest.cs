using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using ServicesLibrary.DTO;
using ServicesLibrary.Interfaces;
using ServicesLibrary.MapperFiles;

namespace ServicesLibrary.Tests.AuthService
{
    [TestFixture]
    public class LogoutTest
    {
        private readonly IAuthService _authService = new Services.AuthService();
        private static readonly Mapper Mapper = MapperFactory.GetMapperInstance();

        [Test]
        public void Logout_Valid_Test()
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
    }
}