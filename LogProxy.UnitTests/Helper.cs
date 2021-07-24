using LogProxy.Api.Models;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogProxy.UnitTests
{
    public class Helper
    {
        public static HttpClient GetHttpClient()
        {
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(GetMessagesTestData(), Encoding.UTF8, "application/json")
            };

            Mock<HttpMessageHandler> mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponse);
            return new HttpClient(mockHandler.Object);
        }
        public static string GetMessagesTestData()
        {
            var messagesTestData = File.ReadAllText("MessagesTestData.json");

            return messagesTestData;
        }

        public static List<MessageDto> GetTestDataRequest()
        {
            return new List<MessageDto>()
            {
                new MessageDto { Id = "1", Title = "title_1", Text = "text_1", ReceivedAt = new DateTime(2021,2, 10, 21, 12, 57, 624) },
                new MessageDto { Id = "2", Title = "title_2", Text = "text_2" },
                new MessageDto { Id = "f94aacb3-029a-4b45-ad4e-711d560eed31", Title = "title_3", Text = "text_3", ReceivedAt = new DateTime(2021,2, 10, 21, 12, 57, 624) }
            };
        }
    }
}
