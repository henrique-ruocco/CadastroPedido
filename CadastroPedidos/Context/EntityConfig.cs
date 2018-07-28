using CadastroPedidos.Models;
using System.Data.Entity.ModelConfiguration;

namespace CadastroPedidos.Context
{
    public abstract class EntityConfig<T> : EntityTypeConfiguration<T> where T : Entity<T>
    {
        public EntityConfig()
        {
            HasKey(x => x.Id);
        }
    }
}