using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Negocios
{
    internal class PedidoNegocio
    {
        private readonly IOrderRepository _orderRepository;

        public PedidoNegocio(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
    }
}
