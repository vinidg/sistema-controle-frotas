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


namespace WindowsFormsApplication2
{
    public partial class CONTROLE : Form
    {

        public CONTROLE()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Status();
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
                BtnAM01.Focus();
            }
        }

        private void txtSolicitacoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSolicitacoes.Focus())
            {
                BtnAM01.Focus();
            }
        }
        public void Status()
        {
            StatusBD d = new StatusBD();
            d.puxarStatus();

            if (d.AM011 == "BLOQUEADA")
            {
                BtnAM01.BackColor = Color.RoyalBlue;
            }
            if (d.AM011 == "DISPONIVEL")
            {
                BtnAM01.BackColor = Color.LimeGreen;
            }
            if (d.AM011 == "OCUPADA")
            {
                BtnAM01.BackColor = Color.Firebrick;
            }
            if (d.AM021 == "BLOQUEADA")
            {
                BtnAM02.BackColor = Color.RoyalBlue;
            }
            if (d.AM021 == "OCUPADA")
            {
                BtnAM02.BackColor = Color.Firebrick;
            }
            if (d.AM021 == "DISPONIVEL")
            {
                BtnAM02.BackColor = Color.LimeGreen;
            }
            if (d.AMRC1 == "DISPONIVEL")
            {
                BtnAMRC.BackColor = Color.LimeGreen;
            }
            if (d.AMRC1 == "OCUPADA")
            {
                BtnAMRC.BackColor = Color.Firebrick;
            }
            if (d.AMRC1 == "BLOQUEADA")
            {
                BtnAMRC.BackColor = Color.RoyalBlue;
            }
            if (d.AM031 == "BLOQUEADA")
            {
                BtnAM03.BackColor = Color.RoyalBlue;
            }
            if (d.AM031 == "DISPONIVEL")
            {
                BtnAM03.BackColor = Color.LimeGreen;
            }
            if (d.AM031 == "OCUPADA")
            {
                BtnAM03.BackColor = Color.Firebrick;
            }
            if (d.AM041 == "BLOQUEADA")
            {
                BtnAM04.BackColor = Color.RoyalBlue;
            }
            if (d.AM041 == "OCUPADA")
            {
                BtnAM04.BackColor = Color.Firebrick;
            }
            if (d.AM041 == "DISPONIVEL")
            {
                BtnAM04.BackColor = Color.LimeGreen;
            }

            if (d.AM051 == "BLOQUEADA")
            {
                BtnAM05.BackColor = Color.RoyalBlue;
            }
            if (d.AM051 == "OCUPADA")
            {
                BtnAM05.BackColor = Color.Firebrick;
            }
            if (d.AM051 == "DISPONIVEL")
            {
                BtnAM05.BackColor = Color.LimeGreen;
            }

            if (d.AM061 == "BLOQUEADA")
            {
                BtnAM06.BackColor = Color.RoyalBlue;
            }

            if (d.AM061 == "DISPONIVEL")
            {
                BtnAM06.BackColor = Color.LimeGreen;
            }

            if (d.AM061 == "OCUPADA")
            {
                BtnAM06.BackColor = Color.Firebrick;
            }

            if (d.AM071 == "BLOQUEADA")
            {
                BtnAM07.BackColor = Color.RoyalBlue;
            }
            if (d.AM071 == "OCUPADA")
            {
                BtnAM07.BackColor = Color.Firebrick;
            }
            if (d.AM071 == "DISPONIVEL")
            {
                BtnAM07.BackColor = Color.LimeGreen;
            }

            if (d.AM081 == "BLOQUEADA")
            {
                BtnAM08.BackColor = Color.RoyalBlue;
            }
            if (d.AM081 == "DISPONIVEL")
            {
                BtnAM08.BackColor = Color.LimeGreen;
            }
            if (d.AM081 == "OCUPADA")
            {
                BtnAM08.BackColor = Color.Firebrick;
            }

            if (d.AM091 == "BLOQUEADA")
            {
                BtnAM09.BackColor = Color.RoyalBlue;
            }
            if (d.AM091 == "DISPONIVEL")
            {
                BtnAM09.BackColor = Color.LimeGreen;
            }
            if (d.AM091 == "OCUPADA")
            {
                BtnAM09.BackColor = Color.Firebrick;
            }

            if (d.AM111 == "BLOQUEADA")
            {
                BtnAM11.BackColor = Color.RoyalBlue;
            }
            if (d.AM111 == "DISPONIVEL")
            {
                BtnAM11.BackColor = Color.LimeGreen;
            }
            if (d.AM111 == "OCUPADA")
            {
                BtnAM11.BackColor = Color.Firebrick;
            }

            if (d.AM101 == "BLOQUEADA")
            {
                BtnAM10.BackColor = Color.RoyalBlue;
            }
            if (d.AM101 == "DISPONIVEL")
            {
                BtnAM10.BackColor = Color.LimeGreen;
            }
            if (d.AM101 == "OCUPADA")
            {
                BtnAM10.BackColor = Color.Firebrick;
            }

            if (d.AM461 == "DISPONIVEL")
            {
                BtnAM46.BackColor = Color.LimeGreen;
            }
            if (d.AM461 == "OCUPADA")
            {
                BtnAM46.BackColor = Color.Firebrick;
            }
            if (d.AM461 == "BLOQUEADA")
            {
                BtnAM46.BackColor = Color.RoyalBlue;
            }

            if (d.AM471 == "OCUPADA")
            {
                BtnAM47.BackColor = Color.Firebrick;
            }
            if (d.AM471 == "DISPONIVEL")
            {
                BtnAM47.BackColor = Color.LimeGreen;
            }
            if (d.AM471 == "BLOQUEADA")
            {
                BtnAM47.BackColor = Color.RoyalBlue;
            }

            if (d.AM521 == "DISPONIVEL")
            {
                BtnAM52.BackColor = Color.LimeGreen;
            }
            if (d.AM521 == "OCUPADA")
            {
                BtnAM52.BackColor = Color.Firebrick;
            }
            if (d.AM521 == "BLOQUEADA")
            {
                BtnAM52.BackColor = Color.RoyalBlue;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Status sta = new Status("3");
            sta.ShowDialog();

        }
        private void BtnAM01_Click(object sender, EventArgs e)
        {
            Status sta = new Status("1");
            sta.ShowDialog();
        }

        private void BtnAM02_Click(object sender, EventArgs e)
        {
            Status sta = new Status("2");
            sta.ShowDialog();
        }

        private void BtnAM03_Click(object sender, EventArgs e)
        {
            Status sta = new Status("4");
            sta.ShowDialog();
        }

        private void BtnAM04_Click(object sender, EventArgs e)
        {
            Status sta = new Status("5");
            sta.ShowDialog();
        }

        private void BtnAM05_Click(object sender, EventArgs e)
        {
            Status sta = new Status("6");
            sta.ShowDialog();
        }

        private void BtnAM06_Click(object sender, EventArgs e)
        {
            Status sta = new Status("7");
            sta.ShowDialog();
        }

        private void BtnAM07_Click(object sender, EventArgs e)
        {
            Status sta = new Status("8");
            sta.ShowDialog();
        }

        private void BtnAM09_Click(object sender, EventArgs e)
        {
            Status sta = new Status("9");
            sta.ShowDialog();
        }

        private void BtnAM08_Click(object sender, EventArgs e)
        {
            Status sta = new Status("10");
            sta.ShowDialog();
        }

        private void BtnAM11_Click(object sender, EventArgs e)
        {
            Status sta = new Status("11");
            sta.ShowDialog();
        }

        private void BtnAM10_Click(object sender, EventArgs e)
        {
            Status sta = new Status("13");
            sta.ShowDialog();
        }

        private void BtnAM15_Click(object sender, EventArgs e)
        {
            Status sta = new Status("15");
            sta.ShowDialog();
        }

        private void BtnAM46_Click(object sender, EventArgs e)
        {
            Status sta = new Status("16");
            sta.ShowDialog();
        }

        private void BtnAM47_Click(object sender, EventArgs e)
        {
            Status sta = new Status("17");
            sta.ShowDialog();
        }

        private void BtnAM52_Click(object sender, EventArgs e)
        {
            Status sta = new Status("18");
            sta.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Status();
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
            Status();
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
                BtnAM01.Focus();
            }
        }

        private void txtAgendadasHoje_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtAgendadasHoje.Focus())
            {
                BtnAM01.Focus();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Atualizacao atualizacao = new Atualizacao();
            atualizacao.ShowDialog();
        }

        private void BtnAM09_Click_1(object sender, EventArgs e)
        {
            Status sta = new Status("12");
            sta.ShowDialog();
        }

        private void BtnAM11_Click_1(object sender, EventArgs e)
        {
            Status sta = new Status("14");
            sta.ShowDialog();
        }

        private void Consultar_Click(object sender, EventArgs e)
        {
            Consulta consulta = new Consulta();
            consulta.ShowDialog();
        }

    }


}

