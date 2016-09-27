namespace Sistema_Controle
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
            this.label1 = new System.Windows.Forms.Label();
            this.numeroFicha = new System.Windows.Forms.TextBox();
            this.nome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataInicio = new System.Windows.Forms.MaskedTextBox();
            this.dataFim = new System.Windows.Forms.MaskedTextBox();
            this.consultaSolicitacoes = new System.Windows.Forms.DataGridView();
            this.opcaoNumero = new System.Windows.Forms.RadioButton();
            this.opcaoNome = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ListaSolicitacaoPaciente = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.consultaSolicitacoes)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaSolicitacaoPaciente)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero da ficha";
            // 
            // numeroFicha
            // 
            this.numeroFicha.Location = new System.Drawing.Point(12, 41);
            this.numeroFicha.Name = "numeroFicha";
            this.numeroFicha.Size = new System.Drawing.Size(177, 20);
            this.numeroFicha.TabIndex = 2;
            this.numeroFicha.Text = "0";
            this.numeroFicha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeroFicha_KeyPress);
            // 
            // nome
            // 
            this.nome.Enabled = false;
            this.nome.Location = new System.Drawing.Point(225, 41);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(177, 20);
            this.nome.TabIndex = 4;
            this.nome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nome_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(222, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(9, 72);
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
            this.label4.Location = new System.Drawing.Point(222, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data Fim";
            this.label4.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.Font = new System.Drawing.Font("Arial", 20.25F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(114, 480);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 79);
            this.button1.TabIndex = 9;
            this.button1.Text = "Pesquisar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataInicio
            // 
            this.dataInicio.Location = new System.Drawing.Point(12, 101);
            this.dataInicio.Name = "dataInicio";
            this.dataInicio.Size = new System.Drawing.Size(177, 20);
            this.dataInicio.TabIndex = 10;
            this.dataInicio.ValidatingType = typeof(System.DateTime);
            this.dataInicio.Visible = false;
            this.dataInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataInicio_KeyPress);
            // 
            // dataFim
            // 
            this.dataFim.Location = new System.Drawing.Point(225, 101);
            this.dataFim.Name = "dataFim";
            this.dataFim.Size = new System.Drawing.Size(177, 20);
            this.dataFim.TabIndex = 11;
            this.dataFim.ValidatingType = typeof(System.DateTime);
            this.dataFim.Visible = false;
            this.dataFim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataFim_KeyPress);
            // 
            // consultaSolicitacoes
            // 
            this.consultaSolicitacoes.AllowUserToAddRows = false;
            this.consultaSolicitacoes.AllowUserToDeleteRows = false;
            this.consultaSolicitacoes.AllowUserToResizeRows = false;
            this.consultaSolicitacoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consultaSolicitacoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.consultaSolicitacoes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.consultaSolicitacoes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(153)))));
            this.consultaSolicitacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.consultaSolicitacoes.Location = new System.Drawing.Point(437, 12);
            this.consultaSolicitacoes.MultiSelect = false;
            this.consultaSolicitacoes.Name = "consultaSolicitacoes";
            this.consultaSolicitacoes.ReadOnly = true;
            this.consultaSolicitacoes.RowHeadersVisible = false;
            this.consultaSolicitacoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.consultaSolicitacoes.Size = new System.Drawing.Size(357, 547);
            this.consultaSolicitacoes.TabIndex = 12;
            this.consultaSolicitacoes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.consultaSolicitacoes_CellDoubleClick);
            // 
            // opcaoNumero
            // 
            this.opcaoNumero.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.opcaoNumero.AutoSize = true;
            this.opcaoNumero.Checked = true;
            this.opcaoNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.opcaoNumero.Location = new System.Drawing.Point(15, 12);
            this.opcaoNumero.Name = "opcaoNumero";
            this.opcaoNumero.Size = new System.Drawing.Size(158, 20);
            this.opcaoNumero.TabIndex = 13;
            this.opcaoNumero.TabStop = true;
            this.opcaoNumero.Text = "Pesquisar por numero";
            this.opcaoNumero.UseVisualStyleBackColor = true;
            this.opcaoNumero.CheckedChanged += new System.EventHandler(this.opcaoNumero_CheckedChanged);
            // 
            // opcaoNome
            // 
            this.opcaoNome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.opcaoNome.AutoSize = true;
            this.opcaoNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.opcaoNome.Location = new System.Drawing.Point(245, 12);
            this.opcaoNome.Name = "opcaoNome";
            this.opcaoNome.Size = new System.Drawing.Size(147, 20);
            this.opcaoNome.TabIndex = 14;
            this.opcaoNome.Text = "Pesquisar por nome";
            this.opcaoNome.UseVisualStyleBackColor = true;
            this.opcaoNome.CheckedChanged += new System.EventHandler(this.opcaoNome_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(153)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataFim);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numeroFicha);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.nome);
            this.panel1.Controls.Add(this.dataInicio);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 140);
            this.panel1.TabIndex = 15;
            // 
            // ListaSolicitacaoPaciente
            // 
            this.ListaSolicitacaoPaciente.AllowUserToAddRows = false;
            this.ListaSolicitacaoPaciente.AllowUserToDeleteRows = false;
            this.ListaSolicitacaoPaciente.AllowUserToResizeRows = false;
            this.ListaSolicitacaoPaciente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListaSolicitacaoPaciente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ListaSolicitacaoPaciente.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ListaSolicitacaoPaciente.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(153)))));
            this.ListaSolicitacaoPaciente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaSolicitacaoPaciente.Location = new System.Drawing.Point(12, 193);
            this.ListaSolicitacaoPaciente.MultiSelect = false;
            this.ListaSolicitacaoPaciente.Name = "ListaSolicitacaoPaciente";
            this.ListaSolicitacaoPaciente.ReadOnly = true;
            this.ListaSolicitacaoPaciente.RowHeadersVisible = false;
            this.ListaSolicitacaoPaciente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListaSolicitacaoPaciente.Size = new System.Drawing.Size(419, 281);
            this.ListaSolicitacaoPaciente.TabIndex = 16;
            this.ListaSolicitacaoPaciente.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListaSolicitacaoPaciente_CellDoubleClick);
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(226)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(806, 571);
            this.Controls.Add(this.ListaSolicitacaoPaciente);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.opcaoNome);
            this.Controls.Add(this.opcaoNumero);
            this.Controls.Add(this.consultaSolicitacoes);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            ((System.ComponentModel.ISupportInitialize)(this.consultaSolicitacoes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaSolicitacaoPaciente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numeroFicha;
        private System.Windows.Forms.TextBox nome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox dataInicio;
        private System.Windows.Forms.MaskedTextBox dataFim;
        private System.Windows.Forms.DataGridView consultaSolicitacoes;
        private System.Windows.Forms.RadioButton opcaoNumero;
        private System.Windows.Forms.RadioButton opcaoNome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView ListaSolicitacaoPaciente;


    }
}