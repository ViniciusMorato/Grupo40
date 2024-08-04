using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lanchonete40App.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProdutoController : ControllerBase
    {
        [Authorize]
        [HttpPost("CriarProduto")]
        public void CriarProduto2()
        {

        }

        [Authorize]
        [HttpPatch("EditarProduto")]
        public void EditarProduto()
        {

        }

        [Authorize]
        [HttpDelete("RemoverProduto")]
        public void RemoverProduto()
        {

        }

        [Authorize]
        [HttpGet("BuscarProduto")]
        public void BuscarProduto()
        {

        }
    }
}
