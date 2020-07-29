using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using ServicesLibrary.DTO;
using ServicesLibrary.Interfaces;
using ServicesLibrary.MapperFiles;

namespace ServicesLibrary.Tests.AuthService
{
    [TestFixture]
    public class RefreshTokenTest
    {
        private readonly IAuthService _authService = new Services.AuthService();
        private static readonly Mapper Mapper = MapperFactory.GetMapperInstance();

        [Test]
        public void RefreshToken_Valid_Test()
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