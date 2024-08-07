using Adapter.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Core.Model;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AutenticarController : ControllerBase
    {
        private readonly AppSettings _appSettings = new AppSettings();
        private readonly ImplJwt _autenticarNegocio;

        public AutenticarController(IOptions<AppSettings> options, ImplJwt autenticarNegocio)
        {
            _appSettings = options.Value;
            _autenticarNegocio = autenticarNegocio;
        }

        [HttpPost("AutenticarUsuario")]
        public IActionResult AutenticarUsuario([FromBody] UsuarioModel usuario)
        {
            // Verifica se o usuário existe
            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = _autenticarNegocio.GerarToken(usuario, _appSettings.Secret);

            // Retorna os dados
            return Ok(token);
        }
    }
}