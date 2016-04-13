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


namespace WindowsFormsApplication2
{
    public partial class SelecionaAM : Form
    {
        string Sexo, Agendamento, TipoAM;
        string idequipe, AMocup, STatus;
        string idAmbu, idPaciente, pegamotivo;
        string pegaUnidade;     //para pegar o telefone com o nome da unidade
        string pegaUnidadeEnd;  //para pegar o endereco com o nome da unidade
        string Endereco1;

        public SelecionaAM(string Id, string AMocupada, string idEquipeStatus, string status)
        {
            InitializeComponent();
            LabelIDPaciente.Text = Id;
            idPaciente = Id;
            AMocup = AMocupada;
            STatus = status;
            idequipe = idEquipeStatus;
            ConsultarSolicitacao();
            StatusSolicita();
            verificaSeAMEstaIncluida();
            VerificarPacienteJaestaInclusoNaMesma();
            PuxarEnderecos();
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
                label22.Text = AMocup;

            }
            else if (AMocup != "" && STatus == "Disponivel")
            {
                PainelAM2.Visible = false;
                label23.Visible = true;
                BtnOutraAM.Visible = true;
                BtnConfimar.Visible = true;
                label22.Visible = true;
                label22.Text = AMocup;
            }

        }

        private void VerificarPacienteJaestaInclusoNaMesma()
        {

            SqlConnection conexao = ConexaoSqlServer.GetConexao();
            string sqlQuery = "select COUNT(idSolicitacoes_Ambulancias) from solicitacoes_ambulancias WHERE idSolicitacoesPacientes='" + LabelIDPaciente.Text + "' AND idAmbulanciaSol = '" + AMocup + "'";
            try
            {

                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);

                int newProdID = (Int32)objComm.ExecuteScalar();

                if (newProdID >= 1)
                {
                    PainelAM2.Visible = false;
                    label23.Visible = false;
                    BtnOutraAM.Visible = false;
                    BtnConfimar.Visible = false;
                    label22.Visible = false;
                    label22.Text = AMocup;
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

        private void ConsultarSolicitacao()
        {
            //buscar informacoes pelo id da tabela

            SqlConnection conexao = ConexaoSqlServer.GetConexao();
            string sqlQuery = "select * from solicitacoes_paciente WHERE idPaciente_Solicitacoes='" + LabelIDPaciente.Text + "'";
            try
            {

                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                SqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();


                while (MyReader2.Read())
                {
                    if (MyReader2["TipoSolicitacao"].ToString() == "Avancada")
                    {
                        BtnBasica.Visible = false;
                        painelAM.Visible = false;
                        BtnAvancada.BackColor = Color.Teal;
                    }
                    else
                    {
                        BtnAvancada.Visible = false;
                        BtnBasica.BackColor = Color.Teal;
                    }
                    if (MyReader2["Agendamento"].ToString() == "Sim")
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

                    txtAtendMarcado.Text = MyReader2["DtHrAgendamento"].ToString();
                    txtNomeSolicitante.Text = MyReader2["NomeSolicitante"].ToString();
                    CbLocalSolicita.Text = MyReader2["LocalSolicitacao"].ToString();
                    txtTelefone.Text = MyReader2["Telefone"].ToString();
                    txtNomePaciente.Text = MyReader2["Paciente"].ToString();

                    if (MyReader2["Genero"].ToString() == "F")
                    {
                        RbFemenino.Checked = true;
                    }
                    else
                    {
                        RbMasculino.Checked = true;
                    }
                    txtIdade.Text = MyReader2["Idade"].ToString();
                    txtDiagnostico.Text = MyReader2["Diagnostico"].ToString();
                    CbMotivoChamado.Text = MyReader2["Motivo"].ToString();
                    CbTipoMotivoSelecionado.Text = MyReader2["SubMotivo"].ToString();
                    if (MyReader2["Prioridade"].ToString() == "False")
                    {
                        CbAtendimentoPrioridade.Checked = false;
                    }
                    else
                    {
                        CbAtendimentoPrioridade.Checked = true;
                    }
                    CbOrigem.Text = MyReader2["Origem"].ToString();
                    txtEnderecoOrigem.Text = MyReader2["EnderecoOrigem"].ToString();
                    CbDestino.Text = MyReader2["Destino"].ToString();
                    txtEnderecoDestino.Text = MyReader2["EnderecoDestino"].ToString();
                    richTextBox1.Text = MyReader2["ObsGerais"].ToString();

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
            d.atualizarStatusOcupado(AMocup);

            SqlConnection conexao = ConexaoSqlServer.GetConexao();
            string sqlQuery = "insert into cancelados_pacientes(idPaciente,idSolicitacaoAM,MotivoCancelamento,DtHrCancelamento,ResposavelCancelamento,ObsCancelamento) values " +
            "('" + LabelIDPaciente.Text + "','" + d.IdSolicitacoes_Ambulancias + "','" + MotivoCancelar.Text + "','" + DtHrCancelamento.Text + "','" + txtResponsavel.Text + "','" + txtObsCancelamento.Text + "');" +
            "UPDATE ambulancia SET Status = 'DISPONIVEL' WHERE idAmbulancia='" + AMocup + "';" +
            "UPDATE solicitacoes_ambulancias SET SolicitacaoConcluida = '1' WHERE idSolicitacoes_Ambulancias = '" + d.IdSolicitacoes_Ambulancias + "';" +
            "UPDATE solicitacoes_paciente SET AmSolicitada = '1' WHERE idPaciente_Solicitacoes = '" + LabelIDPaciente.Text + "'";
            try
            {

                SqlCommand objComm = new SqlCommand(sqlQuery, conexao);
                SqlDataReader MyReader;

                MyReader = objComm.ExecuteReader();

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

        public void StatusSolicita()
        {
            StatusBD d = new StatusBD();
            d.puxarStatus();
            if (d.AM011 == "BLOQUEADA")
            {
                BtnUTI01.BackColor = Color.RoyalBlue;

            }
            if (d.AM011 == "DISPONIVEL")
            {
                BtnUTI01.BackColor = Color.LimeGreen;
            }
            if (d.AM011 == "OCUPADA")
            {
                BtnUTI01.BackColor = Color.Firebrick;
            }

            if (d.AM021 == "BLOQUEADA")
            {
                BtnUTI02.BackColor = Color.RoyalBlue;
            }
            if (d.AM021 == "OCUPADA")
            {
                BtnUTI02.BackColor = Color.Firebrick;
            }
            if (d.AM021 == "DISPONIVEL")
            {
                BtnUTI02.BackColor = Color.LimeGreen;
            }

            if (d.AMRC1 == "DISPONIVEL")
            {
                BtnAmRC.BackColor = Color.LimeGreen;
            }
            if (d.AMRC1 == "OCUPADA")
            {
                BtnAmRC.BackColor = Color.Firebrick;
            }
            if (d.AMRC1 == "BLOQUEADA")
            {
                BtnAmRC.BackColor = Color.RoyalBlue;
            }

            if (d.AM031 == "BLOQUEADA")
            {
                BtnAM03.BackColor = Color.RoyalBlue;
            }
            if (d.AM031 == "DISPONIVEL")
            {
                BtnAM03.BackColor = Color.LimeGreen;
            }
            if (d.AM031 == "OCUPADA")
            {
                BtnAM03.BackColor = Color.Firebrick;
            }


            if (d.AM041 == "BLOQUEADA")
            {
                BtnAm04.BackColor = Color.RoyalBlue;
            }
            if (d.AM041 == "DISPONIVEL")
            {
                BtnAm04.BackColor = Color.LimeGreen;
            }
            if (d.AM041 == "OCUPADA")
            {
                BtnAm04.BackColor = Color.Firebrick;
            }

            if (d.AM051 == "BLOQUEADA")
            {
                BtnAm05.BackColor = Color.RoyalBlue;
            }
            if (d.AM051 == "OCUPADA")
            {
                BtnAm05.BackColor = Color.Firebrick;
            }
            if (d.AM051 == "DISPONIVEL")
            {
                BtnAm05.BackColor = Color.LimeGreen;
            }

            if (d.AM061 == "BLOQUEADA")
            {
                BtnAm06.BackColor = Color.RoyalBlue;
            }

            if (d.AM061 == "DISPONIVEL")
            {
                BtnAm06.BackColor = Color.LimeGreen;
            }

            if (d.AM061 == "OCUPADA")
            {
                BtnAm06.BackColor = Color.Firebrick;
            }

            if (d.AM071 == "BLOQUEADA")
            {
                BtnAm07.BackColor = Color.RoyalBlue;
            }
            if (d.AM071 == "OCUPADA")
            {
                BtnAm07.BackColor = Color.Firebrick;
            }
            if (d.AM071 == "DISPONIVEL")
            {
                BtnAm07.BackColor = Color.LimeGreen;
            }

            if (d.AM081 == "BLOQUEADA")
            {
                BtnAm08.BackColor = Color.RoyalBlue;
            }
            if (d.AM081 == "DISPONIVEL")
            {
                BtnAm08.BackColor = Color.LimeGreen;
            }
            if (d.AM081 == "OCUPADA")
            {
                BtnAm08.BackColor = Color.Firebrick;
            }

            if (d.AM091 == "OCUPADA")
            {
                BtnAm09.BackColor = Color.Firebrick;
            }
            if (d.AM091 == "DISPONIVEL")
            {
                BtnAm09.BackColor = Color.LimeGreen;
            }
            if (d.AM091 == "BLOQUEADA")
            {
                BtnAm09.BackColor = Color.RoyalBlue;
            }

            if (d.AM101 == "BLOQUEADA")
            {
                BtnAm10.BackColor = Color.RoyalBlue;
            }
            if (d.AM101 == "DISPONIVEL")
            {
                BtnAm10.BackColor = Color.LimeGreen;
            }
            if (d.AM101 == "OCUPADA")
            {
                BtnAm10.BackColor = Color.Firebrick;
            }

            if (d.AM111 == "OCUPADA")
            {
                BtnAm11.BackColor = Color.Firebrick;
            }
            if (d.AM111 == "DISPONIVEL")
            {
                BtnAm11.BackColor = Color.LimeGreen;
            }
            if (d.AM111 == "BLOQUEADA")
            {
                BtnAm11.BackColor = Color.RoyalBlue;
            }

            if (d.AM121 == "BLOQUEADA")
            {
                BtnAm12.BackColor = Color.RoyalBlue;
            }
            if (d.AM121 == "DISPONIVEL")
            {
                BtnAm12.BackColor = Color.LimeGreen;
            }
            if (d.AM121 == "OCUPADA")
            {
                BtnAm12.BackColor = Color.Firebrick;
            }

            if (d.AM461 == "DISPONIVEL")
            {
                BtnAm46.BackColor = Color.LimeGreen;
            }
            if (d.AM461 == "OCUPADA")
            {
                BtnAm46.BackColor = Color.Firebrick;
            }
            if (d.AM461 == "BLOQUEADA")
            {
                BtnAm46.BackColor = Color.RoyalBlue;
            }

            if (d.AM471 == "OCUPADA")
            {
                BtnAm47.BackColor = Color.Firebrick;
            }
            if (d.AM471 == "DISPONIVEL")
            {
                BtnAm47.BackColor = Color.LimeGreen;
            }
            if (d.AM471 == "BLOQUEADA")
            {
                BtnAm47.BackColor = Color.RoyalBlue;
            }

            if (d.AM521 == "DISPONIVEL")
            {
                BtnAm52.BackColor = Color.LimeGreen;
            }
            if (d.AM521 == "OCUPADA")
            {
                BtnAm52.BackColor = Color.Firebrick;
            }
            if (d.AM521 == "BLOQUEADA")
            {
                BtnAm52.BackColor = Color.RoyalBlue;
            }

        }
         private void BtnAM03_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 03";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 04";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 05";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 06";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 07";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 08";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 09";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 10";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 11";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 12";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 13";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 14";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 15";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 46";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 47";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 52";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM RC";
        }

        private void BtnConfimar_Click(object sender, EventArgs e)
        {
            verificarAMstatus();
            PainelAM2.Visible = true;

        }
        private void BtnUTI01_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 01";

        }

        private void BtnUTI02_Click(object sender, EventArgs e)
        {
            PainelAM2.Visible = false;
            label22.Text = "AM 02";
        }
        private void verificarAMstatus()
        {
            StatusBD d = new StatusBD();
            d.puxarStatus();

            if (label22.Text == "AM 01")
            {
                if (d.AM011 == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (d.AM011 == "OCUPADA")
                {
                    d.countparaMaxPacientes("1");
                    if (d.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (d.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (a == DialogResult.Yes)
                        {

                            idAmbu = "1";
                            ConfirmaAM();
                        }
                    }
                }
                if (d.AM011 == "DISPONIVEL")
                {
                    idAmbu = "1";
                    ConfirmaAM();
                }

            }
            if (label22.Text == "AM 02")
            {
                if (d.AM021 == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (d.AM021 == "OCUPADA")
                {
                    d.countparaMaxPacientes("2");
                    if (d.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (d.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (a == DialogResult.Yes)
                        {

                            idAmbu = "2";
                            ConfirmaAM();
                        }
                    }
                }
                if (d.AM021 == "DISPONIVEL")
                {
                    idAmbu = "2";
                    ConfirmaAM();
                }

            }
            if (label22.Text == "AM RC")
            {
                if (d.AMRC1 == "DISPONIVEL")
                {
                    idAmbu = "3";
                    ConfirmaAM();
                }
                if (d.AMRC1 == "OCUPADA")
                {
                    d.countparaMaxPacientes("3");
                    if (d.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (d.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (a == DialogResult.Yes)
                        {

                            idAmbu = "3";
                            ConfirmaAM();
                        }
                    }
                }
                if (d.AMRC1 == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            if (label22.Text == "AM 03")
            {
                if (d.AM031 == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (d.AM031 == "DISPONIVEL")
                {
                    idAmbu = "4";
                    ConfirmaAM();
                }
                if (d.AM031 == "OCUPADA")
                {
                    d.countparaMaxPacientes("4");
                    if (d.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (d.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (a == DialogResult.Yes)
                        {

                            idAmbu = "4";
                            ConfirmaAM();
                        }
                    }

                }
            }

            if (label22.Text == "AM 04")
            {
                if (d.AM031 == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (d.AM031 == "DISPONIVEL")
                {
                    idAmbu = "5";
                    ConfirmaAM();
                }
                if (d.AM031 == "OCUPADA")
                {
                    d.countparaMaxPacientes("5");
                    if (d.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (d.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (a == DialogResult.Yes)
                        {

                            idAmbu = "5";
                            ConfirmaAM();
                        }
                    }

                }
            }

            if (label22.Text == "AM 05")
            {
                if (d.AM051 == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (d.AM051 == "OCUPADA")
                {
                    d.countparaMaxPacientes("6");
                    if (d.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (d.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (a == DialogResult.Yes)
                        {

                            idAmbu = "6";
                            ConfirmaAM();
                        }
                    }
                }
                if (d.AM051 == "DISPONIVEL")
                {
                    idAmbu = "6";
                    ConfirmaAM();
                }

            }
            if (label22.Text == "AM 06")
            {
                if (d.AM061 == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (d.AM061 == "DISPONIVEL")
                {
                    idAmbu = "7";
                    ConfirmaAM();
                }

                if (d.AM061 == "OCUPADA")
                {
                    d.countparaMaxPacientes("7");
                    if (d.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (d.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (a == DialogResult.Yes)
                        {

                            idAmbu = "7";
                            ConfirmaAM();
                        }
                    }
                }

            }
            if (label22.Text == "AM 07")
            {
                if (d.AM071 == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (d.AM071 == "OCUPADA")
                {
                    d.countparaMaxPacientes("8");
                    if (d.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (d.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (a == DialogResult.Yes)
                        {

                            idAmbu = "8";
                            ConfirmaAM();
                        }
                    }
                }
                if (d.AM071 == "DISPONIVEL")
                {
                    idAmbu = "8";
                    ConfirmaAM();
                }

            }
            if (label22.Text == "AM 08")
            {
                if (d.AM081 == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (d.AM081 == "DISPONIVEL")
                {
                    idAmbu = "10";
                    ConfirmaAM();
                }
                if (d.AM081 == "OCUPADA")
                {
                    d.countparaMaxPacientes("10");
                    if (d.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (d.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (a == DialogResult.Yes)
                        {

                            idAmbu = "10";
                            ConfirmaAM();
                        }
                    }
                }

            }
            if (label22.Text == "AM 09")
            {
                if (d.AM091 == "OCUPADA")
                {
                    d.countparaMaxPacientes("12");
                    if (d.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (d.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (a == DialogResult.Yes)
                        {

                            idAmbu = "12";
                            ConfirmaAM();
                        }
                    }
                }
                if (d.AM091 == "DISPONIVEL")
                {
                    idAmbu = "12";
                    ConfirmaAM();
                }
                if (d.AM091 == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            if (label22.Text == "AM 10")
            {
                if (d.AM101 == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (d.AM101 == "DISPONIVEL")
                {
                    idAmbu = "13";
                    ConfirmaAM();
                }
                if (d.AM101 == "OCUPADA")
                {
                    d.countparaMaxPacientes("13");
                    if (d.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (d.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (a == DialogResult.Yes)
                        {

                            idAmbu = "13";
                            ConfirmaAM();
                        }
                    }
                }

            }
            if (label22.Text == "AM 11")
            {
                if (d.AM111 == "OCUPADA")
                {
                    d.countparaMaxPacientes("14");
                    if (d.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (d.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (a == DialogResult.Yes)
                        {

                            idAmbu = "14";
                            ConfirmaAM();
                        }
                    }
                }
                if (d.AM111 == "DISPONIVEL")
                {
                    idAmbu = "14";
                    ConfirmaAM();
                }
                if (d.AM111 == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            if (label22.Text == "AM 12")
            {
                if (d.AM121 == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (d.AM121 == "DISPONIVEL")
                {
                    idAmbu = "15";
                    ConfirmaAM();
                }
                if (d.AM121 == "OCUPADA")
                {
                    d.countparaMaxPacientes("15");
                    if (d.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (d.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (a == DialogResult.Yes)
                        {

                            idAmbu = "15";
                            ConfirmaAM();
                        }
                    }
                }
            }
           
            if (label22.Text == "AM 46")
            {
                if (d.AM461 == "DISPONIVEL")
                {
                    idAmbu = "16";
                    ConfirmaAM();

                }
                if (d.AM461 == "OCUPADA")
                {
                    d.countparaMaxPacientes("16");
                    if (d.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (d.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (a == DialogResult.Yes)
                        {

                            idAmbu = "16";
                            ConfirmaAM();
                        }
                    }
                }
                if (d.AM461 == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            if (label22.Text == "AM 47")
            {
                if (d.AM471 == "OCUPADA")
                {
                    d.countparaMaxPacientes("17");
                    if (d.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (d.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (a == DialogResult.Yes)
                        {

                            idAmbu = "17";
                            ConfirmaAM();
                        }
                    }
                }
                if (d.AM471 == "DISPONIVEL")
                {
                    idAmbu = "17";
                    ConfirmaAM();

                }
                if (d.AM471 == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            if (label22.Text == "AM 52")
            {
                if (d.AM521 == "DISPONIVEL")
                {
                    idAmbu = "18";
                    ConfirmaAM();

                }
                if (d.AM521 == "OCUPADA")
                {
                    d.countparaMaxPacientes("18");
                    if (d.ContadorMaxdePacientes1 >= 5)
                    {
                        MessageBox.Show("O maximo de pacientes colocados na ambulancia ja atingiu a marca de 5 lugares, favor escolha outra ambulancia !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (d.ContadorMaxdePacientes1 >= 1)
                    {
                        DialogResult a = MessageBox.Show("Voce esta adicionando outro paciente na ambulancia " + label22.Text + ", deseja concluir ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (a == DialogResult.Yes)
                        {

                            idAmbu = "18";
                            ConfirmaAM();
                        }
                    }
                }
                if (d.AM521 == "BLOQUEADA")
                {
                    MessageBox.Show("A ambulância selecionada esta Bloqueada, por favor selecione outra !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
            Status am = new Status(AMocup);
            string amSolicitada = am.NomeAM1;
            d.atualizarStatusOcupado(AMocup);
            d.selectEquipeBD(AMocup);

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


            // reportViewer1.Visible = true;


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

                //MessageBox.Show("Alterado com sucesso !!!");
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




    }
}
