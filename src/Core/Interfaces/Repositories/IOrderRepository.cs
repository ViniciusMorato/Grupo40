using Core.Negocio.Model;

namespace Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<PedidoModel> GetOrders();
        PedidoModel GetOrderById(Guid orderId);
        void InsertOrder(PedidoModel order);
        void UpdateOrder(PedidoModel order);
        void DeleteOrderById(Guid idOrder);
    }
}
