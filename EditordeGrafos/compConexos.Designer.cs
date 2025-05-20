namespace EditordeGrafos
{
    partial class compConexos
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
            this.Titulo_Conexos = new System.Windows.Forms.Label();
            this.lblRaiz_conexos = new System.Windows.Forms.Label();
            this.Res_conexos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConexosButton = new System.Windows.Forms.Button();
            this.MuestraRaiz = new System.Windows.Forms.TextBox();
            this.lbl_articulaciones = new System.Windows.Forms.Label();
            this.textBoxArt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Titulo_Conexos
            // 
            this.Titulo_Conexos.AutoSize = true;
            this.Titulo_Conexos.Font = new System.Drawing.Font("MS Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo_Conexos.Location = new System.Drawing.Point(38, 27);
            this.Titulo_Conexos.Name = "Titulo_Conexos";
            this.Titulo_Conexos.Size = new System.Drawing.Size(218, 19);
            this.Titulo_Conexos.TabIndex = 10;
            this.Titulo_Conexos.Text = "Componentes Conexos";
            // 
            // lblRaiz_conexos
            // 
            this.lblRaiz_conexos.AutoSize = true;
            this.lblRaiz_conexos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaiz_conexos.Location = new System.Drawing.Point(30, 63);
            this.lblRaiz_conexos.Name = "lblRaiz_conexos";
            this.lblRaiz_conexos.Size = new System.Drawing.Size(42, 18);
            this.lblRaiz_conexos.TabIndex = 13;
            this.lblRaiz_conexos.Text = "Raiz:";
            // 
            // Res_conexos
            // 
            this.Res_conexos.Location = new System.Drawing.Point(33, 119);
            this.Res_conexos.Multiline = true;
            this.Res_conexos.Name = "Res_conexos";
            this.Res_conexos.Size = new System.Drawing.Size(216, 80);
            this.Res_conexos.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Resultado:";
            // 
            // ConexosButton
            // 
            this.ConexosButton.Location = new System.Drawing.Point(144, 62);
            this.ConexosButton.Name = "ConexosButton";
            this.ConexosButton.Size = new System.Drawing.Size(105, 19);
            this.ConexosButton.TabIndex = 15;
            this.ConexosButton.Text = "Conexos";
            this.ConexosButton.UseVisualStyleBackColor = true;
            this.ConexosButton.Click += new System.EventHandler(this.ConexosButton_Click);
            // 
            // MuestraRaiz
            // 
            this.MuestraRaiz.Location = new System.Drawing.Point(78, 64);
            this.MuestraRaiz.Name = "MuestraRaiz";
            this.MuestraRaiz.Size = new System.Drawing.Size(54, 20);
            this.MuestraRaiz.TabIndex = 18;
            // 
            // lbl_articulaciones
            // 
            this.lbl_articulaciones.AutoSize = true;
            this.lbl_articulaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_articulaciones.Location = new System.Drawing.Point(30, 221);
            this.lbl_articulaciones.Name = "lbl_articulaciones";
            this.lbl_articulaciones.Size = new System.Drawing.Size(153, 18);
            this.lbl_articulaciones.TabIndex = 19;
            this.lbl_articulaciones.Text = "Nodos Articulaciones:";
            // 
            // textBoxArt
            // 
            this.textBoxArt.Location = new System.Drawing.Point(189, 222);
            this.textBoxArt.Name = "textBoxArt";
            this.textBoxArt.Size = new System.Drawing.Size(111, 20);
            this.textBoxArt.TabIndex = 20;
            // 
            // compConexos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 283);
            this.Controls.Add(this.textBoxArt);
            this.Controls.Add(this.lbl_articulaciones);
            this.Controls.Add(this.MuestraRaiz);
            this.Controls.Add(this.Res_conexos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ConexosButton);
            this.Controls.Add(this.lblRaiz_conexos);
            this.Controls.Add(this.Titulo_Conexos);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "compConexos";
            this.Text = "Componentes Conexos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titulo_Conexos;
        private System.Windows.Forms.Label lblRaiz_conexos;
        private System.Windows.Forms.TextBox Res_conexos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ConexosButton;
        private System.Windows.Forms.TextBox MuestraRaiz;
        private System.Windows.Forms.Label lbl_articulaciones;
        private System.Windows.Forms.TextBox textBoxArt;
    }
}