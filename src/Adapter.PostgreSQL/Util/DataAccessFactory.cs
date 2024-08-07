using SqlKata.Compilers;
using SqlKata.Execution;
using Npgsql;
using Microsoft.AspNetCore.Builder;

namespace Adapter.DataAccessLayer.Util
{
    public class DataAccessFactory
    {
        public static QueryFactory SqlServerQueryFactory()
        {
            PostgresCompiler compiler = new PostgresCompiler();
            NpgsqlConnection connection = new NpgsqlConnection(WebApplication.CreateBuilder().Configuration.GetSection("AppSettings:connectionString").Value.ToString());

            QueryFactory db = new QueryFactory(connection, compiler);

            return db;
        }
    }
}
