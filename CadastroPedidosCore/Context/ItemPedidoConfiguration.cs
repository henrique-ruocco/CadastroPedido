using CadastroPedidosCore.Models;

namespace CadastroPedidosCore.Context
{
    public class ItemPedidoConfiguration : EntityConfig<ItemPedido>
    {
        public ItemPedidoConfiguration()
        {
            Property(x => x.Quantidade).IsRequired();
        }
    }
}