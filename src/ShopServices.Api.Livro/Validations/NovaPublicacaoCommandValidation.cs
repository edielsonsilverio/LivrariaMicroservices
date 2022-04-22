using FluentValidation;
using ShopServices.Api.Livro.Applications.Command;
using ShopServices.Api.Livro.Models;

namespace ShopServices.Api.Livro.Validations
{
    public class NovaPublicacaoCommandValidation : AbstractValidator<NovaPublicacaoCommand>
    {
        public NovaPublicacaoCommandValidation()
        {
            RuleFor(x => x.DataPublicacao).NotEmpty().WithMessage("A Data da publicação não pode ser vazio.");
            RuleFor(x => x.AutorLivro).NotEmpty().WithMessage("O Autor do livro não pode ser vazio.");
            RuleFor(x => x.Titulo).NotEmpty().WithMessage("O Título não pode ser vazio.");
            RuleFor(x => x.Titulo).Length(3,50).WithMessage("O Título tem que ter mais de duas letras.");
        }
    }
}
