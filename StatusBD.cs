using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using db_transporte_sanitario;

namespace WindowsFormsApplication2
{
    class StatusBD
    {
        
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
        string idPaciente, idSolicitacaoAM, MotivoCancelamento, DtHrCancelamento, ResposavelCancelamento, ObsCancelamento;

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
