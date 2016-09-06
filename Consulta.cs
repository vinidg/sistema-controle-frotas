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
    public partial class Consulta : Form
    {
        int IDpesquisa;
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

        private void pesquisar()
        {
            int numero = Convert.ToInt32(numeroFicha.Text);
           
            consultaSolicitacoes.DataSource = null;
            consultaSolicitacoes.Refresh();

            if(opcaoNome.Checked)
            {

            using(DAHUEEntities db = new DAHUEEntities())
            {
            var query = from solicitacoes_paciente in db.solicitacoes_paciente
                        where
                          solicitacoes_paciente.Paciente.Contains(nome.Text)
                        select new
                        {
                            solicitacoes_paciente.idPaciente_Solicitacoes,
                            solicitacoes_paciente.Paciente,
                            solicitacoes_paciente.Genero,
                            solicitacoes_paciente.Idade
                        };
                consultaSolicitacoes.DataSource = query.ToArray();
                consultaSolicitacoes.Refresh();

                consultaSolicitacoes.Columns[0].HeaderText = "ID";
            }

            }
            
            else if (opcaoNumero.Checked)
            {
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    var query = from solicitacoes_paciente in db.solicitacoes_paciente
                                where
                                  solicitacoes_paciente.idPaciente_Solicitacoes == numero
                                select new
                                {
                                    solicitacoes_paciente.idPaciente_Solicitacoes,
                                    solicitacoes_paciente.Paciente,
                                    solicitacoes_paciente.Genero,
                                    solicitacoes_paciente.Idade
                                };
                    consultaSolicitacoes.DataSource = query.ToArray();
                    consultaSolicitacoes.Refresh();

                    consultaSolicitacoes.Columns[0].HeaderText = "ID";
                }
            }



        }

        private void pesquisarTodos()
        {
            using(DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from solicitacoes_paciente in db.solicitacoes_paciente
                             select new
                             {
                                 solicitacoes_paciente.idPaciente_Solicitacoes,
                                 solicitacoes_paciente.Paciente,
                                 solicitacoes_paciente.Genero,
                                 solicitacoes_paciente.Idade
                             }).Take(50);
                consultaSolicitacoes.DataSource = query.ToList();
                consultaSolicitacoes.Refresh();

                consultaSolicitacoes.Columns[0].HeaderText = "ID";
            }
        }

        private void dataInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataInicio.Mask = "00/00/0000";
        }

        private void dataFim_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataFim.Mask = "00/00/0000";
        }

        private void consultaSolicitacoes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IDpesquisa = Convert.ToInt32(consultaSolicitacoes.Rows[e.RowIndex].Cells[0].Value.ToString());

            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from sa in db.solicitacoes_ambulancias
                             join sp in db.solicitacoes_paciente on sa.idSolicitacoesPacientes
                             equals sp.idPaciente_Solicitacoes into sp_join
                             from sp in sp_join.DefaultIfEmpty()
                             where sa.idSolicitacoesPacientes == IDpesquisa
                             select new
                             {
                                 IDpaciente = sa.idSolicitacoesPacientes,
                                 idSolicitacaoAm = sa.idSolicitacoes_Ambulancias,
                                 Data = sp.DtHrdoInicio,
                                 NomePaciente = sp.Paciente,
                                 Idade = sp.Idade,
                                 Origem = sp.Origem,
                                 Destino = sp.Destino
                             }).ToList();
                ListaSolicitacaoPaciente.DataSource = query;
                ListaSolicitacaoPaciente.Refresh();
                ListaSolicitacaoPaciente.Columns["IDpaciente"].Visible = false;
                ListaSolicitacaoPaciente.Columns["idSolicitacaoAm"].Visible = false;
            }

            if(ListaSolicitacaoPaciente.Rows.Count == 0)
            {
                SelecionaAM sand = new SelecionaAM(IDpesquisa, 0, 0);
                this.Dispose();
                sand.ShowDialog();
            }
        }

        private void opcaoNumero_CheckedChanged(object sender, EventArgs e)
        {
            nome.Enabled = false;
            nome.Text = "";
            numeroFicha.Enabled = true;
        }

        private void opcaoNome_CheckedChanged(object sender, EventArgs e)
        {
            numeroFicha.Enabled = false;
            numeroFicha.Text = "0";
            nome.Enabled = true;
        }

        private void numeroFicha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                pesquisar();
            }
        }

        private void nome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                pesquisar();
            }
        }

        private void ListaSolicitacaoPaciente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idSolicitacaoAm;
            IDpesquisa = Convert.ToInt32(ListaSolicitacaoPaciente.Rows[e.RowIndex].Cells["IDpaciente"].Value.ToString());
            idSolicitacaoAm = Convert.ToInt32(ListaSolicitacaoPaciente.Rows[e.RowIndex].Cells["idSolicitacaoAm"].Value.ToString());

            SelecionaAM sand = new SelecionaAM(IDpesquisa, 0, idSolicitacaoAm);
            this.Dispose();
            sand.ShowDialog();
        }

    }
}
