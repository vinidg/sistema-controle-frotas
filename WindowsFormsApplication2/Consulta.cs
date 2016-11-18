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
using System.Data.Objects.SqlClient;

namespace Sistema_Controle
{
    public partial class Consulta : Form
    {
        int IDpesquisa;
        enum Opcao { Nome, Numero, Data, Diagnostico, Origem, Destino, Motivo };
        Opcao opcao;
        public Consulta()
        {
            InitializeComponent();
            pesquisarTodos();
            dataInicio.Value = new DateTime(dataInicio.Value.Year, dataInicio.Value.Month, 1);

        }
        private void pesquisar()
        {
            consultaSolicitacoes.DataSource = null;
            consultaSolicitacoes.Refresh();

            if (opcao == Opcao.Nome)
            {

                using (DAHUEEntities db = new DAHUEEntities())
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

            else if (opcao == Opcao.Numero)
            {
                int numero = Convert.ToInt32(numeroFicha.Text);
                
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
            else if (opcao == Opcao.Data)
            {
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    var query = from sp in db.solicitacoes_paciente
                                where
                                  sp.DtHrdoInicio >= dataInicio.Value && sp.DtHrdoInicio <= dataFim.Value
                                select new
                                {
                                    sp.idPaciente_Solicitacoes,
                                    sp.Paciente,
                                    sp.Genero,
                                    sp.Idade
                                };
                    consultaSolicitacoes.DataSource = query.ToArray();
                    consultaSolicitacoes.Refresh();

                    consultaSolicitacoes.Columns[0].HeaderText = "ID";
                }
            }
            else if (opcao == Opcao.Diagnostico)
            {
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    var query = from sp in db.solicitacoes_paciente
                                where sp.Diagnostico.Contains(diagnostico.Text)
                                select new
                               { 
                                    sp.idPaciente_Solicitacoes,
                                    sp.Paciente,
                                    sp.Genero,
                                    sp.Idade
                                };
                    consultaSolicitacoes.DataSource = query.ToArray();
                    consultaSolicitacoes.Refresh();

                    consultaSolicitacoes.Columns[0].HeaderText = "ID";
                }
            }


        }
        private void pesquisarTodos()
        {
            using (DAHUEEntities db = new DAHUEEntities())
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
        private void button1_Click(object sender, EventArgs e)
        {
            pesquisar();
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

            if (ListaSolicitacaoPaciente.Rows.Count == 0)
            {
                SelecionaAM sand = new SelecionaAM(IDpesquisa, 0, 0);
                this.Dispose();
                sand.ShowDialog();
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

        private void numeroFicha_Click(object sender, EventArgs e)
        {
            opcao = Opcao.Numero;
        }
        private void nome_Click(object sender, EventArgs e)
        {
            opcao = Opcao.Nome;
        }
        private void diagnostico_Click(object sender, EventArgs e)
        {
            opcao = Opcao.Diagnostico;
        }

        private void dataInicio_Enter(object sender, EventArgs e)
        {
            opcao = Opcao.Data;
        }
        private void dataFim_Enter(object sender, EventArgs e)
        {
            opcao = Opcao.Data;
        }

    }
}
