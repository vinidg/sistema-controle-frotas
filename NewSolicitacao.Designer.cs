namespace WindowsFormsApplication2
{
    partial class ConfirmaSolicitacao
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtnBasica = new System.Windows.Forms.Button();
            this.BtnAvancada = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.BtnLimpar = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtEnderecoDestino = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtEnderecoOrigem = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.CbDestino = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.CbOrigem = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CbAtendimentoPrioridade = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.CbTipoMotivoSelecionado = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.CbMotivoChamado = new System.Windows.Forms.ComboBox();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIdade = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.RbFemenino = new System.Windows.Forms.RadioButton();
            this.RbMasculino = new System.Windows.Forms.RadioButton();
            this.txtNomePaciente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CbLocalSolicita = new System.Windows.Forms.ComboBox();
            this.txtNomeSolicitante = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAtendMarcado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Btnagendasim = new System.Windows.Forms.Button();
            this.Btnagendanao = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. Qual o tipo de ambulância necessária?";
            // 
            // BtnBasica
            // 
            this.BtnBasica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBasica.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BtnBasica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBasica.ForeColor = System.Drawing.Color.DimGray;
            this.BtnBasica.Location = new System.Drawing.Point(379, 10);
            this.BtnBasica.Name = "BtnBasica";
            this.BtnBasica.Size = new System.Drawing.Size(75, 23);
            this.BtnBasica.TabIndex = 1;
            this.BtnBasica.Text = "Básica";
            this.BtnBasica.UseVisualStyleBackColor = false;
            this.BtnBasica.Click += new System.EventHandler(this.BtnBasica_Click);
            // 
            // BtnAvancada
            // 
            this.BtnAvancada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAvancada.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BtnAvancada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAvancada.ForeColor = System.Drawing.Color.DimGray;
            this.BtnAvancada.Location = new System.Drawing.Point(460, 10);
            this.BtnAvancada.Name = "BtnAvancada";
            this.BtnAvancada.Size = new System.Drawing.Size(82, 23);
            this.BtnAvancada.TabIndex = 2;
            this.BtnAvancada.Text = "Avançada";
            this.BtnAvancada.UseVisualStyleBackColor = false;
            this.BtnAvancada.Click += new System.EventHandler(this.BtnAvancada_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.BtnSalvar);
            this.panel1.Controls.Add(this.BtnLimpar);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.txtEnderecoDestino);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.txtEnderecoOrigem);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.CbDestino);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.CbOrigem);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.CbAtendimentoPrioridade);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.CbTipoMotivoSelecionado);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.CbMotivoChamado);
            this.panel1.Controls.Add(this.txtDiagnostico);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtIdade);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.RbFemenino);
            this.panel1.Controls.Add(this.RbMasculino);
            this.panel1.Controls.Add(this.txtNomePaciente);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtTelefone);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.CbLocalSolicita);
            this.panel1.Controls.Add(this.txtNomeSolicitante);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtAtendMarcado);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Btnagendasim);
            this.panel1.Controls.Add(this.Btnagendanao);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BtnAvancada);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtnBasica);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 815);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSalvar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BtnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalvar.ForeColor = System.Drawing.Color.DimGray;
            this.BtnSalvar.Location = new System.Drawing.Point(400, 744);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(129, 57);
            this.BtnSalvar.TabIndex = 42;
            this.BtnSalvar.Text = "SALVAR REGISTRO";
            this.BtnSalvar.UseVisualStyleBackColor = false;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // BtnLimpar
            // 
            this.BtnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLimpar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BtnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnLimpar.ForeColor = System.Drawing.Color.DimGray;
            this.BtnLimpar.Location = new System.Drawing.Point(18, 744);
            this.BtnLimpar.Name = "BtnLimpar";
            this.BtnLimpar.Size = new System.Drawing.Size(129, 57);
            this.BtnLimpar.TabIndex = 41;
            this.BtnLimpar.Text = "LIMPAR";
            this.BtnLimpar.UseVisualStyleBackColor = false;
            this.BtnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(18, 608);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(511, 109);
            this.richTextBox1.TabIndex = 40;
            this.richTextBox1.Text = "";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(7, 578);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 16);
            this.label20.TabIndex = 39;
            this.label20.Text = "Observações:";
            // 
            // txtEnderecoDestino
            // 
            this.txtEnderecoDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnderecoDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnderecoDestino.Location = new System.Drawing.Point(264, 545);
            this.txtEnderecoDestino.Name = "txtEnderecoDestino";
            this.txtEnderecoDestino.Size = new System.Drawing.Size(265, 21);
            this.txtEnderecoDestino.TabIndex = 38;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(261, 526);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(138, 16);
            this.label19.TabIndex = 37;
            this.label19.Text = "Endereço do Destino:";
            // 
            // txtEnderecoOrigem
            // 
            this.txtEnderecoOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnderecoOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnderecoOrigem.Location = new System.Drawing.Point(264, 497);
            this.txtEnderecoOrigem.Name = "txtEnderecoOrigem";
            this.txtEnderecoOrigem.Size = new System.Drawing.Size(265, 21);
            this.txtEnderecoOrigem.TabIndex = 36;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(261, 478);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(136, 16);
            this.label18.TabIndex = 35;
            this.label18.Text = "Endereço da Origem:";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(7, 524);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(132, 16);
            this.label17.TabIndex = 34;
            this.label17.Text = "Destino do Paciente:";
            // 
            // CbDestino
            // 
            this.CbDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbDestino.FormattingEnabled = true;
            this.CbDestino.Location = new System.Drawing.Point(10, 543);
            this.CbDestino.Name = "CbDestino";
            this.CbDestino.Size = new System.Drawing.Size(243, 23);
            this.CbDestino.TabIndex = 33;
            this.CbDestino.SelectedIndexChanged += new System.EventHandler(this.CbDestino_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(5, 476);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(130, 16);
            this.label16.TabIndex = 32;
            this.label16.Text = "Origem do Paciente:";
            // 
            // CbOrigem
            // 
            this.CbOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbOrigem.FormattingEnabled = true;
            this.CbOrigem.Location = new System.Drawing.Point(8, 495);
            this.CbOrigem.Name = "CbOrigem";
            this.CbOrigem.Size = new System.Drawing.Size(243, 23);
            this.CbOrigem.TabIndex = 31;
            this.CbOrigem.SelectedIndexChanged += new System.EventHandler(this.CbOrigem_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(5, 444);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(192, 18);
            this.label15.TabIndex = 30;
            this.label15.Text = "5. Dados do Transporte:";
            // 
            // CbAtendimentoPrioridade
            // 
            this.CbAtendimentoPrioridade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbAtendimentoPrioridade.AutoSize = true;
            this.CbAtendimentoPrioridade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbAtendimentoPrioridade.Location = new System.Drawing.Point(6, 408);
            this.CbAtendimentoPrioridade.Name = "CbAtendimentoPrioridade";
            this.CbAtendimentoPrioridade.Size = new System.Drawing.Size(197, 20);
            this.CbAtendimentoPrioridade.TabIndex = 29;
            this.CbAtendimentoPrioridade.Text = "Atendimento com Prioridade";
            this.CbAtendimentoPrioridade.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(261, 360);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(181, 16);
            this.label14.TabIndex = 28;
            this.label14.Text = "Tipo do Motivo Selecionado:";
            // 
            // CbTipoMotivoSelecionado
            // 
            this.CbTipoMotivoSelecionado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbTipoMotivoSelecionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbTipoMotivoSelecionado.FormattingEnabled = true;
            this.CbTipoMotivoSelecionado.Location = new System.Drawing.Point(264, 379);
            this.CbTipoMotivoSelecionado.Name = "CbTipoMotivoSelecionado";
            this.CbTipoMotivoSelecionado.Size = new System.Drawing.Size(243, 23);
            this.CbTipoMotivoSelecionado.TabIndex = 27;
            this.CbTipoMotivoSelecionado.SelectedIndexChanged += new System.EventHandler(this.CbTipoMotivoSelecionado_SelectedIndexChanged);
            this.CbTipoMotivoSelecionado.TextChanged += new System.EventHandler(this.CbTipoMotivoSelecionado_TextChanged);
            this.CbTipoMotivoSelecionado.Click += new System.EventHandler(this.CbTipoMotivoSelecionado_Click);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(5, 360);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 16);
            this.label13.TabIndex = 26;
            this.label13.Text = "Motivo do Chamado:";
            // 
            // CbMotivoChamado
            // 
            this.CbMotivoChamado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbMotivoChamado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbMotivoChamado.FormattingEnabled = true;
            this.CbMotivoChamado.Items.AddRange(new object[] {
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
            "TRANSPORTE DE PROFISSIONAIS"});
            this.CbMotivoChamado.Location = new System.Drawing.Point(8, 379);
            this.CbMotivoChamado.Name = "CbMotivoChamado";
            this.CbMotivoChamado.Size = new System.Drawing.Size(243, 23);
            this.CbMotivoChamado.TabIndex = 25;
            this.CbMotivoChamado.SelectedIndexChanged += new System.EventHandler(this.CbMotivoChamado_SelectedIndexChanged);
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiagnostico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiagnostico.Location = new System.Drawing.Point(6, 326);
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(522, 21);
            this.txtDiagnostico.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 307);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(183, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "Diagnóstico/Queixa principal:";
            // 
            // txtIdade
            // 
            this.txtIdade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdade.Location = new System.Drawing.Point(445, 273);
            this.txtIdade.Name = "txtIdade";
            this.txtIdade.Size = new System.Drawing.Size(61, 20);
            this.txtIdade.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(442, 254);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 16);
            this.label11.TabIndex = 21;
            this.label11.Text = "Idade:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(290, 255);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Sexo:";
            // 
            // RbFemenino
            // 
            this.RbFemenino.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RbFemenino.AutoSize = true;
            this.RbFemenino.Location = new System.Drawing.Point(372, 274);
            this.RbFemenino.Name = "RbFemenino";
            this.RbFemenino.Size = new System.Drawing.Size(67, 17);
            this.RbFemenino.TabIndex = 19;
            this.RbFemenino.TabStop = true;
            this.RbFemenino.Text = "Feminino";
            this.RbFemenino.UseVisualStyleBackColor = true;
            // 
            // RbMasculino
            // 
            this.RbMasculino.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RbMasculino.AutoSize = true;
            this.RbMasculino.Location = new System.Drawing.Point(293, 274);
            this.RbMasculino.Name = "RbMasculino";
            this.RbMasculino.Size = new System.Drawing.Size(73, 17);
            this.RbMasculino.TabIndex = 18;
            this.RbMasculino.TabStop = true;
            this.RbMasculino.Text = "Masculino";
            this.RbMasculino.UseVisualStyleBackColor = true;
            // 
            // txtNomePaciente
            // 
            this.txtNomePaciente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomePaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomePaciente.Location = new System.Drawing.Point(6, 273);
            this.txtNomePaciente.Name = "txtNomePaciente";
            this.txtNomePaciente.Size = new System.Drawing.Size(265, 21);
            this.txtNomePaciente.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Nome do Paciente:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "4. Dados do paciente:";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefone.Location = new System.Drawing.Point(379, 178);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(127, 20);
            this.txtTelefone.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(376, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Telefone:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(159, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Local da Solicitação:";
            // 
            // CbLocalSolicita
            // 
            this.CbLocalSolicita.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbLocalSolicita.FormattingEnabled = true;
            this.CbLocalSolicita.Location = new System.Drawing.Point(162, 177);
            this.CbLocalSolicita.Name = "CbLocalSolicita";
            this.CbLocalSolicita.Size = new System.Drawing.Size(199, 21);
            this.CbLocalSolicita.TabIndex = 11;
            this.CbLocalSolicita.SelectedIndexChanged += new System.EventHandler(this.CbLocalSolicita_SelectedIndexChanged);
            this.CbLocalSolicita.TextChanged += new System.EventHandler(this.CbLocalSolicita_TextChanged);
            // 
            // txtNomeSolicitante
            // 
            this.txtNomeSolicitante.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeSolicitante.Location = new System.Drawing.Point(6, 177);
            this.txtNomeSolicitante.Name = "txtNomeSolicitante";
            this.txtNomeSolicitante.Size = new System.Drawing.Size(141, 20);
            this.txtNomeSolicitante.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nome:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "3. Dados do solicitante:";
            // 
            // txtAtendMarcado
            // 
            this.txtAtendMarcado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAtendMarcado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAtendMarcado.Location = new System.Drawing.Point(264, 78);
            this.txtAtendMarcado.Name = "txtAtendMarcado";
            this.txtAtendMarcado.Size = new System.Drawing.Size(164, 22);
            this.txtAtendMarcado.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(68, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Atendimento Marcado para:";
            // 
            // Btnagendasim
            // 
            this.Btnagendasim.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btnagendasim.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Btnagendasim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnagendasim.ForeColor = System.Drawing.Color.DimGray;
            this.Btnagendasim.Location = new System.Drawing.Point(460, 43);
            this.Btnagendasim.Name = "Btnagendasim";
            this.Btnagendasim.Size = new System.Drawing.Size(82, 23);
            this.Btnagendasim.TabIndex = 5;
            this.Btnagendasim.Text = "Sim";
            this.Btnagendasim.UseVisualStyleBackColor = false;
            this.Btnagendasim.Click += new System.EventHandler(this.Btnagendasim_Click);
            // 
            // Btnagendanao
            // 
            this.Btnagendanao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btnagendanao.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Btnagendanao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnagendanao.ForeColor = System.Drawing.Color.DimGray;
            this.Btnagendanao.Location = new System.Drawing.Point(379, 43);
            this.Btnagendanao.Name = "Btnagendanao";
            this.Btnagendanao.Size = new System.Drawing.Size(75, 23);
            this.Btnagendanao.TabIndex = 4;
            this.Btnagendanao.Text = "Não";
            this.Btnagendanao.UseVisualStyleBackColor = false;
            this.Btnagendanao.Click += new System.EventHandler(this.Btnagendanao_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(376, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "2. Necessita agendar o horario do atendimento ?";
            // 
            // ConfirmaSolicitacao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(594, 741);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "ConfirmaSolicitacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova Solicitação";
            this.Load += new System.EventHandler(this.NovaSolicitacao_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnBasica;
        private System.Windows.Forms.Button BtnAvancada;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNomeSolicitante;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAtendMarcado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btnagendasim;
        private System.Windows.Forms.Button Btnagendanao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RbFemenino;
        private System.Windows.Forms.RadioButton RbMasculino;
        private System.Windows.Forms.TextBox txtNomePaciente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CbLocalSolicita;
        private System.Windows.Forms.CheckBox CbAtendimentoPrioridade;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox CbTipoMotivoSelecionado;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox CbMotivoChamado;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIdade;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtEnderecoDestino;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtEnderecoOrigem;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox CbDestino;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox CbOrigem;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnLimpar;
    }
}