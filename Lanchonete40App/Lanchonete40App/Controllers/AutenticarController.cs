using Lanchonete40App.Negocio.Model;
using Lanchonete40App.Negocio.Negocios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace Lanchonete40App.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AutenticarController : ControllerBase
    {
        private readonly AppSettings _appSettings = new AppSettings();

        public AutenticarController(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        [HttpPost("AutenticarUsuario")]
        public IActionResult AutenticarUsuario([FromBody]UsuarioModel usuario)
        {
            // Verifica se o usuário existe
            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = AutenticarNegocio.GerarToken(usuario, _appSettings.Secret);

            // Retorna os dados
            return Ok(token);
        }
    }
}
