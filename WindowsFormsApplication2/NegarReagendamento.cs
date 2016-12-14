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
    public partial class NegarReagendamento : Form
    {
        int idpaciente;
        public NegarReagendamento(int idPaciente)
        {
            InitializeComponent();
            idpaciente = idPaciente;
        }

        private void Aceitar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Motivo.Text).Equals(false))
            {
                DialogResult result1 = MessageBox.Show("Deseja negar o agendamento ?",
                Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result1 == DialogResult.Yes)
                {
                    using (DAHUEEntities db = new DAHUEEntities())
                    {
                        solicitacoes_paciente sp = db.solicitacoes_paciente.First(p => p.idPaciente_Solicitacoes == idpaciente);
                        sp.Registrado = "Aguardando resposta do solicitante";

                        historico h = new historico();
                        h.DtHrRegistro = DateTime.Now;
                        h.idPaciente_Solicitacao = idpaciente;
                        h.Usuario = System.Environment.UserName;
                        h.Obs = Motivo.Text;
                        
                        db.historico.Add(h);

                        db.SaveChanges();
                    }
                    MessageBox.Show("Solicitação negada com sucesso !");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Erro ao enviar !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Motivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }


    }
}
