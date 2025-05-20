using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace EditordeGrafos
{
    public partial class busqProf : Form
    {


        private Graph graph;


        public busqProf(Graph graph)
        {
            InitializeComponent();

            this.graph = graph;

            foreach (NodeP nodoP in graph)
            {
                DFS_RaizSelected.Items.Add(nodoP.Name);
            }


        }








        private void dfsButton_Click(object sender, EventArgs e)
        {
            Res_DFS.Clear(); // Limpiar el resultado anterior

            if (graph.Count == 0)
            {
                Res_DFS.Text = "La matriz de adyacencia está vacía.";
                return;
            }


            if (DFS_RaizSelected.SelectedItem == null)
            {

                Res_DFS.Text = "No existe un grafo";
                return;
            }

            string raizText = DFS_RaizSelected.SelectedItem.ToString(); //ComboBox Lista Desplegable


            if (string.IsNullOrEmpty(raizText))
            {
                Res_DFS.Text = "Por favor, ingrese un nodo raíz.";
                return;
            }

            int raizIndex = ConvierteLetra(raizText); //convierte la letra del nodo a entero

            if (raizIndex < 0 || raizIndex >= graph.Count)
            {
                Res_DFS.Text = "El nodo raíz indicado no es válido.";
                return;
            }


            //--------------------------------- CORREGIR ------------------------------------------------------
            if (graph.EdgeIsDirected && graph[raizIndex].relations.Count > 2)
            {
                Res_DFS.Text = "Raíz no válida";
                return;
            }

            DFS(raizIndex, graph);

            // DFS(raizIndex, graph);*
        }




        public void OrdenaAdy()
        {
            graph.Sort((node1, node2) => node1.Name.CompareTo(node2.Name));

            graph.ForEach(node => node.relations.Sort((rel1, rel2) => rel1.Up.Name.CompareTo(rel2.Up.Name)));



        }



        private void DFS(int raizIndex, Graph graph)
        {

            List<NodeP> visitado = new List<NodeP>();

            OrdenaAdy();

            // Define una función interna iterativa para realizar el DFS en preorden
            void DFS_Preorden(int nodoIndex, bool root, NodeP padre = null)
            {

                NodeP nodoActual = graph[nodoIndex];
                visitado.Add(nodoActual);



                if (root)
                    Res_DFS.AppendText("Raiz(" + nodoActual.Name + ") " + " ");
                else
                    Res_DFS.AppendText(nodoActual.Name + " ");


                foreach (NodeR nodoR in nodoActual.relations)
                {
                    /*if(padre != null && !graph.EdgeIsDirected && nodoR.Up == padre)
                    {
                        continue;

                    }*/
                    if (!visitado.Contains(nodoR.Up))
                    {
                        DFS_Preorden(ConvierteLetra(nodoR.Up.Name), false, nodoActual);
                    }
                }





            }


            // Llama a la función DFS_Preorden con el nodo raíz
            DFS_Preorden(raizIndex, true);

            while (visitado.Count != graph.Count)
            {
                foreach (NodeP nodoP in graph)
                {

                    if (!visitado.Contains(nodoP))
                    {
                        DFS_Preorden(ConvierteLetra(nodoP.Name), true);
                    }
                }
            }
        }






        public int ConvierteLetra(string letra)//Habia error al momento de convertir de letras a numeros, por lo que se implemento otra condicion para que funcionara correctamente.
        {
            int Num = 0;

            if (letra == "A" || letra == "0")
            {
                Num = 0;
            }
            else if (letra == "B" || letra == "1")
            {
                Num = 1;
            }
            else if (letra == "C" || letra == "2")
            {
                Num = 2;
            }
            else if (letra == "D" || letra == "3")
            {
                Num = 3;
            }
            else if (letra == "E" || letra == "4")
            {
                Num = 4;
            }
            else if (letra == "F" || letra == "5")
            {
                Num = 5;
            }
            else if (letra == "G" || letra == "6")
            {
                Num = 6;
            }
            else if (letra == "H" || letra == "7")
            {
                Num = 7;
            }
            else if (letra == "I" || letra == "8")
            {
                Num = 8;
            }
            else if (letra == "J" || letra == "9")
            {
                Num = 9;
            }
            else if (letra == "K" || letra == "10")
            {
                Num = 10;
            }
            else if (letra == "L" || letra == "11")
            {
                Num = 11;
            }
            else if (letra == "M" || letra == "12")
            {
                Num = 12;
            }
            else if (letra == "N" || letra == "13")
            {
                Num = 13;
            }
            else if (letra == "O" || letra == "14")
            {
                Num = 14;
            }
            else if (letra == "P" || letra == "15")
            {
                Num = 15;
            }
            else if (letra == "Q" || letra == "16")
            {
                Num = 16;
            }
            else if (letra == "R" || letra == "17")
            {
                Num = 17;
            }
            else if (letra == "S" || letra == "18")
            {
                Num = 18;
            }
            else if (letra == "T" || letra == "19")
            {
                Num = 19;
            }
            else if (letra == "U" || letra == "20")
            {
                Num = 20;
            }
            else if (letra == "V" || letra == "21")
            {
                Num = 21;
            }
            else if (letra == "W" || letra == "22")
            {
                Num = 22;
            }
            else if (letra == "X" || letra == "23")
            {
                Num = 23;
            }
            else if (letra == "Y" || letra == "24")
            {
                Num = 24;
            }
            else if (letra == "Z" || letra == "25")
            {
                Num = 25;
            }
            return Num;

        }



    }
}
