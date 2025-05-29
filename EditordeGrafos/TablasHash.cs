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
    public partial class TablasHash : Form
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
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Archivo binario (*.bin)|*.bin|Todos los archivos (*.*)|*.*";
            openFile.InitialDirectory = Application.StartupPath + "\\Hash";
            if (tablaHash != null)
            {
                MessageBox.Show("¡Ya hay una tabla creada, dar click en limpiar!");
                return;
            }

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Enabled = false;

                try
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(openFile.FileName, FileMode.Open)))
                    {
                        // Leer cabecera
                        int numeroDeZocalos = reader.ReadInt32();
                        int capacidadCubetas = reader.ReadInt32();
                        int tamRegistro = reader.ReadInt32();
                        int apuntadorVacias = reader.ReadInt32();
                        int eof = reader.ReadInt32();
                        int eofini = reader.ReadInt32();

                        // Inicializar tabla con los valores correctos
                        tablaHash = new TablaDirecciones(numeroDeZocalos, capacidadCubetas, eof, tamRegistro);

                        // Leer direcciones de zócalos
                        for (int i = 0; i < numeroDeZocalos; i++)
                        {
                            int direccion = reader.ReadInt32();
                            if (direccion != 0)
                            {
                                tablaHash.SetZocalo(i, direccion);
                            }
                        }

                        // Ahora leemos las cubetas y sus registros
                        long posicionActual = reader.BaseStream.Position;

                        // Diccionario para evitar duplicados
                        Dictionary<int, bool> clavesInsertadas = new Dictionary<int, bool>();

                        // Leemos hasta el final del archivo
                        while (posicionActual < reader.BaseStream.Length)
                        {
                            try
                            {
                                int direccionCubeta = reader.ReadInt32();
                                int registrosUtilizados = reader.ReadInt32();

                                // Leer cada registro de la cubeta actual
                                for (int i = 0; i < registrosUtilizados; i++)
                                {
                                    int claveRegistro = reader.ReadInt32();

                                    // Si la clave no existe, la insertamos
                                    if (!clavesInsertadas.ContainsKey(claveRegistro))
                                    {
                                        tablaHash.Inserta(claveRegistro);
                                        clavesInsertadas[claveRegistro] = true;
                                    }
                                }

                                // Actualizar posición para la siguiente iteración
                                posicionActual = reader.BaseStream.Position;
                            }
                            catch (EndOfStreamException)
                            {
                                // Si llegamos al final del archivo, salimos del bucle
                                break;
                            }
                        }

                        // Actualizar la interfaz gráfica
                        ActualizaGraficos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer el archivo binario: " + ex.Message + "\n" + ex.StackTrace);
                    tablaHash = null;
                }
                finally
                {
                    Enabled = true;
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
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(archivoBinario, FileMode.Create)))
                {
                    // Escribir cabecera
                    writer.Write(tablaHash.GetNumeroDeZocalos());
                    writer.Write(tablaHash.GetCapacidadCubetas());
                    writer.Write(tablaHash.TAM_REGISTRO);
                    writer.Write(tablaHash.GetApuntadorVacias());
                    writer.Write(tablaHash.GetEOF());
                    writer.Write(tablaHash.GetEOFInicial());

                    // Escribir direcciones de zócalos
                    for (int i = 0; i < tablaHash.GetNumeroDeZocalos(); i++)
                    {
                        Cubeta cubeta = tablaHash.direccionesDeCuebetas[i];
                        writer.Write(cubeta != null ? cubeta.GetDireccion() : 0);
                    }

                    // Guardar todas las cubetas existentes
                    // Primero recopilamos todas las cubetas para asegurar que guardamos todas
                    List<Cubeta> todasLasCubetas = new List<Cubeta>();

                    // Recopilamos todas las cubetas principales y sus cubetas enlazadas
                    foreach (Cubeta cubeta in tablaHash.GetDireccionesDeCubetas())
                    {
                        if (cubeta != null)
                        {
                            todasLasCubetas.Add(cubeta);

                            // También añadimos todas las cubetas enlazadas
                            Cubeta siguiente = cubeta.GetSiguiente();
                            while (siguiente != null)
                            {
                                todasLasCubetas.Add(siguiente);
                                siguiente = siguiente.GetSiguiente();
                            }
                        }
                    }

                    // Ordenamos las cubetas por dirección para mantener coherencia
                    todasLasCubetas = todasLasCubetas.OrderBy(c => c.GetDireccion()).ToList();

                    // Escribimos cada cubeta con sus registros
                    foreach (Cubeta cubeta in todasLasCubetas)
                    {
                        writer.Write(cubeta.GetDireccion());
                        writer.Write(cubeta.GetRegistrosUtilizados());

                        // Escribimos cada registro de la cubeta
                        foreach (Registro reg in cubeta.GetRegistros())
                        {
                            if (reg != null)
                                writer.Write(reg.GetClave());
                        }
                    }
                }
                MessageBox.Show("Archivo guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el archivo binario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
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
                if (tablaHash.Elimina((int)numericUpDown1.Value))
                {
                    ActualizaGraficos();
                    MessageBox.Show("La clave (" + numericUpDown1.Value + ") ha sido eliminada correctamente.");
                }
                else
                {
                    MessageBox.Show("La clave (" + numericUpDown1.Value + ") no existe en la tabla.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Ocurrió un error al eliminar: " + ex.Message + "!");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tablaHash == null)
            {
                MessageBox.Show("¡Aún no se ha creado o cargado alguna tabla!");
                return;
            }

            SaveFileDialog sav = new SaveFileDialog
            {
                Filter = "Archivo binario (*.bin)|*.bin|Todos los archivos (*.*)|*.*",
                DefaultExt = "bin",
                InitialDirectory = Application.StartupPath + "\\Hash"
            };

            if (sav.ShowDialog() == DialogResult.OK)
            {
                GuardarDatosEnArchivoBinario(sav.FileName);
            }
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
