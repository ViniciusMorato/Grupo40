using System.ComponentModel.DataAnnotations;

namespace Core.Enums
{
    public enum EnumStatusPedido
    {
        [Display(Name = "Pendente")]
        Pendente = 1,
        [Display(Name = "Processando")]
        Processando = 2,
        [Display(Name = "Concluído")]
        Concluído = 3,
        [Display(Name = "Cancelado")]
        Cancelado = 4
    }
}
