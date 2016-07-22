namespace WindowsFormsApplication2
{
    partial class Status
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Status));
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAddPaciente = new System.Windows.Forms.Button();
            this.BtnBloqueio = new System.Windows.Forms.Button();
            this.BtnTroca = new System.Windows.Forms.Button();
            this.BtTrocar = new System.Windows.Forms.Button();
            this.txtEquipe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMoto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Paineltrocar = new System.Windows.Forms.Panel();
            this.PainelBloqueio = new System.Windows.Forms.Panel();
            this.CbMotivoBloqueio = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResposavel = new System.Windows.Forms.TextBox();
            this.BtnBloquear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDtHorasBloqueio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnDesbloquear = new System.Windows.Forms.Button();
            this.PainelHistorico = new System.Windows.Forms.Panel();
            this.painel5 = new System.Windows.Forms.Panel();
            this.painel4 = new System.Windows.Forms.Panel();
            this.painel3 = new System.Windows.Forms.Panel();
            this.painel2 = new System.Windows.Forms.Panel();
            this.painel1 = new System.Windows.Forms.Panel();
            this.BtnOrigem = new System.Windows.Forms.Button();
            this.txtAlterador6 = new System.Windows.Forms.TextBox();
            this.txtHora6 = new System.Windows.Forms.TextBox();
            this.BtnPatio = new System.Windows.Forms.Button();
            this.txtAlterador5 = new System.Windows.Forms.TextBox();
            this.txtHora5 = new System.Windows.Forms.TextBox();
            this.EquipeLiberada = new System.Windows.Forms.Button();
            this.txtAlterador4 = new System.Windows.Forms.TextBox();
            this.txtHora4 = new System.Windows.Forms.TextBox();
            this.BtnEquipeDestino = new System.Windows.Forms.Button();
            this.txtAlterador3 = new System.Windows.Forms.TextBox();
            this.txtHora3 = new System.Windows.Forms.TextBox();
            this.BtnSaiuOrigem = new System.Windows.Forms.Button();
            this.txtAlterador2 = new System.Windows.Forms.TextBox();
            this.txtHora2 = new System.Windows.Forms.TextBox();
            this.txtAlterador = new System.Windows.Forms.TextBox();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.BtnEquipeCiente = new System.Windows.Forms.Button();
            this.Origem = new System.Windows.Forms.Label();
            this.Destino = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.painelCentral = new System.Windows.Forms.Panel();
            this.equipeView = new System.Windows.Forms.DataGridView();
            this.ListadePacientes = new System.Windows.Forms.DataGridView();
            this.Paineltrocar.SuspendLayout();
            this.PainelBloqueio.SuspendLayout();
            this.PainelHistorico.SuspendLayout();
            this.painelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListadePacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1215, 55);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnAddPaciente
            // 
            this.BtnAddPaciente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnAddPaciente.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnAddPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddPaciente.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnAddPaciente.Location = new System.Drawing.Point(899, 338);
            this.BtnAddPaciente.Name = "BtnAddPaciente";
            this.BtnAddPaciente.Size = new System.Drawing.Size(306, 214);
            this.BtnAddPaciente.TabIndex = 1;
            this.BtnAddPaciente.Text = "Adicionar Paciente";
            this.BtnAddPaciente.UseVisualStyleBackColor = false;
            this.BtnAddPaciente.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnBloqueio
            // 
            this.BtnBloqueio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnBloqueio.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnBloqueio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBloqueio.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnBloqueio.Location = new System.Drawing.Point(899, 45);
            this.BtnBloqueio.Name = "BtnBloqueio";
            this.BtnBloqueio.Size = new System.Drawing.Size(306, 214);
            this.BtnBloqueio.TabIndex = 2;
            this.BtnBloqueio.Text = "Bloquear Ambulância";
            this.BtnBloqueio.UseVisualStyleBackColor = false;
            this.BtnBloqueio.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnTroca
            // 
            this.BtnTroca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnTroca.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnTroca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTroca.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnTroca.Location = new System.Drawing.Point(71, 108);
            this.BtnTroca.Name = "BtnTroca";
            this.BtnTroca.Size = new System.Drawing.Size(108, 29);
            this.BtnTroca.TabIndex = 4;
            this.BtnTroca.Text = "Trocar Equipe";
            this.BtnTroca.UseVisualStyleBackColor = false;
            this.BtnTroca.Click += new System.EventHandler(this.BtnTroca_Click);
            // 
            // BtTrocar
            // 
            this.BtTrocar.BackColor = System.Drawing.Color.Yellow;
            this.BtTrocar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtTrocar.ForeColor = System.Drawing.Color.Black;
            this.BtTrocar.Location = new System.Drawing.Point(14, 159);
            this.BtTrocar.Name = "BtTrocar";
            this.BtTrocar.Size = new System.Drawing.Size(358, 43);
            this.BtTrocar.TabIndex = 9;
            this.BtTrocar.Text = "Trocar";
            this.BtTrocar.UseVisualStyleBackColor = false;
            this.BtTrocar.Click += new System.EventHandler(this.BtTrocar_Click);
            // 
            // txtEquipe
            // 
            this.txtEquipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipe.Location = new System.Drawing.Point(14, 125);
            this.txtEquipe.Name = "txtEquipe";
            this.txtEquipe.Size = new System.Drawing.Size(358, 22);
            this.txtEquipe.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(14, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Equipe de Enfermagem:";
            // 
            // txtMoto
            // 
            this.txtMoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoto.Location = new System.Drawing.Point(14, 53);
            this.txtMoto.Name = "txtMoto";
            this.txtMoto.Size = new System.Drawing.Size(358, 22);
            this.txtMoto.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(14, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Motorista:";
            // 
            // Paineltrocar
            // 
            this.Paineltrocar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Paineltrocar.Controls.Add(this.txtEquipe);
            this.Paineltrocar.Controls.Add(this.BtTrocar);
            this.Paineltrocar.Controls.Add(this.label3);
            this.Paineltrocar.Controls.Add(this.txtMoto);
            this.Paineltrocar.Controls.Add(this.label2);
            this.Paineltrocar.Location = new System.Drawing.Point(7, 14);
            this.Paineltrocar.Name = "Paineltrocar";
            this.Paineltrocar.Size = new System.Drawing.Size(397, 217);
            this.Paineltrocar.TabIndex = 10;
            this.Paineltrocar.Visible = false;
            // 
            // PainelBloqueio
            // 
            this.PainelBloqueio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PainelBloqueio.Controls.Add(this.CbMotivoBloqueio);
            this.PainelBloqueio.Controls.Add(this.label6);
            this.PainelBloqueio.Controls.Add(this.txtResposavel);
            this.PainelBloqueio.Controls.Add(this.BtnBloquear);
            this.PainelBloqueio.Controls.Add(this.label4);
            this.PainelBloqueio.Controls.Add(this.txtDtHorasBloqueio);
            this.PainelBloqueio.Controls.Add(this.label5);
            this.PainelBloqueio.Location = new System.Drawing.Point(832, 45);
            this.PainelBloqueio.Name = "PainelBloqueio";
            this.PainelBloqueio.Size = new System.Drawing.Size(382, 216);
            this.PainelBloqueio.TabIndex = 11;
            this.PainelBloqueio.Visible = false;
            // 
            // CbMotivoBloqueio
            // 
            this.CbMotivoBloqueio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbMotivoBloqueio.FormattingEnabled = true;
            this.CbMotivoBloqueio.Items.AddRange(new object[] {
            " ",
            "Intervalo para Almoço",
            "Terminal de Higenização",
            "Ambulância Quebrada",
            "Não Pertence ao Plantão",
            "Enfermagem Ausente",
            "Motorista Ausente",
            "Ambulância Ausente",
            "Outro Motivo"});
            this.CbMotivoBloqueio.Location = new System.Drawing.Point(17, 53);
            this.CbMotivoBloqueio.Name = "CbMotivoBloqueio";
            this.CbMotivoBloqueio.Size = new System.Drawing.Size(355, 24);
            this.CbMotivoBloqueio.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(14, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Motivo:";
            // 
            // txtResposavel
            // 
            this.txtResposavel.Enabled = false;
            this.txtResposavel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResposavel.Location = new System.Drawing.Point(17, 125);
            this.txtResposavel.Name = "txtResposavel";
            this.txtResposavel.Size = new System.Drawing.Size(184, 22);
            this.txtResposavel.TabIndex = 8;
            // 
            // BtnBloquear
            // 
            this.BtnBloquear.BackColor = System.Drawing.Color.Yellow;
            this.BtnBloquear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBloquear.ForeColor = System.Drawing.Color.Black;
            this.BtnBloquear.Location = new System.Drawing.Point(17, 158);
            this.BtnBloquear.Name = "BtnBloquear";
            this.BtnBloquear.Size = new System.Drawing.Size(358, 43);
            this.BtnBloquear.TabIndex = 9;
            this.BtnBloquear.Text = "Bloquear";
            this.BtnBloquear.UseVisualStyleBackColor = false;
            this.BtnBloquear.Click += new System.EventHandler(this.BtnBloquear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(14, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Responsável Ciente:";
            // 
            // txtDtHorasBloqueio
            // 
            this.txtDtHorasBloqueio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDtHorasBloqueio.Location = new System.Drawing.Point(222, 125);
            this.txtDtHorasBloqueio.Name = "txtDtHorasBloqueio";
            this.txtDtHorasBloqueio.Size = new System.Drawing.Size(150, 22);
            this.txtDtHorasBloqueio.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(219, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Data/Hora do Bloqueio:";
            // 
            // BtnDesbloquear
            // 
            this.BtnDesbloquear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnDesbloquear.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnDesbloquear.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDesbloquear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnDesbloquear.Location = new System.Drawing.Point(383, 264);
            this.BtnDesbloquear.Name = "BtnDesbloquear";
            this.BtnDesbloquear.Size = new System.Drawing.Size(451, 109);
            this.BtnDesbloquear.TabIndex = 12;
            this.BtnDesbloquear.Text = "Desbloquear";
            this.BtnDesbloquear.UseVisualStyleBackColor = false;
            this.BtnDesbloquear.Visible = false;
            this.BtnDesbloquear.Click += new System.EventHandler(this.BtnDesbloquear_Click);
            // 
            // PainelHistorico
            // 
            this.PainelHistorico.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PainelHistorico.BackColor = System.Drawing.Color.White;
            this.PainelHistorico.Controls.Add(this.painel5);
            this.PainelHistorico.Controls.Add(this.painel4);
            this.PainelHistorico.Controls.Add(this.painel3);
            this.PainelHistorico.Controls.Add(this.painel2);
            this.PainelHistorico.Controls.Add(this.painel1);
            this.PainelHistorico.Controls.Add(this.BtnOrigem);
            this.PainelHistorico.Controls.Add(this.txtAlterador6);
            this.PainelHistorico.Controls.Add(this.txtHora6);
            this.PainelHistorico.Controls.Add(this.BtnPatio);
            this.PainelHistorico.Controls.Add(this.txtAlterador5);
            this.PainelHistorico.Controls.Add(this.txtHora5);
            this.PainelHistorico.Controls.Add(this.EquipeLiberada);
            this.PainelHistorico.Controls.Add(this.txtAlterador4);
            this.PainelHistorico.Controls.Add(this.txtHora4);
            this.PainelHistorico.Controls.Add(this.BtnEquipeDestino);
            this.PainelHistorico.Controls.Add(this.txtAlterador3);
            this.PainelHistorico.Controls.Add(this.txtHora3);
            this.PainelHistorico.Controls.Add(this.BtnSaiuOrigem);
            this.PainelHistorico.Controls.Add(this.txtAlterador2);
            this.PainelHistorico.Controls.Add(this.txtHora2);
            this.PainelHistorico.Controls.Add(this.txtAlterador);
            this.PainelHistorico.Controls.Add(this.txtHora);
            this.PainelHistorico.Controls.Add(this.BtnEquipeCiente);
            this.PainelHistorico.Location = new System.Drawing.Point(71, 444);
            this.PainelHistorico.Name = "PainelHistorico";
            this.PainelHistorico.Size = new System.Drawing.Size(1064, 159);
            this.PainelHistorico.TabIndex = 13;
            this.PainelHistorico.Visible = false;
            // 
            // painel5
            // 
            this.painel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.painel5.BackColor = System.Drawing.Color.White;
            this.painel5.Location = new System.Drawing.Point(838, 4);
            this.painel5.Name = "painel5";
            this.painel5.Size = new System.Drawing.Size(144, 159);
            this.painel5.TabIndex = 22;
            // 
            // painel4
            // 
            this.painel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.painel4.BackColor = System.Drawing.Color.White;
            this.painel4.Location = new System.Drawing.Point(689, 4);
            this.painel4.Name = "painel4";
            this.painel4.Size = new System.Drawing.Size(144, 159);
            this.painel4.TabIndex = 21;
            // 
            // painel3
            // 
            this.painel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.painel3.BackColor = System.Drawing.Color.White;
            this.painel3.Location = new System.Drawing.Point(539, 4);
            this.painel3.Name = "painel3";
            this.painel3.Size = new System.Drawing.Size(144, 159);
            this.painel3.TabIndex = 20;
            // 
            // painel2
            // 
            this.painel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.painel2.BackColor = System.Drawing.Color.White;
            this.painel2.Location = new System.Drawing.Point(391, 4);
            this.painel2.Name = "painel2";
            this.painel2.Size = new System.Drawing.Size(142, 159);
            this.painel2.TabIndex = 19;
            // 
            // painel1
            // 
            this.painel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.painel1.BackColor = System.Drawing.Color.White;
            this.painel1.Location = new System.Drawing.Point(242, 4);
            this.painel1.Name = "painel1";
            this.painel1.Size = new System.Drawing.Size(142, 159);
            this.painel1.TabIndex = 18;
            // 
            // BtnOrigem
            // 
            this.BtnOrigem.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOrigem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnOrigem.Location = new System.Drawing.Point(241, 23);
            this.BtnOrigem.Name = "BtnOrigem";
            this.BtnOrigem.Size = new System.Drawing.Size(143, 68);
            this.BtnOrigem.TabIndex = 3;
            this.BtnOrigem.Text = "Equipe na Origem";
            this.BtnOrigem.UseVisualStyleBackColor = false;
            this.BtnOrigem.Click += new System.EventHandler(this.BtnOrigem_Click);
            // 
            // txtAlterador6
            // 
            this.txtAlterador6.Enabled = false;
            this.txtAlterador6.Location = new System.Drawing.Point(838, 123);
            this.txtAlterador6.Name = "txtAlterador6";
            this.txtAlterador6.Size = new System.Drawing.Size(142, 20);
            this.txtAlterador6.TabIndex = 17;
            // 
            // txtHora6
            // 
            this.txtHora6.Enabled = false;
            this.txtHora6.Location = new System.Drawing.Point(838, 97);
            this.txtHora6.Name = "txtHora6";
            this.txtHora6.Size = new System.Drawing.Size(142, 20);
            this.txtHora6.TabIndex = 16;
            // 
            // BtnPatio
            // 
            this.BtnPatio.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnPatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPatio.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnPatio.Location = new System.Drawing.Point(837, 23);
            this.BtnPatio.Name = "BtnPatio";
            this.BtnPatio.Size = new System.Drawing.Size(143, 68);
            this.BtnPatio.TabIndex = 15;
            this.BtnPatio.Text = "Equipe no Pátio";
            this.BtnPatio.UseVisualStyleBackColor = false;
            this.BtnPatio.Click += new System.EventHandler(this.BtnPatio_Click);
            // 
            // txtAlterador5
            // 
            this.txtAlterador5.Enabled = false;
            this.txtAlterador5.Location = new System.Drawing.Point(689, 123);
            this.txtAlterador5.Name = "txtAlterador5";
            this.txtAlterador5.Size = new System.Drawing.Size(142, 20);
            this.txtAlterador5.TabIndex = 14;
            // 
            // txtHora5
            // 
            this.txtHora5.Enabled = false;
            this.txtHora5.Location = new System.Drawing.Point(689, 97);
            this.txtHora5.Name = "txtHora5";
            this.txtHora5.Size = new System.Drawing.Size(142, 20);
            this.txtHora5.TabIndex = 13;
            // 
            // EquipeLiberada
            // 
            this.EquipeLiberada.BackColor = System.Drawing.Color.LightSkyBlue;
            this.EquipeLiberada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipeLiberada.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.EquipeLiberada.Location = new System.Drawing.Point(688, 23);
            this.EquipeLiberada.Name = "EquipeLiberada";
            this.EquipeLiberada.Size = new System.Drawing.Size(143, 68);
            this.EquipeLiberada.TabIndex = 12;
            this.EquipeLiberada.Text = "Equipe Liberada do Destino";
            this.EquipeLiberada.UseVisualStyleBackColor = false;
            this.EquipeLiberada.Click += new System.EventHandler(this.EquipeLiberada_Click);
            // 
            // txtAlterador4
            // 
            this.txtAlterador4.Enabled = false;
            this.txtAlterador4.Location = new System.Drawing.Point(540, 123);
            this.txtAlterador4.Name = "txtAlterador4";
            this.txtAlterador4.Size = new System.Drawing.Size(142, 20);
            this.txtAlterador4.TabIndex = 11;
            // 
            // txtHora4
            // 
            this.txtHora4.Enabled = false;
            this.txtHora4.Location = new System.Drawing.Point(540, 97);
            this.txtHora4.Name = "txtHora4";
            this.txtHora4.Size = new System.Drawing.Size(142, 20);
            this.txtHora4.TabIndex = 10;
            // 
            // BtnEquipeDestino
            // 
            this.BtnEquipeDestino.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnEquipeDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEquipeDestino.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnEquipeDestino.Location = new System.Drawing.Point(539, 23);
            this.BtnEquipeDestino.Name = "BtnEquipeDestino";
            this.BtnEquipeDestino.Size = new System.Drawing.Size(143, 68);
            this.BtnEquipeDestino.TabIndex = 9;
            this.BtnEquipeDestino.Text = "Equipe no Destino";
            this.BtnEquipeDestino.UseVisualStyleBackColor = false;
            this.BtnEquipeDestino.Click += new System.EventHandler(this.BtnEquipeDestino_Click);
            // 
            // txtAlterador3
            // 
            this.txtAlterador3.Enabled = false;
            this.txtAlterador3.Location = new System.Drawing.Point(391, 123);
            this.txtAlterador3.Name = "txtAlterador3";
            this.txtAlterador3.Size = new System.Drawing.Size(142, 20);
            this.txtAlterador3.TabIndex = 8;
            // 
            // txtHora3
            // 
            this.txtHora3.Enabled = false;
            this.txtHora3.Location = new System.Drawing.Point(391, 97);
            this.txtHora3.Name = "txtHora3";
            this.txtHora3.Size = new System.Drawing.Size(142, 20);
            this.txtHora3.TabIndex = 7;
            // 
            // BtnSaiuOrigem
            // 
            this.BtnSaiuOrigem.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnSaiuOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaiuOrigem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnSaiuOrigem.Location = new System.Drawing.Point(390, 23);
            this.BtnSaiuOrigem.Name = "BtnSaiuOrigem";
            this.BtnSaiuOrigem.Size = new System.Drawing.Size(143, 68);
            this.BtnSaiuOrigem.TabIndex = 6;
            this.BtnSaiuOrigem.Text = "Equipe Saiu da Origem";
            this.BtnSaiuOrigem.UseVisualStyleBackColor = false;
            this.BtnSaiuOrigem.Click += new System.EventHandler(this.BtnSaiuOrigem_Click);
            // 
            // txtAlterador2
            // 
            this.txtAlterador2.Enabled = false;
            this.txtAlterador2.Location = new System.Drawing.Point(242, 123);
            this.txtAlterador2.Name = "txtAlterador2";
            this.txtAlterador2.Size = new System.Drawing.Size(142, 20);
            this.txtAlterador2.TabIndex = 5;
            // 
            // txtHora2
            // 
            this.txtHora2.Enabled = false;
            this.txtHora2.Location = new System.Drawing.Point(242, 97);
            this.txtHora2.Name = "txtHora2";
            this.txtHora2.Size = new System.Drawing.Size(142, 20);
            this.txtHora2.TabIndex = 4;
            // 
            // txtAlterador
            // 
            this.txtAlterador.Enabled = false;
            this.txtAlterador.Location = new System.Drawing.Point(93, 121);
            this.txtAlterador.Name = "txtAlterador";
            this.txtAlterador.Size = new System.Drawing.Size(142, 20);
            this.txtAlterador.TabIndex = 2;
            // 
            // txtHora
            // 
            this.txtHora.Enabled = false;
            this.txtHora.Location = new System.Drawing.Point(93, 95);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(142, 20);
            this.txtHora.TabIndex = 1;
            // 
            // BtnEquipeCiente
            // 
            this.BtnEquipeCiente.BackColor = System.Drawing.Color.MediumTurquoise;
            this.BtnEquipeCiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEquipeCiente.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnEquipeCiente.Location = new System.Drawing.Point(93, 21);
            this.BtnEquipeCiente.Name = "BtnEquipeCiente";
            this.BtnEquipeCiente.Size = new System.Drawing.Size(143, 68);
            this.BtnEquipeCiente.TabIndex = 0;
            this.BtnEquipeCiente.Text = "Equipe Ciente";
            this.BtnEquipeCiente.UseVisualStyleBackColor = false;
            this.BtnEquipeCiente.Click += new System.EventHandler(this.BtnEquipeCiente_Click);
            // 
            // Origem
            // 
            this.Origem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Origem.BackColor = System.Drawing.Color.Transparent;
            this.Origem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Origem.ForeColor = System.Drawing.Color.White;
            this.Origem.Location = new System.Drawing.Point(61, 397);
            this.Origem.Name = "Origem";
            this.Origem.Size = new System.Drawing.Size(477, 37);
            this.Origem.TabIndex = 14;
            this.Origem.Text = "Origem";
            this.Origem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Destino
            // 
            this.Destino.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Destino.BackColor = System.Drawing.Color.Transparent;
            this.Destino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Destino.ForeColor = System.Drawing.Color.White;
            this.Destino.Location = new System.Drawing.Point(650, 397);
            this.Destino.Name = "Destino";
            this.Destino.Size = new System.Drawing.Size(493, 37);
            this.Destino.TabIndex = 16;
            this.Destino.Text = "Destino";
            this.Destino.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(431, 397);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(354, 37);
            this.label8.TabIndex = 17;
            this.label8.Text = "Para";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1104, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 55);
            this.label7.TabIndex = 18;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // painelCentral
            // 
            this.painelCentral.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.painelCentral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.painelCentral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.painelCentral.Controls.Add(this.ListadePacientes);
            this.painelCentral.Controls.Add(this.PainelHistorico);
            this.painelCentral.Controls.Add(this.PainelBloqueio);
            this.painelCentral.Controls.Add(this.Paineltrocar);
            this.painelCentral.Controls.Add(this.BtnDesbloquear);
            this.painelCentral.Controls.Add(this.label8);
            this.painelCentral.Controls.Add(this.BtnTroca);
            this.painelCentral.Controls.Add(this.BtnBloqueio);
            this.painelCentral.Controls.Add(this.label1);
            this.painelCentral.Controls.Add(this.Origem);
            this.painelCentral.Controls.Add(this.label7);
            this.painelCentral.Controls.Add(this.BtnAddPaciente);
            this.painelCentral.Controls.Add(this.Destino);
            this.painelCentral.Controls.Add(this.equipeView);
            this.painelCentral.Location = new System.Drawing.Point(12, 12);
            this.painelCentral.Name = "painelCentral";
            this.painelCentral.Size = new System.Drawing.Size(1223, 610);
            this.painelCentral.TabIndex = 20;
            // 
            // equipeView
            // 
            this.equipeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equipeView.Location = new System.Drawing.Point(71, 22);
            this.equipeView.MultiSelect = false;
            this.equipeView.Name = "equipeView";
            this.equipeView.ReadOnly = true;
            this.equipeView.Size = new System.Drawing.Size(289, 80);
            this.equipeView.TabIndex = 20;
            // 
            // ListadePacientes
            // 
            this.ListadePacientes.BackgroundColor = System.Drawing.Color.DarkRed;
            this.ListadePacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListadePacientes.Location = new System.Drawing.Point(410, 38);
            this.ListadePacientes.Name = "ListadePacientes";
            this.ListadePacientes.Size = new System.Drawing.Size(416, 220);
            this.ListadePacientes.TabIndex = 21;
            // 
            // Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1253, 634);
            this.Controls.Add(this.painelCentral);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Status";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Disponível";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paineltrocar.ResumeLayout(false);
            this.Paineltrocar.PerformLayout();
            this.PainelBloqueio.ResumeLayout(false);
            this.PainelBloqueio.PerformLayout();
            this.PainelHistorico.ResumeLayout(false);
            this.PainelHistorico.PerformLayout();
            this.painelCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.equipeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListadePacientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAddPaciente;
        private System.Windows.Forms.Button BtnBloqueio;
        private System.Windows.Forms.Button BtnTroca;
        private System.Windows.Forms.Button BtTrocar;
        public System.Windows.Forms.TextBox txtEquipe;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtMoto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel Paineltrocar;
        private System.Windows.Forms.Panel PainelBloqueio;
        private System.Windows.Forms.ComboBox CbMotivoBloqueio;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtResposavel;
        private System.Windows.Forms.Button BtnBloquear;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtDtHorasBloqueio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnDesbloquear;
        private System.Windows.Forms.Panel PainelHistorico;
        private System.Windows.Forms.TextBox txtAlterador6;
        private System.Windows.Forms.TextBox txtHora6;
        private System.Windows.Forms.Button BtnPatio;
        private System.Windows.Forms.TextBox txtAlterador5;
        private System.Windows.Forms.TextBox txtHora5;
        private System.Windows.Forms.Button EquipeLiberada;
        private System.Windows.Forms.TextBox txtAlterador4;
        private System.Windows.Forms.TextBox txtHora4;
        private System.Windows.Forms.Button BtnEquipeDestino;
        private System.Windows.Forms.TextBox txtAlterador3;
        private System.Windows.Forms.TextBox txtHora3;
        private System.Windows.Forms.Button BtnSaiuOrigem;
        private System.Windows.Forms.TextBox txtAlterador2;
        private System.Windows.Forms.TextBox txtHora2;
        private System.Windows.Forms.Button BtnOrigem;
        private System.Windows.Forms.TextBox txtAlterador;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Button BtnEquipeCiente;
        private System.Windows.Forms.Label Origem;
        private System.Windows.Forms.Label Destino;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel painel5;
        private System.Windows.Forms.Panel painel4;
        private System.Windows.Forms.Panel painel3;
        private System.Windows.Forms.Panel painel2;
        private System.Windows.Forms.Panel painel1;
        private System.Windows.Forms.Panel painelCentral;
        private System.Windows.Forms.DataGridView equipeView;
        private System.Windows.Forms.DataGridView ListadePacientes;
    }
}