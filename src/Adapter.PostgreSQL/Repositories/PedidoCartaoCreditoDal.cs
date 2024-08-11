using Adapter.PostgreSQL.Context;
using Core.Entities;
using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.PostgreSQL.Repositories
{
    public class PedidoCartaoCreditoDal : IOrderCredCardrepository
    {
        private readonly PostgreSqlContext _context;

        public PedidoCartaoCreditoDal(PostgreSqlContext context)
        {
            _context = context;
        }

        public void DeleteOrderCredCard(PedidoCartaoCredito pedidoCartaoCredito)
        {
            _context.PedidoCartaoCredito.Remove(pedidoCartaoCredito);
            _context.SaveChanges();
        }

        public PedidoCartaoCredito GetOrderCredCardById(int id)
        {
            return _context.PedidoCartaoCredito.FirstOrDefault(pcc => pcc.Id == id);
        }

        public PedidoCartaoCredito GetOrderCredCardByOrder(int pedidoId)
        {
            return _context.PedidoCartaoCredito.FirstOrDefault(pcc => pcc.PedidoId == pedidoId);
        }

        public PedidoCartaoCredito InsertUpdateOrderCredCard(PedidoCartaoCredito pedidoCartaoCredito)
        {
            if(pedidoCartaoCredito.Id == 0)
            {
                _context.PedidoCartaoCredito.Add(pedidoCartaoCredito);
            }
            _context.SaveChanges();

            return pedidoCartaoCredito;
        }
    }
}
