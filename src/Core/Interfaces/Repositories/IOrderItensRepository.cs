using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IOrderItensRepository
    {
        List<PedidoItem>? GetOrderItensByPedido(int pedido);
        bool CheckProducIsUsedByOrder(int produto);
        List<PedidoItem> InsertRangeOrderItem(List<PedidoItem> orderItens);
    }
}
