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
    public class PedidoPixDal : IOrderPixRepository
    {
        private readonly PostgreSqlContext _context;

        public PedidoPixDal(PostgreSqlContext context)
        {
            _context = context;
        }

        public void DeleteOrderPix(PedidoPix pedidoPix)
        {
            _context.PedidoPix.Remove(pedidoPix);
        }

        public PedidoPix GetOrderPixById(int id)
        {
            return _context.PedidoPix.FirstOrDefault(pp => pp.Id == id);
        }

        public PedidoPix GetOrderPixByOrder(int pedidoId)
        {
            return _context.PedidoPix.FirstOrDefault(pp => pp.PedidoId == pedidoId);
        }

        public PedidoPix InsertUpdateOrderPix(PedidoPix pedidoPix)
        {
            if(pedidoPix.Id == 0)
            {
                _context.PedidoPix.Add(pedidoPix);
            }
            _context.SaveChanges();

            return pedidoPix;
        }
    }
}
