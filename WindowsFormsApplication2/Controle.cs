using AutoUpdaterDotNET;
using db_transporte_sanitario;
using System;
using System.Data.Entity.SqlServer;
using System.Data.Objects;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Sistema_Controle
{
    public partial class CONTROLE : Form
    {
        int numeroAgendamentos;
        Version appverion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        public CONTROLE()
        {
            InitializeComponent();
        }
        private void CONTROLE_Load(object sender, EventArgs e)
        {
            AutoUpdater.CurrentCulture = CultureInfo.CreateSpecificCulture("pt");
            AutoUpdater.Start("http://vinidg.github.io/update_sistemas/update_controle.xml");

            StartPosition = FormStartPosition.CenterScreen;
            pegarDadosDasAmbulanciasUsa();
            pegarDadosDasAmbulanciasUsb();
            contarSolicitacao();
            contarSolicitacoesAgendadas();
            contarSolicitacoesAgendadasPendentes();
            Re.Text = System.Environment.UserName;

            Timer();

            this.Text = "Sistema de Controle de Ambulancias - " + DateTime.Now.Year.ToString() + ". Versão: " + appverion;
            label1.Text = "CONTROLE DE AMBULÂNCIAS - " + DateTime.Now.Year.ToString();
        }

        public void pegarDadosDasAmbulanciasUsb()
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
                //var queryUsb = (from am in db.ambulancia
                //                join sa in db.solicitacoes_ambulancias
                //                on new { idAmbulanciaSol = am.idAmbulancia, SolicitacaoConcluida = 0 }
                //                equals new { sa.idAmbulanciaSol, SolicitacaoConcluida = (int)sa.SolicitacaoConcluida } into sa_join
                //                from sa in sa_join.DefaultIfEmpty()
                //                join sp in db.solicitacoes_paciente
                //                on new { idSolicitacoesPacientes = (int)sa.idSolicitacoesPacientes }
                //                equals new { idSolicitacoesPacientes = sp.idPaciente_Solicitacoes } into sp_join
                //                from sp in sp_join.DefaultIfEmpty()
                //                where am.TipoAM == "BASICO" && am.Desativado == 0
                //                orderby am.NomeAmbulancia ascending
                //                select new
                //                {
                //                    am.idAmbulancia,
                //                    Ambulancia = am.NomeAmbulancia,
                //                    Status = sa.Status,
                //                    StatusE = am.StatusAmbulancia,
                //                    idPaciente = sa.idSolicitacoesPacientes,
                //                    Paciente = sp.Paciente,
                //                    Idade = sp.Idade,
                //                    Origem = sp.Origem,
                //                    Destino = sp.Destino,
                //                    Bica = (am.Bica == 0 ? false : true),
                //                    TempoBase = (DateTime.Now - am.BicaDtHr.Value).ToString(@"hh\:mm\:ss\:fff")
                //                }).ToList();
                
                //var queryUsb = db.ambulancia
                //    .GroupJoin(db.solicitacoes_ambulancias
                //    .Where(sa => sa.SolicitacaoConcluida == 0),
                //        am => am.idAmbulancia,
                //        sa => sa.idAmbulanciaSol,
                //        (am, saa) => new
                //        {
                //            am, saa
                //        })
                //        .GroupJoin(db.solicitacoes_paciente,
                //        sa => sa.saa.Select(o=> o.idSolicitacoesPacientes),
                //        sp => sp.idPaciente_Solicitacoes,
                //        (saa, sp) => new
                //        {
                //            saa,sp = sp
                //        })
                //        .Where(e => e.saa.am.TipoAM == "BASICO" && e.saa.am.Desativado == 0)
                //        .OrderBy(o => o.saa.am.NomeAmbulancia)
                //        .AsEnumerable()
                //        .Select(s => new
                //        {
                //            idAM = s.saa.am.idAmbulancia, 
                //            Ambulancia = s.saa.am.NomeAmbulancia,
                //            Status = s.saa.sa.Status,
                //            StatusE = s.saa.am.StatusAmbulancia,
                //            idPaciente = s.saa.sa.idSolicitacoesPacientes,
                //            Paciente = s.sp.Paciente,
                //            Idade = s.sp.Idade,
                //            Origem = s.sp.Origem,
                //            Destino = s.sp.Destino,
                //            Bica = (s.saa.am.Bica == 0 ? false : true),
                //            startTime = s.saa.am.BicaDtHr.Value.TimeOfDay,
                //            endTime = DateTime.Now.TimeOfDay,
                //            TempoBase = (s.saa.am.BicaDtHr.Value.TimeOfDay.Duration() - DateTime.Now.TimeOfDay.Duration()).Duration()
                //        })
                //        .ToList();


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
                                    idAM = am.idAmbulancia,
                                    Ambulancia = am.NomeAmbulancia,
                                    Status = sa.Status,
                                    StatusE = am.StatusAmbulancia,
                                    idPaciente = sa.idSolicitacoesPacientes,
                                    Paciente = sp.Paciente,
                                    Idade = sp.Idade,
                                    Origem = sp.Origem,
                                    Destino = sp.Destino,
                                    Bica = (am.Bica == 0 ? false : true),
                                    //TempoBica = am.BicaDtHr,
                                }).ToList();


                listaUsb.DataSource = queryUsb;
                listaUsb.ClearSelection();
                
            }



            listaUsb.Columns["idAM"].Visible = false;
            listaUsb.Columns["idPaciente"].Visible = false;
            listaUsb.Columns["StatusE"].Width = 0;
            coresDasTabelas();
            this.listaUsb.Columns["Ambulancia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.listaUsb.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.listaUsb.Columns["Paciente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.listaUsb.Columns["Idade"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.listaUsb.Columns["Origem"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.listaUsb.Columns["Destino"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
        }
        public void pegarDadosDasAmbulanciasUsa()
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
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
                                    Destino = sp.Destino,
                                    Bica = (am.Bica == 0 ? false : true),
                                   // TempoBase = SqlFunctions.DateDiff("day", am.BicaDtHr, DateTime.Now)
                                }).ToList();

                listaUsa.DataSource = queryUsa;
                listaUsa.ClearSelection();

            }

            listaUsa.Columns[0].Visible = false;
            listaUsa.Columns["idPaciente"].Visible = false;
            listaUsa.Columns["StatusE"].Width = 0;
            coresDasTabelas();

            this.listaUsa.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.listaUsa.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.listaUsa.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.listaUsa.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.listaUsa.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.listaUsa.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


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
            pegarDadosDasAmbulanciasUsa();
            pegarDadosDasAmbulanciasUsb();
            contarSolicitacao();
            contarSolicitacoesAgendadasPendentes();
            alertarNovosAgendamentos();
            numeroAgendamentos = Convert.ToInt32(txtAgendasPendentes.Text);

            AutoUpdater.CurrentCulture = CultureInfo.CreateSpecificCulture("pt");
            AutoUpdater.Start("http://vinidg.github.io/update_sistemas/update_controle.xml");

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
            System.Diagnostics.Process.Start("https://goo.gl/forms/IIOpkaXMHg8vUTd03");
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
        private void CONTROLE_FormClosing(object sender, FormClosingEventArgs e)
        {
            AutoUpdater.disableSkip();
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
            this.Cursor = Cursors.WaitCursor;
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

            this.Cursor = Cursors.Default;
        }
        private void alertarNovosAgendamentos()
        {
            if (Convert.ToInt32(txtAgendasPendentes.Text) > numeroAgendamentos)
            {
                int novos = Convert.ToInt32(txtAgendasPendentes.Text) - numeroAgendamentos;
                numeroAgendamentos = Convert.ToInt32(txtAgendasPendentes.Text);
                MessageBox.Show(novos + " novos agendamentos solicitados !", "Novos agendamentos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
        }
        private void listaUsa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == listaUsa.Columns["Bica"].Index)
                {
                    if (listaUsa.Rows[e.RowIndex].Cells["StatusE"].Value.ToString() == "DISPONIVEL" || listaUsa.Rows[e.RowIndex].Cells["StatusE"].Value.ToString() == "BLOQUEADA")
                    {
                        int bicaSelecionada;
                        if (Convert.ToBoolean(listaUsa.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                        {
                            bicaSelecionada = 0;
                        }
                        else
                        {
                            bicaSelecionada = 1;
                        }

                        int id = Convert.ToInt32(listaUsa.Rows[e.RowIndex].Cells[0].Value);
                        using (DAHUEEntities db = new DAHUEEntities())
                        {
                            ambulancia am = db.ambulancia.First(a => a.idAmbulancia == id);
                            am.Bica = bicaSelecionada;
                            am.BicaDtHr = DateTime.Now;
                            db.SaveChanges();
                        }
                        pegarDadosDasAmbulanciasUsa();
                        pegarDadosDasAmbulanciasUsb();
                    }
                    else
                    {
                        MessageBox.Show("A ambulância ainda está transportando o paciente, conclua a solicitação primeiro.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        private void listaUsb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == listaUsb.Columns["Bica"].Index)
                {
                    if (listaUsb.Rows[e.RowIndex].Cells["StatusE"].Value.ToString() == "DISPONIVEL" || listaUsb.Rows[e.RowIndex].Cells["StatusE"].Value.ToString() == "BLOQUEADA")
                    {
                        int bicaSelecionada;
                        if (Convert.ToBoolean(listaUsb.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                        {
                            bicaSelecionada = 0;
                        }
                        else
                        {
                            bicaSelecionada = 1;
                        }

                        int id = Convert.ToInt32(listaUsb.Rows[e.RowIndex].Cells[0].Value);
                        using (DAHUEEntities db = new DAHUEEntities())
                        {
                            ambulancia am = db.ambulancia.First(a => a.idAmbulancia == id);
                            am.Bica = bicaSelecionada;
                            db.SaveChanges();
                        }
                        pegarDadosDasAmbulanciasUsa();
                        pegarDadosDasAmbulanciasUsb();
                    }
                    else
                    {
                        MessageBox.Show("A ambulância ainda está transportando o paciente, conclua a solicitação primeiro.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion


    }

}




