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

namespace WindowsFormsApplication2
{
    public partial class Solicitacoes : Form
    {
        int Id, idAm;
        string contarSemPrioridade, contarComPrioridade, contarAgendadas;
        string tipo, statusAM;
        public Solicitacoes(int AMocup, string StatusAM)
        {
            InitializeComponent();
            puxarComPrioridade();
            puxarSemPrioridade();
            puxarAgendadas();
            idAm = AMocup;
            statusAM = StatusAM;
            txtTotal1.Text = contarComPrioridade;
            txtTotal2.Text = contarSemPrioridade;
            txtTotal3.Text = contarAgendadas;
            if (this.Focus())
            {
                puxarComPrioridade();
                puxarSemPrioridade();
                puxarAgendadas();

            }
        }
        

        public void puxarSemPrioridade()
        {
            int zero = 0;
            using(DAHUEEntities db = new DAHUEEntities()){
                var query = from solicitacoes_paciente in db.solicitacoes_paciente
                            where solicitacoes_paciente.AmSolicitada == zero && 
                            solicitacoes_paciente.Prioridade == "False" && 
                            solicitacoes_paciente.Agendamento == "Nao"
                            select new
                            {
                                solicitacoes_paciente.idPaciente_Solicitacoes,
                                solicitacoes_paciente.Paciente,
                                solicitacoes_paciente.TipoSolicitacao,
                                solicitacoes_paciente.DtHrdoInicio,
                                solicitacoes_paciente.Motivo,
                                solicitacoes_paciente.Origem,
                                solicitacoes_paciente.Destino,
                            };

                var contar = query.Count();
                contarSemPrioridade = contar.ToString();

                var queryAmbu = query.ToList();
                ListaSemPrioridade.DataSource = queryAmbu;
                ListaSemPrioridade.ClearSelection();
           
            }
        }

        public void puxarComPrioridade()
        {
            int zero = 0;

            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from solicitacoes_paciente in db.solicitacoes_paciente
                            where solicitacoes_paciente.AmSolicitada == zero &&
                            solicitacoes_paciente.Prioridade == "True"
                            select new
                            {
                                solicitacoes_paciente.idPaciente_Solicitacoes,
                                solicitacoes_paciente.Paciente,
                                solicitacoes_paciente.TipoSolicitacao,
                                solicitacoes_paciente.DtHrdoInicio,
                                solicitacoes_paciente.Motivo,
                                solicitacoes_paciente.Origem,
                                solicitacoes_paciente.Destino,
                            };

                var queryAmbu = query.ToList();
                var contar = query.Count();
                contarComPrioridade = contar.ToString();
                listaComPrioridade.DataSource = queryAmbu;
                listaComPrioridade.ClearSelection();

            }
        }

        public void puxarAgendadas()
        {
            int zero = 0;
            DateTime Data = DateTime.Now;
            string dataagora = Data.ToString("dd/MM/yyyy");

            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from solicitacoes_paciente in db.solicitacoes_paciente
                            where solicitacoes_paciente.AmSolicitada == zero &&
                            solicitacoes_paciente.Agendamento == "Sim" &&
                            solicitacoes_paciente.DtHrAgendamento.Substring(0, 10) != dataagora
                            select new
                            {
                                solicitacoes_paciente.idPaciente_Solicitacoes,
                                solicitacoes_paciente.Paciente,
                                solicitacoes_paciente.Agendamento,
                                solicitacoes_paciente.DtHrAgendamento,
                                solicitacoes_paciente.TipoSolicitacao,
                                solicitacoes_paciente.DtHrdoInicio,
                                solicitacoes_paciente.Motivo,
                                solicitacoes_paciente.Origem,
                                solicitacoes_paciente.Destino,
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
            listaComPrioridade.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            listaComPrioridade.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void ListaSemPrioridade_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ListaSemPrioridade.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            ListaSemPrioridade.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void listaAgendadas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            listaAgendadas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            listaAgendadas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void listaComPrioridade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var querya = (String)null;
            using(DAHUEEntities db = new DAHUEEntities())
            {
               var query = from am in db.ambulancia
                            where am.idAmbulancia == idAm
                            select am.TipoAM;
               querya = query.FirstOrDefault();
            }
            Id = Convert.ToInt32(listaComPrioridade.Rows[e.RowIndex].Cells[0].Value.ToString());
            tipo = listaComPrioridade.Rows[e.RowIndex].Cells[2].Value.ToString();

            if (querya == "")
            {
                SelecionaAM ST = new SelecionaAM(Id, idAm, null, statusAM);
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

            SelecionaAM STi = new SelecionaAM(Id, idAm, null, statusAM);
            this.Dispose();
            STi.ShowDialog();
        }

        private void listaAgendadas_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var querya = (String)null;
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from am in db.ambulancia
                            where am.idAmbulancia == idAm
                            select am.TipoAM;
                querya = query.FirstOrDefault();
            }
            Id = Convert.ToInt32(listaAgendadas.Rows[e.RowIndex].Cells[0].Value.ToString());
            tipo = listaAgendadas.Rows[e.RowIndex].Cells[2].Value.ToString();

            if (querya == "")
            {
                SelecionaAM ST = new SelecionaAM(Id, idAm, null, statusAM);
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

            SelecionaAM STi = new SelecionaAM(Id, idAm, null, statusAM);
            this.Dispose();
            STi.ShowDialog();
        }

        private void ListaSemPrioridade_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var querya = (String)null;
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from am in db.ambulancia
                            where am.idAmbulancia == idAm
                            select am.TipoAM;
                querya = query.FirstOrDefault();
            }
            Id = Convert.ToInt32(ListaSemPrioridade.Rows[e.RowIndex].Cells[0].Value.ToString());
            tipo = ListaSemPrioridade.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();

            if (querya == "")
            {
                SelecionaAM ST = new SelecionaAM(Id, idAm, null, statusAM);
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

            SelecionaAM STi = new SelecionaAM(Id, idAm, null, statusAM);
            this.Dispose();
            STi.ShowDialog();
        }



    }
}
