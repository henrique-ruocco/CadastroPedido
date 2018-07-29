namespace CadastroPedidosCore.Models
{
    public partial class ItemPedido : Entity<ItemPedido>
    {
        public int PedidoId { get; protected set; }

        public int ProdutoId { get; protected set ; }

        public int Quantidade { get; protected set; }
        
        public virtual Pedido Pedido { get; protected set; }

        public virtual Produto Produto { get; protected set; }
    }
}