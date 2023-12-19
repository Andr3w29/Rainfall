using AutoMapper;
using MediatR;
using Rainfall.Api.Core.Application.Common.Interfaces.External;
using Rainfall.Api.Core.Application.Common.Response.Rainfall;

namespace Rainfall.Api.Core.Application.Queries.Rainfall;

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
#region Handler
public class GetRainfallByStationIdQueryHandler : IRequestHandler<GetRainfallByStationIdQuery, RainfallReadingResponse>
{
    private readonly IMapper _mapper;
    private readonly IRainfallService _rainfallService;

    #region Constructors
    public GetRainfallByStationIdQueryHandler(IMapper mapper, IRainfallService rainfallService)
    {
        this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this._rainfallService = rainfallService ?? throw new ArgumentNullException(nameof(rainfallService));
    }
    #endregion
    #region Functions
    public async Task<RainfallReadingResponse> Handle(GetRainfallByStationIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _rainfallService.GetRainfallByStationId(request.StationId, request.Count);
        return new RainfallReadingResponse() { Items = _mapper.Map<List<RainfallReading>>(response.Items) };

    }
    #endregion
}
#endregion
