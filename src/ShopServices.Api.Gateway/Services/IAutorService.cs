using ShopServices.Api.Gateway.Applications.Dtos;

namespace ShopServices.Api.Gateway.Services;

public interface IAutorService
{
    Task<(bool resultado, AutorDto autor, string errorMessage)> ObterPorId(Guid autorId);
}
