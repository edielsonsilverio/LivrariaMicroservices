using ShopServices.Api.Carrinho.Models.Dtos;
using System.Text.Json;

namespace ShopServices.Api.Carrinho.Services
{
    public class LivroService : ILivroService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<LivroService> _logger;

        public LivroService(
            IHttpClientFactory httpClient,
            ILogger<LivroService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool resultado, LivroPublicacaoDto livros, string erroMensagem)> ObterLivro(Guid livroId)
        {
            try
            {
                var client = _httpClient.CreateClient("ApiLivros");
                var response = await client.GetAsync($"api/Publicacao/{livroId}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true};
                    var livros = JsonSerializer.Deserialize<LivroPublicacaoDto>(result,options);
                    return (true,livros,string.Empty);  
                }

                return   (false,null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false,null,ex.Message);
            }
        }
    }

}
