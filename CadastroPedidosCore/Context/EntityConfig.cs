using System.Data.Entity.ModelConfiguration;
using CadastroPedidosCore.Models;

namespace CadastroPedidosCore.Context
{
    public abstract class EntityConfig<T> : EntityTypeConfiguration<T> where T : Entity<T>
    {
        public EntityConfig() => HasKey(x => x.Id);
    }
}