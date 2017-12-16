using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Blog
{
    public static class ConnectionFactory
    {
        public static IDbConnection CriaConexao()
        {
            var stringConexao = ConfigurationManager.ConnectionStrings["blog"];
            var conexao = new SqlConnection()
            {
                ConnectionString = stringConexao.ConnectionString,
            };
            conexao.Open();
            return conexao;
        }
    }
}
