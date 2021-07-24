using Newtonsoft.Json;
using System.Collections.Generic;

namespace LogProxy.Api.Models
{
    public class MessageData
    {
        public MessageData() => Records = new List<RecordData>();

        [JsonProperty("records")]
        public List<RecordData> Records { get; set; }

        [JsonProperty("offset")]
        public string Offset { get; set; }
    }
}
