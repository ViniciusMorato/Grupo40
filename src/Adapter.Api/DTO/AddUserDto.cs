using System.ComponentModel.DataAnnotations;

namespace Adapter.Api.DTO;

public class AddUserDto
{
    private const string CpfPattern = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";

    [Required]
    [MaxLength(100, ErrorMessage = "Nome não pode ultrapassar 100 caracteres")]
    public string Nome { get; set; }

    [Required]
    [MaxLength(100, ErrorMessage = "Sobrenome não pode ultrapassar 100 caracteres")]
    public string SobreNome { get; set; }

    [Required(ErrorMessage = "Campo usuário é obrigatório")]
    [RegularExpression(CpfPattern, ErrorMessage = "Campo precisa ser um CPF válido")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "Campo senha é obrigatório")]
    [MinLength(8, ErrorMessage = "Campo senha precisa conter no mínimo 8 caracteres")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "Campo email é obrigatório")]
    [EmailAddress]
    public string Email { get; set; }
}