using Adapter.Api.DTO;
using AutoMapper;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IUserAddressService _userAddressService;
        private readonly IOrderService _orderService;
        private readonly IOrderItensService _orderItensService;
        private readonly IProductService _productService;

        public PedidoController(IMapper mapper, IUserService userService, IOrderService orderService, IUserAddressService userAddressService, IProductService productService, IOrderItensService orderItensService)
        {
            _mapper = mapper;
            _userService = userService;
            _orderService = orderService;
            _userAddressService = userAddressService;
            _productService = productService;
            _orderItensService = orderItensService;
        }

        [Authorize]
        [HttpGet("RetornarPedido")]
        public IActionResult RetornarPedido(int pedido)
        {
            return Ok();
        }

        [Authorize]
        [HttpGet("RetornarPedidosCliente")]
        public IActionResult RetornarPedidosCliente(int cliente)
        {
            return Ok();
        }

        [Authorize]
        [HttpPost("RealizarPedido")]
        public IActionResult RealizarPedido([FromBody] AddPedidoDTO pedido)
        {
            Pedido pedidoEntity = _mapper.Map<Pedido>(pedido);
            List<PedidoItem> ListaPedidoProdutoEntity = _mapper.Map<List<PedidoItem>>(pedido.Itens);

            if (_userService.GetUserById(pedidoEntity.Id) == null)
            {
                throw new ArgumentException("Usuario não encontrado!");
            }
    
            if (_userAddressService.GetUserAddressByUserId(pedidoEntity.UsuarioEndereco) == null)
            {
                throw new ArgumentException("Usuario não encontrado!");
            }

            Produto? produto = new Produto();
            foreach(PedidoItem pedidoItem in ListaPedidoProdutoEntity)
            {
                produto = _productService.GetProductById(pedidoItem.Id);

                if (produto == null)
                {
                    throw new ArgumentException(String.Format("Produto {0} não encontrato", pedidoItem.Id));
                }

                pedidoItem.PrecoUnitario = produto.Preco;
            }

            pedidoEntity.DataPedido = DateTime.Now;
            pedidoEntity.StatusPedido = StatusPedido.Pendente;
            pedidoEntity.ValorTotal = ListaPedidoProdutoEntity.Sum(pp => pp.PrecoUnitario * pp.Quantidade);
            pedidoEntity.QuantidadeProdutos = ListaPedidoProdutoEntity.Sum(pp => pp.Quantidade);

            pedidoEntity = _orderService.AddNewOrder(pedidoEntity);
            ListaPedidoProdutoEntity.ForEach(pp => pp.IdPedido = pedidoEntity.Id);
            _orderItensService.AddNewOrderItens(ListaPedidoProdutoEntity);

            return Ok();
        }

        [Authorize]
        [HttpPost("RealizarPagamentoPorCartao")]
        public IActionResult RealizarPagamentoPorCartao()
        {
            return Ok();
        }

        [Authorize]
        [HttpPatch("AlterarStatusPedido")]
        public IActionResult AlterarStatusPedido()
        {
            return Ok();
        }
    }
}
