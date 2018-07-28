using CadastroPedidos.App_Start;
using CadastroPedidos.Context;

namespace CadastroPedidos.Controllers
{
    public class PedidoService : Service, IPedidoService
    {
        public PedidoService(DBContext db)
            : base(db)
        {
        }

        public bool ExcluirItem(int id, int idItem)
        {
            var pedido = Db.Pedidos.Find(id);

            if (!pedido.ExcluirItem(idItem)) return false;

            Db.SaveChanges();

            return true;
        }
    }
}