using Core.WebApi;
using ShopServices.Api.Gateway.Applications.Dtos;
using ShopServices.Api.Gateway.Services;
using System.Diagnostics;

namespace ShopServices.Api.Gateway.MessageHanlder;

public class LivroHandler : DelegatingHandler
{
    private readonly ILogger<LivroHandler> _logger;
    private readonly IAutorService _autorService;

    public LivroHandler(ILogger<LivroHandler> logger, IAutorService autorService)
    {
        _logger = logger;
        _autorService = autorService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var tempo = Stopwatch.StartNew();
        _logger.LogInformation("Inicio do Request...");
        var response = await base.SendAsync(request, cancellationToken); ;
        if (response.IsSuccessStatusCode)
        {
            var result = await BaseService.DeserializarObjetoResponse<LivroDto>(response);

            var resultAutor = await _autorService.ObterPorId(result.AutorLivro ?? Guid.Empty);
            if (resultAutor.resultado)
            {
                result.Autor = resultAutor.autor;
                response .Content = BaseService.ObterConteudo(result);
            }
        }

        _logger.LogInformation($"Tempo de duração do request: {tempo.ElapsedMilliseconds} ms");
        return response;
    }
}
