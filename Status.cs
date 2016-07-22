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
using db_transporte_sanitario;

namespace WindowsFormsApplication2
{

    public partial class Status : Form
    {
        DateTime now = DateTime.Now;
        string txtHoras, txtAlteradores, hora, alterador, resposavel = System.Environment.UserName;
        int id, codEquipe, SolicitaAM;
        int codigoDaAmbulancia, idSolicitacoesPacientes;
        string NomeAM;
        StatusBD d = new StatusBD();

        public Status(int Cod)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            BtnAddPaciente.Location = new Point(899, 327);
            BtnAddPaciente.Size = new Size(306, 214);
            label7.Visible = false;
            label8.Visible = false;
            txtDtHorasBloqueio.Text = now.ToString();
            codigoDaAmbulancia = Cod;

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
            InteracaoBanco ib = new InteracaoBanco();
            DateTime now = DateTime.Now;

            ib.inserirEquipeNaAmbulancia(txtMoto.Text, txtEquipe.Text, now.ToString(), codigoDaAmbulancia);

            MessageBox.Show("Equipe trocada !");

            equipeView.DataSource = null;
            Paineltrocar.Visible = false;
            selectEquipeBD();
            EquipeAtribuiNaOcupada();
        }
        private void EquipeAtribuiNaOcupada()
        {
            if (this.Text == "Ocupada")
            {
                InteracaoBanco ib = new InteracaoBanco();
                ib.inserirEquipeAmOcupada(codEquipe ,SolicitaAM);
                
                MessageBox.Show("Equipe trocada !");
            }
        }
        ///////////////////////////////////////////////////////SELECT EQUIPE////////////////////////////////////////////////////////////////////////////////////////
        private void selectEquipeBD()
        {
            using(DAHUEEntities db = new DAHUEEntities())
            {

            var query = (from equipe in db.equipe
                        where equipe.idAM == codigoDaAmbulancia 
                        orderby equipe.idEquipe descending 
                        select new {
                            Condutor = equipe.Condutor, 
                            Enfermeiros = equipe.Enfermeiros, 
                            DtEscala = equipe.DtEscala,
                            idAM = equipe.idAM
                        }).Take(1);
            var queryEquipe = query.ToList();

            equipeView.DataSource = queryEquipe;

            codEquipe = equipeView.SelectedCells[0].RowIndex;
            MessageBox.Show(codEquipe.ToString());
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
            InteracaoBanco IB = new InteracaoBanco();
            IB.inserirBloqueioDaAm(txtDtHorasBloqueio.Text, txtResposavel.Text, CbMotivoBloqueio.Text, codigoDaAmbulancia);
                     
            MessageBox.Show("Ambulância Bloqueada !");
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
            InteracaoBanco IB = new InteracaoBanco();
            IB.inserirDesloqueioDaAm(resposavel, now.ToString(), codigoDaAmbulancia);

            MessageBox.Show("Ambulância Desbloqueada !");
            BtnDesbloquear.Visible = false;
            BtnBloqueio.Visible = true;
            painelCentral.BackColor = Color.Green;
            BtnAddPaciente.Visible = true;
            label1.ForeColor = Color.Black;
            label8.Visible = false;
        }

        /// ////////////////////////////////////////////////////////////FIM - BLOQUEIO////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////VERIFICAR QUAL PACIENTE ESTA NA AM E SE TEM MAIS DE 1/////////////////////////////
        public void atualizarStatusOcupadoReservado(int CodAM)
        {
            int zero = 0;
            //atualizar a AM dependendo do status no banco
            using(DAHUEEntities db = new DAHUEEntities())
            {
                var query = from solicitacoes_ambulancias in db.solicitacoes_ambulancias 
                            where solicitacoes_ambulancias.idAmbulanciaSol == CodAM && 
                            solicitacoes_ambulancias.SolicitacaoConcluida == zero 
                            select new { solicitacoes_ambulancias.idSolicitacoesPacientes };
                
                var queryAM = query.First();
                idSolicitacoesPacientes = Convert.ToInt32(queryAM.ToString());

            }
             
            atualizarStatusOcupadoPacientePorCodigo();
            
        }
        public void atualizarStatusOcupadoPacientePorCodigo()
        {
            //atualizar a AM dependendo do status no banco
            using(DAHUEEntities db = new DAHUEEntities())
            {
                var query = from solicitacoes_paciente in db.solicitacoes_paciente
                            where solicitacoes_paciente.idPaciente_Solicitacoes == idSolicitacoesPacientes
                            select new
                            {
                                solicitacoes_paciente.idPaciente_Solicitacoes,
                                solicitacoes_paciente.Paciente
                            };
                var querySP = query.ToList();
                ListadePacientes.DataSource = querySP;
            }

        }
        //////////////////////////////////////////////////////VERIFICAR QUAL PACIENTE ESTA NA AM E SE TEM MAIS DE 1 ---  FIM/////////////////////////////
        //////////////////////////////////////////////////////VERIFICAR STATUS DA AMBULANCIA E ENCAIXAR AS INFORMACOES CORRESPONDENTES/////////////////////////////
        public void statusJanela()
        {
            using(DAHUEEntities db = new DAHUEEntities())
            {

            }
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

                    string sqlQuery = "SELECT Motivo FROM bloqueio WHERE FkAM = '" + codigoDaAmbulancia + "'";


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

                SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, codigoDaAmbulancia);
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
            SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, codigoDaAmbulancia);


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

                SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, codigoDaAmbulancia);
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
            SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, codigoDaAmbulancia);
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

                SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, codigoDaAmbulancia);
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
            SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, codigoDaAmbulancia);
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

                SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, codigoDaAmbulancia);
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
            SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, codigoDaAmbulancia);
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

                SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, codigoDaAmbulancia);
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
            SalvaHorario(hora, alterador, txtHoras, txtAlteradores, msg, codigoDaAmbulancia);
        }

        private void BtnPatio_Click(object sender, EventArgs e)
        {

            BtnEquipeDestino.BackColor = Color.LightSkyBlue;
            txtHora6.Text = DateTime.Now.ToString();
            txtAlterador6.Text = resposavel;

            txtHoras = txtHora6.Text;
            txtAlteradores = txtAlterador6.Text;
            msg = "Equipe disponivel !";
            SalvaHorario("DtHrEquipePatio", "DtHrEquipePatioReg", txtHoras, txtAlteradores, msg, codigoDaAmbulancia);


            string upAM = "UPDATE ambulancia SET Status='DISPONIVEL' WHERE idAmbulancia='" + codigoDaAmbulancia + "'";
            updateSolicitacao(upAM);

            string upSA = "UPDATE solicitacoes_ambulancias SET SolicitacaoConcluida = '1' WHERE idAmbulanciaSol = '" + codigoDaAmbulancia + "' AND SolicitacaoConcluida='0'";
            updateSolicitacao(upSA);
            DialogResult rs = MessageBox.Show("Deseja imprimir a ficha completa da solicitação ?", "Atenção !", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (rs == DialogResult.Yes)
            {

                SelecionaAM samb = new SelecionaAM(id, codigoDaAmbulancia, codEquipe, this.Text);
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

            SelecionaAM sand = new SelecionaAM(id, codigoDaAmbulancia, codEquipe, this.Text);
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
            SelecionaAM sand = new SelecionaAM(IDpesquisa, codigoDaAmbulancia, codEquipe, this.Text);
            this.Dispose();
            sand.ShowDialog();
        }


    }
}
