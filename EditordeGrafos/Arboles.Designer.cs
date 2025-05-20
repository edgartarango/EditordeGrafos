namespace EditordeGrafos
{
    partial class Arboles
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
            this.lblClave_Arbol = new System.Windows.Forms.Label();
            this.Clave_Button = new System.Windows.Forms.Button();
            this.txt_Clave = new System.Windows.Forms.TextBox();
            this.btn_CreaDat = new System.Windows.Forms.Button();
            this.btn_CreaTxt = new System.Windows.Forms.Button();
            this.btn_CargaArbol = new System.Windows.Forms.Button();
            this.txt_DirRaiz = new System.Windows.Forms.TextBox();
            this.lbl_DirRaiz = new System.Windows.Forms.Label();
            this.txt_EOF = new System.Windows.Forms.TextBox();
            this.lbl_EOF = new System.Windows.Forms.Label();
            this.txt_TamRegis = new System.Windows.Forms.TextBox();
            this.lbl_TamRegis = new System.Windows.Forms.Label();
            this.txt_TamPag = new System.Windows.Forms.TextBox();
            this.lbl_TamPag = new System.Windows.Forms.Label();
            this.txt_UltRegis = new System.Windows.Forms.TextBox();
            this.lbl_UltRegis = new System.Windows.Forms.Label();
            this.Res_Arbol = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Res_Arbol)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClave_Arbol
            // 
            this.lblClave_Arbol.AutoSize = true;
            this.lblClave_Arbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClave_Arbol.Location = new System.Drawing.Point(25, 33);
            this.lblClave_Arbol.Name = "lblClave_Arbol";
            this.lblClave_Arbol.Size = new System.Drawing.Size(49, 18);
            this.lblClave_Arbol.TabIndex = 16;
            this.lblClave_Arbol.Text = "Clave:";
            // 
            // Clave_Button
            // 
            this.Clave_Button.Location = new System.Drawing.Point(96, 59);
            this.Clave_Button.Name = "Clave_Button";
            this.Clave_Button.Size = new System.Drawing.Size(75, 22);
            this.Clave_Button.TabIndex = 17;
            this.Clave_Button.Text = "Introducir";
            this.Clave_Button.UseVisualStyleBackColor = true;
            this.Clave_Button.Click += new System.EventHandler(this.Clave_Button_Click);
            // 
            // txt_Clave
            // 
            this.txt_Clave.Location = new System.Drawing.Point(79, 34);
            this.txt_Clave.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Clave.Name = "txt_Clave";
            this.txt_Clave.Size = new System.Drawing.Size(92, 20);
            this.txt_Clave.TabIndex = 22;
            this.txt_Clave.TextChanged += new System.EventHandler(this.txt_Clave_TextChanged);
            // 
            // btn_CreaDat
            // 
            this.btn_CreaDat.Location = new System.Drawing.Point(119, -1);
            this.btn_CreaDat.Name = "btn_CreaDat";
            this.btn_CreaDat.Size = new System.Drawing.Size(102, 22);
            this.btn_CreaDat.TabIndex = 23;
            this.btn_CreaDat.Text = "Crea Archivo .bin";
            this.btn_CreaDat.UseVisualStyleBackColor = true;
            this.btn_CreaDat.Click += new System.EventHandler(this.btn_CreaDat_Click);
            // 
            // btn_CreaTxt
            // 
            this.btn_CreaTxt.Location = new System.Drawing.Point(12, -1);
            this.btn_CreaTxt.Name = "btn_CreaTxt";
            this.btn_CreaTxt.Size = new System.Drawing.Size(99, 22);
            this.btn_CreaTxt.TabIndex = 24;
            this.btn_CreaTxt.Text = "Crea Archivo .txt";
            this.btn_CreaTxt.UseVisualStyleBackColor = true;
            this.btn_CreaTxt.Click += new System.EventHandler(this.btn_CreaTxt_Click);
            // 
            // btn_CargaArbol
            // 
            this.btn_CargaArbol.Location = new System.Drawing.Point(322, -1);
            this.btn_CargaArbol.Name = "btn_CargaArbol";
            this.btn_CargaArbol.Size = new System.Drawing.Size(75, 22);
            this.btn_CargaArbol.TabIndex = 25;
            this.btn_CargaArbol.Text = "Cargar Arbol";
            this.btn_CargaArbol.UseVisualStyleBackColor = true;
            this.btn_CargaArbol.Click += new System.EventHandler(this.btn_CargaArbol_Click);
            // 
            // txt_DirRaiz
            // 
            this.txt_DirRaiz.Location = new System.Drawing.Point(284, 34);
            this.txt_DirRaiz.Margin = new System.Windows.Forms.Padding(2);
            this.txt_DirRaiz.Name = "txt_DirRaiz";
            this.txt_DirRaiz.Size = new System.Drawing.Size(92, 20);
            this.txt_DirRaiz.TabIndex = 27;
            // 
            // lbl_DirRaiz
            // 
            this.lbl_DirRaiz.AutoSize = true;
            this.lbl_DirRaiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DirRaiz.Location = new System.Drawing.Point(223, 34);
            this.lbl_DirRaiz.Name = "lbl_DirRaiz";
            this.lbl_DirRaiz.Size = new System.Drawing.Size(65, 18);
            this.lbl_DirRaiz.TabIndex = 26;
            this.lbl_DirRaiz.Text = "Dir Raíz:";
            // 
            // txt_EOF
            // 
            this.txt_EOF.Location = new System.Drawing.Point(502, 22);
            this.txt_EOF.Margin = new System.Windows.Forms.Padding(2);
            this.txt_EOF.Name = "txt_EOF";
            this.txt_EOF.Size = new System.Drawing.Size(92, 20);
            this.txt_EOF.TabIndex = 29;
            // 
            // lbl_EOF
            // 
            this.lbl_EOF.AutoSize = true;
            this.lbl_EOF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EOF.Location = new System.Drawing.Point(448, 21);
            this.lbl_EOF.Name = "lbl_EOF";
            this.lbl_EOF.Size = new System.Drawing.Size(43, 18);
            this.lbl_EOF.TabIndex = 28;
            this.lbl_EOF.Text = "EOF:";
            // 
            // txt_TamRegis
            // 
            this.txt_TamRegis.Location = new System.Drawing.Point(697, 60);
            this.txt_TamRegis.Margin = new System.Windows.Forms.Padding(2);
            this.txt_TamRegis.Name = "txt_TamRegis";
            this.txt_TamRegis.Size = new System.Drawing.Size(92, 20);
            this.txt_TamRegis.TabIndex = 31;
            // 
            // lbl_TamRegis
            // 
            this.lbl_TamRegis.AutoSize = true;
            this.lbl_TamRegis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TamRegis.Location = new System.Drawing.Point(599, 59);
            this.lbl_TamRegis.Name = "lbl_TamRegis";
            this.lbl_TamRegis.Size = new System.Drawing.Size(102, 18);
            this.lbl_TamRegis.TabIndex = 30;
            this.lbl_TamRegis.Text = "Tam Registro:";
            this.lbl_TamRegis.Click += new System.EventHandler(this.label3_Click);
            // 
            // txt_TamPag
            // 
            this.txt_TamPag.Location = new System.Drawing.Point(697, 21);
            this.txt_TamPag.Margin = new System.Windows.Forms.Padding(2);
            this.txt_TamPag.Name = "txt_TamPag";
            this.txt_TamPag.Size = new System.Drawing.Size(92, 20);
            this.txt_TamPag.TabIndex = 33;
            // 
            // lbl_TamPag
            // 
            this.lbl_TamPag.AutoSize = true;
            this.lbl_TamPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TamPag.Location = new System.Drawing.Point(601, 21);
            this.lbl_TamPag.Name = "lbl_TamPag";
            this.lbl_TamPag.Size = new System.Drawing.Size(91, 18);
            this.lbl_TamPag.TabIndex = 32;
            this.lbl_TamPag.Text = "Tam Pagina:";
            // 
            // txt_UltRegis
            // 
            this.txt_UltRegis.Location = new System.Drawing.Point(502, 62);
            this.txt_UltRegis.Margin = new System.Windows.Forms.Padding(2);
            this.txt_UltRegis.Name = "txt_UltRegis";
            this.txt_UltRegis.Size = new System.Drawing.Size(92, 20);
            this.txt_UltRegis.TabIndex = 35;
            // 
            // lbl_UltRegis
            // 
            this.lbl_UltRegis.AutoSize = true;
            this.lbl_UltRegis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UltRegis.Location = new System.Drawing.Point(382, 59);
            this.lbl_UltRegis.Name = "lbl_UltRegis";
            this.lbl_UltRegis.Size = new System.Drawing.Size(115, 18);
            this.lbl_UltRegis.TabIndex = 34;
            this.lbl_UltRegis.Text = "Ultimo Registro:";
            // 
            // Res_Arbol
            // 
            this.Res_Arbol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Res_Arbol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Res_Arbol.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Res_Arbol.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.Res_Arbol.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.Res_Arbol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Res_Arbol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.Res_Arbol.Location = new System.Drawing.Point(12, 101);
            this.Res_Arbol.Name = "Res_Arbol";
            this.Res_Arbol.RowHeadersWidth = 51;
            this.Res_Arbol.RowTemplate.Height = 28;
            this.Res_Arbol.Size = new System.Drawing.Size(826, 339);
            this.Res_Arbol.TabIndex = 36;
            this.Res_Arbol.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Res_Arbol_CellContentClick_1);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Dir";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "T";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "AP";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Clave";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "AP";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Clave";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "AP";
            this.Column7.MinimumWidth = 8;
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Clave";
            this.Column8.MinimumWidth = 8;
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "AP";
            this.Column9.MinimumWidth = 8;
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Clave";
            this.Column10.MinimumWidth = 8;
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "AP";
            this.Column11.MinimumWidth = 8;
            this.Column11.Name = "Column11";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(227, -1);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(89, 22);
            this.btn_Save.TabIndex = 37;
            this.btn_Save.Text = "Guardar Binario";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // Arboles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.Res_Arbol);
            this.Controls.Add(this.txt_UltRegis);
            this.Controls.Add(this.lbl_UltRegis);
            this.Controls.Add(this.txt_TamPag);
            this.Controls.Add(this.lbl_TamPag);
            this.Controls.Add(this.txt_TamRegis);
            this.Controls.Add(this.lbl_TamRegis);
            this.Controls.Add(this.txt_EOF);
            this.Controls.Add(this.lbl_EOF);
            this.Controls.Add(this.txt_DirRaiz);
            this.Controls.Add(this.lbl_DirRaiz);
            this.Controls.Add(this.btn_CargaArbol);
            this.Controls.Add(this.btn_CreaTxt);
            this.Controls.Add(this.btn_CreaDat);
            this.Controls.Add(this.txt_Clave);
            this.Controls.Add(this.Clave_Button);
            this.Controls.Add(this.lblClave_Arbol);
            this.Name = "Arboles";
            this.Text = "Arboles B+";
            ((System.ComponentModel.ISupportInitialize)(this.Res_Arbol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblClave_Arbol;
        private System.Windows.Forms.Button Clave_Button;
        private System.Windows.Forms.TextBox txt_Clave;
        private System.Windows.Forms.Button btn_CreaDat;
        private System.Windows.Forms.Button btn_CreaTxt;
        private System.Windows.Forms.Button btn_CargaArbol;
        private System.Windows.Forms.TextBox txt_DirRaiz;
        private System.Windows.Forms.Label lbl_DirRaiz;
        private System.Windows.Forms.TextBox txt_EOF;
        private System.Windows.Forms.Label lbl_EOF;
        private System.Windows.Forms.TextBox txt_TamRegis;
        private System.Windows.Forms.Label lbl_TamRegis;
        private System.Windows.Forms.TextBox txt_TamPag;
        private System.Windows.Forms.Label lbl_TamPag;
        private System.Windows.Forms.TextBox txt_UltRegis;
        private System.Windows.Forms.Label lbl_UltRegis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.DataGridView Res_Arbol;
    }
}