using Core.Model;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UsuarioModel> GetUsers();
        UsuarioModel GetUserById(Guid userId);
        void InsertUser(UsuarioModel user);
        void UpdateUser(UsuarioModel user);
        void DeleteUserById(Guid idUser);
    }
}