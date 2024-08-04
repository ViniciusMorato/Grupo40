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
using System.Configuration;
using Microsoft.AspNetCore.Builder;
using Lanchonete40App.Negocio.Negocios;
using Microsoft.Extensions.DependencyInjection;

namespace Lanchonete40App.Negocio
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
