﻿using LogProxy.Api.Authentication;
using LogProxy.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogProxy.Api.Controllers
{
    [BasicAuthorization]
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IEnumerable<MessageDto>> GetAsync()
        {
            return await _messageService.GetMessagesAsync();
        }

        [HttpPost]
        public async Task<IEnumerable<MessageDto>> PostAsync(List<MessageDto> messages)
        {
            return await _messageService.PostMessagesAsync(messages);
        }
    }
}
