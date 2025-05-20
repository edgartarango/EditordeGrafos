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
    public partial class CubetaG : UserControl
    {
        public string APSiguienteCubeta { get; set; }
        public List<string> Registros { get; set; }

        public CubetaG(int direccion, int registrosUtilizados, int capacidad)
        {
            InitializeComponent();
            APSiguienteCubeta = "null";
            Registros = new List<string>(capacidad);
            label5.Text = registrosUtilizados.ToString();
            label4.Text = direccion.ToString();

            ActualizaCubeta();
        }

        public CubetaG(int direccion, int registrosUtilizados, int capacidad, int clave)
        {
            InitializeComponent();
            APSiguienteCubeta = "null";
            Registros = new List<string>(capacidad) { clave.ToString() };
            label5.Text = registrosUtilizados.ToString();
            label4.Text = direccion.ToString();

            ActualizaCubeta();
        }

        public CubetaG()
        {
            InitializeComponent();
        }

        public void ActualizaRegistros(List<int> registros)
        {
            Registros.Clear();
            for (int registro = 0; registro < registros.Count; registro++)
                Registros.Insert(registro, registros[registro].ToString());
        }

        public void ActualizaCubeta()
        {
            int registros = 0;
            dataGridView1.Rows.Clear();
            foreach (string registro in Registros)
            {
                if (registro != "...")
                    registros++;
                dataGridView1.Rows.Add(registro);
            }
            label5.Text = registros.ToString();
            label6.Text = APSiguienteCubeta;
        }
    }
}
