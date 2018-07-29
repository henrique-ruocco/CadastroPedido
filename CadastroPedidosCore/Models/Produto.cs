namespace CadastroPedidosCore.Models
{
    public class Produto : Entity<Produto>
    {
        public string Nome { get; protected set; }
        public decimal Valor { get; protected set; }
    }
}