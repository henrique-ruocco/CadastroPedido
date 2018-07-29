using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CadastroPedidos.Models
{
    [MetadataType(typeof(PedidoValidation))]
    public partial class Pedido : Entity<Pedido>
    {
        public string NomeCliente { get; protected set; }

        public decimal Valor { get; protected set; }

        public DateTime Data { get; protected set; }

        public decimal ValorTotal => ItensPedido == null || !ItensPedido.Any() ? 0 : ItensPedido.Sum(x => x.ValorTotal);

        public virtual ICollection<Item> ItensPedido { get; protected set; }
    }

    public class PedidoValidation
    {
        [Required(ErrorMessage = ErrorMessageConstants.Required)]
        [MaxLength(100, ErrorMessage = ErrorMessageConstants.TamanhoMaximo)]
        [DisplayName("Nome")]
        public string NomeCliente { get; set; }

        [RegularExpression(RegexConstants.NumbersOnly, ErrorMessage = ErrorMessageConstants.ValorInvalido)]
        [DataType(DataType.Currency)]
        [Range(0, float.MaxValue, ErrorMessage = ErrorMessageConstants.Range)]
        [Required(ErrorMessage = ErrorMessageConstants.Required)]
        [DisplayName("Valor (R$)")]
        public decimal Valor { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        [Required(ErrorMessage = ErrorMessageConstants.Required)]
        public DateTime Data { get; set; }
    }
}