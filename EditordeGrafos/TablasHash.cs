using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EditordeGrafos
{
    public partial class TablasHash: Form
    {
        private TablaDirecciones tablaHash;
        public TablasHash()
        {
            InitializeComponent();
        }

        private void elementoAInsertar_ValueChanged(object sender, EventArgs e)
        {
            if (tablaHash != null)
                label4.Text = numericUpDown1.Value + "%" + tablaHash.GetNumeroDeZocalos() + "=" + numericUpDown1.Value % tablaHash.GetNumeroDeZocalos();
        }

        private void ActualizaTablaDirecciones()
        {
            List<List<string>> tablaDireccionesTxt;

            if (tablaHash != null)
            {
                label9.Text = tablaHash.GetNumeroDeZocalos().ToString();
                label12.Text = tablaHash.GetCapacidadCubetas().ToString();
                label11.Text = tablaHash.TAM_REGISTRO.ToString();
                label10.Text = tablaHash.GetApuntadorVacias().ToString();

                tablaDireccionesTxt = tablaHash.TablaDireccionesComoTexto();

                dataGridView1.Rows.Clear();
                foreach (List<string> elemento in tablaDireccionesTxt)
                    dataGridView1.Rows.Add(elemento.ToArray());
            }
            else
            {
                label9.Text = "...";
                label12.Text = "...";
                label11.Text = "...";
                label10.Text = "...";

                dataGridView1.Rows.Clear();

            }
        }

        private void ActualizaGraficos()
        {
            ActualizaTablaDirecciones();

            if (tablaHash != null)
            {
                label2.Text = "EOF: " + tablaHash.GetEOF();
                label3.Text = "EOF inicial: " + tablaHash.GetEOFInicial();

                panel2.Controls.Clear();

                List<PanelCubeta> panelesCubetas = new List<PanelCubeta>();
                foreach (Cubeta cubeta in tablaHash.GetDireccionesDeCubetas())
                    if (cubeta != null)
                        panelesCubetas.Add(new PanelCubeta(cubeta.GetCubetasG()));
                panelesCubetas.Reverse();
                panel2.Controls.AddRange(panelesCubetas.ToArray());
            }
            else
            {
                label4.Text = "%";
                label2.Text = "EOF: ";
                label3.Text = "EOF inicial: ";
                panel2.Controls.Clear();
            }
        }

        private void nuevaTabla_Click(object sender, EventArgs e)
        {
            if (tablaHash == null)
                using (NuevaTabla nuevaTabla = new NuevaTabla())
                {
                    if (nuevaTabla.ShowDialog() == DialogResult.OK)
                    {
                        tablaHash = new TablaDirecciones(
                            nuevaTabla.NumeroDeZocalos,
                            nuevaTabla.CapacidadCubetas,
                            nuevaTabla.EOF,
                            nuevaTabla.TamRegistros
                        );
                        ActualizaGraficos();
                    }
                }
            else
                MessageBox.Show("¡Ya hay una tabla creada, dar click en limpiar!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tablaHash == null)
            {
                MessageBox.Show("Cree una tabla o abra un archivo de tablas de Hash");
                return;
            }
            if (numericUpDown1.Value < 0)
            {
                MessageBox.Show("¡Ingrese valores positivos!");
                return;
            }
            try
            {
                tablaHash.Inserta((int)numericUpDown1.Value);
                ActualizaGraficos();
            }
            catch (Exception ex)
            {
                if (ex is ExcepcionClaveExistente)
                    MessageBox.Show(
                        "La clave (" + (ex as ExcepcionClaveExistente).ClaveExistente + ") ya está en la tabla.");
                else
                    MessageBox.Show("¡Ocurrió un error!");
            }
        }

        private void limpiarTabla_Click(object sender, EventArgs e)
        {
            if (tablaHash == null)
                MessageBox.Show("¡Aún no se ha creado o cargado una tabla Hash!");
            else
            {
                if (MessageBox.Show("Esto eliminara los cambios hechos a la tabla", "¿Eliminar?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tablaHash = null;
                    GC.Collect();
                    ActualizaGraficos();
                }
            }
        }

        private void abrirArchivodatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int seek = 0;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Documento binario (*.dat)|*.dat|All files (*.*)|*.*";
            openFile.InitialDirectory = Application.StartupPath + "\\Hash";
            if (tablaHash != null)
            {
                MessageBox.Show("¡Ya hay una tabla creada, dar click en limpiar!");
            }
            else
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    Enabled = false;

                    try
                    {
                        using (BinaryReader reader = new BinaryReader(File.Open(openFile.FileName, FileMode.Open)))
                        {
                            int numeroDeZocalos = reader.ReadInt32();
                            int capacidadCubetas = reader.ReadInt32();
                            int tamRegistro = reader.ReadInt32();
                            int apuntadorVacias = reader.ReadInt32();
                            int eof = reader.ReadInt32();
                            int eofini = reader.ReadInt32();
                            int[] direcc = new int[numeroDeZocalos];
                            for(int i=0; i<numeroDeZocalos; i++)
                            {
                                direcc[i] = reader.ReadInt32();
                            }

                            tablaHash = new TablaDirecciones(numeroDeZocalos, capacidadCubetas, tamRegistro, apuntadorVacias, eofini);

                            seek=eofini + 1;
                           
                            reader.BaseStream.Seek(seek, SeekOrigin.Begin);

                            while (reader.BaseStream.Position < reader.BaseStream.Length)
                            {
                                int direccionCubeta = reader.ReadInt32();
                                int reguti = reader.ReadInt32();
                                int claveRegistro=reader.ReadInt32();
                                tablaHash.Inserta(claveRegistro);
                            }
                        }
                        ActualizaGraficos();
                        int errores = tablaHash.ValidaDirecciones();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al leer el archivo binario: " + ex.Message);
                    }
                    finally
                    {
                        Enabled = true;
                    }
                }
            }
        }

        private void abrirArchivotxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Documento de texto (*.txt)|*.txt|All files (*.*)|*.*";
            openFile.InitialDirectory = Application.StartupPath + "\\Hash";
            if (tablaHash != null)
                MessageBox.Show("¡Ya hay una tabla creada, dar click en limpiar!");
            else
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Enabled = false;
                string[] texto = File.ReadAllLines(openFile.FileName);
                string[] valores;
                int[] numeros;
                int elementoLectura = -1;
                int zocalosLeidos = 0;
                int registrosRestantes = 0;
                Cubeta cubetaActual = null;
                for (int linea = 0; linea < texto.Count(); linea++)
                {
                    if (texto[linea].EndsWith(";"))
                    {
                        valores = texto[linea].Substring(0, texto[linea].IndexOf(';')).Split(',');
                        if (valores.All(v => int.TryParse(v, out _)))
                        {
                            numeros = Array.ConvertAll(valores, v => int.Parse(v));
                            elementoLectura = numeros.Count();
                            switch (elementoLectura)
                            {
                                case 5:
                                    if (numeros.Count() == 5)
                                        tablaHash = new TablaDirecciones(
                                            numeros[0],
                                            numeros[1],
                                            numeros[2],
                                            numeros[3],
                                            numeros[4]
                                        );
                                    else
                                        MessageBox.Show("Error en la cabecera de la tabla de direcciones. Línea: " + linea);
                                    break;
                                case 2:
                                    if (tablaHash != null)
                                        if (zocalosLeidos <= tablaHash.GetNumeroDeZocalos() - 1)
                                        {
                                            if (numeros[1] != 0)
                                            {
                                                try
                                                {
                                                    tablaHash.SetZocalo(numeros[0], numeros[1]);
                                                }
                                                catch (ExcepcionZocaloInvalido ex)
                                                {
                                                    MessageBox.Show("Dirección de zócalo inválida (" + ex.Zocalo + "). Línea: " + linea);
                                                    return;
                                                }
                                            }
                                            zocalosLeidos++;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error al leer la cabecera de la tabla de direcciones");
                                            return;
                                        }
                                    break;
                                case 3:
                                    if (zocalosLeidos == tablaHash.GetNumeroDeZocalos() && registrosRestantes == 0)
                                    {
                                        cubetaActual = tablaHash.BuscaCubeta(numeros[0]);
                                        if (cubetaActual != null)
                                        {
                                            if (numeros[1] > 0)
                                                registrosRestantes = numeros[1];
                                            if (numeros[2] > 0)
                                                cubetaActual.SetSiguiente(new Cubeta(numeros[2], tablaHash.GetCapacidadCubetas()));
                                        }
                                        else
                                        {
                                            MessageBox.Show("Verifique la cubeta en la línea: " + linea);
                                            throw new Exception();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Zócalos o registros incompletos.");
                                        throw new Exception();
                                    }
                                    break;
                                case 1:
                                    if (--registrosRestantes >= 0 && cubetaActual != null)
                                    {
                                        try
                                        {
                                            cubetaActual.InsertaSimple(new Registro(numeros[0]));
                                        }
                                        catch (ExcepcionColision ex)
                                        {
                                            MessageBox.Show(
                                                "Error al cargar el registro (" +
                                                numeros[0] +
                                                "). Línea: " +
                                                linea +
                                                " Cubeta: " +
                                                ex.CubetaColision.GetDireccion()
                                            );
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error al cargar una cubeta. Línea: " + linea);
                                        throw new Exception();
                                    }
                                    break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta ';' en la línea: " + linea);
                        throw new Exception();
                    }
                }
                Enabled = true;
                ActualizaGraficos();
                int errores = tablaHash.ValidaDirecciones();
            }
        }

        private void GuardarDatosEnArchivoBinario(string archivoBinario)
        {
            int seek = 0;
            using (BinaryWriter writer = new BinaryWriter(File.Open(archivoBinario, FileMode.Create)))
            {
                writer.Write(tablaHash.GetNumeroDeZocalos());
                writer.Write(tablaHash.GetCapacidadCubetas());
                writer.Write(tablaHash.TAM_REGISTRO);
                writer.Write(tablaHash.GetApuntadorVacias());
                writer.Write(tablaHash.GetEOF());
                writer.Write(tablaHash.GetEOFInicial());

                foreach (Cubeta cube in tablaHash.GetDireccionesDeCubetas())
                {
                    writer.Write(cube.GetDireccion());
                }
                seek=tablaHash.GetEOFInicial() + 1;
                writer.BaseStream.Seek(seek, SeekOrigin.Begin);
                foreach (Cubeta cubeta in tablaHash.GetDireccionesDeCubetas())
                {
                    writer.Write(cubeta.GetDireccion());
                    writer.Write(cubeta.GetRegistrosUtilizados());
                    foreach(Registro reg in cubeta.GetRegistros())
                    {
                        writer.Write(reg.GetClave());
                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog
            {
                Filter = "Documento dat (*.dat)|*.dat|All files (*.*)|*.*",
                InitialDirectory = Application.StartupPath + "\\Hash"
            };
            String nombr;
            if (sav.ShowDialog() == DialogResult.OK)
            {
                nombr = sav.FileName;
                GuardarDatosEnArchivoBinario(nombr);

            }
            else
                MessageBox.Show("¡Aún no se ha creado o cargado alguna tabla!");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            List<string> tablaTxt;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "documento txt (*.txt) | *.txt | All files (*.* | *.*)";
            saveFile.InitialDirectory = Application.StartupPath + "\\Hash";
            if (tablaHash != null)
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    tablaTxt = tablaHash.GeneraArchivo();
                    using (StreamWriter archivo = new StreamWriter(saveFile.FileName))
                    {
                        foreach (string linea in tablaTxt)
                            archivo.WriteLine(linea);
                    }
                }
            }
            else
                MessageBox.Show("¡Aún no se ha creado o cargado alguna tabla!");
        }
    }
}
