using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagramacion_De_Clases_JAVA
{
    class Error{

      public string Descripcion;
      public string tipo;
      public string fila;
      public string columna;


        public Error(string Descripcion,string tipo,string fila,string columna) {// constructor;
            this.Descripcion = Descripcion;
            this.tipo = tipo;
            this.fila = fila;
            this.columna = columna;

        }
    }
}
