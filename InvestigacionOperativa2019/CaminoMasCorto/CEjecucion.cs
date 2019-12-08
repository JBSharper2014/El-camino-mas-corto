using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace CaminoMasCorto
{
    public class CEjecucion
    {
        /* 
             Dijkstra es un algoritmo que nos permite también encontrar el camino. 
             Pero en vez de ser el camino más corto, será el camino "mas barato".
             Puesto que considerará el peso que tenga cada nodo.
     
         */

        public static int inicio = 0;
        public static int final = 0;
        public static int distancia = 0;
        public static int n = 0;
        public static int cantNodos = 0;
        public static string dato = "";
        public static int actual = 0;
        public static int columna = 0
            ;
        public static int penalizacion = 0;
        public static string mensaje = "";
        

         public static void Ejecutar(Camino_Variables[] datos)
            {

            mensaje = "El camino más corto se encuentra recorriendo los siguientes nodos: \n\n";

            // Creamos el grafo
            CGrafo migrafo = new CGrafo(cantNodos);

            foreach (Camino_Variables element in datos)
            {
                migrafo.AdicionaArista(element.nodoInicio, element.nodoFinal, element.peso);
                migrafo.AdicionaArista(element.nodoFinal, element.nodoInicio, element.peso);
            }
            // migrafo.MuestrAdyacencia();

            #region Tabla
            // Creamos la tabla
                // 0 - Visitado
                // 1 - Distancia
                // 2 - Previo
                int[,] tabla = new int[cantNodos, 3];

                // Inicializamos la tabla
                for (n = 0; n < cantNodos; n++)
                {
                    tabla[n, 0] = 0;
                    tabla[n, 1] = int.MaxValue;
                    tabla[n, 2] = 0;
                }
                tabla[inicio, 1] = 0;

                //       MostrarTabla(tabla);
            #endregion

                // Inicio de Dijkstra
                actual = inicio;

                do
                {
                    // Marcar nodo como visitado
                    tabla[actual, 0] = 1;

                    for (columna = 0; columna < cantNodos; columna++)
                    {
                        // Buscamos a quien se dirige
                        if (migrafo.ObtenAdyacencia(actual, columna) != 0) 
                        {
                            // Calculamos la distancia
                            distancia = migrafo.ObtenAdyacencia(actual, columna) -1 + tabla[actual, 1];
       // le restamos 1 para volver a peso original que modificamos para evitar el control de != 0
                             
                            // Nos fijamos si está en la misma carretera, de lo contrario
                            // le añadimos la penalizacion

                            // Colocamos las distancias
                            if (distancia < tabla[columna, 1])
                            {
                                tabla[columna, 1] = distancia;

                                // colocamos la información de padre
                                tabla[columna, 2] = actual;
                            }
                        }
                    }

                    // EL nuevo actual es el nodo con la menor distancia que no ha sido visitado

                    int indiceMenor = -1;
                    int distanciaMenor = int.MaxValue;

                    for (int x = 0; x < cantNodos; x++)
                    {
                        if (tabla[x, 1] < distanciaMenor && tabla[x, 0] == 0)
                        {
                            indiceMenor = x;
                            distanciaMenor = tabla[x, 1];
                        }

                        actual = indiceMenor;
                    }
                } while (actual != -1);

          //      MostrarTabla(tabla);

                // Obtenemos la ruta
                List<int> ruta = new List<int>();
                int nodo = final;

                while (nodo != inicio)
                {
                    ruta.Add(nodo);
                    nodo = tabla[nodo, 2];
                }
                ruta.Add(inicio);

                ruta.Reverse();


            foreach (int poisicion in ruta)
            {
                if (ruta.IndexOf(poisicion) != ruta.Count - 1)
                { 
                if (ruta.IndexOf(poisicion) +1 % 5 == 0)
                    mensaje += string.Format("Nodo {0}, \n", poisicion + 1);
                else
                    mensaje += string.Format("Nodo {0}, ", poisicion + 1);
                }
                else
                mensaje += string.Format("Nodo{0} \n", poisicion + 1);

            }
               
               MessageBox.Show(mensaje);
               
            }

            public static void MostrarTabla(int[,] pTabla)
            {
                int n = 0;
                for (n = 0; n < pTabla.GetLength(0); n++)
                {
                    mensaje += string.Format("{0}-> {1}\t{2}\t{3}\n", n +1, pTabla[n, 0], pTabla[n, 1], pTabla[n, 2]);
                }

               MessageBox.Show(mensaje);
               
            }
        }
    }
