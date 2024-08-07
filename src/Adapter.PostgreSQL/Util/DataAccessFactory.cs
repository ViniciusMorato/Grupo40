using SqlKata.Compilers;
using SqlKata.Execution;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace Adapter.DataAccessLayer.Util
{
    public class DataAccessFactory
    {
        private readonly IConfiguration _configuration;

        public DataAccessFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public QueryFactory CreateQueryFactory()
        {
            var connectionString = _configuration.GetSection("AppSettings:connectionString").Value;
            var connection = new NpgsqlConnection(connectionString);
            PostgresCompiler compiler = new PostgresCompiler();
            QueryFactory db = new QueryFactory(connection, compiler);

            return db;
        }
    }
}