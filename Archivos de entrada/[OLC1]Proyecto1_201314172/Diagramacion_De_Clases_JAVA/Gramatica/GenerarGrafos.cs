using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;
using System.IO;
using System.Diagnostics;

namespace Diagramacion_De_Clases_JAVA.Gramatica
{
    class GenerarGrafos
    {
        private  int contador;
        private  string texto;


        public  void GenerarImagenAST(string archivoDot, string nombreArchivo)
        {
            Process a = new Process();
            a.StartInfo.FileName = "\"C:\\release\\bin\\dot.exe\"";
            a.StartInfo.Arguments = "-Tpng " + archivoDot + " -o" + nombreArchivo;
            a.StartInfo.UseShellExecute = false;
            a.Start();
            a.WaitForExit();
        }

        public  void generarDot(ParseTreeNode raiz)
        {

            texto += "digraph G{\n";
            texto += "nodo0[label=\"" + escapar(raiz.ToString()) + "\"];\n";

            contador = 1;
            recorrerAST("nodo0", raiz);
            texto += "}";
            //-----------------------Generamos el archivo .dot, de lo que concateno texto-------
            StreamWriter w = new StreamWriter("AST.dot");
            w.WriteLine(texto);
            w.Close();
            GenerarImagenAST("AST.dot", "AST.png"); // Generamos la imagen 
                                                           }


        public void recorrerAST(String padre, ParseTreeNode hijos)
        { 

            foreach (ParseTreeNode hijo in hijos.ChildNodes)
            {
                //  MessageBox.Show(hijo.ToString());
                string nombrehijo = "nodo" + contador.ToString();
                texto += nombrehijo + "[label=\"" + escapar(hijo.ToString()) + "\"];\n";

                texto += padre + "->" + nombrehijo + ";\n";
                contador++;
                recorrerAST(nombrehijo, hijo);
            }
        }

        private string escapar(string cadena){

            cadena = cadena.Replace("\\", "\\\\");
            cadena = cadena.Replace("\"", "\\\"");
            return cadena;
        }
    }
}
