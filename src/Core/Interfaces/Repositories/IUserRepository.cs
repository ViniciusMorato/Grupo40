using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<Usuario> GetUsers();
        Usuario? GetUserByCpf(string cpf);
        Usuario InsertUser(Usuario user);
        void UpdateUser(Usuario user);
        void DeleteUserById(Usuario user);
    }
}