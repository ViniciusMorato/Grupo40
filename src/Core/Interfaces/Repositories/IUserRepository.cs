using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<Usuario> GetUsers();
        Usuario GetUserById(Guid userId);
        void InsertUser(Usuario user);
        void UpdateUser(Usuario user);
        void DeleteUserById(Guid idUser);
    }
}