using LogProxy.Api;
using LogProxy.Api.Controllers;
using LogProxy.Api.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace LogProxy.UnitTests
{
    public class MessageControllerTests
    {
        private readonly MessageDto messageDto = new MessageDto { Id = "1", Text = "text", Title = "title", ReceivedAt = DateTime.Now };
    
        [Fact]
        public async Task GetAsync_Returns_All_Messages()
        {
            // Arrange
            var expected = new List<MessageDto> { messageDto };
            var messageService = new Mock<IMessageService>();
            messageService.Setup(x => x.GetMessagesAsync()).Returns(Task.FromResult(expected));
            var messageController = new MessageController(messageService.Object);

            // Act
            var actual = await messageController.GetAsync();

            // Assert
            messageService.VerifyAll();
            AssertMessages(messageDto, actual);
        }

        [Fact]
        public async Task Given_Messages_PostAsync_Should_Save_Messages()
        {
            // Arrange
            var expected = new List<MessageDto> { messageDto };
            var messageService = new Mock<IMessageService>();
            messageService.Setup(x => x.PostMessagesAsync(It.IsAny<List<MessageDto>>())).Returns(Task.FromResult(expected));
            var messageController = new MessageController(messageService.Object);

            // Act
            var actual = await messageController.PostAsync(expected);

            // Assert
            messageService.VerifyAll();
            AssertMessages(messageDto, actual);
        }
        private static void AssertMessages(MessageDto expected, IEnumerable<MessageDto> actual)
        {
            Assert.NotNull(actual);
            var messageDto = Assert.Single(actual);
            Assert.Equal(expected.Id, messageDto.Id);
            Assert.Equal(expected.Title, messageDto.Title);
            Assert.Equal(expected.Text, messageDto.Text);
            Assert.Equal(expected.ReceivedAt, messageDto.ReceivedAt);
        }
    }
}
