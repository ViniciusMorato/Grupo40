using Core.Entities;
using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Interfaces.Services
{
    public interface IOrderService
    {
        Pedido AddNewOrder(Pedido pedido);
        Pedido UpdateOrder(Pedido pedido);
        Pedido? GetOrderById(int id);
        List<Pedido>? GetOrderByUsuario(int usuario);
        Pedido UpdateOrderStatus(int pedido, EnumStatusPedido statusPedido);
    }
}
