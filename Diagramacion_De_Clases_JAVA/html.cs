using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Diagramacion_De_Clases_JAVA
{
    class html{

        public static void Generar_Html (ArrayList Lista_Errores){

            string tabla = "";


            int año = DateTime.Now.Year;
            int mes = DateTime.Now.Month;
            int dia = DateTime.Now.Day;
            int hora = DateTime.Now.Hour;
            int minuto = DateTime.Now.Minute;
            int segundo = DateTime.Now.Second;


            tabla += "<html>\n\t<head>\n\t\t<title>Tabla de Errores</title>" + "<meta charset=" + "\"" + "utf-8" + "\"" + ">"
                        + "\n\t\t<link rel=" + "\"" + "stylesheet" + "\"" + "type=" + "\"" + "text/css" + "\"" + " href=" + "\"" + "Estilo.css"
                        + "\"" + ">\n\t</head>\n\t<body>"
                        + "\n\t\t<div style=" + "\"" + "text-align:left;" + "\"" + ">"
                        + "\n\t\t\t<h1>TABLA DE ERRORES</h1>"
                        + "\n\t\t\t<h2>Dia de ejecución:" + dia + " de " + obtenerMes(mes) + " de " + año + "</h2>"
                        + "\n\t\t\t<h2>Hora de ejecución:" + hora + ":" + minuto + ":" + segundo + "</h2>"
                        + "\n\t\t\t<table style=\"margin: margin: 5 auto;\" border=\"2\">\n";
            tabla += "\t\t\t\t<TR>\n\t\t\t\t\t<TH>Linea</TH> <TH>Columna</TH> <TH>Tipo de Error</TH> <TH>Descripcion</TH>\n\t\t\t\t</TR>";
            Error aux;
            for (int i = 0; i < Lista_Errores.Count; i++){
                aux = (Error)Lista_Errores[i];

                tabla += "\n\t\t\t\t<TR>";
                tabla += "\n\t\t\t\t\t<TD>" + aux.fila+"</TD>" + "<TD>" + aux.columna + "</TD>" + "<TD>" + aux.tipo + "</TD>" + "<TD>" + aux.Descripcion + "</TD>";
                tabla += "\n\t\t\t\t</TR>";

            }
           
            tabla += "\n\t\t\t</table>\n\t\t</div>\n\t</body>\n</html>";


            System.IO.StreamWriter w = new System.IO.StreamWriter("TablaErrores.html");
            w.WriteLine(tabla);
            w.Close();

        }
  
       public static string obtenerMes(int valor) {
            string MES = "";
            switch (valor)
            {

                case 1: { MES = "Enero"; } break;
                case 2: { MES = "Febrero"; } break;
                case 3: { MES = "Marzo"; } break;
                case 4: { MES = "Abril"; } break;
                case 5: { MES = "Mayo"; } break;
                case 6: { MES = "Junio"; } break;
                case 7: { MES = "Julio"; } break;
                case 8: { MES = "Agosto"; } break;
                case 9: { MES = "Septiembre"; } break;
                case 10: { MES = "Octubre"; } break;
                case 11: { MES = "Noviembre"; } break;
                case 12: { MES = "Diciembre"; } break;

            }

            return MES;
        }
    }
}
