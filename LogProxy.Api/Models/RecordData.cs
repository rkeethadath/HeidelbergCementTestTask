using Newtonsoft.Json;
using System;

namespace LogProxy.Api.Models
{
    public class RecordData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("fields")]
        public FieldData FieldData { get; set; }

        [JsonProperty("createdTime")]
        public DateTime? CreatedTime { get; set; }
    }
}
