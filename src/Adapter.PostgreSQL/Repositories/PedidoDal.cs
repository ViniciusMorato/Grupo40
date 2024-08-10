using Adapter.PostgreSQL.Context;
using Core.Interfaces.Repositories;
using Core.Entities;

namespace Adapter.PostgreSQL.Repositories
{
    public class PedidoDal : IOrderRepository
    {
        private readonly PostgreSqlContext _context;

        public PedidoDal(PostgreSqlContext context)
        {
            _context = context;
        }

        public List<Pedido> GetOrderByUsuario(int usuario)
        {
            return _context.Pedido.Where(p => p.Usuario == usuario).ToList();
        }

        public Pedido? GetOrderById(int orderId)
        {
            return _context.Pedido.FirstOrDefault(p => p.Id == orderId);
        }

        public Pedido InsertUpdateOrder(Pedido order)
        {
            try
            {
                _context.Pedido.Add(order);
                _context.SaveChanges();

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}