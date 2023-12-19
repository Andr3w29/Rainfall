namespace Rainfall.Api.Core.Application.Common.Response.Rainfall
{
    public class RainfallReadingResponse
    {
        public List<RainfallReading> Items { get; set; }
    }
    public class RainfallReading
    {
        public DateTime DateMeasured { get; set; }
        public double AmountMeasured { get; set; }
    }
}
