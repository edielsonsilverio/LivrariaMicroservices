using ShopServices.Api.Carrinho.Models.Dtos;

namespace ShopServices.Api.Carrinho.Services
{
    public interface ILivroService
    {
        Task<(bool resultado, LivroPublicacaoDto livros, string erroMensagem)> ObterLivro(Guid livroId);
    }

}
