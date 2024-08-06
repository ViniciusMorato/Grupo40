using Core.Interfaces.Authentication;
using Core.Negocio.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Adapter.Jwt
{
    public class Jwt : IAuthentication
    {
        public string GerarToken(UsuarioModel usuarioModel, string secret)
        {
            var jwtToken = new JwtSecurityToken(
                    claims: new Claim[] {
                    new Claim(ClaimTypes.Name, usuarioModel.Usuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioModel.Papel.ToString())
                    },
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)), SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}