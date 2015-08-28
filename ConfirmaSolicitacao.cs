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
    public partial class ConfirmaSolicitacao : Form
    {
        string TipoAM = null;
        string Agendamento = null;
        DateTime now = DateTime.Now;
        string pegaUnidade;     //para pegar o telefone com o nome da unidade
        string pegaUnidadeEnd;  //para pegar o endereco com o nome da unidade
        string Sexo, pegamotivo;
        string Endereco1;
        string rowz;
        public ConfirmaSolicitacao()
        {
            InitializeComponent();
            txtAtendMarcado.Text = now.ToString();
            StartPosition = FormStartPosition.CenterScreen;
            Endereco();
            label3.Visible = false;
            txtAtendMarcado.Visible = false;
            Limpar();
            AutoCompletar();
        }

        private void NovaSolicitacao_Load(object sender, EventArgs e)
        {

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
                BtnBasica.ForeColor = Color.Teal;
                BtnAvancada.ForeColor = Color.Teal;
                BtnAvancada.BackColor = Color.PaleTurquoise;
            }
            BtnAvancada.BackColor = Color.PaleTurquoise;
            BtnBasica.BackColor = Color.Teal;
            BtnBasica.ForeColor = Color.PaleTurquoise;
            BtnAvancada.ForeColor = Color.Teal;
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
                BtnAvancada.ForeColor = Color.Teal;
                BtnBasica.ForeColor = Color.Teal;
                BtnBasica.BackColor = Color.PaleTurquoise;
            }
            BtnBasica.BackColor = Color.PaleTurquoise;
            BtnAvancada.BackColor = Color.Teal;
            BtnAvancada.ForeColor = Color.PaleTurquoise;
            BtnBasica.ForeColor = Color.Teal;
        }


        public void Limpar()
        {
            /*  label2.Visible = false;
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
            Btnagendasim.BackColor = Color.PaleTurquoise;
            Btnagendanao.BackColor = Color.PaleTurquoise;
            BtnAvancada.BackColor = Color.PaleTurquoise;
            BtnBasica.BackColor = Color.PaleTurquoise;
            Btnagendasim.ForeColor = Color.DimGray;
            Btnagendanao.ForeColor = Color.DimGray;
            BtnAvancada.ForeColor = Color.DimGray;
            BtnBasica.ForeColor = Color.DimGray;
            */

            txtAtendMarcado.Text = "";
            txtNomeSolicitante.Text = "";
            CbLocalSolicita.Text = "";
            txtTelefone.Text = "";
            txtNomePaciente.Text = "";
            RbFemenino.Checked = false;
            RbMasculino.Checked = false;
            txtIdade.Text = "";
            txtDiagnostico.Text = "";
            CbMotivoChamado.Text = "";
            CbTipoMotivoSelecionado.Text = "";
            CbAtendimentoPrioridade.Checked = false;
            CbOrigem.Text = "";
            CbDestino.Text = "";
            txtEnderecoOrigem.Text = "";
            txtEnderecoDestino.Text = "";
            richTextBox1.Text = "";

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
            if (Btnagendasim.BackColor == Color.PaleTurquoise)
            {
                Btnagendasim.BackColor = Color.PaleTurquoise;
                Btnagendasim.ForeColor = Color.Teal;
                Btnagendanao.ForeColor = Color.Teal;
                Btnagendanao.BackColor = Color.PaleTurquoise;

            }

            Btnagendasim.BackColor = Color.PaleTurquoise;
            Btnagendanao.BackColor = Color.Teal;
            Btnagendanao.ForeColor = Color.PaleTurquoise;
            Btnagendasim.ForeColor = Color.Teal;
        }

        private void Btnagendasim_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            txtAtendMarcado.Visible = true;
            txtAtendMarcado.Focus();
            txtAtendMarcado.Text = DateTime.Now.ToString();
            Agendamento = "Sim";

            if (Btnagendanao.BackColor == Color.PaleTurquoise)
            {
                Btnagendanao.BackColor = Color.PaleTurquoise;
                Btnagendanao.ForeColor = Color.Teal;
                Btnagendasim.ForeColor = Color.Teal;
                Btnagendasim.BackColor = Color.PaleTurquoise;

            }
            Btnagendanao.BackColor = Color.PaleTurquoise;
            Btnagendasim.BackColor = Color.Teal;
            Btnagendasim.ForeColor = Color.PaleTurquoise;
            Btnagendanao.ForeColor = Color.Teal;
        }

        private void CbLocalSolicita_SelectedIndexChanged(object sender, EventArgs e)
        {



            pegaUnidade = CbLocalSolicita.Text;
            unidade_telefone();
        }


        private void CbTipoMotivoSelecionado_SelectedIndexChanged(object sender, EventArgs e)
        {
            Motivo();
        }

        private void CbTipoMotivoSelecionado_TextChanged(object sender, EventArgs e)
        {
            Motivo();

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
            else if (RbMasculino.Checked)
            {
                Sexo = "M";

            }

            if (Agendamento == "" || TipoAM == "" || Agendamento == null || TipoAM == null)
            {

                MessageBox.Show("Marque a opção do tipo de ambulancia ou se é agendado !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (txtNomeSolicitante.Text == "" ||
            CbLocalSolicita.Text == "" ||
            txtTelefone.Text == "" ||
            txtNomePaciente.Text == "" ||
            txtIdade.Text == "" ||
            txtDiagnostico.Text == "" ||
            CbMotivoChamado.Text == "" ||
            Sexo == "" ||
            CbTipoMotivoSelecionado.Text == "" ||
            CbOrigem.Text == "" ||
            CbDestino.Text == "" ||
            txtEnderecoOrigem.Text == "" ||
            txtEnderecoDestino.Text == "")
            {

                MessageBox.Show("Verifique se algum campo esta vazio ou desmarcado !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                RegistrarSolicitacao();
            }





        }


        private void RegistrarSolicitacao()
        {
            //registrar a solicitacao de vaga
            SqlConnection conexao = ConexaoSqlServer.GetConexao();

            if (Agendamento == "Nao")
            {
                txtAtendMarcado.Text = " ";
            }
            VerificarPontos(this);
            string sqlQuery = "insert into solicitacoes_paciente(TipoSolicitacao,DtHrdoInicio,Agendamento,DtHrAgendamento," +
            "NomeSolicitante,LocalSolicitacao,Telefone,Paciente,Genero,Idade,Diagnostico,Motivo,SubMotivo,Prioridade,Origem," +
            "EnderecoOrigem,Destino,EnderecoDestino,ObsGerais,AmSolicitada) VALUES " +
            "('" + TipoAM + "','" + now + "','" + Agendamento + "','" + this.txtAtendMarcado.Text + "','" + this.txtNomeSolicitante.Text + "','" +
            this.CbLocalSolicita.Text + "','" + this.txtTelefone.Text + "','" + this.txtNomePaciente.Text + "','" + Sexo + "','" + this.txtIdade.Text + "','" + this.txtDiagnostico.Text + "','" +
            this.CbMotivoChamado.Text + "','" + this.CbTipoMotivoSelecionado.Text + "','" + this.CbAtendimentoPrioridade.Checked + "','" + this.CbOrigem.Text + "','" +
            this.txtEnderecoOrigem.Text + "','" + this.CbDestino.Text + "','" + this.txtEnderecoDestino.Text + "','" + this.richTextBox1.Text + "','" + 0 + "')";

            try
            {

                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                // MySqlDataReader MyReader2;

                objComm.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
                MessageBox.Show("Solicitação salva com sucesso !!!");
                this.Dispose();
            }

        }
        private void VerificarPontos(Control container)
        {
            foreach (Control objeto in container.Controls)
            {
                if (objeto is TextBox)
                {
                    if (objeto.Text.IndexOf("'") == -1)
                        continue;
                    else
                        throw new Exception("Caracter ' é inválido!");

                }
                else if (objeto.Controls.Count > 0)
                {
                    VerificarPontos(objeto);
                }
            }
        }
        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        public void Endereco()
        {
            //Consultar na tabela de enderecos
            SqlConnection conexao = ConexaoSqlServer.GetConexao();


            string sqlQuery = "select NomeUnidade from enderecos";


            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conexao);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                rowz = string.Format("{0}", row.ItemArray[0]);
                CbLocalSolicita.Items.Add(rowz);
                CbDestino.Items.Add(rowz);
                CbOrigem.Items.Add(rowz);
            }

            // MessageBox.Show("Solicitação salva com sucesso !!!");

            conexao.Close();
        }
        public void unidade_telefone()
        {
            //consulta para mostrar o telefone quando clicar no enderenco
            SqlConnection conexao = ConexaoSqlServer.GetConexao();


            string sqlQuery2 = "select Telefone from enderecos where NomeUnidade = '" + pegaUnidade + "'";
            try
            {
                SqlCommand objComm = new SqlCommand(sqlQuery2, conexao);
                SqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();

                //MessageBox.Show("Alterado com sucesso !!!");
                while (MyReader2.Read())
                {
                    txtTelefone.Text = MyReader2.GetString(0);
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
            SqlConnection conexao = ConexaoSqlServer.GetConexao();


            string sqlQuery2 = "select Endereco from enderecos where NomeUnidade = '" + pegaUnidadeEnd + "'";
            try
            {
                SqlCommand objComm = new SqlCommand(sqlQuery2, conexao);
                SqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();

                //MessageBox.Show("Alterado com sucesso !!!");
                while (MyReader2.Read())
                {
                    Endereco1 = MyReader2.GetString(0);

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
                pegamotivo = "[INTERNAÇÃO_EM_ENFERMARIA]";
            }
            else if (CbMotivoChamado.Text == "INTERNAÇÃO EM UTI")
            {
                pegamotivo = "[INTERNAÇÃO_EM_UTI]";
            }
            else if (CbMotivoChamado.Text == "PROCEDIMENTO")
            {
                pegamotivo = "[PROCEDIMENTO]";
            }
            else if (CbMotivoChamado.Text == "RETORNO")
            {
                pegamotivo = "RETORNO";
            }
            else if (CbMotivoChamado.Text == "SALA VERMELHA/EMERGÊNCIA")
            {
                pegamotivo = "[SALA_VERMELHA/EMERGÊNCIA]";
            }
            else if (CbMotivoChamado.Text == "TRANSPORTE DE INSUMOS/PRODUTOS/MATERIAIS")
            {
                pegamotivo = "[TRANSPORTE_DE_INSUMOS/PRODUTOS/MATERIAIS]";
            }
            else if (CbMotivoChamado.Text == "TRANSPORTE DE PROFISSIONAIS")
            {
                pegamotivo = "TRANSPORTE_DE_PROFISSIONAIS";
            }


            //Consultar na tabela de enderecos
            SqlConnection conexao = ConexaoSqlServer.GetConexao();


            string sqlQuery = "select " + pegamotivo + " from referencias";
            try
            {

                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conexao);
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

        private void AutoCompletar()
        {
            RbFemenino.Checked = false;
            RbMasculino.Checked = false;
            txtIdade.Text = "";

            SqlConnection conexao = ConexaoSqlServer.GetConexao();
            string sqlQuery = "SELECT Paciente, Genero, Idade FROM solicitacoes_paciente";
            try
            {

                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                SqlDataReader MyReader;

                MyReader = objComm.ExecuteReader();


                while (MyReader.Read())
                {
                   txtNomePaciente.AutoCompleteCustomSource.Add(MyReader["Paciente"].ToString());
   
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

        private void txtNomePaciente_KeyUp(object sender, KeyEventArgs e)
        {
            SqlConnection conexao = ConexaoSqlServer.GetConexao();
            string sqlQuery = "SELECT Genero, Idade FROM solicitacoes_paciente WHERE Paciente = '" + txtNomePaciente.Text + "'";
            try
            {

                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                SqlDataReader MyReader;

                MyReader = objComm.ExecuteReader();


                while (MyReader.Read())
                {

                    if (MyReader["Genero"].ToString() == "M")
                    {
                        RbFemenino.Checked = false;
                        RbMasculino.Checked = true;
                    }
                    else
                    {
                        RbMasculino.Checked = false;
                        RbFemenino.Checked = true;
                    }


                    txtIdade.Text = MyReader["Idade"].ToString();
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



