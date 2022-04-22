using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopServices.Api.Livro.Models;

namespace ShopServices.Api.Livro.Data.Mappings
{
    public class LivrariaMaterialMapping : IEntityTypeConfiguration<Models.LivroPublicacao>
    {
        public void Configure(EntityTypeBuilder<Models.LivroPublicacao> builder)
        {
            builder.ToTable("Bibliotecas");
            builder.HasKey(x => x.BibliotecaId);
            builder.Property(x => x.Titulo).HasMaxLength(50);
            builder.Property(x => x.AutorLivro).HasMaxLength(36);
            builder.Property(x => x.DataPublicacao);

            InserirPublicacao(builder);
        }

        private void InserirPublicacao(EntityTypeBuilder<Models.LivroPublicacao> builder)
        {
            builder.HasData(
            new LivroPublicacao { BibliotecaId = Guid.NewGuid(), Titulo = "Titulo 01",AutorLivro = Guid.Parse("49f9e020-808d-4fd0-8ce8-2bd76a7ba199") ,DataPublicacao = DateTime.UtcNow} ,
            new LivroPublicacao { BibliotecaId = Guid.NewGuid(), Titulo = "Titulo 02",AutorLivro = Guid.Parse("c7606156-c165-4da5-9e7d-28af654bb97d") ,DataPublicacao = DateTime.UtcNow} ,
            new LivroPublicacao { BibliotecaId = Guid.NewGuid(), Titulo = "Titulo 03",AutorLivro = Guid.Parse("368e956e-f665-4291-9a1a-53fc4cb4338a") ,DataPublicacao = DateTime.UtcNow} ,
            new LivroPublicacao { BibliotecaId = Guid.NewGuid(), Titulo = "Titulo 04",AutorLivro = Guid.Parse("8bf309ec-b958-4bcd-99f4-c7dd110c376d") ,DataPublicacao = DateTime.UtcNow} ,
            new LivroPublicacao { BibliotecaId = Guid.NewGuid(), Titulo = "Titulo 05",AutorLivro = Guid.Parse("de2eb41d-c9fd-4a5f-bbd9-57a8759d5cdb") ,DataPublicacao = DateTime.UtcNow} ,
            new LivroPublicacao { BibliotecaId = Guid.NewGuid(), Titulo = "Titulo 06",AutorLivro = Guid.Parse("25142ffd-7ea7-4de0-afce-3ec447536c27") ,DataPublicacao = DateTime.UtcNow} ,
            new LivroPublicacao { BibliotecaId = Guid.NewGuid(), Titulo = "Titulo 07",AutorLivro = Guid.Parse("cd6087c4-48c8-4c25-a704-41af2e0271b3") ,DataPublicacao = DateTime.UtcNow} ,
            new LivroPublicacao { BibliotecaId = Guid.NewGuid(), Titulo = "Titulo 08",AutorLivro = Guid.Parse("90bd9ee0-da94-48ef-8377-a3d9122868d3") ,DataPublicacao = DateTime.UtcNow} 
    );
        }
    }
}
