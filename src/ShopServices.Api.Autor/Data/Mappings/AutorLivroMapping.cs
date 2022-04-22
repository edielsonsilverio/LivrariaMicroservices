using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopServices.Api.Autor.Models;

namespace ShopServices.Api.Autor.Data.Mapping
{
    public class AutorLivroMapping : IEntityTypeConfiguration<AutorLivro>
    {
        public void Configure(EntityTypeBuilder<AutorLivro> builder)
        {
            builder.ToTable("AutorLivros");
            builder.HasKey(x => x.AutorLivroId);
            builder.Property(x => x.Nome).HasMaxLength(80);
            builder.Property(x => x.AutorLivroGuid).HasMaxLength(36);
            builder.Property(x => x.Apelido).HasMaxLength(50);

            builder.HasMany(x=> x.GrauAcademicos)
                   .WithOne(g => g.AutorLivro)
                   .HasForeignKey(g => g.GrauAcademicoId);

            InserirAutor(builder);
        }

        private void InserirAutor(EntityTypeBuilder<AutorLivro> builder)
        {
                    builder.HasData(
                    new() { AutorLivroId = 1, Nome = "Maria", Apelido = "Mara", DataNascimento = DateTime.Now, AutorLivroGuid = "49f9e020-808d-4fd0-8ce8-2bd76a7ba199" },
                    new() { AutorLivroId = 2, Nome = "Pedro", Apelido = "Pedra", DataNascimento = DateTime.Now, AutorLivroGuid = "c7606156-c165-4da5-9e7d-28af654bb97d" },
                    new() { AutorLivroId = 3, Nome = "Antonio", Apelido = "Tonho", DataNascimento = DateTime.Now, AutorLivroGuid = "368e956e-f665-4291-9a1a-53fc4cb4338a" },
                    new() { AutorLivroId = 4, Nome = "Marcio", Apelido = "Cabeça", DataNascimento = DateTime.Now, AutorLivroGuid = "8bf309ec-b958-4bcd-99f4-c7dd110c376d" },
                    new() { AutorLivroId = 5, Nome = "Ana", Apelido = "Ana", DataNascimento = DateTime.Now, AutorLivroGuid =  "de2eb41d-c9fd-4a5f-bbd9-57a8759d5cdb" },
                    new() { AutorLivroId = 6, Nome = "José", Apelido = "Zé", DataNascimento = DateTime.Now, AutorLivroGuid = "25142ffd-7ea7-4de0-afce-3ec447536c27" },
                    new() { AutorLivroId = 7, Nome = "Joana", Apelido = "JÔ", DataNascimento = DateTime.Now, AutorLivroGuid = "cd6087c4-48c8-4c25-a704-41af2e0271b3" },
                    new() { AutorLivroId = 8, Nome = "Alessandro", Apelido = "Alex", DataNascimento = DateTime.Now, AutorLivroGuid = "90bd9ee0-da94-48ef-8377-a3d9122868d3" }
            );
        }
    }
}
