using System;

namespace CadastroPedidosCore.Models
{
    public abstract class Entity<T>
    {
        public int Id { get; set; }
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
        public const string TamanhoMaximo = "Máximo de caracteres {0}";
    }
}