using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using System.Windows.Forms;

namespace Diagramacion_De_Clases_JAVA.Arbol.Intrucciones_clase.Metodos
{
    class metodos:Grammar{

        public static Metodo Recorrer(ParseTreeNode raiz, Metodo metodo) {
            switch (raiz.ToString()) {
                case "METODOS": {
                        metodo = Recorrer(raiz.ChildNodes[0],metodo);//----> METODO | FUNCION

                    } break;
                #region METODO
                      case "METODO": {
                        switch (raiz.ChildNodes.Count) {
                            case 5: {//---> ACCESO + voidd + ID + LI_PARAM   + INSTRUCCIONES 
                                
                                    metodo = Recorrer(raiz.ChildNodes[0], metodo);//----> ACCESO.Rule
                                    metodo.tipo = raiz.ChildNodes[1].ToString().Replace(" (Keyword)", "");
                                    metodo.nombre = raiz.ChildNodes[2].ToString().Replace(" (ID)", "");
                                    metodo = Recorrer(raiz.ChildNodes[3],metodo);//--->LI_PARAM.Rule

                           
                                } break;
                            case 4: {//---> voidd + ID + LI_PARAM + INSTRUCCIONES 
                                    metodo.tipo = raiz.ChildNodes[0].ToString().Replace(" (KeyWord)", "");
                                    metodo.nombre = raiz.ChildNodes[1].ToString().Replace(" (ID)", "");
                                    metodo = Recorrer(raiz.ChildNodes[2], metodo);//--->LI_PARAM.Rule


                                } break;
                        }

                    } break;

                #endregion


                #region FUNCION

                     case "FUNCION": {
                        switch (raiz.ChildNodes.Count) {
                            case 4: {//  OBJETO + ID + LI_PARAM + INSTRUCCIONES_FUNCION
                                     //  TIPO + ID + LI_PARAM + INSTRUCCIONES_FUNCION 
                                    metodo.simbolo ='~';
                                    metodo = Recorrer(raiz.ChildNodes[0], metodo);//--> OBJETO.Rule | TIPO.Rule
                                    metodo.nombre = raiz.ChildNodes[1].ToString().Replace(" (ID)","");
                                    metodo = Recorrer(raiz.ChildNodes[2],metodo); //--->LI_PARAM.Rule
                                   

                                } break;

                            case 5:{//ACCESO + TIPO + ID + LI_PARAM  + INSTRUCCIONES_FUNCION 
                                    // ACCESO + OBJETO + ID + LI_PARAM + INSTRUCCIONES_FUNCION
                                    metodo = Recorrer(raiz.ChildNodes[0],metodo);//-->ACCESO.Rule
                                    metodo = Recorrer(raiz.ChildNodes[1], metodo);//--> OBJETO.Rule | TIPO.Rule
                                    metodo.nombre = raiz.ChildNodes[2].ToString().Replace(" (ID)", "");
                                    metodo = Recorrer(raiz.ChildNodes[3], metodo); //--->LI_PARAM.Rule

                                }
                                break;
                          
                        }


                    } break;
                #endregion


                #region OVERRIDE
                case "OVERRIDE": {

                        switch (raiz.ChildNodes.Count) {

                            case 3: {// ID  + LI_PARAM + INSTRUCCIONES
                                    metodo.simbolo = '~';
                                    metodo.tipo = "";
                                    metodo.nombre = raiz.ChildNodes[0].ToString().Replace(" (ID)","");
                                    metodo = Recorrer(raiz.ChildNodes[1],metodo);//-->LI_PARAM.Rule

                                } break;

                            case 4:{
                                                                     
                                    switch (raiz.ChildNodes[0].ToString()) {
                                         case "DEFINICION": {  // DEFINICION + ID + LI_PARAM +  INSTRUCCIONES_FUNCION  

                                                metodo.simbolo = '~';
                                                metodo = Recorrer(raiz.ChildNodes[0], metodo);//--->DEFINICION.Rule
                                                metodo.nombre = raiz.ChildNodes[1].ToString().Replace(" (ID)", "");
                                                metodo = Recorrer(raiz.ChildNodes[2], metodo);//-->LI_PARAM.Rule

                                            } break;
                                        case "VISIBILIDAD": {// VISIBILIDAD + ID + LI_PARAM +  INSTRUCCIONES
                                    
                                                metodo = Recorrer(raiz.ChildNodes[0],metodo);//--->VISIBILIDAD.Rule
                                                metodo.tipo = "";
                                                metodo.nombre = raiz.ChildNodes[1].ToString().Replace(" (ID)", "");
                                                metodo = Recorrer(raiz.ChildNodes[2], metodo);//-->LI_PARAM.Rule

                                            } break;

                                        default: {////  voidd + ID + LI_PARAM  + INSTRUCCIONES 
                                              
                                                metodo.simbolo = '~';
                                                metodo.tipo = "void";
                                                metodo.nombre = raiz.ChildNodes[1].ToString().Replace(" (ID)", "");
                                                metodo = Recorrer(raiz.ChildNodes[2], metodo);//-->LI_PARAM.Rule


                                            } break;

                                    }

                                }
                                break;

                            case 5: {// 5 hijos
                                  

                                    switch (raiz.ChildNodes[1].ToString()) {

                                        case "DEFINICION": {// VISIBILIDAD + DEFINICION + ID + LI_PARAM + INSTRUCCIONES_FUNCION
                                        
                                                metodo = Recorrer(raiz.ChildNodes[0],metodo);//--->VISIBILIDAD.Rule
                                                metodo = Recorrer(raiz.ChildNodes[1],metodo);//---->DEFINICION.Rule
                                                metodo.nombre = raiz.ChildNodes[2].ToString().Replace(" (ID)", "");
                                                metodo = Recorrer(raiz.ChildNodes[3],metodo);//-------->LI_PARAM.Rule

                                            }
                                            break;

                                        default: {// VISIBILIDAD + voidd  + ID + LI_PARAM  + INSTRUCCIONES
                                          
                                                metodo = Recorrer(raiz.ChildNodes[0], metodo);//--->VISIBILIDAD.Rule
                                                metodo.tipo = "void";
                                                metodo.nombre = raiz.ChildNodes[2].ToString().Replace(" (ID)", "");
                                                metodo = Recorrer(raiz.ChildNodes[3], metodo);//-------->LI_PARAM.Rule

                                            } break;


                                    }

                                }
                                break;
                        }


                    } break;

                #endregion

                case "DEFINICION": { // TIPO | OBJETO
                        metodo = Recorrer(raiz.ChildNodes[0],metodo);//--> TIPO.Rule | OBJETO.Rule

                    } break;

                case "VISIBILIDAD": {
                        string[] val = raiz.ChildNodes[0].ToString().Split(' ');
                        switch (val[0])
                        {
                            case "public": { metodo.simbolo = '+'; } break;
                            case "protected": { metodo.simbolo = '#'; } break;

                        }
                    } break;

                case "ACCESO":{

                        string[] val = raiz.ChildNodes[0].ToString().Split(' ');
                        switch (val[0]){
                            case "public": { metodo.simbolo = '+'; } break;
                            case "private": { metodo.simbolo = '-'; } break;
                            case "protected": { metodo.simbolo = '#'; } break;

                        }
                    }break;

                case "LI_PARAM":
                    {

                        foreach (ParseTreeNode hijo in raiz.ChildNodes)
                        {
                            metodo = Recorrer(hijo, metodo);//---->PARAM.Rule

                        }

                    }
                    break;

                case "PARAM":
                    {//---> TIPO + ID    |   OBJETO + ID;
                        string param = "";
                        string[] tipo = raiz.ChildNodes[0].ChildNodes[0].ToString().Split(' ');

                        param = tipo[0] + " " + raiz.ChildNodes[1].ToString().Replace(" (ID)", "");
                       metodo.parametros.Add(param);// agrega---> (TIPO|OBJETO) (ID)


                    } break;

                case "OBJETO": {
                        metodo.tipo = raiz.ChildNodes[0].ToString().Replace(" (ID)","");

                    } break;
                case "TIPO": {
                        string[] tip = raiz.ChildNodes[0].ToString().Split(' ');
                        metodo.tipo = tip[0];
                    } break;


            }

              
              


                return metodo;
        }

    }
}
