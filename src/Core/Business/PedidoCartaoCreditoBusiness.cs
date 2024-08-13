using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class PedidoCartaoCreditoBusiness : IOrderCredCardService
    {
        private readonly IOrderCredCardrepository _orderCredCardrepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICredCardRepository _credCardRepository;

        public PedidoCartaoCreditoBusiness(IOrderCredCardrepository orderCredCardrepository, IOrderRepository orderRepository, ICredCardRepository credCardRepository)
        {
            _orderCredCardrepository = orderCredCardrepository;
            _orderRepository = orderRepository;
            _credCardRepository = credCardRepository;
        }

        public PedidoCartaoCredito AddNewOrderCredCard(int pedidoId, int clienteCartaoCreditoId)
        {
            Pedido pedido = _orderRepository.GetOrderById(pedidoId);
            if (pedido == null) {
                throw new ArgumentException("Pedido não encontrado!");
            }

            CartaoCredito cartaoCredito = _credCardRepository.GetCredCardById(clienteCartaoCreditoId);
            if (cartaoCredito == null) {
                throw new ArgumentException("Cartão de credito não encontrado!");
            }

            //RealizaPagamento

            PedidoCartaoCredito pedidoCartaoCredito = new PedidoCartaoCredito() { 
                PedidoId = pedidoId,
                CartaoCreditoId = clienteCartaoCreditoId
            };

            pedidoCartaoCredito = _orderCredCardrepository.InsertUpdateOrderCredCard(pedidoCartaoCredito);

            return pedidoCartaoCredito;
        }

        public void DeleteOrderCredCard(PedidoCartaoCredito pedidoCartaoCredito)
        {
            throw new NotImplementedException();
        }

        public PedidoCartaoCredito GetOrderCredCardById(int id)
        {
            throw new NotImplementedException();
        }

        public PedidoCartaoCredito GetOrderCredCardByOrder(int pedidoId)
        {
            throw new NotImplementedException();
        }

        public PedidoCartaoCredito UpdateOrderCredCard(PedidoCartaoCredito pedidoCartaoCredito)
        {
            throw new NotImplementedException();
        }
    }
}
