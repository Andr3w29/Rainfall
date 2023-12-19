namespace Rainfall.Api.Core.Application.Common.Response.External
{
    public class RainfallReadingResponse
    {
        public List<RainfallReading> Items { get; set; }
    }
    public class RainfallReading
    {
        public string Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Measure { get; set; }
        public double value { get; set; }
    }
}
