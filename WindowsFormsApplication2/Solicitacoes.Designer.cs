namespace Sistema_Controle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Solicitacoes));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotal1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ListaSolicitacoes = new System.Windows.Forms.DataGridView();
            this.txtTotal3 = new System.Windows.Forms.TextBox();
            this.listaAgendadas = new System.Windows.Forms.DataGridView();
            this.OrdemPrioridade = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OrdemPaciente = new System.Windows.Forms.RadioButton();
            this.OrdemData = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtreagenda = new System.Windows.Forms.Label();
            this.dtagenda = new System.Windows.Forms.Label();
            this.dataReagendamento = new System.Windows.Forms.DateTimePicker();
            this.dataFiltroAgenda = new System.Windows.Forms.DateTimePicker();
            this.OrdemNomeAgenda = new System.Windows.Forms.RadioButton();
            this.OrdemDataAgenda = new System.Windows.Forms.RadioButton();
            this.OrdemPrioridadeAgenda = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.ListaSolicitacoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaAgendadas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(224)))), ((int)(((byte)(173)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(91)))), ((int)(((byte)(93)))));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1196, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solicitações";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotal1
            // 
            this.txtTotal1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtTotal1.Enabled = false;
            this.txtTotal1.Location = new System.Drawing.Point(1170, 397);
            this.txtTotal1.Name = "txtTotal1";
            this.txtTotal1.Size = new System.Drawing.Size(38, 20);
            this.txtTotal1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(91)))), ((int)(((byte)(93)))));
            this.label3.Location = new System.Drawing.Point(16, 397);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1192, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Solicitações Agendadas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListaSolicitacoes
            // 
            this.ListaSolicitacoes.AllowUserToAddRows = false;
            this.ListaSolicitacoes.AllowUserToDeleteRows = false;
            this.ListaSolicitacoes.AllowUserToOrderColumns = true;
            this.ListaSolicitacoes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.ListaSolicitacoes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ListaSolicitacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ListaSolicitacoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ListaSolicitacoes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ListaSolicitacoes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(252)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListaSolicitacoes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ListaSolicitacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ListaSolicitacoes.DefaultCellStyle = dataGridViewCellStyle3;
            this.ListaSolicitacoes.Location = new System.Drawing.Point(12, 102);
            this.ListaSolicitacoes.MultiSelect = false;
            this.ListaSolicitacoes.Name = "ListaSolicitacoes";
            this.ListaSolicitacoes.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListaSolicitacoes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ListaSolicitacoes.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.ListaSolicitacoes.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ListaSolicitacoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListaSolicitacoes.Size = new System.Drawing.Size(1196, 289);
            this.ListaSolicitacoes.TabIndex = 31;
            this.ListaSolicitacoes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaComPrioridade_CellDoubleClick);
            this.ListaSolicitacoes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.listaComPrioridade_CellFormatting);
            // 
            // txtTotal3
            // 
            this.txtTotal3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtTotal3.Enabled = false;
            this.txtTotal3.Location = new System.Drawing.Point(1170, 797);
            this.txtTotal3.Name = "txtTotal3";
            this.txtTotal3.Size = new System.Drawing.Size(38, 20);
            this.txtTotal3.TabIndex = 8;
            // 
            // listaAgendadas
            // 
            this.listaAgendadas.AllowUserToAddRows = false;
            this.listaAgendadas.AllowUserToDeleteRows = false;
            this.listaAgendadas.AllowUserToOrderColumns = true;
            this.listaAgendadas.AllowUserToResizeRows = false;
            this.listaAgendadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.listaAgendadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listaAgendadas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.listaAgendadas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(252)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listaAgendadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.listaAgendadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.listaAgendadas.DefaultCellStyle = dataGridViewCellStyle7;
            this.listaAgendadas.Location = new System.Drawing.Point(12, 524);
            this.listaAgendadas.MultiSelect = false;
            this.listaAgendadas.Name = "listaAgendadas";
            this.listaAgendadas.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listaAgendadas.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.listaAgendadas.RowHeadersVisible = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.listaAgendadas.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.listaAgendadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaAgendadas.Size = new System.Drawing.Size(1196, 267);
            this.listaAgendadas.TabIndex = 33;
            this.listaAgendadas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaAgendadas_CellDoubleClick_1);
            this.listaAgendadas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.listaAgendadas_CellFormatting);
            // 
            // OrdemPrioridade
            // 
            this.OrdemPrioridade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OrdemPrioridade.AutoSize = true;
            this.OrdemPrioridade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrdemPrioridade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(91)))), ((int)(((byte)(93)))));
            this.OrdemPrioridade.Location = new System.Drawing.Point(353, 21);
            this.OrdemPrioridade.Name = "OrdemPrioridade";
            this.OrdemPrioridade.Size = new System.Drawing.Size(98, 24);
            this.OrdemPrioridade.TabIndex = 34;
            this.OrdemPrioridade.Text = "Prioridade";
            this.OrdemPrioridade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OrdemPrioridade.UseVisualStyleBackColor = true;
            this.OrdemPrioridade.Click += new System.EventHandler(this.OrdemPrioridade_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.OrdemPaciente);
            this.groupBox1.Controls.Add(this.OrdemData);
            this.groupBox1.Controls.Add(this.OrdemPrioridade);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1196, 62);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordernar Por:";
            // 
            // OrdemPaciente
            // 
            this.OrdemPaciente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OrdemPaciente.AutoSize = true;
            this.OrdemPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrdemPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(91)))), ((int)(((byte)(93)))));
            this.OrdemPaciente.Location = new System.Drawing.Point(721, 21);
            this.OrdemPaciente.Name = "OrdemPaciente";
            this.OrdemPaciente.Size = new System.Drawing.Size(157, 24);
            this.OrdemPaciente.TabIndex = 36;
            this.OrdemPaciente.Text = "Nome do Paciente";
            this.OrdemPaciente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OrdemPaciente.UseVisualStyleBackColor = true;
            this.OrdemPaciente.Click += new System.EventHandler(this.OrdemPaciente_Click);
            // 
            // OrdemData
            // 
            this.OrdemData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OrdemData.AutoSize = true;
            this.OrdemData.Checked = true;
            this.OrdemData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrdemData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(91)))), ((int)(((byte)(93)))));
            this.OrdemData.Location = new System.Drawing.Point(532, 21);
            this.OrdemData.Name = "OrdemData";
            this.OrdemData.Size = new System.Drawing.Size(166, 24);
            this.OrdemData.TabIndex = 35;
            this.OrdemData.TabStop = true;
            this.OrdemData.Text = "Data de Abertura";
            this.OrdemData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OrdemData.UseVisualStyleBackColor = true;
            this.OrdemData.Click += new System.EventHandler(this.OrdemData_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dtreagenda);
            this.groupBox2.Controls.Add(this.dtagenda);
            this.groupBox2.Controls.Add(this.dataReagendamento);
            this.groupBox2.Controls.Add(this.dataFiltroAgenda);
            this.groupBox2.Controls.Add(this.OrdemNomeAgenda);
            this.groupBox2.Controls.Add(this.OrdemDataAgenda);
            this.groupBox2.Controls.Add(this.OrdemPrioridadeAgenda);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 423);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1196, 95);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ordernar Por:";
            // 
            // dtreagenda
            // 
            this.dtreagenda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtreagenda.AutoSize = true;
            this.dtreagenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtreagenda.ForeColor = System.Drawing.Color.Black;
            this.dtreagenda.Location = new System.Drawing.Point(880, 27);
            this.dtreagenda.Name = "dtreagenda";
            this.dtreagenda.Size = new System.Drawing.Size(190, 20);
            this.dtreagenda.TabIndex = 40;
            this.dtreagenda.Text = "Data de Reagendamento";
            // 
            // dtagenda
            // 
            this.dtagenda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtagenda.AutoSize = true;
            this.dtagenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtagenda.ForeColor = System.Drawing.Color.Black;
            this.dtagenda.Location = new System.Drawing.Point(495, 27);
            this.dtagenda.Name = "dtagenda";
            this.dtagenda.Size = new System.Drawing.Size(171, 20);
            this.dtagenda.TabIndex = 39;
            this.dtagenda.Text = "Data de Agendamento";
            // 
            // dataReagendamento
            // 
            this.dataReagendamento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataReagendamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataReagendamento.Location = new System.Drawing.Point(884, 50);
            this.dataReagendamento.Name = "dataReagendamento";
            this.dataReagendamento.Size = new System.Drawing.Size(297, 22);
            this.dataReagendamento.TabIndex = 38;
            this.dataReagendamento.ValueChanged += new System.EventHandler(this.dataReagendamento_ValueChanged);
            // 
            // dataFiltroAgenda
            // 
            this.dataFiltroAgenda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataFiltroAgenda.Location = new System.Drawing.Point(499, 50);
            this.dataFiltroAgenda.Name = "dataFiltroAgenda";
            this.dataFiltroAgenda.Size = new System.Drawing.Size(330, 22);
            this.dataFiltroAgenda.TabIndex = 37;
            this.dataFiltroAgenda.ValueChanged += new System.EventHandler(this.dataFiltroAgenda_ValueChanged);
            // 
            // OrdemNomeAgenda
            // 
            this.OrdemNomeAgenda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OrdemNomeAgenda.AutoSize = true;
            this.OrdemNomeAgenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrdemNomeAgenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(91)))), ((int)(((byte)(93)))));
            this.OrdemNomeAgenda.Location = new System.Drawing.Point(317, 42);
            this.OrdemNomeAgenda.Name = "OrdemNomeAgenda";
            this.OrdemNomeAgenda.Size = new System.Drawing.Size(157, 24);
            this.OrdemNomeAgenda.TabIndex = 36;
            this.OrdemNomeAgenda.Text = "Nome do Paciente";
            this.OrdemNomeAgenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OrdemNomeAgenda.UseVisualStyleBackColor = true;
            this.OrdemNomeAgenda.Click += new System.EventHandler(this.OrdemNomeAgenda_Click);
            // 
            // OrdemDataAgenda
            // 
            this.OrdemDataAgenda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OrdemDataAgenda.AutoSize = true;
            this.OrdemDataAgenda.Checked = true;
            this.OrdemDataAgenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrdemDataAgenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(91)))), ((int)(((byte)(93)))));
            this.OrdemDataAgenda.Location = new System.Drawing.Point(137, 42);
            this.OrdemDataAgenda.Name = "OrdemDataAgenda";
            this.OrdemDataAgenda.Size = new System.Drawing.Size(166, 24);
            this.OrdemDataAgenda.TabIndex = 35;
            this.OrdemDataAgenda.TabStop = true;
            this.OrdemDataAgenda.Text = "Data de Abertura";
            this.OrdemDataAgenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OrdemDataAgenda.UseVisualStyleBackColor = true;
            this.OrdemDataAgenda.Click += new System.EventHandler(this.OrdemDataAgenda_Click);
            // 
            // OrdemPrioridadeAgenda
            // 
            this.OrdemPrioridadeAgenda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OrdemPrioridadeAgenda.AutoSize = true;
            this.OrdemPrioridadeAgenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrdemPrioridadeAgenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(91)))), ((int)(((byte)(93)))));
            this.OrdemPrioridadeAgenda.Location = new System.Drawing.Point(8, 42);
            this.OrdemPrioridadeAgenda.Name = "OrdemPrioridadeAgenda";
            this.OrdemPrioridadeAgenda.Size = new System.Drawing.Size(98, 24);
            this.OrdemPrioridadeAgenda.TabIndex = 34;
            this.OrdemPrioridadeAgenda.Text = "Prioridade";
            this.OrdemPrioridadeAgenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OrdemPrioridadeAgenda.UseVisualStyleBackColor = true;
            this.OrdemPrioridadeAgenda.Click += new System.EventHandler(this.OrdemPrioridadeAgenda_Click);
            // 
            // Solicitacoes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(224)))), ((int)(((byte)(173)))));
            this.ClientSize = new System.Drawing.Size(1220, 819);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listaAgendadas);
            this.Controls.Add(this.ListaSolicitacoes);
            this.Controls.Add(this.txtTotal3);
            this.Controls.Add(this.txtTotal1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Solicitacoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitacoes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ListaSolicitacoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaAgendadas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotal1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView ListaSolicitacoes;
        private System.Windows.Forms.TextBox txtTotal3;
        private System.Windows.Forms.DataGridView listaAgendadas;
        private System.Windows.Forms.RadioButton OrdemPrioridade;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton OrdemData;
        private System.Windows.Forms.RadioButton OrdemPaciente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton OrdemNomeAgenda;
        private System.Windows.Forms.RadioButton OrdemDataAgenda;
        private System.Windows.Forms.RadioButton OrdemPrioridadeAgenda;
        private System.Windows.Forms.DateTimePicker dataFiltroAgenda;
        private System.Windows.Forms.Label dtreagenda;
        private System.Windows.Forms.Label dtagenda;
        private System.Windows.Forms.DateTimePicker dataReagendamento;
    }
}