using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopServices.Api.Carrinho.Models;

namespace ShopServices.Api.Livro.Data.Mappings
{
    public class CarrinhoCompraItemMapping : IEntityTypeConfiguration<CarrinhoCompraItem>
    {
        public void Configure(EntityTypeBuilder<CarrinhoCompraItem> builder)
        {
            builder.ToTable("CarrinhoItem");
            builder.HasKey(x => x.CarrinhoItemId);
            builder.Property(x => x.DataCadastro);
            builder.Property(x => x.ProdutoSelecionado).HasMaxLength(36);
        }
    }
}
