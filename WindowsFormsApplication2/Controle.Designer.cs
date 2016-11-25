namespace Sistema_Controle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONTROLE));
            this.BtnNew = new System.Windows.Forms.Button();
            this.txtSolicitacoes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listaUsb = new System.Windows.Forms.DataGridView();
            this.EnderecosEditar = new System.Windows.Forms.Button();
            this.Editar = new System.Windows.Forms.Button();
            this.AgendaPendentes = new System.Windows.Forms.Button();
            this.solicitacoes = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAgendasPendentes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Consultar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAgendadasHoje = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listaUsa = new System.Windows.Forms.DataGridView();
            this.Re = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.avisandoAoControle = new System.Windows.Forms.Label();
            this.Atualizar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaUsb)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaUsa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnNew
            // 
            this.BtnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.BtnNew.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnNew.Location = new System.Drawing.Point(1106, 52);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(144, 46);
            this.BtnNew.TabIndex = 18;
            this.BtnNew.Text = "NOVA";
            this.BtnNew.UseVisualStyleBackColor = false;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // txtSolicitacoes
            // 
            this.txtSolicitacoes.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolicitacoes.Location = new System.Drawing.Point(319, 8);
            this.txtSolicitacoes.Name = "txtSolicitacoes";
            this.txtSolicitacoes.Size = new System.Drawing.Size(77, 25);
            this.txtSolicitacoes.TabIndex = 19;
            this.txtSolicitacoes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSolicitacoes.Click += new System.EventHandler(this.txtSolicitacoes_Click);
            this.txtSolicitacoes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSolicitacoes_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(173)))), ((int)(((byte)(168)))));
            this.label2.Location = new System.Drawing.Point(93, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "SOLICITAÇÕES PENDENTES:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(252)))), ((int)(((byte)(194)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.EnderecosEditar);
            this.panel1.Controls.Add(this.Editar);
            this.panel1.Controls.Add(this.AgendaPendentes);
            this.panel1.Controls.Add(this.solicitacoes);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtAgendasPendentes);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Consultar);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtAgendadasHoje);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSolicitacoes);
            this.panel1.Controls.Add(this.BtnNew);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 147);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 620);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Location = new System.Drawing.Point(888, 592);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(371, 27);
            this.panel2.TabIndex = 36;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Green;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(138, 5);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(82, 16);
            this.label23.TabIndex = 22;
            this.label23.Text = "Disponível";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.DarkBlue;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(281, 5);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(84, 16);
            this.label24.TabIndex = 23;
            this.label24.Text = "Bloqueado";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Red;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(7, 5);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(71, 16);
            this.label25.TabIndex = 21;
            this.label25.Text = "Ocupado";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listaUsb);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(173)))), ((int)(((byte)(168)))));
            this.groupBox2.Location = new System.Drawing.Point(47, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1155, 345);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "USB";
            // 
            // listaUsb
            // 
            this.listaUsb.AllowUserToAddRows = false;
            this.listaUsb.AllowUserToDeleteRows = false;
            this.listaUsb.AllowUserToResizeRows = false;
            this.listaUsb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaUsb.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.listaUsb.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(252)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listaUsb.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(173)))), ((int)(((byte)(168)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaUsb.DefaultCellStyle = dataGridViewCellStyle2;
            this.listaUsb.Location = new System.Drawing.Point(6, 25);
            this.listaUsb.MultiSelect = false;
            this.listaUsb.Name = "listaUsb";
            this.listaUsb.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listaUsb.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listaUsb.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.listaUsb.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.listaUsb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaUsb.Size = new System.Drawing.Size(1143, 314);
            this.listaUsb.TabIndex = 30;
            this.listaUsb.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaUsb_CellDoubleClick);
            this.listaUsb.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.listaUsb_CellFormatting);
            // 
            // EnderecosEditar
            // 
            this.EnderecosEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EnderecosEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(173)))), ((int)(((byte)(168)))));
            this.EnderecosEditar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnderecosEditar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.EnderecosEditar.Location = new System.Drawing.Point(405, 52);
            this.EnderecosEditar.Name = "EnderecosEditar";
            this.EnderecosEditar.Size = new System.Drawing.Size(159, 46);
            this.EnderecosEditar.TabIndex = 36;
            this.EnderecosEditar.Text = "ENDEREÇOS";
            this.EnderecosEditar.UseVisualStyleBackColor = false;
            this.EnderecosEditar.Click += new System.EventHandler(this.EnderecosEditar_Click);
            // 
            // Editar
            // 
            this.Editar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Editar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(173)))), ((int)(((byte)(168)))));
            this.Editar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Editar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Editar.Location = new System.Drawing.Point(216, 52);
            this.Editar.Name = "Editar";
            this.Editar.Size = new System.Drawing.Size(183, 46);
            this.Editar.TabIndex = 30;
            this.Editar.Text = "EDITAR AMBULÂNCIAS";
            this.Editar.UseVisualStyleBackColor = false;
            this.Editar.Click += new System.EventHandler(this.Editar_Click);
            // 
            // AgendaPendentes
            // 
            this.AgendaPendentes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AgendaPendentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(173)))), ((int)(((byte)(168)))));
            this.AgendaPendentes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgendaPendentes.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.AgendaPendentes.Location = new System.Drawing.Point(570, 52);
            this.AgendaPendentes.Name = "AgendaPendentes";
            this.AgendaPendentes.Size = new System.Drawing.Size(196, 46);
            this.AgendaPendentes.TabIndex = 35;
            this.AgendaPendentes.Text = "AGENDAMENTOS PENDENTES";
            this.AgendaPendentes.UseVisualStyleBackColor = false;
            this.AgendaPendentes.Click += new System.EventHandler(this.AgendaPendentes_Click);
            // 
            // solicitacoes
            // 
            this.solicitacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.solicitacoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(173)))), ((int)(((byte)(168)))));
            this.solicitacoes.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solicitacoes.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.solicitacoes.Location = new System.Drawing.Point(772, 52);
            this.solicitacoes.Name = "solicitacoes";
            this.solicitacoes.Size = new System.Drawing.Size(178, 46);
            this.solicitacoes.TabIndex = 34;
            this.solicitacoes.Text = "SOLICITAÇÕES";
            this.solicitacoes.UseVisualStyleBackColor = false;
            this.solicitacoes.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(62)))), ((int)(((byte)(54)))));
            this.label4.Location = new System.Drawing.Point(836, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(315, 18);
            this.label4.TabIndex = 33;
            this.label4.Text = "SOLICITAÇÕES AGENDADAS PENDENTES:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAgendasPendentes
            // 
            this.txtAgendasPendentes.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgendasPendentes.Location = new System.Drawing.Point(1157, 8);
            this.txtAgendasPendentes.Name = "txtAgendasPendentes";
            this.txtAgendasPendentes.Size = new System.Drawing.Size(77, 25);
            this.txtAgendasPendentes.TabIndex = 32;
            this.txtAgendasPendentes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAgendasPendentes.Click += new System.EventHandler(this.txtAgendasPendentes_Click);
            this.txtAgendasPendentes.TextChanged += new System.EventHandler(this.txtAgendasPendentes_TextChanged);
            this.txtAgendasPendentes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAgendasPendentes_KeyDown);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 595);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1262, 23);
            this.label3.TabIndex = 31;
            this.label3.Text = "© 2016 - Departamento de Atenção Hospitalar de Urgência e Emergência";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Consultar
            // 
            this.Consultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Consultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(173)))), ((int)(((byte)(168)))));
            this.Consultar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Consultar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Consultar.Location = new System.Drawing.Point(956, 52);
            this.Consultar.Name = "Consultar";
            this.Consultar.Size = new System.Drawing.Size(144, 46);
            this.Consultar.TabIndex = 29;
            this.Consultar.Text = "CONSULTAR";
            this.Consultar.UseVisualStyleBackColor = false;
            this.Consultar.Click += new System.EventHandler(this.Consultar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(449, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 18);
            this.label6.TabIndex = 28;
            this.label6.Text = "SOLICITAÇÕES AGENDADAS HOJE:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAgendadasHoje
            // 
            this.txtAgendadasHoje.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgendadasHoje.Location = new System.Drawing.Point(718, 8);
            this.txtAgendadasHoje.Name = "txtAgendadasHoje";
            this.txtAgendadasHoje.Size = new System.Drawing.Size(77, 25);
            this.txtAgendadasHoje.TabIndex = 27;
            this.txtAgendadasHoje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAgendadasHoje.Click += new System.EventHandler(this.txtAgendadasHoje_Click);
            this.txtAgendadasHoje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAgendadasHoje_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listaUsa);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(173)))), ((int)(((byte)(168)))));
            this.groupBox1.Location = new System.Drawing.Point(47, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1155, 143);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "USA";
            // 
            // listaUsa
            // 
            this.listaUsa.AllowUserToAddRows = false;
            this.listaUsa.AllowUserToDeleteRows = false;
            this.listaUsa.AllowUserToResizeRows = false;
            this.listaUsa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaUsa.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.listaUsa.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(252)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listaUsa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(173)))), ((int)(((byte)(168)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaUsa.DefaultCellStyle = dataGridViewCellStyle6;
            this.listaUsa.Location = new System.Drawing.Point(6, 25);
            this.listaUsa.MultiSelect = false;
            this.listaUsa.Name = "listaUsa";
            this.listaUsa.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listaUsa.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.listaUsa.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            this.listaUsa.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.listaUsa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaUsa.Size = new System.Drawing.Size(1143, 107);
            this.listaUsa.TabIndex = 31;
            this.listaUsa.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.listaUsa_CellFormatting);
            this.listaUsa.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.listaUsa_CellMouseDoubleClick);
            // 
            // Re
            // 
            this.Re.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Re.AutoSize = true;
            this.Re.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Re.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Re.Location = new System.Drawing.Point(1171, 9);
            this.Re.Name = "Re";
            this.Re.Size = new System.Drawing.Size(29, 16);
            this.Re.TabIndex = 23;
            this.Re.Text = "RE";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 125);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(102, 13);
            this.linkLabel1.TabIndex = 26;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "O que há de novo ?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // avisandoAoControle
            // 
            this.avisandoAoControle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.avisandoAoControle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.avisandoAoControle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avisandoAoControle.ForeColor = System.Drawing.Color.Red;
            this.avisandoAoControle.Location = new System.Drawing.Point(16, 90);
            this.avisandoAoControle.Name = "avisandoAoControle";
            this.avisandoAoControle.Size = new System.Drawing.Size(1260, 16);
            this.avisandoAoControle.TabIndex = 27;
            this.avisandoAoControle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.avisandoAoControle.Visible = false;
            // 
            // Atualizar
            // 
            this.Atualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Atualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(120)))), ((int)(((byte)(143)))));
            this.Atualizar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Atualizar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Atualizar.Location = new System.Drawing.Point(1147, 109);
            this.Atualizar.Name = "Atualizar";
            this.Atualizar.Size = new System.Drawing.Size(129, 35);
            this.Atualizar.TabIndex = 34;
            this.Atualizar.Text = "ATUALIZAR";
            this.Atualizar.UseVisualStyleBackColor = false;
            this.Atualizar.Visible = false;
            this.Atualizar.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(224)))), ((int)(((byte)(173)))));
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(70, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1148, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "CONTROLE DE AMBULÂNCIAS - 2015";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CONTROLE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(224)))), ((int)(((byte)(173)))));
            this.ClientSize = new System.Drawing.Size(1288, 788);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Atualizar);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Re);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.avisandoAoControle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CONTROLE";
            this.Text = "CONTROLE DE AMBULÂNCIA 2015";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listaUsb)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listaUsa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.TextBox txtSolicitacoes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Re;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAgendadasHoje;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label avisandoAoControle;
        private System.Windows.Forms.Button Consultar;
        private System.Windows.Forms.DataGridView listaUsa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView listaUsb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAgendasPendentes;
        private System.Windows.Forms.Button Atualizar;
        private System.Windows.Forms.Button AgendaPendentes;
        private System.Windows.Forms.Button solicitacoes;
        private System.Windows.Forms.Button Editar;
        private System.Windows.Forms.Button EnderecosEditar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
    }
}

