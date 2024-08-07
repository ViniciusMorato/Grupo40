using Core.Interfaces.Repositories;
using Core.Model;

namespace Adapter.DataAccessLayer.Dal;

public class UsuarioDal : IUserRepository
{
    public IEnumerable<UsuarioModel> GetUsers()
    {
        throw new NotImplementedException();
    }

    public UsuarioModel GetUserById(Guid userId)
    {
        throw new NotImplementedException();
    }

    public void InsertUser(UsuarioModel user)
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(UsuarioModel user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUserById(Guid idUser)
    {
        throw new NotImplementedException();
    }
}