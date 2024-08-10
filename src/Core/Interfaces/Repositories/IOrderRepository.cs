using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Pedido? GetOrderById(int orderId);
        List<Pedido>? GetOrderByUsuario(int usuario);
        Pedido InsertUpdateOrder(Pedido order);
    }
}
