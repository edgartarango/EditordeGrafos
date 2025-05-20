namespace EditordeGrafos
{
    partial class busqProf
    {
        /// <summary>
        /// Variable del diseñador.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelRoot;
        private System.Windows.Forms.ComboBox comboBoxRoot;
        private System.Windows.Forms.Button btnRecorrer;
        private System.Windows.Forms.TextBox textBoxDFS;

        /// <summary>
        /// Método requerido para el diseñador.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelRoot = new System.Windows.Forms.Label();
            this.comboBoxRoot = new System.Windows.Forms.ComboBox();
            this.btnRecorrer = new System.Windows.Forms.Button();
            this.textBoxDFS = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelRoot
            // 
            this.labelRoot.AutoSize = true;
            this.labelRoot.Location = new System.Drawing.Point(12, 15);
            this.labelRoot.Name = "labelRoot";
            this.labelRoot.Size = new System.Drawing.Size(97, 13);
            this.labelRoot.TabIndex = 0;
            this.labelRoot.Text = "Seleccionar Raíz:";
            // 
            // comboBoxRoot
            // 
            this.comboBoxRoot.FormattingEnabled = true;
            this.comboBoxRoot.Location = new System.Drawing.Point(115, 12);
            this.comboBoxRoot.Name = "comboBoxRoot";
            this.comboBoxRoot.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRoot.TabIndex = 1;
            // 
            // btnRecorrer
            // 
            this.btnRecorrer.Location = new System.Drawing.Point(250, 10);
            this.btnRecorrer.Name = "btnRecorrer";
            this.btnRecorrer.Size = new System.Drawing.Size(75, 23);
            this.btnRecorrer.TabIndex = 2;
            this.btnRecorrer.Text = "Recorrer";
            this.btnRecorrer.UseVisualStyleBackColor = true;
            this.btnRecorrer.Click += new System.EventHandler(this.btnRecorrer_Click);
            // 
            // textBoxDFS
            // 
            this.textBoxDFS.Location = new System.Drawing.Point(12, 50);
            this.textBoxDFS.Multiline = true;
            this.textBoxDFS.Name = "textBoxDFS";
            this.textBoxDFS.ReadOnly = true;
            this.textBoxDFS.Size = new System.Drawing.Size(360, 100);
            this.textBoxDFS.TabIndex = 3;
            // 
            // busqProf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.textBoxDFS);
            this.Controls.Add(this.btnRecorrer);
            this.Controls.Add(this.comboBoxRoot);
            this.Controls.Add(this.labelRoot);
            this.Name = "busqProf";
            this.Text = "Recorrido en Profundidad (DFS)";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// Limpia los recursos utilizados.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
