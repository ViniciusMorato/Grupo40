using Core.Entities;

namespace Core.Interfaces.Authentication
{
    public interface IAuthentication
    {
        string GerarToken(Usuario usuario, string secret);
    }
}