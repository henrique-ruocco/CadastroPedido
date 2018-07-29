using System.Data.Entity.Migrations;
using CadastroPedidosCore.Context;
using CadastroPedidosCore.Context;

namespace CadastroPedidosCore.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "CadastroPedidos.Context.DBContext";
        }

        protected override void Seed(DBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Pedidos.AddOrUpdate(
                p => p.NomeCliente, new Models.Pedido{ }
                );
        }
    }
}
