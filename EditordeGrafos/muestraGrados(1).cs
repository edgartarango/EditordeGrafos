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
    public partial class muestraGrados : Form
    {
        public List<List<int>> ListAdyacencia = new List<List<int>>();
        public List<int> auxiliar = new List<int>();
        public string name;
        public List<int> inDegree = new List<int>();
        int sumaGrad = 0;
        int exDegree = 0;
        int sumaGradSal = 0;
        int sumaGradTotal = 0;
        int j = 65;

        public muestraGrados(Graph graph)
        {
            InitializeComponent();
            MuestraMatriz(graph);
            CalculaInDegree(graph);
            CalculaExDegree(graph);
            ImprimeGradoTotal(graph);
            calculaEspeciales(graph);
        }

        public void calculaEspeciales(Graph graph)
        {
            if(graph.EdgeIsDirected) { return; }//Si el grafo es dirigido no lo toma en cuenta 
            muestraEspeciales.Text = string.Empty;
            foreach(NodeP nodo in graph)
            {
                
               // Recorre el arreglo de nodos graph, obtiene el grado y lo clasifica en la textbox 
                if (nodo.Degree == 0)
                    muestraEspeciales.Text += nodo.Name + ": Aislado\r\n";
                else if (nodo.Degree == 1)
                    muestraEspeciales.Text += nodo.Name + ": Hoja\r\n";

            }
        }

        public void MuestraMatriz(Graph graph)
        {
            int n = 0;
            int m = 0;
            for (int j = 0; j < graph.Count; j++)
            {
                auxiliar = new List<int>();
                for (int i = 0; i < graph.Count; i++)
                {
                    auxiliar.Add(0);
                }
                ListAdyacencia.Add(auxiliar);
            }

            // Se corrigio el problema en el que cuando se utilizaban numeros en los nodos no calculaba bien los grados 
            if (graph.Count > 0)
            {
                foreach (Edge Ar in graph.edgesList)
                {
                    if (!graph.EdgeIsDirected)  //si el grafo no es dirigido
                    {
                        if (ConvierteLetra(Ar.Source.Name) == ConvierteLetra(Ar.Destiny.Name))  // Verificamos si es una oreja
                        {
                            ListAdyacencia[ConvierteLetra(Ar.Source.Name)][ConvierteLetra(Ar.Destiny.Name)] = 1; //agregamos un 1 a la matriz de adyacencia 
                            ListAdyacencia[ConvierteLetra(Ar.Destiny.Name)][ConvierteLetra(Ar.Source.Name)] = 1;
                        }
                        else  //En caso de no cumplir lo anterior se trata de aristas que no estan conectadas al mismo nodo
                        {
                            ListAdyacencia[ConvierteLetra(Ar.Source.Name)][ConvierteLetra(Ar.Destiny.Name)]++;  //si no es oreja incrementamos en 1 el valor de la matriz
                            ListAdyacencia[ConvierteLetra(Ar.Destiny.Name)][ConvierteLetra(Ar.Source.Name)]++;
                        }

                    }
                    else  // para los grafos dirigidos
                    {
                        if (ConvierteLetra(Ar.Source.Name) == ConvierteLetra(Ar.Destiny.Name))
                        {
                            ListAdyacencia[ConvierteLetra(Ar.Destiny.Name)][ConvierteLetra(Ar.Source.Name)] = 1;  //Si es oreja solo agregamos un 1 a la matriz 

                        }
                        else
                        {
                            ListAdyacencia[ConvierteLetra(Ar.Source.Name)][ConvierteLetra(Ar.Destiny.Name)]++;  // caso contrario, aumentamos en 1 el dato que ya tiene la matriz
                        }

                    }
                }
            }
        }

        public void CalculaInDegree(Graph graph)
        {

            int n = 0;
            int m = 0;
            if (!graph.EdgeIsDirected)
            {

                for (m = 0; m < graph.Count; m++)  //Con estos ciclos recorremos la matriz de adyacencia 
                {
                    sumaGrad = 0;

                    for (n = 0; n < graph.Count; n++)
                    {
                        if (ListAdyacencia[n][m] >= 1 && !graph.EdgeIsDirected)  //checamos que el dato indexado en esa posicion sea mayor o igual a 1 y que no sea grafo dirigido 
                        {
                            sumaGrad = sumaGrad + ListAdyacencia[n][m];  //Si se cumple lo anterior en una variable vamos guardando la suma de los grados 
                            if (n == m) //Si n = m entonces se trata de una oreja y se le aumenta en 1 a la suma de los grados
                                sumaGrad++;
                        }

                    }
                    sumaGradTotal = sumaGradTotal + sumaGrad;  //Aqui vamos acumulando el grado de entrada para al final hacer la sumatoria y poder obtener el grado total del grafo
                    ImprimeInDegree(graph, m);  //se manda llamar a la funcion de impresion de los grados de entrada
                }


            }
            else  // Para grafos dirigidos
            {
                if (graph.EdgeIsDirected)
                {
                    for (m = 0; m < graph.Count; m++)  //Con estos ciclos recorremos la matriz de adyacencia 
                    {
                        sumaGrad = 0;  //reseteamos la suma de los grados en cada iteracion de m

                        for (n = 0; n < graph.Count; n++)
                        {

                            sumaGrad = sumaGrad + ListAdyacencia[n][m];
                            //if(m == n)
                            //{
                            //sumaGrad = sumaGrad + ListAdyacencia[m][n];
                            //}

                            // ImprimeInDegree(graph, m);
                        }
                        sumaGradTotal = sumaGradTotal + sumaGrad;
                        ImprimeInDegree(graph, m);
                    }
                }

            }
        }


        public void CalculaExDegree(Graph graph)
        {
            int n = 0;
            int m = 0;

            if (graph.EdgeIsDirected)  //Para sacar los grados de salida primero debe ser un grafo dirigido, con este condicional hacemos la validacion
            {
                for (n = 0; n < graph.Count; n++)  //Con estos ciclos recorremos la matriz de adyacencia 
                {
                    exDegree = 0;  //reseteamos la cuenta de grado cada que se ingresa a un nuevo nodo
                    for (m = 0; m < graph.Count; m++)
                    {
                        if (ListAdyacencia[n][m] >= 1)  //Si la matriz de adyacencia en esa posicion es mayor o igual a 1 vamos a incrementar el valor de InDegree en el arreglo en la posicion n,m
                            exDegree = exDegree + ListAdyacencia[n][m];
                    }
                    ImprimeExDegree(graph, n);
                }
            }
        }

        public void ImprimeGradoTotal(Graph graph)
        {
            gradoTotalG.Text = gradoTotalG.Text + " " + sumaGradTotal;
        }

        public void ImprimeExDegree(Graph graph, int n)
        {
            muestraGradosSalida.Text = muestraGradosSalida.Text + " " + graph[n].Name + ": " + exDegree + "\r\n";
        }

        public void ImprimeInDegree(Graph graph, int n)
        {
            muestraGradosIn.Text = muestraGradosIn.Text + " " + graph[n].Name + ": " + sumaGrad + "\r\n";
        }


        public int ConvierteLetra(string letra)
        {
            int Num = 0;


            if (letra == "A")
            {
                Num = 0;
            }
            else if (letra == "B")
            {
                Num = 1;
            }
            else if (letra == "C")
            {
                Num = 2;
            }
            else if (letra == "D")
            {
                Num = 3;
            }
            else if (letra == "E")
            {
                Num = 4;
            }
            else if (letra == "F")
            {
                Num = 5;
            }
            else if (letra == "G")
            {
                Num = 6;
            }
            else if (letra == "H")
            {
                Num = 7;
            }
            else if (letra == "I")
            {
                Num = 8;
            }
            else if (letra == "J")
            {
                Num = 9;
            }
            else if (letra == "K")
            {
                Num = 10;
            }
            else if (letra == "L")
            {
                Num = 11;
            }
            else if (letra == "M")
            {
                Num = 12;
            }
            else if (letra == "N")
            {
                Num = 13;
            }
            else if (letra == "O")
            {
                Num = 14;
            }
            else if (letra == "P")
            {
                Num = 15;
            }
            else if (letra == "Q")
            {
                Num = 16;
            }
            else if (letra == "R")
            {
                Num = 17;
            }
            else if (letra == "S")
            {
                Num = 18;
            }
            else if (letra == "T")
            {
                Num = 19;
            }
            else if (letra == "U")
            {
                Num = 20;
            }
            else if (letra == "V")
            {
                Num = 21;
            }
            else if (letra == "W")
            {
                Num = 22;
            }
            else if (letra == "X")
            {
                Num = 23;
            }
            else if (letra == "Y")
            {
                Num = 24;
            }
            else if (letra == "Z")
            {
                Num = 25;
            }
            else
            {
                //Esta linea fue agregada ya que en el modo de numero el nombre es un numero como cadena 
                Num = int.Parse(letra);
            }
            return Num;

        }


    }
}
