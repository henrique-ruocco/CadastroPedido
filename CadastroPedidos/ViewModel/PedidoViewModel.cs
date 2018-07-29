using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CadastroPedidosCore.Models;

namespace CadastroPedidos.ViewModel
{
    public class PedidoViewModel
    {
        [Required(ErrorMessage = ErrorMessageConstants.Required)]
        [MaxLength(100, ErrorMessage = ErrorMessageConstants.TamanhoMaximo)]
        [DisplayName("Nome")]
        public string NomeCliente { get; set; }

        public decimal Total { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        [Required(ErrorMessage = ErrorMessageConstants.Required)]
        public DateTime Data { get; set; }
    }
}