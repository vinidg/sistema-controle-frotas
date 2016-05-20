namespace WindowsFormsApplication2
{
    partial class Consulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consulta));
            this.listaConsulta = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.numeroFicha = new System.Windows.Forms.TextBox();
            this.nome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataInicio = new System.Windows.Forms.MaskedTextBox();
            this.dataFim = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // listaConsulta
            // 
            this.listaConsulta.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listaConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listaConsulta.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listaConsulta.FullRowSelect = true;
            this.listaConsulta.GridLines = true;
            this.listaConsulta.Location = new System.Drawing.Point(499, 24);
            this.listaConsulta.MultiSelect = false;
            this.listaConsulta.Name = "listaConsulta";
            this.listaConsulta.Size = new System.Drawing.Size(295, 347);
            this.listaConsulta.TabIndex = 0;
            this.listaConsulta.UseCompatibleStateImageBehavior = false;
            this.listaConsulta.View = System.Windows.Forms.View.Details;
            this.listaConsulta.DoubleClick += new System.EventHandler(this.listaConsulta_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nº";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nome";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Genero";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Idade";
            this.columnHeader4.Width = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero da ficha";
            // 
            // numeroFicha
            // 
            this.numeroFicha.Location = new System.Drawing.Point(16, 32);
            this.numeroFicha.Name = "numeroFicha";
            this.numeroFicha.Size = new System.Drawing.Size(177, 20);
            this.numeroFicha.TabIndex = 2;
            // 
            // nome
            // 
            this.nome.Location = new System.Drawing.Point(295, 32);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(177, 20);
            this.nome.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(292, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(13, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data Inicio";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.Location = new System.Drawing.Point(292, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data Fim";
            this.label4.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Font = new System.Drawing.Font("Arial", 20.25F);
            this.button1.Location = new System.Drawing.Point(136, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 79);
            this.button1.TabIndex = 9;
            this.button1.Text = "Pesquisar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataInicio
            // 
            this.dataInicio.Location = new System.Drawing.Point(16, 92);
            this.dataInicio.Name = "dataInicio";
            this.dataInicio.Size = new System.Drawing.Size(177, 20);
            this.dataInicio.TabIndex = 10;
            this.dataInicio.ValidatingType = typeof(System.DateTime);
            this.dataInicio.Visible = false;
            this.dataInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataInicio_KeyPress);
            // 
            // dataFim
            // 
            this.dataFim.Location = new System.Drawing.Point(295, 92);
            this.dataFim.Name = "dataFim";
            this.dataFim.Size = new System.Drawing.Size(177, 20);
            this.dataFim.TabIndex = 11;
            this.dataFim.ValidatingType = typeof(System.DateTime);
            this.dataFim.Visible = false;
            this.dataFim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataFim_KeyPress);
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(806, 383);
            this.Controls.Add(this.dataFim);
            this.Controls.Add(this.dataInicio);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numeroFicha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listaConsulta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listaConsulta;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numeroFicha;
        private System.Windows.Forms.TextBox nome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox dataInicio;
        private System.Windows.Forms.MaskedTextBox dataFim;


    }
}