using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaminoMasCorto
{
        public class CGrafo
        {
            // La matriz de adyacencia es para saber QUE vertices tienen aristas
            int[,] mAdyacencia;
            int[] indegree;
            int nodos;

            public CGrafo(int pNodos)
            {
                nodos = pNodos;

                //Instanciamos la matriz de adyacencia:
                mAdyacencia = new int[nodos, nodos];

                // instanciamos el arreglo de indegree
                indegree = new int[nodos];
            }

            // Para decir si hay aristas, llenaremos la matriz de adyacencia.
            // Para esto deberemos conocer el nodo desde cual sale la arista y el nodo al cual
            // se dirige.
            public void AdicionaArista(int pNodoInicio, int pNodoFinal)
            {
                // Así decimos que ahí hay adyacencia.
                mAdyacencia[pNodoInicio, pNodoFinal] = 1;
            }

            //Nuevo
            public void AdicionaArista(int pNodoInicio, int PnodoFinal, int pPeso)
            {
                mAdyacencia[pNodoInicio -1, PnodoFinal-1] = pPeso;
            }


            //
            public void MuestrAdyacencia()
            {
                 int n = 0;
                 int m = 0;
                 string mensaje = "";

                 for (n = 0; n < nodos; n++)
                 mensaje += string.Format ("\t{0}\n", n);

                 MessageBox.Show(mensaje);

                for (n = 0; n < nodos; n++)
                {

                    // Console.Write(n);
                    for (m = 0; m < nodos; m++)
                    {
                        mensaje += string.Format("\t{0}\n", n);
                    }
                }
                MessageBox.Show(mensaje);
                
            }

            // Este metodo recorre la matriz de adyacencia y el resultado de ese recorrer
            // llena el arreglo de Indegree
            public void CalcularIndegree()
            {
                int n = 0;
                int m = 0;

                for (n = 0; n < nodos; n++)
                {
                    for (m = 0; m < nodos; m++)
                    {
                        // Si hay un 1 en la matriz de adyacencia en esa coordenada, entonces
                        // vamos a incrementar en 1 la posicion n del arreglo indigree
                        if (mAdyacencia[m, n] == 1)
                            indegree[n]++;
                    }
                }
            }

            public void MostrarIndegree()
            {
                string mensaje = "";
                int n = 0;
                Console.ForegroundColor = ConsoleColor.White;
                for (n = 0; n < nodos; n++)
                    mensaje += String.Format("Nodo: {0}, {1}\n", n, indegree[n]);

                MessageBox.Show(mensaje);
            }

            // Encontramos el nodo que tiene un Indegree de 0 
            // Nos regresa un entero, el indice de aquel nodo que tiene un indigree de 0
            public int EncuentraI0()
            {
                bool encontrado = false;
                int n = 0;

                for (n = 0; n < nodos; n++)
                {
                    if (indegree[n] == 0)
                    {
                        encontrado = true;
                        break;
                    }
                }


                if (encontrado)
                    return n;
                else
                    return -1; // Codigo que indica que no se ha encontrado 


            }

            public void DecrementaIndigree(int pNodo)
            {
                indegree[pNodo] = -1;

                int n = 0;


                for (n = 0; n < nodos; n++)
                {
                    // Recorremos las columnas por el nodo recibido    
                    if (mAdyacencia[pNodo, n] == 1)
                        indegree[n]--;

                }

            }

            // Nuevo
            public int ObtenAdyacencia(int pFila, int pColumna)
            {
                return mAdyacencia[pFila, pColumna];
            }
        }
    }
