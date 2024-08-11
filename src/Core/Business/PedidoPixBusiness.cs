using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class PedidoPixBusiness(IOrderPixRepository orderPixRepository) : IOrderPixService
    {
        public PedidoPix AddNewOrderCredCard(PedidoPix pedidoPix)
        {
            pedidoPix.CodigoPix = this.GenPixCode(pedidoPix.Pedido.ValorTotal);

            pedidoPix = orderPixRepository.InsertUpdateOrderCredCard(pedidoPix);

            return pedidoPix;
        }

        public void DeleteOrderCredCard(PedidoPix pedidoPix)
        {
            orderPixRepository.DeleteOrderCredCard(pedidoPix);
        }

        public string GenPixCode(decimal valor)
        {
            throw new NotImplementedException();
        }

        public PedidoPix GetOrderCredCardById(int id)
        {
            PedidoPix pedidoPix = orderPixRepository.GetOrderCredCardById(id);
            
            if(pedidoPix == null)
            {
                throw new ArgumentException("Pix do pedido não encontrado");
            }

            return pedidoPix;   
        }

        public PedidoPix GetOrderCredCardByOrder(int pedidoId)
        {
            PedidoPix pedidoPix = orderPixRepository.GetOrderCredCardByOrder(pedidoId);

            if (pedidoPix == null)
            {
                throw new ArgumentException("Pix do pedido não encontrado");
            }

            return pedidoPix;
        }

        public PedidoPix UpdateOrderCredCard(PedidoPix pedidoPix)
        {
            throw new NotImplementedException();
        }
    }
}
