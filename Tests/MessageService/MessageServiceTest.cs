using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using ServicesLibrary.Models;

namespace ServicesLibrary.Tests.MessageService
{
    /// <summary>
    /// This test class will be separated by specified cases
    /// </summary>
    [TestFixture]
    public class MessageServiceTest
    {
        private readonly Services.MessageService _messageService = new Services.MessageService();

        [Test]
        public void GetMessageByIdTest()
        {
            _messageService.GetMessageById(1).Should().NotBeNull();
            _messageService.GetChatMessagesById(-1).Should().BeNull();
        }

        [Test]
        public void GetChatMessagesTest()
        {
            _messageService.GetChatMessagesById(1).Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void GetGroupMessagesTest()
        {
            _messageService.GetGroupMessagesById(1).Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void PostMessageTest()
        {
            var message = new Message
            {
                ChatId = 1,
                UserId = 1,
                CreatedAt = DateTime.Now,
                Id = 1, // id of message to be calculated inside database
                MessageText = "test message",
                UpdatedAt = DateTime.Now
            };

            Action a = () => _messageService.SendMessage(message);
            _messageService.SendMessage(message).MessageText.Should().Be("test message");
            
            // should be conflict of same message id; exception expected
            a.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void EditMessageTest()
        {
            var message = _messageService.GetMessageById(1);
            _messageService.EditMessage(message);
            var edited = _messageService.GetMessageById(1);
            message.Should().NotBe(edited);        // it is necessary to implement IEquatable in Messages to check
        }

        [Test]
        public void PartialEditMessageTest()
        {
            var message = _messageService.GetMessageById(1);
            _messageService.PartialEditMessage(message);
            var edited = _messageService.GetMessageById(1);
            message.Should().NotBe(edited);        // it is necessary to implement IEquatable in Messages to check
        }

        [Test]
        public void DeleteMessageTest()
        {
            var message = _messageService.GetMessageById(1);
            _messageService.DeleteMessage(message);
            _messageService.GetMessageById(1).Should().BeNull();
        }
    }
}