using LogProxy.Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LogProxy.Api
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient httpClient;
        private const string MessageUri = "https://api.airtable.com/v0/appD1b1YjWoXkUJwR/Messages";
        private const string AuthenticationKey = "key46INqjpp7lMzjd";

        public MessageService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationKey);
        }

        public async Task<List<MessageDto>> GetMessagesAsync()
        {
            var response = await httpClient.GetAsync(new Uri(MessageUri));
            var messageData = JsonConvert.DeserializeObject<MessageData>(
                await response.Content.ReadAsStringAsync());

            return MapToMessageDtos(messageData);
        }

        public async Task<List<MessageDto>> PostMessagesAsync(List<MessageDto> messages)
        {
            if (!messages?.Any() == true) return new List<MessageDto>();

            FillMissingFields(messages);

            var response = await httpClient.PostAsync(
                new Uri(MessageUri),
                GetHttpContent(messages));

            var messageData = JsonConvert.DeserializeObject<MessageData>(
                await response.Content.ReadAsStringAsync());

            return MapToMessageDtos(messageData);
        }

        private void FillMissingFields(List<MessageDto> messages)
        {
            messages.ForEach(m => 
            {
                m.Id = Guid.NewGuid().ToString();
                m.ReceivedAt = DateTime.Now;
            });
        }

        private HttpContent GetHttpContent(List<MessageDto> messages)
        {
            return new StringContent(
                JsonConvert.SerializeObject(
                    MapToMessageData(messages),
                    Formatting.None,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }
                    ),
                Encoding.UTF8,
                "application/json"
                );
        }

        private MessageData MapToMessageData(List<MessageDto> messageDtos)
        {
            var messageData = new MessageData();

            if (!messageDtos?.Any() == true) return messageData;

            messageDtos.ForEach(m => messageData.Records.Add(MapToFieldData(m)));
            return messageData;
        }

        private RecordData MapToFieldData(MessageDto messageDto)
        {
            return new RecordData
            {
                FieldData = new FieldData
                {
                    Id = messageDto.Id,
                    Summary = messageDto.Title,
                    Message = messageDto.Text,
                    ReceivedAt = messageDto.ReceivedAt
                }
            };
        }

        private List<MessageDto> MapToMessageDtos(MessageData messageData)
        {
            List<MessageDto> messages = new List<MessageDto>();
            if (!messageData.Records.Any()) return messages;

            messageData.Records.ForEach(r => messages.Add(MapToMessageDto(r)));
            return messages;
        }

        private static MessageDto MapToMessageDto(RecordData recordData)
        {
            return new MessageDto
            {
                Id = recordData?.FieldData?.Id,
                Title = recordData?.FieldData?.Summary,
                Text = recordData?.FieldData?.Message,
                ReceivedAt = recordData?.FieldData?.ReceivedAt
            };
        }
    }
}