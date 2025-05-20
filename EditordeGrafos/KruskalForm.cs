using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditordeGrafos      // ajusta si usas otro namespace
{
    public partial class KruskalForm : Form
    {
        private readonly Graph _graph;

        public KruskalForm(Graph graph)
        {
            InitializeComponent();
            _graph = graph ?? throw new ArgumentNullException(nameof(graph));

            foreach (var n in _graph.OrderBy(n => n.Name))
                cmbRoot.Items.Add(n.Name);

            if (cmbRoot.Items.Count > 0)
                cmbRoot.SelectedIndex = 0;
        }

        /******************************************************************
         *  ALGORITMO DE KRUSKAL con recorrido BFS desde una raíz elegida *
         ******************************************************************/
        private (List<Edge> mst, List<NodeP> recorrido, int pesoTotal)
            EjecutarKruskal(Graph g, NodeP raiz)
        {
            if (g.EdgeIsDirected)
                throw new NotSupportedException("Kruskal requiere grafo NO dirigido.");

            /**---------------   1)   Union–Find   -----------------------**/
            var parent = new Dictionary<NodeP, NodeP>();
            NodeP Find(NodeP x)
            {
                if (parent[x] != x) parent[x] = Find(parent[x]);
                return parent[x];
            }
            void Union(NodeP a, NodeP b) => parent[Find(a)] = Find(b);
            foreach (var v in g) parent[v] = v;

            /**---------------   2)   Ordenar aristas por peso   ----------**/
            var edgesOrdenadas = g.EdgesList
                                  .OrderBy(e => e.Weight)        // <-- usa tu propiedad
                                  .ToList();

            var mst = new List<Edge>();
            int pesoTotal = 0;

            foreach (var edge in edgesOrdenadas)            // ← antes:  e
            {
                var u = edge.Source;
                var v = edge.Destiny;

                if (Find(u) != Find(v))
                {
                    mst.Add(edge);
                    pesoTotal += edge.Weight;
                    Union(u, v);

                    if (mst.Count == g.Count - 1) break;
                }
            }

            /**---------------   3)   Recorrido BFS del MST   -------------**/
            var ady = new Dictionary<NodeP, List<NodeP>>();
            foreach (var n in g) ady[n] = new List<NodeP>();
            foreach (var e in mst)
            {
                ady[e.Source].Add(e.Destiny);
                ady[e.Destiny].Add(e.Source);
            }

            var recorrido = new List<NodeP>();
            var visitado = new HashSet<NodeP> { raiz };
            var cola = new Queue<NodeP>();
            cola.Enqueue(raiz);

            while (cola.Count > 0)
            {
                var nodo = cola.Dequeue();
                recorrido.Add(nodo);

                foreach (var vec in ady[nodo])
                    if (visitado.Add(vec))
                        cola.Enqueue(vec);
            }

            return (mst, recorrido, pesoTotal);
        }

        /******************************************************************
         *  EVENTO: botón “Calcular MST”                                  *
         ******************************************************************/
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (cmbRoot.SelectedItem == null) return;

            NodeP raiz = _graph.First(n => n.Name == cmbRoot.SelectedItem.ToString());

            try
            {
                /* Llamada al algoritmo interno */
                var resultado = EjecutarKruskal(_graph, raiz);
                var mst = resultado.mst;
                var recorrido = resultado.recorrido;
                var peso = resultado.pesoTotal;

                /* Formatear salida */
                var sb = new StringBuilder();
                sb.AppendLine("Árbol generador mínimo (Kruskal):\r\n");
                foreach (var edge in mst)
                    sb.AppendLine($"{edge.Source.Name} — {edge.Destiny.Name}  (w={edge.Weight})");

                sb.AppendLine($"\r\nPeso total: {peso}");
                sb.AppendLine("\r\nRecorrido BFS del MST desde la raíz:\r\n" +
                              string.Join(" → ", recorrido.Select(n => n.Name)));

                txtResultado.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Kruskal",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
