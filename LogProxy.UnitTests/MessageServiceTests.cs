using LogProxy.Api;
using LogProxy.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace LogProxy.UnitTests
{
    public class MessageServiceTests
    {
        private readonly HttpClient httpClient;
        
        public MessageServiceTests()
        {
            httpClient = Helper.GetHttpClient();
        }

        [Fact]
        public async Task Ensure_That_GetMessagesAsync_Returns_All_Messages()
        {
            // Arrange
            var messageService = new MessageService(httpClient);

            // Act
            var actual = await messageService.GetMessagesAsync();

            // Assert
            AssertMessages(actual);
        }

        [Fact]
        public async Task Given_Messages_PostMessagesAsync_Should_Add()
        {
            // Arrange
            var messageService = new MessageService(httpClient);

            // Act
            var actual = await messageService.PostMessagesAsync(Helper.GetTestDataRequest());

            // Assert
            AssertMessages(actual);
        }

        private static void AssertMessages(List<MessageDto> actual)
        {
            Assert.NotNull(actual);
            Assert.Equal(3, actual.Count);

            Assert.Equal("1", actual[0].Id);
            Assert.Equal("2", actual[1].Id);
            Assert.Equal("f94aacb3-029a-4b45-ad4e-711d560eed31", actual[2].Id);

            Assert.Equal("title_1", actual[0].Title);
            Assert.Equal("title_2", actual[1].Title);
            Assert.Equal("title_3", actual[2].Title);

            Assert.Equal("text_1", actual[0].Text);
            Assert.Equal("text_2", actual[1].Text);
            Assert.Equal("text_3", actual[2].Text);

            Assert.Equal(new DateTime(2021,2, 10, 21, 12, 57, 624), actual[0].ReceivedAt);
            Assert.Null(actual[1].ReceivedAt);
            Assert.Equal(new DateTime(2021, 2, 14, 11, 9, 16, 827), actual[2].ReceivedAt);
        }
    }
}
