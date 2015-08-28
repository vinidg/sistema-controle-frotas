using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApplication2
{
    public partial class Solicitacoes : Form
    {
        string amocupada, sta;
        public Solicitacoes(string AMocup, string STAtus)
        {
            InitializeComponent();
            puxarAmbu();
            amocupada = AMocup;
            sta = STAtus;
            txtTotal1.Text = ListaComPriori.Items.Count.ToString();
            txtTotal2.Text = ListaSemPriori.Items.Count.ToString();
            txtTotal3.Text = ListaAgenda.Items.Count.ToString();
            if (this.Focus())
            {
                puxarAmbu();

            }
        }
        string Id, tipo;

        public void puxarAmbu()
        {
            DateTime Data = DateTime.Now;
            string dataagora = Data.ToString("dd/MM/yyyy");
            string dataAgenda, dataformatada = "", Agenda = "", Priori = "";
            ListViewItem IT2 = null, IT = null;

            //Consultar no banco de dados o status da ambulancia
            SqlConnection conexao = ConexaoSqlServer.GetConexao();

            string sqlQuery = "SELECT Paciente,TipoSolicitacao,DtHrdoInicio,idPaciente_Solicitacoes,Motivo,Origem,Destino,Agendamento,DtHrAgendamento,Prioridade from solicitacoes_paciente WHERE AmSolicitada = '0'";
            
            SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
            SqlDataReader MyReader2;

            MyReader2 = objComm.ExecuteReader();

            while (MyReader2.Read())
            {

                Priori = MyReader2["Prioridade"].ToString();
                IT = new ListViewItem(MyReader2["idPaciente_Solicitacoes"].ToString());
                IT.SubItems.Add(MyReader2["Paciente"].ToString());
                IT.SubItems.Add(MyReader2["TipoSolicitacao"].ToString());
                IT.SubItems.Add(MyReader2["DtHrdoInicio"].ToString());
                IT.SubItems.Add(MyReader2["Motivo"].ToString());
                IT.SubItems.Add(MyReader2["Origem"].ToString());
                IT.SubItems.Add(MyReader2["Destino"].ToString());
                IT.SubItems.Add(MyReader2["Agendamento"].ToString());
                IT.SubItems.Add(MyReader2["DtHrAgendamento"].ToString());
                Agenda = MyReader2["Agendamento"].ToString();
                dataAgenda = MyReader2["DtHrAgendamento"].ToString();
                IT2 = new ListViewItem(MyReader2["idPaciente_Solicitacoes"].ToString());
                IT2.SubItems.Add(MyReader2["Paciente"].ToString());
                IT2.SubItems.Add(MyReader2["TipoSolicitacao"].ToString());
                IT2.SubItems.Add(MyReader2["DtHrdoInicio"].ToString());
                IT2.SubItems.Add(MyReader2["DtHrAgendamento"].ToString());
                IT2.SubItems.Add(MyReader2["Motivo"].ToString());
                IT2.SubItems.Add(MyReader2["Origem"].ToString());
                IT2.SubItems.Add(MyReader2["Destino"].ToString());

                // if (dataAgenda != " " || dataAgenda != null)
                //    {
                //        dataformatada = dataAgenda.Substring(0, 10);
                //     }

                if (Priori == "False" && Agenda == "Nao")
                {
                    ListaSemPriori.Items.Add(IT);
                }
                if (Priori == "True")
                {
                    ListaComPriori.Items.Add(IT);
                }

                if (Agenda == "Sim" && dataformatada != dataagora)
                {
                    ListaAgenda.Items.Add(IT2);
                }
                // if (Agenda == "Sim" && dataformatada == dataagora)
                //    {
                //         ListaSemPriori.Items.Add(IT2);
                //   }
                dataAgenda = "";
                dataformatada = "";
                Agenda = "";
                Priori = "";


            }
            conexao.Close();
        }

        private void ListaComPriori_DoubleClick(object sender, EventArgs e)
        {
            if (amocupada == "")
            {
                if (ListaComPriori.SelectedItems.Count > 0)
                {
                    Id = ListaComPriori.SelectedItems[0].Text;
                }
                SelecionaAM ST = new SelecionaAM(Id, amocupada, null, sta);
                this.Dispose();
                ST.ShowDialog();
                return;
            }
            tipo = ListaComPriori.SelectedItems[0].SubItems[2].Text;
            if (tipo == "Avancada")
            {

                if (amocupada == "AM 01" || amocupada == "AM 02")
                {
           
                }
                else {
                    MessageBox.Show("Selecionar ambulância do tipo avançada ou a solicitação do tipo básica!");
                    return;
                }

            }
            if (tipo == "Basica")
            {
                if (amocupada == "AM 01" || amocupada == "AM 02")
                {
                    MessageBox.Show("Selecionar ambulância do tipo basica ou a solicitação do tipo avançada!");
                    return;
                }

            }
            if (ListaComPriori.SelectedItems.Count > 0)
            {
                Id = ListaComPriori.SelectedItems[0].Text;
            }
            SelecionaAM STi = new SelecionaAM(Id, amocupada, null, sta);
            this.Dispose();
            STi.ShowDialog();
            
        }

        private void ListaSemPriori_DoubleClick(object sender, EventArgs e)
        {
            if (amocupada == "")
            {
                if (ListaSemPriori.SelectedItems.Count > 0)
                {
                    Id = ListaSemPriori.SelectedItems[0].Text;
                }
                SelecionaAM ST = new SelecionaAM(Id, amocupada, null, sta);
                this.Dispose();
                ST.ShowDialog();
           
                return;
            }
            tipo = ListaSemPriori.SelectedItems[0].SubItems[2].Text;
            if (tipo == "Avancada")
            {

                if (amocupada == "AM 01" || amocupada == "AM 02")
                {

                }
                else
                {
                    MessageBox.Show("Selecionar ambulância do tipo avançada ou a solicitação do tipo básica!");
                    return;
                }

            }
            if (tipo == "Basica")
            {
                if (amocupada == "AM 01" || amocupada == "AM 02")
                {
                    MessageBox.Show("Selecionar ambulância do tipo basica ou a solicitação do tipo avançada!");
                    return;
                }

            }
            if (ListaSemPriori.SelectedItems.Count > 0)
            {
                Id = ListaSemPriori.SelectedItems[0].Text;
            }
            SelecionaAM STa = new SelecionaAM(Id, amocupada, null, sta);
            this.Dispose();
            STa.ShowDialog();
        }

        private void ListaAgenda_DoubleClick(object sender, EventArgs e)
        {
            if (amocupada == "")
            {
                if (ListaAgenda.SelectedItems.Count > 0)
                {
                    Id = ListaAgenda.SelectedItems[0].Text;
                }
                SelecionaAM ST = new SelecionaAM(Id, amocupada, null, sta);
                this.Dispose();
                ST.ShowDialog();
  
                return;
            }
            tipo = ListaAgenda.SelectedItems[0].SubItems[2].Text;
            if (tipo == "Avancada")
            {

                if (amocupada == "AM 01" || amocupada == "AM 02")
                {
           
                }
                else {
                    MessageBox.Show("Selecionar ambulância do tipo avançada ou a solicitação do tipo básica!");
                    return;
                }

            }
            if (tipo == "Basica")
            {
                if (amocupada == "AM 01" || amocupada == "AM 02")
                {
                    MessageBox.Show("Selecionar ambulância do tipo basica ou a solicitação do tipo avançada!");
                    return;
                }

            }
            if (ListaAgenda.SelectedItems.Count > 0)
            {
                Id = ListaAgenda.SelectedItems[0].Text;
            }

            SelecionaAM STb = new SelecionaAM(Id, amocupada, null, sta);
            this.Dispose();
            STb.ShowDialog();
        }

    }
}
