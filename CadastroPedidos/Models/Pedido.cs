using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CadastroPedidos.Models
{
    public partial class Pedido : Entity<Pedido>
    {
        [Required(ErrorMessage = "Preencha o campo Nome.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres.")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres.")]
        [DisplayName("Nome")]
        public string NomeCliente { get; set; }

        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Valor Inválido")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999")]
        [Required(ErrorMessage = "Preencha o campo Valor.")]
        [DisplayName("Valor (R$)")]
        public decimal Valor { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        public decimal ValorTotal { get; set; }

        //public decimal ValorTotal => ItensPedido == null || !ItensPedido.Any() ? 0 : ItensPedido.Sum(x => x.ValorTotal);

        public virtual ICollection<Item> ItensPedido { get; set; }

        
    }
}