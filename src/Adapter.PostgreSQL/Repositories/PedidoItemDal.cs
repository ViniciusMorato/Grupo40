using Adapter.PostgreSQL.Context;
using Core.Entities;
using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.PostgreSQL.Repositories
{
    public class PedidoItemDal : IOrderItensRepository
    {
        private readonly PostgreSqlContext _context;

        public PedidoItemDal(PostgreSqlContext context)
        {
            _context = context;
        }

        public bool CheckProducIsUsedByOrder(int produto)
        {
            return _context.PedidoItem.FirstOrDefault(pi => pi.ProdutoId == produto) != null;
        }

        public List<PedidoItem>? GetOrderItensByPedido(int pedido)
        {
            return _context.PedidoItem.Where(pi => pi.PedidoId == pedido).ToList();
        }

        public List<PedidoItem> InsertRangeOrderItem(List<PedidoItem> orderItens)
        {
            _context.PedidoItem.AddRange(orderItens);
            _context.SaveChanges();
            return orderItens;
        }
    }
}
