using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagramacion_De_Clases_JAVA.Arbol
{
    class clasejava
    {
        int num_pestaña;
        string nombreclase;
        string codigo;
        string ruta_acceso;
        
        
        public clasejava(int pestaña,string nombre,string codigo,string path) {
          
            this.num_pestaña = pestaña;
            this.nombreclase = nombre;
            this.codigo = codigo;
            this.ruta_acceso = path;

        }

        public int f_num_pestaña {

            get  { return this.num_pestaña; }
            set { this.num_pestaña = value; }
        }

        public string f_codigo {
            get { return this.codigo; }
            set { this.codigo = value; }

        }

        public string f_ruta_acceso {
            get { return this.ruta_acceso; }
            set { this.ruta_acceso = value; }

        }

        public string f_nombreclase {
            get { return this.nombreclase; }
            set { this.nombreclase = value; }
        }

        public bool  prueba(int x) {

           


            return false;
        }
    }
}
