using LogProxy.Api.Helpers;
using Newtonsoft.Json;
using System;

namespace LogProxy.Api.Models
{
    public class FieldData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Summary")]
        public string Summary { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("receivedAt"), JsonConverter(typeof(DatetimeConverter))]
        public DateTime? ReceivedAt { get; set; }
    }
}
