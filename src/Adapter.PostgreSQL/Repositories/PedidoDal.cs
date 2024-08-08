using Adapter.DataAccessLayer.Util;
using Core.Interfaces.Repositories;
using Core.Entities;
using Newtonsoft.Json;
using SqlKata.Execution;

namespace Adapter.DataAccessLayer.Dal
{
    public class PedidoDal : IOrderRepository
    {
        private readonly QueryFactory _db;

        public PedidoDal(PostgreSqlContext postgreSqlContext)
        {
            _db = postgreSqlContext.CreateQueryFactory();
        }

        public void DeleteOrderById(Guid idOrder)
        {
            throw new NotImplementedException();
        }

        public Pedido GetOrderById(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> GetOrders()
        {
            throw new NotImplementedException();
        }

        public void InsertOrder(Pedido order)
        {
            throw new NotImplementedException();
        }

        public void TESTE()
        {
            var query = _db.Query("tb_teste");

            var accounts = query.Clone().Get();
            Console.WriteLine(JsonConvert.SerializeObject(accounts, Newtonsoft.Json.Formatting.Indented));

            var exists = query.Clone().Exists();
            Console.WriteLine(exists);
        }

        public void UpdateOrder(Pedido order)
        {
            throw new NotImplementedException();
        }
    }
}