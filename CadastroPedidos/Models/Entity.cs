using System;

namespace CadastroPedidos.Models
{
    public abstract class Entity<T>
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }

        public override string ToString()
        {
            return $"[Id: {Id} - Guid: {Guid}]";
        }

        public string GetCode() => Guid.ToString().Substring(0, 7).ToUpper();
    }
}