using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CadastroPedidosCore.Models;

namespace CadastroPedidos.ViewModel
{
    public class ItemViewModel
    {
        [Required(ErrorMessage = ErrorMessageConstants.Required)]
        public int Id { get; protected internal set; }

        public int Quantidade { get; protected internal set; }
    }
}