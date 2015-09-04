using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class ConexaoSqlServer
    {
        public static SqlConnection GetConexao()
        {
            string strCon = "data source = XXX;initial catalog = XXX;user id = XXX; password = XXX";
            
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
