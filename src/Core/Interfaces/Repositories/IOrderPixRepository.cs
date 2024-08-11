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
        public PedidoPix InsertUpdateOrderCredCard(PedidoPix pedidoPix);
        public PedidoPix GetOrderCredCardById(int id);
        public PedidoPix GetOrderCredCardByOrder(int pedidoId);
        public void DeleteOrderCredCard(PedidoPix pedidoPix);
    }
}
