using LogProxy.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LogProxy.Api
{
    public interface IMessageService
    {
        Task<List<MessageDto>> GetMessagesAsync();
        Task<List<MessageDto>> PostMessagesAsync(List<MessageDto> messages);
    }
}
