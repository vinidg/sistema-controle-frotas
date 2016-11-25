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
using System.Data.Entity.SqlServer;
using System.Collections;

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
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            where sp.AmSolicitada == 0 &&
                            sp.Agendamento == "Nao" &&
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
                txtTotal1.Text = contar.ToString();
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

            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            join saa in db.solicitacoes_agendamentos
                            on sp.idReagendamento equals saa.idSolicitacaoAgendamento into spsaaajoin
                            from saa in spsaaajoin.DefaultIfEmpty()
                            where sp.AmSolicitada == zero &&
                            sp.Agendamento == "Sim"
                            && sp.Registrado == "Sim"
                            && SqlFunctions.DateDiff("day", Data, sp.DtHrdoAgendamento) == 0 
                            orderby sp.Paciente ascending
                            select new
                            {
                                ID = sp.idPaciente_Solicitacoes,
                                sp.Paciente,
                                Tipo = sp.TipoSolicitacao,
                                sp.DtHrdoInicio,
                                sp.DtHrdoAgendamento,
                                Data_Reagendada = saa.DtHrAgendamento,
                                sp.Prioridade,
                                sp.Motivo,
                                sp.Origem,
                                sp.Destino
                            };

                var queryAmbu = query.ToList();
                var contar = query.Count();
                contarAgendadas = contar.ToString();
                txtTotal3.Text = contar.ToString();
                listaAgendadas.DataSource = queryAmbu;
                listaAgendadas.ClearSelection();

            }
            foreach (DataGridViewColumn column in listaAgendadas.Columns)
            {

                column.SortMode = DataGridViewColumnSortMode.Automatic;
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
            listaAgendadas.Columns["Data_Reagendada"].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            listaAgendadas.Columns["Data_Reagendada"].HeaderCell.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
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

                    if (querya == "BASICO")
                    {
                        MessageBox.Show("Selecionar ambulância do tipo avançada ou a solicitação do tipo básica!");
                        return;
                    }
                }

                if (tipo == "Basica")
                {
                    if (querya == "AVANCADO")
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

        #region Ordernacao
        private void OrdemPrioridade_Click(object sender, EventArgs e)
        {
            int zero = 0;
            ListaSolicitacoes.DataSource = "";
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            where sp.AmSolicitada == zero &&
                            sp.Registrado == "Sim" &&
                            sp.Agendamento == "Nao"
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
                txtTotal1.Text = contar.ToString();
                ListaSolicitacoes.DataSource = queryAmbu;
                ListaSolicitacoes.ClearSelection();

            }
            OrdemPrioridade.Font = new Font(dtagenda.Font, FontStyle.Bold);
            OrdemPaciente.Font = new Font(OrdemDataAgenda.Font, FontStyle.Regular);
            OrdemData.Font = new Font(OrdemPrioridadeAgenda.Font, FontStyle.Regular);
        }
        private void OrdemData_Click(object sender, EventArgs e)
        {
            int zero = 0;
            ListaSolicitacoes.DataSource = "";
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            where sp.AmSolicitada == zero &&
                            sp.Registrado == "Sim" &&
                            sp.Agendamento == "Nao"
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
                txtTotal1.Text = contar.ToString();
                ListaSolicitacoes.DataSource = queryAmbu;
                ListaSolicitacoes.ClearSelection();
            }
           OrdemData.Font = new Font(dtagenda.Font, FontStyle.Bold);
           OrdemPaciente.Font = new Font(OrdemDataAgenda.Font, FontStyle.Regular);
           OrdemPrioridade.Font = new Font(OrdemPrioridadeAgenda.Font, FontStyle.Regular);
        }
        private void OrdemPaciente_Click(object sender, EventArgs e)
        {
            int zero = 0;
            ListaSolicitacoes.DataSource = "";
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            where sp.AmSolicitada == zero &&
                            sp.Registrado == "Sim" &&
                            sp.Agendamento == "Nao"
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
                txtTotal1.Text = contar.ToString();
                ListaSolicitacoes.DataSource = queryAmbu;
                ListaSolicitacoes.ClearSelection();

                ListaSolicitacoes.Columns[0].HeaderText = "ID";
            }
            OrdemPaciente.Font = new Font(dtagenda.Font, FontStyle.Bold);
            OrdemData.Font = new Font(OrdemDataAgenda.Font, FontStyle.Regular);
            OrdemPrioridade.Font = new Font(OrdemPrioridadeAgenda.Font, FontStyle.Regular);

        }
        private void OrdemPrioridadeAgenda_Click(object sender, EventArgs e)
        {
            int zero = 0;
            listaAgendadas.DataSource = "";
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            join saa in db.solicitacoes_agendamentos
                            on sp.idReagendamento equals saa.idSolicitacaoAgendamento into spsaaajoin
                            from saa in spsaaajoin.DefaultIfEmpty()                                                              
                            where sp.AmSolicitada == zero &&
                            sp.Agendamento == "Sim" &&
                            sp.Registrado == "Sim"
                            orderby sp.Prioridade descending
                            select new
                            {
                                ID = sp.idPaciente_Solicitacoes,
                                sp.Paciente,
                                Tipo = sp.TipoSolicitacao,
                                sp.DtHrdoInicio,
                                sp.DtHrdoAgendamento,
                                Data_Reagendada = saa.DtHrAgendamento,
                                sp.Prioridade,
                                sp.Motivo,
                                sp.Origem,
                                sp.Destino
                            };

                var queryAmbu = query.ToList();
                var contar = query.Count();
                contarAgendadas = contar.ToString();
                txtTotal3.Text = contar.ToString();
                listaAgendadas.DataSource = queryAmbu;
                listaAgendadas.ClearSelection();
            }

            OrdemPrioridadeAgenda.Font = new Font(dtagenda.Font, FontStyle.Bold);
            dtagenda.Font = new Font(dtreagenda.Font, FontStyle.Regular);
            dataFiltroAgenda.Font = new Font(dtreagenda.Font, FontStyle.Regular);
            OrdemNomeAgenda.Font = new Font(OrdemDataAgenda.Font, FontStyle.Regular);
            OrdemDataAgenda.Font = new Font(OrdemPrioridadeAgenda.Font, FontStyle.Regular);
            dtreagenda.Font = new Font(OrdemNomeAgenda.Font, FontStyle.Regular);
            dataReagendamento.Font = new Font(OrdemNomeAgenda.Font, FontStyle.Regular);
        }
        private void OrdemDataAgenda_Click(object sender, EventArgs e)
        {
            int zero = 0;
            listaAgendadas.DataSource = "";
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            join saa in db.solicitacoes_agendamentos
                            on sp.idReagendamento equals saa.idSolicitacaoAgendamento into spsaaajoin
                            from saa in spsaaajoin.DefaultIfEmpty()
                            where sp.AmSolicitada == zero &&
                            sp.Agendamento == "Sim" &&
                            sp.Registrado == "Sim"
                            orderby sp.DtHrdoInicio descending
                            select new
                            {
                                ID = sp.idPaciente_Solicitacoes,
                                sp.Paciente,
                                Tipo = sp.TipoSolicitacao,
                                sp.DtHrdoInicio,
                                sp.DtHrdoAgendamento,
                                Data_Reagendada = saa.DtHrAgendamento,
                                sp.Prioridade,
                                sp.Motivo,
                                sp.Origem,
                                sp.Destino
                            };

                var queryAmbu = query.ToList();
                var contar = query.Count();
                contarAgendadas = contar.ToString();
                txtTotal3.Text = contar.ToString();
                listaAgendadas.DataSource = queryAmbu;
                listaAgendadas.ClearSelection();


            }
            OrdemDataAgenda.Font = new Font(dtagenda.Font, FontStyle.Bold);
            dtagenda.Font = new Font(dtreagenda.Font, FontStyle.Regular);
            dataFiltroAgenda.Font = new Font(OrdemNomeAgenda.Font, FontStyle.Regular);
            OrdemNomeAgenda.Font = new Font(OrdemDataAgenda.Font, FontStyle.Regular);
            OrdemPrioridadeAgenda.Font = new Font(OrdemPrioridadeAgenda.Font, FontStyle.Regular);
            dtreagenda.Font = new Font(OrdemNomeAgenda.Font, FontStyle.Regular);
            dataReagendamento.Font = new Font(OrdemNomeAgenda.Font, FontStyle.Regular);

        }

        private void OrdemNomeAgenda_Click(object sender, EventArgs e)
        {
            int zero = 0;
            listaAgendadas.DataSource = "";
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            join saa in db.solicitacoes_agendamentos
                            on sp.idReagendamento equals saa.idSolicitacaoAgendamento into spsaaajoin
                            from saa in spsaaajoin.DefaultIfEmpty()
                            where sp.AmSolicitada == zero &&
                            sp.Agendamento == "Sim" &&
                            sp.Registrado == "Sim"
                            orderby sp.Paciente ascending
                            select new
                            {
                                ID = sp.idPaciente_Solicitacoes,
                                sp.Paciente,
                                Tipo = sp.TipoSolicitacao,
                                sp.DtHrdoInicio,
                                sp.DtHrdoAgendamento,
                                Data_Reagendada = saa.DtHrAgendamento,
                                sp.Prioridade,
                                sp.Motivo,
                                sp.Origem,
                                sp.Destino
                            };

                var queryAmbu = query.ToList();
                var contar = query.Count();
                contarAgendadas = contar.ToString();
                txtTotal3.Text = contar.ToString();
                listaAgendadas.DataSource = queryAmbu;
                listaAgendadas.ClearSelection();


            }

            OrdemNomeAgenda.Font = new Font(dtagenda.Font, FontStyle.Bold);
            dtagenda.Font = new Font(dtreagenda.Font, FontStyle.Regular);
            dataFiltroAgenda.Font = new Font(OrdemNomeAgenda.Font, FontStyle.Regular);
            OrdemDataAgenda.Font = new Font(OrdemDataAgenda.Font, FontStyle.Regular);
            OrdemPrioridadeAgenda.Font = new Font(OrdemPrioridadeAgenda.Font, FontStyle.Regular);
            dtreagenda.Font = new Font(OrdemNomeAgenda.Font, FontStyle.Regular);
            dataReagendamento.Font = new Font(OrdemNomeAgenda.Font, FontStyle.Regular);
        }
        private void dataFiltroAgenda_ValueChanged(object sender, EventArgs e)
        {
            int zero = 0;
            
            dtagenda.Font = new Font(dtagenda.Font, FontStyle.Bold);
            dataFiltroAgenda.Font = new Font(OrdemNomeAgenda.Font, FontStyle.Bold);
            dtreagenda.Font = new Font(dtreagenda.Font, FontStyle.Regular);
            dataReagendamento.Font = new Font(OrdemNomeAgenda.Font, FontStyle.Regular);
            OrdemDataAgenda.Font = new Font(OrdemDataAgenda.Font, FontStyle.Regular);
            OrdemPrioridadeAgenda.Font = new Font(OrdemPrioridadeAgenda.Font, FontStyle.Regular);
            OrdemNomeAgenda.Font = new Font(OrdemNomeAgenda.Font, FontStyle.Regular);


            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            join saa in db.solicitacoes_agendamentos
                            on sp.idReagendamento equals saa.idSolicitacaoAgendamento into spsaaajoin
                            from saa in spsaaajoin.DefaultIfEmpty()
                            where sp.AmSolicitada == zero &&
                            sp.Agendamento == "Sim" &&
                            sp.Registrado == "Sim" &&
                            SqlFunctions.DateDiff("day", dataFiltroAgenda.Value, sp.DtHrdoAgendamento) == 0
                            select new
                            {
                                ID = sp.idPaciente_Solicitacoes,
                                sp.Paciente,
                                Tipo = sp.TipoSolicitacao,
                                sp.DtHrdoInicio,
                                sp.DtHrdoAgendamento,
                                Data_Reagendada = saa.DtHrAgendamento,
                                sp.Prioridade,
                                sp.Motivo,
                                sp.Origem,
                                sp.Destino
                            };

                var queryAmbu = query.ToList();
                var contar = query.Count();
                contarAgendadas = contar.ToString();
                txtTotal3.Text = contar.ToString();
                listaAgendadas.DataSource = queryAmbu;
                listaAgendadas.ClearSelection();

            }

        }
        private void dataReagendamento_ValueChanged(object sender, EventArgs e)
        {
            int zero = 0;
            DateTime Data = DateTime.Now;
          
            dtreagenda.Font = new Font(dtagenda.Font, FontStyle.Bold);
            dataReagendamento.Font = new Font(OrdemNomeAgenda.Font, FontStyle.Bold);
            dtagenda.Font = new Font(dtreagenda.Font, FontStyle.Regular);
            dataFiltroAgenda.Font = new Font(OrdemNomeAgenda.Font, FontStyle.Regular);
            OrdemDataAgenda.Font = new Font(OrdemDataAgenda.Font, FontStyle.Regular);
            OrdemPrioridadeAgenda.Font = new Font(OrdemPrioridadeAgenda.Font, FontStyle.Regular);
            OrdemNomeAgenda.Font = new Font(OrdemNomeAgenda.Font, FontStyle.Regular);

            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sp in db.solicitacoes_paciente
                            join saa in db.solicitacoes_agendamentos
                            on sp.idReagendamento equals saa.idSolicitacaoAgendamento into spsaaajoin
                            from saa in spsaaajoin.DefaultIfEmpty()
                            where sp.AmSolicitada == zero &&
                            sp.Agendamento == "Sim" &&
                            sp.Registrado == "Sim" &&
                            SqlFunctions.DateDiff("day", dataReagendamento.Value, saa.DtHrAgendamento) == 0
                            select new
                            {
                                ID = sp.idPaciente_Solicitacoes,
                                sp.Paciente,
                                Tipo = sp.TipoSolicitacao,
                                sp.DtHrdoInicio,
                                sp.DtHrdoAgendamento,
                                Data_Reagendada = saa.DtHrAgendamento,
                                sp.Prioridade,
                                sp.Motivo,
                                sp.Origem,
                                sp.Destino
                            };

                var queryAmbu = query.ToList();
                var contar = query.Count();
                contarAgendadas = contar.ToString();
                txtTotal3.Text = contar.ToString();
                listaAgendadas.DataSource = queryAmbu;
                listaAgendadas.ClearSelection();

            }
        }

        #endregion

        private void iomprimirAgendamentos_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            ((Form)objPPdialog).WindowState = FormWindowState.Maximized;
            objPPdialog.Document = printDocument1;
            objPPdialog.ShowDialog();

        }
        #region Member Variables Print
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        #endregion
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                printDocument1.DefaultPageSettings.Landscape = true;
                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in listaAgendadas.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Font fonte = new Font("Arial", 8);
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;             
                
                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in listaAgendadas.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= listaAgendadas.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = listaAgendadas.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 6;
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Agendamentos do dia", new Font(fonte, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Agendamentos do dia", new Font(fonte,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(fonte, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(fonte,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Agendamentos do dia", new Font(new Font(fonte,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in listaAgendadas.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), fonte,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);

                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;                    
                }                

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

    }
}
