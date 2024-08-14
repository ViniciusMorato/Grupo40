using System.ComponentModel.DataAnnotations;

namespace Core.Enums;

public enum EnumCategoria
{
    [Display(Name = "Lanche")]
    Lanche = 1,
    [Display(Name = "Acompanhamento")]
    Acompanhamento = 2,
    [Display(Name = "Bebida")]
    Bebida = 3,
    [Display(Name = "Sobremesa")]
    Sobremesa = 4
}