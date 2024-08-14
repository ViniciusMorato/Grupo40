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
        public PedidoPix AddNewOrderPix(int pedidoId);
        public PedidoPix UpdateOrderPix(PedidoPix pedidoPix);
        public void DeleteOrderPix(PedidoPix pedidoPix);
        public PedidoPix GetOrderPixById(int id);
        public PedidoPix GetOrderPixByOrder(int pedidoId);
    }
}
