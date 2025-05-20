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
    public partial class compConexos : Form
    {

        private Graph graph;
        public compConexos(Graph graph)
        {
            InitializeComponent();
            this.graph = graph;
        }

        private void ConexosButton_Click(object sender, EventArgs e)
        {
            //Chechar si es binario y si  no es dirigido, te toca pa



            Res_conexos.Text = string.Empty;
            var aux = graph.Select(x => x.relations.Count).ToList();
            var raizPadre = graph[aux.IndexOf(aux.Max())];
            this.MuestraRaiz.Text = raizPadre.Name;

            var visitados = new List<NodeP>();
            var circutos = new List<string>();
            OrdenaAdy();
            Tarjan(raizPadre, new List<char>(), circutos, visitados);
            foreach (var item in circutos)
            {

                Res_conexos.Text += item + "\n ";
            }
            var nose = circutos.Select(x => x[0]);
            var nn = nose.Distinct().ToList();
            textBoxArt.Text = string.Join(", ", nn);


        }


        public void OrdenaAdy()
        {
            graph.Sort((node1, node2) => node1.Name.CompareTo(node2.Name));

            graph.ForEach(node => node.relations.Sort((rel1, rel2) => rel1.Up.Name.CompareTo(rel2.Up.Name)));



        }



        private Stack<NodeP> Pila = new Stack<NodeP>();

        private void Tarjan(NodeP nodo, List<char> aux, List<string> circuito, List<NodeP> visitados, NodeP padre = null)
        {



            visitados.Add(nodo);
            Pila.Push(nodo);
            aux.Add(nodo.Name.ToCharArray()[0]);

            foreach (var item in nodo.relations)
            {
                var nodoAux = item.Up;

                /* if (aux.Count > 1)
                 {
                     var caracter = nodoAux.Name.ToCharArray()[0];
                     if (aux[aux.Count-2] != caracter && visitados.Contains(nodoAux) && aux.Contains(caracter))
                     {
                         while (aux[0] != caracter)
                             aux.RemoveAt(0);
                         circuito.Add(string.Join("", aux) + caracter);
                     }

                 }*/


                if (padre != null && !graph.EdgeIsDirected && nodoAux == padre)
                    continue;
                if (!visitados.Contains(nodoAux))
                    Tarjan(nodoAux, new List<char>(aux), circuito, visitados, nodo);
                else if (Pila.Contains(nodoAux))
                {
                    var temp = string.Join("", aux).Substring(string.Join("", aux).IndexOf(nodoAux.Name.ToCharArray()[0]));
                    temp += nodoAux.Name.ToCharArray()[0];

                    Console.WriteLine("Conexos: " + temp);
                    circuito.Add(temp);
                }



            }
            Pila.Pop();

        }
    }
}
