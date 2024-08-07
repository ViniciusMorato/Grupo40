using System.ComponentModel.DataAnnotations;

namespace Adapter.Api.DTO;

public class UserAuthenticationDto
{
    private const string CpfPattern = @"^\d{3}\.?\d{3}\.?\d{3}\-?\d{2}$";

    [Required(ErrorMessage = "Campo usuário é obrigatório")]
    [RegularExpression(CpfPattern, ErrorMessage = "Campo precisa ser um CPF válido")]
    public string Usuario { get; set; }

    [Required(ErrorMessage = "Campo senha é obrigatório")]
    public string Senha { get; set; }
}