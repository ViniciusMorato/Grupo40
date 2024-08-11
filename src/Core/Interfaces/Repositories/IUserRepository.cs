using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        List<Usuario> GetUsers();
        Usuario? GetUserByCpf(string cpf);
        Usuario? GetUserByEmailSenha(string email, string senha);
        Usuario? GetUserById(int id);
        Usuario InsertUpdateUser(Usuario user);
        void DeleteUserById(Usuario user);
    }
}