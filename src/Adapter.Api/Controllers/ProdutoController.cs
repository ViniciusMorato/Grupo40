using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ProdutoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("CriarProduto")]
        public IActionResult CriarProduto2()
        {
            return Ok();
        }

        [Authorize]
        [HttpPatch("EditarProduto")]
        public IActionResult EditarProduto()
        {
            return Ok();
        }

        [Authorize]
        [HttpDelete("RemoverProduto")]
        public IActionResult RemoverProduto()
        {
            return Ok();
        }

        [Authorize]
        [HttpGet("BuscarProduto")]
        public IActionResult BuscarProduto()
        {
            return Ok();
        }
    }
}
