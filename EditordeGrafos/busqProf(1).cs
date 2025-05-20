using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EditordeGrafos
{
    public partial class busqProf : Form
    {
        private Graph graph;  // Referencia al grafo actual

        public busqProf(Graph graph)
        {
            InitializeComponent();
            this.graph = graph;
            // Llenar el ComboBox con los nodos disponibles (se mostrará la propiedad Name)
            comboBoxRoot.DataSource = graph;
            comboBoxRoot.DisplayMember = "Name";
            if (graph.Count > 0)
                comboBoxRoot.SelectedIndex = 0;
        }

        // Evento para el botón "Recorrer"
        private void btnRecorrer_Click(object sender, EventArgs e)
        {
            // Obtener la raíz seleccionada del ComboBox
            NodeP initialRoot = comboBoxRoot.SelectedItem as NodeP;
            if (initialRoot != null)
            {
                string dfsResult = DFSForest(graph, initialRoot);
                textBoxDFS.Text = dfsResult;
            }
            else
            {
                textBoxDFS.Text = "No se ha seleccionado una raíz válida.";
            }
        }

        /// <summary>
        /// Realiza un recorrido en profundidad (DFS) sobre todo el grafo, generando un bosque de recorridos.
        /// La primera componente se inicia desde la raíz seleccionada; luego, si quedan nodos sin visitar,
        /// se crea un nuevo árbol tomando como raíz el nodo no visitado con la etiqueta mayor (orden alfabético).
        /// </summary>
        /// <param name="graph">El grafo sobre el que se realiza el recorrido.</param>
        /// <param name="initialRoot">La raíz inicial seleccionada.</param>
        /// <returns>Una cadena con cada árbol en el formato RAIZ(N) n, n, n, separados por saltos de línea.</returns>
        private string DFSForest(Graph graph, NodeP initialRoot)
        {
            // Reiniciar el estado "Visited" de todos los nodos
            foreach (NodeP node in graph)
            {
                node.Visited = false;
            }

            List<string> forest = new List<string>();

            // Función recursiva local para realizar DFS desde un nodo dado
            void DFS(NodeP current, List<string> order)
            {
                current.Visited = true;
                order.Add(current.Name);
                foreach (var rel in current.relations.OrderBy(r => r.Up.Position.X))
                {
                    NodeP neighbor = rel.Up;
                    if (!neighbor.Visited)
                    {
                        DFS(neighbor, order);
                    }
                }
            }

            // Primera componente: DFS desde la raíz seleccionada
            List<string> orderInitial = new List<string>();
            DFS(initialRoot, orderInitial);
            forest.Add("RAIZ(" + initialRoot.Name + ") " + string.Join(", ", orderInitial));

            // Mientras existan nodos sin visitar, generar nuevas componentes (bosque)
            while (graph.Exists(n => !n.Visited))
            {
                // Seleccionar, entre los no visitados, el nodo con la etiqueta mayor (orden alfabético)
                NodeP candidate = null;
                foreach (NodeP node in graph)
                {
                    if (!node.Visited)
                    {
                        if (candidate == null || string.Compare(node.Name, candidate.Name) < 0)
                        {
                            candidate = node;
                        }
                    }
                }
                if (candidate != null)
                {
                    List<string> orderCandidate = new List<string>();
                    DFS(candidate, orderCandidate);
                    forest.Add("RAIZ(" + candidate.Name + ") " + string.Join(", ", orderCandidate));
                }
            }

            return string.Join(Environment.NewLine, forest);
        }
    }
}
