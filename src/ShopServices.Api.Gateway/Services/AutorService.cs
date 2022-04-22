using Core.WebApi;
using ShopServices.Api.Gateway.Applications.Dtos;

namespace ShopServices.Api.Gateway.Services;

public class AutorService : IAutorService
{
    private readonly IHttpClientFactory _httpClient;
    private readonly ILogger<AutorService> _logger;

    public AutorService(IHttpClientFactory httpClient, ILogger<AutorService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<(bool resultado, AutorDto autor, string errorMessage)> ObterPorId(Guid autorId)
    {
        try
        {
            var client = _httpClient.CreateClient("AutorService");
            var response = await client.GetAsync($"/Api/Autor/{autorId}");
            if (response.IsSuccessStatusCode)
            {
                var result = await BaseService.DeserializarObjetoResponse<AutorDto>(response);
                return (true, result, null);
            }
            
            return (false,null,response.ReasonPhrase);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return (false,null, ex.Message);
        }
    }
}
