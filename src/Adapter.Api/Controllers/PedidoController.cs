using Adapter.Api.DTO;
using AutoMapper;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public PedidoController(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [Authorize]
        [HttpGet("RetornarPedido")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReturnPedidoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult RetornarPedido(int pedidoId)
        {
            try
            {
                Pedido pedido = _orderService.GetOrderById(pedidoId);

                if (pedido == null)
                {
                    throw new ArgumentException("O um pedido não foi encontrado!");
                }

                return Ok(_mapper.Map<ReturnPedidoDto>(pedido));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("RetornarPedidosCliente")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReturnPedidoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult RetornarPedidosCliente(int cliente)
        {
            try
            {
                List<Pedido> pedidos = _orderService.GetOrderByUsuario(cliente);

                if(pedidos == null || pedidos.Count == 0)
                {
                    throw new ArgumentException("Nem um pedido foi encontrado!");
                }

                return Ok(_mapper.Map<List<ReturnPedidoDto>>(pedidos));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("RealizarPedido")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReturnPedidoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult RealizarPedido([FromBody] AddPedidoDTO pedido)
        {
            try
            {
                Pedido pedidoEntity = _mapper.Map<Pedido>(pedido);

                pedidoEntity = _orderService.AddNewOrder(pedidoEntity);

                return Ok(_mapper.Map<ReturnPedidoDto>(pedidoEntity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("RealizarPagamentoPorCartao")]
        public IActionResult RealizarPagamentoPorCartao()
        {
            return Ok();
        }

        [Authorize]
        [HttpPatch("AlterarStatusPedido")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReturnPedidoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult AlterarStatusPedido([Required]int pedidoId, [Required]EnumStatusPedido statusPedido)
        {
            try
            {
                Pedido pedido = _orderService.UpdateOrderStatus(pedidoId, statusPedido);

                if (pedido == null)
                {
                    throw new ArgumentException("O um pedido não foi encontrado!");
                }

                return Ok(_mapper.Map<ReturnPedidoDto>(pedido));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
