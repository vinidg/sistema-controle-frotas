namespace Sistema_Controle
{
    partial class NegarReagendamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NegarReagendamento));
            this.panel1 = new System.Windows.Forms.Panel();
            this.La = new System.Windows.Forms.Label();
            this.Motivo = new System.Windows.Forms.RichTextBox();
            this.Aceitar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.La);
            this.panel1.Controls.Add(this.Motivo);
            this.panel1.Controls.Add(this.Aceitar);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 320);
            this.panel1.TabIndex = 0;
            // 
            // La
            // 
            this.La.AutoSize = true;
            this.La.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.La.Location = new System.Drawing.Point(98, 16);
            this.La.Name = "La";
            this.La.Size = new System.Drawing.Size(187, 24);
            this.La.TabIndex = 100;
            this.La.Text = "Motivo da Negativa";
            // 
            // Motivo
            // 
            this.Motivo.Location = new System.Drawing.Point(15, 54);
            this.Motivo.Name = "Motivo";
            this.Motivo.Size = new System.Drawing.Size(365, 188);
            this.Motivo.TabIndex = 99;
            this.Motivo.Text = "";
            this.Motivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Motivo_KeyPress);
            // 
            // Aceitar
            // 
            this.Aceitar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Aceitar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Aceitar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Aceitar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Aceitar.Location = new System.Drawing.Point(124, 260);
            this.Aceitar.Name = "Aceitar";
            this.Aceitar.Size = new System.Drawing.Size(144, 46);
            this.Aceitar.TabIndex = 98;
            this.Aceitar.Text = "Aceitar";
            this.Aceitar.UseVisualStyleBackColor = false;
            this.Aceitar.Click += new System.EventHandler(this.Aceitar_Click);
            // 
            // NegarReagendamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(224)))), ((int)(((byte)(173)))));
            this.ClientSize = new System.Drawing.Size(423, 344);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NegarReagendamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NegarReagendamento";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label La;
        private System.Windows.Forms.RichTextBox Motivo;
        private System.Windows.Forms.Button Aceitar;
    }
}