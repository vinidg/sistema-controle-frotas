namespace Sistema_Controle
{
    partial class Reagedamentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reagedamentos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Negadas = new System.Windows.Forms.DataGridView();
            this.ListaReagementos = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Negadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaReagementos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(252)))), ((int)(((byte)(194)))));
            this.panel1.Controls.Add(this.Negadas);
            this.panel1.Controls.Add(this.ListaReagementos);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 409);
            this.panel1.TabIndex = 0;
            // 
            // Negadas
            // 
            this.Negadas.AllowUserToAddRows = false;
            this.Negadas.AllowUserToDeleteRows = false;
            this.Negadas.AllowUserToOrderColumns = true;
            this.Negadas.AllowUserToResizeRows = false;
            this.Negadas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Negadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Negadas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Negadas.BackgroundColor = System.Drawing.Color.White;
            this.Negadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Negadas.Location = new System.Drawing.Point(3, 203);
            this.Negadas.MultiSelect = false;
            this.Negadas.Name = "Negadas";
            this.Negadas.ReadOnly = true;
            this.Negadas.RowHeadersVisible = false;
            this.Negadas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Negadas.Size = new System.Drawing.Size(562, 204);
            this.Negadas.TabIndex = 1;
            this.Negadas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Negadas_CellContentClick);
            this.Negadas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Negadas_KeyPress);
            // 
            // ListaReagementos
            // 
            this.ListaReagementos.AllowUserToAddRows = false;
            this.ListaReagementos.AllowUserToDeleteRows = false;
            this.ListaReagementos.AllowUserToOrderColumns = true;
            this.ListaReagementos.AllowUserToResizeRows = false;
            this.ListaReagementos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListaReagementos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ListaReagementos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ListaReagementos.BackgroundColor = System.Drawing.Color.White;
            this.ListaReagementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaReagementos.Location = new System.Drawing.Point(3, 3);
            this.ListaReagementos.MultiSelect = false;
            this.ListaReagementos.Name = "ListaReagementos";
            this.ListaReagementos.ReadOnly = true;
            this.ListaReagementos.RowHeadersVisible = false;
            this.ListaReagementos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ListaReagementos.Size = new System.Drawing.Size(562, 204);
            this.ListaReagementos.TabIndex = 0;
            this.ListaReagementos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ListaReagementos_KeyPress);
            // 
            // Reagedamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(224)))), ((int)(((byte)(173)))));
            this.ClientSize = new System.Drawing.Size(592, 433);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Reagedamentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reagedamentos";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Negadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaReagementos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView ListaReagementos;
        private System.Windows.Forms.DataGridView Negadas;
    }
}