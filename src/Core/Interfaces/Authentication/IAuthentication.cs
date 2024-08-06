using Core.Negocio.Model;

namespace Core.Interfaces.Authentication
{
    public interface IAuthentication
    {
        string GerarToken(UsuarioModel usuarioModel, string secret);
    }
}