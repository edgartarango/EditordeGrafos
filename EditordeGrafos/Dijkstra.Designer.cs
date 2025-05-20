namespace EditordeGrafos
{
    partial class Dijkstra
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
            this.lbl_Dijkstra = new System.Windows.Forms.Label();
            this.Raiz_Dijkstra = new System.Windows.Forms.ComboBox();
            this.lblRaiz_Dijkstra = new System.Windows.Forms.Label();
            this.DijkstraButton = new System.Windows.Forms.Button();
            this.Tabla_Orig = new System.Windows.Forms.DataGridView();
            this.Tabla_Mod = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Detalles_Dijkstra = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla_Orig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla_Mod)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Dijkstra
            // 
            this.lbl_Dijkstra.AutoSize = true;
            this.lbl_Dijkstra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Dijkstra.Location = new System.Drawing.Point(282, 9);
            this.lbl_Dijkstra.Name = "lbl_Dijkstra";
            this.lbl_Dijkstra.Size = new System.Drawing.Size(0, 24);
            this.lbl_Dijkstra.TabIndex = 2;
            // 
            // Raiz_Dijkstra
            // 
            this.Raiz_Dijkstra.FormattingEnabled = true;
            this.Raiz_Dijkstra.Location = new System.Drawing.Point(68, 85);
            this.Raiz_Dijkstra.Name = "Raiz_Dijkstra";
            this.Raiz_Dijkstra.Size = new System.Drawing.Size(121, 21);
            this.Raiz_Dijkstra.TabIndex = 11;
            // 
            // lblRaiz_Dijkstra
            // 
            this.lblRaiz_Dijkstra.AutoSize = true;
            this.lblRaiz_Dijkstra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaiz_Dijkstra.Location = new System.Drawing.Point(65, 52);
            this.lblRaiz_Dijkstra.Name = "lblRaiz_Dijkstra";
            this.lblRaiz_Dijkstra.Size = new System.Drawing.Size(42, 18);
            this.lblRaiz_Dijkstra.TabIndex = 10;
            this.lblRaiz_Dijkstra.Text = "Raiz:";
            // 
            // DijkstraButton
            // 
            this.DijkstraButton.Location = new System.Drawing.Point(68, 122);
            this.DijkstraButton.Name = "DijkstraButton";
            this.DijkstraButton.Size = new System.Drawing.Size(105, 32);
            this.DijkstraButton.TabIndex = 8;
            this.DijkstraButton.Text = "Iniciar";
            this.DijkstraButton.UseVisualStyleBackColor = true;
            this.DijkstraButton.Click += new System.EventHandler(this.DijkstraButton_Click);
            // 
            // Tabla_Orig
            // 
            this.Tabla_Orig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.Tabla_Orig.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.Tabla_Orig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tabla_Orig.Enabled = false;
            this.Tabla_Orig.Location = new System.Drawing.Point(44, 220);
            this.Tabla_Orig.Margin = new System.Windows.Forms.Padding(2);
            this.Tabla_Orig.Name = "Tabla_Orig";
            this.Tabla_Orig.RowHeadersWidth = 51;
            this.Tabla_Orig.RowTemplate.Height = 24;
            this.Tabla_Orig.Size = new System.Drawing.Size(528, 77);
            this.Tabla_Orig.TabIndex = 14;
            // 
            // Tabla_Mod
            // 
            this.Tabla_Mod.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.Tabla_Mod.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.Tabla_Mod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tabla_Mod.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.Tabla_Mod.Location = new System.Drawing.Point(44, 342);
            this.Tabla_Mod.Margin = new System.Windows.Forms.Padding(2);
            this.Tabla_Mod.Name = "Tabla_Mod";
            this.Tabla_Mod.RowHeadersWidth = 51;
            this.Tabla_Mod.Size = new System.Drawing.Size(528, 74);
            this.Tabla_Mod.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tabla Modificada:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Tabla Original:";
            // 
            // Detalles_Dijkstra
            // 
            this.Detalles_Dijkstra.BackColor = System.Drawing.SystemColors.Menu;
            this.Detalles_Dijkstra.Location = new System.Drawing.Point(273, 52);
            this.Detalles_Dijkstra.Margin = new System.Windows.Forms.Padding(2);
            this.Detalles_Dijkstra.Name = "Detalles_Dijkstra";
            this.Detalles_Dijkstra.Size = new System.Drawing.Size(249, 139);
            this.Detalles_Dijkstra.TabIndex = 18;
            this.Detalles_Dijkstra.Text = "";
            // 
            // Dijkstra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 450);
            this.Controls.Add(this.Detalles_Dijkstra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tabla_Orig);
            this.Controls.Add(this.Tabla_Mod);
            this.Controls.Add(this.Raiz_Dijkstra);
            this.Controls.Add(this.lblRaiz_Dijkstra);
            this.Controls.Add(this.DijkstraButton);
            this.Controls.Add(this.lbl_Dijkstra);
            this.Name = "Dijkstra";
            this.Text = "Dijkstra";
            ((System.ComponentModel.ISupportInitialize)(this.Tabla_Orig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla_Mod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Dijkstra;
        private System.Windows.Forms.ComboBox Raiz_Dijkstra;
        private System.Windows.Forms.Label lblRaiz_Dijkstra;
        private System.Windows.Forms.Button DijkstraButton;
        private System.Windows.Forms.DataGridView Tabla_Orig;
        private System.Windows.Forms.DataGridView Tabla_Mod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox Detalles_Dijkstra;
    }
}