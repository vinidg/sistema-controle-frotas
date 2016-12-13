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
using System.Data.Entity.SqlServer;

namespace Sistema_Controle
{
    public partial class Consulta : Form
    {
        int IDpesquisa;
        enum Opcao { Nome, Numero, Data, Diagnostico, Origem, Destino, Motivo, LocalDaSolicitacao, DataAgendamento};
        Opcao opcao;
        public Consulta()
        {
            InitializeComponent();
            pesquisarTodos();
            Endereco();
            dataInicio.Value = new DateTime(dataInicio.Value.Year, dataInicio.Value.Month, 1);
            ToolTip descricao = new ToolTip();
            descricao.SetToolTip(this.label5, "Digite a palavra que a ser procurada no campo diagnóstico. Exemplo: IAM");
            descricao.SetToolTip(this.diagnostico, "Digite a palavra que a ser procurada no campo diagnóstico. Exemplo: IAM");
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
                                    sp.Idade,
                                    sp.Diagnostico
                                };
                    consultaSolicitacoes.DataSource = query.ToArray();
                    consultaSolicitacoes.Refresh();

                    consultaSolicitacoes.Columns[0].HeaderText = "ID";
                }
            }
            else if (opcao == Opcao.Motivo)
            {
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    var query = from sp in db.solicitacoes_paciente
                                where sp.Motivo.Contains(motivo.Text)
                                select new
                                {
                                    sp.idPaciente_Solicitacoes,
                                    sp.Paciente,
                                    sp.Genero,
                                    sp.Idade,
                                    sp.Motivo
                                };
                    consultaSolicitacoes.DataSource = query.ToArray();
                    consultaSolicitacoes.Refresh();

                    consultaSolicitacoes.Columns[0].HeaderText = "ID";
                }
            }
            else if (opcao == Opcao.Origem)
            {
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    var query = from sp in db.solicitacoes_paciente
                                where sp.Diagnostico.Contains(origem.Text)
                                select new
                                {
                                    sp.idPaciente_Solicitacoes,
                                    sp.Paciente,
                                    sp.Genero,
                                    sp.Idade,
                                    sp.Origem
                                };
                    consultaSolicitacoes.DataSource = query.ToArray();
                    consultaSolicitacoes.Refresh();

                    consultaSolicitacoes.Columns[0].HeaderText = "ID";
                }
            }
            else if (opcao == Opcao.Destino)
            {
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    var query = from sp in db.solicitacoes_paciente
                                where sp.Destino.Contains(destino.Text)
                                select new
                                {
                                    sp.idPaciente_Solicitacoes,
                                    sp.Paciente,
                                    sp.Genero,
                                    sp.Idade,
                                    sp.Destino
                                };
                    consultaSolicitacoes.DataSource = query.ToArray();
                    consultaSolicitacoes.Refresh();

                    consultaSolicitacoes.Columns[0].HeaderText = "ID";
                }
            }
            else if (opcao == Opcao.LocalDaSolicitacao)
            {
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    var query = from sp in db.solicitacoes_paciente
                                where sp.LocalSolicitacao.Contains(localdasolicitacao.Text)
                                select new
                                {
                                    sp.idPaciente_Solicitacoes,
                                    sp.Paciente,
                                    sp.Genero,
                                    sp.Idade,
                                    sp.LocalSolicitacao
                                };
                    consultaSolicitacoes.DataSource = query.ToArray();
                    consultaSolicitacoes.Refresh();

                    consultaSolicitacoes.Columns[0].HeaderText = "ID";
                }
            }
            else if (opcao == Opcao.DataAgendamento)
            {
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    var query = from sp in db.solicitacoes_paciente
                                join saa in db.solicitacoes_agendamentos
                                on sp.idReagendamento equals saa.idSolicitacaoAgendamento into spsaaajoin
                                from saa in spsaaajoin.DefaultIfEmpty()
                                where 
                                SqlFunctions.DateDiff("day", dataagendamento.Value, sp.DtHrdoAgendamento) == 0
                               // || SqlFunctions.DateDiff("day", dataagendamento.Value, sp.DtHrAgendamento) == 0
                               // || SqlFunctions.DateDiff("day", dataagendamento.Value, saa.DtHrAgendamento) == 0
                                select new
                                {
                                    sp.idPaciente_Solicitacoes,
                                    sp.Paciente,
                                    sp.Genero,
                                    sp.Idade,
                                    sp.DtHrdoAgendamento,
                                    Data_Reagendada = saa.DtHrAgendamento
                                };
                    consultaSolicitacoes.DataSource = query.ToList();
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
                             }).OrderByDescending(x => x.idPaciente_Solicitacoes).Take(50);
                consultaSolicitacoes.DataSource = query.ToList();
                consultaSolicitacoes.Refresh();

                consultaSolicitacoes.Columns[0].HeaderText = "ID";
            }
        }
        public void Endereco()
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
                localdasolicitacao.DataSource = db.enderecos.OrderBy(x => x.NomeUnidade).ToList();
                localdasolicitacao.ValueMember = "NomeUnidade";
                localdasolicitacao.DisplayMember = "NomeUnidade";
                destino.DataSource = db.enderecos.OrderBy(x => x.NomeUnidade).ToList();
                destino.ValueMember = "NomeUnidade";
                destino.DisplayMember = "NomeUnidade";
                origem.DataSource = db.enderecos.OrderBy(x => x.NomeUnidade).ToList();
                origem.ValueMember = "NomeUnidade";
                origem.DisplayMember = "NomeUnidade";
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
       
        #region Eventos Cliks
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
        private void dataagendamento_Enter(object sender, EventArgs e)
        {
            opcao = Opcao.DataAgendamento;
        }
        private void motivo_Click(object sender, EventArgs e)
        {
            opcao = Opcao.Motivo;
        }
        private void origem_Click(object sender, EventArgs e)
        {
            opcao = Opcao.Origem;
        }
        private void destino_Click(object sender, EventArgs e)
        {
            opcao = Opcao.Destino;
        }
        private void localdasolicitacao_Click(object sender, EventArgs e)
        {
            opcao = Opcao.LocalDaSolicitacao;
        }
        #endregion
       
        private void imprimirAgendamentos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in consultaSolicitacoes.Rows)
            {
                row.Height = 60;
            }
            this.consultaSolicitacoes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8);
            this.consultaSolicitacoes.DefaultCellStyle.Font = new Font("Arial", 8);

            PrintDGV.Print_DataGridView(consultaSolicitacoes);
        }


    }
}
