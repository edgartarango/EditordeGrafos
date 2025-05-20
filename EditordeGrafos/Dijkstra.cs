


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
    public partial class Dijkstra : Form
    {
        private Graph graph;



        private List<string> ListaRes = new List<string>();

        public Dijkstra(Graph graph)
        {
            this.graph = graph;
            InitializeComponent();
            Tabla_Mod.AutoGenerateColumns = false;

            if (graph == null || graph.Count == 0)
            {
                MessageBox.Show(" ERROR: No se ha cargado ningún grafo. ");
                Close();

                return;
            }





            graph.UnselectAllEdges();
            graph.UnselectAllNodes();




            foreach (NodeP nodoP in graph)
            {
                Raiz_Dijkstra.Items.Add(nodoP.Name);
            }
            Raiz_Dijkstra.SelectedIndex = 0;

            foreach (var item in graph)
            {
                Tabla_Mod.Columns.Add(item.Name, item.Name);
                Tabla_Orig.Columns.Add(item.Name, item.Name);
            }


        }


        public void EjecutarDijkstra(int indiceOrigen)
        {
            //Detalles_Dijkstra.AppendText("\nNodo seleccionado es el: " + graph[indiceOrigen].Name + "\n");
            int numeroNodos = graph.Count;
            int[] distancias = new int[numeroNodos];
            int[] auxArr = new int[numeroNodos];
            int[] arrAux2 = new int[numeroNodos];
            bool[] visitados = new bool[numeroNodos];

            for (int i = 0; i < numeroNodos; i++)
            {
                distancias[i] = int.MaxValue;
                visitados[i] = false;
            }

            distancias[indiceOrigen] = 0;

            for (int contador = 0; contador < numeroNodos - 1; contador++)
            {
                int u = EncontrarDistanciaMinima(distancias, visitados);

                if (u >= 0)
                {
                    visitados[u] = true;

                    foreach (var vecino in graph[u].relations.Select(x => x.Up).ToList())
                    {
                        int v = graph.IndexOf(vecino);
                        Edge arista = graph.GetEdge(graph[u], vecino);

                        if (!visitados[v] && distancias[u] != int.MaxValue && distancias[u] + arista.Weight < distancias[v])
                        {
                            distancias[v] = distancias[u] + arista.Weight;

                            if (distancias[u] != 0)
                            {
                                string texto = "\n Se modifica " + vecino.Name + ":";
                                texto += "\n" + " [" + graph[indiceOrigen].Name + ", " + graph[u].Name + "] " + " = " + distancias[u].ToString();
                                texto += "\n" + " [" + graph[indiceOrigen].Name + "," + graph[u].Name + "] " + " [" + graph[u].Name + "," + vecino.Name + "] " + " = " + distancias[u].ToString() + " + " + arista.Weight.ToString() + " = " + distancias[v].ToString();
                                Detalles_Dijkstra.AppendText(texto);
                                Detalles_Dijkstra.AppendText("\n");
                                arrAux2[v] = distancias[v];
                            }
                            else
                                arrAux2[v] = int.MaxValue;
                        }
                    }
                }
            }

            for (int i = 0; i < numeroNodos; i++)
            {
                Tabla_Mod.Rows[0].Cells[i].Value = distancias[i] != int.MaxValue ? distancias[i].ToString() : "∞";
            }


            for (int i = 0; i < numeroNodos; i++)
            {
                if (distancias[i] == 0)
                    auxArr[i] = int.MaxValue;
                else
                    auxArr[i] = distancias[i];


            }
            int indiceMinimo = Array.IndexOf(auxArr, auxArr.Min());
            int val;
            if (auxArr.Min() == int.MaxValue)
                val = 0;
            else
                val = auxArr.Min();
            string text2 = "El camino mas corto es: " + "[" + graph[indiceOrigen].Name + "," + graph[indiceMinimo].Name + "] = " + val;
            Detalles_Dijkstra.AppendText("\n" + text2);
            int band = 0;

            for (int i = 0; i < numeroNodos; i++)
            {
                if (arrAux2[i] == val)
                {
                    band = i;
                }

            }

            if (band == 1)
            {
                Detalles_Dijkstra.AppendText("\n Usa pivote");
            }
            else
                Detalles_Dijkstra.AppendText("\n Resultado es directo");

        }
        private int EncontrarDistanciaMinima(int[] distancias, bool[] visitados)
        {
            int minimaDistancia = int.MaxValue;
            int indiceMinimaDistancia = -1;

            for (int v = 0; v < distancias.Length; v++)
            {
                if (!visitados[v] && distancias[v] < minimaDistancia)
                {
                    minimaDistancia = distancias[v];
                    indiceMinimaDistancia = v;
                }
            }

            return indiceMinimaDistancia;
        }



        private async void DijkstraButton_Click(object sender, EventArgs e)
        {
            List<dynamic> dynamics = new List<dynamic>();

            var nodoOrigen = graph[Raiz_Dijkstra.SelectedIndex];
            var nodosVecinos = nodoOrigen.relations.Select(x => x.Up).ToList();

            if (graph == null || graph.Count == 0)
            {
                MessageBox.Show(" ERROR: No se ha cargado ningún grafo. ");
                Close();

                return;
            }

            Detalles_Dijkstra.Clear();
            int indexOrigen = Raiz_Dijkstra.SelectedIndex;


            /*
            foreach (var item in graph)
            {


                if (item == nodoOrigen)
                    dynamics.Add(0);
                else if (nodosVecinos.Contains(item))
                {

                    Edge edge = graph.GetEdge(nodoOrigen, item);
                    dynamics.Add(edge.Weight);

                }
                else
                    dynamics.Add(" ∞ ");
            }


            for (int i = 0; i < dynamics.Count; i++)
            {

                Tabla_Mod.Rows[0].Cells[i].Value = dynamics[i];

                Tabla_Orig.Rows[0].Cells[i].Value = dynamics[i];

            }*/

            /*
             graph.UnselectAllEdges();
             graph.UnselectAllNodes(); 
             CalculaRuta(nodoOrigen, 0, nodoOrigen, true);

             graph.UnselectAllEdges();
             graph.UnselectAllNodes();
             CalculaRuta(nodoOrigen, 0, nodoOrigen, false);
            */




            Tabla_Orig.Rows.Clear();
            Tabla_Orig.Columns.Clear();

            Tabla_Mod.Rows.Clear();
            Tabla_Mod.Columns.Clear();


            Generator(graph, indexOrigen);
            EjecutarDijkstra(indexOrigen);

        }


        public void Generator(Graph graph, int Target)
        {
            List<string> listaSt = new List<string>();
            var NFirst = graph[Target];


            foreach (NodeP col in graph)
            {
                Tabla_Orig.Columns.Add(col.Name, col.Name);
                Tabla_Mod.Columns.Add(col.Name, col.Name);
            }

            listaSt.Add(Raiz_Dijkstra.Name);
            listaSt = new List<string>();


            Tabla_Orig.Rows[0].Cells[Target].Value = 0;



            for (int i = 0; i < graph.Count; i++)
            {
                if (i == Target)
                {

                    ListaRes.Add((Tabla_Orig.Rows[0].Cells[i].Value = 0).ToString());

                }
                else if (NFirst.relations.Select(x => x.Up).Contains(graph[i]))
                {

                    ListaRes.Add((Tabla_Orig.Rows[0].Cells[i].Value = graph.GetEdge(NFirst, graph[i]).Weight).ToString());

                }
                else
                {

                    ListaRes.Add((Tabla_Orig.Rows[0].Cells[i].Value = " ∞ ").ToString());

                }


            }
        }






        private void CalculaRuta(NodeP nodeP, int costo, NodeP nodoPadre, bool origen)
        {

            var ordenacion = origen ? nodeP.relations.Select(x => x.Up) :
                nodeP.relations.Select(x => x.Up).ToList().OrderByDescending(x => x.Name);

            foreach (var item in ordenacion)
            {

                Edge edge = graph.GetEdge(nodeP, item);
                if (edge == null || edge.Visited)
                {
                    edge.Visited = false;
                    continue;
                }

                edge.Visited = true;

                if (nodoPadre == item)
                    continue;

                var costoAux = costo + edge.Weight;
                var cell = Tabla_Mod.Rows[0].Cells[item.Name];
                int valor = cell.Value == " ∞ " ? int.MaxValue : Convert.ToInt32(cell.Value);
                cell.Value = Math.Min(valor, costoAux);

                CalculaRuta(item, costoAux, nodoPadre, origen);
            }
        }
    }
}
