using System;
using System.Collections.Generic;
using System.Linq;
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

        // Método para obtener las componentes conexas
        // Se asume que graph tiene:
        // - Una propiedad 'EdgeIsDirected' o similar para determinar si es dirigido
        // - Un campo o propiedad 'edgesList' y la lista de nodos (la clase Graph hereda de List<NodeP>)
        // - Cada nodo se identifica por un entero (su posición en la lista) o bien se puede adaptar.
        // Aquí usaremos un método basado en Tarjan para grafos dirigidos
        // y una DFS estándar para grafos no dirigidos.
        private List<List<int>> EncontrarComponentesConexosOptimizado()
        {
            int n = graph.Count;
            // Se construye una lista de adyacencia: para cada nodo, lista de índices de sus vecinos.
            // Para ello, se asume que el orden de graph es el índice del nodo.
            List<int>[] adyacencia = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                adyacencia[i] = new List<int>();
            }
            // Recorrer las aristas del grafo y agregar vecinos.
            // Para grafos no dirigidos se agrega en ambos sentidos.
            foreach (Edge ar in graph.edgesList)
            {
                // Buscar índices de los nodos en el grafo, asumiendo que la propiedad Name es única y
                // que la posición en la lista Graph se corresponde con su índice.
                int idxSource = graph.FindIndex(x => x.Name == ar.Source.Name);
                int idxDest = graph.FindIndex(x => x.Name == ar.Destiny.Name);
                if (idxSource != -1 && idxDest != -1)
                {
                    adyacencia[idxSource].Add(idxDest);
                    if (!graph.EdgeIsDirected)
                        adyacencia[idxDest].Add(idxSource);
                }
            }

            // Ordenar los nodos de mayor a menor grado para iniciar por el de mayor densidad.
            var nodosPorGrado = Enumerable.Range(0, n)
                .OrderByDescending(i => adyacencia[i].Count)
                .ToList();

            List<List<int>> componentes = new List<List<int>>();

            if (graph.EdgeIsDirected)
            {
                // Algoritmo de Tarjan para componentes fuertemente conexas (para grafo dirigido)
                int[] index = new int[n];
                int[] low = new int[n];
                bool[] enPila = new bool[n];
                for (int i = 0; i < n; i++) index[i] = -1;
                Stack<int> pila = new Stack<int>();
                int contador = 0;

                void TarjanDFS(int u)
                {
                    index[u] = contador;
                    low[u] = contador;
                    contador++;
                    pila.Push(u);
                    enPila[u] = true;
                    foreach (int v in adyacencia[u])
                    {
                        if (index[v] == -1)
                        {
                            TarjanDFS(v);
                            low[u] = Math.Min(low[u], low[v]);
                        }
                        else if (enPila[v])
                        {
                            low[u] = Math.Min(low[u], index[v]);
                        }
                    }
                    if (low[u] == index[u])
                    {
                        List<int> comp = new List<int>();
                        int w;
                        do
                        {
                            w = pila.Pop();
                            enPila[w] = false;
                            comp.Add(w);
                        } while (w != u);
                        componentes.Add(comp);
                    }
                }

                // Usar el orden de mayor grado
                foreach (int v in nodosPorGrado)
                {
                    if (index[v] == -1)
                        TarjanDFS(v);
                }
            }
            else
            {
                // DFS estándar para componentes conexas en grafo no dirigido
                bool[] visitado = new bool[n];
                void DFS(int u, List<int> comp)
                {
                    visitado[u] = true;
                    comp.Add(u);
                    foreach (int w in adyacencia[u])
                    {
                        if (!visitado[w])
                            DFS(w, comp);
                    }
                }

                foreach (int v in nodosPorGrado)
                {
                    if (!visitado[v])
                    {
                        List<int> comp = new List<int>();
                        DFS(v, comp);
                        componentes.Add(comp);
                    }
                }
            }

            return componentes;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Obtener las componentes conexas (lista de índices)
            List<List<int>> comps = EncontrarComponentesConexosOptimizado();

            // Construir resultado: traducir índices a nombres de nodos
            string resultado = "";
            int cont = 1;
            foreach (var comp in comps)
            {
                resultado += "Componente " + cont + ": ";
                // Ordenar los nombres para presentación (opcional)
                var nombres = comp.Select(i => graph[i].Name).OrderBy(s => s);
                resultado += string.Join(", ", nombres) + Environment.NewLine;
                cont++;
            }
            txtResultado.Text = resultado;
        }
    }
}
