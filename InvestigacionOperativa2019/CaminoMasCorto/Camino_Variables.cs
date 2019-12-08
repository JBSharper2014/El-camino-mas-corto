using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace CaminoMasCorto
{
    public class Camino_Variables
    {
        private Camino_Variables[] variables;

        private Label _label;
        private int _peso;
        private int _carretera;
        private int _nodo_inicio;
        private int _nodo_final;

        public Label label { get { return _label;} set  {_label = value; }}
        public int peso { get {return _peso;} set { _peso = value; }}
        public int carretera { get {return _carretera;} set { _carretera = value; }}
        public int nodoInicio { get {return _nodo_inicio;} set { _nodo_inicio = value; }}
        public int nodoFinal { get { return _nodo_final; } set { _nodo_final = value; } }

        public Camino_Variables() { }
        public Camino_Variables(Label label, int peso, int carretera,int nodoInicio, int nodoFinal)
        {
            _label = label;
            _peso = peso;
            _carretera = carretera;
            _nodo_final = nodoFinal;
            _nodo_inicio = nodoInicio;
        }

        public override string ToString()
        {
            return string.Format("Peso : {0}, carretera: {1}", _peso, _carretera);
        }

        public Camino_Variables this[int index]
        {
            get
            {
                return variables[index];
            }

            set
            {
                variables[index] = value;
            }
        }
    }

}

