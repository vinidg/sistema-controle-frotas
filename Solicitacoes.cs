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
using db_transporte_sanitario;

namespace Sistema_Controle
{
    public partial class Solicitacoes : Form
    {
        int idPaciente, idAm;
        string contarComPrioridade, contarAgendadas;
        string tipo, statusAM;
        public Solicitacoes(int AMocup, string StatusAM)
        {
            InitializeComponent();
            puxarSolicitacoes();
            puxarAgendadas();
            idAm = AMocup;
            statusAM = StatusAM;
            txtTotal1.Text = contarComPrioridade;
            txtTotal3.Text = contarAgendadas;
            if (this.Focus())
            {
                puxarSolicitacoes();
                puxarAgendadas();

            }
        }
        
        public void puxarSolicitacoes()
        {
            int zero = 0;

            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            where sp.AmSolicitada == zero &&
                            sp.Registrado == "Sim"
                            select new
                            {
                                ID = sp.idPaciente_Solicitacoes,
                                sp.Paciente,
                                Tipo = sp.TipoSolicitacao,
                                sp.DtHrdoInicio,
                                sp.Prioridade,
                                sp.Motivo,
                                sp.Origem,
                                sp.Destino
                            };

                var queryAmbu = query.ToList();
                var contar = query.Count();
                contarComPrioridade = contar.ToString();
                ListaSolicitacoes.DataSource = queryAmbu;
                ListaSolicitacoes.ClearSelection();

                ListaSolicitacoes.Columns[0].HeaderText = "ID";
             }
        }

        public void puxarAgendadas()
        {
            int zero = 0;
            DateTime Data = DateTime.Now;
            string dataagora = Data.ToString("dd/MM/yyyy");

            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            where sp.AmSolicitada == zero &&
                            sp.Agendamento == "Sim" &&
                            sp.DtHrAgendamento.Substring(0, 10) != dataagora &&
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
                var contar = query.Count();
                contarAgendadas = contar.ToString();
                listaAgendadas.DataSource = queryAmbu;
                listaAgendadas.ClearSelection();


            }
        }

        private void listaComPrioridade_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ListaSolicitacoes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            ListaSolicitacoes.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void listaAgendadas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            listaAgendadas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            listaAgendadas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void listaComPrioridade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var querya = (String)null;
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    var query = from am in db.ambulancia
                                where am.idAmbulancia == idAm
                                select am.TipoAM;
                    querya = query.FirstOrDefault();
                }
                idPaciente = Convert.ToInt32(ListaSolicitacoes.Rows[e.RowIndex].Cells[0].Value.ToString());
                tipo = ListaSolicitacoes.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();

                if (querya == null)
                {
                    SelecionaAM ST = new SelecionaAM(idPaciente, idAm, 0);
                    this.Dispose();
                    ST.ShowDialog();
                    return;
                }

                if (tipo == "Avancada")
                {
                    if (querya == "BASICO")
                    {
                        MessageBox.Show("Selecionar ambulância do tipo basica ou a solicitação do tipo avançada!");
                        return;
                    }
                }

                if (tipo == "Basica")
                {
                    if (querya == "AVANCADO")
                    {
                        MessageBox.Show("Selecionar ambulância do tipo avançada ou a solicitação do tipo básica!");
                        return;
                    }
                }

                SelecionaAM STi = new SelecionaAM(idPaciente, idAm, 0);
                this.Dispose();
                STi.ShowDialog();
            }
        }

        private void listaAgendadas_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var querya = (String)null;
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    var query = from am in db.ambulancia
                                where am.idAmbulancia == idAm
                                select am.TipoAM;
                    querya = query.FirstOrDefault();
                }
                idPaciente = Convert.ToInt32(listaAgendadas.Rows[e.RowIndex].Cells[0].Value.ToString());
                tipo = listaAgendadas.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();

                if (querya == "")
                {
                    SelecionaAM ST = new SelecionaAM(idPaciente, idAm, 0);
                    this.Dispose();
                    ST.ShowDialog();
                    return;
                }

                if (tipo == "Avancada")
                {
                    MessageBox.Show("Selecionar ambulância do tipo avançada ou a solicitação do tipo básica!");
                    return;
                }

                if (tipo == "Basica")
                {
                    if (querya == "Avancada")
                    {
                        MessageBox.Show("Selecionar ambulância do tipo basica ou a solicitação do tipo avançada!");
                        return;
                    }
                }

                SelecionaAM STi = new SelecionaAM(idPaciente, idAm, 0);
                this.Dispose();
                STi.ShowDialog();
            }
        }

        private void OrdemPrioridade_Click(object sender, EventArgs e)
        {
            int zero = 0;

            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            where sp.AmSolicitada == zero &&
                            sp.Registrado == "Sim"
                            orderby sp.Prioridade ascending
                            select new
                            {
                                ID = sp.idPaciente_Solicitacoes,
                                sp.Paciente,
                                Tipo = sp.TipoSolicitacao,
                                sp.DtHrdoInicio,
                                sp.Prioridade,
                                sp.Motivo,
                                sp.Origem,
                                sp.Destino
                            };

                var queryAmbu = query.ToList();
                var contar = query.Count();
                contarComPrioridade = contar.ToString();
                ListaSolicitacoes.DataSource = queryAmbu;
                ListaSolicitacoes.ClearSelection();

                ListaSolicitacoes.Columns[0].HeaderText = "ID";
            }
        }

        private void OrdemData_Click(object sender, EventArgs e)
        {
            int zero = 0;

            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            where sp.AmSolicitada == zero &&
                            sp.Registrado == "Sim"
                            orderby sp.DtHrdoInicio descending
                            select new
                            {
                                ID = sp.idPaciente_Solicitacoes,
                                sp.Paciente,
                                Tipo = sp.TipoSolicitacao,
                                sp.DtHrdoInicio,
                                sp.Prioridade,
                                sp.Motivo,
                                sp.Origem,
                                sp.Destino
                            };

                var queryAmbu = query.ToList();
                var contar = query.Count();
                contarComPrioridade = contar.ToString();
                ListaSolicitacoes.DataSource = queryAmbu;
                ListaSolicitacoes.ClearSelection();

                ListaSolicitacoes.Columns[0].HeaderText = "ID";
            }
        }

        private void OrdemPaciente_Click(object sender, EventArgs e)
        {
            int zero = 0;

            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            where sp.AmSolicitada == zero &&
                            sp.Registrado == "Sim"
                            orderby sp.Paciente ascending
                            select new
                            {
                                ID = sp.idPaciente_Solicitacoes,
                                sp.Paciente,
                                Tipo = sp.TipoSolicitacao,
                                sp.DtHrdoInicio,
                                sp.Prioridade,
                                sp.Motivo,
                                sp.Origem,
                                sp.Destino
                            };

                var queryAmbu = query.ToList();
                var contar = query.Count();
                contarComPrioridade = contar.ToString();
                ListaSolicitacoes.DataSource = queryAmbu;
                ListaSolicitacoes.ClearSelection();

                ListaSolicitacoes.Columns[0].HeaderText = "ID";
            }
        }

        private void OrdemPrioridadeAgenda_Click(object sender, EventArgs e)
        {
            int zero = 0;
            DateTime Data = DateTime.Now;
            string dataagora = Data.ToString("dd/MM/yyyy");

            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            where sp.AmSolicitada == zero &&
                            sp.Agendamento == "Sim" &&
                            sp.DtHrAgendamento.Substring(0, 10) != dataagora &&
                            sp.Registrado == "Sim"
                            orderby sp.Prioridade descending
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
                var contar = query.Count();
                contarAgendadas = contar.ToString();
                listaAgendadas.DataSource = queryAmbu;
                listaAgendadas.ClearSelection();


            }
        
        }

        private void OrdemDataAgenda_Click(object sender, EventArgs e)
        {
            int zero = 0;
            DateTime Data = DateTime.Now;
            string dataagora = Data.ToString("dd/MM/yyyy");

            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            where sp.AmSolicitada == zero &&
                            sp.Agendamento == "Sim" &&
                            sp.DtHrAgendamento.Substring(0, 10) != dataagora &&
                            sp.Registrado == "Sim"
                            orderby sp.DtHrdoInicio descending
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
                var contar = query.Count();
                contarAgendadas = contar.ToString();
                listaAgendadas.DataSource = queryAmbu;
                listaAgendadas.ClearSelection();


            }
        }

        private void OrdemNomeAgenda_Click(object sender, EventArgs e)
        {
            int zero = 0;
            DateTime Data = DateTime.Now;
            string dataagora = Data.ToString("dd/MM/yyyy");

            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            where sp.AmSolicitada == zero &&
                            sp.Agendamento == "Sim" &&
                            sp.DtHrAgendamento.Substring(0, 10) != dataagora &&
                            sp.Registrado == "Sim"
                            orderby sp.Paciente ascending
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
                var contar = query.Count();
                contarAgendadas = contar.ToString();
                listaAgendadas.DataSource = queryAmbu;
                listaAgendadas.ClearSelection();


            }
        }

     }
}
