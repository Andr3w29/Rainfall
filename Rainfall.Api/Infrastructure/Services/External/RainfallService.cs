using Rainfall.Api.Core.Application.Common.Interfaces.External;
using Rainfall.Api.Core.Application.Common.Response.External;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Rainfall.Api.Infrastructure.Services.External;

public class RainfallService : IRainfallService
{
    private readonly HttpClient _httpClient;
    private const string BASE_ADDRESS = "https://environment.data.gov.uk";

    #region Constructors
    public RainfallService(HttpClient httpClient)
    {
        this._httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        _httpClient.BaseAddress = new Uri(BASE_ADDRESS);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    }
    #endregion
    #region Functions
    public async Task<RainfallReadingResponse> GetRainfallByStationId(string stationId, int limit = 10)
    {
        var response = new RainfallReadingResponse();
        try
        {


            response = await _httpClient.GetFromJsonAsync<RainfallReadingResponse>($"/flood-monitoring/id/stations/{stationId}/readings?_sorted&_limit={limit}", options: JsonSerializerOptions);

            throw new Exception();
        }
        catch (HttpRequestException ex)
        {
            //TODO Log error for investigation
            throw ex;
        }
        catch (Exception ex)
        {
            //TODO Log error for investigation
            throw ex;
        }
        return response;
    }
    private JsonSerializerOptions JsonSerializerOptions
    {
        get
        {
            return new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        set { JsonSerializerOptions = value; }
    }

    #endregion
}
