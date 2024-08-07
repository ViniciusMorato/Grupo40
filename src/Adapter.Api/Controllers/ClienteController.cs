using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ClienteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("CadastrarCliente")]
        public IActionResult CadastrarCliente()
        {
            return Ok();
        }

        [Authorize]
        [HttpGet("IdentificarCliente")]
        public IActionResult IdentificarCliente()
        {
            return Ok();
        }
    }
}
