using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CadastroPedidosCore.Models;
using Pedido = CadastroPedidosCore.Models.Pedido;

namespace CadastroPedidosCore.Context
{
    public class DBContext : DbContext
    {
        public IDbSet<Pedido> Pedidos { get; set; }
        public IDbSet<ItemPedido> Itens { get; set; }
        public IDbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Mapear todas as configurações por varredura de assembly ao invés de manualmente incluir.
            modelBuilder.Configurations.AddFromAssembly(typeof(DBContext).Assembly);

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));
        }
    }
}