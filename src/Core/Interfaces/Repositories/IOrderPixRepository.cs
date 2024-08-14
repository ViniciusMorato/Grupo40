using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IOrderPixRepository
    {
        public PedidoPix InsertUpdateOrderPix(PedidoPix pedidoPix);
        public PedidoPix GetOrderPixById(int id);
        public PedidoPix GetOrderPixByOrder(int pedidoId);
        public void DeleteOrderPix(PedidoPix pedidoPix);
    }
}
