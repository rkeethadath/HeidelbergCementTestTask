using LogProxy.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogProxy.Api
{
    public interface IMessageService
    {
        /// <summary>
        /// Get all messages from the backend service
        /// </summary>
        /// <returns></returns>
        Task<List<MessageDto>> GetMessagesAsync();

        /// <summary>
        /// Save messages to the backend service
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        Task<List<MessageDto>> PostMessagesAsync(List<MessageDto> messages);
    }
}
