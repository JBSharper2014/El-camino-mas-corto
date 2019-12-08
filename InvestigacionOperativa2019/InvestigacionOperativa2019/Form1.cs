using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CaminoMasCorto;
using ControlStock;



namespace InvestigacionOperativa2019
{
    public partial class Form1 : Form
    {

        Image nodo4_imagen = Image.FromFile("4nodos.png");
        Image nodo9_imagen = Image.FromFile("9nodos.png");
        Image nodo16_imagen = Image.FromFile("16nodos.png");

        int indice_actual = 0;
        int opcion_nodos = 0;

        Camino_Variables[] nodos4 = new Camino_Variables[5];
        Camino_Variables[] nodos9 = new Camino_Variables[16];
        Camino_Variables[] nodos16 = new Camino_Variables[33];

        bool avanzar = true;
        bool retroceder = false;

        int nodo_inicio = 0;
        int nodo_final = 0;

        int penalizacion = 0;
        

        public Form1()
        {
            InitializeComponent();
            Limpiar_grafico_camino();
            Inicializa_nodos();
            LabelsA0(nodos4);
            LabelsA0(nodos9);
            LabelsA0(nodos16);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioNodo16_CheckedChanged(object sender, EventArgs e)
        {
            opcion_nodos = 3;
            habilitar_labels_camino(16);
            CEjecucion.cantNodos = 16;
            Habilitar_controles_camino();
            deshabilitar_radiobuttons();
        }

        private void radioNodo9_CheckedChanged(object sender, EventArgs e)
        {
            opcion_nodos = 2;
            habilitar_labels_camino(9);
            CEjecucion.cantNodos = 9;
            Habilitar_controles_camino();
            deshabilitar_radiobuttons();
        }

        private void radioNodo4_CheckedChanged(object sender, EventArgs e)
        {
            opcion_nodos = 1;
            habilitar_labels_camino(4);    
            CEjecucion.cantNodos = 4;
            Habilitar_controles_camino();
            deshabilitar_radiobuttons();
        }

        private void deshabilitar_radiobuttons()
        {
            radioNodo4.Enabled = false;
            radioNodo9.Enabled = false;
            radioNodo16.Enabled = false;
        }

        private void habilitar_labels_camino(int valor)
        {
            if (valor == 4)
            {
                btnsiguiente.Image = nodo4_imagen;
                N41a2.Visible = true;
                n41a3.Visible = true;
                n41a4.Visible = true;
                n42a4.Visible = true;
                n43a4.Visible = true;
            }

            if (valor == 9)
            {
                btnsiguiente.Image = nodo9_imagen;
                n91a2.Visible = true;
                n91a5.Visible = true;
                n91a4.Visible = true;
                n92a3.Visible = true;
                n92a6.Visible = true;
                n94a7.Visible = true;
                n94a8.Visible = true;
                n95a8.Visible = true;
                n95a9.Visible = true;
                n95a6.Visible = true;
                n97a8.Visible = true;
                n93a6.Visible = true;
                n96a9.Visible = true;
                n98a9.Visible = true;
                n92a5.Visible = true;
                n94a5.Visible = true;
            }

            if (valor == 16)
            {
                btnsiguiente.Image = nodo16_imagen;
                n161a2.Visible = true;
                n162a3.Visible = true;
                n163a4.Visible = true;
                n165a6.Visible = true;
                n166a7.Visible = true;
                n167a8.Visible = true;
                n169a10.Visible = true;
                n1610a11.Visible = true;
                n1611a12.Visible = true;
                n1613a14.Visible = true;
                n1614a15.Visible = true;
                n1615a16.Visible = true;
                n161a5.Visible = true;
                n165a9.Visible = true;
                n169a13.Visible = true;
                n162a6.Visible = true;
                n166a10.Visible = true;
                n1610a14.Visible = true;
                n163a7.Visible = true;
                n167a11.Visible = true;
                n1611a15.Visible = true;
                n164a8.Visible = true;
                n168a12.Visible = true;
                n1612a16.Visible = true;
                n163a8.Visible = true;
                n162a7.Visible = true;
                n167a12.Visible = true;
                n161a6.Visible = true;
                n166a11.Visible = true;
                n1611a16.Visible = true;
                n165a10.Visible = true;
                n1610a15.Visible = true;
                n169a14.Visible = true;


            }

            Deshabilitar_labels_camino(valor);
        }

        private void Deshabilitar_labels_camino(int valor)
        {
            if (valor != 4)
            {
                N41a2.Visible = false;
                n41a3.Visible = false;
                n41a4.Visible = false;
                n42a4.Visible = false;
                n43a4.Visible = false;
            }

            if (valor != 9)
            {
                n91a2.Visible = false;
                n91a5.Visible = false;
                n91a4.Visible = false;
                n92a3.Visible = false;
                n92a6.Visible = false;
                n94a7.Visible = false;
                n94a8.Visible = false;
                n95a8.Visible = false;
                n95a9.Visible = false;
                n95a6.Visible = false;
                n97a8.Visible = false;
                n93a6.Visible = false;
                n96a9.Visible = false;
                n98a9.Visible = false;
                n92a5.Visible = false;
                n94a5.Visible = false;
            }

            if (valor != 16)
            {
                n161a2.Visible = false;
                n162a3.Visible = false;
                n163a4.Visible = false;
                n165a6.Visible = false;
                n166a7.Visible = false;
                n167a8.Visible = false;
                n169a10.Visible = false;
                n1610a11.Visible = false;
                n1611a12.Visible = false;
                n1613a14.Visible = false;
                n1614a15.Visible = false;
                n1615a16.Visible = false;
                n161a5.Visible = false;
                n165a9.Visible = false;
                n169a13.Visible = false;
                n162a6.Visible = false;
                n166a10.Visible = false;
                n1610a14.Visible = false;
                n163a7.Visible = false;
                n167a11.Visible = false;
                n1611a15.Visible = false;
                n164a8.Visible = false;
                n168a12.Visible = false;
                n1612a16.Visible = false;
                n163a8.Visible = false;
                n162a7.Visible = false;
                n167a12.Visible = false;
                n161a6.Visible = false;
                n166a11.Visible = false;
                n1611a16.Visible = false;
                n165a10.Visible = false;
                n1610a15.Visible = false;
                n169a14.Visible = false;
            }  
        }
        private void Limpiar_grafico_camino()
        { 
                N41a2.Text = "0";
                n41a3.Text = "0";
                n41a4.Text = "0";
                n42a4.Text = "0";
                n43a4.Text = "0";

                n91a2.Text = "0";
                n91a5.Text = "0";
                n91a4.Text = "0";
                n92a3.Text = "0";
                n92a6.Text = "0";
                n94a7.Text = "0";
                n94a8.Text = "0";
                n95a8.Text = "0";
                n95a9.Text = "0";
                n95a6.Text = "0";
                n97a8.Text = "0";
                n93a6.Text = "0";
                n96a9.Text = "0";
                n98a9.Text = "0";
                n92a5.Text = "0";
                n94a5.Text = "0";

                n161a2.Text = "0";
                n162a3.Text = "0";
                n163a4.Text = "0";
                n165a6.Text = "0";
                n166a7.Text = "0";
                n167a8.Text = "0";
                n169a10.Text = "0";
                n1610a11.Text = "0";
                n1611a12.Text = "0";
                n1613a14.Text = "0";
                n1614a15.Text = "0";
                n1615a16.Text = "0";
                n161a5.Text = "0";
                n165a9.Text = "0";
                n169a13.Text = "0";
                n162a6.Text = "0";
                n166a10.Text = "0";
                n1610a14.Text = "0";
                n163a7.Text = "0";
                n167a11.Text = "0";
                n1611a15.Text = "0";
                n164a8.Text = "0";
                n168a12.Text = "0";
                n1612a16.Text = "0";
                n163a8.Text = "0";
                n162a7.Text = "0";
                n167a12.Text = "0";
                n161a6.Text = "0";
                n166a11.Text = "0";
                n1611a16.Text = "0";
                n165a10.Text = "0";
                n1610a15.Text = "0";
                n169a14.Text = "0";
        }

        private void Habilitar_controles_camino()
        {
            if (CaminoMasCorto.CEjecucion.cantNodos > 0)
            {
                grupo1.Visible = true;
                grupo2.Visible = true;
               // grupo3.Visible = true;
                btnCancelar.Visible = true;
                btnEjecutar.Visible = true;
                btnsiguiente.Visible = true;
            }
        }
        private void Deshabilitar_controles_camino()
        {
            radioNodo16.Checked = false;
            radioNodo9.Checked = false;
            radioNodo4.Checked = false;

            radioNodo16.Enabled = true;
            radioNodo4.Enabled = true;
            radioNodo9.Enabled = true;

            grupo1.Visible = false;
            grupo2.Visible = false;
            grupo3.Visible = false;
            btnCancelar.Visible = false;
            btnEjecutar.Visible = false;

            btnmostrarcamino.Visible = false;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Insertar_nodos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 1 y 2";
            indice_actual = 0;
            
            Deshabilitar_controles_camino();
            Deshabilitar_labels_camino(0);
            btnsiguiente.Visible = false;
            txtIngresarNodo.Clear();
            txtNodoFinal.Clear();
            txtNodoInicio.Clear();
            

        }

        private bool controles_llenos_caminos ()
        {
            return true;
        }

        private void Insertar_nodos()
        {

            if (txtIngresarNodo.Text != "")
            {
                switch (opcion_nodos)
                {

                    case 1:
                        nodos4[indice_actual].peso = Convert.ToInt32(txtIngresarNodo.Text) + 1;
           /// +1 para salvar error de control distinto de 0
                        nodos4[indice_actual].label.Text = txtIngresarNodo.Text;
                        nodos4[indice_actual].label.ForeColor = labelasignado;
                        nodos4[indice_actual].label.BackColor = fondoasignado;
                        NodosCargados(nodos4);
                        Cambiar_nodo(avanzar);
                        break;
                    case 2:
                        nodos9[indice_actual].peso = Convert.ToInt32(txtIngresarNodo.Text) + 1;
                        nodos9[indice_actual].label.Text = txtIngresarNodo.Text;
                        nodos9[indice_actual].label.ForeColor = labelasignado;
                        nodos9[indice_actual].label.BackColor = fondoasignado;
                        NodosCargados(nodos9);
                        Cambiar_nodo(avanzar);
                        break;
                    case 3:
                        nodos16[indice_actual].peso = Convert.ToInt32(txtIngresarNodo.Text) + 1;
                        nodos16[indice_actual].label.Text = txtIngresarNodo.Text;
                        nodos16[indice_actual].label.ForeColor = labelasignado;
                        nodos16[indice_actual].label.BackColor = fondoasignado;
                        NodosCargados(nodos16);
                        Cambiar_nodo(avanzar);
                        break;
                }
                if (btnmostrarcamino.Visible)
                {
                    btnmostrarcamino.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Inserte un valor entero");
                txtIngresarNodo.Focus();
            }
        }

        private void Cambiar_nodo(bool avanzar)
        {
            if (avanzar) { indice_actual += 1; }
            else indice_actual -= 1;

            if (indice_actual == 33 && opcion_nodos == 3) indice_actual = 0;
            if (indice_actual == -1 && opcion_nodos == 3) indice_actual = 32;
            if (indice_actual == 16 && opcion_nodos == 2) indice_actual = 0;
            if (indice_actual == -1 && opcion_nodos == 2) indice_actual = 15;
            if (indice_actual == 5 && opcion_nodos == 1) indice_actual = 0;
            if (indice_actual == -1 && opcion_nodos == 1) indice_actual = 4;

            switch (opcion_nodos)
            {

                case 1:
                    switch (indice_actual + 1)
                    {
                        case 1:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 1 y 2";
                            break;
                        case 2:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 1 y 4";
                            break;
                        case 3:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 1 y 3";
                            break;
                        case 4:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 2 y 4";
                            break;
                        case 5:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 3 y 4";
                            break;

                    }
                    break;
                case 2:
                    switch (indice_actual + 1)
                    {
                        case 1:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 01 y 02";
                            break;
                        case 2:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 02 y 03";
                            break;
                        case 3:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 04 y 05";
                            break;
                        case 4:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 05 y 06";
                            break;
                        case 5:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 07 y 08";
                            break;
                        case 6:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 08 y 09";
                            break;
                        case 7:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 01 y 04";
                            break;
                        case 8:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 04 y 07";
                            break;
                        case 9:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 02 y 05";
                            break;
                        case 10:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 05 y 08";
                            break;
                        case 11:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 03 y 06";
                            break;
                        case 12:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 06 y 09";
                            break;
                        case 13:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 02 y 06";
                            break;
                        case 14:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 01 y 05";
                            break;
                        case 15:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 05 y 09";
                            break;
                        case 16:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 04 y 08";
                            break;

                    }
                    break;
                case 3:
                    switch (indice_actual + 1)
                    {
                        case 1:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 01 y 02";
                            break;
                        case 2:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 02 y 03";
                            break;
                        case 3:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 03 y 04";
                            break;
                        case 4:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 05 y 06";
                            break;
                        case 5:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 06 y 07";
                            break;
                        case 6:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 07 y 08";
                            break;
                        case 7:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 09 y 10";
                            break;
                        case 8:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 10 y 11";
                            break;
                        case 9:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 11 y 12";
                            break;
                        case 10:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 13 y 14";
                            break;
                        case 11:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 14 y 15";
                            break;
                        case 12:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 15 y 16";
                            break;
                        case 13:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 04 y 08";
                            break;
                        case 14:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 08 y 12";
                            break;
                        case 15:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 12 y 16";
                            break;
                        case 16:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 03 y 07";
                            break;
                        case 17:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 07 y 11";
                            break;
                        case 18:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 11 y 15";
                            break;
                        case 19:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 02 y 06";
                            break;
                        case 20:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 06 y 10";
                            break;
                        case 21:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 10 y 14";
                            break;
                        case 22:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 01 y 05";
                            break;
                        case 23:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 05 y 09";
                            break;
                        case 24:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 09 y 13";
                            break;
                        case 25:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 03 y 08";
                            break;
                        case 26:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 02 y 07";
                            break;
                        case 27:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 07 y 12";
                            break;
                        case 28:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 01 y 06";
                            break;
                        case 29:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 06 y 11";
                            break;
                        case 30:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 11 y 16";
                            break;
                        case 31:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 05 y 10";
                            break;
                        case 32:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 10 y 15";
                            break;
                        case 33:
                            labelAristas.Text = "Ingrese un valor para la distancia entre el nodo 09 y 14";
                            break;
                    }
                    break;
            }
        }

        private void Inicializa_nodos()
        {
            nodos4[0] = new Camino_Variables(N41a2,0,1,1,2);
            nodos4[1] = new Camino_Variables(n41a4,0,2,1,4);
            nodos4[2] = new Camino_Variables(n41a3,0,3,1,3);
            nodos4[3] = new Camino_Variables(n42a4,0,4,2,4);
            nodos4[4] = new Camino_Variables(n43a4,0,5,3,4);

            nodos9[0] = new Camino_Variables(n91a2,0,1,1,2);
            nodos9[1] = new Camino_Variables(n92a3,0,1,2,3);
            nodos9[2] = new Camino_Variables(n94a5,0,2,4,5);
            nodos9[3] = new Camino_Variables(n95a6,0,2,5,6);
            nodos9[4] = new Camino_Variables(n97a8,0,3,7,8);
            nodos9[5] = new Camino_Variables(n98a9,0,3,8,9);
            nodos9[6] = new Camino_Variables(n91a4,0,4,1,4);
            nodos9[7] = new Camino_Variables(n94a7,0,4,4,7);
            nodos9[8] = new Camino_Variables(n92a5,0,5,2,5);
            nodos9[9] = new Camino_Variables(n95a8,0,5,5,8);
            nodos9[10] = new Camino_Variables(n93a6,0,6,3,6);
            nodos9[11] = new Camino_Variables(n96a9,0,6,6,9);
            nodos9[12] = new Camino_Variables(n92a6,0,7,2,6);
            nodos9[13] = new Camino_Variables(n91a5,0,8,1,5);
            nodos9[14] = new Camino_Variables(n95a9,0,8,5,9);
            nodos9[15] = new Camino_Variables(n94a8,0,9,4,8);

            nodos16[0] = new Camino_Variables(n161a2,0,1,1,2);
            nodos16[1] = new Camino_Variables(n162a3,0,1,2,3);
            nodos16[2] = new Camino_Variables(n163a4,0,1,3,4);
            nodos16[3] = new Camino_Variables(n165a6,0,2,5,6);
            nodos16[4] = new Camino_Variables(n166a7,0,2,6,7);
            nodos16[5] = new Camino_Variables(n167a8,0,2,7,8);
            nodos16[6] = new Camino_Variables(n169a10,0,3,9,10);
            nodos16[7] = new Camino_Variables(n1610a11,0,3,10,11);
            nodos16[8] = new Camino_Variables(n1611a12,0,3,11,12);
            nodos16[9] = new Camino_Variables(n1613a14,0,4,13,14);
            nodos16[10] = new Camino_Variables(n1614a15,0,4,14,15);
            nodos16[11] = new Camino_Variables(n1615a16,0,4,15,16);
            nodos16[12] = new Camino_Variables(n164a8,0,5,4,8);
            nodos16[13] = new Camino_Variables(n168a12,0,5,8,12);
            nodos16[14] = new Camino_Variables(n1612a16,0,5,12,16);
            nodos16[15] = new Camino_Variables(n163a7,0,6,3,7);
            nodos16[16] = new Camino_Variables(n167a11,0,6,7,11);
            nodos16[17] = new Camino_Variables(n1611a15,0,6,11,15);
            nodos16[18] = new Camino_Variables(n162a6,0,7,2,6);
            nodos16[19] = new Camino_Variables(n166a10,0,7,6,10);
            nodos16[20] = new Camino_Variables(n1610a14,0,7,10,14);
            nodos16[21] = new Camino_Variables(n161a5,0,8,1,5);
            nodos16[22] = new Camino_Variables(n165a9,0,8,5,9);
            nodos16[23] = new Camino_Variables(n169a13,0,8,9,13);
            nodos16[24] = new Camino_Variables(n163a8,0,9,3,8);
            nodos16[25] = new Camino_Variables(n162a7,0,10,2,7);
            nodos16[26] = new Camino_Variables(n167a12,0,10,7,12);
            nodos16[27] = new Camino_Variables(n161a6,0,11,1,6);
            nodos16[28] = new Camino_Variables(n166a11,0,11,6,11);
            nodos16[29] = new Camino_Variables(n1611a16,0,11,11,16);
            nodos16[30] = new Camino_Variables(n165a10,0,12,5,10);
            nodos16[31] = new Camino_Variables(n1610a15,0,12,10,15);
            nodos16[32] = new Camino_Variables(n169a14,0,13,9,14);
           
        }

        private void Mostrar_Nodos(Camino_Variables[] arreglo)
        {
            int conteo = 1;
            string mensaje = "";
            foreach (Camino_Variables element in arreglo)
            {

                mensaje += string.Format("Nodo {0} = ", conteo) + element.ToString() + "\n";
                conteo++;

            }
            MessageBox.Show(mensaje);
        }

        private void validar_txt(object sender, EventArgs e)
        {
            TextBox txtaux = (TextBox)sender;
            if (txtaux.Text != "")
            {
                try
                {
                    Convert.ToInt32(txtaux.Text);
                }
                catch
                {
                    MessageBox.Show("Ingrese solo valores enteros postivos");
                    txtaux.Text = "";
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cambiar_nodo(avanzar);
        }

        private void btnanterior_Click(object sender, EventArgs e)
        {
            Cambiar_nodo(retroceder);
        }

      
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (txtNodoInicio.Text == "" || txtNodoFinal.Text == "")
            {
                MessageBox.Show("Debe ingresar nodo de inicio y nodo destino");
                return;
            }


            nodo_inicio = (Convert.ToInt32(txtNodoInicio.Text)) - 1;
            nodo_final = (Convert.ToInt32(txtNodoFinal.Text)) - 1;
            penalizacion = Convert.ToInt32(txtPenalizacion.Text);

            if (nodo_inicio == nodo_final)
            {
                MessageBox.Show("Siempre el mejor camino hacia sí mismo es el silencio");
                return;
            }

            if (nodo_inicio+1 < 1 || nodo_final+1 < 1)
            {
                MessageBox.Show("El nodo de inicio tanto como el nodo final, no pueden ser menores a 1");
                return;
            }

            if ((opcion_nodos == 1 && nodo_inicio+1 > 4) || (nodo_final+1 > 4 && opcion_nodos ==1))
            {
                MessageBox.Show("El nodo de inicio tanto como el nodo final no pueden ser mayores a 4 para este grafo");
                return;
            }
            if ((opcion_nodos == 2 && nodo_inicio+1 > 9) || (nodo_final+1 > 9 && opcion_nodos == 2))
            {
                MessageBox.Show("El nodo de inicio tanto como el nodo final no pueden ser mayores a 9 para este grafo");
                return;
            }
            if ((opcion_nodos == 3 && nodo_inicio+1 > 16) || (nodo_final+1 > 16 && opcion_nodos == 3))
            {
                MessageBox.Show("El nodo de inicio tanto como el nodo final no pueden ser mayores a 16 en ningún grafo");
                return;
            }

            CEjecucion.inicio = nodo_inicio;
            CEjecucion.final = nodo_final;

            switch (opcion_nodos)
            {
                case 1:
                    CEjecucion.Ejecutar(nodos4);
                    break;
                case 2:
                    CEjecucion.Ejecutar(nodos9);
                    break;
                case 3:
                    CEjecucion.Ejecutar(nodos16);
                    break;
            }

            btnmostrarcamino.Visible = true;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnmostrarcamino_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CEjecucion.mensaje);
        }

        Color labelsinasignar = Color.Red;
        Color labelasignado = Color.Blue;
        Color fondosinasignar = Color.Transparent;
        Color fondoasignado = Color.White;
        private void LabelsA0(Camino_Variables[] array)
        {
            foreach (Camino_Variables a in array)
            {
                a.label.Text = "--";
                a.label.ForeColor=labelsinasignar;
                a.label.BackColor= fondosinasignar;
                //a.label.f
            }
        }

        private void NodosCargados(Camino_Variables[] array)
        { 
            bool completo = true;
            foreach (Camino_Variables a in array)
            {
                if (a.label.ForeColor == labelsinasignar)
                {
                    completo = false;
                }
            }

            if (completo)
            {
                btnEjecutar.Enabled = true;
            }
            else 
            {
                btnEjecutar.Enabled = false;
            }
        
        }
    }

}
