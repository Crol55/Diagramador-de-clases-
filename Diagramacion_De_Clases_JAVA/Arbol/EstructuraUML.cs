using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Diagramacion_De_Clases_JAVA.Arbol
{
    class EstructuraUML{
        public string Clase;
        public ArrayList Atributos;
        public ArrayList Metodos;

        public EstructuraUML() {
            this.Clase = "";
            this.Atributos = new ArrayList();
            this.Metodos = new ArrayList();
        }


    }
}
