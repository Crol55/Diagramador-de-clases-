using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Interpreter;
using Irony.Parsing;

namespace Diagramacion_De_Clases_JAVA.Gramatica
{
    class sintactico:Grammar{
       static ParseTreeNode Raiz;
        public static bool analizar(string cadena) {
            bool ret = false;

            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);// Genera arbol a partir de la cadena de entrada
            ParseTreeNode raiz = arbol.Root;
            Raiz = raiz;
            if (raiz==null) {
                ret = false;

            }else {
                ret = true;
            //   GenerarArbolAst(raiz);
            }

            return ret;

        }

        private static void GenerarArbolAst(ParseTreeNode raiz) {
            GenerarGrafos grafos = new GenerarGrafos();
            grafos.generarDot(raiz); //  Genera el Arbol Ast en una imagen .png
            
        }

        public static ParseTreeNode getRaiz() {

            return Raiz ;
        }

    }
}
