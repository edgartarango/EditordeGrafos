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
    public partial class busqAmp : Form
    {

        private Graph graph;

        public busqAmp(Graph graph)
        {
            InitializeComponent();
            this.graph = graph;

            foreach (NodeP nodoP in graph)
            {
                RaizSelected.Items.Add(nodoP.Name);
            }


        }


        public void OrdenaAdy()
        {
            graph.Sort((node1, node2) => node1.Name.CompareTo(node2.Name));

            graph.ForEach(node => node.relations.Sort((rel1, rel2) => rel1.Up.Name.CompareTo(rel2.Up.Name)));



        }





        private List<NodeP> visitado;

        private void BFS(int raizIndex, Graph graph)
        {
            OrdenaAdy();
            foreach (var node in graph)
            {
                Console.Write($"{node.Name} -> ");
                Console.WriteLine($"[{string.Join(", ", node.relations)}]");

            }
            //return;


            visitado.Add(graph[raizIndex]);

            Queue<int> cola = new Queue<int>();
            cola.Enqueue(raizIndex);

            Res_Recorrido.AppendText("Raiz(" + graph[raizIndex].Name + "): ");
            while (cola.Count > 0)
            {
                var _index = cola.Dequeue();
                foreach (NodeR nodoR in graph[_index].relations)
                {
                    if (!visitado.Contains(nodoR.Up))
                    {
                        visitado.Add(nodoR.Up);
                        cola.Enqueue(ConvierteLetra(nodoR.Up.Name));
                        Res_Recorrido.AppendText(nodoR.Up.Name + " ");
                    }

                }
            }

            var index = graph.FindIndex(node => !visitado.Contains(node));
            if (index != -1)
                BFS(index, graph);

        }





        /*
                private void BFS(int raizIndex, Graph graph)
                {
                    OrdenaAdy();
                    foreach (var node in graph)
                    {
                        Console.Write($"{node.Name} -> ");
                        Console.WriteLine($"[{string.Join(", ", node.relations)}]");

                    }
                    //return;


                    visitado.Add(graph[raizIndex]);

                    Queue<int> cola = new Queue<int>();

                    Res_Recorrido.AppendText("Raiz(" + graph[raizIndex].Name + "): ");

                    foreach (NodeR nodoR in graph[raizIndex].relations)
                    {
                        if (!visitado.Contains(nodoR.Up))
                        {
                            visitado.Add(nodoR.Up);
                            cola.Enqueue(ConvierteLetra(nodoR.Up.Name));
                            Res_Recorrido.AppendText(nodoR.Up.Name + " ");

                        }

                    }


                    var index = graph.FindIndex(node => !visitado.Contains(node));
                    if (index != -1)
                        BFS(index, graph);


                    if (visitado.Count < graph.Count)
                    {
                        BFS(raizIndex, graph);
                    }*/

        //while (visitado.Count != graph.Count)
        //{

        //    while (cola.Count > 0)
        //    {

        //     // Lista temporal para almacenar los nombres de los nodos adyacentes
        //        List<string> adyacentesNombres = new List<string>();
        //        int nodo = cola.Dequeue();

        //        //if (!visitado.Contains(graph[nodo]))


        //        foreach (NodeR nodoR in graph[nodo].relations.OrderBy(x => x.Name))
        //        {
        //            if (!visitado.Contains(nodoR.Up))
        //            {
        //                visitado.Add(nodoR.Up);
        //                cola.Enqueue(ConvierteLetra(nodoR.Up.Name));
        //                Res_Recorrido.AppendText(nodoR.Up.Name + " ");

        //            }


        //        }
        //    }



        //    foreach (NodeP nodoP in graph)
        //    {
        //        if (!visitado.Contains(nodoP))
        //        {
        //            visitado.Add(nodoP);
        //            cola.Enqueue(graph.IndexOf(nodoP));

        //            Res_Recorrido.AppendText("Raiz(" + nodoP.Name + "): ");
        //            break;
        //        }
        //    }


        //}











        //ULTIMA VERSION REALIZADA
        /*
        
        private void BFS(int raizIndex, Graph graph)
        {
            List<NodeP> visitado = new List<NodeP>();
            Queue<int> cola = new Queue<int>();
            //Res_Recorrido.AppendText("Raiz(" + graph[raizIndex].Name + "): ");

            visitado.Add(graph[raizIndex]);
            cola.Enqueue(raizIndex);
            Res_Recorrido.AppendText("Raiz(" + graph[raizIndex].Name + "): ");

            while (cola.Count > 0)
            {



                int nodoIndex = cola.Dequeue();
                NodeP nodoActual = graph[nodoIndex];

                if (nodoIndex != raizIndex) // Evitar imprimir el nodo raíz en el recorrido
                {
                    Res_Recorrido.AppendText("\n" + nodoActual.Name + " ");
                }

                //Res_Recorrido.AppendText(nodoActual.Name + " ");

                foreach (NodeR nodoR in nodoActual.relations)
                {
                    if (!visitado.Contains(nodoR.Up))
                    {
                        visitado.Add(nodoR.Up);
                        cola.Enqueue(ConvierteLetra(nodoR.Up.Name));
                    }
                }
            }
            var nRest = new List<NodeP>();
            foreach (var item in graph)
            {
                if (!visitado.Contains(item))
                {
                    nRest.Add(item);
                }
            }
            if (nRest.Count > 0)
            {
                BFS(ConvierteLetra(nRest[0].Name), graph);
            }

        }
        
        */



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

        private void bfsButton_Click(object sender, EventArgs e)
        {
            Res_Recorrido.Clear(); // Limpiar el resultado anterior

            if (graph.Count == 0)
            {
                Res_Recorrido.Text = "La matriz de adyacencia está vacía.";
                return;
            }


            if (RaizSelected.SelectedItem == null)
            {

                Res_Recorrido.Text = "No existe un grafo";
                return;
            }

            string raizText = RaizSelected.SelectedItem.ToString(); //ComboBox Lista Desplegable


            if (string.IsNullOrEmpty(raizText))
            {
                Res_Recorrido.Text = "Por favor, ingrese un nodo raíz.";
                return;
            }

            int raizIndex = ConvierteLetra(raizText); //convierte la letra del nodo a entero

            if (raizIndex < 0 || raizIndex >= graph.Count)
            {
                Res_Recorrido.Text = "El nodo raíz indicado no es válido.";
                return;
            }

            /*if (graph[raizIndex].relations.Count < 0 || graph[raizIndex].relations.Count > 2)
            {
                Res_Recorrido.Text = "Raíz no válida";
                return;
            }*/
            visitado = new List<NodeP>();

            BFS(raizIndex, graph);
        }

    }
}





