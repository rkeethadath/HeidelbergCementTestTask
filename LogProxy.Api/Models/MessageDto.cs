using System;

namespace LogProxy.Api.Models
{
    public class MessageDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime? ReceivedAt { get; set; }
    }
}
