using Adapter.DataAccessLayer.Util;
using Core.Interfaces.Repositories;
using Core.Entities;
using SqlKata.Execution;

namespace Adapter.DataAccessLayer.Dal;

public class UsuarioDal : IUserRepository
{
    private readonly QueryFactory _db;

    public UsuarioDal(DataAccessFactory dataAccessFactory)
    {
        _db = dataAccessFactory.CreateQueryFactory();
    }

    public IEnumerable<Usuario> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Usuario GetUserById(Guid userId)
    {
        throw new NotImplementedException();
    }

    public void InsertUser(Usuario user)
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(Usuario user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUserById(Guid idUser)
    {
        throw new NotImplementedException();
    }
}