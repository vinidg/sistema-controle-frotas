using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Controle
{
    public partial class Reagendar : Form
    {
        public Reagendar(string dataAgendamento)
        {
            InitializeComponent();
            dataAgendar.Text = dataAgendamento;
        }

        private void Enviar_Click(object sender, EventArgs e)
        {

        }
    }
}
