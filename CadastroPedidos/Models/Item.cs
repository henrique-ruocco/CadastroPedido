using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadastroPedidos.Models
{
    [MetadataType(typeof(ItemValidation))]
    public class Item : Entity<Item>
    {
        public int PedidoId { get; protected set; }

        public int Quantidade { get; protected set; }

        public string Produto { get; protected set; }

        public decimal ValorUnitario { get; protected set; }

        public decimal ValorTotal { get; protected set; }

        public virtual Pedido Pedido { get; protected  set; }

        // solid
        public void AtualizarQuantidade(int novaQuantidade)
        {
            Quantidade = novaQuantidade;
            ValorTotal = ValorUnitario * Quantidade;
        }
    }   

    public class ItemValidation
    { 
        [Required(ErrorMessage = ErrorMessageConstants.Required)]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessageConstants.Required)]
        [Range(0, int.MaxValue, ErrorMessage = ErrorMessageConstants.Range)]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = ErrorMessageConstants.Required)]
        [MaxLength(100, ErrorMessage = ErrorMessageConstants.TamanhoMaximo)]
        [DisplayName("Descrição do Item")]
        public string Produto { get; set; }

        [RegularExpression(RegexConstants.NumbersOnly, ErrorMessage = ErrorMessageConstants.ValorInvalido)]
        [DataType(DataType.Currency)]
        [Range(0, float.MaxValue, ErrorMessage = ErrorMessageConstants.Range)]
        [Required(ErrorMessage = ErrorMessageConstants.Required)]
        [DisplayName("Valor (R$)")]
        public decimal ValorUnitario { get; set; }
    }
}