using Adapter.PostgreSQL.Context;
using Core.Interfaces.Repositories;
using Core.Entities;

namespace Adapter.PostgreSQL.Repositories;

public class UsuarioDal : IUserRepository
{
    private readonly PostgreSqlContext _context;

    public UsuarioDal(PostgreSqlContext context)
    {
        _context = context;
    }


    public IEnumerable<Usuario> GetUsers()
    {
        return _context.Usuarios;
    }

    public Usuario? GetUserByCpf(string cpf)
    {
        return _context.Usuarios.FirstOrDefault(user => user.Cpf == cpf);
    }

    public Usuario InsertUser(Usuario user)
    {
        _context.Usuarios.Add(user);
        _context.SaveChanges();
        return user;
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