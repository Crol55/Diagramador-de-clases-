using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using System.Windows.Forms;
using System.Collections;

namespace Diagramacion_De_Clases_JAVA.Arbol.Intrucciones_clase
{
  
    class Declaracion:Grammar 
    {
        public  class Atributo
        {
            public char simbolo;
            public string tipo;
            public ArrayList nombreVariable = new ArrayList();
        }


        public static Atributo Recorrer(ParseTreeNode raiz, Atributo atributo) {
        
           
            switch (raiz.ToString()) {
                case "DECLARACION": {
                      atributo=  Recorrer(raiz.ChildNodes[0],atributo);//---->VARIABLES.Rule

                    } break;

                #region VARIABLES 
                case "VARIABLES":
                    {
                        switch (raiz.ChildNodes.Count){

                            case 2:{ // 2 hijos

                                    switch (raiz.ChildNodes[0].ToString()){

                                        case "OBJETO": { // ---> OBJETO + LI_ID 
                                               // MessageBox.Show("variable tipo objeto");
                                                atributo.simbolo = '~';
                                                atributo = Recorrer(raiz.ChildNodes[0], atributo);//--->OBJETO.Rule
                                                atributo = Recorrer(raiz.ChildNodes[1],atributo);//---->LI_ID.Rule
                                                                                               
                                                          
                                            }
                                            break;
                                        case "TIPO":{//----> TIPO + LI_ID 
                                             //   MessageBox.Show("variable tipo normal");
                                                atributo.simbolo = '~';
                                                atributo = Recorrer(raiz.ChildNodes[0], atributo);//--->TIPO.Rule
                                                atributo = Recorrer(raiz.ChildNodes[1], atributo);//---->LI_ID.Rule

                                            }
                                            break;
                                    }

                                }
                                break;

                            case 3:{ // 3 hijos

                                    switch (raiz.ChildNodes[0].ToString()){
                                        case "ACCESO":{
                                                switch (raiz.ChildNodes[1].ToString()){

                                                    case "OBJETO":{//-->ACCESO + OBJETO + LI_ID 
                                                           // MessageBox.Show("1");
                                                            atributo = Recorrer(raiz.ChildNodes[0], atributo);//--->ACCESO.Rule
                                                            atributo = Recorrer(raiz.ChildNodes[1], atributo);//--->OBJETO.Rule
                                                            atributo = Recorrer(raiz.ChildNodes[2], atributo);//---->LI_ID.Rule


                                                        } break;

                                                    case "TIPO":{//----->ACCESO + TIPO + LI_ID 
                                                           // MessageBox.Show("2");
                                                            atributo = Recorrer(raiz.ChildNodes[0],atributo);//--->ACCESO.Rule
                                                            atributo = Recorrer(raiz.ChildNodes[1], atributo);//--->TIPO.Rule
                                                            atributo = Recorrer(raiz.ChildNodes[2], atributo);//---->LI_ID.Rule


                                                        } break;

                                                } //  cierre switch


                                            }
                                            break;

                                        case "TIPO":{//--->TIPO + LI_ID + ToTerm("=") + EXPRESION 
                                             //   MessageBox.Show("3");
                                                atributo.simbolo = '~';
                                                atributo = Recorrer(raiz.ChildNodes[0], atributo);//--->TIPO.Rule
                                                atributo = Recorrer(raiz.ChildNodes[1], atributo);//---->LI_ID.Rule

                                            }
                                            break;

                                        case "OBJETO":{//--->OBJETO + LI_ID + ToTerm("=") + CONSTRUCTOR 
                                            //    MessageBox.Show("4");
                                                atributo.simbolo = '~';
                                                atributo = Recorrer(raiz.ChildNodes[0], atributo);//--->OBJETO.Rule
                                                atributo = Recorrer(raiz.ChildNodes[1], atributo);//---->LI_ID.Rule
                                            }
                                            break;

                                    }


                                }
                                break;

                            case 4:{// 4 hijos

                                    switch (raiz.ChildNodes[1].ToString()){

                                        case "TIPO":{//----> ACCESO + TIPO + LI_ID + ToTerm("=") + EXPRESION 
                                             //   MessageBox.Show("4 hijos,tipo");
                                                atributo = Recorrer(raiz.ChildNodes[0], atributo);//--->ACCESO.Rule
                                                atributo = Recorrer(raiz.ChildNodes[1], atributo);//--->TIPO.Rule
                                                atributo = Recorrer(raiz.ChildNodes[2], atributo);//---->LI_ID.Rule

                                            }
                                            break;

                                        case "OBJETO":{//---> ACCESO + OBJETO + LI_ID + ToTerm("=") + CONSTRUCTOR
                                             //   MessageBox.Show("4 hijos,objeto");
                                                atributo = Recorrer(raiz.ChildNodes[0], atributo);//--->ACCESO.Rule
                                                atributo = Recorrer(raiz.ChildNodes[1], atributo);//--->OBJETO.Rule
                                                atributo = Recorrer(raiz.ChildNodes[2], atributo);//---->LI_ID.Rule

                                            }
                                            break;

                                    }




                                }
                                break;



                        }



                    }
                    break; // cierre  de VARIABLES
                #endregion


                case "OBJETO": {
                        string[] valor = raiz.ChildNodes[0].ToString().Split(' ');
                        
                        atributo.tipo = valor[0];

                    } break;

                case "LI_ID": {
                   
                
                        foreach (var hijo in raiz.ChildNodes) {
                            string[] valor = hijo.ToString().Split(' ');
                        
                            atributo.nombreVariable.Add(valor[0]);                        
                                
                        }

                    } break;

                case "TIPO": {
                        string[] valor = raiz.ChildNodes[0].ToString().Split(' ');

                        atributo.tipo = valor[0];

                    } break;

                case "ACCESO": {
                        string[] val = raiz.ChildNodes[0].ToString().Split(' ');
                        switch (val[0]) {
                            case "public": { atributo.simbolo = '+'; }break;
                            case "private": { atributo.simbolo = '-'; } break;
                            case "protected": { atributo.simbolo = '#'; } break;
                        } 

                    } break;

            }// cierre switch
           return atributo;
        }

    }
}
