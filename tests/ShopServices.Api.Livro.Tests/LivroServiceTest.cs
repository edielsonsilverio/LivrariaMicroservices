using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Livro.Applications.Command;
using ShopServices.Api.Livro.Applications.CommandHandler;
using ShopServices.Api.Livro.Data;
using System;
using System.Linq;
using System.Threading;
using Xunit;

namespace ShopServices.Api.Livro.Tests
{

    public class LivroServiceTest : ParametroTesteConfig
    {

        [Fact(DisplayName = "Obter Todos Os Livro")]
        [Trait("Unitário", "Serviço Livro")]
        public async void Livro_Consultar_ObterTodosLivro()
        {
            //System.Diagnostics.Debugger.Launch();
            // Qual método dentro do meu microsserviço de livros é responsável
            // por consultar os livros no banco de dados???

            // Arrange
            //1.Emular a instância entity framework core de - LivroContext
            // para emular as ações e eventos de um objeto em um ambiente de teste unitário
            // usamos objetos do tipo mock
            var mockContexto = ObterInstanciaContextoMock();

            //2. Emular mapeamento IMapper
            var mapper = ObterMapperConfig();

            //3. Instancie a classe Handler e passe os mocks que criei como parâmetros
            var commandHandler = new ListaPublicacaoCommandHandler(mockContexto, mapper);
            var command = new ListaPublicacaoCommand();

            // Act
            var lista = await commandHandler.Handle(command, new CancellationToken());

            // Assert
            Assert.True(lista.Any());
        }

        [Fact(DisplayName ="Obter Livro Por Id")]
        [Trait("Unitário","Serviço Livro")]
        public async void Livro_Consultar_PorId()
        {
            // Arrange
            var mockContexto = ObterInstanciaContextoMock();

            var mapper = ObterMapperConfig();

            var command = new PesquisaPublicacaoCommand();
            command.PublicacaoId = Guid.Empty.ToString();

            var commandHandler = new PesquisaPublicacaoCommandHandler(mockContexto, mapper);

            //Act
            var result = await commandHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.NotNull(result);
            Assert.True(result.BibliotecaId == Guid.Empty);


        }

        [Fact(DisplayName = "Adicionar um livro")]
        [Trait("Unitário","Serviço Livro")]
        public async void Livro_Adicionar_NovoLivro()
        {
            //Arrange
            LivroContext context = ObterInstanciaContextoInMemory("BaseLivroAdicionar");

            var command = new NovaPublicacaoCommand
            {
                AutorLivro = Guid.NewGuid(),
                DataPublicacao = DateTime.Now,
                Titulo = "Microservices Book"
            };
            var commandHandler = new NovaPublicacaoCommandHandler(context,null);

            //Act
            var result = await commandHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(result);
        }

       


    }
}
