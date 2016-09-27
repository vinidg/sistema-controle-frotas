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
            this.BtnNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ListaDeAmbulancias = new System.Windows.Forms.DataGridView();
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
            this.panel1.Controls.Add(this.BtnNew);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ListaDeAmbulancias);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 501);
            this.panel1.TabIndex = 0;
            // 
            // BtnNew
            // 
            this.BtnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.BtnNew.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnNew.Location = new System.Drawing.Point(649, 72);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(72, 36);
            this.BtnNew.TabIndex = 19;
            this.BtnNew.Text = "Nova";
            this.BtnNew.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
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
            this.ListaDeAmbulancias.Location = new System.Drawing.Point(3, 114);
            this.ListaDeAmbulancias.MultiSelect = false;
            this.ListaDeAmbulancias.Name = "ListaDeAmbulancias";
            this.ListaDeAmbulancias.ReadOnly = true;
            this.ListaDeAmbulancias.RowHeadersVisible = false;
            this.ListaDeAmbulancias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListaDeAmbulancias.Size = new System.Drawing.Size(718, 382);
            this.ListaDeAmbulancias.TabIndex = 0;
            this.ListaDeAmbulancias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListaDeAmbulancias_CellContentClick);
            this.ListaDeAmbulancias.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ListaDeAmbulancias_CellFormatting);
            // 
            // EditarAmbulancias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(224)))), ((int)(((byte)(173)))));
            this.ClientSize = new System.Drawing.Size(750, 525);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditarAmbulancias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditarAmbulancias";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListaDeAmbulancias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView ListaDeAmbulancias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnNew;
    }
}