using Adapter.Api.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
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
        [ProducesResponseType(typeof(AddUserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CriarProduto([FromBody] AddProductDto productDto)
        {
            Produto productEntity = _mapper.Map<Produto>(productDto);
            _productService.AddNewProduct(productEntity);

            return CreatedAtAction(nameof(BuscarProduto),
                new { x = productEntity.Id }, productEntity);
        }

        [HttpGet("ListaProdutos")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        public IEnumerable<ProductDto> BuscarProdutos()
        {
            IEnumerable<Produto> products = _productService.GetProducts();
            IEnumerable<ProductDto> productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return productDtos;
        }

        [HttpPut( Name = "id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult EditarProduto(int id, [FromBody] UpdateProductDto productDto)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();
            _mapper.Map(productDto, product);
            _productService.UpdateProduct(product);
            return NoContent();
        }


        [HttpDelete(Name = "id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RemoverProduto(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();
            _productService.DeleteProduct(product);
            return NoContent();
        }

        [HttpGet(Name = "id")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarProduto(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null) return NotFound();

            ProductDto productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }
    }
}