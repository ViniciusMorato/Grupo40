using Adapter.Api.DTO;
using Adapter.Jwt;
using AutoMapper;
using Core.Interfaces.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Core.Entities;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AutenticarController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IAuthentication _authentication;
        private readonly IMapper _mapper;

        public AutenticarController(IOptions<AppSettings> options, IAuthentication authentication, IMapper mapper)
        {
            _appSettings = options.Value;
            _authentication = authentication;
            _mapper = mapper;
        }

        [HttpPost("AutenticarUsuario")]
        public IActionResult AutenticarUsuario([FromBody] Usuario usuario)
        {
            // Verifica se o usuário existe
            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = _authentication.GerarToken(usuario, _appSettings.Secret);

            // Retorna os dados
            return Ok(token);
        }
    }
}