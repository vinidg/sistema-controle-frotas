namespace Sistema_Controle
{
    partial class EditarAmbulancias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarAmbulancias));
            this.panel1 = new System.Windows.Forms.Panel();
            this.update = new System.Windows.Forms.Button();
            this.OpcaoDesativado = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Tipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NomeUnidade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nova = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ListaDeAmbulancias = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaDeAmbulancias)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(252)))), ((int)(((byte)(194)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Id);
            this.panel1.Controls.Add(this.update);
            this.panel1.Controls.Add(this.OpcaoDesativado);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Tipo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.NomeUnidade);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.nova);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ListaDeAmbulancias);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 501);
            this.panel1.TabIndex = 0;
            // 
            // update
            // 
            this.update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.update.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.update.Location = new System.Drawing.Point(571, 108);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(72, 36);
            this.update.TabIndex = 26;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = false;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // OpcaoDesativado
            // 
            this.OpcaoDesativado.AutoSize = true;
            this.OpcaoDesativado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpcaoDesativado.Location = new System.Drawing.Point(280, 112);
            this.OpcaoDesativado.Name = "OpcaoDesativado";
            this.OpcaoDesativado.Size = new System.Drawing.Size(53, 22);
            this.OpcaoDesativado.TabIndex = 25;
            this.OpcaoDesativado.Text = "Sim";
            this.OpcaoDesativado.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 18);
            this.label3.TabIndex = 24;
            this.label3.Text = "Desativado";
            // 
            // Tipo
            // 
            this.Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Tipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tipo.FormattingEnabled = true;
            this.Tipo.Items.AddRange(new object[] {
            "AVANCADO",
            "BASICO"});
            this.Tipo.Location = new System.Drawing.Point(181, 80);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(152, 26);
            this.Tipo.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "Tipo";
            // 
            // NomeUnidade
            // 
            this.NomeUnidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomeUnidade.Location = new System.Drawing.Point(147, 50);
            this.NomeUnidade.Name = "NomeUnidade";
            this.NomeUnidade.Size = new System.Drawing.Size(186, 24);
            this.NomeUnidade.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "Nome Ambulancia";
            // 
            // nova
            // 
            this.nova.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nova.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.nova.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nova.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.nova.Location = new System.Drawing.Point(649, 108);
            this.nova.Name = "nova";
            this.nova.Size = new System.Drawing.Size(72, 36);
            this.nova.TabIndex = 19;
            this.nova.Text = "Nova";
            this.nova.UseVisualStyleBackColor = false;
            this.nova.Click += new System.EventHandler(this.nova_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(718, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Configuração das Ambulâncias";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListaDeAmbulancias
            // 
            this.ListaDeAmbulancias.AllowUserToAddRows = false;
            this.ListaDeAmbulancias.AllowUserToDeleteRows = false;
            this.ListaDeAmbulancias.AllowUserToOrderColumns = true;
            this.ListaDeAmbulancias.AllowUserToResizeRows = false;
            this.ListaDeAmbulancias.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ListaDeAmbulancias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaDeAmbulancias.Location = new System.Drawing.Point(3, 150);
            this.ListaDeAmbulancias.MultiSelect = false;
            this.ListaDeAmbulancias.Name = "ListaDeAmbulancias";
            this.ListaDeAmbulancias.ReadOnly = true;
            this.ListaDeAmbulancias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListaDeAmbulancias.Size = new System.Drawing.Size(718, 346);
            this.ListaDeAmbulancias.TabIndex = 0;
            this.ListaDeAmbulancias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListaDeAmbulancias_CellContentClick);
            this.ListaDeAmbulancias.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ListaDeAmbulancias_RowHeaderMouseClick);
            this.ListaDeAmbulancias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ListaDeAmbulancias_KeyPress);
            // 
            // Id
            // 
            this.Id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Id.AutoSize = true;
            this.Id.Location = new System.Drawing.Point(686, 10);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(35, 13);
            this.Id.TabIndex = 27;
            this.Id.Text = "label5";
            // 
            // EditarAmbulancias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(224)))), ((int)(((byte)(173)))));
            this.ClientSize = new System.Drawing.Size(750, 525);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditarAmbulancias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditarAmbulancias";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaDeAmbulancias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView ListaDeAmbulancias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button nova;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NomeUnidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Tipo;
        private System.Windows.Forms.CheckBox OpcaoDesativado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Label Id;
    }
}