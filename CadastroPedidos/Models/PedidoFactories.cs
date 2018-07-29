using System.Linq;

namespace CadastroPedidos.Models
{
    public partial class Pedido
    {
        public static Pedido NovoPedido(int id)
        {
            return new Pedido
            {
                Id = id
            };
        }

        public static Item NovoItem(int pedidoId, int quantidade, string produto, decimal valorUnitario)
        {
            return new Item()
            {
                PedidoId = pedidoId,

            };
        }



        public Item BuscarItem(int idItem)
        {
            return ItensPedido?.SingleOrDefault(x => x.Id == idItem);
        }

        public bool ExcluirItem(int idItem)
        {
            var item = BuscarItem(idItem);

            if (item == null) return false;

            ItensPedido.Remove(item);

            return true;
        }
    }
}