using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class StatusBD
    {
        string AM01, AM02, AMRC, AM03, AM04, AM05, AM06, AM07, AM08, AM09, AM10, AM11, AM12, AM46, AM47, AM52;

        public string AM521
        {
            get { return AM52; }
            set { AM52 = value; }
        }

        public string AM471
        {
            get { return AM47; }
            set { AM47 = value; }
        }

        public string AM461
        {
            get { return AM46; }
            set { AM46 = value; }
        }

        public string AM121
        {
            get { return AM12; }
            set { AM12 = value; }
        }

        public string AM111
        {
            get { return AM11; }
            set { AM11 = value; }
        }

        public string AM101
        {
            get { return AM10; }
            set { AM10 = value; }
        }

        public string AM091
        {
            get { return AM09; }
            set { AM09 = value; }
        }

        public string AM081
        {
            get { return AM08; }
            set { AM08 = value; }
        }

        public string AM071
        {
            get { return AM07; }
            set { AM07 = value; }
        }

        public string AM061
        {
            get { return AM06; }
            set { AM06 = value; }
        }

        public string AM051
        {
            get { return AM05; }
            set { AM05 = value; }
        }

        public string AM041
        {
            get { return AM04; }
            set { AM04 = value; }
        }

        public string AM031
        {
            get { return AM03; }
            set { AM03 = value; }
        }

        public string AMRC1
        {
            get { return AMRC; }
            set { AMRC = value; }
        }

        public string AM021
        {
            get { return AM02; }
            set { AM02 = value; }
        }

        public string AM011
        {
            get { return AM01; }
            set { AM01 = value; }
        }
        string idSolicitacoes_Ambulancias, IdOutroPaciente, idSolicitacoesPacientes, Cancelamento, DtHrCiencia, DtHrCienciaReg, DtHrChegadaOrigem, DtHrChegadaOrigemReg, DtHrSaidaOrigem, DtHrSaidaOrigemReg, DtHrChegadaDestino, DtHrChegadaDestinoReg, DtHrLiberacaoEquipe, DtHrLiberacaoEquipeReg, DtHrEquipePatio, DtHrEquipePatioReg, idAmbulanciaSol;
        string Origem, Destino;
        string Condutor, Equipe;

        int ContadorMaxdePacientes;



        public int ContadorMaxdePacientes1
        {
            get { return ContadorMaxdePacientes; }
            set { ContadorMaxdePacientes = value; }
        }
        DataTable dt;
        DataSet ds;

        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }

        public DataTable Dt
        {
            get { return dt; }
            set { dt = value; }
        }


        public string Equipe1
        {
            get { return Equipe; }
            set { Equipe = value; }
        }

        public string Condutor1
        {
            get { return Condutor; }
            set { Condutor = value; }
        }
        string idcancelados_pacientes, idPaciente, idSolicitacaoAM, MotivoCancelamento, DtHrCancelamento, ResposavelCancelamento, ObsCancelamento;

        public string ObsCancelamento1
        {
            get { return ObsCancelamento; }
            set { ObsCancelamento = value; }
        }

        public string ResposavelCancelamento1
        {
            get { return ResposavelCancelamento; }
            set { ResposavelCancelamento = value; }
        }

        public string DtHrCancelamento1
        {
            get { return DtHrCancelamento; }
            set { DtHrCancelamento = value; }
        }

        public string MotivoCancelamento1
        {
            get { return MotivoCancelamento; }
            set { MotivoCancelamento = value; }
        }

        public string IdSolicitacaoAM
        {
            get { return idSolicitacaoAM; }
            set { idSolicitacaoAM = value; }
        }

        public string IdPaciente
        {
            get { return idPaciente; }
            set { idPaciente = value; }
        }

        public string Destino1
        {
            get { return Destino; }
            set { Destino = value; }
        }

        public string Origem1
        {
            get { return Origem; }
            set { Origem = value; }
        }
        public string IdAmbulanciaSol
        {
            get { return idAmbulanciaSol; }
            set { idAmbulanciaSol = value; }
        }

        public string DtHrEquipePatioReg1
        {
            get { return DtHrEquipePatioReg; }
            set { DtHrEquipePatioReg = value; }
        }

        public string DtHrEquipePatio1
        {
            get { return DtHrEquipePatio; }
            set { DtHrEquipePatio = value; }
        }

        public string DtHrLiberacaoEquipeReg1
        {
            get { return DtHrLiberacaoEquipeReg; }
            set { DtHrLiberacaoEquipeReg = value; }
        }

        public string DtHrLiberacaoEquipe1
        {
            get { return DtHrLiberacaoEquipe; }
            set { DtHrLiberacaoEquipe = value; }
        }

        public string DtHrChegadaDestinoReg1
        {
            get { return DtHrChegadaDestinoReg; }
            set { DtHrChegadaDestinoReg = value; }
        }

        public string DtHrChegadaDestino1
        {
            get { return DtHrChegadaDestino; }
            set { DtHrChegadaDestino = value; }
        }

        public string DtHrSaidaOrigemReg1
        {
            get { return DtHrSaidaOrigemReg; }
            set { DtHrSaidaOrigemReg = value; }
        }

        public string DtHrSaidaOrigem1
        {
            get { return DtHrSaidaOrigem; }
            set { DtHrSaidaOrigem = value; }
        }

        public string DtHrChegadaOrigemReg1
        {
            get { return DtHrChegadaOrigemReg; }
            set { DtHrChegadaOrigemReg = value; }
        }

        public string DtHrChegadaOrigem1
        {
            get { return DtHrChegadaOrigem; }
            set { DtHrChegadaOrigem = value; }
        }

        public string DtHrCienciaReg1
        {
            get { return DtHrCienciaReg; }
            set { DtHrCienciaReg = value; }
        }

        public string DtHrCiencia1
        {
            get { return DtHrCiencia; }
            set { DtHrCiencia = value; }
        }

        public string Cancelamento1
        {
            get { return Cancelamento; }
            set { Cancelamento = value; }
        }

        public string IdSolicitacoesPacientes
        {
            get { return idSolicitacoesPacientes; }
            set { idSolicitacoesPacientes = value; }
        }

        public string IdOutroPaciente1
        {
            get { return IdOutroPaciente; }
            set { IdOutroPaciente = value; }
        }

        public string IdSolicitacoes_Ambulancias
        {
            get { return idSolicitacoes_Ambulancias; }
            set { idSolicitacoes_Ambulancias = value; }
        }
      

        public void puxarStatus()
        {

            //Consultar no banco de dados o status da ambulancia
            SqlConnection conexao = ConexaoSqlServer.GetConexao();


            try
            {
                string sqlQuery = "select * from ambulancia";



                SqlDataAdapter objComm = new SqlDataAdapter(sqlQuery, conexao);


                DataSet CD = new DataSet();
                objComm.Fill(CD);

                AM01 = CD.Tables[0].Rows[0][2].ToString();
                AM02 = CD.Tables[0].Rows[1][2].ToString();
                AMRC = CD.Tables[0].Rows[2][2].ToString();
                AM03 = CD.Tables[0].Rows[3][2].ToString();
                AM04 = CD.Tables[0].Rows[4][2].ToString();
                AM05 = CD.Tables[0].Rows[5][2].ToString();
                AM06 = CD.Tables[0].Rows[6][2].ToString();
                AM07 = CD.Tables[0].Rows[7][2].ToString();
                AM08 = CD.Tables[0].Rows[9][2].ToString();
                AM09 = CD.Tables[0].Rows[10][2].ToString();
                AM10 = CD.Tables[0].Rows[11][2].ToString();
                AM11 = CD.Tables[0].Rows[12][2].ToString();
                AM12 = CD.Tables[0].Rows[13][2].ToString();
                AM46 = CD.Tables[0].Rows[14][2].ToString();
                AM47 = CD.Tables[0].Rows[15][2].ToString();
                AM52 = CD.Tables[0].Rows[16][2].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

        }

        public void countparaMaxPacientes(string AMSelecionada)
        {
            //CONTA AS solicitacoes
            SqlConnection conexao = ConexaoSqlServer.GetConexao();


            string sqlQuery = "SELECT COUNT (idSolicitacoes_Ambulancias) FROM solicitacoes_ambulancias WHERE idAmbulanciaSol = '" + AMSelecionada + "' AND SolicitacaoConcluida='0'";
            try
            {

                using (SqlCommand objComm = new SqlCommand(sqlQuery, conexao))
                {
                    int count = (int)objComm.ExecuteScalar();
                    ContadorMaxdePacientes = count;
                }
            }
            finally
            {
                conexao.Close();

            }
        }

        public void atualizarStatusOcupado(string CodAM)
        {
            //atualizar a AM dependendo do status no banco
            SqlConnection conexao = ConexaoSqlServer.GetConexao();

            string sqlQuery = "SELECT * FROM solicitacoes_ambulancias WHERE idAmbulanciaSol = '" + CodAM + "' AND SolicitacaoConcluida='0'";

            try
            {

                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                SqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();

                while (MyReader2.Read())
                {
                    idSolicitacoes_Ambulancias = MyReader2["idSolicitacoes_Ambulancias"].ToString();
                    IdOutroPaciente = MyReader2["IdOutroPaciente"].ToString();
                    idSolicitacoesPacientes = MyReader2["idSolicitacoesPacientes"].ToString();
                    Cancelamento = MyReader2["Cancelamento"].ToString();
                    DtHrCiencia = MyReader2["DtHrCiencia"].ToString();
                    DtHrCienciaReg = MyReader2["DtHrCienciaReg"].ToString();
                    DtHrChegadaOrigem = MyReader2["DtHrChegadaOrigem"].ToString();
                    DtHrChegadaOrigemReg = MyReader2["DtHrChegadaOrigemReg"].ToString();
                    DtHrSaidaOrigem = MyReader2["DtHrSaidaOrigem"].ToString();
                    DtHrSaidaOrigemReg = MyReader2["DtHrSaidaOrigemReg"].ToString();
                    DtHrChegadaDestino = MyReader2["DtHrChegadaDestino"].ToString();
                    DtHrChegadaDestinoReg = MyReader2["DtHrChegadaDestinoReg"].ToString();
                    DtHrLiberacaoEquipe = MyReader2["DtHrLiberacaoEquipe"].ToString();
                    DtHrLiberacaoEquipeReg = MyReader2["DtHrLiberacaoEquipeReg"].ToString();
                    DtHrEquipePatio = MyReader2["DtHrEquipePatio"].ToString();
                    DtHrEquipePatioReg = MyReader2["DtHrEquipePatioReg"].ToString();
                    idAmbulanciaSol = MyReader2["idAmbulanciaSol"].ToString();

                }
            }
            finally
            {
                conexao.Close();

            }
        }
        public void atualizarStatusOcupadoPaciente()
        {
            dt = new DataTable();
            ds = new DataSet();
            //atualizar a AM dependendo do status no banco
            SqlConnection conexao = ConexaoSqlServer.GetConexao();

            string sqlQuery = "SELECT Origem, Destino FROM solicitacoes_paciente where idPaciente_Solicitacoes='" + idSolicitacoesPacientes + "'";

            try
            {

                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                SqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();

                while (MyReader2.Read())
                {

                    Origem = MyReader2["Origem"].ToString();
                    Destino = MyReader2["Destino"].ToString();

                    //    dt.Columns.Add("Cloum");
                    //   dt.Rows.Add(MyReader2["Paciente"].ToString());
                    //    ds.Tables.Add(dt);

                }
            }
            finally
            {
                conexao.Close();
            }
        }



        public void selectEquipeBD(string amcd)
        {
            SqlConnection conexao = ConexaoSqlServer.GetConexao();
            string sqlQuery = "SELECT TOP 1 * FROM equipe WHERE idAM = '" + amcd + "' ORDER BY idEquipe DESC";
            try
            {

                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                SqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();


                while (MyReader2.Read())
                {
                    Condutor = MyReader2["Condutor"].ToString();
                    Equipe = MyReader2["Enfermeiros"].ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();

            }

        }


    }
}
