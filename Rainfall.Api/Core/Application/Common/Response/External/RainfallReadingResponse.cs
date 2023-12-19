using Newtonsoft.Json;

namespace Rainfall.Api.Core.Application.Common.Response.External
{
    public class RainfallReadingResponse
    {
        public List<RainfallReading> Items { get; set; }
    }
    public class RainfallReading
    {
        [JsonProperty("@id")]
        public string Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Value { get; set; }
    }
}
