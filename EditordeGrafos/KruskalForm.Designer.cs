using System;
using System.Windows.Forms;

namespace EditordeGrafos          // ← ajusta si usas otro namespace
{
    partial class KruskalForm
    {
        /// <summary>Variable necesaria para diseñar la interfaz.</summary>
        private System.ComponentModel.IContainer components = null;

        // Controles de la ventana
        private Label lblRoot;
        private ComboBox cmbRoot;
        private Button btnCalcular;
        private TextBox txtResultado;

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            this.lblRoot = new System.Windows.Forms.Label();
            this.cmbRoot = new System.Windows.Forms.ComboBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblRoot
            // 
            this.lblRoot.AutoSize = true;
            this.lblRoot.Location = new System.Drawing.Point(12, 15);
            this.lblRoot.Name = "lblRoot";
            this.lblRoot.Size = new System.Drawing.Size(33, 13);
            this.lblRoot.TabIndex = 0;
            this.lblRoot.Text = "Raíz:";
            // 
            // cmbRoot
            // 
            this.cmbRoot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoot.FormattingEnabled = true;
            this.cmbRoot.Location = new System.Drawing.Point(53, 12);
            this.cmbRoot.Name = "cmbRoot";
            this.cmbRoot.Size = new System.Drawing.Size(121, 21);
            this.cmbRoot.TabIndex = 1;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalcular.Location = new System.Drawing.Point(425, 10);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(98, 23);
            this.btnCalcular.TabIndex = 2;
            this.btnCalcular.Text = "Calcular MST";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // txtResultado
            // 
            this.txtResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                          | System.Windows.Forms.AnchorStyles.Left)
                                          | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultado.Location = new System.Drawing.Point(15, 48);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResultado.Size = new System.Drawing.Size(508, 301);
            this.txtResultado.TabIndex = 3;
            this.txtResultado.WordWrap = false;
            // 
            // KruskalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 361);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.cmbRoot);
            this.Controls.Add(this.lblRoot);
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "KruskalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Árbol de Expansión Mínima (Kruskal)";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
