using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using ShopServices.Api.Livro.Data;
using ShopServices.Api.Livro.Models;

namespace ShopServices.Api.Livro.Tests
{
    public abstract class ParametroTesteConfig
    {
        public static LivroContext ObterInstanciaContextoMock()
        {
            return CriarContext().Object;
        }

        public static LivroContext ObterInstanciaContextoInMemory(string databaseName)
        {
            var options = new DbContextOptionsBuilder<LivroContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;

            var context = new LivroContext(options);
            return context;
        }

        private static Mock<LivroContext> CriarContext()
        {
            //Cria um objeto Context do entityFramework e configura o DbSet e Retorna os objetos
            //Chama a função para obter todos
            var data = ObterLivros().AsQueryable();
            var dbSet = new Mock<DbSet<LivroPublicacao>>();
            dbSet.As<IQueryable<LivroPublicacao>>().Setup(x => x.Provider).Returns(data.Provider);
            dbSet.As<IQueryable<LivroPublicacao>>().Setup(x => x.Expression).Returns(data.Expression);
            dbSet.As<IQueryable<LivroPublicacao>>().Setup(x => x.ElementType).Returns(data.ElementType);
            dbSet.As<IQueryable<LivroPublicacao>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator);

            //Configuração para simular o retorno de uma lista.
            dbSet.As<IAsyncEnumerable<LivroPublicacao>>()
                .Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                .Returns(new AsyncEnumerator<LivroPublicacao>(data.GetEnumerator()));

            //Configurção simular a consulta com um filtro.
            dbSet.As<IQueryable<LivroPublicacao>>().Setup(x => x.Provider)
                .Returns(new AsyncQueryProvider<LivroPublicacao>(data.Provider));


            var context = new Mock<LivroContext>();
            context.Setup(x => x.Livros).Returns(dbSet.Object);
            return context;
        }

        private static IEnumerable<LivroPublicacao> ObterLivros()
        {
            //Cria Dados Fakes para fazer os testes.
            A.Configure<LivroPublicacao>()
                .Fill(x => x.Titulo).AsArticleTitle()
                .Fill(x => x.BibliotecaId, () => { return Guid.NewGuid(); });

            var livros = A.ListOf<LivroPublicacao>(30);
            livros[0].BibliotecaId = Guid.Empty;

            return livros;
        }

        public static IMapper ObterMapperConfig()
        {
            return new MapperConfiguration(cfg => { cfg.AddProfile(new MappingTest()); })
                .CreateMapper();
        }
    }
}
