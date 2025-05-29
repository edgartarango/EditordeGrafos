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


//----------------------------------------------------- CHRIS ------------------------------------------------------

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
            printDegrees();
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
                Tarjan(root);
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
                Tarjan(root);

            }
            else
            {
                Res_Euler.Text = " Ni camino ni circuito ";
            }


            /*
            var _circuito = circuitos[0];
            circuitos.Add(string.Join(" ", visitados));
            int i = 0;
            foreach (var c in circuitos)
            {
                Console.WriteLine(c);
                if (i > 0)
                {
                    var stringBuildder = new StringBuilder(_circuito);
                    stringBuildder.Insert(_circuito.IndexOf(c[0]), c.Substring(0, c.Length - 1));
                    _circuito = stringBuildder.ToString();
                }
                i++;

            }
            Console.WriteLine($"circuito total: " + _circuito);
            Res_Euler.Text += " " + _circuito;*/


            //VERSION ANTERIOR
            circuitos.Add(string.Join(" ", visitados));

            foreach (var c in circuitos)
            {
                Res_Euler.Text += " " + c;
                Console.WriteLine(c);

            }




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
        private void Tarjan(NodeP nodo)
        {
            visitados.Add(nodo);


            foreach (var item in nodo.relations)
            {
                var nodoAux = item.Up;
                var arista = encuentraArista(nodo, nodoAux);
                if (!arista.Visited)
                {
                    arista.Visited = true;
                    Tarjan(nodoAux);
                }
            }

            if (!graph.AllEdgesVisited())
            {
                var siguiente = visitados.Find(nodoT => nodoT.relations.Exists(r => !encuentraArista(nodoT, r.Up).Visited));
                Console.WriteLine("sig: " + siguiente);
                if (siguiente != null)
                {
                    circuitos.Add(string.Join(" ", visitados));
                    visitados = new List<NodeP>();
                    Tarjan(siguiente);
                }
            }
        }

        private Edge encuentraArista(NodeP a, NodeP b)
        {
            return graph.EdgesList.Find(arista => arista.Source == a && arista.Destiny == b || arista.Source == b && arista.Destiny == a);
        }
    }
}
