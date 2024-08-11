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

    public List<Usuario> GetUsers()
    {
        return _context.Usuarios.ToList();
    }

    public Usuario? GetUserByCpf(string cpf)
    {
        return _context.Usuarios.FirstOrDefault(user => user.Cpf == cpf);
    }

    public Usuario InsertUpdateUser(Usuario user)
    {
        if(user.Id == 0)
        {
            _context.Usuarios.Add(user);
        }
        _context.SaveChanges();
        return user;
    }

    public void DeleteUserById(Usuario user)
    {
        _context.Usuarios.Remove(user);
    }

    public Usuario? GetUserById(int id)
    {
        return _context.Usuarios.FirstOrDefault(user => user.Id == id);
    }

    public Usuario? GetUserByEmailSenha(string email, string senha)
    {
        return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
    }
}