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
using System.Data.Objects.SqlClient;

namespace Sistema_Controle
{
    public partial class RespostaDeAmbulancias : Form
    {
        int idPaciente;
        public RespostaDeAmbulancias()
        {
            InitializeComponent();
            puxarAgendadas();
        }

        public void puxarAgendadas()
        {
            int zero = 0;
            var data = Calendario.SelectionRange.Start;
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            where sp.AmSolicitada == zero &&
                            sp.Agendamento == "Sim" &&
                            SqlFunctions.DateDiff("day",sp.DtHrdoAgendamento,"24/08/2016") == 0 &&
                            sp.Registrado == "Sim"
                            select new
                            {
                                ID = sp.idPaciente_Solicitacoes,
                                sp.Paciente,
                                sp.Agendamento,
                                sp.DtHrAgendamento,
                                Tipo = sp.TipoSolicitacao,
                                sp.DtHrdoInicio,
                                sp.Prioridade,
                                sp.Motivo,
                                sp.Origem,
                                sp.Destino
                            };

                var queryAmbu = query.ToList();
                ListaAgendados.DataSource = queryAmbu;
                ListaAgendados.ClearSelection();

             }
        }

        private void ListaAgendados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                idPaciente = Convert.ToInt32(ListaAgendados.Rows[e.RowIndex].Cells[0].Value.ToString());
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    var query = (from sp in db.solicitacoes_paciente
                                where sp.idPaciente_Solicitacoes == idPaciente
                                select sp).FirstOrDefault();
                    id.Text = query.idPaciente_Solicitacoes.ToString();
                    Tipo.Text = query.TipoSolicitacao;
                    DataInicio.Text = query.DtHrdoInicio.ToString();
                    DataHrAgendamento.Text = query.DtHrAgendamento;
                    NomeSolicitante.Text = query.NomeSolicitante;
                    LocalSolicitacao.Text = query.LocalSolicitacao;
                    Telefone.Text = query.Telefone;
                    NomePaciente.Text = query.Paciente;
                    if (query.Genero == "F")
                    {
                        RbFemenino.Checked = true;
                    }
                    else
                    {
                        RbMasculino.Checked = true;
                    }
                    Idade.Text = query.Idade;
                    Diagnostico.Text = query.Diagnostico;
                    MotivoChamado.Text = query.Motivo;
                    TipoMotivoSelecionado.Text = query.SubMotivo;
                    Prioridade.Text = query.Prioridade;
                    Origem.Text = query.Origem;
                    EnderecoOrigem.Text = query.EnderecoOrigem;
                    Destino.Text = query.Destino;
                    EnderecoDestino.Text = query.EnderecoDestino;
                    Obs.Text = query.ObsGerais;

                }
                


                
            }
        }

        private void Calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            puxarAgendadas();
        }



    }
}
