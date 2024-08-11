using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IOrderPixService
    {
        public PedidoPix AddNewOrderCredCard(PedidoPix pedidoPix);
        public PedidoPix UpdateOrderCredCard(PedidoPix pedidoPix);
        public void DeleteOrderCredCard(PedidoPix pedidoPix);
        public PedidoPix GetOrderCredCardById(int id);
        public PedidoPix GetOrderCredCardByOrder(int pedidoId);
        public string GenPixCode(decimal valor);
    }
}
