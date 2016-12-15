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
            this.consultaSolicitacoes = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataagendamento = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.localdasolicitacao = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.motivo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.destino = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.origem = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.diagnostico = new System.Windows.Forms.TextBox();
            this.dataFim = new System.Windows.Forms.DateTimePicker();
            this.dataInicio = new System.Windows.Forms.DateTimePicker();
            this.ListaSolicitacaoPaciente = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imprimirAgendamentos = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.OpcaoAmbulancia = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.consultaSolicitacoes)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaSolicitacaoPaciente)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero da ficha";
            // 
            // numeroFicha
            // 
            this.numeroFicha.Location = new System.Drawing.Point(12, 29);
            this.numeroFicha.Name = "numeroFicha";
            this.numeroFicha.Size = new System.Drawing.Size(177, 20);
            this.numeroFicha.TabIndex = 2;
            this.numeroFicha.Text = "0";
            this.numeroFicha.Click += new System.EventHandler(this.numeroFicha_Click);
            this.numeroFicha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeroFicha_KeyPress);
            // 
            // nome
            // 
            this.nome.Location = new System.Drawing.Point(225, 29);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(177, 20);
            this.nome.TabIndex = 4;
            this.nome.Click += new System.EventHandler(this.nome_Click);
            this.nome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nome_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(222, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(9, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data Inicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.Location = new System.Drawing.Point(222, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data Fim";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.Font = new System.Drawing.Font("Arial", 20.25F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(103, 608);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 79);
            this.button1.TabIndex = 9;
            this.button1.Text = "Pesquisar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // consultaSolicitacoes
            // 
            this.consultaSolicitacoes.AllowUserToAddRows = false;
            this.consultaSolicitacoes.AllowUserToDeleteRows = false;
            this.consultaSolicitacoes.AllowUserToResizeRows = false;
            this.consultaSolicitacoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.consultaSolicitacoes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.consultaSolicitacoes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(153)))));
            this.consultaSolicitacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.consultaSolicitacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consultaSolicitacoes.Location = new System.Drawing.Point(0, 0);
            this.consultaSolicitacoes.MultiSelect = false;
            this.consultaSolicitacoes.Name = "consultaSolicitacoes";
            this.consultaSolicitacoes.ReadOnly = true;
            this.consultaSolicitacoes.RowHeadersVisible = false;
            this.consultaSolicitacoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.consultaSolicitacoes.Size = new System.Drawing.Size(357, 640);
            this.consultaSolicitacoes.TabIndex = 12;
            this.consultaSolicitacoes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.consultaSolicitacoes_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(153)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.OpcaoAmbulancia);
            this.panel1.Controls.Add(this.dataagendamento);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.localdasolicitacao);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.motivo);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.destino);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.origem);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.diagnostico);
            this.panel1.Controls.Add(this.dataFim);
            this.panel1.Controls.Add(this.dataInicio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numeroFicha);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.nome);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 332);
            this.panel1.TabIndex = 15;
            // 
            // dataagendamento
            // 
            this.dataagendamento.CustomFormat = "dd/MM/yyyy";
            this.dataagendamento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataagendamento.Location = new System.Drawing.Point(225, 231);
            this.dataagendamento.Name = "dataagendamento";
            this.dataagendamento.Size = new System.Drawing.Size(177, 20);
            this.dataagendamento.TabIndex = 21;
            this.dataagendamento.Enter += new System.EventHandler(this.dataagendamento_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label11.Location = new System.Drawing.Point(222, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 16);
            this.label11.TabIndex = 20;
            this.label11.Text = "Data Agendamento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label10.Location = new System.Drawing.Point(9, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Local da Solicitação";
            // 
            // localdasolicitacao
            // 
            this.localdasolicitacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localdasolicitacao.FormattingEnabled = true;
            this.localdasolicitacao.Location = new System.Drawing.Point(12, 231);
            this.localdasolicitacao.Name = "localdasolicitacao";
            this.localdasolicitacao.Size = new System.Drawing.Size(177, 21);
            this.localdasolicitacao.TabIndex = 18;
            this.localdasolicitacao.Click += new System.EventHandler(this.localdasolicitacao_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label9.Location = new System.Drawing.Point(222, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Motivo";
            // 
            // motivo
            // 
            this.motivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.motivo.FormattingEnabled = true;
            this.motivo.Items.AddRange(new object[] {
            "ALTA HOSPITALAR",
            "AVALIAÇÃO DE MÉDICO ESPECIALISTA",
            "AVALIAÇÃO DE PROFISSIONAL NÃO MÉDICO",
            "CONSULTA AGENDADA",
            "DEMANDAS JUDICIAIS",
            "EVENTO COMEMORATIVO",
            "EVENTO DE CULTURA, LAZER OU RELIGIÃO",
            "EVENTO ESPORTIVO",
            "EXAME AGENDADO",
            "EXAME DE URGÊNCIA",
            "INTERNAÇÃO EM ENFERMARIA",
            "INTERNAÇÃO EM UTI",
            "PROCEDIMENTO",
            "RETORNO",
            "SALA VERMELHA/EMERGÊNCIA",
            "TRANSPORTE DE INSUMOS/PRODUTOS/MATERIAIS",
            "TRANSPORTE DE PROFISSIONAIS",
            "TRANSFERENCIA"});
            this.motivo.Location = new System.Drawing.Point(225, 128);
            this.motivo.Name = "motivo";
            this.motivo.Size = new System.Drawing.Size(177, 21);
            this.motivo.TabIndex = 16;
            this.motivo.Click += new System.EventHandler(this.motivo_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label8.Location = new System.Drawing.Point(222, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Destino";
            // 
            // destino
            // 
            this.destino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destino.FormattingEnabled = true;
            this.destino.Location = new System.Drawing.Point(225, 175);
            this.destino.Name = "destino";
            this.destino.Size = new System.Drawing.Size(177, 21);
            this.destino.TabIndex = 14;
            this.destino.Click += new System.EventHandler(this.destino_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label7.Location = new System.Drawing.Point(9, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Origem";
            // 
            // origem
            // 
            this.origem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.origem.FormattingEnabled = true;
            this.origem.Location = new System.Drawing.Point(12, 178);
            this.origem.Name = "origem";
            this.origem.Size = new System.Drawing.Size(177, 21);
            this.origem.TabIndex = 12;
            this.origem.Click += new System.EventHandler(this.origem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.Location = new System.Drawing.Point(9, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Diagnóstico";
            // 
            // diagnostico
            // 
            this.diagnostico.Location = new System.Drawing.Point(12, 129);
            this.diagnostico.Name = "diagnostico";
            this.diagnostico.Size = new System.Drawing.Size(177, 20);
            this.diagnostico.TabIndex = 11;
            this.diagnostico.Click += new System.EventHandler(this.diagnostico_Click);
            // 
            // dataFim
            // 
            this.dataFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataFim.Location = new System.Drawing.Point(225, 79);
            this.dataFim.Name = "dataFim";
            this.dataFim.Size = new System.Drawing.Size(177, 20);
            this.dataFim.TabIndex = 9;
            this.dataFim.Enter += new System.EventHandler(this.dataFim_Enter);
            // 
            // dataInicio
            // 
            this.dataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataInicio.Location = new System.Drawing.Point(12, 79);
            this.dataInicio.Name = "dataInicio";
            this.dataInicio.Size = new System.Drawing.Size(177, 20);
            this.dataInicio.TabIndex = 8;
            this.dataInicio.Enter += new System.EventHandler(this.dataInicio_Enter);
            // 
            // ListaSolicitacaoPaciente
            // 
            this.ListaSolicitacaoPaciente.AllowUserToAddRows = false;
            this.ListaSolicitacaoPaciente.AllowUserToDeleteRows = false;
            this.ListaSolicitacaoPaciente.AllowUserToResizeRows = false;
            this.ListaSolicitacaoPaciente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ListaSolicitacaoPaciente.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ListaSolicitacaoPaciente.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(153)))));
            this.ListaSolicitacaoPaciente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaSolicitacaoPaciente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaSolicitacaoPaciente.Location = new System.Drawing.Point(0, 0);
            this.ListaSolicitacaoPaciente.MultiSelect = false;
            this.ListaSolicitacaoPaciente.Name = "ListaSolicitacaoPaciente";
            this.ListaSolicitacaoPaciente.ReadOnly = true;
            this.ListaSolicitacaoPaciente.RowHeadersVisible = false;
            this.ListaSolicitacaoPaciente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListaSolicitacaoPaciente.Size = new System.Drawing.Size(419, 216);
            this.ListaSolicitacaoPaciente.TabIndex = 16;
            this.ListaSolicitacaoPaciente.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListaSolicitacaoPaciente_CellDoubleClick);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(782, 35);
            this.label6.TabIndex = 17;
            this.label6.Text = "Clique na consulta que deseja fazer";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(153)))));
            this.panel2.Controls.Add(this.ListaSolicitacaoPaciente);
            this.panel2.Location = new System.Drawing.Point(12, 386);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 216);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(153)))));
            this.panel3.Controls.Add(this.consultaSolicitacoes);
            this.panel3.Location = new System.Drawing.Point(437, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(357, 640);
            this.panel3.TabIndex = 19;
            // 
            // imprimirAgendamentos
            // 
            this.imprimirAgendamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imprimirAgendamentos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(224)))), ((int)(((byte)(173)))));
            this.imprimirAgendamentos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imprimirAgendamentos.BackgroundImage")));
            this.imprimirAgendamentos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imprimirAgendamentos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imprimirAgendamentos.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.imprimirAgendamentos.Location = new System.Drawing.Point(749, 7);
            this.imprimirAgendamentos.Name = "imprimirAgendamentos";
            this.imprimirAgendamentos.Size = new System.Drawing.Size(45, 37);
            this.imprimirAgendamentos.TabIndex = 38;
            this.imprimirAgendamentos.UseVisualStyleBackColor = false;
            this.imprimirAgendamentos.Click += new System.EventHandler(this.imprimirAgendamentos_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label12.Location = new System.Drawing.Point(9, 264);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "Ambulancia";
            // 
            // OpcaoAmbulancia
            // 
            this.OpcaoAmbulancia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OpcaoAmbulancia.FormattingEnabled = true;
            this.OpcaoAmbulancia.Location = new System.Drawing.Point(12, 283);
            this.OpcaoAmbulancia.Name = "OpcaoAmbulancia";
            this.OpcaoAmbulancia.Size = new System.Drawing.Size(177, 21);
            this.OpcaoAmbulancia.TabIndex = 22;
            this.OpcaoAmbulancia.Click += new System.EventHandler(this.OpcaoAmbulancia_Click);
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(226)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(806, 699);
            this.Controls.Add(this.imprimirAgendamentos);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            ((System.ComponentModel.ISupportInitialize)(this.consultaSolicitacoes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaSolicitacaoPaciente)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numeroFicha;
        private System.Windows.Forms.TextBox nome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView consultaSolicitacoes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView ListaSolicitacaoPaciente;
        private System.Windows.Forms.DateTimePicker dataFim;
        private System.Windows.Forms.DateTimePicker dataInicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox diagnostico;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox motivo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox destino;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox origem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox localdasolicitacao;
        private System.Windows.Forms.DateTimePicker dataagendamento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button imprimirAgendamentos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox OpcaoAmbulancia;


    }
}