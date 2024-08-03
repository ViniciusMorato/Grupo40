using Microsoft.AspNetCore.Mvc;

namespace Lanchonete40App.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProdutoController : ControllerBase
    {
        [HttpPost("CriarProduto")]
        public void CriarProduto2()
        {

        }

        [HttpPatch("EditarProduto")]
        public void EditarProduto()
        {

        }

        [HttpDelete("RemoverProduto")]
        public void RemoverProduto()
        {

        }

        [HttpGet("BuscarProduto")]
        public void BuscarProduto()
        {

        }
    }
}
