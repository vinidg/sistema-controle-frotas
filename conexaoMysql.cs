using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication2
{
    class conexaoMysql
    {
        public static MySqlConnection GetConexao()
        {
            string conexao = "SERVER=localhost; Port=3306; DATABASE=dahue; UID=root; PASSWORD=dahue123;";
            MySqlConnection objConexao = new MySqlConnection(conexao);
            objConexao.Open();
            return objConexao;
        }




    }
}






