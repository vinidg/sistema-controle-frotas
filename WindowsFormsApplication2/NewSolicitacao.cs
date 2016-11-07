using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class ConfirmaSolicitacao : Form
    {
        string TipoAM = null;
        string Agendamento = null;
        DateTime now = DateTime.Now;
        string pegaUnidade;//para pegar o telefone com o nome da unidade
        string pegaUnidadeEnd;//para pegar o endereco com o nome da unidade
        string Sexo, pegamotivo;
        string Endereco1;

        public ConfirmaSolicitacao()
        {
            InitializeComponent();
            txtAtendMarcado.Text = now.ToString();
            StartPosition = FormStartPosition.CenterScreen;
            Endereco();

        }

        private void NovaSolicitacao_Load(object sender, EventArgs e)
        {

            Limpar();

        }

        private void BtnBasica_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            Btnagendanao.Visible = true;
            Btnagendasim.Visible = true;
            TipoAM = "Basica";


            if (BtnAvancada.BackColor == Color.PaleTurquoise)
            {
                BtnBasica.BackColor = Color.PaleTurquoise;
                BtnAvancada.BackColor = Color.Teal;
            }
            BtnAvancada.BackColor = Color.PaleTurquoise;
            BtnBasica.BackColor = Color.Teal;
        }
        private void BtnAvancada_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            Btnagendanao.Visible = true;
            Btnagendasim.Visible = true;
            TipoAM = "Avancada";

            if (BtnBasica.BackColor == Color.PaleTurquoise)
            {
                BtnAvancada.BackColor = Color.PaleTurquoise;
                BtnBasica.BackColor = Color.Teal;
            }
            BtnBasica.BackColor = Color.PaleTurquoise;
            BtnAvancada.BackColor = Color.Teal;
        }


        public void Limpar()
        {
            label2.Visible = false;
            Btnagendanao.Visible = false;
            Btnagendasim.Visible = false;
            label3.Visible = false;
            txtAtendMarcado.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            txtNomeSolicitante.Visible = false;
            label6.Visible = false;
            CbLocalSolicita.Visible = false;
            label7.Visible = false;
            txtTelefone.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            txtNomePaciente.Visible = false;
            label10.Visible = false;
            RbFemenino.Visible = false;
            RbMasculino.Visible = false;
            label11.Visible = false;
            txtIdade.Visible = false;
            label12.Visible = false;
            txtDiagnostico.Visible = false;
            label13.Visible = false;
            CbMotivoChamado.Visible = false;
            label14.Visible = false;
            CbTipoMotivoSelecionado.Visible = false;
            CbAtendimentoPrioridade.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            CbOrigem.Visible = false;
            label17.Visible = false;
            CbDestino.Visible = false;
            label18.Visible = false;
            txtEnderecoOrigem.Visible = false;
            label19.Visible = false;
            txtEnderecoDestino.Visible = false;
            label20.Visible = false;
            richTextBox1.Visible = false;
            BtnSalvar.Visible = false;
            Btnagendasim.BackColor = Color.OrangeRed;
            Btnagendanao.BackColor = Color.OrangeRed;
            BtnAvancada.BackColor = Color.OrangeRed;
            BtnBasica.BackColor = Color.OrangeRed;
        }

        private void Btnagendanao_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            txtAtendMarcado.Visible = false;
            label4.Visible = true;
            label5.Visible = true;
            txtNomeSolicitante.Visible = true;
            label6.Visible = true;
            CbLocalSolicita.Visible = true;
            label7.Visible = true;
            txtTelefone.Visible = true;
            Agendamento = "Nao";
            if (Btnagendasim.BackColor == Color.OrangeRed)
            {
                Btnagendanao.BackColor = Color.OrangeRed;
                Btnagendasim.BackColor = Color.DarkRed;
            }
            Btnagendasim.BackColor = Color.OrangeRed;
            Btnagendanao.BackColor = Color.DarkRed;

        }

        private void Btnagendasim_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            txtAtendMarcado.Visible = true;
            txtAtendMarcado.Focus();
            label4.Visible = true;
            label5.Visible = true;
            txtNomeSolicitante.Visible = true;
            label6.Visible = true;
            CbLocalSolicita.Visible = true;
            label7.Visible = true;
            txtTelefone.Visible = true;
            Agendamento = "Sim";

            if (Btnagendanao.BackColor == Color.OrangeRed)
            {
                Btnagendasim.BackColor = Color.OrangeRed;
                Btnagendanao.BackColor = Color.DarkRed;
            }
            Btnagendanao.BackColor = Color.OrangeRed;
            Btnagendasim.BackColor = Color.DarkRed;

        }

        private void CbLocalSolicita_SelectedIndexChanged(object sender, EventArgs e)
        {



            pegaUnidade = CbLocalSolicita.Text;
            unidade_telefone();
        }

        private void CbLocalSolicita_TextChanged(object sender, EventArgs e)
        {
            label8.Visible = true;
            label9.Visible = true;
            txtNomePaciente.Visible = true;
            label10.Visible = true;
            RbMasculino.Visible = true;
            RbFemenino.Visible = true;
            label11.Visible = true;
            txtIdade.Visible = true;
            label12.Visible = true;
            txtDiagnostico.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            CbMotivoChamado.Visible = true;
            CbTipoMotivoSelecionado.Visible = true;
            //CbAtendimentoPrioridade.Visible = true;

        }

        private void CbTipoMotivoSelecionado_SelectedIndexChanged(object sender, EventArgs e)
        {
            Motivo();
        }

        private void CbTipoMotivoSelecionado_TextChanged(object sender, EventArgs e)
        {
            Motivo();
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            CbOrigem.Visible = true;
            CbDestino.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            txtEnderecoDestino.Visible = true;
            txtEnderecoOrigem.Visible = true;
            label20.Visible = true;
            richTextBox1.Visible = true;
            BtnSalvar.Visible = true;

            if (Agendamento == "Sim")
            {
                CbAtendimentoPrioridade.Visible = false;
            }
            else
            {
                CbAtendimentoPrioridade.Visible = true;
            }

        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (RbFemenino.Checked)
            {
                Sexo = "F";
            }
            else
            {
                Sexo = "M";

            }
            RegistrarSolicitacao();

        }


        private void RegistrarSolicitacao()
        {
            //registrar a solicitacao de vaga
            MySqlConnection conexao = conexaoMysql.GetConexaoNote();

            if (Agendamento == "Nao")
            {
                txtAtendMarcado.Text = " ";
            }

            string sqlQuery = "insert into solicitacoes_paciente(TipoSolicitacao,DtHrdoInicio,Agendamento,DtHrAgendamento," +
            "NomeSolicitante,LocalSolicitacao,Telefone,Paciente,Genero,Idade,Diagnostico,Motivo,SubMotivo,Prioridade,Origem," +
            "EnderecoOrigem,Destino,EnderecoDestino,ObsGerais) values " +
            "('" + TipoAM + "','" + now + "','" + Agendamento + "','" + this.txtAtendMarcado.Text + "','" + this.txtNomeSolicitante.Text + "','" +
            this.CbLocalSolicita.Text + "','" + this.txtTelefone.Text + "','" + this.txtNomePaciente.Text + "','" + Sexo + "','" + this.txtIdade.Text + "','" + this.txtDiagnostico.Text + "','" +
            this.CbMotivoChamado.Text + "','" + this.CbTipoMotivoSelecionado.Text + "','" + this.CbAtendimentoPrioridade.Checked + "','" + this.CbOrigem.Text + "','" +
            this.txtEnderecoOrigem.Text + "','" + this.CbDestino.Text + "','" + this.txtEnderecoDestino.Text + "','" + this.richTextBox1.Text + "')";
            try
            {

                MySqlCommand objComm = new MySqlCommand(sqlQuery, conexao);
                MySqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();

                MessageBox.Show("Solicitação salva com sucesso !!!");

                while (MyReader2.Read())
                {
                }
            }
            finally
            {
                conexao.Close();
                this.Dispose();
            }
        }
        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Endereco()
        {
            //Consultar na tabela de enderecos
            MySqlConnection conexao = conexaoMysql.GetConexaoNote();


            string sqlQuery = "select NomeUnidade from enderecos";


            MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, conexao);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                string rowz = string.Format("{0}", row.ItemArray[0]);
                CbLocalSolicita.Items.Add(rowz);
                CbDestino.Items.Add(rowz);
                CbOrigem.Items.Add(rowz);
            }

            // MessageBox.Show("Solicitação salva com sucesso !!!");

            conexao.Close();
        }
        private void unidade_telefone()
        {
            //consulta para mostrar o telefone quando clicar no enderenco
            MySqlConnection conexao = conexaoMysql.GetConexaoNote();


            string sqlQuery2 = "select Telefone from enderecos where NomeUnidade = '" + pegaUnidade + "'";
            try
            {
                MySqlCommand objComm = new MySqlCommand(sqlQuery2, conexao);
                MySqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();

                //MessageBox.Show("Alterado com sucesso !!!");
                while (MyReader2.Read())
                {
                    txtTelefone.Text = MyReader2.GetString("Telefone");
                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private void unidade_Endereco()
        {
            //consulta para mostrar o telefone quando clicar no enderenco
            MySqlConnection conexao = conexaoMysql.GetConexaoNote();


            string sqlQuery2 = "select Endereco from enderecos where NomeUnidade = '" + pegaUnidadeEnd + "'";
            try
            {
                MySqlCommand objComm = new MySqlCommand(sqlQuery2, conexao);
                MySqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();

                //MessageBox.Show("Alterado com sucesso !!!");
                while (MyReader2.Read())
                {
                    Endereco1 = MyReader2.GetString("Endereco");
                    
                }

                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CbOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            pegaUnidadeEnd = CbOrigem.Text;
            unidade_Endereco();
            txtEnderecoOrigem.Text = Endereco1;

        }

        private void CbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            pegaUnidadeEnd = CbDestino.Text;
            unidade_Endereco();
            txtEnderecoDestino.Text = Endereco1;

        }


        private void Motivo()
        {

            //descobrir o que foi selecionado e criar uma variavel para ela
            if (CbMotivoChamado.Text == "ALTA HOSPITALAR")
            {
                pegamotivo = "ALTA_HOSPITALAR";
            }
            else if (CbMotivoChamado.Text == "AVALIAÇÃO DE MÉDICO ESPECIALISTA")
            {
                pegamotivo = "AVALIAÇÃO_DE_MÉDICO_ESPECIALISTA";
            }
            else if (CbMotivoChamado.Text == "AVALIAÇÃO DE PROFISSIONAL NÃO MÉDICO")
            {
                pegamotivo = "AVALIAÇÃO_DE_PROFISSIONAL_NÃO_MÉDICO";
            }
            else if (CbMotivoChamado.Text == "CONSULTA AGENDADA")
            {
                pegamotivo = "CONSULTA_AGENDADA";
            }
            else if (CbMotivoChamado.Text == "DEMANDAS JUDICIAIS")
            {
                pegamotivo = "DEMANDA_JUDICIAL";
            }
            else if (CbMotivoChamado.Text == "EVENTO COMEMORATIVO")
            {
                pegamotivo = "EVENTO_COMEMORATIVO_DO_MUNICÍPIO";
            }
            else if (CbMotivoChamado.Text == "EVENTO DE CULTURA, LAZER OU RELIGIÃO")
            {
                pegamotivo = "EVENTO_DE_CULTURA,_LAZER_OU_RELIGIÃO";
            }
            else if (CbMotivoChamado.Text == "EVENTO ESPORTIVO")
            {
                pegamotivo = "EVENTO_ESPORTIVO";
            }
            else if (CbMotivoChamado.Text == "EXAME AGENDADO")
            {
                pegamotivo = "EXAME_AGENDADO";
            }
            else if (CbMotivoChamado.Text == "EXAME DE URGÊNCIA")
            {
                pegamotivo = "EXAME_DE_URGÊNCIA";
            }
            else if (CbMotivoChamado.Text == "INTERNAÇÃO EM ENFERMARIA")
            {
                pegamotivo = "INTERNAÇÃO_EM_ENFERMARIA";
            }
            else if (CbMotivoChamado.Text == "INTERNAÇÃO EM UTI")
            {
                pegamotivo = "INTERNAÇÃO_EM_UTI";
            }
            else if (CbMotivoChamado.Text == "PROCEDIMENTO")
            {
                pegamotivo = "PROCEDIMENTO";
            }
            else if (CbMotivoChamado.Text == "RETORNO")
            {
                pegamotivo = "RETORNO";
            }
            else if (CbMotivoChamado.Text == "SALA VERMELHA/EMERGÊNCIA")
            {
                pegamotivo = "SALA_VERMELHA/EMERGÊNCIA";
            }
            else if (CbMotivoChamado.Text == "TRANSPORTE DE INSUMOS/PRODUTOS/MATERIAIS")
            {
                pegamotivo = "TRANSPORTE_DE_INSUMOS/PRODUTOS/MATERIAIS";
            }
            else if (CbMotivoChamado.Text == "TRANSPORTE DE PROFISSIONAIS")
            {
                pegamotivo = "TRANSPORTE_DE_PROFISSIONAIS";
            }


            //Consultar na tabela de enderecos
            MySqlConnection conexao = conexaoMysql.GetConexaoNote();


            string sqlQuery = "select " + pegamotivo + " from referencias";
            try
            {

                MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, conexao);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    string rowz = string.Format("{0}", row.ItemArray[0]);
                    CbTipoMotivoSelecionado.Items.Add(rowz);

                }

                // MessageBox.Show("Solicitação salva com sucesso !!!");
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void CbMotivoChamado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbTipoMotivoSelecionado.Items.Clear();

        }

        private void CbTipoMotivoSelecionado_Click(object sender, EventArgs e)
        {
            Motivo();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }




}



