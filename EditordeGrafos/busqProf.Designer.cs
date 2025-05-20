namespace EditordeGrafos
{
    partial class busqProf
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
            this.Res_DFS = new System.Windows.Forms.TextBox();
            this.DFS_RaizSelected = new System.Windows.Forms.ComboBox();
            this.lblRaiz_DFS = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Titulo_DFS = new System.Windows.Forms.Label();
            this.dfsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Res_DFS
            // 
            this.Res_DFS.Location = new System.Drawing.Point(70, 90);
            this.Res_DFS.Multiline = true;
            this.Res_DFS.Name = "Res_DFS";
            this.Res_DFS.Size = new System.Drawing.Size(241, 115);
            this.Res_DFS.TabIndex = 13;
            // 
            // DFS_RaizSelected
            // 
            this.DFS_RaizSelected.FormattingEnabled = true;
            this.DFS_RaizSelected.Location = new System.Drawing.Point(70, 40);
            this.DFS_RaizSelected.Name = "DFS_RaizSelected";
            this.DFS_RaizSelected.Size = new System.Drawing.Size(121, 21);
            this.DFS_RaizSelected.TabIndex = 12;
            // 
            // lblRaiz_DFS
            // 
            this.lblRaiz_DFS.AutoSize = true;
            this.lblRaiz_DFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaiz_DFS.Location = new System.Drawing.Point(70, 15);
            this.lblRaiz_DFS.Name = "lblRaiz_DFS";
            this.lblRaiz_DFS.Size = new System.Drawing.Size(42, 18);
            this.lblRaiz_DFS.TabIndex = 11;
            this.lblRaiz_DFS.Text = "Raiz:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Resultado:";
            // 
            // Titulo_DFS
            // 
            this.Titulo_DFS.AutoSize = true;
            this.Titulo_DFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo_DFS.Location = new System.Drawing.Point(151, 39);
            this.Titulo_DFS.Name = "Titulo_DFS";
            this.Titulo_DFS.Size = new System.Drawing.Size(0, 16);
            this.Titulo_DFS.TabIndex = 9;
            // 
            // dfsButton
            // 
            this.dfsButton.Location = new System.Drawing.Point(200, 40);
            this.dfsButton.Name = "dfsButton";
            this.dfsButton.Size = new System.Drawing.Size(105, 19);
            this.dfsButton.TabIndex = 8;
            this.dfsButton.Text = "Iniciar";
            this.dfsButton.UseVisualStyleBackColor = true;
            this.dfsButton.Click += new System.EventHandler(this.dfsButton_Click);
            // 
            // Pestana_DFS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 238);
            this.Controls.Add(this.Res_DFS);
            this.Controls.Add(this.DFS_RaizSelected);
            this.Controls.Add(this.lblRaiz_DFS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Titulo_DFS);
            this.Controls.Add(this.dfsButton);
            this.Name = "busqProf";
            this.Text = "Busqueda Profundidad DFS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Res_DFS;
        private System.Windows.Forms.ComboBox DFS_RaizSelected;
        private System.Windows.Forms.Label lblRaiz_DFS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Titulo_DFS;
        private System.Windows.Forms.Button dfsButton;
    }
}