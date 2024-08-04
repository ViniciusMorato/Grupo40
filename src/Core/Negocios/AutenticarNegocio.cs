using Lanchonete40App.Negocio.Model;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Core.Negocio.Negocios
{
    public class AutenticarNegocio
    {
        public static string GerarToken(UsuarioModel usuarioModel, string secret)
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
