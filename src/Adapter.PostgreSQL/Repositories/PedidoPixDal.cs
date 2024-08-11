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

        public void DeleteOrderCredCard(PedidoPix pedidoPix)
        {
            _context.PedidoPix.Remove(pedidoPix);
        }

        public PedidoPix GetOrderCredCardById(int id)
        {
            return _context.PedidoPix.FirstOrDefault(pp => pp.Id == id);
        }

        public PedidoPix GetOrderCredCardByOrder(int pedidoId)
        {
            return _context.PedidoPix.FirstOrDefault(pp => pp.PedidoId == pedidoId);
        }

        public PedidoPix InsertUpdateOrderCredCard(PedidoPix pedidoPix)
        {
            if(pedidoPix.Id ==  pedidoPix.PedidoId)
            {
                _context.PedidoPix.Add(pedidoPix);
            }
            _context.SaveChanges();

            return pedidoPix;
        }
    }
}
