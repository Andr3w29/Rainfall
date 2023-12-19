

using Rainfall.Api.Core.Application.Common.Response.External;

namespace Rainfall.Api.Core.Application.Common.Interfaces.External
{
    public interface IRainfallService
    {
        Task<RainfallReadingResponse> GetRainfallByStationId(string stationId, int limit = 10);
    }
}
