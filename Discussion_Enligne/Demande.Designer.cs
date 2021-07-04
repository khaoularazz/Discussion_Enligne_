
namespace Discussion_Enligne
{
    partial class Demande
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
            this.btnparticiper = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtpseudo = new System.Windows.Forms.TextBox();
            this.pseudo_validation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnparticiper
            // 
            this.btnparticiper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(57)))), ((int)(((byte)(83)))));
            this.btnparticiper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnparticiper.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnparticiper.Location = new System.Drawing.Point(213, 97);
            this.btnparticiper.Name = "btnparticiper";
            this.btnparticiper.Size = new System.Drawing.Size(95, 27);
            this.btnparticiper.TabIndex = 0;
            this.btnparticiper.Text = "Participer";
            this.btnparticiper.UseVisualStyleBackColor = false;
            this.btnparticiper.Click += new System.EventHandler(this.btnparticiper_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(57)))), ((int)(((byte)(83)))));
            this.label1.Location = new System.Drawing.Point(41, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = " Pseudo Name  :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtpseudo
            // 
            this.txtpseudo.Location = new System.Drawing.Point(213, 45);
            this.txtpseudo.Name = "txtpseudo";
            this.txtpseudo.Size = new System.Drawing.Size(189, 20);
            this.txtpseudo.TabIndex = 2;
            // 
            // pseudo_validation
            // 
            this.pseudo_validation.AutoSize = true;
            this.pseudo_validation.ForeColor = System.Drawing.Color.Red;
            this.pseudo_validation.Location = new System.Drawing.Point(213, 78);
            this.pseudo_validation.Name = "pseudo_validation";
            this.pseudo_validation.Size = new System.Drawing.Size(0, 13);
            this.pseudo_validation.TabIndex = 3;
            // 
            // Demande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(435, 150);
            this.Controls.Add(this.pseudo_validation);
            this.Controls.Add(this.txtpseudo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnparticiper);
            this.Name = "Demande";
            this.Text = "Demande";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnparticiper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpseudo;
        private System.Windows.Forms.Label pseudo_validation;
    }
}