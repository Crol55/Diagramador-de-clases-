using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;
using System.Windows.Forms;
using Diagramacion_De_Clases_JAVA.Arbol.Grafo;
using Diagramacion_De_Clases_JAVA.Arbol.Intrucciones_clase;

namespace Diagramacion_De_Clases_JAVA.Arbol
{
    class RecorrerArbol:Grammar    {
      static  string nombreClase = "";

        public static string  Recorrer(ParseTreeNode raiz,string str) {

            switch (raiz.ToString()) {
                case "INICIO": { str = Recorrer(raiz.ChildNodes[0],""); }break;

                case "CUERPO": {/*SOLO INGRESA UNA VEZ*/

                        switch (raiz.ChildNodes.Count) {

                            case 2: {// ID+ INSTRUCCIONES_CLASE
                                    nombreClase = raiz.ChildNodes[0].ToString().Replace(" (ID)", "");
                                    EstructuraUML uml = new EstructuraUML();
                                    uml.Clase = nombreClase;                                   
                                    uml= instrucciones_clase.Recorrer(raiz.ChildNodes[1], uml); //---> INSTRUCCIONES_CLASE

                                    GrafoUml g = new GrafoUml();
                                    str = g.ModelarClase_EnUml(uml,"");
                                    //g.GrafoUML_Dot(uml);


                                } break;

                            case 3: {// ACCESO + ID + INSTRUCCIONES_CLASE 

                                    nombreClase = raiz.ChildNodes[1].ToString().Replace(" (ID)", "");
                                    EstructuraUML uml = new EstructuraUML();
                                    uml.Clase = nombreClase;                                
                                    uml=instrucciones_clase.Recorrer(raiz.ChildNodes[2], uml); //---> INSTRUCCIONES_CLASE

                                    GrafoUml g = new GrafoUml();
                                    str = g.ModelarClase_EnUml(uml, "");
                                } break;

                            case 4: {// ID + extends + LI_ID  + INSTRUCCIONES_CLASE 

                                    nombreClase = raiz.ChildNodes[0].ToString().Replace(" (ID)", "");
                                    EstructuraUML uml = new EstructuraUML();
                                    uml.Clase = nombreClase;                                    
                                    uml= instrucciones_clase.Recorrer(raiz.ChildNodes[3], uml); //---> INSTRUCCIONES_CLASE

                                    GrafoUml g = new GrafoUml();
                                    str = g.ModelarClase_EnUml(uml, "");
                                } break;

                            case 5: {//ACCESO + ID+ extends + LI_ID + NSTRUCCIONES_CLASE
                                    nombreClase = raiz.ChildNodes[1].ToString().Replace(" (ID)", "");
                                    EstructuraUML uml = new EstructuraUML();
                                    uml.Clase = nombreClase;
                                    uml= instrucciones_clase.Recorrer(raiz.ChildNodes[4], uml); //---> INSTRUCCIONES_CLASE

                                    GrafoUml g = new GrafoUml();
                                    str = g.ModelarClase_EnUml(uml, "");
                                }
                                break;
                        }// cierre switch
                    } break; // break de CUERPO



                
            }


            return str;
        }



    }
}
