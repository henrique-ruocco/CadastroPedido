using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadastroPedidosCore.Models
{
    public partial class Pedido : Entity<Pedido>
    {
        public string NomeCliente { get; protected set; }

        public decimal Total { get; protected set; }

        public DateTime Data { get; protected set; }

        public virtual ICollection<ItemPedido> ItensPedido { get; protected set; }
    }
}