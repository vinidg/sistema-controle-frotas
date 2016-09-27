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
    public partial class EditarAmbulancias : Form
    {
        public EditarAmbulancias()
        {
            InitializeComponent();
            puxarAmbulancias();
            adicionarBotoesNaLista();
        }

        private void puxarAmbulancias()
        {
            using(DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from am in db.ambulancia
                             select new { 
                                am.idAmbulancia, 
                                Nome = am.NomeAmbulancia, 
                                Tipo = am.TipoAM, 
                                Desativado = am.Desativado 
                             } ).ToList();
                
                ListaDeAmbulancias.DataSource = query;
                ListaDeAmbulancias.Refresh();
                ListaDeAmbulancias.Columns[0].Visible = false;
            }
        }

        private void adicionarBotoesNaLista()
        {
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.HeaderText = "Editar";
            btnEditar.Name = "Editar";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            ListaDeAmbulancias.Columns.Add(btnEditar);

            DataGridViewButtonColumn btnDesativar = new DataGridViewButtonColumn();
            btnDesativar.Name = "Desativar";
            btnDesativar.Text = "Desativar";
            btnDesativar.UseColumnTextForButtonValue = true;
            ListaDeAmbulancias.Columns.Add(btnDesativar);


        }

        private void ListaDeAmbulancias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCheckBoxColumn btnCheck = new DataGridViewCheckBoxColumn(); 
            btnCheck.HeaderText = "Desativado";

            if (e.Value != null)
            {
                if(e.Value.Equals(0))
                {
                    e.Equals(btnCheck.FalseValue);
                }

                else if (e.Value.Equals(1))
                {
                    e.Equals(btnCheck.TrueValue);
                }
        }
    
        }

        private void ListaDeAmbulancias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(ListaDeAmbulancias.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if(ListaDeAmbulancias.Columns[e.RowIndex].Equals("Editar"))
                {

                }
            }
        }

    }
}
