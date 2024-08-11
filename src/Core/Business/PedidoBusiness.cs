using Core.Entities;
using Core.Enums;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class PedidoBusiness : IOrderService
    {
        private readonly IUserService _userService;
        private readonly IUserAddressService _userAddressService;
        private readonly IProductService _productService;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItensRepository _orderItensRepository;

        public PedidoBusiness(IUserService userService, IUserAddressService userAddressService, IProductService productService, IOrderRepository orderRepository, IOrderItensRepository orderItensRepository)
        {
            _userService = userService;
            _userAddressService = userAddressService;
            _productService = productService;
            _orderRepository = orderRepository;
            _orderItensRepository = orderItensRepository;
        }

        public Pedido AddNewOrder(Pedido pedido)
        {
            if (_userService.GetUserById(pedido.Usuario) == null)
            {
                throw new ArgumentException("Usuario não encontrado!");
            }

            if (_userAddressService.GetUserAddressByUserId(pedido.UsuarioEndereco) == null)
            {
                throw new ArgumentException("Usuario não encontrado!");
            }

            Produto? produto = new Produto();
            foreach (PedidoItem pedidoItem in pedido.PedidoItens)
            {
                produto = _productService.GetProductById(pedidoItem.ProdutoId);

                if (produto == null)
                {
                    throw new ArgumentException(String.Format("Produto {0} não encontrado", pedidoItem.ProdutoId));
                }

                pedidoItem.PrecoUnitario = produto.Preco;
            }

            pedido.DataPedido = DateTime.UtcNow;
            pedido.StatusPedido = EnumStatusPedido.Pendente;
            pedido.ValorTotal = pedido.PedidoItens.Sum(pp => pp.PrecoUnitario * pp.Quantidade);
            pedido.QuantidadeProdutos = pedido.PedidoItens.Sum(pp => pp.Quantidade);

            pedido = _orderRepository.InsertUpdateOrder(pedido);

            return pedido;
        }

        public Pedido? GetOrderById(int id)
        {
            Pedido pedido = _orderRepository.GetOrderById(id);
            if(pedido == null)
            {
                throw new ArgumentException("Pedido não encontrado");
            }
            pedido.PedidoItens = _orderItensRepository.GetOrderItensByPedido(pedido.Id);
            return pedido;
        }

        public List<Pedido>? GetOrderByUsuario(int usuario)
        {
            return _orderRepository.GetOrderByUsuario(usuario);
        }

        public Pedido UpdateOrder(Pedido pedido)
        {
            return _orderRepository.InsertUpdateOrder(pedido);
        }

        public Pedido UpdateOrderStatus(int pedidoId, EnumStatusPedido statusPedido)
        {
            Pedido? pedido = this.GetOrderById(pedidoId);
            if(pedido == null) {
                throw new ArgumentException("");
            }

            //Validar status
            pedido.StatusPedido = statusPedido;

            this.UpdateOrder(pedido);

            return pedido;
        }
    }
}
