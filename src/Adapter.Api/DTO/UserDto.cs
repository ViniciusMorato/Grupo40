using Core.Enums;

namespace Adapter.Api.DTO;

public class UserDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string SobreNome { get; set; }
    public string Cpf { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
}

public class AutUserDto
{
    public string Email { get; set; }
    public string Senha { get; set; }

}