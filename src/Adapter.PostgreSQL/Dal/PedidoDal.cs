using Adapter.DataAccessLayer.Util;
using Core.Interfaces.Repositories;
using Core.Negocio.Model;
using Newtonsoft.Json;
using SqlKata.Execution;

namespace Adapter.DataAccessLayer.Dal
{
    public class PedidoDal : IOrderRepository
    {
        private readonly QueryFactory _db;

        public PedidoDal(DataAccessFactory dataAccessFactory)
        {
            _db = dataAccessFactory.CreateQueryFactory();
        }

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
            var query = _db.Query("tb_teste");

            var accounts = query.Clone().Get();
            Console.WriteLine(JsonConvert.SerializeObject(accounts, Newtonsoft.Json.Formatting.Indented));

            var exists = query.Clone().Exists();
            Console.WriteLine(exists);
        }

        public void UpdateOrder(PedidoModel order)
        {
            throw new NotImplementedException();
        }
    }
}