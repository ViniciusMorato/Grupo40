using Adapter.Api.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IUserAddressService _userAddressService;
        private readonly ICredCardService _credCardService;

        public ClienteController(IMapper mapper, IUserService userService, IUserAddressService userAddressService, ICredCardService credCardService)
        {
            _mapper = mapper;
            _userService = userService;
            _userAddressService = userAddressService;
            _credCardService = credCardService;
        }

        [HttpGet("Clientes")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        public IActionResult BuscaUsuarios()
        {
            try
            {
                return Ok(_userService.GetUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CadastrarCliente")]
        [ProducesResponseType(typeof(AddUserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarCliente([FromBody] AddUserDto userDto)
        {
            try
            {
                Usuario userEntity = _mapper.Map<Usuario>(userDto);
                userEntity = _userService.AddNewUser(userEntity);

                return Ok(_mapper.Map<UserDto>(userEntity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet(Name = "cpf")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult IdentificarCliente([FromQuery] string cpf)
        {
            try
            {
                Usuario? user = _userService.GetUserByCpf(cpf);

                if (user == null)
                    return NotFound();

                return Ok(_mapper.Map<UserDto>(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("CadastrarEndereco")]
        public IActionResult CadastrarEndereco([FromBody] AddPessoaEnderecoDto pessoaEnderecoDto)
        {
            try
            {
                UsuarioEndereco usuarioEnderecoEntity = _mapper.Map<UsuarioEndereco>(pessoaEnderecoDto);

                usuarioEnderecoEntity = _userAddressService.AddNewUserAddress(usuarioEnderecoEntity);

                return Ok(_mapper.Map<ReturnPessoaEnderecoDto>(usuarioEnderecoEntity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("RetornarEnderecosCliente")]
        [ProducesResponseType(typeof(List<ReturnPessoaEnderecoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RetornarEnderecosCliente([FromQuery] int cliente)
        {
            try
            {
                List<UsuarioEndereco> usuarioEnderecoEntity = _userAddressService.GetUserAddressByUserId(cliente);

                return Ok(_mapper.Map<List<ReturnPessoaEnderecoDto>>(usuarioEnderecoEntity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("CadastrarCartaoCredito")]
        [ProducesResponseType(typeof(ClienteCartaoCreditoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarCartaoCredito([FromBody] ClienteCartaoCreditoDto clienteCartaoCredito)
        {
            try
            {
                CartaoCredito cartaoCredito = _mapper.Map<CartaoCredito>(clienteCartaoCredito);

                cartaoCredito = _credCardService.AddNewCredCard(cartaoCredito);

                return Ok(_mapper.Map<ReturnClienteCartaoCreditoDto>(cartaoCredito));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult RemoverCartaoCredito([FromQuery] int cartaoCreditoId)
        {
            try
            {
                _credCardService.DeleteCredCard(cartaoCreditoId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}