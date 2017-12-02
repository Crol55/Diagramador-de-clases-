using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Parsing;
using Diagramacion_De_Clases_JAVA.Arbol.Intrucciones_clase.Metodos;
namespace Diagramacion_De_Clases_JAVA.Arbol.Intrucciones_clase.Constructor
{
    class constructor_principal:Grammar {


        public static Metodo Recorrer(ParseTreeNode raiz, Metodo constructr) {

            switch (raiz.ToString()) {
                case "CONSTRUCTOR_PRINCIPAL": {
                       
                        switch (raiz.ChildNodes.Count) {
                            case 3:{//----> ID + LI_PARAM + INSTRUCCIONES
                                    constructr.simbolo = '~';
                                    constructr.tipo = "";
                                    constructr.nombre = raiz.ChildNodes[0].ToString().Replace(" (ID)","");
                                    constructr = Recorrer(raiz.ChildNodes[1],constructr);//-> LI_PARAM.Rule
                                   
                                   
                                } break;

                            case 4: {//--->ACCESO + ID + LI_PARAM  + INSTRUCCIONES
                                    constructr.tipo = "";
                                    constructr = Recorrer(raiz.ChildNodes[0],constructr);//---> ACCESO.Rule
                                    constructr.nombre = raiz.ChildNodes[1].ToString().Replace(" (ID)", "");
                                    constructr = Recorrer(raiz.ChildNodes[2], constructr);//-> LI_PARAM.Rule


                                } break;
                        }//switch
                    } break;

                case "LI_PARAM": {
                       
                        foreach (ParseTreeNode hijo in raiz.ChildNodes){
                            constructr = Recorrer(hijo,constructr);//---->PARAM.Rule

                        }

                    } break;

                case "PARAM": {//---> TIPO + ID    |   OBJETO + ID;
                       
                        string param="";
                        string []tipo = raiz.ChildNodes[0].ChildNodes[0].ToString().Split(' ');

                        param=tipo[0]+" "+raiz.ChildNodes[1].ToString().Replace(" (ID)","");
                        constructr.parametros.Add(param);// agrega---> (TIPO|OBJETO) (ID)

                    
                    } break;

                case "ACCESO": {
                        string[] val = raiz.ChildNodes[0].ToString().Split(' ');
                        switch (val[0]){

                            case "public": { constructr.simbolo = '+'; } break;
                            case "private": { constructr.simbolo = '-'; } break;
                            case "protected": { constructr.simbolo = '#'; } break;
                        }


                    } break;
            }// switch

            return constructr;
        }


    }
}
