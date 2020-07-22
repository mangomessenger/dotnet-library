using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using ServicesLibrary.Implementations;
using ServicesLibrary.Models;

namespace ServicesLibrary.Tests
{
    [TestFixture]
    public class MessageServicesTests
    {
        private readonly MessageServices _messageServices = new MessageServices();

        [Test]
        public void GetMessageByIdTest()
        {
            _messageServices.GetMessageById(1).Should().NotBeNull();
            _messageServices.GetChatMessagesById(-1).Should().BeNull();
        }

        [Test]
        public void GetChatMessagesTest()
        {
            _messageServices.GetChatMessagesById(1).Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void GetGroupMessagesTest()
        {
            _messageServices.GetGroupMessagesById(1).Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void PostMessageTest()
        {
            var message = new Messages
            {
                ChatId = 1,
                UserId = 1,
                CreatedAt = DateTime.Now,
                Id = 1, // id of message to be calculated inside database
                Message = "test message",
                UpdatedAt = DateTime.Now
            };

            Action a = () => _messageServices.SendMessage(message);
            _messageServices.SendMessage(message).Message.Should().Be("test message");
            
            // should be conflict of same message id; exception expected
            a.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void EditMessageTest()
        {
            var message = _messageServices.GetMessageById(1);
            _messageServices.EditMessage(message);
            var edited = _messageServices.GetMessageById(1);
            message.Should().NotBe(edited);        // it is necessary to implement IEquatable in Messages to check
        }

        [Test]
        public void PartialEditMessageTest()
        {
            var message = _messageServices.GetMessageById(1);
            _messageServices.PartialEditMessage(message);
            var edited = _messageServices.GetMessageById(1);
            message.Should().NotBe(edited);        // it is necessary to implement IEquatable in Messages to check
        }

        [Test]
        public void DeleteMessageTest()
        {
            var message = _messageServices.GetMessageById(1);
            _messageServices.DeleteMessage(message);
            _messageServices.GetMessageById(1).Should().BeNull();
        }
    }
}