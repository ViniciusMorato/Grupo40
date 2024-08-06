using Adapter.PostgreSQL.DataAccess;
using Core.Interfaces.Repositories;
using Core.Negocio.Model;
using Newtonsoft.Json;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Adapter.PostgreSQL.DataAccess
{
    public class PedidoDados : IOrderRepository
    {
        public void DeleteOrderById(Guid idOrder)
        {
            throw new NotImplementedException();
        }

        public PedidoModel GetOrderById(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PedidoModel> GetOrders()
        {
            throw new NotImplementedException();
        }

        public void InsertOrder(PedidoModel order)
        {
            throw new NotImplementedException();
        }

        public void TESTE()
        {
            using (var db = DataAcessFactory.SqlServerQueryFactory())
            {
                var query = db.Query("tb_teste");

                var accounts = query.Clone().Get();
                Console.WriteLine(JsonConvert.SerializeObject(accounts, Newtonsoft.Json.Formatting.Indented));

                var exists = query.Clone().Exists();
                Console.WriteLine(exists);
            }
        }

        public void UpdateOrder(PedidoModel order)
        {
            throw new NotImplementedException();
        }
    }
}
