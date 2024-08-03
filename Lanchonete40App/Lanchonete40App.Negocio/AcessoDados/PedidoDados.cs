using Newtonsoft.Json;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace Lanchonete40App.Negocio.AcessoDados
{
    public class PedidoDados
    {
        public void TESTE()
        {
            using (var db = DataAcessFactory.SqlServerQueryFactory())
            {
                var query = db.Query("tb_teste");

                var accounts = query.Clone().Get();
                Console.WriteLine(JsonConvert.SerializeObject(accounts, Formatting.Indented));

                var exists = query.Clone().Exists();
                Console.WriteLine(exists);
            }
        }
    }
}
