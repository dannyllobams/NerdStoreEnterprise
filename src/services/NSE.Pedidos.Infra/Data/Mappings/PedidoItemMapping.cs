using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.Pedidos.Domain.Pedidos;

namespace NSE.Pedidos.Infra.Data.Mappings
{
    public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(pi => pi.Id);

            builder.Property(pi => pi.ProdutoNome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.HasOne(pi => pi.Pedido)
                .WithMany(pi => pi.PedidoItems);

            builder.ToTable("PedidoItems");
        }
    }
}
