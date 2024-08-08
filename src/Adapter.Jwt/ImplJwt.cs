using System.IdentityModel.Tokens.Jwt;
using Core.Interfaces.Authentication;
using System.Security.Claims;
using System.Text;
using Core.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Adapter.Jwt
{
    public class ImplJwt : IAuthentication
    {
        public string GerarToken(Usuario usuario, string secret)
        {
            var jwtToken = new JwtSecurityToken(
                claims: new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Cpf.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Papel.ToString())
                },
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)),
                    SecurityAlgorithms.HmacSha256Signature)
            );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}