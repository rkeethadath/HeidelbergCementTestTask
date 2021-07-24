using LogProxy.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogProxy.Api
{
    public interface IMessageService
    {
        Task<List<MessageDto>> GetMessagesAsync();
        Task<List<MessageDto>> PostMessagesAsync(List<MessageDto> messages);
    }
}
