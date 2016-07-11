using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{

    public partial class Status : Form
    {
        DateTime now = DateTime.Now;
        string cdAM, txtHoras, txtAlteradores, hora, alterador, sqlQuery, msg, resposavel = System.Environment.UserName;
        string id, codEquipe, SolicitaAM;
        string NomeAM, idSolicitacoesPacientes;
        StatusBD d = new StatusBD();

        public Status(string Cod)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            BtnAddPaciente.Location = new Point(899, 327);
            BtnAddPaciente.Size = new Size(306, 214);
            label7.Visible = false;
            label8.Visible = false;
            txtDtHorasBloqueio.Text = now.ToString();
            cdAM = Cod;

            selectEquipeBD();
            statusJanela();
            selectHorarios();
            selectHorarioVerificacao();
            NomeAM = label1.Text;
        }
        public string NomeAM1
        {

            get { return NomeAM; }
            set { NomeAM = value; }
        }

        private void BtnTroca_Click(object sender, EventArgs e)
        {

            Paineltrocar.Visible = true;

        }
        /////////////////////////////////////////////////////////////////////////////TROCAR EQUIPE////////////////////////////////////////////////////////////////////////////////////////
        private void BtTrocar_Click(object sender, EventArgs e)
        {



            DateTime now = DateTime.Now;


            SqlConnection conexao = ConexaoSqlServer.GetConexao();

            string sqlQuery = "INSERT INTO equipe (Condutor, Enfermeiros, DtEscala, idAM ) VALUES ('" + txtMoto.Text + "','" + txtEquipe.Text + "', '" + now.ToString() + "','" + cdAM + "')";


            try
            {

                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);


                SqlDataReader MyReader2;



                MyReader2 = objComm.ExecuteReader();

                MessageBox.Show("Equipe trocada !");
            }
            finally
            {
                conexao.Close();
            }
            listView1.Items.Clear();
            Paineltrocar.Visible = false;
            selectEquipeBD();
            EquipeAtribuiNaOcupada();
        }
        private void EquipeAtribuiNaOcupada()
        {
            if (this.Text == "Ocupada")
            {
                SqlConnection conexao1 = ConexaoSqlServer.GetConexao();

                string sqlQuery2 = "INSERT INTO equipe_solam (idequipe, idSolAM) VALUES ('" + codEquipe + "','" + SolicitaAM + "')";


                try
                {

                    SqlCommand objComm1 = new SqlCommand(sqlQuery2, conexao1);
                    SqlDataReader MyReader1;
                    MyReader1 = objComm1.ExecuteReader();

                    MessageBox.Show("Equipe trocada !");

                }

                finally
                {
                    conexao1.Close();
                }
            }
        }
        ///////////////////////////////////////////////////////SELECT EQUIPE////////////////////////////////////////////////////////////////////////////////////////
        private void selectEquipeBD()
        {
            SqlConnection conexao = ConexaoSqlServer.GetConexao();
            string sqlQuery = "SELECT TOP 1 * FROM equipe WHERE idAM = '" + cdAM + "' ORDER BY idEquipe DESC ";
            try
            {

                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                SqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();


                while (MyReader2.Read())
                {
                    codEquipe = MyReader2["idEquipe"].ToString();

                    ListViewItem saturno = new ListViewItem(MyReader2["Condutor"].ToString());

                    saturno.SubItems.Add(MyReader2["Enfermeiros"].ToString());
                    listView1.Items.Add(saturno);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Solicitacoes cs = new Solicitacoes(label1.Text, this.Text);

            this.Dispose();
            cs.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PainelBloqueio.Visible = true;
            txtResposavel.Text = resposavel;
        }
        /// ////////////////////////////////////////////////////////////BLOQUEIO////////////////////////////////////////////////////////////////////
        private void BtnBloquear_Click(object sender, EventArgs e)
        {
            sqlQuery = "INSERT INTO bloqueio (DtHrStatus, Registrado, Motivo, FkAM) VALUES ('" + txtDtHorasBloqueio.Text + "', '" + txtResposavel.Text + "', '" + CbMotivoBloqueio.Text + "','" + cdAM + "');" +
            "UPDATE ambulancia SET Status ='BLOQUEADA' WHERE idAmbulancia ='" + cdAM + "'";
            msg = "Ambulância Bloqueada !";
            Bloqueio();
            PainelBloqueio.Visible = false;
            BtnDesbloquear.Visible = true;
            BtnBloqueio.Visible = false;
            BtnAddPaciente.Visible = false;
            painelCentral.BackColor = Color.Blue;
            label1.ForeColor = Color.White;
            /////
            label8.Visible = true;


        }

        private void BtnDesbloquear_Click(object sender, EventArgs e)
        {

            sqlQuery = "INSERT INTO desbloqueioam (Registrado, DthrDesblo,FkAMd) VALUES ('" + resposavel + "','" + now.ToString() + "','" + cdAM + "');" +
            "UPDATE ambulancia SET Status ='DISPONIVEL' WHERE idAmbulancia ='" + cdAM + "'";
            msg = "Ambulância Desbloqueada !";
            Bloqueio();
            BtnDesbloquear.Visible = false;
            BtnBloqueio.Visible = true;
            painelCentral.BackColor = Color.Green;
            BtnAddPaciente.Visible = true;
            label1.ForeColor = Color.Black;
            label8.Visible = false;
        }



        public void Bloqueio()
        {


            SqlConnection conexao = ConexaoSqlServer.GetConexao();

            try
            {

                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                SqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();

                MessageBox.Show(msg);
            }
            finally
            {
                conexao.Close();

            }

        }



        /// ////////////////////////////////////////////////////////////FIM - BLOQUEIO////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////VERIFICAR QUAL PACIENTE ESTA NA AM E SE TEM MAIS DE 1/////////////////////////////
        public void atualizarStatusOcupadoReservado(string CodAM)
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
                    
                    idSolicitacoesPacientes = MyReader2["idSolicitacoesPacientes"].ToString();
                   
                    atualizarStatusOcupadoPacientePorCodigo();
                }
            }
            finally
            {
                conexao.Close();

            }
        }
        public void atualizarStatusOcupadoPacientePorCodigo()
        {

            //atualizar a AM dependendo do status no banco
            SqlConnection conexao = ConexaoSqlServer.GetConexao();

            string sqlQuery = "SELECT idPaciente_Solicitacoes, Paciente FROM solicitacoes_paciente where idPaciente_Solicitacoes='" + idSolicitacoesPacientes + "'";

            try
            {
                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                SqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();

                while (MyReader2.Read())
                {
                    ListViewItem Pac = new ListViewItem(MyReader2["idPaciente_Solicitacoes"].ToString());
                    Pac.SubItems.Add(MyReader2["Paciente"].ToString());
                    ListadePacientes.Items.Add(Pac);
               

                }


            }
            finally
            {
                conexao.Close();
            }
        }
        //////////////////////////////////////////////////////VERIFICAR QUAL PACIENTE ESTA NA AM E SE TEM MAIS DE 1 ---  FIM/////////////////////////////
        //////////////////////////////////////////////////////VERIFICAR STATUS DA AMBULANCIA E ENCAIXAR AS INFORMACOES CORRESPONDENTES/////////////////////////////
        public void statusJanela()
        {

            if (cdAM == "1")
            {
                if (d.AM011 == "BLOQUEADA")
                {
                    painelCentral.BackColor = Color.RoyalBlue;
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    ListadePacientes.Visible = false;
                    this.Text = "Bloqueio";
                    label8.Visible = true;
                    SqlConnection conexao = ConexaoSqlServer.GetConexao();

                    string sqlQuery = "SELECT Motivo FROM bloqueio WHERE FkAM = '" + cdAM + "'";


                    try
                    {

                        SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                        SqlDataReader MyReader2;

                        MyReader2 = objComm.ExecuteReader();

                        while (MyReader2.Read())
                        {
                            label8.Text = MyReader2["Motivo"].ToString();

                        }
                    }
                    finally
                    {
                        conexao.Close();

                    }

                }
                if (d.AM011 == "OCUPADA")
                {
                    painelCentral.BackColor = Color.Firebrick;
                    label7.Visible = true;
                    label8.Visible = true;
                    PainelHistorico.Visible = true;
                    BtnAddPaciente.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    this.Text = "Ocupada";
                    d.atualizarStatusOcupado("1");
                    d.atualizarStatusOcupadoPaciente();
                    atualizarStatusOcupadoReservado("1");
                    id = d.IdSolicitacoesPacientes;
       
                    Destino.Text = d.Destino1;
                    Origem.Text = d.Origem1;
                    
                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    label7.Text = id;

                }
                if (d.AM011 == "DISPONIVEL")
                {
                    painelCentral.BackColor = Color.LimeGreen;
                    this.Text = "Disponível";
                    ListadePacientes.Visible = false;
                }
                label1.Text = "AM 01";
            }
            if (cdAM == "2")
            {
                if (d.AM021 == "BLOQUEADA")
                {
                    painelCentral.BackColor = Color.RoyalBlue;
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    this.Text = "Bloqueio";
                    label8.Visible = true;
                    ListadePacientes.Visible = false;

                    SqlConnection conexao = ConexaoSqlServer.GetConexao();

                    string sqlQuery = "SELECT Motivo FROM bloqueio WHERE FkAM = '" + cdAM + "'";


                    try
                    {

                        SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                        SqlDataReader MyReader2;

                        MyReader2 = objComm.ExecuteReader();

                        while (MyReader2.Read())
                        {
                            label8.Text = MyReader2["Motivo"].ToString();

                        }
                    }
                    finally
                    {
                        conexao.Close();

                    }
                }
                if (d.AM021 == "OCUPADA")
                {
                    painelCentral.BackColor = Color.Firebrick;
                    this.Text = "Ocupada";
                    label7.Visible = true;
                    label8.Visible = true;
                    PainelHistorico.Visible = true;
                    BtnAddPaciente.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    d.atualizarStatusOcupado("2");
                    d.atualizarStatusOcupadoPaciente();
                    atualizarStatusOcupadoReservado("2");
                    id = d.IdSolicitacoesPacientes;
                    Destino.Text = d.Destino1;
                    Origem.Text = d.Origem1;
                    
                    label7.Text = id;
                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    ListadePacientes.Visible = true;
                }
                if (d.AM021 == "DISPONIVEL")
                {
                    painelCentral.BackColor = Color.LimeGreen;
                    this.Text = "Disponivel";
                    
                    ListadePacientes.Visible = false;
                }
                label1.Text = "AM 02";
            }
            if (cdAM == "3")
            {
                if (d.AMRC1 == "DISPONIVEL")
                {
                    painelCentral.BackColor = Color.LimeGreen;
                    this.Text = "Disponivel";
                    ListadePacientes.Visible = false;
                }
                if (d.AMRC1 == "OCUPADA")
                {
                    this.Text = "Ocupada";

                    PainelHistorico.Visible = true;
                    BtnAddPaciente.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    label7.Visible = true;
                    label8.Visible = true;
                    d.atualizarStatusOcupado("3");
                    atualizarStatusOcupadoReservado("3");
                    d.atualizarStatusOcupadoPaciente();
                    id = d.IdSolicitacoesPacientes;
                    Destino.Text = d.Destino1;
                    Origem.Text = d.Origem1;
                   
                    label7.Text = id;
                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    ListadePacientes.Visible = true;

                    painelCentral.BackColor = Color.Firebrick;
                }
                if (d.AMRC1 == "BLOQUEADA")
                {
                    painelCentral.BackColor = Color.RoyalBlue;
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    this.Text = "Bloqueio";
                    label8.Visible = true;
                    ListadePacientes.Visible = false;
                }
                label1.Text = "AM RC";
            }
            if (cdAM == "4")
            {
                if (d.AM031 == "BLOQUEADA")
                {
                    painelCentral.BackColor = Color.RoyalBlue;
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    this.Text = "Bloqueio";
                    ListadePacientes.Visible = false;
                    label8.Visible = true;

                    SqlConnection conexao = ConexaoSqlServer.GetConexao();

                    string sqlQuery = "SELECT Motivo FROM bloqueio WHERE FkAM = '" + cdAM + "'";


                    try
                    {

                        SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                        SqlDataReader MyReader2;

                        MyReader2 = objComm.ExecuteReader();

                        while (MyReader2.Read())
                        {
                            label8.Text = MyReader2["Motivo"].ToString();

                        }
                    }
                    finally
                    {
                        conexao.Close();

                    }
                }
                if (d.AM031 == "DISPONIVEL")
                {
                    painelCentral.BackColor = Color.LimeGreen;
                    this.Text = "Disponivel";
                    ListadePacientes.Visible = false;
                }
                if (d.AM031 == "OCUPADA")
                {
                    painelCentral.BackColor = Color.Firebrick;
                    this.Text = "Ocupada";
                    PainelHistorico.Visible = true;
                    BtnAddPaciente.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    d.atualizarStatusOcupado("4");
                    atualizarStatusOcupadoReservado("4");
                    d.atualizarStatusOcupadoPaciente();
                    id = d.IdSolicitacoesPacientes;
                    Destino.Text = d.Destino1;
                    Origem.Text = d.Origem1;
                    label7.Text = id;
                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    ListadePacientes.Visible = true;
                }
                label1.Text = "AM 03";
            }
            if (cdAM == "5")
            {
                if (d.AM041 == "BLOQUEADA")
                {
                    painelCentral.BackColor = Color.RoyalBlue;
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    this.Text = "Bloqueio";
                    ListadePacientes.Visible = false;
                    label8.Visible = true;
                    SqlConnection conexao = ConexaoSqlServer.GetConexao();

                    string sqlQuery = "SELECT Motivo FROM bloqueio WHERE FkAM = '" + cdAM + "'";


                    try
                    {

                        SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                        SqlDataReader MyReader2;

                        MyReader2 = objComm.ExecuteReader();

                        while (MyReader2.Read())
                        {
                            label8.Text = MyReader2["Motivo"].ToString();

                        }
                    }
                    finally
                    {
                        conexao.Close();

                    }
                }
                if (d.AM041 == "OCUPADA")
                {
                    painelCentral.BackColor = Color.Firebrick;
                    this.Text = "Ocupada";
                    PainelHistorico.Visible = true;
                    BtnAddPaciente.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    d.atualizarStatusOcupado("5");
                    atualizarStatusOcupadoReservado("5");
                    d.atualizarStatusOcupadoPaciente();
                    id = d.IdSolicitacoesPacientes;
                    Destino.Text = d.Destino1;
                    Origem.Text = d.Origem1;
                    label7.Text = id;
                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    ListadePacientes.Visible = true;
                }
                if (d.AM041 == "DISPONIVEL")
                {
                    painelCentral.BackColor = Color.LimeGreen;
                    this.Text = "Disponivel";
                    ListadePacientes.Visible = false;
                }
                label1.Text = "AM 04";
            }
            if (cdAM == "6")
            {
                if (d.AM051 == "BLOQUEADA")
                {
                    painelCentral.BackColor = Color.RoyalBlue;
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    this.Text = "Bloqueio";
                    ListadePacientes.Visible = false;
                    label8.Visible = true;
                    label8.Visible = true;
                    SqlConnection conexao = ConexaoSqlServer.GetConexao();

                    string sqlQuery = "SELECT Motivo FROM bloqueio WHERE FkAM = '" + cdAM + "'";


                    try
                    {

                        SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                        SqlDataReader MyReader2;

                        MyReader2 = objComm.ExecuteReader();

                        while (MyReader2.Read())
                        {
                            label8.Text = MyReader2["Motivo"].ToString();

                        }
                    }
                    finally
                    {
                        conexao.Close();

                    }
                }

                if (d.AM051 == "DISPONIVEL")
                {
                    painelCentral.BackColor = Color.LimeGreen;
                    this.Text = "Disponivel";
                    ListadePacientes.Visible = false;
                }

                if (d.AM051 == "OCUPADA")
                {
                    painelCentral.BackColor = Color.Firebrick;
                    this.Text = "Ocupada";
                    label7.Visible = true;
                    label8.Visible = true;
                    PainelHistorico.Visible = true;
                    BtnAddPaciente.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    d.atualizarStatusOcupado("6");
                    atualizarStatusOcupadoReservado("6");
                    d.atualizarStatusOcupadoPaciente();
                    id = d.IdSolicitacoesPacientes;
                    Destino.Text = d.Destino1;
                    Origem.Text = d.Origem1;
                    label7.Text = id;
                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    ListadePacientes.Visible = true;
                }
                label1.Text = "AM 05";
            }
            if (cdAM == "7")
            {
                if (d.AM061 == "BLOQUEADA")
                {
                    painelCentral.BackColor = Color.RoyalBlue;
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    this.Text = "Bloqueio";
                    ListadePacientes.Visible = false;
                    label8.Visible = true;
                    SqlConnection conexao = ConexaoSqlServer.GetConexao();

                    string sqlQuery = "SELECT Motivo FROM bloqueio WHERE FkAM = '" + cdAM + "'";


                    try
                    {

                        SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                        SqlDataReader MyReader2;

                        MyReader2 = objComm.ExecuteReader();

                        while (MyReader2.Read())
                        {
                            label8.Text = MyReader2["Motivo"].ToString();

                        }
                    }
                    finally
                    {
                        conexao.Close();

                    }
                }
                if (d.AM061 == "OCUPADA")
                {
                    painelCentral.BackColor = Color.Firebrick;
                    this.Text = "Ocupada";
                    PainelHistorico.Visible = true;
                    BtnAddPaciente.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    d.atualizarStatusOcupado("7");
                    atualizarStatusOcupadoReservado("7");
                    d.atualizarStatusOcupadoPaciente();
                    id = d.IdSolicitacoesPacientes;
                    Destino.Text = d.Destino1;
                    Origem.Text = d.Origem1;
                    label7.Text = id;
                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    ListadePacientes.Visible = true;
                }
                if (d.AM061 == "DISPONIVEL")
                {
                    painelCentral.BackColor = Color.LimeGreen;
                    this.Text = "Disponivel";
                    ListadePacientes.Visible = false;
                }
                label1.Text = "AM 06";
            }
            if (cdAM == "8")
            {
                if (d.AM071 == "BLOQUEADA")
                {
                    label8.Visible = true;
                    painelCentral.BackColor = Color.RoyalBlue;
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    this.Text = "Bloqueio";
                    ListadePacientes.Visible = false;
                    SqlConnection conexao = ConexaoSqlServer.GetConexao();

                    string sqlQuery = "SELECT Motivo FROM bloqueio WHERE FkAM = '" + cdAM + "'";


                    try
                    {

                        SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                        SqlDataReader MyReader2;

                        MyReader2 = objComm.ExecuteReader();

                        while (MyReader2.Read())
                        {
                            label8.Text = MyReader2["Motivo"].ToString();

                        }
                    }
                    finally
                    {
                        conexao.Close();

                    }
                }
                if (d.AM071 == "DISPONIVEL")
                {
                    painelCentral.BackColor = Color.LimeGreen;
                    this.Text = "Disponivel";
                    ListadePacientes.Visible = false;
                }
                if (d.AM071 == "OCUPADA")
                {
                    painelCentral.BackColor = Color.Firebrick;
                    this.Text = "Ocupada";
                    PainelHistorico.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    BtnAddPaciente.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    d.atualizarStatusOcupado("8");
                    atualizarStatusOcupadoReservado("8");
                    d.atualizarStatusOcupadoPaciente();
                    id = d.IdSolicitacoesPacientes;
                    Destino.Text = d.Destino1;
                    Origem.Text = d.Origem1;
                    label7.Text = id;
                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    ListadePacientes.Visible = true;
                }
                label1.Text = "AM 07";
            }
            if (cdAM == "10")
            {
                if (d.AM081 == "OCUPADA")
                {
                    painelCentral.BackColor = Color.Firebrick;
                    this.Text = "Ocupada";
                    PainelHistorico.Visible = true;
                    BtnAddPaciente.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    d.atualizarStatusOcupado("10");
                    atualizarStatusOcupadoReservado("10");
                    d.atualizarStatusOcupadoPaciente();
                    id = d.IdSolicitacoesPacientes;
                    Destino.Text = d.Destino1;
                    Origem.Text = d.Origem1;
                    label7.Text = id;
                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    ListadePacientes.Visible = true;
                }
                if (d.AM081 == "DISPONIVEL")
                {
                    this.Text = "Disponivel";
                    painelCentral.BackColor = Color.LimeGreen;
                    ListadePacientes.Visible = false;
                }
                if (d.AM081 == "BLOQUEADA")
                {
                    painelCentral.BackColor = Color.RoyalBlue;
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    this.Text = "Bloqueio";
                    ListadePacientes.Visible = false;
                    label8.Visible = true;
                    SqlConnection conexao = ConexaoSqlServer.GetConexao();

                    string sqlQuery = "SELECT Motivo FROM bloqueio WHERE FkAM = '" + cdAM + "'";


                    try
                    {

                        SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                        SqlDataReader MyReader2;

                        MyReader2 = objComm.ExecuteReader();

                        while (MyReader2.Read())
                        {
                            label8.Text = MyReader2["Motivo"].ToString();

                        }
                    }
                    finally
                    {
                        conexao.Close();

                    }
                }
                label1.Text = "AM 08";
            }
            if (cdAM == "12")
            {
                if (d.AM091 == "BLOQUEADA")
                {
                    painelCentral.BackColor = Color.RoyalBlue;
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    this.Text = "Bloqueio";
                    ListadePacientes.Visible = false;
                    SqlConnection conexao = ConexaoSqlServer.GetConexao();
                    label8.Visible = true;
                    string sqlQuery = "SELECT Motivo FROM bloqueio WHERE FkAM = '" + cdAM + "'";


                    try
                    {

                        SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                        SqlDataReader MyReader2;

                        MyReader2 = objComm.ExecuteReader();

                        while (MyReader2.Read())
                        {
                            label8.Text = MyReader2["Motivo"].ToString();

                        }
                    }
                    finally
                    {
                        conexao.Close();

                    }
                }
                if (d.AM091 == "DISPONIVEL")
                {
                    painelCentral.BackColor = Color.LimeGreen;
                    this.Text = "Disponivel";
                    ListadePacientes.Visible = false;
                }
                if (d.AM091 == "OCUPADA")
                {
                    painelCentral.BackColor = Color.Firebrick;
                    this.Text = "Ocupada";
                    label7.Visible = true;
                    label8.Visible = true;
                    PainelHistorico.Visible = true;
                    BtnAddPaciente.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    d.atualizarStatusOcupado("12");
                    atualizarStatusOcupadoReservado("12");
                    d.atualizarStatusOcupadoPaciente();
                    id = d.IdSolicitacoesPacientes;
                    Destino.Text = d.Destino1;
                    Origem.Text = d.Origem1;
                    label7.Text = id;
                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    ListadePacientes.Visible = true;
                }
                label1.Text = "AM 09";
            }
            if (cdAM == "13")
            {
                if (d.AM101 == "OCUPADA")
                {
                    painelCentral.BackColor = Color.Firebrick;
                    this.Text = "Ocupada";
                    PainelHistorico.Visible = true;
                    BtnAddPaciente.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    d.atualizarStatusOcupado("13");
                    atualizarStatusOcupadoReservado("13");
                    d.atualizarStatusOcupadoPaciente();
                    id = d.IdSolicitacoesPacientes;
                    Destino.Text = d.Destino1;
                    Origem.Text = d.Origem1;
                    label7.Text = id;
                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    ListadePacientes.Visible = true;
                }
                if (d.AM101 == "DISPONIVEL")
                {
                    painelCentral.BackColor = Color.LimeGreen;
                    this.Text = "Disponivel";
                    ListadePacientes.Visible = false;
                }
                if (d.AM101 == "BLOQUEADA")
                {
                    painelCentral.BackColor = Color.RoyalBlue;
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    this.Text = "Bloqueio";
                    ListadePacientes.Visible = false;
                    label8.Visible = true;
                    SqlConnection conexao = ConexaoSqlServer.GetConexao();

                    string sqlQuery = "SELECT Motivo FROM bloqueio WHERE FkAM = '" + cdAM + "'";


                    try
                    {

                        SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                        SqlDataReader MyReader2;

                        MyReader2 = objComm.ExecuteReader();

                        while (MyReader2.Read())
                        {
                            label8.Text = MyReader2["Motivo"].ToString();

                        }
                    }
                    finally
                    {
                        conexao.Close();

                    }
                }
                label1.Text = "AM 10";
            }
            if (cdAM == "14")
            {
                if (d.AM111 == "BLOQUEADA")
                {
                    painelCentral.BackColor = Color.RoyalBlue;
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    this.Text = "Bloqueio";
                    ListadePacientes.Visible = false;
                    label8.Visible = true;
                    SqlConnection conexao = ConexaoSqlServer.GetConexao();

                    string sqlQuery = "SELECT Motivo FROM bloqueio WHERE FkAM = '" + cdAM + "'";


                    try
                    {

                        SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                        SqlDataReader MyReader2;

                        MyReader2 = objComm.ExecuteReader();

                        while (MyReader2.Read())
                        {
                            label8.Text = MyReader2["Motivo"].ToString();

                        }
                    }
                    finally
                    {
                        conexao.Close();

                    }
                }
                if (d.AM111 == "DISPONIVEL")
                {
                    painelCentral.BackColor = Color.LimeGreen;
                    this.Text = "Disponivel";
                    ListadePacientes.Visible = false;
                }
                if (d.AM111 == "OCUPADA")
                {
                    painelCentral.BackColor = Color.Firebrick;
                    this.Text = "Ocupada";
                    label7.Visible = true;
                    label8.Visible = true;
                    PainelHistorico.Visible = true;
                    BtnAddPaciente.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    d.atualizarStatusOcupado("14");
                    atualizarStatusOcupadoReservado("14");
                    d.atualizarStatusOcupadoPaciente();
                    id = d.IdSolicitacoesPacientes;
                    Destino.Text = d.Destino1;
                    Origem.Text = d.Origem1;
                    label7.Text = id;
                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    ListadePacientes.Visible = true;
                }
                label1.Text = "AM 11";
            }

            if (cdAM == "15")
            {
                if (d.AM121 == "BLOQUEADA")
                {
                    painelCentral.BackColor = Color.RoyalBlue;
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    this.Text = "Bloqueio";
                    ListadePacientes.Visible = false;
                    label8.Visible = true;
                    SqlConnection conexao = ConexaoSqlServer.GetConexao();

                    string sqlQuery = "SELECT Motivo FROM bloqueio WHERE FkAM = '" + cdAM + "'";


                    try
                    {

                        SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                        SqlDataReader MyReader2;

                        MyReader2 = objComm.ExecuteReader();

                        while (MyReader2.Read())
                        {
                            label8.Text = MyReader2["Motivo"].ToString();

                        }
                    }
                    finally
                    {
                        conexao.Close();

                    }
                }
                if (d.AM121 == "DISPONIVEL")
                {
                    painelCentral.BackColor = Color.LimeGreen;
                    this.Text = "Disponivel";
                    ListadePacientes.Visible = false;
                }
                if (d.AM121 == "OCUPADA")
                {
                    painelCentral.BackColor = Color.Firebrick;
                    this.Text = "Ocupada";
                    label7.Visible = true;
                    label8.Visible = true;
                    PainelHistorico.Visible = true;
                    BtnAddPaciente.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    d.atualizarStatusOcupado("15");
                    atualizarStatusOcupadoReservado("15");
                    d.atualizarStatusOcupadoPaciente();
                    id = d.IdSolicitacoesPacientes;
                    Destino.Text = d.Destino1;
                    Origem.Text = d.Origem1;
                    label7.Text = id;
                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    ListadePacientes.Visible = true;
                }
                label1.Text = "AM 12";
            }
          
            if (cdAM == "16")
            {
                if (d.AM461 == "DISPONIVEL")
                {
                    painelCentral.BackColor = Color.LimeGreen;
                    this.Text = "Disponivel";
                    ListadePacientes.Visible = false;
                }
                if (d.AM461 == "OCUPADA")
                {
                    painelCentral.BackColor = Color.Firebrick;
                    this.Text = "Ocupada";
                    PainelHistorico.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    BtnAddPaciente.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    d.atualizarStatusOcupado("16");
                    atualizarStatusOcupadoReservado("16");
                    d.atualizarStatusOcupadoPaciente();
                    id = d.IdSolicitacoesPacientes;
                    Destino.Text = d.Destino1;
                    Origem.Text = d.Origem1;
                    label7.Text = id;
                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    ListadePacientes.Visible = true;
                }
                if (d.AM461 == "BLOQUEADA")
                {
                    painelCentral.BackColor = Color.RoyalBlue;
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    this.Text = "Bloqueio";
                    ListadePacientes.Visible = false;
                    label8.Visible = true;
                    SqlConnection conexao = ConexaoSqlServer.GetConexao();

                    string sqlQuery = "SELECT Motivo FROM bloqueio WHERE FkAM = '" + cdAM + "'";


                    try
                    {

                        SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                        SqlDataReader MyReader2;

                        MyReader2 = objComm.ExecuteReader();

                        while (MyReader2.Read())
                        {
                            label8.Text = MyReader2["Motivo"].ToString();

                        }
                    }
                    finally
                    {
                        conexao.Close();

                    }
                }
                label1.Text = "AM 46";
            }
            if (cdAM == "17")
            {
                if (d.AM471 == "OCUPADA")
                {
                    painelCentral.BackColor = Color.Firebrick;
                    this.Text = "Ocupada";
                    PainelHistorico.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    BtnAddPaciente.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    d.atualizarStatusOcupado("17");
                    atualizarStatusOcupadoReservado("17");
                    d.atualizarStatusOcupadoPaciente();
                    id = d.IdSolicitacoesPacientes;
                    Destino.Text = d.Destino1;
                    Origem.Text = d.Origem1;
                    label7.Text = id;
                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    ListadePacientes.Visible = true;
                }
                if (d.AM471 == "DISPONIVEL")
                {
                    painelCentral.BackColor = Color.LimeGreen;
                    this.Text = "Disponivel";
                    ListadePacientes.Visible = false;
                }
                if (d.AM471 == "BLOQUEADA")
                {
                    painelCentral.BackColor = Color.RoyalBlue;
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    this.Text = "Bloqueio";
                    ListadePacientes.Visible = false;
                    label8.Visible = true;
                    SqlConnection conexao = ConexaoSqlServer.GetConexao();

                    string sqlQuery = "SELECT Motivo FROM bloqueio WHERE FkAM = '" + cdAM + "'";


                    try
                    {

                        SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                        SqlDataReader MyReader2;

                        MyReader2 = objComm.ExecuteReader();

                        while (MyReader2.Read())
                        {
                            label8.Text = MyReader2["Motivo"].ToString();

                        }
                    }
                    finally
                    {
                        conexao.Close();

                    }
                }
                label1.Text = "AM 47";
            }
            if (cdAM == "18")
            {
                if (d.AM521 == "DISPONIVEL")
                {
                    painelCentral.BackColor = Color.LimeGreen;
                    this.Text = "Disponivel";
                    ListadePacientes.Visible = false;
                }
                if (d.AM521 == "OCUPADA")
                {
                    painelCentral.BackColor = Color.Firebrick;
                    this.Text = "Ocupada";
                    PainelHistorico.Visible = true;
                    BtnAddPaciente.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    d.atualizarStatusOcupado("18");
                    atualizarStatusOcupadoReservado("18");
                    d.atualizarStatusOcupadoPaciente();
                    id = d.IdSolicitacoesPacientes;
                    Destino.Text = d.Destino1;
                    Origem.Text = d.Origem1;
                    label7.Text = id;
                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    ListadePacientes.Visible = true;
                }
                if (d.AM521 == "BLOQUEADA")
                {
                    painelCentral.BackColor = Color.RoyalBlue;
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    this.Text = "Bloqueio";
                    ListadePacientes.Visible = false;
                    label8.Visible = true;
                    SqlConnection conexao = ConexaoSqlServer.GetConexao();

                    string sqlQuery = "SELECT Motivo FROM bloqueio WHERE FkAM = '" + cdAM + "'";


                    try
                    {

                        SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                        SqlDataReader MyReader2;

                        MyReader2 = objComm.ExecuteReader();

                        while (MyReader2.Read())
                        {
                            label8.Text = MyReader2["Motivo"].ToString();

                        }
                    }
                    finally
                    {
                        conexao.Close();

                    }
                }
                label1.Text = "AM 52";
            }
        }
        ///////////////////////////////////////////////////////FIM STATUS AM///////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////LOGISTICA DA AM - INICIO///////////////////////////////////////////////////////////////////////////////


        private void BtnEquipeCiente_Click(object sender, EventArgs e)
        {
            if (txtHora.Enabled == false && txtHora.Text != "")
            {
                txtHora.Enabled = true;
                txtAlterador.Enabled = true;
                BtnEquipeCiente.Text = "Alterar";
                return;
            }
            if (txtHora.Enabled == true && txtHora.Text != "")
            {
                BtnEquipeCiente.Text = "Equipe Ciente";
                txtHoras = txtHora.Text;
                txtAlteradores = txtAlterador.Text;
                hora = "DtHrCiencia";
                alterador = "DtHrCienciaReg";
                msg = "Alterado !";

                SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, cdAM);
                txtHora.Enabled = false;
                txtAlterador.Enabled = false;
                return;

            }
            if (listView1.Items.Count <= 0)
            {
                MessageBox.Show("Atribua uma equipe na Ambulância !", "ATENÇÃO", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }

            txtAlterador.Text = resposavel;
            txtHora.Text = DateTime.Now.ToString();

            painel1.Visible = false;
            BtnOrigem.BackColor = Color.MediumTurquoise;
            BtnEquipeCiente.BackColor = Color.LightSkyBlue;

            txtHoras = txtHora.Text;
            txtAlteradores = txtAlterador.Text;
            hora = "DtHrCiencia";
            alterador = "DtHrCienciaReg";
            msg = "Avise a equipe que é necessario informar a chegada na origem !";
            SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, cdAM);


        }


        private void BtnOrigem_Click(object sender, EventArgs e)
        {
            if (txtHora2.Enabled == false && txtHora2.Text != "")
            {
                txtHora2.Enabled = true;
                txtAlterador2.Enabled = true;
                BtnOrigem.Text = "Alterar";
                return;
            }
            if (txtHora2.Enabled == true && txtHora2.Text != "")
            {
                BtnOrigem.Text = "Equipe na Origem";
                txtHoras = txtHora2.Text;
                txtAlteradores = txtAlterador2.Text;
                hora = "DtHrChegadaOrigem";
                alterador = "DtHrChegadaOrigemReg";
                msg = "Alterado !";

                SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, cdAM);
                txtHora2.Enabled = false;
                txtAlterador2.Enabled = false;
                return;

            }

            txtHora2.Text = DateTime.Now.ToString();
            txtAlterador2.Text = resposavel;

            painel2.Visible = false;
            BtnSaiuOrigem.BackColor = Color.MediumTurquoise;
            BtnOrigem.BackColor = Color.LightSkyBlue;

            txtHoras = txtHora2.Text;
            txtAlteradores = txtAlterador2.Text;
            hora = "DtHrChegadaOrigem";
            alterador = "DtHrChegadaOrigemReg";
            msg = "Avise a equipe que é necessario informar a saida da origem !";
            SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, cdAM);
        }

        private void BtnSaiuOrigem_Click(object sender, EventArgs e)
        {
            if (txtHora3.Enabled == false && txtHora3.Text != "")
            {
                txtHora3.Enabled = true;
                txtAlterador3.Enabled = true;
                BtnSaiuOrigem.Text = "Alterar";
                return;
            }
            if (txtHora3.Enabled == true && txtHora3.Text != "")
            {
                BtnSaiuOrigem.Text = "Equipe Saiu da Origem";
                txtHoras = txtHora3.Text;
                txtAlteradores = txtAlterador3.Text;
                hora = "DtHrSaidaOrigem";
                alterador = "DtHrSaidaOrigemReg";
                msg = "Alterado !";

                SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, cdAM);
                txtHora3.Enabled = false;
                txtAlterador3.Enabled = false;
                return;

            }
            txtAlterador3.Text = resposavel;
            txtHora3.Text = DateTime.Now.ToString();

            painel3.Visible = false;
            BtnEquipeDestino.BackColor = Color.MediumTurquoise;
            BtnSaiuOrigem.BackColor = Color.LightSkyBlue;

            txtHoras = txtHora3.Text;
            txtAlteradores = txtAlterador3.Text;
            hora = "DtHrSaidaOrigem";
            alterador = "DtHrSaidaOrigemReg";
            msg = "Avise a equipe que é necessario informar ao chegar ao destino !";
            SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, cdAM);
        }

        private void BtnEquipeDestino_Click(object sender, EventArgs e)
        {
            if (txtHora4.Enabled == false && txtHora4.Text != "")
            {
                txtHora4.Enabled = true;
                txtAlterador4.Enabled = true;
                BtnEquipeDestino.Text = "Alterar";
                return;
            }
            if (txtHora4.Enabled == true && txtHora4.Text != "")
            {
                BtnEquipeDestino.Text = "Equipe no Destino";
                txtHoras = txtHora4.Text;
                txtAlteradores = txtAlterador4.Text;
                hora = "DtHrChegadaDestino";
                alterador = "DtHrChegadaDestinoReg";
                msg = "Alterado !";

                SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, cdAM);
                txtHora4.Enabled = false;
                txtAlterador4.Enabled = false;
                return;

            }

            txtAlterador4.Text = resposavel;
            txtHora4.Text = DateTime.Now.ToString();

            painel4.Visible = false;
            EquipeLiberada.BackColor = Color.MediumTurquoise;
            BtnEquipeDestino.BackColor = Color.LightSkyBlue;

            txtHoras = txtHora4.Text;
            txtAlteradores = txtAlterador4.Text;
            hora = "DtHrChegadaDestino";
            alterador = "DtHrChegadaDestinoReg";
            msg = "Avise a equipe que é necessario informar ao ser liberado do destino !";
            SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, cdAM);
        }

        private void EquipeLiberada_Click(object sender, EventArgs e)
        {
            if (txtHora5.Enabled == false && txtHora5.Text != "")
            {
                txtHora5.Enabled = true;
                txtAlterador5.Enabled = true;
                EquipeLiberada.Text = "Alterar";
                return;
            }
            if (txtHora5.Enabled == true && txtHora5.Text != "")
            {
                EquipeLiberada.Text = "Equipe Liberada do Destino";
                txtHoras = txtHora5.Text;
                txtAlteradores = txtAlterador5.Text;
                hora = "DtHrLiberacaoEquipe";
                alterador = "DtHrLiberacaoEquipeReg";
                msg = "Alterado !";

                SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, cdAM);
                txtHora5.Enabled = false;
                txtAlterador5.Enabled = false;
                return;

            }
            txtAlterador5.Text = resposavel;
            txtHora5.Text = DateTime.Now.ToString();

            painel5.Visible = false;
            BtnPatio.BackColor = Color.MediumTurquoise;
            EquipeLiberada.BackColor = Color.LightSkyBlue;

            txtHoras = txtHora5.Text;
            txtAlteradores = txtAlterador5.Text;
            hora = "DtHrLiberacaoEquipe";
            alterador = "DtHrLiberacaoEquipeReg";
            msg = "Avise a equipe que é necessario informar a chegada no pátio !";
            SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, cdAM);
        }

        private void BtnPatio_Click(object sender, EventArgs e)
        {

            BtnEquipeDestino.BackColor = Color.LightSkyBlue;
            txtHora6.Text = DateTime.Now.ToString();
            txtAlterador6.Text = resposavel;

            txtHoras = txtHora6.Text;
            txtAlteradores = txtAlterador6.Text;
            msg = "Equipe disponivel !";
            SalvaHorario("DtHrEquipePatio", "DtHrEquipePatioReg", txtHoras, txtAlteradores, msg, cdAM);


            string upAM = "UPDATE ambulancia SET Status='DISPONIVEL' WHERE idAmbulancia='" + cdAM + "'";
            updateSolicitacao(upAM);

            string upSA = "UPDATE solicitacoes_ambulancias SET SolicitacaoConcluida = '1' WHERE idAmbulanciaSol = '" + cdAM + "' AND SolicitacaoConcluida='0'";
            updateSolicitacao(upSA);
            DialogResult rs = MessageBox.Show("Deseja imprimir a ficha completa da solicitação ?", "Atenção !", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (rs == DialogResult.Yes)
            {

                SelecionaAM samb = new SelecionaAM(id, cdAM, codEquipe, this.Text);
                samb.imprimirFicha();
                this.Dispose();
            }
            else
            {
                this.Dispose();
            }



        }
        private void SalvaHorario(string hora1, string alterador1, string txtHoras1, string txtAlteradores1, string mensagem, string CodigodaAm1)
        {


            //salva os horarios da AM
            SqlConnection conexao = ConexaoSqlServer.GetConexao();

            string sqlQuery = "UPDATE solicitacoes_ambulancias SET " + hora1 + "='" + txtHoras1 + "'," + alterador1 + "='" + txtAlteradores1 + "' WHERE idAmbulanciaSol = '" + CodigodaAm1 + "' AND SolicitacaoConcluida='0'";


            try
            {

                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                SqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();

                MessageBox.Show("Solicitação salva com sucesso !!!");
                MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                conexao.Close();

            }
        }
        ///////////////////////////////////////////////////////LOGISTICA DA AM - FIM///////////////////////////////////////////////////////////////////////////////

        private void updateSolicitacao(string aa)
        {
            SqlConnection conexao = ConexaoSqlServer.GetConexao();

            try
            {

                SqlCommand objComm = new SqlCommand(aa, conexao);
                SqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();
            }
            finally
            {
                conexao.Close();

            }
        }


        private void selectHorarios()
        {
            SqlConnection conexao = ConexaoSqlServer.GetConexao();

            string sqlQuery = "SELECT * FROM solicitacoes_ambulancias WHERE idSolicitacoes_Ambulancias = '" + SolicitaAM + "'";


            try
            {

                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                SqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();
                while (MyReader2.Read())
                {
                    txtHora.Text = MyReader2["DtHrCiencia"].ToString();
                    txtHora2.Text = MyReader2["DtHrChegadaOrigem"].ToString();
                    txtHora3.Text = MyReader2["DtHrSaidaOrigem"].ToString();
                    txtHora4.Text = MyReader2["DtHrChegadaDestino"].ToString();
                    txtHora5.Text = MyReader2["DtHrLiberacaoEquipe"].ToString();
                    txtHora6.Text = MyReader2["DtHrEquipePatio"].ToString();
                    txtAlterador.Text = MyReader2["DtHrCienciaReg"].ToString();
                    txtAlterador2.Text = MyReader2["DtHrChegadaOrigemReg"].ToString();
                    txtAlterador3.Text = MyReader2["DtHrSaidaOrigemReg"].ToString();
                    txtAlterador4.Text = MyReader2["DtHrChegadaDestinoReg"].ToString();
                    txtAlterador5.Text = MyReader2["DtHrLiberacaoEquipeReg"].ToString();
                    txtAlterador6.Text = MyReader2["DtHrEquipePatioReg"].ToString();
                }
            }
            finally
            {
                conexao.Close();

            }
        }
        private void selectHorarioVerificacao()
        {

            if (txtHora.Text == "")
            {
                painel1.Visible = true;
            }
            else if (txtHora.Text != "")
            {
                painel1.Visible = false;
                BtnOrigem.BackColor = Color.MediumTurquoise;
                BtnEquipeCiente.BackColor = Color.LightSkyBlue;
            }
            if (txtHora2.Text == "")
            {
                painel2.Visible = true;
            }
            else if (txtHora2.Text != "")
            {
                BtnOrigem.BackColor = Color.LightSkyBlue;
                painel2.Visible = false;
                BtnSaiuOrigem.BackColor = Color.MediumTurquoise;
            }
            if (txtHora3.Text == "")
            {
                painel3.Visible = true;
            }
            else if (txtHora3.Text != "")
            {

                painel3.Visible = false;
                BtnEquipeDestino.BackColor = Color.MediumTurquoise;
                BtnSaiuOrigem.BackColor = Color.LightSkyBlue;
            }
            if (txtHora4.Text == "")
            {
                painel4.Visible = true;
            }
            else if (txtHora4.Text != "")
            {
                painel4.Visible = false;
                EquipeLiberada.BackColor = Color.MediumTurquoise;
                BtnEquipeDestino.BackColor = Color.LightSkyBlue;
            }
            if (txtHora5.Text == "")
            {
                painel5.Visible = true;
            }
            else if (txtHora5.Text != "")
            {
                painel5.Visible = false;
                BtnPatio.BackColor = Color.MediumTurquoise;
                EquipeLiberada.BackColor = Color.LightSkyBlue;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            SelecionaAM sand = new SelecionaAM(id, cdAM, codEquipe, this.Text);
            this.Dispose();
            sand.ShowDialog();
        }

        string IDpesquisa;
        private void ListadePacientes_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (ListadePacientes.SelectedItems.Count > 0)
            {
                IDpesquisa = ListadePacientes.SelectedItems[0].Text;

            }
            SelecionaAM sand = new SelecionaAM(IDpesquisa, cdAM, codEquipe, this.Text);
            this.Dispose();
            sand.ShowDialog();
        }


    }
}
