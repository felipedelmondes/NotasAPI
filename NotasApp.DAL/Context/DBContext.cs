using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace NotasApp.DAL.Context
{
    public class DBContext
    {
        private readonly IConfiguration _configuration;

        private readonly string connectionStrig;

        public DBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            this.connectionStrig = this._configuration.GetConnectionString("PostgresDb");
        }

        public IDbConnection CreateConnection() => new NpgsqlConnection(connectionStrig);
    }
    
}

