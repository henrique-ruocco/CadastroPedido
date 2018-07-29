using CadastroPedidosCore.Models;

namespace CadastroPedidosCore.Context
{
    public class PedidoConfiguration : EntityConfig<Pedido>
    {
        public PedidoConfiguration()
        {
            Property(x => x.NomeCliente).IsRequired();
            Property(x => x.Data).IsRequired();
            Property(x => x.Total).IsRequired();
        }
    }
}