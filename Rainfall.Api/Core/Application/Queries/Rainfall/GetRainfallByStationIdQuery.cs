using MediatR;
using Rainfall.Api.Core.Application.Common.Interfaces.External;
using Rainfall.Api.Core.Application.Common.Response.Rainfall;

namespace Rainfall.Api.Core.Application.Queries.Rainfall
{
    public class GetRainfallByStationIdQuery : IRequest<RainfallReadingResponse>
    {
        public string StationId { get; private set; }
        public int Count { get; private set; }
        public GetRainfallByStationIdQuery(string stationId, int count)
        {
            StationId = stationId;
            Count = count;
        }
    }
    public class GetRainfallByStationIdQueryHandler : IRequestHandler<GetRainfallByStationIdQuery, RainfallReadingResponse>
    {
        private readonly IRainfallService _rainfallService;

        public GetRainfallByStationIdQueryHandler(IRainfallService rainfallService)
        {
            this._rainfallService = rainfallService ?? throw new ArgumentNullException(nameof(rainfallService));
        }
        public async Task<RainfallReadingResponse> Handle(GetRainfallByStationIdQuery request, CancellationToken cancellationToken)
        {
            return await _rainfallService.GetRainfallByStationId(request.StationId, request.Count);
        }
    }
}
