using CadastroPedidos.Models;

namespace CadastroPedidos.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CadastroPedidos.Context.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "CadastroPedidos.Context.DBContext";
        }

        protected override void Seed(Context.DBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Pedidos.AddOrUpdate(
                p => p.NomeCliente, new Pedido{ }
                );
        }
    }
}
