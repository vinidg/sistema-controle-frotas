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
    public partial class ConfirmaSolicitacao : Form
    {
        string TipoAM = null;
        string Agendamento = null;
        DateTime now = DateTime.Now;
        string pegaUnidade;     //para pegar o telefone com o nome da unidade
        string pegaUnidadeEnd;  //para pegar o endereco com o nome da unidade
        string Sexo, pegamotivo;
        string Endereco1;
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
            InsercoesDoBanco IB = new InsercoesDoBanco();

            if (Agendamento == "Nao")
            {
                txtAtendMarcado.Text = " ";
            }
            VerificarPontos(this);

            try
            {
                IB.inserirSolicitacaoDoPaciente(TipoAM, now.ToString(), Agendamento, this.txtAtendMarcado.Text, this.txtNomeSolicitante.Text, this.CbLocalSolicita.Text, this.txtTelefone.Text,
                this.txtNomePaciente.Text, Sexo, this.txtIdade.Text, this.txtDiagnostico.Text, this.CbMotivoChamado.Text, this.CbTipoMotivoSelecionado.Text,
                this.CbAtendimentoPrioridade.Checked.ToString(), this.CbOrigem.Text, this.txtEnderecoOrigem.Text, this.CbDestino.Text, this.txtEnderecoDestino.Text, this.richTextBox1.Text,
                0, this.PacienteNaoAcompanhante.Checked.ToString(), System.Environment.UserName, now);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
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
            using(DAHUEEntities db = new DAHUEEntities())
            {
                CbLocalSolicita.DataSource = db.enderecos.ToList();
                CbLocalSolicita.ValueMember = "NomeUnidade";
                CbLocalSolicita.DisplayMember = "NomeUnidade";
                CbDestino.DataSource = db.enderecos.ToList();
                CbDestino.ValueMember = "NomeUnidade";
                CbDestino.DisplayMember = "NomeUnidade";
                CbOrigem.DataSource = db.enderecos.ToList();
                CbOrigem.ValueMember = "NomeUnidade";
                CbOrigem.DisplayMember = "NomeUnidade";
            }
        }
        public void unidade_telefone()
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var telefoneDoEndereco = db.enderecos
                    .Where(e => e.NomeUnidade == pegaUnidade)
                    .Select(e => e.Telefone);

                txtTelefone.Text = telefoneDoEndereco.FirstOrDefault();
             
            }
        }
        private void unidade_Endereco()
        {
            using(DAHUEEntities db = new DAHUEEntities())
            {
                var enderecoDoEnderecos = db.enderecos
                    .Where(e => e.NomeUnidade == pegaUnidadeEnd)
                    .Select(e => e.Endereco);

                Endereco1 = enderecoDoEnderecos.FirstOrDefault();
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
                pegamotivo = "AVALIACAO_DE_MEDICO_ESPECIALISTA";
            }
            else if (CbMotivoChamado.Text == "AVALIAÇÃO DE PROFISSIONAL NÃO MÉDICO")
            {
                pegamotivo = "AVALIACAO_DE_PROFISSIONAL_NAO_MEDICO";
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
                pegamotivo = "EVENTO_COMEMORATIVO_DO_MUNICIPIO";
            }
            else if (CbMotivoChamado.Text == "EVENTO DE CULTURA, LAZER OU RELIGIÃO")
            {
                pegamotivo = "EVENTO_DE_CULTURA_LAZER_OU_RELIGIAO";
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
                pegamotivo = "EXAME_DE_URGENCIA";
            }
            else if (CbMotivoChamado.Text == "INTERNAÇÃO EM ENFERMARIA")
            {
                pegamotivo = "INTERNACAO_EM_ENFERMARIA";
            }
            else if (CbMotivoChamado.Text == "INTERNAÇÃO EM UTI")
            {
                pegamotivo = "INTERNACAO_EM_UTI";
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
                pegamotivo = "SALA_VERMELHA_EMERGENCIA";
            }
            else if (CbMotivoChamado.Text == "TRANSPORTE DE INSUMOS/PRODUTOS/MATERIAIS")
            {
                pegamotivo = "TRANSPORTE_DE_INSUMOS_PRODUTOS_MATERIAIS";
            }
            else if (CbMotivoChamado.Text == "TRANSPORTE DE PROFISSIONAIS")
            {
                pegamotivo = "TRANSPORTE_DE_PROFISSIONAIS";
            }

            using(DAHUEEntities db = new DAHUEEntities())
            {
                CbTipoMotivoSelecionado.DataSource = db.referencias.ToList();
                CbTipoMotivoSelecionado.ValueMember = pegamotivo;
                CbTipoMotivoSelecionado.DisplayMember = pegamotivo;
            }
     
        }

        private void CbMotivoChamado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbTipoMotivoSelecionado.DataSource = null; 
            CbTipoMotivoSelecionado.ValueMember = "";
            CbTipoMotivoSelecionado.DisplayMember = "";

            if (CbMotivoChamado.Text == "INTERNAÇÃO EM UTI" || CbMotivoChamado.Text == "SALA VERMELHA/EMERGÊNCIA" || CbMotivoChamado.Text == "")
            {
                BtnAvancada.PerformClick();
                BtnAvancada.Enabled = false;
                BtnBasica.Enabled = false;
            }
            else
            {
                label2.Visible = true;
                Btnagendanao.Visible = true;
                Btnagendasim.Visible = true;
                TipoAM = "";
                BtnAvancada.Enabled = true;
                BtnBasica.Enabled = true;
                BtnAvancada.BackColor = Color.PaleTurquoise;
                BtnAvancada.ForeColor = Color.Teal;
                BtnBasica.ForeColor = Color.Teal;
                BtnBasica.BackColor = Color.PaleTurquoise;
            }

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

            using (DAHUEEntities db = new DAHUEEntities())
            {
                var autoCompletar = db.solicitacoes_paciente
                    .Select(a => a.Paciente).Distinct().ToArray();
                AutoCompleteStringCollection source = new AutoCompleteStringCollection();
                source.AddRange(autoCompletar);
                txtNomePaciente.AutoCompleteCustomSource = source;

            }
        }

        private void txtNomePaciente_KeyUp(object sender, KeyEventArgs e)
        {
            /*          using (DAHUEEntities db = new DAHUEEntities())
                      {
                          var autoCompletarDadosPaciente = db.solicitacoes_paciente
                              .Where(a => a.Paciente == txtNomePaciente.Text)
                              .Select(a => new {a.Genero, a.Idade}).FirstOrDefault();
                               
                              if (autoCompletarDadosPaciente.Genero == "M")
                              {
                                  RbFemenino.Checked = false;
                                  RbMasculino.Checked = true;
                              }
                              else
                              {
                                  RbMasculino.Checked = false;
                                  RbFemenino.Checked = true;
                              }


                              txtIdade.Text = autoCompletarDadosPaciente.Idade;
                       }*/
        }

    }
}



