using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IOrderCredCardrepository
    {
        public PedidoCartaoCredito InsertUpdateOrderCredCard(PedidoCartaoCredito pedidoCartaoCredito);
        public PedidoCartaoCredito GetOrderCredCardById(int id);
        public PedidoCartaoCredito GetOrderCredCardByOrder(int pedidoId);
        public void DeleteOrderCredCard(PedidoCartaoCredito pedidoCartaoCredito);
    }
}
