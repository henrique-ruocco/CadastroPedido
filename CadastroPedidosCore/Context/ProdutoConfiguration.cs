using CadastroPedidosCore.Models;

namespace CadastroPedidosCore.Context
{
    public class ProdutoConfiguration : EntityConfig<Produto>
    {
        public ProdutoConfiguration()
        {
            Property(x => x.Nome).IsRequired();
            Property(x => x.Valor).IsRequired();
        }
    }
}