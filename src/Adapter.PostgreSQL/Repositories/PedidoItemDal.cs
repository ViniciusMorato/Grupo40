using Adapter.PostgreSQL.Context;
using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.PostgreSQL.Repositories
{
    public class PedidoItemDal : IOrderItensRepository
    {
        private readonly PostgreSqlContext _context;

        public PedidoItemDal(PostgreSqlContext context)
        {
            _context = context;
        }
    }
}
