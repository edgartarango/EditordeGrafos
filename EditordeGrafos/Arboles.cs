using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EditordeGrafos
{
    public partial class Arboles : Form
    {


        public List<long> list_Content;
        public List<Tree_BMas> ListDatos;


        public List<Root> List_LeafR;
        public List<Leaf> List_Leafs;
        public List<IntMed> List_LeafMed;



        public bool Opcion = false;
        public Leaf RaizContent;
        public bool Flag = false;


        public int CuentaIntro = 0;
        public int Grado = 5;

        public int Size;
        public string Archivo;
        public string FileType;

        public FileStream Arch;

        public bool BinFlag = false;









        public Arboles()
        {
            InitializeComponent();
            List_Leafs = new List<Leaf>();
            ListDatos = new List<Tree_BMas>();
            list_Content = new List<long>();
            Size = 1000;
            txt_TamRegis.Text += 30;
            txt_TamPag.Text += 65;
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_CreaTxt_Click(object sender, EventArgs e)
        {
            Opcion = true;

            GeneraArchTxt(sender, e);
        }

        private void btn_CreaDat_Click(object sender, EventArgs e)
        {
            Opcion = true;

            GeneraArchBin(sender, e);
        }

        private void txt_Clave_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clave_Button_Click(object sender, EventArgs e)
        {
            if (Opcion == true)
            {
                txt_EOF.Clear();
                MeteInfo(sender, e);
                txt_EOF.Text += Size;
            }


            else
                MessageBox.Show("\t\t          ** ERROR: **  \n   Genere un archivo nuevo o abra un archivo con información");
        }

        private void Res_Arbol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_CargaArbol_Click(object sender, EventArgs e)
        {
            Opcion = true;
            AbreArch(sender, e);
        }

        private void Res_Arbol_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }









        private void AddNum(int Num)
        {
            if (!list_Content.Contains(Num))
            {
                Tree_BMas r = SalvaInfo(Num);
                if (RaizContent.Tipo == 'H')
                {

                    RaizContent.list_Content.Add(Num);
                    RaizContent.list_Content.Sort();

                    RaizContent.list_Dir.Insert(RaizContent.list_Content.IndexOf(Num), r.Direccion);


                    if (RaizContent.list_Content.Count > Grado - 1)
                    {
                        RSpread();
                        txt_DirRaiz.Clear();
                        txt_DirRaiz.Text += RaizContent.Direccion;
                    }
                }

                else
                {
                    Leaf Leaf = AuxLeaf(Num, RaizContent);

                    Leaf.list_Content.Add(Num);
                    Leaf.list_Content.Sort();
                    Leaf.list_Dir.Insert(Leaf.list_Content.IndexOf(Num), r.Direccion);

                    if (Leaf.list_Content.Count > Grado - 1)
                    {
                        SpreadSheet(Leaf);
                    }
                }


                InsertaDatos();
            }
            else
            {
                MessageBox.Show("\t** NOTA: **\n Dato Ingresado Anteriormente");
            }
        }






        private void InsertaNodo(Leaf nPa, Leaf nMy)
        {
            nPa.list_Content.Add(nMy.list_Content.First());
            nPa.list_Content.Sort();
            nPa.list_Dir.Insert(nPa.list_Content.IndexOf(nMy.list_Content.First()) + 1, nMy.Direccion);
            if (nMy.Tipo != 'H')
            {
                nMy.list_Content.Remove(nMy.list_Content.First());
            }
            if (nPa.list_Content.Count > Grado - 1)
            {
                if (nPa.Tipo != 'R')
                {
                    SpreadSheet(nPa);
                }
                else
                {
                    DivideSheet(nMy);
                }
            }
        }





        private void MeteInfo(object sender, EventArgs e)
        {
            int Num = -1;

            if (txt_Clave.TextLength > 0)
            {
                if (int.TryParse(txt_Clave.Text, out Num))
                {
                    AddNum(Num);
                }
                else
                {

                    MessageBox.Show("Clave Ha Sido Introducida Anteriormente");

                }
            }
            else
            {

                MessageBox.Show("Introduzca Una Clave");

            }
        }








        private Tree_BMas SalvaInfo(int Num)
        {
            txt_UltRegis.Clear();
            txt_UltRegis.Text += Size;



            Tree_BMas save = new Tree_BMas(Num);

            save.Direccion = Size;

            Size += 30;
            if (ListDatos.Count > 0)
            {
                ListDatos.Last().Direccion_Next = save.Direccion;
            }


            ListDatos.Add(save);
            list_Content.Add(save.Num);


            if (!Flag)
            {
                StreamWriter sw;
                Arch = new FileStream(Archivo, FileMode.Append, FileAccess.Write);

                sw = new StreamWriter(Arch);
                sw.Write(save.Num.ToString() + ", ");
                sw.Flush();


                Arch.Close();
            }


            return save;
        }


        private void SaveBinFile()
        {


            SaveFileDialog WinSave = new SaveFileDialog
            {

                Filter = "Archivo binario (*.bin)|*.bin|Todos los archivos (*.*)|*.*",


                InitialDirectory = Application.StartupPath + "\\ArchivoBinB+"


            };
            String FilaName;



            if (WinSave.ShowDialog() == DialogResult.OK)
            {

                FilaName = WinSave.FileName;

                using (BinaryWriter writer = new BinaryWriter(File.Open(FilaName, FileMode.Create)))
                {
                    foreach (int Num in list_Content)
                    {
                        writer.Write(Num);
                    }
                }


            }
            MessageBox.Show("Archivo Binario Guardado Exitosamente");
        }





        private void nuevoFile(object sender, EventArgs e)
        {
            CierraArch(null, null);

            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                InitialDirectory = Application.StartupPath + "\\ArbolB+"
            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Archivo = saveDialog.FileName;
                FileType = Path.GetExtension(saveDialog.FileName);
                Arch = new FileStream(Archivo, FileMode.Create, FileAccess.Write);
                FormNueva('H');
                RaizContent = List_Leafs.First();
                InsertaDatos();
                txt_EOF.Clear();
                txt_EOF.Text += Size;
                Arch.Close();
            }
        }



        private void GeneraArchTxt(object sender, EventArgs e)
        {
            CierraArch(null, null);

            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Filter = "Documento de texto (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = Application.StartupPath + "\\ArbolB+"
            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Archivo = saveDialog.FileName;
                FileType = Path.GetExtension(saveDialog.FileName);
                Arch = new FileStream(Archivo, FileMode.Create, FileAccess.Write);
                FormNueva('H');
                RaizContent = List_Leafs.First();
                InsertaDatos();
                txt_EOF.Clear();
                txt_EOF.Text += Size;
                Arch.Close();
            }
        }





        private void GeneraArchBin(object sender, EventArgs e)
        {

            CierraArch(null, null);
            BinFlag = true;

            SaveFileDialog saveDialog = new SaveFileDialog()
            {


                Filter = "Archivo binario (*.bin)|*.bin|Todos los archivos (*.*)|*.*",

                InitialDirectory = Application.StartupPath + "\\ArchivoBinB+"


            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {


                Archivo = saveDialog.FileName;
                FileType = Path.GetExtension(saveDialog.FileName);
                Arch = new FileStream(Archivo, FileMode.Create, FileAccess.Write);


                FormNueva('H');
                RaizContent = List_Leafs.First();
                InsertaDatos();
                txt_EOF.Clear();
                txt_EOF.Text += Size;
                Arch.Close();
            }
            MessageBox.Show("Archivo Binario Creado");
        }





        private void AbreArch(object sender, EventArgs e)
        {
            //FileType = Path.GetExtension(openDialog.FileName);


            CierraArch(null, null);

            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.InitialDirectory = Application.StartupPath + "\\ArchivoBinB+";


            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Flag = true;


                Archivo = openDialog.FileName;
                FileType = Path.GetExtension(openDialog.FileName);

                Arch = new FileStream(Archivo, FileMode.Open, FileAccess.Read);


                FormNueva('H');


                RaizContent = List_Leafs.First();


                if (FileType == ".bin")
                {

                    List<int> List_Nums = new List<int>();
                    using (BinaryReader binaryReader = new BinaryReader(Arch))
                    {
                        while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                        {
                            int num_aux = binaryReader.ReadInt32();
                            AddNum(num_aux);
                        }
                    }


                }
                else if (FileType == ".txt")
                {

                    StreamReader Reader;
                    Reader = new StreamReader(Arch);


                    string texto = Reader.ReadToEnd();
                    texto.Trim(' ');

                    string[] content = texto.Split(',');

                    var listaOrdenada = content.OrderBy(numero => numero).ToList();

                    int aux = 0;


                    foreach (string c in listaOrdenada)
                    {
                        if (int.TryParse(c, out aux))
                        {
                            AddNum(aux);
                        }
                    }

                }




                Arch.Close();
                Flag = false;

                txt_EOF.Clear();
                txt_EOF.Text += Size;

                txt_DirRaiz.Clear();
                txt_DirRaiz.Text += RaizContent.Direccion;

                string TxtFileDir = Path.GetDirectoryName(Archivo);
                string BinFileName = Path.Combine(TxtFileDir, Path.GetFileNameWithoutExtension(Archivo) + ".bin");


                CreateBinSampleTxt(Archivo, BinFileName);

                MessageBox.Show("Arbol Cargado Exitosamente");





                /*
                if (BinFlag == true)
                {
                    SaveBinFile();
                }
                else 
                {

                    CierraArch(null, null);

                    OpenFileDialog openDialog = new OpenFileDialog();

                    openDialog.InitialDirectory = Application.StartupPath + "\\ArchivoBinB+";


                    if (openDialog.ShowDialog() == DialogResult.OK)
                    {
                        Flag = true;


                        Archivo = openDialog.FileName;
                        FileType = Path.GetExtension(openDialog.FileName);

                        Arch = new FileStream(Archivo, FileMode.Open, FileAccess.Read);


                        FormNueva('H');


                        RaizContent = List_Leafs.First();


                        if (FileType == ".bin")
                        {

                            List<int> List_Nums = new List<int>();
                            using (BinaryReader binaryReader = new BinaryReader(Arch))
                            {
                                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                                {
                                    int num_aux = binaryReader.ReadInt32();
                                    AddNum(num_aux);
                                }
                            }


                        }
                        else if (FileType == ".txt")
                        {

                            StreamReader Reader;
                            Reader = new StreamReader(Arch);


                            string texto = Reader.ReadToEnd();
                            texto.Trim(' ');

                            string[] content = texto.Split(',');

                            var listaOrdenada = content.OrderBy(numero => numero).ToList();

                            int aux = 0;


                            foreach (string c in listaOrdenada)
                            {
                                if (int.TryParse(c, out aux))
                                {
                                    AddNum(aux);
                                }
                            }

                        }




                        Arch.Close();
                        Flag = false;

                        txt_EOF.Clear();
                        txt_EOF.Text += Size;

                        txt_DirRaiz.Clear();
                        txt_DirRaiz.Text += RaizContent.Direccion;

                        string TxtFileDir = Path.GetDirectoryName(Archivo);
                        string BinFileName = Path.Combine(TxtFileDir, Path.GetFileNameWithoutExtension(Archivo) + ".bin");


                        CreateBinSampleTxt(Archivo, BinFileName);



                    }*/



            }
        }




        private Leaf FormNueva(char t)
        {
            Leaf Aux_Leaf = new Leaf(Grado);


            Aux_Leaf.Direccion = Size;
            Aux_Leaf.Tipo = t;
            Aux_Leaf.aux_Cuenta = CuentaIntro;

            Size += 65;
            List_Leafs.Add(Aux_Leaf);
            CuentaIntro++;


            return Aux_Leaf;
        }



        private void CierraArch(object sender, EventArgs e)
        {
            List_Leafs = new List<Leaf>();

            ListDatos = new List<Tree_BMas>();

            list_Content = new List<long>();
            RaizContent = null;

            Size = 1000;
            InsertaDatos();
            txt_DirRaiz.Clear();
            txt_DirRaiz.Text += Size;
        }



        private void btn_Save_Click(object sender, EventArgs e)
        {

            SaveBinFile();


        }


        public void DivideSheet(Leaf Parent_M)
        {
            if (RaizContent.list_Content.Count > Grado - 1)
            {
                Parent_M = FormNueva('I');

                int aux_Cuenta = 0;

                foreach (var R in RaizContent.list_Content)
                {

                    if (aux_Cuenta >= 2)
                    {

                        Parent_M.list_Content.Add(R);
                        Parent_M.list_Dir.Add(RaizContent.list_Dir[aux_Cuenta + 1]);

                    }


                    aux_Cuenta++;
                }

                foreach (var R in Parent_M.list_Content)
                {

                    if (RaizContent.list_Content.Contains(R))
                    {

                        RaizContent.list_Content.Remove(R);
                    }

                }


                foreach (var P in Parent_M.list_Dir)
                {

                    if (RaizContent.list_Dir.Contains(P))
                    {

                        RaizContent.list_Dir.Remove(P);
                    }


                }

            }

            Parent_M.Tipo = 'I';

            Leaf RaizPrincipal = FormNueva('R');
            RaizPrincipal.list_Dir.Add(RaizContent.Direccion);

            InsertaNodo(RaizPrincipal, Parent_M);

            RaizContent.Tipo = 'I';
            RaizContent = RaizPrincipal;


            txt_DirRaiz.Clear();
            txt_DirRaiz.Text += RaizContent.Direccion;

        }



        private void CreateBinSampleTxt(string TxtFile, string BinFile)
        {
            List<int> Aux_ContentList = new List<int>();



            using (StreamReader reader = new StreamReader(TxtFile))
            {
                string Content = reader.ReadToEnd();
                string[] Sections = Content.Split(',');

                foreach (string Fract in Sections)
                {

                    if (int.TryParse(Fract.Trim(), out int dato))
                    {

                        Aux_ContentList.Add(dato);

                    }
                }
            }


            using (BinaryWriter writer = new BinaryWriter(File.Open(BinFile, FileMode.Create)))
            {
                foreach (int dato in Aux_ContentList)
                {
                    writer.Write(dato);
                }
            }
        }






        private void SpreadSheet(Leaf Dato)
        {
            Leaf parienteM = FormNueva(Dato.Tipo);
            int aux_Cuenta = 0;


            foreach (var AuxSeparate in Dato.list_Content)
            {
                if (Dato.Tipo == 'H' || Dato.Tipo == 'R')
                {
                    if (aux_Cuenta >= 2)
                    {
                        parienteM.list_Content.Add(AuxSeparate);
                        parienteM.list_Dir.Add(Dato.list_Dir[aux_Cuenta]);

                        if (Dato.Tipo == 'R' && Dato.list_Content.Last() == AuxSeparate)
                        {
                            parienteM.list_Dir.Add(Dato.list_Dir[aux_Cuenta] + 1);
                        }
                    }
                }
                else
                {
                    if (aux_Cuenta >= 3)
                    {
                        parienteM.list_Content.Add(AuxSeparate);
                        parienteM.list_Dir.Add(Dato.list_Dir[aux_Cuenta]);
                    }
                }
                aux_Cuenta++;
            }
            foreach (var Aux2 in parienteM.list_Content)
            {

                if (Dato.list_Content.Contains(Aux2))
                {
                    Dato.list_Content.Remove(Aux2);
                }
            }


            foreach (var Aux_Parent in parienteM.list_Dir)
            {


                if (Dato.list_Dir.Contains(Aux_Parent))
                {


                    Dato.list_Dir.Remove(Aux_Parent);

                }
            }


            if (Dato.Tipo != 'R')
            {
                Leaf padre = getPadre(Dato.Direccion);
                InsertaNodo(padre, parienteM);
            }
            else
            {
                DivideSheet(parienteM);
            }
        }



        public void RSpread()
        {


            Leaf Parent_M = FormNueva('H');

            Leaf RaizPrincipal = FormNueva('R');


            int aux_Cuenta = 0;

            foreach (var R in RaizContent.list_Content)
            {
                if (aux_Cuenta >= 2)
                {


                    Parent_M.list_Content.Add(R);
                    Parent_M.list_Dir.Add(RaizContent.list_Dir[aux_Cuenta]);


                }
                aux_Cuenta++;
            }
            foreach (var R in Parent_M.list_Content)
            {

                if (RaizContent.list_Content.Contains(R))
                {

                    RaizContent.list_Content.Remove(R);
                }
            }
            foreach (var P in Parent_M.list_Dir)
            {

                if (RaizContent.list_Dir.Contains(P))
                {


                    RaizContent.list_Dir.Remove(P);
                }

            }

            RaizPrincipal.list_Content.Add(getLeftH(Parent_M));
            RaizPrincipal.list_Dir.Add(RaizContent.Direccion);
            RaizPrincipal.list_Dir.Add(Parent_M.Direccion);


            RaizContent = RaizPrincipal;
            txt_DirRaiz.Clear();
            txt_DirRaiz.Text += RaizContent.Direccion;
        }



        private Leaf getPadre(long dirHijo)
        {
            Leaf padre = null;
            foreach (var a in List_Leafs)
            {
                if (a.list_Dir.Contains(dirHijo))
                {
                    padre = a;
                    break;
                }
            }

            return padre;

        }


        public long getLeftH(Leaf Leaf)
        {
            long menor;
            menor = Leaf.list_Content.First();
            return menor;
        }


        private void InsertaDatos()
        {
            Res_Arbol.Rows.Clear();
            int contador = 0;
            foreach (var data in List_Leafs)
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.Cells.Add(new DataGridViewTextBoxCell { Value = data.Direccion });
                fila.Cells.Add(new DataGridViewTextBoxCell { Value = data.Tipo });
                foreach (var l in data.list_Dir)
                {
                    fila.Cells.Add(new DataGridViewTextBoxCell { Value = l });
                    if (data.list_Dir.IndexOf(l) < data.list_Content.Count)
                    {
                        fila.Cells.Add(new DataGridViewTextBoxCell { Value = data.list_Content[data.list_Dir.IndexOf(l)] });
                    }
                    contador++;
                }
                if (contador <= Grado - 1)
                {
                    if (data.Tipo == 'H')
                    {
                        for (; contador < Grado - 1; contador++)
                        {
                            fila.Cells.Add(new DataGridViewTextBoxCell { Value = "-1" });
                            fila.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                        }
                        fila.Cells.Add(new DataGridViewTextBoxCell { Value = "-1" });
                    }
                    else
                    {
                        for (; contador < Grado; contador++)
                        {
                            fila.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                            fila.Cells.Add(new DataGridViewTextBoxCell { Value = "-1" });
                        }
                    }
                }
                Res_Arbol.Rows.Add(fila);
                contador = 0;
            }

            foreach (var data in ListDatos)
            {
                Res_Arbol.Rows.Add(data.Direccion, data.Tipo, data.Direccion_Next, data.Num);
            }
            Res_Arbol.Sort(Res_Arbol.Columns[0], ListSortDirection.Ascending);
        }













































        public Leaf getRIH(long Direccion)
        {
            Leaf look = null;
            foreach (var a in List_Leafs)
            {
                if (a.Direccion == Direccion)
                {
                    look = a;
                    break;
                }
            }
            return look;
        }








        public Leaf AuxLeaf(int num, Leaf actual)
        {
            Leaf found = null;
            if (actual.Tipo == 'H')
            {
                return actual;
            }
            else
            {
                foreach (var r in actual.list_Content)
                {
                    if (num < r)
                    {
                        found = AuxLeaf(num, getRIH(actual.list_Dir[actual.list_Content.IndexOf(r)]));
                        break;
                    }
                    else
                    {
                        if (actual.list_Content.Last() == r)
                        {
                            found = AuxLeaf(num, getRIH(actual.list_Dir[actual.list_Content.IndexOf(r) + 1]));
                            break;
                        }
                    }
                }

            }
            return found;
        }


    }
}
