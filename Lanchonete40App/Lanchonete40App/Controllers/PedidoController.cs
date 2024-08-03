using Microsoft.AspNetCore.Mvc;

namespace Lanchonete40App.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PedidoController : ControllerBase
    {
        [HttpPost("FinalizarPedido")]
        public void FinalizarPedido()
        {

        }
    }
}
