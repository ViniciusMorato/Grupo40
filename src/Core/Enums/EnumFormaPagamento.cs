using System.ComponentModel.DataAnnotations;

namespace Core.Enums
{
    public enum EnumFormaPagamento
    {
        [Display(Name = "CartaoCredito")]
        CartaoCredito = 1,
        [Display(Name = "CartaoDebito")]
        CartaoDebito = 2,
        [Display(Name = "Dinheiro")]
        Dinheiro = 3,
        [Display(Name = "Pix")]
        Pix = 4
    }
}
