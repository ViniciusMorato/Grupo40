using Core.Entities;

namespace Core.Interfaces.Services;

public interface IUserService
{
    Usuario AddNewUser(Usuario usuario);
    Usuario? GetUserByCpf(string cpf);
    Usuario? GetUserByEmailSenha(string email, string senha);
    Usuario? GetUserById(int id);
    List<Usuario> GetUsers();
}