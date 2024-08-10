using Adapter.Api.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public ClienteController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet("Clientes")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        public IEnumerable<Usuario> BuscaUsuarios()
        {
            return _userService.GetUsers();
        }
        
        [HttpPost("CadastrarCliente")]
        [ProducesResponseType(typeof(AddUserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarCliente([FromBody] AddUserDto user)
        {
            Usuario userEntity = _mapper.Map<Usuario>(user);
            _userService.AddNewUser(userEntity);

            return CreatedAtAction(nameof(IdentificarCliente),
                new { cpf = user.Cpf },
                user);
        }

        [HttpGet("{cpf}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult IdentificarCliente(string cpf)
        {
            var user = _userService.GetUserByCpf(cpf);

            if (user != null) return NotFound();

            UserDto userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }
    }
}