using Lanchonete40App.Negocio.AcessoDados;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lanchonete40App.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteController : ControllerBase
    {
        [Authorize]
        [HttpPost("CadastrarCliente")]
        public void CadastrarCliente()
        {

        }

        [Authorize]
        [HttpGet("IdentificarCliente")]
        public void IdentificarCliente()
        {

        }
    }
}
