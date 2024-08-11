using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IOrderCredCardService
    {
        public PedidoCartaoCredito AddNewOrderCredCard(PedidoCartaoCredito pedidoCartaoCredito);
        public PedidoCartaoCredito UpdateOrderCredCard(PedidoCartaoCredito pedidoCartaoCredito);
        public void DeleteOrderCredCard(PedidoCartaoCredito pedidoCartaoCredito);
        public PedidoCartaoCredito GetOrderCredCardById(int id);
        public PedidoCartaoCredito GetOrderCredCardByOrder(int pedidoId);
    }
}
