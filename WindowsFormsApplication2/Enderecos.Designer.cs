﻿namespace Sistema_Controle
{
    partial class Enderecos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Enderecos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UpdateEndereco = new System.Windows.Forms.Button();
            this.Novo = new System.Windows.Forms.Button();
            this.Telefone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Endereco = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NomeUnidade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TabelaEnderecos = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabelaEnderecos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(252)))), ((int)(((byte)(194)))));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.TabelaEnderecos);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 563);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(252)))), ((int)(((byte)(194)))));
            this.groupBox1.Controls.Add(this.UpdateEndereco);
            this.groupBox1.Controls.Add(this.Novo);
            this.groupBox1.Controls.Add(this.Telefone);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Endereco);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NomeUnidade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(898, 186);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Endereço";
            // 
            // UpdateEndereco
            // 
            this.UpdateEndereco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(124)))), ((int)(((byte)(102)))));
            this.UpdateEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateEndereco.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.UpdateEndereco.Location = new System.Drawing.Point(363, 126);
            this.UpdateEndereco.Name = "UpdateEndereco";
            this.UpdateEndereco.Size = new System.Drawing.Size(91, 31);
            this.UpdateEndereco.TabIndex = 8;
            this.UpdateEndereco.Text = "Update";
            this.UpdateEndereco.UseVisualStyleBackColor = false;
            this.UpdateEndereco.Click += new System.EventHandler(this.Update_Click);
            // 
            // Novo
            // 
            this.Novo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(124)))), ((int)(((byte)(102)))));
            this.Novo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Novo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Novo.Location = new System.Drawing.Point(9, 126);
            this.Novo.Name = "Novo";
            this.Novo.Size = new System.Drawing.Size(91, 31);
            this.Novo.TabIndex = 7;
            this.Novo.Text = "Novo";
            this.Novo.UseVisualStyleBackColor = false;
            this.Novo.Click += new System.EventHandler(this.Novo_Click);
            // 
            // Telefone
            // 
            this.Telefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Telefone.Location = new System.Drawing.Point(199, 88);
            this.Telefone.Name = "Telefone";
            this.Telefone.Size = new System.Drawing.Size(255, 24);
            this.Telefone.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Telefone";
            // 
            // Endereco
            // 
            this.Endereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Endereco.Location = new System.Drawing.Point(149, 58);
            this.Endereco.Name = "Endereco";
            this.Endereco.Size = new System.Drawing.Size(305, 24);
            this.Endereco.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Endereço";
            // 
            // NomeUnidade
            // 
            this.NomeUnidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomeUnidade.Location = new System.Drawing.Point(119, 28);
            this.NomeUnidade.Name = "NomeUnidade";
            this.NomeUnidade.Size = new System.Drawing.Size(335, 24);
            this.NomeUnidade.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome Unidade";
            // 
            // TabelaEnderecos
            // 
            this.TabelaEnderecos.AllowUserToAddRows = false;
            this.TabelaEnderecos.AllowUserToDeleteRows = false;
            this.TabelaEnderecos.AllowUserToResizeColumns = false;
            this.TabelaEnderecos.AllowUserToResizeRows = false;
            this.TabelaEnderecos.BackgroundColor = System.Drawing.Color.White;
            this.TabelaEnderecos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TabelaEnderecos.Location = new System.Drawing.Point(3, 195);
            this.TabelaEnderecos.MultiSelect = false;
            this.TabelaEnderecos.Name = "TabelaEnderecos";
            this.TabelaEnderecos.ReadOnly = true;
            this.TabelaEnderecos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TabelaEnderecos.Size = new System.Drawing.Size(898, 365);
            this.TabelaEnderecos.TabIndex = 0;
            this.TabelaEnderecos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TabelaEnderecos_CellContentClick);
            this.TabelaEnderecos.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            this.TabelaEnderecos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TabelaEnderecos_KeyPress);
            // 
            // Enderecos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(224)))), ((int)(((byte)(173)))));
            this.ClientSize = new System.Drawing.Size(928, 587);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Enderecos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enderecos";
            this.Load += new System.EventHandler(this.Enderecos_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabelaEnderecos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView TabelaEnderecos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idControleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeUnidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enderecoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distanciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minutosDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button UpdateEndereco;
        private System.Windows.Forms.Button Novo;
        private System.Windows.Forms.TextBox Telefone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Endereco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NomeUnidade;
        private System.Windows.Forms.Label label1;
    }
}