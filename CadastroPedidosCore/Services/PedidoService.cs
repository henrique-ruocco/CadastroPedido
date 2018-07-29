using System.Collections.Generic;
using CadastroPedidosCore.Context;
using CadastroPedidosCore.Interfaces;
using CadastroPedidosCore.Models;

namespace CadastroPedidosCore.Services
{
    public abstract class Service : IPedidoService
    {
        protected readonly DBContext Db;

        protected Service(DBContext db)
        {
            Db = db;
        }

        //public int SalvarPedido(int pedidoId, int quantidade, string produto, decimal valorUnitario)
        //{

        //    Db.SaveChanges();
        //}

        public Pedido BuscarPedidos()
        {
            return Db.Pedidos.Find();
        }

        //public bool ExcluirPedido(int id, int idItem)
        //{
        //    var pedido = Db.Pedidos.Find(id);

        //    //pedido;

        //    Db.SaveChanges();
        //}
    }
}