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
    public partial class Consulta : Form
    {
        string nomeLike;
        public Consulta()
        {
            InitializeComponent();
            pesquisarTodos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataInicio.Text == "  /  /")
            {
                dataInicio.Mask = "";
            }
            if (dataFim.Text == "  /  /")
            {
                dataFim.Mask = "";
            }
            pesquisar();
        }

        string IDpesquisa;
        private void listaConsulta_DoubleClick(object sender, EventArgs e)
        {
            if (listaConsulta.SelectedItems.Count > 0)
            {
                IDpesquisa = listaConsulta.SelectedItems[0].Text;
            }
            SelecionaAM sand = new SelecionaAM(IDpesquisa, "", "", this.Text);
            this.Dispose();
            sand.ShowDialog();
        }

        private void pesquisar()
        {
            if(nome.Text != null || nome.Text != ""){
                nomeLike = nome.Text + "%";
            }
            ListViewItem IT = null;
            listaConsulta.Items.Clear();

            //Consultar no banco de dados o status da ambulancia
            SqlConnection conexao = ConexaoSqlServer.GetConexao();

            string sqlQuery = "SELECT idPaciente_Solicitacoes,Paciente,genero,idade from solicitacoes_paciente " +
                "WHERE paciente LIKE '" + nomeLike + "' or idPaciente_solicitacoes LIKE '" + numeroFicha.Text + "';";
            SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
            SqlDataReader MyReader2;

            MyReader2 = objComm.ExecuteReader();

            while (MyReader2.Read())
            {
                IT = new ListViewItem(MyReader2["idPaciente_Solicitacoes"].ToString());
                IT.SubItems.Add(MyReader2["Paciente"].ToString());
                IT.SubItems.Add(MyReader2["genero"].ToString());
                IT.SubItems.Add(MyReader2["idade"].ToString());
                listaConsulta.Items.Add(IT);
            }
            conexao.Close();
        }

        private void pesquisarTodos()
        {
            ListViewItem IT = null;

            //Consultar no banco de dados o status da ambulancia
            SqlConnection conexao = ConexaoSqlServer.GetConexao();

            string sqlQuery = "SELECT TOP 50 idPaciente_Solicitacoes,Paciente,genero,idade from solicitacoes_paciente;";

            SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
            SqlDataReader MyReader2;

            MyReader2 = objComm.ExecuteReader();

            while (MyReader2.Read())
            {
                IT = new ListViewItem(MyReader2["idPaciente_Solicitacoes"].ToString());
                IT.SubItems.Add(MyReader2["Paciente"].ToString());
                IT.SubItems.Add(MyReader2["genero"].ToString());
                IT.SubItems.Add(MyReader2["idade"].ToString());
                listaConsulta.Items.Add(IT);

            }
            conexao.Close();
        }

        private void dataInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataInicio.Mask = "00/00/0000";
        }

        private void dataFim_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataFim.Mask = "00/00/0000";
        }

    }
}
