using Adapter.Api.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProdutoController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpPost("CriarProduto")]
        [ProducesResponseType(typeof(ReturnProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CriarProduto([FromBody] AddProductDto productDto)
        {
            try
            {
                Produto productEntity = _mapper.Map<Produto>(productDto);
                productEntity = _productService.AddNewProduct(productEntity);

                return Ok(_mapper.Map<ReturnProductDto>(productEntity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscarProdutos")]
        [ProducesResponseType(typeof(ReturnProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult BuscarProdutos()
        {
            try
            {
                List<Produto> products = _productService.GetProducts();
                return Ok(_mapper.Map<List<ProductDto>>(products));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut( Name = "EditarProduto")]
        [ProducesResponseType(typeof(ReturnProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EditarProduto(int id, [FromBody] UpdateProductDto productDto)
        {
            try
            {
                var product = _productService.GetProductById(id);
                if (product == null) return NotFound();
                _mapper.Map(productDto, product);
                product = _productService.UpdateProduct(product);
                return Ok(_mapper.Map<ProductDto>(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(Name = "RemoverProduto")]
        [ProducesResponseType(typeof(ReturnProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RemoverProduto(int id)
        {
            try
            {
                var product = _productService.GetProductById(id);
                if (product == null) return NotFound();
                _productService.DeleteProduct(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet(Name = "BuscarProduto")]
        [ProducesResponseType(typeof(ReturnProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult BuscarProduto(int id)
        {
            try
            {
                var product = _productService.GetProductById(id);

                if (product == null) return NotFound();

                return Ok(_mapper.Map<ProductDto>(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}