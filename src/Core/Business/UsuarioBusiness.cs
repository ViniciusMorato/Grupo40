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

        Usuario addNewUser = userRepository.InsertUpdateUser(usuario);
      
        return addNewUser;
    }

    public Usuario? GetUserByCpf(string cpf)
    {
        cpf = cpf.Trim();
        return userRepository.GetUserByCpf(cpf);
    }

    public Usuario? GetUserByEmailSenha(string email, string senha)
    {
        return userRepository.GetUserByEmailSenha(email, senha);
    }

    public Usuario? GetUserById(int id)
    {
        return userRepository.GetUserById(id);
    }

    public List<Usuario> GetUsers()
    {
        return userRepository.GetUsers();
    }
}