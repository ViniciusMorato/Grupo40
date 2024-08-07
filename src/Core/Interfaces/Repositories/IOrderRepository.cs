using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Pedido> GetOrders();
        Pedido GetOrderById(Guid orderId);
        void InsertOrder(Pedido order);
        void UpdateOrder(Pedido order);
        void DeleteOrderById(Guid idOrder);
    }
}
