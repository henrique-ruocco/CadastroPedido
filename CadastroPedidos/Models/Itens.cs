using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadastroPedidos.Models
{
    [MetadataType(typeof(ItemValidation))]
    public class Item : Entity<Item>
    {
        public int PedidoId { get; set; }

        public int Quantidade { get; set; }

        public string Produto { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal ValorTotal { get; set; }

        public virtual Pedido Pedido { get; set; }

        // factory methods
        public static Item Novo(int pedidoId, int qte) { return null; }

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

        [Required(ErrorMessage = "Preencha o campo Quantidade.")]
        [Range(typeof(int), "1", "999999999")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres.")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres.")]
        [DisplayName("Descrição do Item")]
        public string Produto { get; set; }

        [RegularExpression(RegexConstants.NumbersOnly, ErrorMessage = ErrorMessageConstants.ValorInvalido)]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999", ErrorMessage = ErrorMessageConstants.Range)]
        [Required(ErrorMessage = ErrorMessageConstants.Required)]
        [DisplayName("Valor (R$)")]
        public decimal ValorUnitario { get; set; }
    }

    public class RegexConstants
    {
        public const string NumbersOnly = @"\d+(\.\d{1,2})?";
    }

    public class ErrorMessageConstants
    {
        public const string Range = "O valor deve estar entre {0} e {1}";
        public const string Required = "Preencha o campo {0}";
        public const string ValorInvalido = "Valor Inválido";
    }
}