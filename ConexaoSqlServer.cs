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
            string strCon = "data source = srv-mssql-01;initial catalog = DAHUE;user id = dahue; password = DT1_D@huE_1438_DtI";
          // string strCon = "data source = dti-webhmg-01;initial catalog = DAHUE;user id = dahue; password = DT1_HmG_2005_DtI";
            //string strCon = "data source = .\\SQLEXPRESS;initial catalog = DAHUE;user id = sa; password = 123456";
            
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
