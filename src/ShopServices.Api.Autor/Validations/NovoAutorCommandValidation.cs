using FluentValidation;
using ShopServices.Api.Autor.Applications;

namespace ShopServices.Api.Autor.Validations
{
    public class NovoAutorCommandValidation : AbstractValidator<NovoAutorCommand>
    {
        public NovoAutorCommandValidation()
        {
            RuleFor(x=> x.Nome).NotEmpty().WithMessage("O Nome não pode ser vazio");
            RuleFor(x=> x.Apelido).NotEmpty().WithMessage("O Apelido não pode ser vazio");
        }
    }
}
