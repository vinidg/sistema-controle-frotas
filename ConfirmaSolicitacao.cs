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

namespace Sistema_Controle
{
    public partial class ConfirmaSolicitacao : Form
    {
        string TipoAM = null;
        string Agendamento = null;
        string pegaUnidade;     //para pegar o telefone com o nome da unidade
        string pegaUnidadeEnd;  //para pegar o endereco com o nome da unidade
        string Sexo, pegamotivo;
        string Endereco1;
        public ConfirmaSolicitacao(int idPaciente)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Endereco();
            label3.Visible = false;
            dataAgendamento.Visible = false;
            AutoCompletar();
            if(idPaciente != 0)
            {
                PreencherCampos(idPaciente);
            }
        }
<<<<<<< HEAD
=======
        private void PreencherCampos(int id)
        {
            using(DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from sp in db.solicitacoes_paciente
                             where sp.idPaciente_Solicitacoes == id
                             select sp).FirstOrDefault();

                CbLocalSolicita.Text = query.LocalSolicitacao;
                txtTelefone.Text = query.Telefone;
                txtNomePaciente.Text = query.Paciente;
                if(query.Genero == "M")
                {
                    RbMasculino.Checked = false;
                }
                else
                {
                    RbFemenino.Checked = true;
                }
                txtIdade.Text = query.Idade;
                txtDiagnostico.Text = query.Diagnostico;
                CbMotivoChamado.Text = query.Motivo;
                CbTipoMotivoSelecionado.Text = query.SubMotivo;
                Prioridade.Text = query.Prioridade;
                CbOrigem.Text = query.Origem;
                txtEnderecoOrigem.Text = query.EnderecoOrigem;
                CbDestino.Text = query.Destino;
                txtEnderecoDestino.Text = query.EnderecoDestino;
                Obs.Text = query.ObsGerais;
            }
        }
>>>>>>> EntityInsert

        private void BtnBasica_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            Btnagendanao.Visible = true;
            Btnagendasim.Visible = true;
            TipoAM = "Basica";


            if (BtnAvancada.BackColor == Color.FromArgb(69, 173, 168))
            {
                BtnBasica.BackColor = Color.FromArgb(229, 252, 194);
                BtnBasica.ForeColor = Color.FromArgb(69, 173, 168);
                BtnAvancada.ForeColor = Color.FromArgb(69, 173, 168);
                BtnAvancada.BackColor = Color.FromArgb(229, 252, 194);
            }
            BtnAvancada.BackColor = Color.FromArgb(229, 252, 194);
            BtnBasica.BackColor = Color.FromArgb(69, 173, 168);
            BtnBasica.ForeColor = Color.FromArgb(229, 252, 194);
            BtnAvancada.ForeColor = Color.FromArgb(69, 173, 168);
        }
        private void BtnAvancada_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            Btnagendanao.Visible = true;
            Btnagendasim.Visible = true;
            TipoAM = "Avancada";

            if (BtnBasica.BackColor == Color.FromArgb(69, 173, 168))
            {
                BtnAvancada.BackColor = Color.FromArgb(229, 252, 194);
                BtnAvancada.ForeColor = Color.FromArgb(69, 173, 168);
                BtnBasica.ForeColor = Color.FromArgb(69, 173, 168);
                BtnBasica.BackColor = Color.FromArgb(229, 252, 194);
            }
            BtnBasica.BackColor = Color.FromArgb(229, 252, 194);
            BtnAvancada.BackColor = Color.FromArgb(69, 173, 168);
            BtnAvancada.ForeColor = Color.FromArgb(229, 252, 194);
            BtnBasica.ForeColor = Color.FromArgb(69, 173, 168);
        }


        public void Limpar()
        {
            RbFemenino.Checked = false;
            RbMasculino.Checked = false;
            TipoAM = "";
            Agendamento = "";
            Obs.Text = "";
            label3.Visible = false;
            dataAgendamento.Visible = false;

            Btnagendasim.BackColor = Color.FromArgb(69, 173, 168);
            Btnagendasim.ForeColor = Color.FromArgb(229, 252, 194);
            Btnagendanao.BackColor = Color.FromArgb(69, 173, 168);
            Btnagendanao.ForeColor = Color.FromArgb(229, 252, 194);

            BtnAvancada.BackColor = Color.FromArgb(69, 173, 168);
            BtnAvancada.ForeColor = Color.FromArgb(229, 252, 194);
            BtnBasica.BackColor = Color.FromArgb(69, 173, 168);
            BtnBasica.ForeColor = Color.FromArgb(229, 252, 194);
        }

        private void Btnagendanao_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            dataAgendamento.Visible = false;
            label4.Visible = true;
            label5.Visible = true;
            txtNomeSolicitante.Visible = true;
            label6.Visible = true;
            CbLocalSolicita.Visible = true;
            label7.Visible = true;
            txtTelefone.Visible = true;
            Agendamento = "Nao";
            if (Btnagendasim.BackColor == Color.FromArgb(69, 173, 168))
            {
                Btnagendasim.BackColor = Color.FromArgb(229, 252, 194);
                Btnagendasim.ForeColor = Color.FromArgb(69, 173, 168);
                Btnagendanao.BackColor = Color.FromArgb(69, 173, 168);
                Btnagendanao.ForeColor = Color.FromArgb(229, 252, 194);

            }

            Btnagendasim.BackColor = Color.FromArgb(229, 252, 194);
            Btnagendanao.BackColor = Color.FromArgb(69, 173, 168);
            Btnagendasim.ForeColor = Color.FromArgb(69, 173, 168);
            Btnagendanao.ForeColor = Color.FromArgb(229, 252, 194);
        }

        private void Btnagendasim_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            dataAgendamento.Visible = true;
            dataAgendamento.Focus();
            Agendamento = "Sim";

            if (Btnagendanao.BackColor == Color.FromArgb(69, 173, 168))
            {
                Btnagendanao.BackColor = Color.FromArgb(229, 252, 194);
                Btnagendanao.ForeColor = Color.FromArgb(69, 173, 168);
                Btnagendasim.ForeColor = Color.FromArgb(69, 173, 168);
                Btnagendasim.BackColor = Color.FromArgb(229, 252, 194);

            }
            Btnagendanao.BackColor = Color.FromArgb(229, 252, 194);
            Btnagendasim.BackColor = Color.FromArgb(69, 173, 168);
            Btnagendasim.ForeColor = Color.FromArgb(229, 252, 194);
            Btnagendanao.ForeColor = Color.FromArgb(69, 173, 168);
        }

        private void CbLocalSolicita_SelectedIndexChanged(object sender, EventArgs e)
        {
            pegaUnidade = CbLocalSolicita.Text;
            unidade_telefone();
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
                Limpar();
                ClearTextBoxes();
                ClearComboBox();
            }

        }


        private void RegistrarSolicitacao()
        {
            InsercoesDoBanco IB = new InsercoesDoBanco();

            VerificarPontos(this);

            try
            {
                IB.inserirSolicitacaoDoPaciente(TipoAM, DateTime.Now, Agendamento, this.dataAgendamento.Value, this.txtNomeSolicitante.Text, this.CbLocalSolicita.Text, this.txtTelefone.Text,
                this.txtNomePaciente.Text, Sexo, this.txtIdade.Text, this.txtDiagnostico.Text, this.CbMotivoChamado.Text, this.CbTipoMotivoSelecionado.Text,
                this.Prioridade.Text, this.CbOrigem.Text, this.txtEnderecoOrigem.Text, this.CbDestino.Text, this.txtEnderecoDestino.Text, this.Obs.Text,
                0, System.Environment.UserName);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
            ClearComboBox();
            ClearTextBoxes();
        }

        public void Endereco()
        {
            using(DAHUEEntities db = new DAHUEEntities())
            {
                CbLocalSolicita.DataSource = db.enderecos.OrderBy(x => x.NomeUnidade).ToList();
                CbLocalSolicita.ValueMember = "NomeUnidade";
                CbLocalSolicita.DisplayMember = "NomeUnidade";
                CbDestino.DataSource = db.enderecos.OrderBy(x => x.NomeUnidade).ToList();
                CbDestino.ValueMember = "NomeUnidade";
                CbDestino.DisplayMember = "NomeUnidade";
                CbOrigem.DataSource = db.enderecos.OrderBy(x => x.NomeUnidade).ToList();
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

            if (CbMotivoChamado.Text == "INTERNAÇÃO EM UTI" || CbMotivoChamado.Text == "SALA VERMELHA/EMERGÊNCIA")
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
                BtnAvancada.BackColor = Color.FromArgb(69, 173, 168);
                BtnAvancada.ForeColor = Color.FromArgb(229, 252, 194);
                BtnBasica.ForeColor = Color.FromArgb(229, 252, 194);
                BtnBasica.BackColor = Color.FromArgb(69, 173, 168);
            }
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

        private void txtIdade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        private void ClearComboBox()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is ComboBox)
                        (control as ComboBox).SelectedIndex = -1;
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

    }
}



