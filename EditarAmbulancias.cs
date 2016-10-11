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
    int idControleAmbulancia;
        public EditarAmbulancias()
        {
            InitializeComponent();
            puxarAmbulancias();
            Id.Text = "";
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
  

        private void ListaDeAmbulancias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idControleAmbulancia = Convert.ToInt32(ListaDeAmbulancias.Rows[e.RowIndex].Cells[0].Value.ToString());
            NomeUnidade.Text = ListaDeAmbulancias.Rows[e.RowIndex].Cells[1].Value.ToString();
            Tipo.Text = ListaDeAmbulancias.Rows[e.RowIndex].Cells[2].Value.ToString();

            if (ListaDeAmbulancias.Rows[e.RowIndex].Cells[3].Value.ToString() == "1")
            {
                OpcaoDesativado.Checked = true;
            }
            else
            {
                OpcaoDesativado.Checked = false;
            }
            Id.Text = idControleAmbulancia.ToString();
        }

        private void ListaDeAmbulancias_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            idControleAmbulancia = Convert.ToInt32(ListaDeAmbulancias.Rows[e.RowIndex].Cells[0].Value.ToString());
            NomeUnidade.Text = ListaDeAmbulancias.Rows[e.RowIndex].Cells[1].Value.ToString();
            Tipo.Text = ListaDeAmbulancias.Rows[e.RowIndex].Cells[2].Value.ToString();

            if (ListaDeAmbulancias.Rows[e.RowIndex].Cells[3].Value.ToString() == "1")
            {
                OpcaoDesativado.Checked = true;
            }
            else
            {
                OpcaoDesativado.Checked = false;
            }

            Id.Text = idControleAmbulancia.ToString();
        }

        private void nova_Click(object sender, EventArgs e)
        {
            using (DAHUEEntities db = new DAHUEEntities())
            {
                var ambulanciaPesquisa = (from am in db.ambulancia
                                         where am.NomeAmbulancia == NomeUnidade.Text
                                         select am.idAmbulancia).Count();
                if (ambulanciaPesquisa >= 1)
                {
                    MessageBox.Show("Endereço ja existe !", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (NomeUnidade.Text != "")
            {
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    ambulancia am = new ambulancia();
                    am.NomeAmbulancia = NomeUnidade.Text;
                    am.TipoAM = Tipo.Text;
                    if(OpcaoDesativado.Checked == true)
                    {
                        am.Desativado = 1;
                    }else
                    {
                        am.Desativado = 0;
                    }

                    db.ambulancia.Add(am);
                    db.SaveChanges();
                    MessageBox.Show("Ambulancia salva com sucesso !", "Sucesso");
                }
                puxarAmbulancias();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (NomeUnidade.Text != "")
            {
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    ambulancia am = db.ambulancia.First(ama => ama.idAmbulancia == idControleAmbulancia);
                    am.NomeAmbulancia = NomeUnidade.Text;
                    am.TipoAM = Tipo.Text;
                    if (OpcaoDesativado.Checked == true)
                    {
                        am.Desativado = 1;
                    }
                    else
                    {
                        am.Desativado = 0;
                    }

                    db.SaveChanges();
                    MessageBox.Show("Ambulancia atualizado com sucesso !", "Sucesso");
                }
                puxarAmbulancias();

            }
        }

        private void ListaDeAmbulancias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 100 || e.KeyChar == 68)
            {
                DialogResult result1 = MessageBox.Show("Deseja exluir o ambulancia ?",
                "Atenção !",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    using (DAHUEEntities db = new DAHUEEntities())
                    {
                        ambulancia en = db.ambulancia.First(ea => ea.idAmbulancia == idControleAmbulancia);
                        db.ambulancia.Remove(en);
                        db.SaveChanges();
                        MessageBox.Show("Deletado !", "Sys");
                    }
                }
                puxarAmbulancias();
            }
        }


    }
}
