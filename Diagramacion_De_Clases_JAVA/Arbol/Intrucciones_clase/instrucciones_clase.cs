using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using System.Windows.Forms;
using Diagramacion_De_Clases_JAVA.Arbol.Intrucciones_clase.Constructor;
using Diagramacion_De_Clases_JAVA.Arbol.Intrucciones_clase.Metodos;
namespace Diagramacion_De_Clases_JAVA.Arbol.Intrucciones_clase
{
    class instrucciones_clase:Grammar{

        public static EstructuraUML Recorrer(ParseTreeNode raiz,EstructuraUML uml) {

            switch (raiz.ToString()) {

                case "INSTRUCCIONES_CLASE": {

                        foreach (ParseTreeNode hijo in raiz.ChildNodes) { //siempre tendra---> LI_INSTRUCCIONES_CLASE
                          uml =  Recorrer(hijo,uml);//---->LI_INSTRUCCIONES_CLASE

                        }


                    } break;

                case "LI_INSTRUCCIONES_CLASE": {
                      uml =  Recorrer(raiz.ChildNodes[0],uml);//----> DECLARACION | CONSTRUCTOR_PRINCIPAL | METODOS | OVERRIDE


                    } break;

                case "DECLARACION": {
                        Declaracion.Atributo at = new Declaracion.Atributo();
                       at= Declaracion.Recorrer(raiz,at);//----> DECLARACION.Rule
                        uml.Atributos.Add(at); // agregamos cada atributo
                        //int conta = 0;
                        //foreach (var item in at.nombreVariable){
                        //    MessageBox.Show(at.simbolo.ToString() + " " + at.tipo + " " + at.nombreVariable[conta]);
                        //    conta++;
                        //}
                    }
                    break;

                case "CONSTRUCTOR_PRINCIPAL": {
                        //constructor c = new Constructor.constructor();
                        Metodo c = new Metodo();
                        c = constructor_principal.Recorrer(raiz,c);
                        uml.Metodos.Add(c);
                        //int conta = 0;
                        //foreach (var item in c.parametros){
                        //    MessageBox.Show(c.simbolo.ToString() + " " + c.nombre + "("+c.parametros[conta] +")" );
                        //    conta++;
                        //}

                    }
                    break;

                case "METODOS": { // FUNCIONAL PARA (METODO,FUNCION,OVERRIDE)
                        Metodo m = new Metodo();
                        m = metodos.Recorrer(raiz,m);
                        uml.Metodos.Add(m);
                        //int conta = 0;
                        //foreach (var item in m.parametros)
                        //{
                        //    MessageBox.Show(m.simbolo.ToString()+" "+m.tipo + " " + m.nombre + "(" + m.parametros[conta] + ")");
                        //    conta++;
                        //}

                    }
                    break;

                case "OVERRIDE": {
                        Metodo Override = new Metodo();
                        Override = metodos.Recorrer(raiz, Override);
                        uml.Metodos.Add(Override);
                        //    MessageBox.Show(Override.simbolo.ToString()+" "+Override.tipo + " " + Override.nombre + "(" + Override.parametros[0] + ")");


                    }
                    break;



            }


            return uml;
        }



    }
}
