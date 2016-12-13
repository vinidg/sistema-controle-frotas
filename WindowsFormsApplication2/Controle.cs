using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using db_transporte_sanitario;
using System.Data.Entity.SqlServer;

namespace Sistema_Controle
{
    public partial class CONTROLE : Form
    {
        public CONTROLE()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            pegarDadosDasAmbulancias();
            contarSolicitacao();
            contarSolicitacoesAgendadas();
            contarSolicitacoesAgendadasPendentes();
            Re.Text = System.Environment.UserName;

            Timer();

            this.Text = "Sistema de Controle de Ambulancias - " + DateTime.Now.Year.ToString() + ". Versão: " + appverion;
            label1.Text = "CONTROLE DE AMBULÂNCIAS - " + DateTime.Now.Year.ToString();
        }
        int numeroAgendamentos;
        Version appverion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        public void pegarDadosDasAmbulancias()
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var queryUsb = (from am in db.ambulancia
                                join sa in db.solicitacoes_ambulancias
                                on new { idAmbulanciaSol = am.idAmbulancia, SolicitacaoConcluida = 0 }
                                equals new { sa.idAmbulanciaSol, SolicitacaoConcluida = (int)sa.SolicitacaoConcluida } into sa_join
                                from sa in sa_join.DefaultIfEmpty()
                                join sp in db.solicitacoes_paciente
                                on new { idSolicitacoesPacientes = (int)sa.idSolicitacoesPacientes }
                                equals new { idSolicitacoesPacientes = sp.idPaciente_Solicitacoes } into sp_join
                                from sp in sp_join.DefaultIfEmpty()
                                where am.TipoAM == "BASICO" && am.Desativado == 0
                                orderby am.NomeAmbulancia ascending
                                select new
                                {
                                    am.idAmbulancia,
                                    Ambulancia = am.NomeAmbulancia,
                                    Status = sa.Status,
                                    StatusE = am.StatusAmbulancia,
                                    idPaciente = sa.idSolicitacoesPacientes,
                                    Paciente = sp.Paciente,
                                    Idade = sp.Idade,
                                    Origem = sp.Origem,
                                    Destino = sp.Destino
                                }).ToList();

                listaUsb.DataSource = queryUsb;
                listaUsb.ClearSelection();

                var queryUsa = (from am in db.ambulancia
                                join sa in db.solicitacoes_ambulancias
                                on new { idAmbulanciaSol = am.idAmbulancia, SolicitacaoConcluida = 0 }
                                equals new { sa.idAmbulanciaSol, SolicitacaoConcluida = (int)sa.SolicitacaoConcluida } into sa_join
                                from sa in sa_join.DefaultIfEmpty()
                                join sp in db.solicitacoes_paciente on new { idSolicitacoesPacientes = (int)sa.idSolicitacoesPacientes } equals new { idSolicitacoesPacientes = sp.idPaciente_Solicitacoes } into sp_join
                                from sp in sp_join.DefaultIfEmpty()
                                where am.TipoAM == "AVANCADO" && am.Desativado == 0
                                orderby am.NomeAmbulancia ascending
                                select new
                                {
                                    am.idAmbulancia,
                                    Ambulancia = am.NomeAmbulancia,
                                    Status = sa.Status,
                                    StatusE = am.StatusAmbulancia,
                                    idPaciente = sa.idSolicitacoesPacientes,
                                    Paciente = sp.Paciente,
                                    Idade = sp.Idade,
                                    Origem = sp.Origem,
                                    Destino = sp.Destino
                                }).ToList();

                listaUsa.DataSource = queryUsa;
                listaUsa.ClearSelection();

            }
            listaUsa.Columns[0].Visible = false;
            listaUsb.Columns[0].Visible = false;
            listaUsa.Columns["idPaciente"].Visible = false;
            listaUsb.Columns["idPaciente"].Visible = false;
            listaUsa.Columns["StatusE"].Width = 0;
            listaUsb.Columns["StatusE"].Width = 0;
            coresDasTabelas();

            this.listaUsa.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.listaUsa.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.listaUsa.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.listaUsa.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.listaUsa.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.listaUsa.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.listaUsb.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.listaUsb.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.listaUsb.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.listaUsb.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.listaUsb.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.listaUsb.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        #region NumeroDeSolicitacoes

        private void contarSolicitacao()
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from sp in db.solicitacoes_paciente
                             where sp.AmSolicitada == 0 && sp.Agendamento == "Nao" &&
                             sp.Registrado == "Sim"
                             select sp.idPaciente_Solicitacoes).Count();

                txtSolicitacoes.Text = query.ToString();
            }

        }
        private void contarSolicitacoesAgendadas()
        {
            //CONTA AS solicitacoes agendadas
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from sp in db.solicitacoes_paciente
                             join saa in db.solicitacoes_agendamentos
                             on sp.idReagendamento equals saa.idSolicitacaoAgendamento
                             where sp.Agendamento == "Sim" &&
                             sp.AmSolicitada == 0 &&
                             sp.Registrado == "Sim" &&
                             SqlFunctions.DateDiff("day", DateTime.Now, saa.DtHrAgendamento) == 0
                             select sp.idPaciente_Solicitacoes).Count();

                txtAgendadasHoje.Text = query.ToString();
            }
        }
        private void contarSolicitacoesAgendadasPendentes()
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from sp in db.solicitacoes_paciente
                             where sp.AmSolicitada == 0 && sp.Agendamento == "Sim"
                             && sp.Registrado == "Aguardando resposta do controle"
                             select sp.idPaciente_Solicitacoes).Count();

                txtAgendasPendentes.Text = query.ToString();
            }

        }

        #endregion

        #region Timer
        public void Timer()
        {
            timer1.Stop();
            timer1.Interval = 5000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            pegarDadosDasAmbulancias();
            contarSolicitacao();
            contarSolicitacoesAgendadasPendentes();
            atualizadorParaNotificador();
            //alertarNovosAgendamentos();
            //numeroAgendamentos = Convert.ToInt32(txtAgendasPendentes.Text);
        }


        #endregion

        #region EventosCliks
        private void BtnNew_Click(object sender, EventArgs e)
        {
            ConfirmaSolicitacao frm = new ConfirmaSolicitacao(0);
            frm.ShowDialog();
        }
        private void txtSolicitacoes_Click(object sender, EventArgs e)
        {
            Solicitacoes Sol = new Solicitacoes(0, "");
            Sol.ShowDialog();
            if (txtSolicitacoes.Focus())
            {
                label1.Focus();
            }
        }
        private void txtSolicitacoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSolicitacoes.Focus())
            {
                label1.Focus();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            contarSolicitacao();
            contarSolicitacoesAgendadas();
            contarSolicitacoesAgendadasPendentes();
        }
        private void atualizadorParaNotificador()
        {
            Update update = new Update();
            update.up();
            if (update.Avisar == true)
            {
                avisandoAoControle.Visible = true;
                avisandoAoControle.Text = "Nova atualização no sistema de Controle de Ambulancias. Reinicie o sistema !!!";
                Atualizar.Visible = true;
            }
        }
        private void txtAgendadasHoje_Click(object sender, EventArgs e)
        {
            Solicitacoes solicitacoes = new Solicitacoes(0, "");
            solicitacoes.ShowDialog();
            if (txtAgendadasHoje.Focus())
            {
                label1.Focus();
            }
        }
        private void txtAgendadasHoje_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtAgendadasHoje.Focus())
            {
                label1.Focus();
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Atualizacao atualizacao = new Atualizacao();
            atualizacao.ShowDialog();
        }
        private void Consultar_Click(object sender, EventArgs e)
        {
            Consulta consulta = new Consulta();
            consulta.ShowDialog();
        }
        private void Editar_Click(object sender, EventArgs e)
        {
            EditarAmbulancias ea = new EditarAmbulancias();
            ea.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Update updatando = new Update();
            updatando.up();
            if (updatando.Yn == true)
            {
                Environment.Exit(1);
            }
        }
        private void listaUsa_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string idAM = listaUsa.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (listaUsa.Rows[e.RowIndex].Cells["idPaciente"].Value != null)
                {
                    string idPaciente = listaUsa.Rows[e.RowIndex].Cells["idPaciente"].Value.ToString();
                    Status status = new Status(Convert.ToInt32(idAM), Convert.ToInt32(idPaciente));
                    status.ShowDialog();
                }
                else
                {
                    Status status = new Status(Convert.ToInt32(idAM), 0);
                    status.ShowDialog();
                }
            }
        }
        private void listaUsb_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string idAM = listaUsb.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (listaUsb.Rows[e.RowIndex].Cells["idPaciente"].Value != null)
                {
                    string idPaciente = listaUsb.Rows[e.RowIndex].Cells["idPaciente"].Value.ToString();

                    Status sta = new Status(Convert.ToInt32(idAM), Convert.ToInt32(idPaciente));
                    sta.ShowDialog();
                }
                else
                {

                    Status sta = new Status(Convert.ToInt32(idAM), 0);
                    sta.ShowDialog();
                }
            }
        }
        private void txtAgendasPendentes_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtAgendasPendentes.Focus())
            {
                label1.Focus();
            }
        }
        private void txtAgendasPendentes_Click(object sender, EventArgs e)
        {

            RespostaDeAmbulancias ra = new RespostaDeAmbulancias();
            ra.ShowDialog();
            if (txtAgendasPendentes.Focus())
            {
                label1.Focus();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Solicitacoes solicitacoes = new Solicitacoes(0, "");
            solicitacoes.ShowDialog();
        }
        private void AgendaPendentes_Click(object sender, EventArgs e)
        {
            RespostaDeAmbulancias ra = new RespostaDeAmbulancias();
            ra.ShowDialog();
        }
        private void EnderecosEditar_Click(object sender, EventArgs e)
        {
            Enderecos en = new Enderecos();
            en.ShowDialog();
        }
        #endregion

        #region Eventos
        private void txtAgendasPendentes_TextChanged(object sender, EventArgs e)
        {
            if (txtAgendasPendentes.Focus())
            {
                label1.Focus();
            }
        }

        private void coresDasTabelas()
        {

            foreach (DataGridViewRow row in listaUsb.Rows)
            {

                string RowType = row.Cells[3].Value.ToString();

                if (RowType == "BLOQUEADA")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(0, 122, 181);
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (RowType == "OCUPADA")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(224, 62, 54);
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (RowType == "DISPONIVEL")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(46, 172, 109);
                    row.DefaultCellStyle.ForeColor = Color.White;
                }

            }
            foreach (DataGridViewRow row in listaUsb.Rows)
            {
                string RowType2 = "";
                if (row.Cells[2].Value != null)
                {
                    RowType2 = row.Cells[2].Value.ToString();
                }
                if (RowType2 == "Equipe Liberada do Destino")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(241, 237, 99);
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            foreach (DataGridViewRow row in listaUsa.Rows)
            {

                string RowType = row.Cells[3].Value.ToString();

                if (RowType == "BLOQUEADA")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(0, 122, 181);
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (RowType == "OCUPADA")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(224, 62, 54);
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (RowType == "DISPONIVEL")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(46, 172, 109);
                    row.DefaultCellStyle.ForeColor = Color.White;
                }

            }
            foreach (DataGridViewRow row in listaUsa.Rows)
            {
                string RowType2 = "";
                if (row.Cells[2].Value != null)
                {
                    RowType2 = row.Cells[2].Value.ToString();
                }
                if (RowType2 == "Equipe Liberada do Destino")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(241, 237, 99);
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }


        }
        #endregion
        private void alertarNovosAgendamentos()
        {
            if (Convert.ToInt32(txtAgendasPendentes.Text) > numeroAgendamentos)
            {
                int novos = Convert.ToInt32(txtAgendasPendentes.Text) - numeroAgendamentos;
                MessageBox.Show(novos + " novos agendamentos solicitados !", "Novos agendamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                numeroAgendamentos = Convert.ToInt32(txtAgendasPendentes.Text);
            }
        }
    }

}




