using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IMapper _mapper;

        public PedidoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("FinalizarPedido")]
        public IActionResult FinalizarPedido()
        {
            return Ok();
        }
    }
}
