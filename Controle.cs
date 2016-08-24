using MySql.Data.MySqlClient;
using Sistema_Controle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using db_transporte_sanitario;

namespace Sistema_Controle
{
    public partial class CONTROLE : Form
    {
        public CONTROLE()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            pegarDadosDasAmbulancias();
            countparaSol();
            countparaSolAgendadas();
            countparaSolAgendadasPendentes();
            Re.Text = System.Environment.UserName;
            timerAtualiza(0);

            this.Text = "Sistema de Controle de Ambulancias - " + DateTime.Now.Year.ToString() + ". Versão: " + appverion;
            label1.Text = "CONTROLE DE AMBULÂNCIAS - " + DateTime.Now.Year.ToString();
        }
        Version appverion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

        public void timerAtualiza(int foi)
        {
            if (foi != 1)
            {
                Timer t = new Timer();
                t.Interval = 5000;
                t.Tick += new EventHandler(timer1_Tick);
                t.Start();
            }
            return;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ConfirmaSolicitacao frm = new ConfirmaSolicitacao();
            frm.ShowDialog();
            timerAtualiza(1);
        }

        private void txtSolicitacoes_Click(object sender, EventArgs e)
        {
            Solicitacoes Sol = new Solicitacoes(0, "");
            Sol.ShowDialog();
            timerAtualiza(1);
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
            countparaSol();
            countparaSolAgendadas();
            countparaSolAgendadasPendentes();
        }
        private void countparaSol()
        {
            int zero = 0;
          
            using (DAHUEEntities db = new DAHUEEntities())
                {
                    var query= (from sp in db.solicitacoes_paciente
                               where sp.AmSolicitada == zero && sp.Agendamento == "Nao"
                               select sp.idPaciente_Solicitacoes).Count();

                    txtSolicitacoes.Text = query.ToString();
                }

        }

        private void countparaSolAgendadas()
        {
            int zero = 0;

            //CONTA AS solicitacoes agendadas
            using (DAHUEEntities db = new DAHUEEntities())
            {

                var query = (from sp in db.solicitacoes_paciente
                             where sp.Agendamento == "Sim" &&
                             sp.AmSolicitada == zero &&
                             sp.Registrado == "Sim"
                             select sp.idPaciente_Solicitacoes).Count();

                txtAgendadasHoje.Text = query.ToString();
            }
        }

        private void countparaSolAgendadasPendentes()
        {
            int zero = 0;

            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from sp in db.solicitacoes_paciente
                             where sp.AmSolicitada == zero && sp.Agendamento == "Sim"
                             && sp.Registrado != "Sim"
                             select sp.idPaciente_Solicitacoes).Count();

                txtAgendasPendentes.Text = query.ToString();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pegarDadosDasAmbulancias();
            countparaSol();
            countparaSolAgendadasPendentes();
            atualizadorParaNotificador();

        }

        private void atualizadorParaNotificador()
        {
            Update update = new Update();
            update.up();
            if (update.Avisar == true)
            {
                avisandoAoControle.Visible = true;
                avisandoAoControle.Text = "Nova atualização no sistema de Controle de Ambulancias. Reinicie o sistema !!!";

            }
        }

        private void txtAgendadasHoje_Click(object sender, EventArgs e)
        {
            Solicitacoes solicitacoes = new Solicitacoes(0, "");
            solicitacoes.ShowDialog();
            timerAtualiza(1);
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

        public void pegarDadosDasAmbulancias()
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var queryUsb = (from am in db.ambulancia
                               join sa in db.solicitacoes_ambulancias
                               on new { idAmbulanciaSol = am.idAmbulancia, SolicitacaoConcluida = 0 }
                               equals new { sa.idAmbulanciaSol, SolicitacaoConcluida = (int)sa.SolicitacaoConcluida} into sa_join
                               from sa in sa_join.DefaultIfEmpty()
                               join sp in db.solicitacoes_paciente 
                               on new { idSolicitacoesPacientes = (int)sa.idSolicitacoesPacientes } 
                               equals new { idSolicitacoesPacientes = sp.idPaciente_Solicitacoes } into sp_join
                               from sp in sp_join.DefaultIfEmpty()
                               where am.TipoAM == "BASICO" && am.Desativado == 0
                               select new
                               {
                                   am.idAmbulancia,
                                   Ambulancia =  am.NomeAmbulancia,
                                   Status = am.StatusAmbulancia,
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
                               where
                               am.TipoAM == "AVANCADO" && am.Desativado == 0
                               select new
                               {
                                   am.idAmbulancia,
                                   Ambulancia = am.NomeAmbulancia,
                                   Status = am.StatusAmbulancia,
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

            this.listaUsa.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.listaUsa.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.listaUsa.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.listaUsa.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.listaUsa.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.listaUsa.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.listaUsb.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.listaUsb.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.listaUsb.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.listaUsb.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.listaUsb.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.listaUsb.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.Equals("BLOQUEADA"))
            {
                listaUsb.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(0, 122, 181);
                listaUsb.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else if (e.Value != null && e.Value.Equals("OCUPADA"))
            {
                listaUsb.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(224, 62, 54);
                listaUsb.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else if (e.Value != null && e.Value.Equals("DISPONIVEL"))
            {
                listaUsb.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(46, 172, 109);
                listaUsb.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }

        }

        private void listaUsa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.Equals("BLOQUEADA"))
            {
                listaUsa.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(0, 122, 181);
                listaUsa.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else if (e.Value != null && e.Value.Equals("OCUPADA"))
            {
                listaUsa.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(224, 62, 54);
                listaUsa.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else if (e.Value != null && e.Value.Equals("DISPONIVEL"))
            {
                listaUsa.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(46, 172, 109);
                listaUsa.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void listaUsb_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
            string idAM = listaUsb.Rows[e.RowIndex].Cells[0].Value.ToString();
            if(listaUsb.Rows[e.RowIndex].Cells["idPaciente"].Value != null)
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

        private void Editar_Click(object sender, EventArgs e)
        {
            EditarAmbulancias ea = new EditarAmbulancias();
            ea.ShowDialog();
        
        }

        private void txtAgendasPendentes_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtAgendasPendentes.Focus())
            {
                label1.Focus();
            }
        }

    }

}




