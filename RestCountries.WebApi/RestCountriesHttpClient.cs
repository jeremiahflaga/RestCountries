using RestCountries.WebApi.Controllers.Import;

namespace RestCountries.WebApi;

public interface IRestCountriesHttpClient
{
    Task<List<ImportCountryDto>> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default);
    //Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken cancellationToken = default);
    //Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest request, CancellationToken cancellationToken = default);
    //Task DeleteAsync(string endpoint, CancellationToken cancellationToken = default);
}

public class RestCountriesHttpClient : IRestCountriesHttpClient
{
    private readonly HttpClient _httpClient;

    public RestCountriesHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ImportCountryDto>?> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(endpoint, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<ImportCountryDto>>(cancellationToken);
    }
}
