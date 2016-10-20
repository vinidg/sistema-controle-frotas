using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using db_transporte_sanitario;

namespace Sistema_Controle
{
    public partial class Reagedamentos : Form
    {
        int paciente, idhistorico;
        public Reagedamentos(int IdPaciente)
        {
            InitializeComponent();
            paciente = IdPaciente;
            puxarReagendamentoENegadas();
        }

        private void puxarReagendamentoENegadas()
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var reagendamentos = (from sad in db.solicitacoes_agendamentos
                                      join sp in db.solicitacoes_paciente
                                      on sad.idSolicitacao_paciente equals sp.idPaciente_Solicitacoes into sad_join
                                      from sp in sad_join.DefaultIfEmpty()
                                      where sad.idSolicitacao_paciente == paciente
                                      select new
                                      {
                                          ID = sad.idSolicitacaoAgendamento,
                                          sad.DtHrAgendamento
                                      }).ToList();

                ListaReagementos.DataSource = reagendamentos;
                //ListaReagementos.Refresh();

                var negativas = (from h in db.historico
                                 where h.Obs != "" && h.Obs != null && h.idPaciente_Solicitacao == paciente
                                 select new
                                 {
                                     h.IdHistorico,
                                     h.DtHrRegistro,
                                     h.Obs
                                 }).ToList();

                Negadas.DataSource = negativas;
                //Negadas.Refresh();
            }
        }

        private void Negadas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 100 || e.KeyChar == 68)
            {
                DialogResult result1 = MessageBox.Show("Deseja exluir ?",
                "Atenção !",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    using (DAHUEEntities db = new DAHUEEntities())
                    {
                        historico h = db.historico.First(hi => hi.IdHistorico == idhistorico);
                        db.historico.Remove(h);
                        db.SaveChanges();

                        MessageBox.Show("Deletado !", "Sys");
                    }
                }
                puxarReagendamentoENegadas();
            }
        }

        private void ListaReagementos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 100 || e.KeyChar == 68)
            {
                DialogResult result1 = MessageBox.Show("Deseja exluir ?",
                "Atenção !",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    using (DAHUEEntities db = new DAHUEEntities())
                    {
                        solicitacoes_agendamentos sa = db.solicitacoes_agendamentos.First(saa => saa.idSolicitacao_paciente == paciente);
                        db.solicitacoes_agendamentos.Remove(sa);
                        db.SaveChanges();
                        MessageBox.Show("Deletado !", "Sys");
                    }
                }
                puxarReagendamentoENegadas();
            }
        }

        private void Negadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idhistorico = Convert.ToInt32(Negadas.Rows[e.RowIndex].Cells["IdHistorico"].Value.ToString());
        }
    }
}
