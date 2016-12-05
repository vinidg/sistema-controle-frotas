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
    public partial class OpcoesImprimir : Form
    {
        public OpcoesImprimir()
        {
            InitializeComponent();
        }
        public OpcoesImprimir(List<string> availableFields)
        {
            InitializeComponent();

            foreach (string field in availableFields)
                     chklst.Items.Add(field, true);
        }

        private void OpcoesImprimir_Load(object sender, EventArgs e)
        {
            TodasLinhas.Checked = true;
            AjustePorPagina.Checked = true;
            titulo.Text = "Agendamentos: " + DateTime.Now.ToShortDateString();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public List<string> GetSelecionarColunas()
        {
            List<string> lst = new List<string>();
            foreach (object item in chklst.CheckedItems)
                lst.Add(item.ToString());
            return lst;
        }
        public string PrintTitle
        {
            get { return titulo.Text; }
        }

        public bool PrintAllRows
        {
            get { return TodasLinhas.Checked; }
        }

        public bool FitToPageWidth
        {
            get { return AjustePorPagina.Checked; }
        }
    }
}
