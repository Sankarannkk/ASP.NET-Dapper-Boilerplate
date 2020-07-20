
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DapperDemo.Business.Interfaces;
namespace DapperDemo.Business
{
    public class ConnectionFactory : IConnectionFactory
    {
        public IDbConnection Create()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["DapperDemo"].ConnectionString);
        }
    }
}
