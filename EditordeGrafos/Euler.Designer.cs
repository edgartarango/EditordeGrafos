﻿namespace EditordeGrafos
{
    partial class Euler
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
            this.CamOCirc = new System.Windows.Forms.TextBox();
            this.lbl_CamCir = new System.Windows.Forms.Label();
            this.MuestraRaiz_Euler = new System.Windows.Forms.TextBox();
            this.Res_Euler = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EulerButton = new System.Windows.Forms.Button();
            this.lblRaiz_Euler = new System.Windows.Forms.Label();
            this.Titulo_Euler = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CamOCirc
            // 
            this.CamOCirc.Location = new System.Drawing.Point(400, 392);
            this.CamOCirc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CamOCirc.Name = "CamOCirc";
            this.CamOCirc.Size = new System.Drawing.Size(165, 26);
            this.CamOCirc.TabIndex = 28;
            // 
            // lbl_CamCir
            // 
            this.lbl_CamCir.AutoSize = true;
            this.lbl_CamCir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CamCir.Location = new System.Drawing.Point(151, 388);
            this.lbl_CamCir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_CamCir.Name = "lbl_CamCir";
            this.lbl_CamCir.Size = new System.Drawing.Size(209, 29);
            this.lbl_CamCir.TabIndex = 27;
            this.lbl_CamCir.Text = "Camino O Circuito";
            // 
            // MuestraRaiz_Euler
            // 
            this.MuestraRaiz_Euler.Location = new System.Drawing.Point(400, 239);
            this.MuestraRaiz_Euler.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MuestraRaiz_Euler.Name = "MuestraRaiz_Euler";
            this.MuestraRaiz_Euler.Size = new System.Drawing.Size(79, 26);
            this.MuestraRaiz_Euler.TabIndex = 26;
            // 
            // Res_Euler
            // 
            this.Res_Euler.Location = new System.Drawing.Point(384, 335);
            this.Res_Euler.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Res_Euler.Multiline = true;
            this.Res_Euler.Name = "Res_Euler";
            this.Res_Euler.Size = new System.Drawing.Size(303, 26);
            this.Res_Euler.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(437, 301);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 29);
            this.label2.TabIndex = 24;
            this.label2.Text = "Resultado:";
            // 
            // EulerButton
            // 
            this.EulerButton.Location = new System.Drawing.Point(207, 335);
            this.EulerButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EulerButton.Name = "EulerButton";
            this.EulerButton.Size = new System.Drawing.Size(158, 29);
            this.EulerButton.TabIndex = 23;
            this.EulerButton.Text = "Euler";
            this.EulerButton.UseVisualStyleBackColor = true;
            this.EulerButton.Click += new System.EventHandler(this.EulerButton_Click);
            // 
            // lblRaiz_Euler
            // 
            this.lblRaiz_Euler.AutoSize = true;
            this.lblRaiz_Euler.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaiz_Euler.Location = new System.Drawing.Point(326, 235);
            this.lblRaiz_Euler.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRaiz_Euler.Name = "lblRaiz_Euler";
            this.lblRaiz_Euler.Size = new System.Drawing.Size(66, 29);
            this.lblRaiz_Euler.TabIndex = 22;
            this.lblRaiz_Euler.Text = "Raiz:";
            // 
            // Titulo_Euler
            // 
            this.Titulo_Euler.AutoSize = true;
            this.Titulo_Euler.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo_Euler.Location = new System.Drawing.Point(242, 63);
            this.Titulo_Euler.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Titulo_Euler.Name = "Titulo_Euler";
            this.Titulo_Euler.Size = new System.Drawing.Size(371, 33);
            this.Titulo_Euler.TabIndex = 21;
            this.Titulo_Euler.Text = "Caminos / Circuitos Euler";
            // 
            // PestanaEuler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 482);
            this.Controls.Add(this.CamOCirc);
            this.Controls.Add(this.lbl_CamCir);
            this.Controls.Add(this.MuestraRaiz_Euler);
            this.Controls.Add(this.Res_Euler);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EulerButton);
            this.Controls.Add(this.lblRaiz_Euler);
            this.Controls.Add(this.Titulo_Euler);
            this.Name = "PestanaEuler";
            this.Text = "Recorrido Euler ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CamOCirc;
        private System.Windows.Forms.Label lbl_CamCir;
        private System.Windows.Forms.TextBox MuestraRaiz_Euler;
        private System.Windows.Forms.TextBox Res_Euler;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button EulerButton;
        private System.Windows.Forms.Label lblRaiz_Euler;
        private System.Windows.Forms.Label Titulo_Euler;
    }
}