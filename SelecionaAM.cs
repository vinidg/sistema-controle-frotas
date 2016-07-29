using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Reporting.WebForms;
using System.Drawing.Printing;
using System.Collections.Specialized;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using db_transporte_sanitario;

namespace WindowsFormsApplication2
{
    public partial class SelecionaAM : Form
    {
        string Sexo, Agendamento, TipoAM, STatus, pegamotivo;
        string statusAM, Id, NomeAM;
        int idAmbu, idPaciente;
        string pegaUnidade;     //para pegar o telefone com o nome da unidade
        string pegaUnidadeEnd;  //para pegar o endereco com o nome da unidade
        string Endereco1;

        public SelecionaAM(int Id, int AMocupada, string status, string nomeAM)
        {
            InitializeComponent();
            LabelIDPaciente.Text = Id.ToString();
            idPaciente = Id;
            idAmbu = AMocupada;
            STatus = status;
            NomeAM = nomeAM;
            ConsultarSolicitacao();
            verificaSeAMEstaIncluida();
            VerificarPacienteJaestaInclusoNaMesma();
            PuxarEnderecos();
            pegarDadosDasAmbulancias();
        }


        private void verificaSeAMEstaIncluida()
        {
            if (STatus == "Ocupada")
            {
                PainelAM2.Visible = false;
                label23.Visible = true;
                BtnOutraAM.Visible = true;
                BtnConfimar.Visible = true;
                label22.Visible = true;
                label22.Text = NomeAM;

            }
            else if (NomeAM == "" && STatus == "Disponivel")
            {
                PainelAM2.Visible = false;
                label23.Visible = true;
                BtnOutraAM.Visible = true;
                BtnConfimar.Visible = true;
                label22.Visible = true;
                label22.Text = NomeAM;
            }

        }

        private void VerificarPacienteJaestaInclusoNaMesma()
        {
            using(DAHUEEntities db = new DAHUEEntities())
            {
                var query = from sa in db.solicitacoes_ambulancias
                            where sa.idSolicitacoesPacientes == idPaciente && sa.idAmbulanciaSol == idAmbu
                                select sa;
                int newProdID = query.Count();
                if (newProdID >= 1)
                {
                    PainelAM2.Visible = false;
                    label23.Visible = false;
                    BtnOutraAM.Visible = false;
                    BtnConfimar.Visible = false;
                    label22.Visible = false;
                    label22.Text = NomeAM;
                }
            }

        }

        private void ConsultarSolicitacao()
        {
            //buscar informacoes pelo id da tabela

            string sqlQuery = "select * from solicitacoes_paciente WHERE idPaciente_Solicitacoes='" + LabelIDPaciente.Text + "'";
            using(DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from sp in db.solicitacoes_paciente
                            where sp.idPaciente_Solicitacoes == idPaciente
                            select sp).FirstOrDefault();
            
                    if (query.TipoSolicitacao == "Avancada")
                    {
                        BtnBasica.Visible = false;
                        BtnAvancada.BackColor = Color.Teal;
                    }
                    else
                    {
                        BtnAvancada.Visible = false;
                        BtnBasica.BackColor = Color.Teal;
                    }

                    if (query.Agendamento == "Sim")
                    {
                        Btnagendanao.Visible = false;
                        label3.Visible = true;
                        txtAtendMarcado.Visible = true;
                        Btnagendasim.BackColor = Color.Teal;
                    }
                    else
                    {
                        Btnagendasim.Visible = false;
                        label3.Visible = false;
                        Btnagendanao.BackColor = Color.Teal;
                        txtAtendMarcado.Visible = false;
                    }

                        txtAtendMarcado.Text = query.DtHrAgendamento;
                        txtNomeSolicitante.Text = query.NomeSolicitante;
                        CbLocalSolicita.Text = query.LocalSolicitacao;
                        txtTelefone.Text = query.Telefone;
                        txtNomePaciente.Text = query.Paciente;

                    if (query.Genero == "F")
                    {
                        RbFemenino.Checked = true;
                    }
                    else
                    {
                        RbMasculino.Checked = true;
                    }
                        txtIdade.Text = query.Idade;
                        txtDiagnostico.Text = query.Diagnostico;
                        CbMotivoChamado.Text = query.Motivo;
                        CbTipoMotivoSelecionado.Text = query.SubMotivo;
                    if (query.Prioridade == "False")
                    {
                        CbAtendimentoPrioridade.Checked = false;
                    }
                    else
                    {
                        CbAtendimentoPrioridade.Checked = true;
                    }
                        CbOrigem.Text = query.Origem;
                        txtEnderecoOrigem.Text = query.EnderecoOrigem;
                        CbDestino.Text = query.Destino;
                        txtEnderecoDestino.Text = query.EnderecoDestino;
                        richTextBox1.Text = query.ObsGerais;

            }
        }

        private void BtnOutraAM_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            painelCancelar.Visible = true;
            DtHrCancelamento.Text = DateTime.Now.ToString();
            txtResponsavel.Text = System.Environment.UserName;

        }
        private void cancelar()
        {
            StatusBD d = new StatusBD();
            d.atualizarStatusOcupado(idAmbu);

            InsercoesDoBando ib = new InsercoesDoBando();
            ib.cancelarSolicitacao(idPaciente, d.IdSolicitacoes_Ambulancias, MotivoCancelar.Text, DtHrCancelamento.Text,
                txtResponsavel.Text, txtObsCancelamento.Text, idAmbu);
           
        }

        private void BtnConfimar_Click(object sender, EventArgs e)
        {
            verificarAMstatus();
            ConfirmaAM();
            PainelAM2.Visible = true;

        }
        private void BtnUTI01_Click(object sender, EventArgs e)
        {
            //Clique duplo do datatable
            PainelAM2.Visible = false;
            label22.Text = "AM 01";

        }
        public void pegarDadosDasAmbulancias()
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from am in db.ambulancia
                               join sa in db.solicitacoes_ambulancias
                               on new { idAmbulanciaSol = am.idAmbulancia, SolicitacaoConcluida = 0 }
                               equals new { sa.idAmbulanciaSol, SolicitacaoConcluida = (int)sa.SolicitacaoConcluida } into sa_join
                               from sa in sa_join.DefaultIfEmpty()
                               join sp in db.solicitacoes_paciente on new { idSolicitacoesPacientes = (int)sa.idSolicitacoesPacientes } equals new { idSolicitacoesPacientes = sp.idPaciente_Solicitacoes } into sp_join
                               from sp in sp_join.DefaultIfEmpty()
                               orderby am.idAmbulancia
                               select new
                               {
                                   am.idAmbulancia,
                                   am.NomeAmbulancia,
                                   am.StatusAmbulancia,
                                   Paciente = sp.Paciente,
                                   Idade = sp.Idade,
                                   Origem = sp.Origem,
                                   Destino = sp.Destino
                               };

                var queryAmbulanciaUsb = query.ToList();

                Lista.DataSource = queryAmbulanciaUsb;
                Lista.ClearSelection();

                Lista.Columns[0].Visible = false;
                Lista.Columns[1].HeaderText = "Ambulancia";
                Lista.Columns[2].HeaderText = "Status";
            }
        }
        private void verificarAMstatus()
        {
            StatusBD statusBD = new StatusBD();
     
                if (statusAM == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (statusAM == "OCUPADA")
                {
                    statusBD.countparaMaxPacientes(1);
                    if (statusBD.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (statusBD.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    }
                
            }
        }
        private void ConfirmaAM()
        {

            //registrar a solicitacao de ambulancia
            SqlConnection conexao = ConexaoSqlServer.GetConexao();

            string sqlQuery = "insert into solicitacoes_ambulancias(idSolicitacoesPacientes,idAmbulanciaSol,SolicitacaoConcluida) values " +
            "('" + LabelIDPaciente.Text + "','" + idAmbu + "','" + 0 + "');" +
            "UPDATE ambulancia SET Status = 'OCUPADA' WHERE idAmbulancia=" + idAmbu + ";" +
            "UPDATE solicitacoes_paciente SET AmSolicitada = '1' WHERE idPaciente_Solicitacoes = " + LabelIDPaciente.Text + ";";
            try
            {
                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                SqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();

                MessageBox.Show("Solicitação salva com sucesso !!!");
            }
            finally
            {
                conexao.Close();
                this.Dispose();
            }

        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            imprimirFicha();
        }
        public void imprimirFicha()
        {
            // ConsultarSolicitaoRelatorio();

            StatusBD d = new StatusBD();
            Status am = new Status(idAmbu);
            string amSolicitada = am.NomeAM1;
            d.atualizarStatusOcupado(idAmbu);
            d.selectEquipeBD(idAmbu);

            string tipoAM, Agendade, Sexo, priori, cancelado;
            if (MotivoCancelar.Text != "")
            {
                cancelado = "Sim";
            }
            else
            {
                cancelado = "Não";
            }
            if (BtnAvancada.Visible == true)
            {
                tipoAM = "Avançada";
            }
            else
            {
                tipoAM = "Básica";
            }
            if (Btnagendasim.Visible == true)
            {
                Agendade = "Sim";
            }
            else
            {
                Agendade = "Não";
            }
            if (RbMasculino.Checked == true)
            {
                Sexo = "Masculino";
            }
            else
            {
                Sexo = "Feminino";
            } if (CbAtendimentoPrioridade.Checked == true)
            {
                priori = "Sim";
            }
            else
            {
                priori = "Não";
            }

            int n = 34;
            ReportViewer report = new ReportViewer();
            report.ProcessingMode = ProcessingMode.Local;
            report.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication2.Report1.rdlc";
            ReportParameter[] listReport = new ReportParameter[n];
            listReport[0] = new ReportParameter("Nome", txtNomePaciente.Text);
            listReport[1] = new ReportParameter("Tipo", tipoAM);
            listReport[2] = new ReportParameter("Agendado", Agendade);
            listReport[3] = new ReportParameter("DtHrAgendado", txtAtendMarcado.Text);
            listReport[4] = new ReportParameter("ID", LabelIDPaciente.Text);
            listReport[5] = new ReportParameter("Sexo", Sexo);
            listReport[6] = new ReportParameter("Idade", txtIdade.Text);
            listReport[7] = new ReportParameter("Diagnostico", txtDiagnostico.Text);
            listReport[8] = new ReportParameter("Motivo", CbMotivoChamado.Text);
            listReport[9] = new ReportParameter("Submotivo", CbTipoMotivoSelecionado.Text);
            listReport[10] = new ReportParameter("Origem", CbOrigem.Text);
            listReport[11] = new ReportParameter("Destino", CbDestino.Text);
            listReport[12] = new ReportParameter("EnderecoOrigem", txtEnderecoOrigem.Text);
            listReport[13] = new ReportParameter("EnderecoDestino", txtEnderecoDestino.Text);
            listReport[14] = new ReportParameter("Obsgerais", richTextBox1.Text);
            listReport[15] = new ReportParameter("NomeSolicitante", txtNomeSolicitante.Text);
            listReport[16] = new ReportParameter("LocalSolicitacao", CbLocalSolicita.Text);
            listReport[17] = new ReportParameter("Telefone", txtTelefone.Text);
            listReport[18] = new ReportParameter("Registrado", System.Environment.UserName);
            listReport[19] = new ReportParameter("HrRegistro", DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss"));
            listReport[20] = new ReportParameter("AM", amSolicitada);
            listReport[21] = new ReportParameter("Condutor", d.Condutor1);
            listReport[22] = new ReportParameter("Equipe", d.Equipe1);
            listReport[23] = new ReportParameter("Prioridade", priori);
            listReport[24] = new ReportParameter("Cancelamento", cancelado);
            listReport[25] = new ReportParameter("HrCancelamento", DtHrCancelamento.Text);
            listReport[26] = new ReportParameter("MotivoCancelamento", MotivoCancelar.Text);
            listReport[27] = new ReportParameter("NomeCancelante", txtResponsavel.Text);
            listReport[28] = new ReportParameter("HrCiencia", d.DtHrCiencia1);
            listReport[29] = new ReportParameter("HrSaida", d.DtHrSaidaOrigem1);
            listReport[30] = new ReportParameter("HrLiberacao", d.DtHrLiberacaoEquipe1);
            listReport[31] = new ReportParameter("HrChegadaOrigem", d.DtHrChegadaOrigem1);
            listReport[32] = new ReportParameter("HrChegadaDestino", d.DtHrChegadaDestino1);
            listReport[33] = new ReportParameter("HrEquipepatio", d.DtHrEquipePatio1);
            
            report.LocalReport.SetParameters(listReport);
            report.LocalReport.Refresh();

            //reportViewer1.Visible = true;

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string enconding;
            string extension;

            byte[] bytePDF = report.LocalReport.Render("Pdf", null, out mimeType, out enconding, out extension, out streamids, out warnings);

            FileStream filestrampdf = null;
            string nomeArquivopdf = Path.GetTempPath() + "Impresso_" + txtNomePaciente.Text + DateTime.Now.ToString("_dd_MM_yyyy-HH_mm_ss") + ".pdf";

            filestrampdf = new FileStream(nomeArquivopdf, FileMode.Create);
            filestrampdf.Write(bytePDF, 0, bytePDF.Length);
            filestrampdf.Close();

            Process.Start(nomeArquivopdf);
        }

        private void CancelaSolicitacao_Click(object sender, EventArgs e)
        {
            MotivoCancelar.Text = "";
            txtObsCancelamento.Text = "";
            DtHrCancelamento.Text = "";
            painelCancelar.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Deseja cancelar a solicitação do paciente na ambulancia ?",
            "Atenção !",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                cancelar();
                imprimirFicha();
                this.Dispose();
            }
        }
        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            
            if(txtAtendMarcado.Enabled == false){
            DesbloquarCampos();
            }else
            {
                if (RbFemenino.Checked)
                {
                    Sexo = "F";
                }
                else if (RbMasculino.Checked)
                {
                    Sexo = "M";
                }
                if (Agendamento == "" || TipoAM == "" || Agendamento == null || TipoAM == null)
                {
                    MessageBox.Show("Marque a opção do tipo de ambulancia ou se é agendado !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (txtNomeSolicitante.Text == "" ||
                CbLocalSolicita.Text == "" ||
                txtTelefone.Text == "" ||
                txtNomePaciente.Text == "" ||
                txtIdade.Text == "" ||
                txtDiagnostico.Text == "" ||
                CbMotivoChamado.Text == "" ||
                Sexo == "" ||
                CbTipoMotivoSelecionado.Text == "" ||
                CbOrigem.Text == "" ||
                CbDestino.Text == "" ||
                txtEnderecoOrigem.Text == "" ||
                txtEnderecoDestino.Text == ""){
                

               MessageBox.Show("Verifique se algum campo esta vazio ou desmarcado !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
               MessageBox.Show("Deseja salvar as alterações feitas ?","Atenção !", MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
               AlterarCampos();
                bloquearCampos();

            }

        }

        private void DesbloquarCampos()
        {
            BtnBasica.Location = new Point(330, 12);
            BtnAvancada.Location = new Point(430, 12);
            BtnAvancada.Visible = true;
            BtnBasica.Visible = true;
            Btnagendanao.Visible = true;
            Btnagendasim.Visible = true;
            Btnagendanao.Location = new Point(470, 40);
            Btnagendasim.Location = new Point(390, 40);

            txtAtendMarcado.Enabled = true;
            txtNomeSolicitante.Enabled = true;
            CbLocalSolicita.Enabled = true;
            txtTelefone.Enabled = true;
            txtNomePaciente.Enabled = true;
            RbFemenino.Enabled = true;
            RbMasculino.Enabled = true;
            txtIdade.Enabled = true;
            txtDiagnostico.Enabled = true;
            CbMotivoChamado.Enabled = true;
            CbTipoMotivoSelecionado.Enabled = true;
            CbOrigem.Enabled = true;
            CbDestino.Enabled = true;
            txtEnderecoDestino.Enabled = true;
            txtEnderecoOrigem.Enabled = true;
            richTextBox1.Enabled = true;
            
        }
        private void bloquearCampos()
        {
            BtnBasica.Location = new Point(382, 12);
            BtnAvancada.Location = new Point(382, 12);
            BtnAvancada.Visible = true;
            BtnBasica.Visible = true;
            Btnagendanao.Visible = true;
            Btnagendasim.Visible = true;
            Btnagendanao.Location = new Point(405, 40);
            Btnagendasim.Location = new Point(405, 40);

            txtAtendMarcado.Enabled = false;
            txtNomeSolicitante.Enabled = false;
            CbLocalSolicita.Enabled = false;
            txtTelefone.Enabled = false;
            txtNomePaciente.Enabled = false;
            RbFemenino.Enabled = false;
            RbMasculino.Enabled = false;
            txtIdade.Enabled = false;
            txtDiagnostico.Enabled = false;
            CbMotivoChamado.Enabled = false;
            CbTipoMotivoSelecionado.Enabled = false;
            CbOrigem.Enabled = false;
            CbDestino.Enabled = false;
            txtEnderecoDestino.Enabled = false;
            txtEnderecoOrigem.Enabled = false;
            richTextBox1.Enabled = false;

        }

        private void AlterarCampos()
        {
            SqlConnection conexao = ConexaoSqlServer.GetConexao();
            string sqlQuery = "UPDATE solicitacoes_paciente SET " +
      "[TipoSolicitacao] = '" + TipoAM + "'" +
      ",[DtHrdoInicio] = '" + txtAtendMarcado + "'" +
      ",[Agendamento] = '" + Agendamento + "'" +
      ",[DtHrAgendamento] ='" + txtAtendMarcado.Text + "'" +
      ",[NomeSolicitante] ='" + txtNomeSolicitante.Text + "'" +
      ",[LocalSolicitacao] = '" + CbLocalSolicita.Text + "'" +
      ",[Telefone] = '" + txtTelefone.Text + "'" +
      ",[Paciente] = '" + txtNomePaciente.Text + "'" +
      ",[Genero] = '" + Sexo + "'" +
      ",[Idade] = '" + txtIdade.Text + "'" +
      ",[Diagnostico] = '" + txtDiagnostico.Text + "'" +
      ",[Motivo] = '" + CbMotivoChamado.Text + "'" +
      ",[SubMotivo] = '" + CbTipoMotivoSelecionado.Text + "'" +
      ",[Origem] = '" + CbOrigem.Text + "'" +
      ",[EnderecoOrigem] = '" + txtEnderecoOrigem.Text + "'" +
      ",[Destino] = '" + CbDestino.Text + "'" +
      ",[Registrado] = '" + System.Environment.UserName + "'" +
      ",[HrRegistro] = '" + DateTime.Now + "'" +
      ",[EnderecoDestino] = '" + txtEnderecoDestino.Text + "'" +
      ",[ObsGerais] ='" + richTextBox1.Text + "' WHERE idPaciente_Solicitacoes = '" + LabelIDPaciente.Text + "'";
          try
            {

                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                SqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();


                while (MyReader2.Read())
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();

            }



        }

        private void BtnAvancada_Click(object sender, EventArgs e)
        {
            TipoAM = "Avancada";
                        if (BtnBasica.BackColor == Color.PaleTurquoise)
            {
                BtnAvancada.BackColor = Color.PaleTurquoise;               
                BtnAvancada.ForeColor = Color.Teal;
                BtnBasica.ForeColor = Color.Teal;
                BtnBasica.BackColor = Color.PaleTurquoise;
            }
                BtnBasica.BackColor = Color.PaleTurquoise;
                BtnAvancada.BackColor = Color.Teal;
                BtnAvancada.ForeColor = Color.PaleTurquoise;
                BtnBasica.ForeColor = Color.Teal;
        
        }

        private void BtnBasica_Click(object sender, EventArgs e)
        {
            TipoAM = "Basica";  
            
            
                if (BtnAvancada.BackColor == Color.PaleTurquoise)
            {
                BtnBasica.BackColor = Color.PaleTurquoise;
                BtnBasica.ForeColor = Color.Teal;
                BtnAvancada.ForeColor = Color.Teal;
                BtnAvancada.BackColor = Color.PaleTurquoise;
            }
                BtnAvancada.BackColor = Color.PaleTurquoise;
                BtnBasica.BackColor = Color.Teal;
                BtnBasica.ForeColor = Color.PaleTurquoise;
                BtnAvancada.ForeColor = Color.Teal;
        }

        private void Btnagendasim_Click(object sender, EventArgs e)
        {
            
            txtAtendMarcado.Focus();
            txtAtendMarcado.Text = DateTime.Now.ToString();
            Agendamento = "Sim";

            if (Btnagendanao.BackColor == Color.PaleTurquoise)
            {
                Btnagendanao.BackColor = Color.PaleTurquoise;
                Btnagendanao.ForeColor = Color.Teal;
                Btnagendasim.ForeColor = Color.Teal;
                Btnagendasim.BackColor = Color.PaleTurquoise;

            }

            Btnagendanao.BackColor = Color.PaleTurquoise;
            Btnagendasim.BackColor = Color.Teal;
            Btnagendasim.ForeColor = Color.PaleTurquoise;
            Btnagendanao.ForeColor = Color.Teal;
        }

        private void Btnagendanao_Click(object sender, EventArgs e)
        {
            Agendamento = "Nao";
            if (Btnagendasim.BackColor == Color.PaleTurquoise)
            {
                Btnagendasim.BackColor = Color.PaleTurquoise;
                Btnagendasim.ForeColor = Color.Teal;
                Btnagendanao.ForeColor = Color.Teal;
                Btnagendanao.BackColor = Color.PaleTurquoise;

            }

            Btnagendasim.BackColor = Color.PaleTurquoise;
            Btnagendanao.BackColor = Color.Teal;
            Btnagendanao.ForeColor = Color.PaleTurquoise;
            Btnagendasim.ForeColor = Color.Teal;
        }

        private void CbLocalSolicita_SelectedIndexChanged(object sender, EventArgs e)
        {
            pegaUnidade = CbLocalSolicita.Text;
            unidade_telefone();
        }
        public void unidade_telefone()
        {
            //consulta para mostrar o telefone quando clicar no enderenco
            SqlConnection conexao = ConexaoSqlServer.GetConexao();


            string sqlQuery2 = "select Telefone from enderecos where NomeUnidade = '" + pegaUnidade + "'";
            try
            {
                SqlCommand objComm = new SqlCommand(sqlQuery2, conexao);
                SqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();

                while (MyReader2.Read())
                {
                    txtTelefone.Text = MyReader2.GetString(0);
                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private void PuxarEnderecos()
        {
            //Consultar na tabela de enderecos
            SqlConnection conexao = ConexaoSqlServer.GetConexao();


            string sqlQuery = "select NomeUnidade from enderecos";


            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conexao);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
               string rowz = string.Format("{0}", row.ItemArray[0]);
                CbLocalSolicita.Items.Add(rowz);
                CbDestino.Items.Add(rowz);
                CbOrigem.Items.Add(rowz);
            }

            // MessageBox.Show("Solicitação salva com sucesso !!!");

            conexao.Close();
        }

        private void CbMotivoChamado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbTipoMotivoSelecionado.Items.Clear();
            CbTipoMotivoSelecionado.Text = "";
        }

        private void CbTipoMotivoSelecionado_SelectedIndexChanged(object sender, EventArgs e)
        {
            Motivo();
        }

        private void Motivo()
        {

            //descobrir o que foi selecionado e criar uma variavel para ela
            if (CbMotivoChamado.Text == "ALTA HOSPITALAR")
            {
                pegamotivo = "ALTA_HOSPITALAR";
            }
            else if (CbMotivoChamado.Text == "AVALIAÇÃO DE MÉDICO ESPECIALISTA")
            {
                pegamotivo = "AVALIAÇÃO_DE_MÉDICO_ESPECIALISTA";
            }
            else if (CbMotivoChamado.Text == "AVALIAÇÃO DE PROFISSIONAL NÃO MÉDICO")
            {
                pegamotivo = "AVALIAÇÃO_DE_PROFISSIONAL_NÃO_MÉDICO";
            }
            else if (CbMotivoChamado.Text == "CONSULTA AGENDADA")
            {
                pegamotivo = "CONSULTA_AGENDADA";
            }
            else if (CbMotivoChamado.Text == "DEMANDAS JUDICIAIS")
            {
                pegamotivo = "DEMANDA_JUDICIAL";
            }
            else if (CbMotivoChamado.Text == "EVENTO COMEMORATIVO")
            {
                pegamotivo = "EVENTO_COMEMORATIVO_DO_MUNICÍPIO";
            }
            else if (CbMotivoChamado.Text == "EVENTO DE CULTURA, LAZER OU RELIGIÃO")
            {
                pegamotivo = "EVENTO_DE_CULTURA,_LAZER_OU_RELIGIÃO";
            }
            else if (CbMotivoChamado.Text == "EVENTO ESPORTIVO")
            {
                pegamotivo = "EVENTO_ESPORTIVO";
            }
            else if (CbMotivoChamado.Text == "EXAME AGENDADO")
            {
                pegamotivo = "EXAME_AGENDADO";
            }
            else if (CbMotivoChamado.Text == "EXAME DE URGÊNCIA")
            {
                pegamotivo = "EXAME_DE_URGÊNCIA";
            }
            else if (CbMotivoChamado.Text == "INTERNAÇÃO EM ENFERMARIA")
            {
                pegamotivo = "[INTERNAÇÃO_EM_ENFERMARIA]";
            }
            else if (CbMotivoChamado.Text == "INTERNAÇÃO EM UTI")
            {
                pegamotivo = "[INTERNAÇÃO_EM_UTI]";
            }
            else if (CbMotivoChamado.Text == "PROCEDIMENTO")
            {
                pegamotivo = "[PROCEDIMENTO]";
            }
            else if (CbMotivoChamado.Text == "RETORNO")
            {
                pegamotivo = "RETORNO";
            }
            else if (CbMotivoChamado.Text == "SALA VERMELHA/EMERGÊNCIA")
            {
                pegamotivo = "[SALA_VERMELHA/EMERGÊNCIA]";
            }
            else if (CbMotivoChamado.Text == "TRANSPORTE DE INSUMOS/PRODUTOS/MATERIAIS")
            {
                pegamotivo = "[TRANSPORTE_DE_INSUMOS/PRODUTOS/MATERIAIS]";
            }
            else if (CbMotivoChamado.Text == "TRANSPORTE DE PROFISSIONAIS")
            {
                pegamotivo = "TRANSPORTE_DE_PROFISSIONAIS";
            }


            //Consultar na tabela de enderecos
            SqlConnection conexao = ConexaoSqlServer.GetConexao();


            string sqlQuery = "select " + pegamotivo + " from referencias";
            try
            {

                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, conexao);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    string rowz = string.Format("{0}", row.ItemArray[0]);
                    CbTipoMotivoSelecionado.Items.Add(rowz);

                }

                // MessageBox.Show("Solicitação salva com sucesso !!!");
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CbTipoMotivoSelecionado_TextChanged(object sender, EventArgs e)
        {
            Motivo();
        }

        private void CbOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            pegaUnidadeEnd = CbOrigem.Text;
            unidade_Endereco();
            txtEnderecoOrigem.Text = Endereco1;
        }

        private void CbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            pegaUnidadeEnd = CbDestino.Text;
            unidade_Endereco();
            txtEnderecoDestino.Text = Endereco1;
        }

        private void unidade_Endereco()
        {
            //consulta para mostrar o telefone quando clicar no enderenco
            SqlConnection conexao = ConexaoSqlServer.GetConexao();


            string sqlQuery2 = "select Endereco from enderecos where NomeUnidade = '" + pegaUnidadeEnd + "'";
            try
            {
                SqlCommand objComm = new SqlCommand(sqlQuery2, conexao);
                SqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();

                //MessageBox.Show("Alterado com sucesso !!!");
                while (MyReader2.Read())
                {
                    Endereco1 = MyReader2.GetString(0);

                }

                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CbTipoMotivoSelecionado_Click(object sender, EventArgs e)
        {
            Motivo();
        }

        private void Lista_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = Lista.Rows[e.RowIndex].Cells[0].Value.ToString();
            statusAM = Lista.Rows[e.RowIndex].Cells["Status"].Value.ToString();
            NomeAM = Lista.Rows[e.RowIndex].Cells["Ambulancia"].Value.ToString();
        }




    }
}
