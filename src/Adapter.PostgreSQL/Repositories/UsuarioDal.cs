using Adapter.DataAccessLayer.Context;
using Core.Interfaces.Repositories;
using Core.Entities;

namespace Adapter.DataAccessLayer.Repositories;

public class UsuarioDal : IUserRepository
{
    private readonly PostgreSqlContext _context;

    public UsuarioDal(PostgreSqlContext context)
    {
        _context = context;
    }


    public IEnumerable<Usuario> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Usuario? GetUserById(string cpf)
    {
        return _context.Usuarios.FirstOrDefault(user => user.Cpf == cpf);
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