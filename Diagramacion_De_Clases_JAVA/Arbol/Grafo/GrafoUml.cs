using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diagramacion_De_Clases_JAVA.Arbol.Intrucciones_clase.Metodos;
using Diagramacion_De_Clases_JAVA.Arbol.Intrucciones_clase;


namespace Diagramacion_De_Clases_JAVA.Arbol.Grafo
{
    class GrafoUml {
        
        string estructuraGrafo = "";
        private void GenerarImagenGrafoUml(string archivoDot,string nombreArchivo) {
 
            Process a = new Process();
            a.StartInfo.FileName = "\"C:\\release\\bin\\dot.exe\"";
             a.StartInfo.Arguments = "dot -Tpng " + archivoDot + " -o" + nombreArchivo;
         //   a.StartInfo.Arguments = "dot -Tpng prueba.dot -o output.png";
            a.StartInfo.UseShellExecute = false;
            a.Start();
            a.WaitForExit();
            //dot - T png - o class.png class.dot
    }

        public void GrafoUML_Dot(string etiquetas) {// esta es la que se llama afuera de la clase GrafoUml.cs



            estructuraGrafo += "digraph G{\n";
            estructuraGrafo += "fontname = \"Bitstream Vera Sans\" \n";
            estructuraGrafo += "fontsize = 9 \n";

            estructuraGrafo += "node[\n";
            estructuraGrafo += "fontname = \"Bitstream Vera Sans\"\n";
            estructuraGrafo += "fontsize = 8\n";
            estructuraGrafo += "shape = \"record\"\n";
            estructuraGrafo += "]\n";
            estructuraGrafo += "edge [\n";
           // estructuraGrafo += "arrowhead = \"empty\" \n";
            estructuraGrafo += "fontname = \"Bitstream Vera Sans\"\n";
            estructuraGrafo += "fontsize = 8\n";
            estructuraGrafo += "] \n";
            //estructuraGrafo += ModelarClase_EnUml(estructura,"");//"animal[\n  label = \"{ Animal | +name : string\\l + age : int\\l | +die() : void\\l}\"\n] \n";
            estructuraGrafo += etiquetas;
          //  estructuraGrafo += "Alumno->Auxiliar [dir=forward arrowhead=\"empty\"]";// [dir=both arrowhead=\"empty\" arrowtail=\"ediamond\"] 
            estructuraGrafo += "}";
            //Generar archivo.Dot
            StreamWriter w = new StreamWriter("Grafo.dot");
            w.WriteLine(estructuraGrafo);
            w.Close();
            //
            // Crear la imagen .png del archivo Dot previamente creado

            GenerarImagenGrafoUml("Grafo.dot","Grafo.png");
            //
            //MessageBox.Show(estructuraGrafo);
            
        }

        public string ModelarClase_EnUml(EstructuraUML estructura,string concat) {
            /*
             -clase
             -atributos
             -metodos y funciones
             
             */
            string clase=estructura.Clase;
            concat += clase+"[ label = \"{"+clase +"| ";


            Declaracion.Atributo aux = new Declaracion.Atributo();
            for (int i = 0; i < estructura.Atributos.Count; i++){// accesar a todos los atributos declarados por una clase
                aux =(Declaracion.Atributo)estructura.Atributos[i];
                foreach (var nombreVar in aux.nombreVariable) {// ingresamos a todos los ID's que se colocaron en una unica declaracion ej (int x,a,b)

                    concat +=aux.simbolo +" "+aux.tipo+" "+nombreVar+"\\l";
                }
                
            }
            concat += "| ";

            Metodo auxm = new Metodo();
            for (int i = 0; i < estructura.Metodos.Count; i++){// accesar a todos los metodos declarados en una clase
                auxm = (Metodo) estructura.Metodos[i];
                string param="";

                for (int j = 0; j < auxm.parametros.Count; j++){
                    if (j==auxm.parametros.Count-1) {
                        param += auxm.parametros[j];
                    }else {
                        param += auxm.parametros[j] + ",";
                    }
                   
                }
                
                concat += auxm.simbolo+ " "+auxm.tipo +" "+auxm.nombre+" ("+param+")\\l";
            }

            concat += "}\" ]";
           // MessageBox.Show("mierda: "+concat);
            return concat;

        }



    }
}
