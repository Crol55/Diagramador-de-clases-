using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Irony.Parsing;
using System.Windows.Forms;

namespace Diagramacion_De_Clases_JAVA
{
    class verificadorControl
    {
        public static ArrayList NodoAgregacion;
        public static string ID ="";

        public static string verificacion(ParseTreeNode raiz, ArrayList Clases,string ret) {
            // aqui se genera HERENCIA de clases
            // clase para verificar la existencia cuando se realiza un extend o se quiere usar un objeto
            switch (raiz.ToString()) {
                case "INICIO": {
                        ret = verificacion(raiz.ChildNodes[0],Clases,ret);
                    } break;
                case "CUERPO": {
                        switch (raiz.ChildNodes.Count) {

                            case 2: {// ID+ INSTRUCCIONES_CLASE
                                    ID = raiz.ChildNodes[0].ToString().Replace(" (ID)", "");

                                    NodoAgregacion = new ArrayList();
                                    agregacion(ID, raiz.ChildNodes[1], "", Clases);//----> CREANDO AGREGACION
                                    string arrow = " [dir=both arrowhead=\"vee\" arrowtail=\"ediamond\"]\n";
                                    for (int i = 0; i < NodoAgregacion.Count; i++)
                                    {
                                        ret += NodoAgregacion[i] + arrow;

                                    }
                                }
                                break;
                            case 3: {// ACCESO + ID + INSTRUCCIONES_CLASE 
                                    ID = raiz.ChildNodes[1].ToString().Replace(" (ID)", "");
                                    NodoAgregacion = new ArrayList();
                                    agregacion(ID, raiz.ChildNodes[2], "", Clases);//----> CREANDO AGREGACION
                                    string arrow = " [dir=both arrowhead=\"vee\" arrowtail=\"ediamond\"]\n";
                                    for (int i = 0; i < NodoAgregacion.Count; i++)
                                    {
                                        ret += NodoAgregacion[i] + arrow;

                                    }

                                } break;

                            case 4: {// ID + extends + LI_ID  + INSTRUCCIONES_CLASE 
                                    ID = raiz.ChildNodes[0].ToString().Replace(" (ID)","");
                                    ret = verificacion(raiz.ChildNodes[2], Clases, ret);//--->CREANDO HERENCIA
                                    NodoAgregacion = new ArrayList();
                                    agregacion(ID,raiz.ChildNodes[3],"",Clases);//----> CREANDO AGREGACION
                                    string arrow = " [dir=both arrowhead=\"vee\" arrowtail=\"ediamond\"]\n";
                                    for (int i = 0; i < NodoAgregacion.Count; i++) {
                                        ret += NodoAgregacion[i] + arrow ;
                                                                       
                                    }
                                 
                                } break;
                            case 5: {// ACCESO + ID+ extends + LI_ID + NSTRUCCIONES_CLASE
                                    ID = raiz.ChildNodes[1].ToString().Replace(" (ID)", "");                                 
                                    ret = verificacion(raiz.ChildNodes[3], Clases, ret);//---->CREANDO HERENCIA
                                    NodoAgregacion = new ArrayList();
                                    agregacion(ID,raiz.ChildNodes[4], "",Clases);//----> CREANDO AGREGACION
                                    string arrow = " [dir=both arrowhead=\"vee\" arrowtail=\"ediamond\"]\n";
                                    for (int i = 0; i < NodoAgregacion.Count; i++) {
                                        ret += NodoAgregacion[i] + arrow ;
                                                                       
                                    }
                                   
                                }
                                break;
                        }
                    } break;

                case "LI_ID": {
                        // aqui verificamos si en realidad existe la clase de la cual se quiere extender
                        foreach (var hijo in raiz.ChildNodes) {//----> a cada ID
                            string id = hijo.ToString().Replace(" (ID)","");
                                                 
                            if (Clases.Contains(id)) {
                              //  MessageBox.Show("la extension: si existe");
                                ret += ID + "->" + id+ " [dir=forward arrowhead=\"empty\"]";

                            }else {
                                Form1.lista_Errores.Add(new Error("La extension ->"+id+" no existe","Control","-","-"));
                                MessageBox.Show("la extension: no existe");
                            }
                        }


                    } break;

            }

         
            return ret;
        }

        public static void agregacion(string clase,ParseTreeNode raiz, string str, ArrayList Clases) {


            foreach (var hijo in raiz.ChildNodes) {

                switch (hijo.ToString()) {
                    case "VARIABLES": {
                           Objeto(clase,hijo,str,Clases);
                        }break;

                    case "LOCALES": {
                           Objeto(clase,hijo, str,Clases);
                        } break;

                    case "FUNCION": {
                            switch (hijo.ChildNodes.Count) {
                               case 4: {//  OBJETO + ID + LI_PARAM + INSTRUCCIONES_FUNCION
                                        //  TIPO + ID + LI_PARAM + INSTRUCCIONES_FUNCION 
                                         Objeto(clase,hijo.ChildNodes[0],str,Clases);
                                        agregacion(clase,hijo.ChildNodes[3],str,Clases);
                                } break;

                            case 5:{//ACCESO + TIPO + ID + LI_PARAM  + INSTRUCCIONES_FUNCION 
                                    // ACCESO + OBJETO + ID + LI_PARAM + INSTRUCCIONES_FUNCION
                                        Objeto(clase, hijo.ChildNodes[1], str, Clases);
                                         agregacion(clase, hijo.ChildNodes[4], str, Clases);//---->LOCALES
                                    } break;
                            }
                         
                        } break;

                    case "METODOS": {
                            switch (hijo.ChildNodes.Count) {
                                case 4: {//---> voidd + ID + LI_PARAM + INSTRUCCIONES 
                                         agregacion(clase, hijo.ChildNodes[3], str, Clases);//--->LOCALES

                                    } break;
                                case 5: {//----> ACCESO + voidd + ID + LI_PARAM   + INSTRUCCIONES 
                                       agregacion(clase, hijo.ChildNodes[4], str, Clases);//--->LOCALES

                                    }
                                    break;

                            }

                        } break;

                    case "OVERRIDE": {
                            switch (hijo.ChildNodes.Count) {
                                case 4: {
                                        if (hijo.ChildNodes[0].ToString().Contains("DEFINICION")) {
                                            // DEFINICION + ID + LI_PARAM +  INSTRUCCIONES_FUNCION 
                                           Objeto(clase,hijo.ChildNodes[0],str,Clases);
                                           agregacion(clase, hijo.ChildNodes[3], str, Clases);//---->LOCALES
                                        }


                                    } break;
                                case 5: {
                                        if (hijo.ChildNodes[1].ToString().Contains("DEFINICION")) {
                                            // VISIBILIDAD + DEFINICION + ID + LI_PARAM + INSTRUCCIONES_FUNCION
                                             Objeto(clase, hijo.ChildNodes[1], str, Clases);
                                            agregacion(clase, hijo.ChildNodes[4], str, Clases);//---->LOCALES
                                        }
                                    } break;

                            }

                        } break;
                 
                }
               agregacion(clase,hijo,str,Clases);

            }

         //   return str;
        }

        public static void Objeto(string clase,ParseTreeNode raiz, string str,ArrayList Clases)
        {
                foreach (var hijo in raiz.ChildNodes) {

                switch (hijo.ToString()) {
                    
                    case "OBJETO": {
                         //   MessageBox.Show(hijo.ChildNodes[0].ToString());
                            string objeto = hijo.ChildNodes[0].ToString().Replace(" (ID)", "");

                            if (Clases.Contains(objeto)) {
                              //   MessageBox.Show("el objeto a crear si existe");
                                string nuevaEtiqueta = clase + "->" + objeto + "\n";
                              //  str += clase + "->" + objeto+"\n";
                                if (!NodoAgregacion.Contains(nuevaEtiqueta)) {
                                    NodoAgregacion.Add(nuevaEtiqueta);
                                }
                              
                            }
                            else {
                                Form1.lista_Errores.Add(new Error("El objeto a crear ->" + objeto + " no existe", "Control", "-", "-"));
                                MessageBox.Show("el objeto a crear no existe:comparando ");

                            }
                           
                          

                        } break;
                }
                // str= agregacion(clase,hijo,str,Clases);
                agregacion(clase, hijo, str, Clases);

            }


          //  return str;

        }
    }



   
}
