using Microsoft.Data.SqlClient;
using System.Data;

namespace SQ_Evaluacion_API
{
    public class DapperDbContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public DapperDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = this.configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
