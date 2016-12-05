namespace Sistema_Controle
{
    partial class OpcoesImprimir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpcoesImprimir));
            this.chklst = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AjustePorPagina = new System.Windows.Forms.CheckBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.titulo = new System.Windows.Forms.TextBox();
            this.gboxRowsToPrint = new System.Windows.Forms.GroupBox();
            this.SelecionarLinhas = new System.Windows.Forms.RadioButton();
            this.TodasLinhas = new System.Windows.Forms.RadioButton();
            this.ok = new System.Windows.Forms.Button();
            this.gboxRowsToPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // chklst
            // 
            this.chklst.FormattingEnabled = true;
            this.chklst.Location = new System.Drawing.Point(12, 25);
            this.chklst.Name = "chklst";
            this.chklst.Size = new System.Drawing.Size(182, 289);
            this.chklst.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Colunas para Imprimir";
            // 
            // AjustePorPagina
            // 
            this.AjustePorPagina.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AjustePorPagina.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AjustePorPagina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AjustePorPagina.Location = new System.Drawing.Point(203, 94);
            this.AjustePorPagina.Name = "AjustePorPagina";
            this.AjustePorPagina.Size = new System.Drawing.Size(173, 26);
            this.AjustePorPagina.TabIndex = 27;
            this.AjustePorPagina.Text = "Ajustar para o tamanho da pagina";
            this.AjustePorPagina.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(200, 144);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(119, 13);
            this.lblTitle.TabIndex = 26;
            this.lblTitle.Text = "Título da impressão";
            // 
            // titulo
            // 
            this.titulo.AcceptsReturn = true;
            this.titulo.Location = new System.Drawing.Point(200, 161);
            this.titulo.Multiline = true;
            this.titulo.Name = "titulo";
            this.titulo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.titulo.Size = new System.Drawing.Size(176, 77);
            this.titulo.TabIndex = 25;
            // 
            // gboxRowsToPrint
            // 
            this.gboxRowsToPrint.Controls.Add(this.SelecionarLinhas);
            this.gboxRowsToPrint.Controls.Add(this.TodasLinhas);
            this.gboxRowsToPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxRowsToPrint.Location = new System.Drawing.Point(200, 25);
            this.gboxRowsToPrint.Name = "gboxRowsToPrint";
            this.gboxRowsToPrint.Size = new System.Drawing.Size(185, 51);
            this.gboxRowsToPrint.TabIndex = 24;
            this.gboxRowsToPrint.TabStop = false;
            this.gboxRowsToPrint.Text = "Linhas para impressão";
            // 
            // SelecionarLinhas
            // 
            this.SelecionarLinhas.AutoSize = true;
            this.SelecionarLinhas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelecionarLinhas.Location = new System.Drawing.Point(91, 19);
            this.SelecionarLinhas.Name = "SelecionarLinhas";
            this.SelecionarLinhas.Size = new System.Drawing.Size(85, 17);
            this.SelecionarLinhas.TabIndex = 1;
            this.SelecionarLinhas.TabStop = true;
            this.SelecionarLinhas.Text = "Selecionar";
            this.SelecionarLinhas.UseVisualStyleBackColor = true;
            // 
            // TodasLinhas
            // 
            this.TodasLinhas.AutoSize = true;
            this.TodasLinhas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodasLinhas.Location = new System.Drawing.Point(9, 19);
            this.TodasLinhas.Name = "TodasLinhas";
            this.TodasLinhas.Size = new System.Drawing.Size(60, 17);
            this.TodasLinhas.TabIndex = 0;
            this.TodasLinhas.TabStop = true;
            this.TodasLinhas.Text = "Todas";
            this.TodasLinhas.UseVisualStyleBackColor = true;
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(173)))), ((int)(((byte)(168)))));
            this.ok.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ok.Location = new System.Drawing.Point(318, 289);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(67, 26);
            this.ok.TabIndex = 28;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // OpcoesImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(224)))), ((int)(((byte)(173)))));
            this.ClientSize = new System.Drawing.Size(397, 327);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.AjustePorPagina);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.gboxRowsToPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chklst);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OpcoesImprimir";
            this.Text = "Opções Imprimir";
            this.Load += new System.EventHandler(this.OpcoesImprimir_Load);
            this.gboxRowsToPrint.ResumeLayout(false);
            this.gboxRowsToPrint.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chklst;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.CheckBox AjustePorPagina;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.TextBox titulo;
        internal System.Windows.Forms.GroupBox gboxRowsToPrint;
        internal System.Windows.Forms.RadioButton SelecionarLinhas;
        internal System.Windows.Forms.RadioButton TodasLinhas;
        private System.Windows.Forms.Button ok;
    }
}