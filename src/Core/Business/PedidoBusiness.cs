﻿using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class PedidoBusiness(IOrderService orderRepository) : IOrderService
    {
        public Pedido AddNewOrder(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public Pedido? GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido>? GetOrderByUsuario(int usuario)
        {
            return orderRepository.GetOrderByUsuario(usuario);
        }

        public Pedido UpdateOrder(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderStatus(Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}
