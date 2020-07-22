using NUnit.Framework;
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