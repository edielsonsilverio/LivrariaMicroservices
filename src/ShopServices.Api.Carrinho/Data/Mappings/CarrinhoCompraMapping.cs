using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopServices.Api.Carrinho.Models;

namespace ShopServices.Api.Livro.Data.Mappings
{
    public class CarrinhoCompraMapping : IEntityTypeConfiguration<CarrinhoCompra>
    {
        public void Configure(EntityTypeBuilder<CarrinhoCompra> builder)
        {
            builder.ToTable("Carrinho");
            builder.HasKey(x => x.CarrinhoCompraId);
            builder.Property(x => x.DataCadastro);

            builder.HasMany(x => x.ListaDetalhe)
                   .WithOne(i=> i.Carrinho)
                   .HasForeignKey(i=> i.CarrinhoCompraId);
        }
    }
}
