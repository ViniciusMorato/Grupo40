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
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItensRepository _orderItensRepository;

        public PedidoBusiness(IUserService userService, IUserAddressRepository userAddressRepository, IOrderRepository orderRepository, IOrderItensRepository orderItensRepository, IProductRepository productRepository)
        {
            _userService = userService;
            _userAddressRepository = userAddressRepository;
            _orderRepository = orderRepository;
            _orderItensRepository = orderItensRepository;
            _productRepository = productRepository;
        }

        public Pedido AddNewOrder(Pedido pedido)
        {
            if (_userService.GetUserById(pedido.Usuario) == null)
            {
                throw new ArgumentException("Usuario não encontrado!");
            }

            if (_userAddressRepository.GetUserAddressByUser(pedido.UsuarioEndereco) == null)
            {
                throw new ArgumentException("Usuario não encontrado!");
            }

            if(pedido.FormaPagamento == EnumFormaPagamento.Dinheiro || pedido.FormaPagamento == EnumFormaPagamento.Pix || pedido.FormaPagamento == EnumFormaPagamento.CartaoCredito || pedido.FormaPagamento == EnumFormaPagamento.CartaoDebito)
            {
                Produto? produto = new Produto();
                foreach (PedidoItem pedidoItem in pedido.PedidoItens)
                {
                    produto = _productRepository.GetProductById(pedidoItem.ProdutoId);

                    if (produto == null)
                    {
                        throw new ArgumentException(String.Format("Produto {0} não encontrado", pedidoItem.ProdutoId));
                    }

                    if(produto.Estoque - pedidoItem.Quantidade < 0)
                    {
                        throw new ArgumentException("Produto sem estoque");
                    }

                    produto.Estoque -= pedidoItem.Quantidade;

                    _productRepository.InsertUpdateProduct(produto);

                    pedidoItem.PrecoUnitario = produto.Preco;
                }

                pedido.DataPedido = DateTime.UtcNow;
                pedido.StatusPedido = EnumStatusPedido.Pendente;
                pedido.ValorTotal = pedido.PedidoItens.Sum(pp => pp.PrecoUnitario * pp.Quantidade) + pedido.ValorEntrega;
                pedido.QuantidadeProdutos = pedido.PedidoItens.Sum(pp => pp.Quantidade);

                pedido = _orderRepository.InsertUpdateOrder(pedido);

                return pedido;
            }
            else
            {
                throw new ArgumentException("Forma de pagamento não é valida!");
            }
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
                throw new ArgumentException("Pedido não encontrado");
            }

            if(pedido.StatusPedido == statusPedido)
            {
                throw new ArgumentException("Pedido já tem esse status");
            }

            if((statusPedido == EnumStatusPedido.Cancelado && pedido.StatusPedido == EnumStatusPedido.Processando)
                || (statusPedido == EnumStatusPedido.Processando && (pedido.StatusPedido == EnumStatusPedido.Cancelado || pedido.StatusPedido == EnumStatusPedido.Concluído))
                || (statusPedido == EnumStatusPedido.Concluído && pedido.StatusPedido == EnumStatusPedido.Cancelado)
                || (statusPedido == EnumStatusPedido.Pendente && (pedido.StatusPedido == EnumStatusPedido.Processando || pedido.StatusPedido == EnumStatusPedido.Concluído || pedido.StatusPedido == EnumStatusPedido.Cancelado)))
            {
                throw new ArgumentException("O status do pedido não pode ser alterado");
            }

            //Validar status
            pedido.StatusPedido = statusPedido;

            this.UpdateOrder(pedido);

            return pedido;
        }
    }
}
