using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Core.Business;

public class UsuarioBusiness(IUserRepository userRepository) : IUserService
{
    public Usuario AddNewUser(Usuario usuario)
    {
        usuario.Validade();
        var user = GetUserByCpf(usuario.Cpf);
        if (user != null)
        {
            return user;
        }

        Usuario addNewUser = userRepository.InsertUser(usuario);
      
        return addNewUser;
    }

    public Usuario? GetUserByCpf(string cpf)
    {
        return userRepository.GetUserById(cpf);
    }

    public IEnumerable<Usuario> GetUsers()
    {
        return userRepository.GetUsers();
    }
}