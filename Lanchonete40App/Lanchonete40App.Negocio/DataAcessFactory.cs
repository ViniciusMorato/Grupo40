using System;
using System.Collections.Generic;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Data.SQLite;
using static SqlKata.Expressions;
using System.IO;
using Npgsql;
using System.Data.Entity;

namespace Lanchonete40App.Negocio
{
    public class DataAcessFactory
    {
        public static QueryFactory SqlServerQueryFactory()
        {
            var compiler = new PostgresCompiler();
            string connectionString = @"Host=localhost;
            Port=5432;
            Database=MinhaLanchonete;
            User Id=postgres;
            Password=129845;";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);

            var db = new QueryFactory(connection, compiler);

            db.Logger = result =>
            {
                Console.WriteLine(result.ToString());
            };

            return db;
        }
    }
}
