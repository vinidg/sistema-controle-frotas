using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Reporting.WebForms;
using db_transporte_sanitario;

namespace Sistema_Controle
{
    public partial class SelecionaAM : Form
    {
        string Sexo, Agendamento, TipoAM, pegamotivo, statusAM, tipoSolicitacao;
        string statusAMLista, NomeAM;
        int idAmbu, idPaciente, idSolicitacaoAm;
        string pegaUnidade;     //para pegar o telefone com o nome da unidade
        string pegaUnidadeEnd;  //para pegar o endereco com o nome da unidade
        string Endereco1;

        public SelecionaAM(int IDpaciente, int AMocupada, int idSoAm)
        {
            InitializeComponent();
            idPaciente = IDpaciente;
            LabelIDPaciente.Text = idPaciente.ToString();
            idAmbu = AMocupada;
            idSolicitacaoAm = idSoAm;

            PuxarEnderecos();
            PreencherCampos();
            verificaSeAMEstaIncluida();
            VerificarPacienteJaestaInclusoNaMesma();
            pegarDadosDasAmbulancias();
            AgendamentoNao.Visible = false;
            AgendamentoSim.Visible = false;
        }

        private void PuxarEnderecos()
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
                CbLocalSolicita.DataSource = db.enderecos.ToList();
                CbLocalSolicita.ValueMember = "NomeUnidade";
                CbLocalSolicita.DisplayMember = "NomeUnidade";
                CbDestino.DataSource = db.enderecos.ToList();
                CbDestino.ValueMember = "NomeUnidade";
                CbDestino.DisplayMember = "NomeUnidade";
                CbOrigem.DataSource = db.enderecos.ToList();
                CbOrigem.ValueMember = "NomeUnidade";
                CbOrigem.DisplayMember = "NomeUnidade";
            }
        }
        private void PreencherCampos()
        {
            //buscar informacoes pelo id da tabela
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from sp in db.solicitacoes_paciente
                             where sp.idPaciente_Solicitacoes == idPaciente
                             select sp).FirstOrDefault();

                tipoSolicitacao = query.TipoSolicitacao;
                Agendamento = query.Agendamento;

                if (query.TipoSolicitacao == "Avancada")
                {
                    LabelTipo.Text = "Avançada";
                }
                else
                {
                    LabelTipo.Text = "Básica";
                }

                if (query.Agendamento == "Sim")
                {
                    LabelAgendamento.Text = "Sim";

                    labelAtendimentoMarcado.Visible = true;
                    dataAgendamento.Visible = true;
                    Reagendar.Visible = true;
                    ReagendamentosNegativas.Visible = true;
                }
                else
                {
                    LabelAgendamento.Text = "Nao";

                    labelAtendimentoMarcado.Visible = false;
                    dataAgendamento.Visible = false;
                    Reagendar.Visible = false;
                    ReagendamentosNegativas.Visible = false;
                }

                dataAgendamento.Text = query.DtHrdoAgendamento.ToString();
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
                PrioridadeTxt.Text = query.Prioridade;
                CbOrigem.Text = query.Origem;
                txtEnderecoOrigem.Text = query.EnderecoOrigem;
                CbDestino.Text = query.Destino;
                txtEnderecoDestino.Text = query.EnderecoDestino;
                obsGerais.Text = query.ObsGerais;

            }
        }
        private void verificaSeAMEstaIncluida()
        {
            if (idAmbu == 0)
            {
                RetirarAM.Visible = false;
                return;
            }
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from am in db.ambulancia
                             where am.idAmbulancia == idAmbu
                             select new { am.NomeAmbulancia, am.StatusAmbulancia }).FirstOrDefault();
                NomeAM = query.NomeAmbulancia;
                statusAM = query.StatusAmbulancia;
            }

            if (statusAM == "OCUPADA")
            {
                PainelAM2.Visible = false;
                label23.Visible = true;
                BtnOutraAM.Visible = true;
                BtnConfimar.Visible = true;
                label22.Visible = true;
                RetirarAM.Visible = true;
                label22.Text = NomeAM;

            }
            else if (statusAM == "DISPONIVEL")
            {
                PainelAM2.Visible = false;
                label23.Visible = true;
                BtnOutraAM.Visible = true;
                BtnConfimar.Visible = true;
                label22.Visible = true;
                RetirarAM.Visible = false;
                label22.Text = NomeAM;
            }

        }
        private void VerificarPacienteJaestaInclusoNaMesma()
        {
            using (DAHUEEntities db = new DAHUEEntities())
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
        public void pegarDadosDasAmbulancias()
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from am in db.ambulancia
                             join sa in db.solicitacoes_ambulancias
                             on new { idAmbulanciaSol = am.idAmbulancia, SolicitacaoConcluida = 0 }
                             equals new { sa.idAmbulanciaSol, SolicitacaoConcluida = (int)sa.SolicitacaoConcluida } into sa_join
                             from sa in sa_join.DefaultIfEmpty()
                             join sp in db.solicitacoes_paciente on new { idSolicitacoesPacientes = (int)sa.idSolicitacoesPacientes } equals new { idSolicitacoesPacientes = sp.idPaciente_Solicitacoes } into sp_join
                             from sp in sp_join.DefaultIfEmpty()
                             where am.Desativado == 0
                             orderby am.idAmbulancia
                             select new
                             {
                                 am.idAmbulancia,
                                 Ambulancia = am.NomeAmbulancia,
                                 Status = am.StatusAmbulancia,
                                 Paciente = sp.Paciente,
                                 Idade = sp.Idade,
                                 Origem = sp.Origem,
                                 Destino = sp.Destino
                             }).ToList();

                Lista.DataSource = query;
                Lista.ClearSelection();

                Lista.Columns[0].Visible = false;
                Lista.ClearSelection();
            }
        }

        private void cancelar()
        {
            try
            {
                StatusBD d = new StatusBD();
                d.puxarLogisticaDaSolicitacaNaAmbulancia(idPaciente);

                InsercoesDoBanco ib = new InsercoesDoBanco();
                ib.cancelarSolicitacao(idPaciente, Convert.ToInt32(d.IdSolicitacoes_Ambulancias), MotivoCancelar.Text, DtHrCancelamento.Text,
                    txtResponsavel.Text, txtObsCancelamento.Text);
                ib.updateNasTabelasParaCancelar(idPaciente, idAmbu, Convert.ToInt32(d.IdSolicitacoes_Ambulancias));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                MessageBox.Show("Solicitação cancelada com sucesso !!!");
                this.Dispose();
        }
        private void ConfirmaAM()
        {

            try
            {
                InsercoesDoBanco ib = new InsercoesDoBanco();
                ib.confirmarAmbulanciaNaSolicitacao(idPaciente, idAmbu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                MessageBox.Show("Solicitação salva com sucesso !!!");
                this.Dispose();
            }

        }
        public void imprimirFicha()
        {
            // ConsultarSolicitaoRelatorio();

            StatusBD Horarios = new StatusBD();
            using (DAHUEEntities db = new DAHUEEntities())
            {
                   
                string Condutor="", Enfermeiros="";

                    //pesquisar equipe
                    var Equipe = (from eq in db.equipe
                                 where eq.idAM == idAmbu
                                 orderby eq.idEquipe descending
                                 select eq).FirstOrDefault();
                        if(Equipe != null)
                        {
                            Condutor = Equipe.Condutor;
                            Enfermeiros = Equipe.Enfermeiros;
                        }
            

                    //pesquisar dados do paciente
                    var Solicitacao = (from sp in db.solicitacoes_paciente
                                   where sp.idPaciente_Solicitacoes == idPaciente
                                   select sp).FirstOrDefault();

                    if (idSolicitacaoAm == 0)
                    {
                        Horarios.puxarLogisticaDaSolicitacaNaAmbulancia(idPaciente);
                    }
                    else
                    {
                        Horarios.puxarLogisticaDaSolicitacaNaAmbulanciaSelecionadaNaConsulta(idPaciente, idSolicitacaoAm);

                       Equipe = (from eq in db.equipe
                                 where eq.idAM == Horarios.IdAmbulanciaSol
                                 orderby eq.idEquipe descending
                                 select eq).FirstOrDefault();
                    }
            
                    //Verificar se esta sendo cancelado
                    string cancelado = "", dataHoraCancelamento = "", MotivoCancelamento = "", nomeCancelante="";
                        var query = (from can in db.cancelados_pacientes
                                     where can.idPaciente == idPaciente
                                     orderby can.DtHrCancelamento descending
                                     select can).Take(1).FirstOrDefault();
                        if(query != null)
                        {
                            cancelado = "Sim";
                            dataHoraCancelamento = query.DtHrCancelamento;
                            MotivoCancelamento = query.MotivoCancelamento;
                            nomeCancelante = query.ResposavelCancelamento;
                        }
                        else
                        {
                           cancelado = "Não";
                        }
                    
                    
                    //Pesquisar nome da ambulancias
                    if (NomeAM == "" || NomeAM == null)
                    {
                        var nome = (from am in db.ambulancia
                                    where am.idAmbulancia == Horarios.IdAmbulanciaSol
                                    select am.NomeAmbulancia).FirstOrDefault();
                        NomeAM = nome;
                    }

                    int n = 34;
                    ReportViewer report = new ReportViewer();
                    report.ProcessingMode = ProcessingMode.Local;
                    report.LocalReport.ReportEmbeddedResource = "Sistema_Controle.Report1.rdlc";
                    ReportParameter[] listReport = new ReportParameter[n];
                    listReport[0] = new ReportParameter("Nome", Solicitacao.Paciente);
                    listReport[1] = new ReportParameter("Tipo", Solicitacao.TipoSolicitacao);
                    listReport[2] = new ReportParameter("Agendado", Solicitacao.Agendamento);
                    listReport[3] = new ReportParameter("DtHrAgendado", Solicitacao.DtHrdoAgendamento.ToString());
                    listReport[4] = new ReportParameter("ID", Convert.ToString(Solicitacao.idPaciente_Solicitacoes));
                    listReport[5] = new ReportParameter("Sexo", Solicitacao.Genero);
                    listReport[6] = new ReportParameter("Idade", Solicitacao.Idade);
                    listReport[7] = new ReportParameter("Diagnostico", Solicitacao.Diagnostico);
                    listReport[8] = new ReportParameter("Motivo", Solicitacao.Motivo);
                    listReport[9] = new ReportParameter("Submotivo", Solicitacao.SubMotivo);
                    listReport[10] = new ReportParameter("Origem", Solicitacao.Origem);
                    listReport[11] = new ReportParameter("Destino", Solicitacao.Destino);
                    listReport[12] = new ReportParameter("EnderecoOrigem", Solicitacao.EnderecoOrigem);
                    listReport[13] = new ReportParameter("EnderecoDestino", Solicitacao.EnderecoDestino);
                    listReport[14] = new ReportParameter("Obsgerais", Solicitacao.ObsGerais);
                    listReport[15] = new ReportParameter("NomeSolicitante", Solicitacao.NomeSolicitante);
                    listReport[16] = new ReportParameter("LocalSolicitacao", Solicitacao.LocalSolicitacao);
                    listReport[17] = new ReportParameter("Telefone", Solicitacao.Telefone);
                    listReport[18] = new ReportParameter("Registrado", System.Environment.UserName);
                    listReport[19] = new ReportParameter("HrRegistro", DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss"));
                    listReport[20] = new ReportParameter("AM", NomeAM);
                    listReport[21] = new ReportParameter("Condutor", Condutor);
                    listReport[22] = new ReportParameter("Equipe", Enfermeiros);
                    listReport[23] = new ReportParameter("Prioridade", Solicitacao.Prioridade.Substring(0,2));
                    listReport[24] = new ReportParameter("Cancelamento", cancelado);
                    listReport[25] = new ReportParameter("HrCancelamento", dataHoraCancelamento);
                    listReport[26] = new ReportParameter("MotivoCancelamento", MotivoCancelamento);
                    listReport[27] = new ReportParameter("NomeCancelante", nomeCancelante);
                    listReport[28] = new ReportParameter("HrCiencia", Horarios.DtHrCiencia1);
                    listReport[29] = new ReportParameter("HrSaida", Horarios.DtHrSaidaOrigem1);
                    listReport[30] = new ReportParameter("HrLiberacao", Horarios.DtHrLiberacaoEquipe1);
                    listReport[31] = new ReportParameter("HrChegadaOrigem", Horarios.DtHrChegadaOrigem1);
                    listReport[32] = new ReportParameter("HrChegadaDestino", Horarios.DtHrChegadaDestino1);
                    listReport[33] = new ReportParameter("HrEquipepatio", Horarios.DtHrEquipePatio1);

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
        }
        private void DesbloquarCampos()
        {
            BtnAvancada.Visible = true;
            BtnBasica.Visible = true;
            AgendamentoNao.Visible = true;
            AgendamentoSim.Visible = true;
            LabelAgendamento.Visible = false;
            LabelTipo.Visible = false;

            dataAgendamento.Enabled = true;
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
            obsGerais.Enabled = true;
            PrioridadeTxt.Enabled = true;

            if (LabelTipo.Text == "Básica")
            {
                TipoAM = "Basica";
                BtnBasica.BackColor = Color.FromArgb(69, 173, 168);
                BtnBasica.ForeColor = Color.FromArgb(229, 252, 194);
                BtnAvancada.BackColor = Color.FromArgb(229, 252, 194);
                BtnAvancada.ForeColor = Color.FromArgb(69, 173, 168);
            }
            else
            {
                TipoAM = "Avancada";
                BtnBasica.BackColor = Color.FromArgb(229, 252, 194);
                BtnBasica.ForeColor = Color.FromArgb(69, 173, 168);
                BtnAvancada.ForeColor = Color.FromArgb(69, 173, 168);
                BtnAvancada.BackColor = Color.FromArgb(229, 252, 194);
            }

            if (LabelAgendamento.Text == "Sim")
            {
                Agendamento = "Sim";
                AgendamentoSim.BackColor = Color.FromArgb(69, 173, 168);
                AgendamentoSim.ForeColor = Color.FromArgb(229, 252, 194);
                AgendamentoNao.ForeColor = Color.FromArgb(229, 252, 194);
                AgendamentoNao.BackColor = Color.FromArgb(69, 173, 168);
            }
            else
            {
                Agendamento = "Nao";
                AgendamentoSim.BackColor = Color.FromArgb(229, 252, 194);
                AgendamentoSim.ForeColor = Color.FromArgb(69, 173, 168);
                AgendamentoNao.BackColor = Color.FromArgb(69, 173, 168);
                AgendamentoNao.ForeColor = Color.FromArgb(229, 252, 194);
            }

        }
        private void bloquearCampos()
        {
            BtnAvancada.Visible = false;
            BtnBasica.Visible = false;
            AgendamentoNao.Visible = false;
            AgendamentoSim.Visible = false;
            LabelAgendamento.Visible = true;
            LabelTipo.Visible = true;

            dataAgendamento.Enabled = false;
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
            obsGerais.Enabled = false;
            PrioridadeTxt.Enabled = false;

        }
        private void AlterarCampos()
        {
            try
            {
                InsercoesDoBanco ib = new InsercoesDoBanco();
                ib.alterarCamposDaSolicitacao(idPaciente, TipoAM, Agendamento, dataAgendamento.Value, txtNomeSolicitante.Text, CbLocalSolicita.Text, txtTelefone.Text,
                                              txtNomePaciente.Text, Sexo, txtIdade.Text, txtDiagnostico.Text, CbMotivoChamado.Text, CbTipoMotivoSelecionado.Text, PrioridadeTxt.Text, CbOrigem.Text,
                                              txtEnderecoOrigem.Text, CbDestino.Text, txtEnderecoDestino.Text, System.Environment.UserName, DateTime.Now.ToString(), obsGerais.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                pegamotivo = "AVALIACAO_DE_MEDICO_ESPECIALISTA";
            }
            else if (CbMotivoChamado.Text == "AVALIAÇÃO DE PROFISSIONAL NÃO MÉDICO")
            {
                pegamotivo = "AVALIACAO_DE_PROFISSIONAL_NAO_MEDICO";
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
                pegamotivo = "EVENTO_COMEMORATIVO_DO_MUNICIPIO";
            }
            else if (CbMotivoChamado.Text == "EVENTO DE CULTURA, LAZER OU RELIGIÃO")
            {
                pegamotivo = "EVENTO_DE_CULTURA_LAZER_OU_RELIGIAO";
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
                pegamotivo = "EXAME_DE_URGENCIA";
            }
            else if (CbMotivoChamado.Text == "INTERNAÇÃO EM ENFERMARIA")
            {
                pegamotivo = "INTERNACAO_EM_ENFERMARIA";
            }
            else if (CbMotivoChamado.Text == "INTERNAÇÃO EM UTI")
            {
                pegamotivo = "INTERNACAO_EM_UTI";
            }
            else if (CbMotivoChamado.Text == "PROCEDIMENTO")
            {
                pegamotivo = "PROCEDIMENTO";
            }
            else if (CbMotivoChamado.Text == "RETORNO")
            {
                pegamotivo = "RETORNO";
            }
            else if (CbMotivoChamado.Text == "SALA VERMELHA/EMERGÊNCIA")
            {
                pegamotivo = "SALA_VERMELHA_EMERGENCIA";
            }
            else if (CbMotivoChamado.Text == "TRANSPORTE DE INSUMOS/PRODUTOS/MATERIAIS")
            {
                pegamotivo = "TRANSPORTE_DE_INSUMOS_PRODUTOS_MATERIAIS";
            }
            else if (CbMotivoChamado.Text == "TRANSPORTE DE PROFISSIONAIS")
            {
                pegamotivo = "TRANSPORTE_DE_PROFISSIONAIS";
            }

            using (DAHUEEntities db = new DAHUEEntities())
            {
                CbTipoMotivoSelecionado.DataSource = db.referencias.ToList();
                CbTipoMotivoSelecionado.ValueMember = pegamotivo;
                CbTipoMotivoSelecionado.DisplayMember = pegamotivo;
            }

        }
        public void unidade_telefone()
        {
            try
            {
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    var query = from tele in db.enderecos
                                where tele.NomeUnidade == pegaUnidade
                                select tele.Telefone;
                    txtTelefone.Text = query.FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private void unidade_Endereco()
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var enderecoDoEnderecos = db.enderecos
                    .Where(e => e.NomeUnidade == pegaUnidadeEnd)
                    .Select(e => e.Endereco);

                Endereco1 = enderecoDoEnderecos.FirstOrDefault();
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
        private void BtnConfimar_Click(object sender, EventArgs e)
        {
            var querya = (String)null;
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var query = from am in db.ambulancia
                            where am.idAmbulancia == idAmbu
                            select am.TipoAM;
                querya = query.FirstOrDefault();
            }

            if (tipoSolicitacao != "Avancada")
            {
                if (querya != "BASICO")
                {
                    MessageBox.Show("Selecionar ambulância do tipo basica ou a solicitação do tipo avançada!");
                    return;
                }
            }

            if (tipoSolicitacao != "Basica")
            {
                if (querya != "AVANCADO")
                {
                    MessageBox.Show("Selecionar ambulância do tipo avançada ou a solicitação do tipo básica!");
                    return;
                }
            }

            int contadorMaxdePacientes, zero = 0;
            if (statusAMLista == "BLOQUEADA")
            {
                MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (statusAMLista == "OCUPADA" || statusAM == "OCUPADA")
            {
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    var query = from sa in db.solicitacoes_ambulancias
                                where sa.idAmbulanciaSol == idAmbu &&
                                sa.SolicitacaoConcluida == zero
                                select sa.idSolicitacoes_Ambulancias;

                    var queryCount = query.Count();
                    contadorMaxdePacientes = queryCount;
                }
                if (contadorMaxdePacientes == 5)
                {
                    MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (contadorMaxdePacientes == 1)
                {
                    DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                }

            }
            ConfirmaAM();
            PainelAM2.Visible = true;

        }
        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            imprimirFicha();
        }
        private void CancelaSolicitacao_Click(object sender, EventArgs e)
        {
            MotivoCancelar.Text = "";
            txtObsCancelamento.Text = "";
            DtHrCancelamento.Text = "";
            painelCancelar.Visible = false;
        }
        private void BtnAlterar_Click(object sender, EventArgs e)
        {

            if (dataAgendamento.Enabled == false)
            {
                DesbloquarCampos();
                
            }
            else
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
                PrioridadeTxt.Text == "" ||
                CbTipoMotivoSelecionado.Text == "" ||
                CbOrigem.Text == "" ||
                CbDestino.Text == "" ||
                txtEnderecoOrigem.Text == "" ||
                txtEnderecoDestino.Text == "")
                {

                    MessageBox.Show("Verifique se algum campo esta vazio ou desmarcado !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Deseja salvar as alterações feitas ?", "Atenção !", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                AlterarCampos();
                bloquearCampos();

            }

        }
        private void BtnAvancada_Click(object sender, EventArgs e)
        {
            TipoAM = "Avancada";
            if (BtnBasica.BackColor == Color.FromArgb(229, 252, 194))
            {
                BtnAvancada.BackColor = Color.FromArgb(229, 252, 194);
                BtnAvancada.ForeColor = Color.FromArgb(69, 173, 168);
                BtnBasica.ForeColor = Color.FromArgb(69, 173, 168);
                BtnBasica.BackColor = Color.FromArgb(229, 252, 194);
            }
            BtnBasica.BackColor = Color.FromArgb(229, 252, 194);
            BtnAvancada.BackColor = Color.FromArgb(69, 173, 168);
            BtnAvancada.ForeColor = Color.FromArgb(229, 252, 194);
            BtnBasica.ForeColor = Color.FromArgb(69, 173, 168);

        }
        private void BtnBasica_Click(object sender, EventArgs e)
        {
            TipoAM = "Basica";


            if (BtnAvancada.BackColor == Color.FromArgb(229, 252, 194))
            {
                BtnBasica.BackColor = Color.FromArgb(229, 252, 194);
                BtnBasica.ForeColor = Color.FromArgb(69, 173, 168);
                BtnAvancada.ForeColor = Color.FromArgb(69, 173, 168);
                BtnAvancada.BackColor = Color.FromArgb(229, 252, 194);
            }
            BtnAvancada.BackColor = Color.FromArgb(229, 252, 194);
            BtnBasica.BackColor = Color.FromArgb(69, 173, 168);
            BtnBasica.ForeColor = Color.FromArgb(229, 252, 194);
            BtnAvancada.ForeColor = Color.FromArgb(69, 173, 168);
        }
        private void RetirarAM_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Deseja retirar a solicitação desta ambulância ?",
"Atenção !",
MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    StatusBD d = new StatusBD();
                    d.puxarLogisticaDaSolicitacaNaAmbulancia(idPaciente);

                    solicitacoes_ambulancias sa = db.solicitacoes_ambulancias.First(p => p.idSolicitacoes_Ambulancias == d.IdSolicitacoes_Ambulancias);
                    sa.SolicitacaoConcluida = 1;

                    solicitacoes_paciente sp = db.solicitacoes_paciente.First(s => s.idPaciente_Solicitacoes == idPaciente);
                    sp.AmSolicitada = 0;

                    var contemPaciente = (from soa in db.solicitacoes_ambulancias
                                          where soa.idAmbulanciaSol == idAmbu && soa.SolicitacaoConcluida == 0
                                          select soa).Count();

                    if (contemPaciente == 1)
                    {
                        ambulancia am = db.ambulancia.First(a => a.idAmbulancia == idAmbu);
                        am.StatusAmbulancia = "DISPONIVEL";
                    }
                    db.SaveChanges();
                }
                this.Dispose();
            }
        }
        private void IncluirSolicitacaoPendentes_Click(object sender, EventArgs e)
        {           
            DialogResult result1 = MessageBox.Show("Deseja inserir a solicitação na lista de pendêcias ?",
            "Atenção !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                ConfirmaSolicitacao cs = new ConfirmaSolicitacao(idPaciente);
                this.Dispose();
                cs.ShowDialog();
            }
        }
        private void Reagendar_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Deseja reagendar a solicitação ?",
            "Atenção !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                using(DAHUEEntities db = new DAHUEEntities())
                {
                    solicitacoes_paciente sp = db.solicitacoes_paciente.First(p => p.idPaciente_Solicitacoes == idPaciente);
                    sp.Registrado = "Aguardando resposta do controle";
                    db.SaveChanges(); 
                }
                RespostaDeAmbulancias ra = new RespostaDeAmbulancias();
                this.Dispose();
                ra.ShowDialog();
            }
        }
        private void Reagendamentos_Click(object sender, EventArgs e)
        {
            Reagedamentos re = new Reagedamentos(idPaciente);
            re.ShowDialog();
        }

        private void CbLocalSolicita_SelectedIndexChanged(object sender, EventArgs e)
        {
            pegaUnidade = CbLocalSolicita.Text;
            unidade_telefone();
        }
        private void CbMotivoChamado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbTipoMotivoSelecionado.DataSource = null;
            CbTipoMotivoSelecionado.ValueMember = "";
            CbTipoMotivoSelecionado.DisplayMember = "";

            if (CbMotivoChamado.Text == "INTERNAÇÃO EM UTI" || CbMotivoChamado.Text == "SALA VERMELHA/EMERGÊNCIA")
            {
                BtnAvancada.PerformClick();
                BtnAvancada.Enabled = false;
                BtnBasica.Enabled = false;
            }
            else
            {
                label2.Visible = true;
                AgendamentoNao.Visible = true;
                AgendamentoSim.Visible = true;
                TipoAM = "";
                BtnAvancada.Enabled = true;
                BtnBasica.Enabled = true;
                BtnAvancada.BackColor = Color.FromArgb(69, 173, 168);
                BtnAvancada.ForeColor = Color.FromArgb(229, 252, 194);
                BtnBasica.ForeColor = Color.FromArgb(229, 252, 194);
                BtnBasica.BackColor = Color.FromArgb(69, 173, 168);
            }
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
        private void Lista_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idAmbu = Convert.ToInt32(Lista.Rows[e.RowIndex].Cells[0].Value.ToString());
            statusAMLista = Lista.Rows[e.RowIndex].Cells["Status"].Value.ToString();
            NomeAM = Lista.Rows[e.RowIndex].Cells["Ambulancia"].Value.ToString();
            PainelAM2.Visible = false;
            label22.Text = NomeAM;
        }
        private void Lista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value.Equals("BLOQUEADA"))
            {
                Lista.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(0, 122, 181);
                Lista.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else if (e.Value != null && e.Value.Equals("OCUPADA"))
            {
                Lista.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(224, 62, 54);
                Lista.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else if (e.Value != null && e.Value.Equals("DISPONIVEL"))
            {
                Lista.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(46, 172, 109);
                Lista.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void AgendamentoSim_Click(object sender, EventArgs e)
        {
            dataAgendamento.Visible = true;
            labelAtendimentoMarcado.Visible = true;
            dataAgendamento.Focus();
            Agendamento = "Sim";

            if (AgendamentoNao.BackColor == Color.FromArgb(229, 252, 194))
            {
                AgendamentoNao.BackColor = Color.FromArgb(229, 252, 194);
                AgendamentoNao.ForeColor = Color.FromArgb(69, 173, 168);
                AgendamentoSim.ForeColor = Color.FromArgb(69, 173, 168);
                AgendamentoSim.BackColor = Color.FromArgb(229, 252, 194);

            }

            AgendamentoNao.BackColor = Color.FromArgb(229, 252, 194);
            AgendamentoSim.BackColor = Color.FromArgb(69, 173, 168);
            AgendamentoSim.ForeColor = Color.FromArgb(229, 252, 194);
            AgendamentoNao.ForeColor = Color.FromArgb(69, 173, 168);
        }
        private void AgendamentoNao_Click(object sender, EventArgs e)
        {
            Agendamento = "Nao";
            dataAgendamento.Visible = false;
            labelAtendimentoMarcado.Visible = false;
            if (AgendamentoSim.BackColor == Color.FromArgb(229, 252, 194))
            {
                AgendamentoSim.BackColor = Color.FromArgb(229, 252, 194);
                AgendamentoSim.ForeColor = Color.FromArgb(69, 173, 168);
                AgendamentoNao.ForeColor = Color.FromArgb(69, 173, 168);
                AgendamentoNao.BackColor = Color.FromArgb(229, 252, 194);
            }
            AgendamentoSim.BackColor = Color.FromArgb(229, 252, 194);
            AgendamentoNao.BackColor = Color.FromArgb(69, 173, 168);
            AgendamentoNao.ForeColor = Color.FromArgb(229, 252, 194);
            AgendamentoSim.ForeColor = Color.FromArgb(69, 173, 168);
        }

        private void BtnConfirmando_Click(object sender, EventArgs e)
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


    }
}
