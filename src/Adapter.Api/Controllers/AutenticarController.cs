using Adapter.Jwt;
using AutoMapper;
using Core.Interfaces.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Core.Entities;
using Adapter.Api.DTO;
using Core.Interfaces.Services;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AutenticarController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IAuthentication _authentication;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AutenticarController(IOptions<AppSettings> options, IAuthentication authentication, IMapper mapper, IUserService userService)
        {
            _appSettings = options.Value;
            _authentication = authentication;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("AutenticarUsuario")]
        public IActionResult AutenticarUsuario([FromBody] AutUserDto usuarioDto)
        {
            try
            {
                // Verifica se o usuário existe
                if (usuarioDto == null)
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                Usuario? usuario = _userService.GetUserByEmailSenha(usuarioDto.Email, usuarioDto.Senha);

                if (usuario == null)
                    throw new ArgumentException("");

                // Gera o Token
                var token = _authentication.GerarToken(usuario, _appSettings.Secret);

                // Retorna os dados
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}