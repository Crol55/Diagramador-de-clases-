using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Interpreter;
using Irony.Parsing;
using System.Windows.Forms;

namespace Diagramacion_De_Clases_JAVA.Gramatica
{
    class Gramatica:Grammar {
        public static bool ErrorFatal = false;

        public Gramatica():base(caseSensitive:true) {

            #region Expresiones Regulares

            //caracteres
            // letras
            NumberLiteral numeros = new NumberLiteral("Num"); // num o decimales
          //  RegexBasedTerminal ID = new RegexBasedTerminal("ID", "[^\\s?[boolean]|\\s?00]+");
            IdentifierTerminal ID = new IdentifierTerminal("ID"); // identificadores
            StringLiteral STRING = new StringLiteral("STRING", "\"", StringOptions.IsTemplate);// cadenas
            CommentTerminal comentario = new CommentTerminal("comentario", "//", "\n", "\r\n");
            CommentTerminal bloque_comentario = new CommentTerminal("bloqueC", "/*", "*/");
            RegexBasedTerminal chars = new RegexBasedTerminal("chars", "['][^­­¿][']");// Chars='*'



            #endregion

            #region TERMINALES
            var clase = ToTerm("class");
            var publico = ToTerm("public");
            var privado = ToTerm("private");
            var protegido = ToTerm("protected");
            var extends = ToTerm("extends");
            var entero = ToTerm("int");
            var strng = ToTerm("String");
            var boolean = ToTerm("boolean");
            var doble = ToTerm("double");
            var character = ToTerm("char");
            var verdadero = ToTerm("true");
            var falso = ToTerm("false");
            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var por = ToTerm("*");
            var div = ToTerm("/");
            var elev = ToTerm("^");
            var retorno = ToTerm("return");
            var voidd = ToTerm("void");
            var overrid = ToTerm("@Override");
            var If = ToTerm("if");
            var Switch = ToTerm("switch");
            var While = ToTerm("while");
            var Do = ToTerm("do");
            var For = ToTerm("for");
            var Case = ToTerm("case");
            var Else = ToTerm("else");


            #endregion

            #region NO TERMINALES
            NonTerminal INICIO = new NonTerminal("INICIO");
            NonTerminal CUERPO= new NonTerminal("CUERPO");
            NonTerminal ACCESO = new NonTerminal("ACCESO");
            NonTerminal INSTRUCCIONES_CLASE = new NonTerminal("INSTRUCCIONES_CLASE");
            NonTerminal LI_INSTRUCCIONES_CLASE = new NonTerminal("LI_INSTRUCCIONES_CLASE");
            NonTerminal DECLARACION = new NonTerminal("DECLARACION");
            NonTerminal VARIABLES = new NonTerminal("VARIABLES");
            NonTerminal METODOS = new NonTerminal("METODOS");
            NonTerminal TIPO = new NonTerminal("TIPO");
            NonTerminal EXPRESION= new NonTerminal("EXPRESION");
            NonTerminal LI_ID = new NonTerminal("LI_ID");
            NonTerminal CONSTRUCTOR = new NonTerminal("CONSTRUCTOR");
            NonTerminal PARAMETRO = new NonTerminal("PARAMETRO");
            NonTerminal LI_PARAMETRO = new NonTerminal("LI_PARAMETRO");
            NonTerminal OBJETO = new NonTerminal("OBJETO");
            NonTerminal LOGICO = new NonTerminal("LOGICO");
            NonTerminal OP = new NonTerminal("OP");
            NonTerminal INVOCAR = new NonTerminal("INVOCAR");
            NonTerminal LI_PARAM = new NonTerminal("LI_PARAM");
            NonTerminal PARAM = new NonTerminal("PARAM");
            NonTerminal FUNCION = new NonTerminal("FUNCION");
            NonTerminal RETORNO = new NonTerminal("RETORNO");
            NonTerminal METODO = new NonTerminal("METODO");
            NonTerminal INSTRUCCIONES = new NonTerminal("INSTRUCCIONES");
            NonTerminal CONSTRUCTOR_PRINCIPAL = new NonTerminal("CONSTRUCTOR_PRINCIPAL");
            NonTerminal OVERRIDE = new NonTerminal("OVERRIDE");
            NonTerminal VISIBILIDAD = new NonTerminal("VISIBILIDAD");
            NonTerminal DEFINICION = new NonTerminal("DEFINICION");
            NonTerminal ATRIBUTOS = new NonTerminal("ATRIBUTOS");
            NonTerminal LI_INSTRUCCIONES = new NonTerminal("LI_INSTRUCCIONES");
            NonTerminal CICLOS= new NonTerminal("CICLOS");
            NonTerminal IF = new NonTerminal("IF");
            NonTerminal CONDICION = new NonTerminal("CONDICION");
            NonTerminal ELSEIF = new NonTerminal("ELSEIF");
            NonTerminal LISTA_ELSEIF = new NonTerminal("LISTA_ELSEIF");
            NonTerminal ELSE = new NonTerminal("ELSE");
            NonTerminal OR = new NonTerminal("OR");
            NonTerminal OL = new NonTerminal("OL");
            NonTerminal EXP_R = new NonTerminal("EXP_R");
            NonTerminal CONDICION2 = new NonTerminal("CONDICION2");
            NonTerminal ASOCIACION = new NonTerminal("ASOCIACION");
            NonTerminal SIMPLE = new NonTerminal("SIMPLE");
            NonTerminal SWITCH = new NonTerminal("SWITCH");
            NonTerminal CASES = new NonTerminal("CASES");
            NonTerminal CASO = new NonTerminal("CASO");
            NonTerminal WHILE = new NonTerminal("WHILE");
            NonTerminal DOWHILE= new NonTerminal("DOWHILE");
            NonTerminal FOR = new NonTerminal("FOR");
            NonTerminal DECOASIG = new NonTerminal("DECLOASIG");
            NonTerminal ASIGNACION = new NonTerminal("ASIGNACION");
            NonTerminal INICIALIZAR = new NonTerminal("INICIALIZAR");
            NonTerminal INCREMENTO = new NonTerminal("INCREMENTO");
            NonTerminal INSTRUCCIONES_CICLO = new NonTerminal("INSTRUCCIONES_CICLO");
            NonTerminal TI = new NonTerminal("TI");
            NonTerminal INSTRUCT = new NonTerminal("INSTRUCT");
            NonTerminal LOCALES = new NonTerminal("LOCALES");
            NonTerminal INSTRUCCIONES_FUNCION = new NonTerminal("INSTRUCCIONES_FUNCION");
            NonTerminal INST = new NonTerminal("INST");
            NonTerminal CICLOS_FUNCION = new NonTerminal("CICLOS_FUNCION");
            NonTerminal IF_FUNC= new NonTerminal("IF_FUNC");
            NonTerminal SWITCH_FUNC = new NonTerminal("SWITCH_FUNC");
            NonTerminal WHILE_FUNC = new NonTerminal("WHILE_FUNC");
            NonTerminal DOWHILE_FUNC = new NonTerminal("DOWHILE_FUNC");
            NonTerminal FOR_FUNC = new NonTerminal("FOR_FUNC");
            NonTerminal SCC = new NonTerminal("SCC");
            NonTerminal IF_CICLO = new NonTerminal("SCC");
            NonTerminal ELSEIF_CICLO = new NonTerminal("ELSEIF_CICLO");
            NonTerminal ELSE_CICLO = new NonTerminal("ELSE_CICLO");
            NonTerminal LISTA_ELSEIF_CICLO = new NonTerminal("LISTA_ELSEIF_CICLO");
            NonTerminal SENTENCIA_CONTROL = new NonTerminal("SENTENCIA_CONTROL");
            NonTerminal SCF = new NonTerminal("SCF");
            NonTerminal LISTA_ELSEIF_FUNC = new NonTerminal("LISTA_ELSEIF_FUNC");
            NonTerminal ELSEIF_FUNC = new NonTerminal("ELSEIF_FUNC");
            NonTerminal ELSE_FUNC = new NonTerminal("ELSE_FUNC");
            NonTerminal INST_FUNCION_CICLO = new NonTerminal("INST_FUNCION_CICLO");
            NonTerminal ACCESO_AMF = new NonTerminal("ACCESO_AMF");
            NonTerminal EXPRESION_RETORNO = new NonTerminal("EXPRESION_RETORNO");
            NonTerminal L_INST_FUNCION_CICLO = new NonTerminal("L_INST_FUNCION_CICLO");
            NonTerminal SCFC = new NonTerminal("SCFC");
             NonTerminal IF_FUNC_CICLO = new NonTerminal("IF_FUNC_CICLO");
            NonTerminal ELSE_FUNC_CICLO= new NonTerminal("ELSE_FUNC_CICLO");
            NonTerminal LISTA_ELSEIF_FUNC_CICLO = new NonTerminal("IF_FUNC_CICLO");
            NonTerminal ELSEIF_FUNC_CICLO = new NonTerminal(" ELSEIF_FUNC_CICLO");
            NonTerminal LOGICO_ESPECIAL = new NonTerminal(" L_ESP");


            #endregion

            #region GRAMATICA

            INICIO.Rule =CUERPO;

            CUERPO.Rule =ACCESO + clase + ID+ extends + LI_ID + ToTerm("{")+ INSTRUCCIONES_CLASE + ToTerm("}") 
                        | clase + ID + extends + LI_ID + ToTerm("{") + INSTRUCCIONES_CLASE + ToTerm("}")
                        | ACCESO + clase + ID + ToTerm("{") + INSTRUCCIONES_CLASE + ToTerm("}")
                        | clase + ID+ ToTerm("{") + INSTRUCCIONES_CLASE + ToTerm("}")
                ;

            ACCESO.Rule =  publico | privado | protegido ;
         //   ACCESO.ErrorRule =SyntaxError+ ACCESO;

            TIPO.Rule = entero | strng | boolean | character | doble;//(variables de tipo objeto)

            LI_ID.Rule = MakePlusRule(LI_ID, ToTerm(","), ID);
          //  LI_ID.ErrorRule =SyntaxError + ID;

            INSTRUCCIONES_CLASE.Rule = MakeStarRule(INSTRUCCIONES_CLASE,LI_INSTRUCCIONES_CLASE);

            LI_INSTRUCCIONES_CLASE.Rule = DECLARACION // DECLARACION DE VARIABLES Globales 
                                | CONSTRUCTOR_PRINCIPAL
                                | METODOS
                                | OVERRIDE
                                  ;

            #region CONSTRUCTOR_PRINCIPAL

            CONSTRUCTOR_PRINCIPAL.Rule = ACCESO + ID + ToTerm("(") + LI_PARAM + ToTerm(")") + ToTerm("{") + INSTRUCCIONES + ToTerm("}")
                                     | ID + ToTerm("(") + LI_PARAM + ToTerm(")") + ToTerm("{") + INSTRUCCIONES + ToTerm("}")
             ;





            #endregion

            LI_PARAM.Rule = MakeStarRule(LI_PARAM, ToTerm(","), PARAM);

            PARAM.Rule = TIPO + ID
                        | OBJETO + ID;

         
            METODOS.Rule = METODO | FUNCION ;
            METODOS.ErrorRule = SyntaxError + "}";



            #region FUNCIONES

            FUNCION.Rule = ACCESO + TIPO + ID + ToTerm("(") + LI_PARAM + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_FUNCION + ToTerm("}")
                  | TIPO + ID + ToTerm("(") + LI_PARAM + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_FUNCION + ToTerm("}")
                  | ACCESO + OBJETO + ID + ToTerm("(") + LI_PARAM + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_FUNCION + ToTerm("}")
                  | OBJETO + ID + ToTerm("(") + LI_PARAM + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_FUNCION + ToTerm("}")

          ;
            INSTRUCCIONES_FUNCION.Rule = MakeStarRule(INSTRUCCIONES_FUNCION, INST)
                ;

            INST.Rule = CICLOS_FUNCION
                      | SCF//-----> SENTENCIAS DE CONTROL DE UNA FUNCION
                      | LOCALES // CREAR nuevas variables
                      | INICIALIZAR + ToTerm(";")
                      | INCREMENTO + ToTerm(";")
                      | INVOCAR + ToTerm(";")
                      | RETORNO ;

        
            SCF.Rule =IF_FUNC
                      |Switch 
                ;

            CICLOS_FUNCION.Rule = WHILE_FUNC
                                | DOWHILE_FUNC
                                | FOR_FUNC
               ;


            IF_FUNC.Rule = If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_FUNCION+ ToTerm("}")
                  | If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_FUNCION + ToTerm("}") + ELSE_FUNC
                  | If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_FUNCION + ToTerm("}") + LISTA_ELSEIF_FUNC
                  | If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_FUNCION + ToTerm("}") + LISTA_ELSEIF_FUNC + ELSE_FUNC

                ;
            LISTA_ELSEIF_FUNC.Rule = MakePlusRule(LISTA_ELSEIF_FUNC, ELSEIF_FUNC)
          ;

            ELSEIF_FUNC.Rule = Else + If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_FUNCION + ToTerm("}")
                ;
            ELSE_FUNC.Rule = Else + ToTerm("{") + INSTRUCCIONES_FUNCION + ToTerm("}")
                ;


            WHILE_FUNC.Rule = While + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + L_INST_FUNCION_CICLO + ToTerm("}")
                ;

            DOWHILE_FUNC.Rule = Do + ToTerm("{") + L_INST_FUNCION_CICLO + ToTerm("}") + While + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm(";")
                ;

            FOR_FUNC.Rule = For + ToTerm("(") + DECOASIG + CONDICION + ToTerm(";") + ASIGNACION + ToTerm(")") + ToTerm("{") + L_INST_FUNCION_CICLO + ToTerm("}")
                ;

            L_INST_FUNCION_CICLO.Rule = MakeStarRule(L_INST_FUNCION_CICLO, INST_FUNCION_CICLO)
                
                ;
            INST_FUNCION_CICLO.Rule = CICLOS_FUNCION
                                    | SCFC //---> SENTENCIAS DE CONTROL DE FUNCION DE CICLOS
                                    | LOCALES
                                    | INICIALIZAR + ToTerm(";")
                                    | INCREMENTO + ToTerm(";")
                                    | INVOCAR + ToTerm(";")
                                    | ToTerm("continue") + ToTerm(";")
                                    | ToTerm("break") + ToTerm(";")
                                    | RETORNO;
                                       ;

            SCFC.Rule = IF_FUNC_CICLO
                      | Switch       ;

            IF_FUNC_CICLO.Rule = If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + L_INST_FUNCION_CICLO + ToTerm("}")
                  | If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + L_INST_FUNCION_CICLO + ToTerm("}") + ELSE_FUNC_CICLO
                  | If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + L_INST_FUNCION_CICLO + ToTerm("}") + LISTA_ELSEIF_FUNC_CICLO
                  | If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + L_INST_FUNCION_CICLO + ToTerm("}") + LISTA_ELSEIF_FUNC_CICLO + ELSE_FUNC_CICLO
              ;

            LISTA_ELSEIF_FUNC_CICLO.Rule = MakePlusRule(LISTA_ELSEIF_FUNC_CICLO, ELSEIF_FUNC_CICLO)
              ;

            ELSEIF_FUNC_CICLO.Rule = Else + If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + L_INST_FUNCION_CICLO + ToTerm("}")
                ;
            ELSE_FUNC_CICLO.Rule = Else + ToTerm("{") + L_INST_FUNCION_CICLO + ToTerm("}")
                ;
            #endregion



            #region METODOS

            METODO.Rule = ACCESO + voidd + ID + ToTerm("(") + LI_PARAM + ToTerm(")") + ToTerm("{") + INSTRUCCIONES + ToTerm("}")
                      | voidd + ID + ToTerm("(") + LI_PARAM + ToTerm(")") + ToTerm("{") + INSTRUCCIONES + ToTerm("}")

              ;


            #endregion



            RETORNO.Rule = retorno + EXPRESION_RETORNO + ToTerm(";")
                         |  retorno + CONDICION +ToTerm(";")
                         ;

            EXPRESION_RETORNO.Rule = chars | OP;


            #region INSTRUCCIONES

            INSTRUCCIONES.Rule = MakeStarRule(INSTRUCCIONES, LI_INSTRUCCIONES);

           



            LI_INSTRUCCIONES.Rule = CICLOS
                                    |SENTENCIA_CONTROL
                                    | LOCALES // CREAR nuevas variables
                                    | INICIALIZAR + ToTerm(";")
                                    | INCREMENTO + ToTerm(";")
                                    | INVOCAR + ToTerm(";")
                                    |retorno + ToTerm(";") 
                                  ;

            LI_INSTRUCCIONES.ErrorRule = SyntaxError + ";";

            #endregion



            #region SENTENCIAS DE CONTROL

            SENTENCIA_CONTROL.Rule = IF
                                   | SWITCH
               ;

            IF.Rule = If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + INSTRUCCIONES + ToTerm("}")
                  | If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + INSTRUCCIONES + ToTerm("}") + ELSE
                  | If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + INSTRUCCIONES + ToTerm("}") + LISTA_ELSEIF
                  | If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + INSTRUCCIONES + ToTerm("}") + LISTA_ELSEIF + ELSE
               ;

            LISTA_ELSEIF.Rule = MakePlusRule(LISTA_ELSEIF, ELSEIF)
            ;

            ELSEIF.Rule = Else + If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + INSTRUCCIONES + ToTerm("}")
                ;
            ELSE.Rule = Else + ToTerm("{") + INSTRUCCIONES + ToTerm("}")
                ;

            SWITCH.Rule = Switch + ToTerm("(") + EXPRESION + ToTerm(")") + ToTerm("{") + Case + EXPRESION + ToTerm(":") + INSTRUCCIONES + ToTerm("break") + ToTerm(";") + CASES + ToTerm("default") + ToTerm(":") + INSTRUCCIONES + ToTerm("break") + ToTerm(";") + ToTerm("}")
                        ;

            CASES.Rule = MakeStarRule(CASES, CASO);

            CASO.Rule = Case + EXPRESION + ToTerm(":") + INSTRUCCIONES + ToTerm("break") + ToTerm(";");


            #endregion




            #region CICLOS


            CICLOS.Rule = WHILE
                         |DOWHILE
                         |FOR
                ;

            WHILE.Rule =While + ToTerm("(") + CONDICION + ToTerm(")")+ ToTerm("{") + INSTRUCCIONES_CICLO + ToTerm("}")
                ;

            DOWHILE.Rule =Do + ToTerm("{") + INSTRUCCIONES_CICLO + ToTerm("}") + While + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm(";")
                ;

            FOR.Rule = For + ToTerm("(") + DECOASIG + CONDICION + ToTerm(";") + ASIGNACION  + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_CICLO + ToTerm("}")
                ;

            DECOASIG.Rule =DECLARACION
                         | ASIGNACION + ToTerm (";")            
                ;

            INSTRUCCIONES_CICLO.Rule = MakeStarRule(INSTRUCCIONES_CICLO, INSTRUCT);

            INSTRUCT.Rule =CICLOS 
                           |SCC //---> SENTENCIAS DE CONTROL DE CICLOS
                           |LOCALES  
                           | INICIALIZAR + ToTerm(";")
                           | INCREMENTO + ToTerm(";")
                           | INVOCAR + ToTerm(";")
                           | ToTerm("continue") + ToTerm(";")
                           | ToTerm("break") + ToTerm(";")
                           | retorno + ToTerm(";")
                           ;
            INSTRUCT.ErrorRule = SyntaxError + ";";// para continue,break,retorno


            SCC.Rule =IF_CICLO
                     |SWITCH 
                     ;

            IF_CICLO.Rule = If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_CICLO + ToTerm("}")
                  | If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_CICLO + ToTerm("}") + ELSE_CICLO
                  | If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_CICLO + ToTerm("}") + LISTA_ELSEIF_CICLO
                  | If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_CICLO + ToTerm("}") + LISTA_ELSEIF_CICLO + ELSE_CICLO
                ;

            ELSE_CICLO.Rule = Else + ToTerm("{") + INSTRUCCIONES_CICLO + ToTerm("}")
                ;

            LISTA_ELSEIF_CICLO.Rule = MakePlusRule(LISTA_ELSEIF_CICLO, ELSEIF_CICLO)
                ;
            ELSEIF_CICLO.Rule = Else + If + ToTerm("(") + CONDICION + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_CICLO + ToTerm("}")
                ;

            #endregion







            #region CONDICION

            CONDICION.Rule = EXP_R + CONDICION2
                             | ASOCIACION   ;

            CONDICION2.Rule = MakeStarRule(CONDICION2, SIMPLE)
                            ;

            SIMPLE.Rule = OL + EXP_R
                      | OL + ASOCIACION;

            ASOCIACION.Rule =                ToTerm("(") + CONDICION + ToTerm(")")
                             | ToTerm("!") + ToTerm("(") + CONDICION + ToTerm(")")
                             |               ToTerm("(") + CONDICION + ToTerm(")") + OL + CONDICION
                             | ToTerm("!") + ToTerm("(") + CONDICION + ToTerm(")") + OL + CONDICION;

            EXP_R.Rule = EXPRESION + OR + EXPRESION
                       |EXPRESION 
                       | ToTerm("!") + EXPRESION
                       | LOGICO_ESPECIAL
                       | ToTerm("!") + EXPRESION + OR + EXPRESION
                       | ToTerm("!") + LOGICO_ESPECIAL
                       ;

            OR.Rule = ToTerm("==")
                  | ToTerm("!=")
                  | ToTerm("<=")
                  | ToTerm(">")
                  | ToTerm(">=")
                  | ToTerm("<");

            OL.Rule = ToTerm("&&")
                    | ToTerm("||");

            LOGICO_ESPECIAL.Rule = verdadero | falso | ID ;

            #endregion
           





            EXPRESION.Rule = chars | LOGICO | OP    ; //  se cambio LOGICO por CONDICION
          




            #region OVERRIDE

            OVERRIDE.Rule = overrid + VISIBILIDAD + DEFINICION + ID + ToTerm("(") + LI_PARAM + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_FUNCION + ToTerm("}")//5
                       |    overrid + VISIBILIDAD + voidd  + ID + ToTerm("(") + LI_PARAM + ToTerm(")") + ToTerm("{") + INSTRUCCIONES + ToTerm("}") //5
                       |    overrid + VISIBILIDAD + ID + ToTerm("(") + LI_PARAM + ToTerm(")") + ToTerm("{") + INSTRUCCIONES + ToTerm("}")//4
                       |    overrid + DEFINICION + ID + ToTerm("(") + LI_PARAM + ToTerm(")") + ToTerm("{") + INSTRUCCIONES_FUNCION  + ToTerm("}")//4
                       |    overrid + voidd + ID + ToTerm("(") + LI_PARAM + ToTerm(")") + ToTerm("{") + INSTRUCCIONES + ToTerm("}")//4
                       |    overrid + ID + ToTerm("(") + LI_PARAM + ToTerm(")") + ToTerm("{") + INSTRUCCIONES + ToTerm("}")//3

                ;
            OVERRIDE.ErrorRule =SyntaxError + "}"; // si se recupera
            VISIBILIDAD.Rule =publico | protegido;
            DEFINICION.Rule = TIPO | OBJETO  ;

            #endregion





            ASIGNACION.Rule = INICIALIZAR
                            | INCREMENTO
                            
                            ;

            INICIALIZAR.Rule = TI + ToTerm("=") + EXPRESION 
                              | TI + ToTerm("=") + CONSTRUCTOR;
            INICIALIZAR.ErrorRule= SyntaxError +"=";

            INCREMENTO.Rule = TI + ToTerm("++")
                             | TI + ToTerm("--")  ;

            INCREMENTO.ErrorRule =SyntaxError + "++";
            INCREMENTO.ErrorRule = SyntaxError +"--";

            TI.Rule =ACCESO_AMF | ID ;
            
            #region DECLARACION

            DECLARACION.Rule = VARIABLES;
            DECLARACION.ErrorRule = SyntaxError +";";


            VARIABLES.Rule = ACCESO + TIPO + LI_ID + ToTerm(";")//3
                             | TIPO + LI_ID + ToTerm(";")//2
                             | TIPO + LI_ID + ToTerm("=") + EXPRESION + ToTerm(";")//3
                             | ACCESO + TIPO + LI_ID + ToTerm("=") + EXPRESION + ToTerm(";")//4
                             | ACCESO + OBJETO + LI_ID + ToTerm("=") + CONSTRUCTOR + ToTerm(";") // 4- tipo objeto
                             |          OBJETO + LI_ID + ToTerm(";") //2-  tipo objeto
                             | ACCESO + OBJETO + LI_ID + ToTerm(";") //3-  tipo objeto
                             |          OBJETO + LI_ID + ToTerm("=") + CONSTRUCTOR + ToTerm(";")// 3- tipo objeto
                            // |ToTerm("var")+ LI_ID  +ToTerm("(") + ToTerm(")") + ToTerm("{") + ToTerm("}")

                          ;
            VARIABLES.ErrorRule =SyntaxError + "}";

            LOCALES.Rule = TIPO + LI_ID + ToTerm(";")
                          | TIPO + LI_ID + ToTerm("=") + EXPRESION + ToTerm(";")
                          | OBJETO + LI_ID + ToTerm(";")
                          | OBJETO + LI_ID + ToTerm("=") + CONSTRUCTOR + ToTerm(";")//  tipo objeto
                ;
            LOCALES.ErrorRule =SyntaxError +";";
   


            CONSTRUCTOR.Rule = ToTerm("null")
                              | ToTerm("new") + OBJETO + ToTerm("(") + LI_PARAMETRO + ToTerm(")")
                              | ToTerm("new") + OBJETO + ToTerm("(") + ToTerm(")")
                              |EXPRESION 
                              ;

            OBJETO.Rule = ID;

            #endregion


          

            LI_PARAMETRO.Rule = MakePlusRule(LI_PARAMETRO,ToTerm(","),PARAMETRO) ;

            PARAMETRO.Rule = LOGICO | chars | OP;

          


            LOGICO.Rule = verdadero | falso ; // true o false

            #region LLAMADA O INVOCAR 


            INVOCAR.Rule = ID + ToTerm("(") + LI_PARAMETRO + ToTerm(")")
                 | ID + ToTerm("(") + ToTerm(")")
                 | OBJETO + ToTerm(".") + ATRIBUTOS + ToTerm("(") + ToTerm(")")  //Objeto.x.a.b.val()
                 | OBJETO + ToTerm(".") + ATRIBUTOS + ToTerm("(") + LI_PARAMETRO + ToTerm(")") //Objeto.x.a.b.val(x,y)
                 | ToTerm("this") + ToTerm(".") + ATRIBUTOS + ToTerm("(") + LI_PARAMETRO + ToTerm(")")
                 | ToTerm("this") + ToTerm(".") +ATRIBUTOS + ToTerm("(") + ToTerm(")")
                 | ToTerm("this") + ToTerm(".") + OBJETO + ToTerm(".") + ATRIBUTOS + ToTerm("(") + ToTerm(")")  //this.Objeto.x.a.b.val()
                 | ToTerm("this") + ToTerm(".") + OBJETO + ToTerm(".") + ATRIBUTOS + ToTerm("(") + LI_PARAMETRO + ToTerm(")") //this.Objeto.x.a.b.val(x,y)
                ;
            INVOCAR.ErrorRule = SyntaxError + ")";
            #endregion 


            OP.Rule = OP + mas + OP
                     | OP + menos + OP
                     | OP + por + OP
                     | OP + div + OP
                     | OP + elev + OP
                     | ToTerm("(") + OP + ToTerm(")")
                     | numeros // numeros y decimales
                     | ACCESO_AMF     // acceso a atributos, metodos y funciones
                     | ID      // lo q sea
                     |STRING //"strings"
                     |INCREMENTO
                    

                  ;


            #region ACCESO_AMF

            ACCESO_AMF.Rule = OBJETO + ToTerm(".") + ATRIBUTOS
                            | INVOCAR
                            |  ToTerm("this") + ToTerm(".") + ATRIBUTOS // this.x.a.b.val
                            | ToTerm("this") + ToTerm(".") + OBJETO + ToTerm(".") + ATRIBUTOS //this.Objeto.x.a.b.val
               ;

            ATRIBUTOS.Rule = MakePlusRule(ATRIBUTOS, ToTerm("."), ID);


            #endregion



            //  VARIADO.Rule = ID ; 

         //   FUNCYMET.Rule = MakePlusRule(FUNCYMET, ToTerm("."), INVOCAR) ;
            

            #endregion


            #region comentarios
            NonGrammarTerminals.Add(comentario);
            NonGrammarTerminals.Add(bloque_comentario);
            #endregion



            this.Root = INICIO;
            this.RegisterOperators(1, Associativity.Left, mas, menos);
            this.RegisterOperators(2, Associativity.Left, por, div);
            this.RegisterOperators(2, Associativity.Left, elev);
            MarkReservedWords("true","false","int","double","char","String","boolean","public","protected","private","class","extends","return","void","@Override","if","switch","while","do","for","case","else","this","break","continue");
            this.MarkPunctuation("(",")",";","class","{","}","@Override","=");


        }

        public override void ReportParseError(ParsingContext context){
            base.ReportParseError(context);
            String error = context.CurrentToken.ValueString;
            // context.CurrentParserState()
            //   MessageBox.Show("" + context.);
            // MessageBox.Show("input "+context.CurrentParserInput);
            string tipo;
            int fila;
            int columna;
            string descripcion = "";

            if (error.Contains("Invalid character")) {
                tipo = "Error Lexico";
                fila = context.Source.Location.Line;
                columna = context.Source.Location.Column;

                string delimStr = ":";
                char[] delim = delimStr.ToCharArray();
                string[] division = error.Split(delim, 2);
                division = division[1].Split('.');
                descripcion = "Caracter Invalido " + division[0];
                 MessageBox.Show("lexico : fila "+fila+" col "+columna+"   "+division[0]);
                ErrorFatal = true;
                Form1.lista_Errores.Add(new Error(descripcion,"Error Lexico",fila.ToString(),columna.ToString()));
            }
            else {
                tipo = "Error Sintactico";
                fila = context.Source.Location.Line;
                columna = context.Source.Location.Column;
                descripcion = "Se esperaba: " + context.GetExpectedTermSet().ToString();
                ErrorFatal = true;
                MessageBox.Show("sintactico\n :fila :  " + fila+"\n Token Erroneo:  " + context.CurrentToken + "\n col :" + columna+ "\n "+descripcion);
                Form1.lista_Errores.Add(new Error(descripcion, "Error Sintactico", fila.ToString(), columna.ToString()));
            }






        }

    }
}
