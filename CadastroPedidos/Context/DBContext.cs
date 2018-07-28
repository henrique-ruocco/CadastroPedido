using CadastroPedidos.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CadastroPedidos.Context
{
    public class DBContext : DbContext
    {
        public IDbSet<Pedido> Pedidos { get; set; }
        public IDbSet<Item> Itens { get; set; }

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