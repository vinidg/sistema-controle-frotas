using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class SolicitaConfirma : Form
    {

       
        public SolicitaConfirma(string Id)
        {
            InitializeComponent();
            LabelID.Text = Id;
            ConsultarSolicitacao();
            StatusSolicita();
           
       }

        private void SolicitaConfirma_Load(object sender, EventArgs e)
        {

        }

        private void ministatus()
        {
            CONTROLE con = new CONTROLE();
            

        }


        private void ConsultarSolicitacao()
        {
            //buscar informacoes pelo id da tabela

            MySqlConnection conexao = conexaoMysql.GetConexao();
            string sqlQuery = "select * from solicitacoes_paciente WHERE idPaciente_Solicitacoes='" + LabelID.Text + "'";
            try
            {

                MySqlCommand objComm = new MySqlCommand(sqlQuery, conexao);
                MySqlDataReader MyReader2;

                MyReader2 = objComm.ExecuteReader();


                while (MyReader2.Read())
                {
                    if (MyReader2["TipoSolicitacao"].ToString() == "Avancada")
                    {
                        BtnBasica.Visible = false;
                        painelAM.Visible = false;
                    }
                    else
                    {
                        BtnAvancada.Visible = false;
                    }
                    if (MyReader2["Agendamento"].ToString() == "Sim")
                    {
                        Btnagendanao.Visible = false;
                        label3.Visible = true;
                        txtAtendMarcado.Visible = true;
                    }
                    else
                    {
                        Btnagendasim.Visible = false;
                        label3.Visible = false;
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
                    txtMotivoChamado.Text = MyReader2["Motivo"].ToString();
                    txtTipoMotivo.Text = MyReader2["SubMotivo"].ToString();
                    if (MyReader2["Prioridade"].ToString() == "false")
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
            DialogResult result1 = MessageBox.Show("Deseja cancelar a inserção do paciente na ambulancia ?",
            "Atenção !",
            MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                this.Dispose();
            }
            else
            {

            }

        }

        private void painelAM_Paint(object sender, PaintEventArgs e)
        {

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
                BtnUTI01.BackColor = Color.Red;
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
                button20.BackColor = Color.LimeGreen;
            }
            if (d.AMRC1 == "OCUPADA")
            {
                button20.BackColor = Color.Firebrick;
            }
            if (d.AMRC1 == "BLOQUEADA")
            {
                button20.BackColor = Color.RoyalBlue;
            }

            if (d.AM031 == "BLOQUEADA")
            {
                button5.BackColor = Color.RoyalBlue;
            }
            if (d.AM031 == "DISPONIVEL")
            {
                button5.BackColor = Color.LimeGreen;
            }
            if (d.AM031 == "OCUPADA")
            {
                button5.BackColor = Color.Firebrick;
            }

            if (d.AM051 == "BLOQUEADA")
            {
                button10.BackColor = Color.RoyalBlue;
            }
            if (d.AM051 == "OCUPADA")
            {
                button10.BackColor = Color.Firebrick;
            }
            if (d.AM051 == "DISPONIVEL")
            {
                button10.BackColor = Color.LimeGreen;
            }

            if (d.AM061 == "BLOQUEADA")
            {
                button13.BackColor = Color.RoyalBlue;
            }

            if (d.AM061 == "DISPONIVEL")
            {
                button13.BackColor = Color.LimeGreen;
            }

            if (d.AM061 == "OCUPADA")
            {
                button13.BackColor = Color.Firebrick;
            }

            if (d.AM071 == "BLOQUEADA")
            {
                button16.BackColor = Color.RoyalBlue;
            }
            if (d.AM071 == "OCUPADA")
            {
                button16.BackColor = Color.Firebrick;
            }
            if (d.AM071 == "DISPONIVEL")
            {
                button16.BackColor = Color.LimeGreen;
            }

            if (d.AM081 == "BLOQUEADA")
            {
                button19.BackColor = Color.RoyalBlue;
            }
            if (d.AM081 == "DISPONIVEL")
            {
                button19.BackColor = Color.LimeGreen;
            }
            if (d.AM081 == "OCUPADA")
            {
                button19.BackColor = Color.Firebrick;
            }

            if (d.AM091 == "OCUPADA")
            {
                button6.BackColor = Color.Firebrick;
            }
            if (d.AM091 == "DISPONIVEL")
            {
                button6.BackColor = Color.LimeGreen;
            }
            if (d.AM091 == "BLOQUEADA")
            {
                button6.BackColor = Color.RoyalBlue;
            }

            if (d.AM101 == "BLOQUEADA")
            {
                button9.BackColor = Color.RoyalBlue;
            }
            if (d.AM101 == "DISPONIVEL")
            {
                button9.BackColor = Color.LimeGreen;
            }
            if (d.AM101 == "OCUPADA")
            {
                button9.BackColor = Color.Firebrick;
            }

            if (d.AM111 == "OCUPADA")
            {
                button12.BackColor = Color.Firebrick;
            }
            if (d.AM111 == "DISPONIVEL")
            {
                button12.BackColor = Color.LimeGreen;
            }
            if (d.AM111 == "BLOQUEADA")
            {
                button12.BackColor = Color.RoyalBlue;
            }

            if (d.AM121 == "BLOQUEADA")
            {
                button15.BackColor = Color.RoyalBlue;
            }
            if (d.AM121 == "DISPONIVEL")
            {
                button15.BackColor = Color.LimeGreen;
            }
            if (d.AM121 == "OCUPADA")
            {
                button15.BackColor = Color.Firebrick;
            }

            if (d.AM131 == "OCUPADA")
            {
                button18.BackColor = Color.Firebrick;
            }
            if (d.AM131 == "DISPONIVEL")
            {
                button18.BackColor = Color.LimeGreen;
            }
            if (d.AM131 == "BLOQUEADA")
            {
                button18.BackColor = Color.RoyalBlue;
            }

            if (d.AM141 == "BLOQUEADA")
            {
                button7.BackColor = Color.RoyalBlue;
            }
            if (d.AM141 == "DISPONIVEL")
            {
                button7.BackColor = Color.LimeGreen;
            }
            if (d.AM141 == "OCUPADA")
            {
                button7.BackColor = Color.Firebrick;
            }

            if (d.AM151 == "OCUPADA")
            {
                button8.BackColor = Color.Firebrick;
            }
            if (d.AM151 == "DISPONIVEL")
            {
                button8.BackColor = Color.LimeGreen;
            }
            if (d.AM151 == "BLOQUEADA")
            {
                button8.BackColor = Color.RoyalBlue;
            }

            if (d.AM461 == "DISPONIVEL")
            {
                button11.BackColor = Color.LimeGreen;
            }
            if (d.AM461 == "OCUPADA")
            {
                button11.BackColor = Color.Firebrick;
            }
            if (d.AM461 == "BLOQUEADA")
            {
                button11.BackColor = Color.RoyalBlue;
            }

            if (d.AM471 == "OCUPADA")
            {
                button14.BackColor = Color.Firebrick;
            }
            if (d.AM471 == "DISPONIVEL")
            {
                button14.BackColor = Color.LimeGreen;
            }
            if (d.AM471 == "BLOQUEADA")
            {
                button14.BackColor = Color.RoyalBlue;
            }

            if (d.AM521 == "DISPONIVEL")
            {
                button17.BackColor = Color.LimeGreen;
            }
            if (d.AM521 == "OCUPADA")
            {
                button17.BackColor = Color.Firebrick;
            }
            if (d.AM521 == "BLOQUEADA")
            {
                button17.BackColor = Color.RoyalBlue;
            }

            // AM01, AM02, AMRC, AM03, AM05, AM06, AM07, AM08, AM09, AM10, AM11, AM12, AM13, AM14, AM15, AM46, AM47, AM52;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fonte = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
            Font fonte2 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point);


         //   Bitmap jpg = Properties.Resources."IMAGEM";
         //   Image newImage = jpg;
         //   e.Graphics.DrawImage(newImage, 1, 1, newImage.Width, newImage.Height);
         //e.Graphics.DrawString(txtNomePaciente.Text, fonte2, Brushes.Black, 290, 285);
        }




    }
}
