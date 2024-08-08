using Adapter.DataAccessLayer.Context;
using Core.Interfaces.Repositories;
using Core.Entities;

namespace Adapter.DataAccessLayer.Repositories
{
    public class PedidoDal : IOrderRepository
    {
        private readonly PostgreSqlContext _context;

        public PedidoDal(PostgreSqlContext context)
        {
            _context = context;
        }


        public void DeleteOrderById(Guid idOrder)
        {
            throw new NotImplementedException();
        }

        public Pedido GetOrderById(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> GetOrders()
        {
            throw new NotImplementedException();
        }

        public void InsertOrder(Pedido order)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Pedido order)
        {
            throw new NotImplementedException();
        }
    }
}