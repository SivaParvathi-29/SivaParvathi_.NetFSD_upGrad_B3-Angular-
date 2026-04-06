using System.Data;
using System.Data.SqlClient;

namespace WebApplication3.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString = string.Empty;

        public DapperContext(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("DefaultConnection")!;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
