using Adapter.DataAccessLayer.Util;
using Core.Interfaces.Repositories;
using Core.Entities;
using SqlKata.Execution;

namespace Adapter.DataAccessLayer.Dal;

public class UsuarioDal : IUserRepository
{
    private readonly QueryFactory _db;

    public UsuarioDal(PostgreSqlContext postgreSqlContext)
    {
        _db = postgreSqlContext.CreateQueryFactory();
    }

    public IEnumerable<Usuario> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Usuario? GetUserById(string cpf)
    {
        throw new NotImplementedException();
    }

    public Usuario InsertUser(Usuario user)
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(Usuario user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUserById(int idUser)
    {
        throw new NotImplementedException();
    }
}