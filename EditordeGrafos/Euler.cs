using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;






namespace EditordeGrafos
{
    public partial class Euler : Form
    {
        private Graph graph;

        public Euler(Graph graph)
        {
            InitializeComponent();
            this.graph = graph;
        }

        private void EulerButton_Click(object sender, EventArgs e)
        {
            // Borra el contenido de los campos
            Res_Euler.Text = string.Empty;
            CamOCirc.Text = string.Empty;
            MuestraRaiz_Euler.Text = string.Empty;

            // Verifica si el grafo está cargado
            if (graph == null || graph.Count == 0)
            {
                Res_Euler.Text = "No se ha cargado un grafo.";
                return;
            }
            graph.UnselectAllEdges();
            OrdenaAdy();
            //printDegrees();
            euler();
        }

        List<NodeP> visitados;

        private void euler()
        {
            var odd_no_dir = graph.FindAll(node => node.Degree % 2 != 0);
            var odd_dir = graph.FindAll(node => node.DegreeEx != node.DegreeIn);
            var odd = graph.EdgeIsDirected ? odd_dir : odd_no_dir;
            Console.WriteLine($"odds: [{string.Join(", ", odd)}]");
            visitados = new List<NodeP>();
            circuitos = new List<string>();
            NodeP root = null;
            if (odd.Count == 0 && graph.Count >= 2)
            {
                //circuito euleriano
                root = graph[0];
                MuestraRaiz_Euler.Text = root.Name;
                Tarjan(root, false);
                CamOCirc.Text = "Cicuito Euleriano";
            }
            else if (odd.Count == 2)
            {
                //camino: comienza en uno, termina en el otro
                if (!graph.EdgeIsDirected)
                {
                    //obtenemos el mayor de los impares
                    root = odd.OrderByDescending(node => node.Degree).FirstOrDefault();
                    MuestraRaiz_Euler.Text = root.Name;
                    CamOCirc.Text = "Camino Euleriano";
                }
                else
                {
                    //buscamnos a i
                    root = odd.Find(node => node.DegreeIn < node.DegreeEx);
                    MuestraRaiz_Euler.Text = root.Name;
                    CamOCirc.Text = "Camino Euleriano";
                }
                Console.WriteLine("odd root: " + root);
                Tarjan(root, true);
                #region codigo anterior

                //var impares_no_dirigidos = graph.FindAll(nodo => nodo.Degree % 2 != 0);
                //var impares_dirigidos = graph.FindAll(nodo => (nodo.DegreeIn + nodo.DegreeEx) % 2 != 0);
                //var impares = graph.EdgeIsDirected ? impares_dirigidos : impares_no_dirigidos;
                //visitados = new List<NodeP>();
                //graph.UnselectAllEdges();

                //if (impares.Count == 0)
                //{
                //    // Circuito de euler
                //    var impar = graph.First();
                //    Tarjan(impar);
                //    CamOCirc.Text = "Circuito";
                //}
                //else if (impares.Count == 2)
                //{
                //    // Camino de euler
                //    NodeP impar;
                //    if (graph.EdgeIsDirected)
                //    {
                //        impar = impares.Find(nodo => nodo.DegreeEx > nodo.DegreeIn);
                //    }
                //    else
                //    {
                //        impar = impares.OrderByDescending(nodo => nodo.Degree).FirstOrDefault();
                //    }
                //    // Llamada
                //    Tarjan(impar);
                //    CamOCirc.Text = "Camino";
                //}

                //// Muestra la raíz en MuestraRaiz_Euler
                //if (visitados.Count > 0)
                //{
                //    MuestraRaiz_Euler.Text = "Raíz (Nodo raíz): " + visitados[0].Name;
                //}

                //// Muestra el recorrido Euler en Res_Euler
                //if (visitados.Count > 0)
                //{
                //    Res_Euler.Text = "Raíz (Nodo raíz): " + string.Join(" ", visitados.Select(node => node.Name));
                //}
                #endregion
            }
            else
            {
                Res_Euler.Text = " Ni camino ni circuito ";
            }
            circuitos.Add(string.Join(" ", visitados));
            var _circuito = circuitos[0];
            int i = 0;
            foreach (var c in circuitos)
            {
                //Console.WriteLine(c);
                if (i > 0)
                {
                    var stringBuildder = new StringBuilder(_circuito);
                    stringBuildder.Insert(_circuito.IndexOf(c[0]), c.Substring(0, c.Length - 1));
                    _circuito = stringBuildder.ToString();
                }
                i++;
            }
            //Console.WriteLine($"circuito total: " + _circuito);
            Res_Euler.Text += " " + _circuito;
        }

        public void OrdenaAdy()
        {
            graph.Sort((node1, node2) => node1.Name.CompareTo(node2.Name));
            graph.ForEach(node => node.relations.Sort((rel1, rel2) => rel1.Up.Name.CompareTo(rel2.Up.Name)));
        }


        private List<string> circuitos;

        private void printDegrees()
        {
            foreach (var node in graph)
            {
                Console.WriteLine($"{node}: Degree = {node.Degree}, DegreeIN = {node.DegreeIn}, DegreeEX = {node.DegreeEx}");
            }
        }
        private void Tarjan(NodeP nodo, bool esCamino, bool ciclo = false)
        {
            visitados.Add(nodo);
            if (!ciclo)
                foreach (var item in nodo.relations)
                {
                    var nodoAux = item.Up;
                    var arista = encuentraArista(nodo, nodoAux);
                    if (!arista.Visited)
                    {
                        if (!esCamino && nodoAux == visitados[0]) ciclo = true;
                        else ciclo = false;
                        arista.Visited = true;
                        Tarjan(nodoAux, esCamino, ciclo);
                    }
                }
            if (!graph.AllEdgesVisited())
            {
                // se elimina el primero de la lista actual de visitados, porque no se considera
                var _visitados = visitados.ToList();
                _visitados.RemoveAt(0);
                var siguiente = _visitados.Find(nodoT => nodoT.relations.Exists(r => !encuentraArista(nodoT, r.Up).Visited));
                Console.WriteLine("sig: " + siguiente);
                if (siguiente != null)
                {
                    circuitos.Add(string.Join(" ", visitados));
                    visitados = new List<NodeP>();
                    Tarjan(siguiente, esCamino);
                }
            }
        }

        private Edge encuentraArista(NodeP a, NodeP b)
        {
            return graph.EdgesList.Find(arista => arista.Source == a && arista.Destiny == b || arista.Source == b && arista.Destiny == a);
        }
    }
}
