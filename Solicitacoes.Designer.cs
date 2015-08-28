namespace WindowsFormsApplication2
{
    partial class Solicitacoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Solicitacoes));
            this.label1 = new System.Windows.Forms.Label();
            this.ListaComPriori = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtTotal1 = new System.Windows.Forms.TextBox();
            this.txtTotal2 = new System.Windows.Forms.TextBox();
            this.ListaSemPriori = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal3 = new System.Windows.Forms.TextBox();
            this.ListaAgenda = new System.Windows.Forms.ListView();
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(64, -32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1144, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. Solicitações com Prioriadade:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListaComPriori
            // 
            this.ListaComPriori.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.ListaComPriori.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ListaComPriori.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader20,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.ListaComPriori.FullRowSelect = true;
            this.ListaComPriori.GridLines = true;
            this.ListaComPriori.Location = new System.Drawing.Point(68, 8);
            this.ListaComPriori.MultiSelect = false;
            this.ListaComPriori.Name = "ListaComPriori";
            this.ListaComPriori.Size = new System.Drawing.Size(1140, 197);
            this.ListaComPriori.TabIndex = 1;
            this.ListaComPriori.UseCompatibleStateImageBehavior = false;
            this.ListaComPriori.View = System.Windows.Forms.View.Details;
            this.ListaComPriori.DoubleClick += new System.EventHandler(this.ListaComPriori_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nº";
            this.columnHeader3.Width = 41;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nome";
            this.columnHeader1.Width = 315;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tipo";
            this.columnHeader2.Width = 119;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Data da Solicitação";
            this.columnHeader20.Width = 172;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Motivo do Transporte";
            this.columnHeader4.Width = 261;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Origem";
            this.columnHeader5.Width = 201;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Destino";
            this.columnHeader6.Width = 195;
            // 
            // txtTotal1
            // 
            this.txtTotal1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtTotal1.Enabled = false;
            this.txtTotal1.Location = new System.Drawing.Point(1170, 211);
            this.txtTotal1.Name = "txtTotal1";
            this.txtTotal1.Size = new System.Drawing.Size(38, 20);
            this.txtTotal1.TabIndex = 2;
            // 
            // txtTotal2
            // 
            this.txtTotal2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtTotal2.Enabled = false;
            this.txtTotal2.Location = new System.Drawing.Point(1170, 487);
            this.txtTotal2.Name = "txtTotal2";
            this.txtTotal2.Size = new System.Drawing.Size(38, 20);
            this.txtTotal2.TabIndex = 5;
            // 
            // ListaSemPriori
            // 
            this.ListaSemPriori.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.ListaSemPriori.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ListaSemPriori.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader21,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.ListaSemPriori.FullRowSelect = true;
            this.ListaSemPriori.GridLines = true;
            this.ListaSemPriori.Location = new System.Drawing.Point(68, 284);
            this.ListaSemPriori.MultiSelect = false;
            this.ListaSemPriori.Name = "ListaSemPriori";
            this.ListaSemPriori.Size = new System.Drawing.Size(1140, 197);
            this.ListaSemPriori.TabIndex = 4;
            this.ListaSemPriori.UseCompatibleStateImageBehavior = false;
            this.ListaSemPriori.View = System.Windows.Forms.View.Details;
            this.ListaSemPriori.DoubleClick += new System.EventHandler(this.ListaSemPriori_DoubleClick);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Nº";
            this.columnHeader9.Width = 41;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Nome";
            this.columnHeader7.Width = 315;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Tipo";
            this.columnHeader8.Width = 119;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Data da Solicitação";
            this.columnHeader21.Width = 171;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Motivo do Transporte";
            this.columnHeader10.Width = 261;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Origem";
            this.columnHeader11.Width = 201;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Destino";
            this.columnHeader12.Width = 195;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(64, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1144, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "2. Solicitações sem Prioriadade:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotal3
            // 
            this.txtTotal3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtTotal3.Enabled = false;
            this.txtTotal3.Location = new System.Drawing.Point(1170, 754);
            this.txtTotal3.Name = "txtTotal3";
            this.txtTotal3.Size = new System.Drawing.Size(38, 20);
            this.txtTotal3.TabIndex = 8;
            // 
            // ListaAgenda
            // 
            this.ListaAgenda.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.ListaAgenda.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.ListaAgenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ListaAgenda.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader22,
            this.columnHeader19,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18});
            this.ListaAgenda.FullRowSelect = true;
            this.ListaAgenda.GridLines = true;
            this.ListaAgenda.Location = new System.Drawing.Point(68, 551);
            this.ListaAgenda.MultiSelect = false;
            this.ListaAgenda.Name = "ListaAgenda";
            this.ListaAgenda.Size = new System.Drawing.Size(1140, 197);
            this.ListaAgenda.TabIndex = 7;
            this.ListaAgenda.UseCompatibleStateImageBehavior = false;
            this.ListaAgenda.View = System.Windows.Forms.View.Details;
            this.ListaAgenda.DoubleClick += new System.EventHandler(this.ListaAgenda_DoubleClick);
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Nº";
            this.columnHeader15.Width = 41;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Nome";
            this.columnHeader13.Width = 315;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Tipo";
            this.columnHeader14.Width = 119;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Data da Solicitação";
            this.columnHeader22.Width = 150;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Data do Agendamento";
            this.columnHeader19.Width = 148;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Motivo do Transporte";
            this.columnHeader16.Width = 261;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Origem";
            this.columnHeader17.Width = 201;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Destino";
            this.columnHeader18.Width = 195;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(68, 512);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1140, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "3. Solicitações Agendadas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 197);
            this.label4.TabIndex = 9;
            this.label4.Text = "Antigo\r\n.\r\n.\r\n.\r\n.\r\n.\r\n.\r\n.\r\n.\r\n.\r\n.\r\nV\r\nRecente";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 197);
            this.label5.TabIndex = 10;
            this.label5.Text = "Antigo\r\n.\r\n.\r\n.\r\n.\r\n.\r\n.\r\n.\r\n.\r\n.\r\n.\r\nV\r\nRecente";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(4, 551);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 197);
            this.label6.TabIndex = 11;
            this.label6.Text = "Antigo\r\n.\r\n.\r\n.\r\n.\r\n.\r\n.\r\n.\r\n.\r\n.\r\n.\r\nV\r\nRecente";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Solicitacoes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1220, 733);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotal3);
            this.Controls.Add(this.ListaAgenda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotal2);
            this.Controls.Add(this.ListaSemPriori);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotal1);
            this.Controls.Add(this.ListaComPriori);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Solicitacoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitacoes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView ListaComPriori;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox txtTotal1;
        private System.Windows.Forms.TextBox txtTotal2;
        private System.Windows.Forms.ListView ListaSemPriori;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotal3;
        private System.Windows.Forms.ListView ListaAgenda;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
    }
}