using SqlKata.Compilers;
using SqlKata.Execution;
using Npgsql;
using Microsoft.AspNetCore.Builder;

namespace Adapter.DataAcessLayer.Util
{
    public class DataAcessFactory
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
