using dotnet_socompa_api.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_socompa_api.Infrastructure.Persistence.Configurations
{
    
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("pedidos");
            builder.Property(e => e.id);
            builder.Property(e => e.numeroDePedido);
            builder.Property(e => e.cicloDelPedido);
            builder.Property(e => e.codigoDeContratoInterno);
            builder.Property(e => e.estadoDelPedido);
            builder.Property(e => e.cuentaCorriente);
            builder.Property(e => e.cuando);
        }
    }
}
