using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Core.Business;

public class UsuarioBusiness(IUserRepository userRepository) : IUserService
{
    public Usuario AddNewUser(Usuario usuario)
    {
        var user = GetUserByCpf(usuario.Cpf);
        if (user != null)
        {
            return user;
        }

        return userRepository.InsertUser(usuario);
    }

    public Usuario? GetUserByCpf(string cpf)
    {
        return userRepository.GetUserById(cpf);
    }
}