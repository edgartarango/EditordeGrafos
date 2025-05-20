using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EditordeGrafos
{
    public partial class busqAmp : Form
    {
        private Graph graph;  // Se almacena el grafo actual

        public busqAmp(Graph graph)
        {
            InitializeComponent();
            this.graph = graph;
            // Rellenar el ComboBox con los nodos disponibles (se mostrará la propiedad Name)
            comboBoxRoot.DataSource = graph;
            comboBoxRoot.DisplayMember = "Name";
            if (graph.Count > 0)
                comboBoxRoot.SelectedIndex = 0;
        }

        // Evento para el botón "Recorrer"
        private void btnRecorrer_Click(object sender, EventArgs e)
        {
            // Obtener el nodo seleccionado en el ComboBox como raíz inicial
            NodeP initialRoot = comboBoxRoot.SelectedItem as NodeP;
            if (initialRoot != null)
            {
                string bfsResult = BFSForest(graph, initialRoot);
                textBoxBFS.Text = bfsResult;
            }
            else
            {
                textBoxBFS.Text = "No se ha seleccionado una raíz válida.";
            }
        }

       
        /// Realiza el recorrido en amplitud (BFS) sobre todo el grafo, generando un bosque de recorridos.
        /// La primera componente se inicia desde la raíz seleccionada en el ComboBox; luego, si quedan nodos
        /// sin visitar, se crea un nuevo árbol tomando como raíz el nodo no visitado con la etiqueta mayor
    
        private string BFSForest(Graph graph, NodeP initialRoot)
        {
            // Reiniciar el estado "Visited" de todos los nodos
            foreach (NodeP node in graph)
            {
                node.Visited = false;
            }

            List<string> forest = new List<string>();

            // Función local que realiza el recorrido BFS desde una raíz dada
            string BFSFrom(NodeP root)
            {
                Queue<NodeP> queue = new Queue<NodeP>();
                List<string> order = new List<string>();

                root.Visited = true;
                queue.Enqueue(root);
                order.Add(root.Name);

                while (queue.Count > 0)
                {
                    NodeP current = queue.Dequeue();
                    foreach (var rel in current.relations)
                    {
                        NodeP neighbor = rel.Up;
                        if (!neighbor.Visited)
                        {
                            neighbor.Visited = true;
                            queue.Enqueue(neighbor);
                            order.Add(neighbor.Name);
                        }
                    }
                }
                return "RAIZ(" + root.Name + ") " + string.Join(", ", order);
            }

            // Primera componente: partir de la raíz seleccionada
            forest.Add(BFSFrom(initialRoot));

            // Mientras queden nodos sin visitar, generar nuevas componentes
            while (graph.Exists(n => !n.Visited))
            {
                // Entre los nodos no visitados, elegir el de mayor etiqueta (orden alfabético)
                NodeP candidate = null;
                foreach (NodeP node in graph)
                {
                    if (!node.Visited)
                    {
                        //Correccion simbolo menor que 3 de marzo 2025
                        if (candidate == null || string.Compare(node.Name, candidate.Name) < 0)
                        {
                            candidate = node;
                        }
                    }
                }

                if (candidate != null)
                {
                    forest.Add(BFSFrom(candidate));
                }
            }

            return string.Join(Environment.NewLine, forest);
        }


     
        /// Realiza el recorrido en amplitud (BFS) a partir del nodo raíz seleccionado.
       
        private string BFS(Graph graph, NodeP root)
        {
            if (graph == null || graph.Count == 0)
                return "El grafo está vacío.";

            // Reiniciar la propiedad Visited de todos los nodos para evitar efectos de recorridos anteriores
            foreach (NodeP node in graph)
            {
                node.Visited = false;
            }

            Queue<NodeP> queue = new Queue<NodeP>();
            List<string> traversalOrder = new List<string>();

            // Se marca la raíz y se agrega a la cola
            root.Visited = true;
            queue.Enqueue(root);
            traversalOrder.Add(root.Name);

            // Recorrido BFS
            while (queue.Count > 0)
            {
                NodeP current = queue.Dequeue();
                foreach (var rel in current.relations)
                {
                    NodeP neighbor = rel.Up;
                    if (!neighbor.Visited)
                    {
                        neighbor.Visited = true;
                        queue.Enqueue(neighbor);
                        traversalOrder.Add(neighbor.Name);
                    }
                }
            }

            // Formatear la salida:
            string result = "RAIZ(" + root.Name + ") " + string.Join(", ", traversalOrder);
            return result;
        }
    }
}
