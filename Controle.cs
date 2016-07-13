using MySql.Data.MySqlClient;
using Solicitacao_de_Ambulancias;
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

namespace WindowsFormsApplication2
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
            Re.Text = System.Environment.UserName;
            timerAtualiza(0);
            update();
            
            this.Text = "Sistema de Controle de Ambulancias. Versão: " + appverion;
        }
        Version appverion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        public void update()
        {
            Update updatando = new Update();
            updatando.up();
            if (updatando.Yn == true)
            {
                Environment.Exit(1);
            }
        }

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
            Solicitacoes Sol = new Solicitacoes(null, null);
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

        private void abreStatusComIdDaAM()
        {
            Status sta = new Status("3");
            sta.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            countparaSol();
            countparaSolAgendadas();
        }
        private void countparaSol()
        {
            //CONTA AS solicitacoes
            SqlConnection conexao = ConexaoSqlServer.GetConexao();


            string sqlQuery = "SELECT COUNT(idPaciente_Solicitacoes) FROM [dbo].[solicitacoes_paciente] WHERE AmSolicitada = '0' and Agendamento = 'Nao'";
            try
            {

                using (SqlCommand objComm = new SqlCommand(sqlQuery, conexao))
                {
                    int count = (int)objComm.ExecuteScalar();
                    txtSolicitacoes.Text = count.ToString();
                }
            }
            finally
            {
                conexao.Close();

            }
        }

        private void countparaSolAgendadas()
        {
            DateTime Data = DateTime.Now;
            int i = 0;
            string str = "";
            string data = "";
            int contagem = 0;
            string dataHoje = Data.ToString("dd/MM/yyyy");
            //CONTA AS solicitacoes agendadas
            SqlConnection conexao = ConexaoSqlServer.GetConexao();

            string sqlQuery = "SELECT DtHrAgendamento FROM [dbo].[solicitacoes_paciente] WHERE Agendamento = 'Sim' and AmSolicitada = '0'";

            try
            {
                SqlDataAdapter objComm = new SqlDataAdapter(sqlQuery, conexao);

                DataSet CD = new DataSet();
                objComm.Fill(CD);

                //verificar se é igual a data de 'hoje'
                while (i < CD.Tables[0].Rows.Count)
                {
                    str = CD.Tables[0].Rows[i][0].ToString();
                    data = str.Substring(0, 10);

                    if (data == dataHoje)
                    {
                        contagem++;
                    }
                    i++;
                }

                txtAgendadasHoje.Text = contagem.ToString();
            }
            finally
            {
                conexao.Close();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pegarDadosDasAmbulancias();
            countparaSol();
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
            Solicitacoes solicitacoes = new Solicitacoes("", "");
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
                var queryUsb = from am in db.ambulancia
                            join sa in db.solicitacoes_ambulancias
                            on new { idAmbulanciaSol = am.idAmbulancia, SolicitacaoConcluida = 0 }
                            equals new { sa.idAmbulanciaSol, SolicitacaoConcluida = (int)sa.SolicitacaoConcluida } into sa_join
                            from sa in sa_join.DefaultIfEmpty()
                            join sp in db.solicitacoes_paciente on new { idSolicitacoesPacientes = (int)sa.idSolicitacoesPacientes } equals new { idSolicitacoesPacientes = sp.idPaciente_Solicitacoes } into sp_join
                            from sp in sp_join.DefaultIfEmpty()
                            where
                            am.TipoAM == "BASICO"
                            select new
                            {
                                am.idAmbulancia,
                                am.NomeAmbulancia,
                                am.StatusAmbulancia,
                                Paciente = sp.Paciente,
                                Idade = sp.Idade,
                                Origem = sp.Origem,
                                Destino = sp.Destino
                            };

                var queryAmbulanciaUsb = queryUsb.ToList();

                listaUsb.DataSource = queryAmbulanciaUsb;
                listaUsb.ClearSelection();

                var queryUsa = from am in db.ambulancia
                            join sa in db.solicitacoes_ambulancias
                            on new { idAmbulanciaSol = am.idAmbulancia, SolicitacaoConcluida = 0 }
                            equals new { sa.idAmbulanciaSol, SolicitacaoConcluida = (int)sa.SolicitacaoConcluida } into sa_join
                            from sa in sa_join.DefaultIfEmpty()
                            join sp in db.solicitacoes_paciente on new { idSolicitacoesPacientes = (int)sa.idSolicitacoesPacientes } equals new { idSolicitacoesPacientes = sp.idPaciente_Solicitacoes } into sp_join
                            from sp in sp_join.DefaultIfEmpty()
                            where
                            am.TipoAM == "AVANCADO"
                            select new
                            {
                                am.idAmbulancia,
                                am.NomeAmbulancia,
                                am.StatusAmbulancia,
                                Paciente = sp.Paciente,
                                Idade = sp.Idade,
                                Origem = sp.Origem,
                                Destino = sp.Destino
                            };

                var queryAmbulanciaUsa = queryUsa.ToList();

                listaUsa.DataSource = queryAmbulanciaUsa;
                listaUsa.ClearSelection();


            }
            listaUsa.Columns[0].Visible = false;
            listaUsa.Columns[1].HeaderText = "Ambulancia";
            listaUsa.Columns[2].HeaderText = "Status";

            listaUsb.Columns[0].Visible = false;
            listaUsb.Columns[1].HeaderText = "Ambulancia";
            listaUsb.Columns[2].HeaderText = "Status";
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.Equals("BLOQUEADA"))
            {
                listaUsb.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.RoyalBlue;
                listaUsb.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else if (e.Value != null && e.Value.Equals("OCUPADA"))
            {
                listaUsb.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Firebrick;
                listaUsb.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else if (e.Value != null && e.Value.Equals("DISPONIVEL"))
            {
                listaUsb.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LimeGreen;
                listaUsb.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }

        }

        private void listaUsa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.Equals("BLOQUEADA"))
            {
                listaUsa.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.RoyalBlue;
                listaUsa.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else if (e.Value != null && e.Value.Equals("OCUPADA"))
            {
                listaUsa.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Firebrick;
                listaUsa.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else if (e.Value != null && e.Value.Equals("DISPONIVEL"))
            {
                listaUsa.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LimeGreen;
                listaUsa.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void listaUsb_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = listaUsb.Rows[e.RowIndex].Cells[0].Value.ToString();
            Status sta = new Status(cellValue);
            sta.ShowDialog();
        }

        private void listaUsa_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = listaUsb.Rows[e.RowIndex].Cells[0].Value.ToString();
            Status sta = new Status(cellValue);
            sta.ShowDialog();
        }

    }

}




