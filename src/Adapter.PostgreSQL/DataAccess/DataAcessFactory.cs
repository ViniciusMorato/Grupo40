using SqlKata.Compilers;
using SqlKata.Execution;
using Npgsql;
using Microsoft.AspNetCore.Builder;

namespace Adapter.PostgreSQL.DataAccess
{
    public class DataAcessFactory
    {
        public static QueryFactory SqlServerQueryFactory()
        {
            var compiler = new PostgresCompiler();
            NpgsqlConnection connection = new NpgsqlConnection(WebApplication.CreateBuilder().Configuration.GetSection("AppSettings:connectionString").Value.ToString());

            var db = new QueryFactory(connection, compiler);

            db.Logger = result =>
            {
                Console.WriteLine(result.ToString());
            };

            return db;
        }
    }
}
