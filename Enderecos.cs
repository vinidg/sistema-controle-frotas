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
    public partial class Enderecos : Form
    {
        int idControleEndereco;
        public Enderecos()
        {
            InitializeComponent();
        }

        private void Enderecos_Load(object sender, EventArgs e)
        {
            puxarEnderecos();

            TabelaEnderecos.Columns[4].Visible = false;
            TabelaEnderecos.Columns[5].Visible = false;
            TabelaEnderecos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            TabelaEnderecos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TabelaEnderecos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void puxarEnderecos()
        {
            using(DAHUEEntities db = new DAHUEEntities())
            {
                var query = (from en in db.enderecos
                             select new { en.idControle, en.NomeUnidade, en.Endereco, en.Telefone }).ToList();

                TabelaEnderecos.DataSource = query;
                TabelaEnderecos.Refresh();
            }
        }
        private void Novo_Click(object sender, EventArgs e)
        {
            using(DAHUEEntities db = new DAHUEEntities())
            {
                var enderecosPesquisa = (from ende in db.enderecos
                                        where ende.NomeUnidade == NomeUnidade.Text
                                        select ende.idControle).Count();
                if(enderecosPesquisa >= 1)
                {
                    MessageBox.Show("Endereço ja existe !", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if(NomeUnidade.Text != "" || Endereco.Text != "")
            {
                using(DAHUEEntities db = new DAHUEEntities())
                {
                    enderecos en = new enderecos();
                    en.NomeUnidade = NomeUnidade.Text;
                    en.Endereco = Endereco.Text;
                    en.Telefone = Telefone.Text;

                    db.enderecos.Add(en);
                    db.SaveChanges();
                    MessageBox.Show("Endereço salva com sucesso !", "Sucesso");
                }
                puxarEnderecos();
            }
        }
        private void Update_Click(object sender, EventArgs e)
        {
            if (NomeUnidade.Text != "" || Endereco.Text != "")
            {
                using (DAHUEEntities db = new DAHUEEntities())
                {
                    enderecos en = db.enderecos.First(ed => ed.idControle == idControleEndereco);
                    en.NomeUnidade = NomeUnidade.Text;
                    en.Endereco = Endereco.Text;
                    en.Telefone = Telefone.Text;

                    db.SaveChanges();
                    MessageBox.Show("Endereço atualizado com sucesso !", "Sucesso");
                }
                puxarEnderecos();

            }
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            idControleEndereco = Convert.ToInt32(TabelaEnderecos.Rows[e.RowIndex].Cells[0].Value.ToString());
            NomeUnidade.Text = TabelaEnderecos.Rows[e.RowIndex].Cells[1].Value.ToString();
            Endereco.Text = TabelaEnderecos.Rows[e.RowIndex].Cells[2].Value.ToString();
            Telefone.Text = TabelaEnderecos.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
        private void TabelaEnderecos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                idControleEndereco = Convert.ToInt32(TabelaEnderecos.Rows[e.RowIndex].Cells[0].Value.ToString());
                NomeUnidade.Text = TabelaEnderecos.Rows[e.RowIndex].Cells[1].Value.ToString();
                Endereco.Text = TabelaEnderecos.Rows[e.RowIndex].Cells[2].Value.ToString();
                Telefone.Text = TabelaEnderecos.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }
        private void TabelaEnderecos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 100 || e.KeyChar == 68)
            {
                DialogResult result1 = MessageBox.Show("Deseja exluir o endereço ?",
                "Atenção !",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    using (DAHUEEntities db = new DAHUEEntities())
                    {
                        enderecos en = db.enderecos.First(ea=> ea.idControle == idControleEndereco);
                        db.enderecos.Remove(en);
                        db.SaveChanges();
                        MessageBox.Show("Deletado !", "Sys");
                    }
                }
                puxarEnderecos();
            }
        }
    }
}
