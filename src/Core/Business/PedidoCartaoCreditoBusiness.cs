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
    public class PedidoCartaoCreditoBusiness(IOrderCredCardrepository orderCredCardrepository) : IOrderCredCardService
    {
        public PedidoCartaoCredito AddNewOrderCredCard(PedidoCartaoCredito pedidoCartaoCredito)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrderCredCard(PedidoCartaoCredito pedidoCartaoCredito)
        {
            throw new NotImplementedException();
        }

        public PedidoCartaoCredito GetOrderCredCardById(int id)
        {
            throw new NotImplementedException();
        }

        public PedidoCartaoCredito GetOrderCredCardByOrder(int pedidoId)
        {
            throw new NotImplementedException();
        }

        public PedidoCartaoCredito UpdateOrderCredCard(PedidoCartaoCredito pedidoCartaoCredito)
        {
            throw new NotImplementedException();
        }
    }
}
