using MediatR;
using ShopServices.Api.Livro.Applications.Command;
using ShopServices.Api.Livro.Data;
using ShopServices.Api.Livro.Validations;
using ShopServices.RabbitMQ.Bus.BusRabbit;
using ShopServices.RabbitMQ.Bus.EventQueue;

namespace ShopServices.Api.Livro.Applications.CommandHandler
{
    public class NovaPublicacaoCommandHandler : IRequestHandler<NovaPublicacaoCommand, bool>
    {
        private readonly LivroContext _context;
        private readonly IRabbitEventBus _rabbitBus;

        public NovaPublicacaoCommandHandler(
            LivroContext context
            ,IRabbitEventBus rabbitBus
            )
        {
            _context = context;
            _rabbitBus = rabbitBus;
        }

        public async Task<bool> Handle(NovaPublicacaoCommand request, CancellationToken cancellationToken)
        {
            var model = new Models.LivroPublicacao
            {
                AutorLivro = request.AutorLivro,
                DataPublicacao = request.DataPublicacao,
                Titulo = request.Titulo
            };

            var validation = new NovaPublicacaoCommandValidation();
            if (!validation.Validate(request).IsValid) return false;

            _rabbitBus.Publish(new EmailEventQueue(
                "desitnario@teste.com",
                 request.Titulo,
                "Livro Cadastrado com Sucesso"
            ));

            await _context.Livros.AddAsync(model);



            return (await _context.SaveChangesAsync()) > 0 ? true :
                                 throw new Exception("Não foi possível inserir a publicação.");
        }
    }
}
