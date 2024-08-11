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
    public class PedidoItemBusiness(IOrderItensRepository OrderItensRepository) : IOrderItensService
    {

        public PedidoItem AddNewOrderItem(PedidoItem pedidoItem)
        {
            throw new NotImplementedException();
        }

        public PedidoItem AddNewOrderItens(List<PedidoItem> pedidoItem)
        {
            throw new NotImplementedException();
        }

        public PedidoItem GetOrderItemById(int id)
        {
            throw new NotImplementedException();
        }

        public List<PedidoItem> GetOrderItensByOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public PedidoItem UpdateOrderItem(PedidoItem pedidoItem)
        {
            throw new NotImplementedException();
        }
    }
}
