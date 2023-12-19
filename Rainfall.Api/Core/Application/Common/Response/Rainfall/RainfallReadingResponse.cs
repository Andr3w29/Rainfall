namespace Rainfall.Api.Core.Application.Common.Response.Rainfall
{
    public class RainfallReadingResponse
    {
        public List<RainfallReading> Items { get; set; }
    }
    public class RainfallReading
    {
        public string DateMeasured { get; set; }
        public double AmountMeasured { get; set; }
    }
}
