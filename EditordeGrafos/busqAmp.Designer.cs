namespace EditordeGrafos
{
    partial class busqAmp
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
            this.bfsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRaiz = new System.Windows.Forms.Label();
            this.RaizSelected = new System.Windows.Forms.ComboBox();
            this.Res_Recorrido = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bfsButton
            // 
            this.bfsButton.Location = new System.Drawing.Point(200, 40);
            this.bfsButton.Name = "bfsButton";
            this.bfsButton.Size = new System.Drawing.Size(105, 19);
            this.bfsButton.TabIndex = 0;
            this.bfsButton.Text = "Iniciar";
            this.bfsButton.UseVisualStyleBackColor = true;
            this.bfsButton.Click += new System.EventHandler(this.bfsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Resultado:";
            // 
            // lblRaiz
            // 
            this.lblRaiz.AutoSize = true;
            this.lblRaiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaiz.Location = new System.Drawing.Point(70, 15);
            this.lblRaiz.Name = "lblRaiz";
            this.lblRaiz.Size = new System.Drawing.Size(42, 18);
            this.lblRaiz.TabIndex = 4;
            this.lblRaiz.Text = "Raiz:";
            // 
            // RaizSelected
            // 
            this.RaizSelected.FormattingEnabled = true;
            this.RaizSelected.Location = new System.Drawing.Point(70, 40);
            this.RaizSelected.Name = "RaizSelected";
            this.RaizSelected.Size = new System.Drawing.Size(121, 21);
            this.RaizSelected.TabIndex = 6;
            // 
            // Res_Recorrido
            // 
            this.Res_Recorrido.Location = new System.Drawing.Point(70, 90);
            this.Res_Recorrido.Multiline = true;
            this.Res_Recorrido.Name = "Res_Recorrido";
            this.Res_Recorrido.Size = new System.Drawing.Size(241, 118);
            this.Res_Recorrido.TabIndex = 7;
            // 
            // busqAmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 238);
            this.Controls.Add(this.Res_Recorrido);
            this.Controls.Add(this.RaizSelected);
            this.Controls.Add(this.lblRaiz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bfsButton);
            this.Name = "busqAmp";
            this.Text = "Recorridos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bfsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRaiz;
        private System.Windows.Forms.ComboBox RaizSelected;
        private System.Windows.Forms.TextBox Res_Recorrido;
    }
}