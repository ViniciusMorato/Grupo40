using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PedidoController : ControllerBase
    {
        [Authorize]
        [HttpPost("FinalizarPedido")]
        public void FinalizarPedido()
        {

        }
    }
}
