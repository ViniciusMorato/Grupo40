using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IOrderItensService
    {
        PedidoItem AddNewOrderItem(PedidoItem pedidoItem);
        PedidoItem AddNewOrderItens(List<PedidoItem> pedidoItem);
        PedidoItem UpdateOrderItem(PedidoItem pedidoItem);
        PedidoItem GetOrderItemById(int id);
        List<PedidoItem> GetOrderItensByOrder(int orderId);
    }
}
