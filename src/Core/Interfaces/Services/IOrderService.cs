using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IOrderService
    {
        Pedido AddNewOrder(Pedido pedido);
        Pedido UpdateOrder(Pedido pedido);
        Pedido? GetOrderById(int id);
        List<Pedido>? GetOrderByUsuario(int usuario);
        void UpdateOrderStatus(Pedido pedido);
    }
}
