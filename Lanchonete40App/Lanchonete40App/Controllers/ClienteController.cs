using Microsoft.AspNetCore.Mvc;

namespace Lanchonete40App.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpPost("CadastrarCliente")]
        public void CadastrarCliente()
        {

        }

        [HttpGet("IdentificarCliente")]
        public void IdentificarCliente()
        {

        }
    }
}
