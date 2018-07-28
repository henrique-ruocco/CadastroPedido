using CadastroPedidos.Models;

namespace CadastroPedidos.Context
{
    public class PedidoConfiguration : EntityConfig<Item>
    {
        public PedidoConfiguration()
        {

            // Ignorar tudo que for TOTAL de coisas.
            Ignore(x => x.ValorTotal);
        }
    }
}