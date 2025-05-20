using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos
{
    public partial class NuevaTabla : Form
    {
        public int NumeroDeZocalos { get; set; }
        public int CapacidadCubetas { get; set; }
        public int EOF { get; set; }
        public int TamRegistros { get; set; }
        public NuevaTabla()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {
                if (numericUpDown2.Value > 0)
                {
                    if (int.Parse(textBox1.Text) > 0)
                    {
                        NumeroDeZocalos = (int)numericUpDown1.Value;
                        CapacidadCubetas = (int)numericUpDown2.Value;
                        TamRegistros = int.Parse(textBox1.Text);
                        EOF = (NumeroDeZocalos * 8) + 20;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                        MessageBox.Show("¡Introduzca un valor > 0 para el tamaño de los registros!");
                }
                else
                    MessageBox.Show("¡Introduzca un valor > 0 para la capacidad de las cubetas!");
            }
            else
                MessageBox.Show("¡Introduzca un valor > 0 para el número de zocalos!");
        }
    }
}
