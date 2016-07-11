namespace WindowsFormsApplication2
{
    partial class CONTROLE
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONTROLE));
            this.label1 = new System.Windows.Forms.Label();
            this.BtnNew = new System.Windows.Forms.Button();
            this.txtSolicitacoes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Consultar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAgendadasHoje = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ListaUsb = new System.Windows.Forms.ListView();
            this.AM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusAM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Idade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Origem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Destino = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ListaUsa = new System.Windows.Forms.ListView();
            this.AMUsa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusUsa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NomePacienteUsa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IdadeUsa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OrigemUsa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DestinoUsa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Re = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.notificador = new System.Windows.Forms.NotifyIcon(this.components);
            this.avisandoAoControle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(72, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1148, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "CONTROLE DE AMBULÂNCIAS - 2015";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnNew.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnNew.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnNew.Location = new System.Drawing.Point(1112, 16);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(144, 46);
            this.BtnNew.TabIndex = 18;
            this.BtnNew.Text = "NOVA";
            this.BtnNew.UseVisualStyleBackColor = false;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // txtSolicitacoes
            // 
            this.txtSolicitacoes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSolicitacoes.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolicitacoes.Location = new System.Drawing.Point(858, 74);
            this.txtSolicitacoes.Name = "txtSolicitacoes";
            this.txtSolicitacoes.Size = new System.Drawing.Size(77, 25);
            this.txtSolicitacoes.TabIndex = 19;
            this.txtSolicitacoes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSolicitacoes.Click += new System.EventHandler(this.txtSolicitacoes_Click);
            this.txtSolicitacoes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSolicitacoes_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(842, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 39);
            this.label2.TabIndex = 20;
            this.label2.Text = "SOLICITAÇÕES PENDENTES:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(391, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ocupado";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.Consultar);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtAgendadasHoje);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSolicitacoes);
            this.panel1.Controls.Add(this.BtnNew);
            this.panel1.Location = new System.Drawing.Point(12, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1268, 569);
            this.panel1.TabIndex = 0;
            // 
            // Consultar
            // 
            this.Consultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Consultar.BackColor = System.Drawing.Color.LightSlateGray;
            this.Consultar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Consultar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Consultar.Location = new System.Drawing.Point(1112, 68);
            this.Consultar.Name = "Consultar";
            this.Consultar.Size = new System.Drawing.Size(144, 46);
            this.Consultar.TabIndex = 29;
            this.Consultar.Text = "CONSULTAR";
            this.Consultar.UseVisualStyleBackColor = false;
            this.Consultar.Click += new System.EventHandler(this.Consultar_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(974, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 55);
            this.label6.TabIndex = 28;
            this.label6.Text = "SOLICITAÇÕES AGENDADAS HOJE:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAgendadasHoje
            // 
            this.txtAgendadasHoje.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAgendadasHoje.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgendadasHoje.Location = new System.Drawing.Point(993, 74);
            this.txtAgendadasHoje.Name = "txtAgendadasHoje";
            this.txtAgendadasHoje.Size = new System.Drawing.Size(77, 25);
            this.txtAgendadasHoje.TabIndex = 27;
            this.txtAgendadasHoje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAgendadasHoje.Click += new System.EventHandler(this.txtAgendadasHoje_Click);
            this.txtAgendadasHoje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAgendadasHoje_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.ListaUsb);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(95, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1045, 347);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "USB";
            // 
            // ListaUsb
            // 
            this.ListaUsb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListaUsb.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AM,
            this.StatusAM,
            this.Nome,
            this.Idade,
            this.Origem,
            this.Destino});
            this.ListaUsb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaUsb.GridLines = true;
            this.ListaUsb.Location = new System.Drawing.Point(6, 25);
            this.ListaUsb.MultiSelect = false;
            this.ListaUsb.Name = "ListaUsb";
            this.ListaUsb.Size = new System.Drawing.Size(1033, 316);
            this.ListaUsb.TabIndex = 0;
            this.ListaUsb.UseCompatibleStateImageBehavior = false;
            this.ListaUsb.View = System.Windows.Forms.View.Details;
            // 
            // AM
            // 
            this.AM.Text = "AM";
            // 
            // StatusAM
            // 
            this.StatusAM.Text = "Status";
            this.StatusAM.Width = 80;
            // 
            // Nome
            // 
            this.Nome.Text = "Nome do Paciente";
            this.Nome.Width = 153;
            // 
            // Idade
            // 
            this.Idade.Text = "Idade";
            // 
            // Origem
            // 
            this.Origem.Text = "Origem";
            this.Origem.Width = 160;
            // 
            // Destino
            // 
            this.Destino.Text = "Destino";
            this.Destino.Width = 160;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.ListaUsa);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(95, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(741, 127);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "USA";
            // 
            // ListaUsa
            // 
            this.ListaUsa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListaUsa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AMUsa,
            this.StatusUsa,
            this.NomePacienteUsa,
            this.IdadeUsa,
            this.OrigemUsa,
            this.DestinoUsa});
            this.ListaUsa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaUsa.GridLines = true;
            this.ListaUsa.Location = new System.Drawing.Point(6, 25);
            this.ListaUsa.MultiSelect = false;
            this.ListaUsa.Name = "ListaUsa";
            this.ListaUsa.Size = new System.Drawing.Size(729, 96);
            this.ListaUsa.TabIndex = 1;
            this.ListaUsa.UseCompatibleStateImageBehavior = false;
            this.ListaUsa.View = System.Windows.Forms.View.Details;
            // 
            // AMUsa
            // 
            this.AMUsa.Text = "AM";
            // 
            // StatusUsa
            // 
            this.StatusUsa.Text = "Status";
            this.StatusUsa.Width = 100;
            // 
            // NomePacienteUsa
            // 
            this.NomePacienteUsa.Text = "Nome do Paciente";
            this.NomePacienteUsa.Width = 177;
            // 
            // IdadeUsa
            // 
            this.IdadeUsa.Text = "Idade";
            // 
            // OrigemUsa
            // 
            this.OrigemUsa.Text = "Origem";
            this.OrigemUsa.Width = 160;
            // 
            // DestinoUsa
            // 
            this.DestinoUsa.Text = "Destino";
            this.DestinoUsa.Width = 160;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(63, 545);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1142, 21);
            this.panel2.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Green;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(524, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Disponível";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DarkBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(665, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Bloqueado";
            // 
            // Re
            // 
            this.Re.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Re.AutoSize = true;
            this.Re.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Re.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Re.Location = new System.Drawing.Point(1175, 9);
            this.Re.Name = "Re";
            this.Re.Size = new System.Drawing.Size(29, 16);
            this.Re.TabIndex = 23;
            this.Re.Text = "RE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication2.Properties.Resources.LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(12, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 97);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(102, 13);
            this.linkLabel1.TabIndex = 26;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "O que há de novo ?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // notificador
            // 
            this.notificador.Text = "Nova atualização, reinicie o sistema !!!";
            this.notificador.Visible = true;
            // 
            // avisandoAoControle
            // 
            this.avisandoAoControle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.avisandoAoControle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.avisandoAoControle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avisandoAoControle.ForeColor = System.Drawing.Color.Red;
            this.avisandoAoControle.Location = new System.Drawing.Point(12, 90);
            this.avisandoAoControle.Name = "avisandoAoControle";
            this.avisandoAoControle.Size = new System.Drawing.Size(1268, 16);
            this.avisandoAoControle.TabIndex = 27;
            this.avisandoAoControle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.avisandoAoControle.Visible = false;
            // 
            // CONTROLE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1292, 733);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Re);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.avisandoAoControle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CONTROLE";
            this.Text = "CONTROLE DE AMBULÂNCIA 2015";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.TextBox txtSolicitacoes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Re;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAgendadasHoje;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.NotifyIcon notificador;
        private System.Windows.Forms.Label avisandoAoControle;
        private System.Windows.Forms.Button Consultar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView ListaUsb;
        private System.Windows.Forms.ColumnHeader AM;
        private System.Windows.Forms.ColumnHeader StatusAM;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.ColumnHeader Idade;
        private System.Windows.Forms.ColumnHeader Destino;
        private System.Windows.Forms.ColumnHeader Origem;
        private System.Windows.Forms.ListView ListaUsa;
        private System.Windows.Forms.ColumnHeader AMUsa;
        private System.Windows.Forms.ColumnHeader StatusUsa;
        private System.Windows.Forms.ColumnHeader NomePacienteUsa;
        private System.Windows.Forms.ColumnHeader IdadeUsa;
        private System.Windows.Forms.ColumnHeader DestinoUsa;
        private System.Windows.Forms.ColumnHeader OrigemUsa;
    }
}

