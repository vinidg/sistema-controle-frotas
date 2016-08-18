using MySql.Data.MySqlClient;
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

namespace WindowsFormsApplication2
{

    public partial class Status : Form
    {
        DateTime now = DateTime.Now;
        string resposavel = System.Environment.UserName;
        int idPaciente, codEquipe, SolicitaAM;
        int codigoDaAmbulancia;
        string NomeAM, statusAmbulancia;

        public Status(int codigoAM, int idPacientes)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            BtnAddPaciente.Location = new Point(899, 327);
            BtnAddPaciente.Size = new Size(306, 214);
            label7.Visible = false;
            label8.Visible = false;
            txtDtHorasBloqueio.Text = now.ToString();
            codigoDaAmbulancia = codigoAM;
            idPaciente = idPacientes;

            selectEquipeBD();
            statusJanela();
            selectHorarios();
            selectHorarioVerificacao();
            NomeAM = label1.Text;

        }
        public string NomeAM1
        {

            get { return NomeAM; }
            set { NomeAM = value; }
        }

        private void BtnTroca_Click(object sender, EventArgs e)
        {

            Paineltrocar.Visible = true;

        }
        /////////////////////////////////////////////////////////////////////////////TROCAR EQUIPE////////////////////////////////////////////////////////////////////////////////////////
        private void BtTrocar_Click(object sender, EventArgs e)
        {
            InsercoesDoBanco ib = new InsercoesDoBanco();
            DateTime now = DateTime.Now;

            ib.inserirEquipeNaAmbulancia(txtMoto.Text, txtEquipe.Text, now.ToString(), codigoDaAmbulancia);

            MessageBox.Show("Equipe trocada !");

            equipeView.DataSource = null;
            Paineltrocar.Visible = false;
            selectEquipeBD();
            EquipeAtribuiNaOcupada();
        }
        private void EquipeAtribuiNaOcupada()
        {
            if (this.Text == "Ocupada")
            {
                InsercoesDoBanco ib = new InsercoesDoBanco();
                ib.inserirEquipeAmOcupada(codEquipe ,SolicitaAM);
                
                MessageBox.Show("Equipe trocada !");
            }
        }
        ///////////////////////////////////////////////////////SELECT EQUIPE////////////////////////////////////////////////////////////////////////////////////////
        private void selectEquipeBD()
        {
            using(DAHUEEntities db = new DAHUEEntities())
            {

            var query = (from equipe in db.equipe
                        where equipe.idAM == codigoDaAmbulancia 
                        orderby equipe.idEquipe descending 
                        select new {
                            idEquipe = equipe.idEquipe,
                            Condutor = equipe.Condutor, 
                            Enfermeiros = equipe.Enfermeiros, 
                            DtEscala = equipe.DtEscala
                        }).Take(1);
            var queryEquipe = query.ToList();

            equipeView.DataSource = queryEquipe;
            equipeView.Columns[0].Visible = false;
            codEquipe = query.FirstOrDefault().idEquipe;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Solicitacoes cs = new Solicitacoes(codigoDaAmbulancia, statusAmbulancia);

            this.Dispose();
            cs.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PainelBloqueio.Visible = true;
            txtResposavel.Text = resposavel;
        }
        
        /// ////////////////////////////////////////////////////////////BLOQUEIO////////////////////////////////////////////////////////////////////
        private void BtnBloquear_Click(object sender, EventArgs e)
        {
            InsercoesDoBanco IB = new InsercoesDoBanco();
            IB.inserirBloqueioDaAm(txtDtHorasBloqueio.Text, txtResposavel.Text, CbMotivoBloqueio.Text, codigoDaAmbulancia);
                     
            MessageBox.Show("Ambulância Bloqueada !");
            PainelBloqueio.Visible = false;
            BtnDesbloquear.Visible = true;
            BtnBloqueio.Visible = false;
            BtnAddPaciente.Visible = false;
            painelCentral.BackColor = Color.Blue;
            label1.ForeColor = Color.White;
            /////
            label8.Visible = true;


        }

        private void BtnDesbloquear_Click(object sender, EventArgs e)
        {
            InsercoesDoBanco IB = new InsercoesDoBanco();
            IB.inserirDesloqueioDaAm(resposavel, now.ToString(), codigoDaAmbulancia);

            MessageBox.Show("Ambulância Desbloqueada !");
            BtnDesbloquear.Visible = false;
            BtnBloqueio.Visible = true;
            painelCentral.BackColor = Color.LimeGreen;
            BtnAddPaciente.Visible = true;
            label1.ForeColor = Color.White;
            label8.Visible = false;
            Destino.Visible = true;
            Origem.Visible = true;
        }

        /// ////////////////////////////////////////////////////////////FIM - BLOQUEIO////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////VERIFICAR QUAL PACIENTE ESTA NA AM E SE TEM MAIS DE 1/////////////////////////////
        public void atualizarStatusOcupadoPacientePorCodigo()
        {
            //atualizar a AM dependendo do status no banco
            using(DAHUEEntities db = new DAHUEEntities())
            {
                var query = from solicitacoes_paciente in db.solicitacoes_paciente
                            where solicitacoes_paciente.idPaciente_Solicitacoes == idPaciente
                            select new
                            {
                                solicitacoes_paciente.idPaciente_Solicitacoes,
                                solicitacoes_paciente.Paciente
                            };
                var querySP = query.ToList();
                ListadePacientes.DataSource = querySP;
                ListadePacientes.Columns[0].Visible = false;
            }

        }
        //////////////////////////////////////////////////////VERIFICAR QUAL PACIENTE ESTA NA AM E SE TEM MAIS DE 1 ---  FIM/////////////////////////////
        //////////////////////////////////////////////////////VERIFICAR STATUS DA AMBULANCIA E ENCAIXAR AS INFORMACOES CORRESPONDENTES/////////////////////////////
        public void statusJanela()
        {
            var queryStatus = (String)null;
            var nomeAM = (String)null;
            string origem, destino;

            StatusBD d = new StatusBD();

            using(DAHUEEntities db = new DAHUEEntities())
            {
                var query = from am in db.ambulancia
                            where am.idAmbulancia == codigoDaAmbulancia
                            select new {am.StatusAmbulancia, am.NomeAmbulancia };
                queryStatus = query.FirstOrDefault().StatusAmbulancia;
                nomeAM = query.FirstOrDefault().NomeAmbulancia;
            }

            if (queryStatus.ToString() == "BLOQUEADA")
                {
                    painelCentral.BackColor = Color.FromArgb(0, 122, 181);
                    this.BackColor = Color.FromArgb(204, 229, 255);
                    BtnAddPaciente.Visible = false;
                    BtnDesbloquear.Visible = true;
                    BtnBloqueio.Visible = false;
                    ListadePacientes.Visible = false;
                    this.Text = "BLOQUEADA";
                    statusAmbulancia = queryStatus;
                    label8.Visible = true;
                    Destino.Visible = false;
                    Origem.Visible = false;
                    
                    using(DAHUEEntities db = new DAHUEEntities())
                    {
                        var sqlQuery = from bloq in db.bloqueio
                                       where bloq.FkAM == codigoDaAmbulancia
                                       select bloq.Motivo;
                        label8.Text = sqlQuery.First().ToString();
                    }
                    Destino.Text = "";
                    Origem.Text = "";
                }

            if (queryStatus.ToString() == "OCUPADA")
                {
                    if(idPaciente == 0)
                    {
                        return;
                    }
                    painelCentral.BackColor = Color.FromArgb(224, 62, 54);
                    this.BackColor = Color.FromArgb(255, 204, 204);
                    label7.Visible = true;
                    label8.Visible = true;
                    PainelHistorico.Visible = true;
                    BtnAddPaciente.Visible = true;
                    BtnAddPaciente.Location = new Point(71, 244);
                    BtnAddPaciente.Size = new Size(306, 146);
                    BtnBloqueio.Visible = false;
                    this.Text = "OCUPADA";
                    statusAmbulancia = queryStatus;

                    d.puxarLogisticaDaSolicitacaNaAmbulancia(idPaciente);
                    
                    using (DAHUEEntities db = new DAHUEEntities())
                    {
                        var query = (from sa in db.solicitacoes_paciente
                                     where sa.idPaciente_Solicitacoes == idPaciente
                                     select new { sa.Origem, sa.Destino }).FirstOrDefault();

                        if(query.Origem != null || query.Destino != null){
                        origem = query.Origem.ToString();
                        destino = query.Destino.ToString();
                        }
                        else
                        {
                            destino = "";
                            origem = "";
                        }
                    }

                    atualizarStatusOcupadoPacientePorCodigo();

                    Destino.Text = destino;
                    Origem.Text = origem;

                    SolicitaAM = d.IdSolicitacoes_Ambulancias;
                    label7.Text = idPaciente.ToString();

                }
            if (queryStatus.ToString() == "DISPONIVEL")
                {
                    painelCentral.BackColor = Color.FromArgb(46, 172, 109);
                    this.BackColor = Color.FromArgb(229, 255, 204);
                    this.Text = "DISPONIVEL";
                    statusAmbulancia = queryStatus;
                    ListadePacientes.Visible = false;
                    Destino.Text = "";
                    Origem.Text = "";
                    Destino.Visible = false;
                    Origem.Visible = false;
                }
            label1.Text = nomeAM;
            NomeAM = nomeAM;
        }
        ///////////////////////////////////////////////////////FIM STATUS AM///////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////LOGISTICA DA AM - INICIO///////////////////////////////////////////////////////////////////////////////


        private void BtnEquipeCiente_Click(object sender, EventArgs e)
        {
            if (txtHora.Enabled == false && txtHora.Text != "")
            {
                txtHora.Enabled = true;
                txtAlterador.Enabled = true;
                BtnEquipeCiente.Text = "Alterar";
                return;
            }
            if (txtHora.Enabled == true && txtHora.Text != "")
            {
                BtnEquipeCiente.Text = "Equipe Ciente";

            using (DAHUEEntities db = new DAHUEEntities())
            {
                solicitacoes_ambulancias solicitacoesAmbulancias = db.solicitacoes_ambulancias.First(p => p.idAmbulanciaSol == codigoDaAmbulancia && p.SolicitacaoConcluida == 0 && p.idSolicitacoesPacientes == idPaciente);
                solicitacoesAmbulancias.DtHrCiencia = txtHora.Text;
                solicitacoesAmbulancias.DtHrCienciaReg = txtAlterador.Text;

                db.SaveChanges();
                MessageBox.Show("Solicitação salva com sucesso !!!");
                MessageBox.Show("Alterado !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

                txtHora.Enabled = false;
                txtAlterador.Enabled = false;
                return;

            }
            if (equipeView.RowCount == 0)
            {
                MessageBox.Show("Atribua uma equipe na Ambulância !", "ATENÇÃO", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }

            txtAlterador.Text = resposavel;
            txtHora.Text = DateTime.Now.ToString();

            painel1.Visible = false;
            BtnOrigem.BackColor = Color.MediumTurquoise;
            BtnEquipeCiente.BackColor = Color.LightSkyBlue;

            using (DAHUEEntities db = new DAHUEEntities())
            {
                solicitacoes_ambulancias solicitacoesAmbulancias = db.solicitacoes_ambulancias.First(p => p.idAmbulanciaSol == codigoDaAmbulancia && p.SolicitacaoConcluida == 0 && p.idSolicitacoesPacientes == idPaciente);
                solicitacoesAmbulancias.DtHrCiencia = txtHora.Text;
                solicitacoesAmbulancias.DtHrCienciaReg = txtAlterador.Text;

                db.SaveChanges();
                MessageBox.Show("Solicitação salva com sucesso !!!");
                MessageBox.Show("Avise a equipe que é necessario informar a chegada na origem !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }


        private void BtnOrigem_Click(object sender, EventArgs e)
        {
            if (txtHora2.Enabled == false && txtHora2.Text != "")
            {
                txtHora2.Enabled = true;
                txtAlterador2.Enabled = true;
                BtnOrigem.Text = "Alterar";
                return;
            }
            if (txtHora2.Enabled == true && txtHora2.Text != "")
            {
                BtnOrigem.Text = "Equipe na Origem";

                using (DAHUEEntities db = new DAHUEEntities())
                {
                    solicitacoes_ambulancias solicitacoesAmbulancias = db.solicitacoes_ambulancias.First(p => p.idAmbulanciaSol == codigoDaAmbulancia && p.SolicitacaoConcluida == 0 && p.idSolicitacoesPacientes == idPaciente);
                    solicitacoesAmbulancias.DtHrChegadaOrigem = txtHora2.Text;
                    solicitacoesAmbulancias.DtHrChegadaOrigemReg = txtAlterador2.Text;

                    db.SaveChanges();
                    MessageBox.Show("Solicitação salva com sucesso !!!");
                    MessageBox.Show("Alterado !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                txtHora2.Enabled = false;
                txtAlterador2.Enabled = false;
                return;

            }

            txtHora2.Text = DateTime.Now.ToString();
            txtAlterador2.Text = resposavel;

            painel2.Visible = false;
            BtnSaiuOrigem.BackColor = Color.MediumTurquoise;
            BtnOrigem.BackColor = Color.LightSkyBlue;

            using (DAHUEEntities db = new DAHUEEntities())
            {
                solicitacoes_ambulancias solicitacoesAmbulancias = db.solicitacoes_ambulancias.First(p => p.idAmbulanciaSol == codigoDaAmbulancia && p.SolicitacaoConcluida == 0 && p.idSolicitacoesPacientes == idPaciente);
                solicitacoesAmbulancias.DtHrChegadaOrigem = txtHora2.Text;
                solicitacoesAmbulancias.DtHrChegadaOrigemReg = txtAlterador2.Text;

                db.SaveChanges();
                MessageBox.Show("Solicitação salva com sucesso !!!");
                MessageBox.Show("Avise a equipe que é necessario informar a saida da origem !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void BtnSaiuOrigem_Click(object sender, EventArgs e)
        {
            if (txtHora3.Enabled == false && txtHora3.Text != "")
            {
                txtHora3.Enabled = true;
                txtAlterador3.Enabled = true;
                BtnSaiuOrigem.Text = "Alterar";
                return;
            }
            if (txtHora3.Enabled == true && txtHora3.Text != "")
            {
                BtnSaiuOrigem.Text = "Equipe Saiu da Origem";

                using (DAHUEEntities db = new DAHUEEntities())
                {
                    solicitacoes_ambulancias solicitacoesAmbulancias = db.solicitacoes_ambulancias.First(p => p.idAmbulanciaSol == codigoDaAmbulancia && p.SolicitacaoConcluida == 0 && p.idSolicitacoesPacientes == idPaciente);
                    solicitacoesAmbulancias.DtHrSaidaOrigem = txtHora3.Text;
                    solicitacoesAmbulancias.DtHrSaidaOrigemReg = txtAlterador3.Text;

                    db.SaveChanges();
                    MessageBox.Show("Solicitação salva com sucesso !!!");
                    MessageBox.Show("Alterado !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                txtHora3.Enabled = false;
                txtAlterador3.Enabled = false;
                return;

            }
            txtAlterador3.Text = resposavel;
            txtHora3.Text = DateTime.Now.ToString();

            painel3.Visible = false;
            BtnEquipeDestino.BackColor = Color.MediumTurquoise;
            BtnSaiuOrigem.BackColor = Color.LightSkyBlue;

            using (DAHUEEntities db = new DAHUEEntities())
            {
                solicitacoes_ambulancias solicitacoesAmbulancias = db.solicitacoes_ambulancias.First(p => p.idAmbulanciaSol == codigoDaAmbulancia && p.SolicitacaoConcluida == 0 && p.idSolicitacoesPacientes == idPaciente);
                solicitacoesAmbulancias.DtHrSaidaOrigem = txtHora3.Text;
                solicitacoesAmbulancias.DtHrSaidaOrigemReg = txtAlterador3.Text;

                db.SaveChanges();
                MessageBox.Show("Solicitação salva com sucesso !!!");
                MessageBox.Show("Avise a equipe que é necessario informar ao chegar ao destino !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void BtnEquipeDestino_Click(object sender, EventArgs e)
        {
            if (txtHora4.Enabled == false && txtHora4.Text != "")
            {
                txtHora4.Enabled = true;
                txtAlterador4.Enabled = true;
                BtnEquipeDestino.Text = "Alterar";
                return;
            }
            if (txtHora4.Enabled == true && txtHora4.Text != "")
            {
                BtnEquipeDestino.Text = "Equipe no Destino";

                using (DAHUEEntities db = new DAHUEEntities())
                {
                    solicitacoes_ambulancias solicitacoesAmbulancias = db.solicitacoes_ambulancias.First(p => p.idAmbulanciaSol == codigoDaAmbulancia && p.SolicitacaoConcluida == 0 && p.idSolicitacoesPacientes == idPaciente);
                    solicitacoesAmbulancias.DtHrChegadaDestino = txtHora4.Text;
                    solicitacoesAmbulancias.DtHrChegadaDestinoReg = txtAlterador4.Text;

                    db.SaveChanges();
                    MessageBox.Show("Solicitação salva com sucesso !!!");
                    MessageBox.Show("Alterado !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                txtHora4.Enabled = false;
                txtAlterador4.Enabled = false;
                return;

            }

            txtAlterador4.Text = resposavel;
            txtHora4.Text = DateTime.Now.ToString();

            painel4.Visible = false;
            EquipeLiberada.BackColor = Color.MediumTurquoise;
            BtnEquipeDestino.BackColor = Color.LightSkyBlue;

            using (DAHUEEntities db = new DAHUEEntities())
            {
                solicitacoes_ambulancias solicitacoesAmbulancias = db.solicitacoes_ambulancias.First(p => p.idAmbulanciaSol == codigoDaAmbulancia && p.SolicitacaoConcluida == 0 && p.idSolicitacoesPacientes == idPaciente);
                solicitacoesAmbulancias.DtHrChegadaDestino = txtHora4.Text;
                solicitacoesAmbulancias.DtHrChegadaDestinoReg = txtAlterador4.Text;

                db.SaveChanges();
                MessageBox.Show("Solicitação salva com sucesso !!!");
                MessageBox.Show("Avise a equipe que é necessario informar ao ser liberado do destino !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void EquipeLiberada_Click(object sender, EventArgs e)
        {
            if (txtHora5.Enabled == false && txtHora5.Text != "")
            {
                txtHora5.Enabled = true;
                txtAlterador5.Enabled = true;
                EquipeLiberada.Text = "Alterar";
                return;
            }
            if (txtHora5.Enabled == true && txtHora5.Text != "")
            {
                EquipeLiberada.Text = "Equipe Liberada do Destino";

                using (DAHUEEntities db = new DAHUEEntities())
                {
                    solicitacoes_ambulancias solicitacoesAmbulancias = db.solicitacoes_ambulancias.First(p => p.idAmbulanciaSol == codigoDaAmbulancia && p.SolicitacaoConcluida == 0 && p.idSolicitacoesPacientes == idPaciente);
                    solicitacoesAmbulancias.DtHrLiberacaoEquipe = txtHora5.Text;
                    solicitacoesAmbulancias.DtHrLiberacaoEquipeReg = txtAlterador5.Text;

                    db.SaveChanges();
                    MessageBox.Show("Solicitação salva com sucesso !!!");
                    MessageBox.Show("Alterado !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                txtHora5.Enabled = false;
                txtAlterador5.Enabled = false;
                return;

            }
            txtAlterador5.Text = resposavel;
            txtHora5.Text = DateTime.Now.ToString();

            painel5.Visible = false;
            BtnPatio.BackColor = Color.MediumTurquoise;
            EquipeLiberada.BackColor = Color.LightSkyBlue;

            using (DAHUEEntities db = new DAHUEEntities())
            {
                solicitacoes_ambulancias solicitacoesAmbulancias = db.solicitacoes_ambulancias.First(p => p.idAmbulanciaSol == codigoDaAmbulancia && p.SolicitacaoConcluida == 0 && p.idSolicitacoesPacientes == idPaciente);
                solicitacoesAmbulancias.DtHrLiberacaoEquipe = txtHora5.Text;
                solicitacoesAmbulancias.DtHrLiberacaoEquipeReg = txtAlterador5.Text;

                db.SaveChanges();
                MessageBox.Show("Solicitação salva com sucesso !!!");
                MessageBox.Show("Avise a equipe que é necessario informar a chegada no pátio !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void BtnPatio_Click(object sender, EventArgs e)
        {

            BtnEquipeDestino.BackColor = Color.LightSkyBlue;
            txtHora6.Text = DateTime.Now.ToString();
            txtAlterador6.Text = resposavel;
            var idSolicitacaAM = (String)null;
            using (DAHUEEntities db = new DAHUEEntities())
            {
                solicitacoes_ambulancias solicitacoesAmbulancias = db.solicitacoes_ambulancias.First(p => p.idAmbulanciaSol == codigoDaAmbulancia && p.SolicitacaoConcluida == 0 && p.idSolicitacoesPacientes == idPaciente);
                solicitacoesAmbulancias.DtHrEquipePatio = txtHora6.Text;
                solicitacoesAmbulancias.DtHrEquipePatioReg = txtAlterador6.Text;

                var contemPaciente = (from soa in db.solicitacoes_ambulancias
                                      where soa.idAmbulanciaSol == codigoDaAmbulancia && soa.SolicitacaoConcluida == 0
                                      select soa).Count();
                idSolicitacaAM = (from sa in db.solicitacoes_ambulancias
                                          where sa.idSolicitacoesPacientes == idPaciente && sa.SolicitacaoConcluida == 0
                                          select sa.idSolicitacoes_Ambulancias).FirstOrDefault().ToString();

                if (contemPaciente == 1)
                {
                    ambulancia am = db.ambulancia.First(a => a.idAmbulancia == codigoDaAmbulancia);
                    am.StatusAmbulancia = "DISPONIVEL";
                }
                solicitacoes_ambulancias sas = db.solicitacoes_ambulancias.First(s => s.idAmbulanciaSol == codigoDaAmbulancia && s.SolicitacaoConcluida == 0);
                sas.SolicitacaoConcluida = 1;

                db.SaveChanges();
                MessageBox.Show("Solicitação salva com sucesso !!!");
                MessageBox.Show("Equipe disponivel !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            DialogResult rs = MessageBox.Show("Deseja imprimir a ficha completa da solicitação ?", "Atenção !", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (rs == DialogResult.Yes)
            {

                SelecionaAM samb = new SelecionaAM(idPaciente, codigoDaAmbulancia, Convert.ToInt32(idSolicitacaAM));
                samb.imprimirFicha();
                this.Dispose();
            }
            else
            {
                this.Dispose();
            }



        }

        ///////////////////////////////////////////////////////LOGISTICA DA AM - FIM///////////////////////////////////////////////////////////////////////////////
        private void selectHorarios()
        {
            if (statusAmbulancia == "OCUPADA")
            {

            using (DAHUEEntities db = new DAHUEEntities())
            {

                var query = (from sa in db.solicitacoes_ambulancias
                            where sa.idSolicitacoes_Ambulancias == SolicitaAM
                            select new 
                            { sa.DtHrCiencia, 
                              sa.DtHrCienciaReg,
                              sa.DtHrChegadaOrigem,
                              sa.DtHrChegadaOrigemReg,
                              sa.DtHrSaidaOrigem,
                              sa.DtHrSaidaOrigemReg,
                              sa.DtHrChegadaDestino,
                              sa.DtHrChegadaDestinoReg,
                              sa.DtHrLiberacaoEquipe,
                              sa.DtHrLiberacaoEquipeReg,
                              sa.DtHrEquipePatio,
                              sa.DtHrEquipePatioReg
                            }).FirstOrDefault();

                if (query.DtHrCiencia != null)
                {
                    txtHora.Text = query.DtHrCiencia;
                }
                if(query.DtHrChegadaOrigem != null)
                {
                    txtHora2.Text = query.DtHrChegadaOrigem;
                }
                if(query.DtHrSaidaOrigem != null)
                {
                    txtHora3.Text = query.DtHrSaidaOrigem;
                }
                if(query.DtHrChegadaDestino != null){
                    txtHora4.Text = query.DtHrChegadaDestino;
                }
                if(query.DtHrLiberacaoEquipe != null)
                {
                    txtHora5.Text = query.DtHrLiberacaoEquipe;
                }
                if (query.DtHrEquipePatio != null)
                {
                    txtHora6.Text = query.DtHrEquipePatio;
                }
                if (query.DtHrCienciaReg != null)
                {
                    txtAlterador.Text = query.DtHrCienciaReg;
                }
                if (query.DtHrChegadaOrigemReg != null)
                {
                    txtAlterador2.Text = query.DtHrChegadaOrigemReg;
                }
                if (query.DtHrSaidaOrigemReg != null)
                {
                    txtAlterador3.Text = query.DtHrSaidaOrigemReg;
                }
                if (query.DtHrChegadaDestinoReg != null)
                {
                    txtAlterador4.Text = query.DtHrChegadaDestinoReg;
                }
                if (query.DtHrLiberacaoEquipeReg != null)
                {
                    txtAlterador5.Text = query.DtHrLiberacaoEquipeReg;
                }
                if (query.DtHrEquipePatioReg != null)
                {
                    txtAlterador6.Text = query.DtHrEquipePatioReg;
                }
                }
            }
        }

        private void selectHorarioVerificacao()
        {

            if (txtHora.Text == "")
            {
                painel1.Visible = true;
            }
            else if (txtHora.Text != "")
            {
                painel1.Visible = false;
                BtnOrigem.BackColor = Color.MediumTurquoise;
                BtnEquipeCiente.BackColor = Color.LightSkyBlue;
            }
            if (txtHora2.Text == "")
            {
                painel2.Visible = true;
            }
            else if (txtHora2.Text != "")
            {
                BtnOrigem.BackColor = Color.LightSkyBlue;
                painel2.Visible = false;
                BtnSaiuOrigem.BackColor = Color.MediumTurquoise;
            }
            if (txtHora3.Text == "")
            {
                painel3.Visible = true;
            }
            else if (txtHora3.Text != "")
            {

                painel3.Visible = false;
                BtnEquipeDestino.BackColor = Color.MediumTurquoise;
                BtnSaiuOrigem.BackColor = Color.LightSkyBlue;
            }
            if (txtHora4.Text == "")
            {
                painel4.Visible = true;
            }
            else if (txtHora4.Text != "")
            {
                painel4.Visible = false;
                EquipeLiberada.BackColor = Color.MediumTurquoise;
                BtnEquipeDestino.BackColor = Color.LightSkyBlue;
            }
            if (txtHora5.Text == "")
            {
                painel5.Visible = true;
            }
            else if (txtHora5.Text != "")
            {
                painel5.Visible = false;
                BtnPatio.BackColor = Color.MediumTurquoise;
                EquipeLiberada.BackColor = Color.LightSkyBlue;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            SelecionaAM sand = new SelecionaAM(idPaciente, codigoDaAmbulancia, 0);
            this.Dispose();
            sand.ShowDialog();
        }

        private void ListadePacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int IDpesquisa;
            IDpesquisa = Convert.ToInt32(ListadePacientes.Rows[e.RowIndex].Cells[0].Value.ToString());
            SelecionaAM sand = new SelecionaAM(idPaciente, codigoDaAmbulancia, 0);
            this.Dispose();
            sand.ShowDialog();
        }




    }
}
