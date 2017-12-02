using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diagramacion_De_Clases_JAVA.Gramatica;
using Diagramacion_De_Clases_JAVA.Arbol;
using Diagramacion_De_Clases_JAVA.Arbol.Grafo;
using System.Collections;
using Irony.Parsing;
using System.IO;

namespace Diagramacion_De_Clases_JAVA
{
    public partial class Form1 : Form
    {
        private string Directorio="";// = @"C:\Users\carlo\OneDrive\Documentos\visual studio 2015\Projects\Diagramacion_De_Clases_JAVA\Diagramacion_De_Clases_JAVA\bin\Debug";
        private string DirectorioSecundario = "";
        private bool DirSecundarioActivo = false;
        public static ArrayList lista_Errores = new ArrayList();
        private ArrayList ClasesExistentes = new ArrayList();
        private Queue colaRaices;
        public Form1()
        {
            InitializeComponent();
        }

        #region METODOS Y FUNCIONES

        private void Crear_Pestaña(string nombre_clase,string ruta,string tex) { // Crea una nueva pestaña(CLASE.java) con el nombre que el usuario ingrese
           
                tabControl1.TabPages.Add(nombre_clase);// agregamos la pestaña visualmente
                
                Crear_Nuevo_RichTextBox(nombre_clase,ruta,tex);// se crea el nuevo richtextbox y se coloca la ruta a la pestaña, para saber a que archivo pertenece
      

        }

        private int Buscar_Pestaña(string Nombre_clase) { // metodo se debe cambiar por uno q busque el archivo en el directorio
            // en el cual se este trabajando en ese momeno
            int busqueda = -1;
            int conta = 0;
            foreach (TabPage pagina in tabControl1.TabPages){

                if (pagina.Text.Equals(Nombre_clase)){

                    busqueda = conta;
                    // MessageBox.Show("Ya existe una clase con ese nombre y es : "+busqueda);
                }
                conta++;

            }
            return busqueda;
        }

        private void Crear_Nuevo_RichTextBox(string nombreClase,string ruta,string tex) {
            int PestañaActual = tabControl1.TabCount-1; // Siempre nos dara el valor de la ultima pestaña creada.
            tabControl1.TabPages[PestañaActual].Name = ruta; // aca le colocamos la ruta al la pestaña....!! importantisimo!!

            RichTextBox area = new RichTextBox();
            area.Text = tex;
            area.Name = nombreClase;
            area.Height = 294;
            area.Width = 359;
            area.BackColor = Color.LightGray;
            tabControl1.TabPages[PestañaActual].Controls.Add(area);

        }

        public static DialogResult InputBox(string titulo, string EntradaTexto, ref string value)
        { //---------------->  Mensaje en pantalla para ingresar Datos
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = titulo;
            label.Text = EntradaTexto;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        public static DialogResult Entrada(string titulo, string textoAmostrar) {
            Form form = new Form();
            Label label = new Label();
            //TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

           form.Text = titulo;
            label.Text = textoAmostrar;
           // textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
           // textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
           // textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
          //  value = textBox.Text;
            return dialogResult;

        }

        private void Crear_Proyecto(string NombreDirectorio) {//----> Crea el proyecto en el "bin\NombreDirectorio" 

            string ruta = Application.StartupPath + @"\Proyectos\" + NombreDirectorio;
            //
          
           // MessageBox.Show("la ruta que se cargo fue   "+Directorio);
            try {

                if (Directory.Exists(ruta)){
                    MessageBox.Show("Ya existe un proyecto con este nombre ");

                } else {
                    Directorio = ruta;
                    Directory.CreateDirectory(ruta);// creamos el directorio en la ruta 
                    Crear_ArchivoJAVA(NombreDirectorio,ruta);// crea un archivo en la carpeta recien creada y una nueva pestaña

                    MessageBox.Show("Se ha creado un nuevo proyecto");
                }
            }
            catch (Exception e){

                MessageBox.Show("Error al crear directorio " + e.ToString());
            }




        }

        private void Crear_ArchivoJAVA(string NombreClase,string ruta) {//---->Crea un archivo.java en el directorio que se este trabajando

            string Rutaarchivo = ruta + "\\" + NombreClase + ".java";

            try {

                if (File.Exists(Rutaarchivo)){ // verificar si el archivo ya existe

                    MessageBox.Show("YA EXISTE UNA CLASE CON ESE NOMBRE");

                } else {

                   var creacion= File.Create(Rutaarchivo) ;
                    creacion.Close();

                    Crear_Pestaña(NombreClase+".java",Rutaarchivo,""); // crea una pestaña en el tab control de windos form1
                }
            }
            catch (Exception e){
                MessageBox.Show("ocurrio un error al crear la clase. " + e.ToString());
            }

        }

        private void Mostrar_Treeview(TreeView lista, string path) {
            lista.Nodes.Clear();
            DirectoryInfo RootPath = new DirectoryInfo(path);
            lista.Nodes.Add(Crear_Treeview(RootPath));

        }
        private TreeNode Crear_Treeview(DirectoryInfo directorio) {

            var DirectorioPadre = new TreeNode(directorio.Name);

            //MessageBox.Show("zayayay");
              foreach (var directory in directorio.GetDirectories()) { 
                      DirectorioPadre.Nodes.Add(Crear_Treeview(directory));
                     // MessageBox.Show(directory.ToString());
            }

            foreach (var archivo in directorio.GetFiles())
            {
                DirectorioPadre.Nodes.Add(new TreeNode(archivo.Name));
               // MessageBox.Show(archivo.Name.ToString());
            }
              return DirectorioPadre;
                   
        }

        private void Guardar_Archivo(string nombreClase, string texto,string RutaArchivo)
        {
            string[] cadenas = texto.Split('\n');
          //  string archivo = Directorio + "\\" + nombreClase + ".java";
            File.WriteAllLines(RutaArchivo, cadenas); // escribe todo el texto del richtextbox, en el archivo

        }// metodo para Almacenar texto

        private string Analizar_Codigo(string codigo) {/*verifica el analizador lexico y sintactico si el codigo esta escrito correctamente*/

            string etiqueta = "";
            bool respuesta = sintactico.analizar(codigo);

            if (respuesta == true){
                MessageBox.Show("la cadena es correcta");

                etiqueta= RecorrerArbol.Recorrer(sintactico.getRaiz(),"");
                colaRaices.Enqueue(sintactico.getRaiz());
            }
            else{
                MessageBox.Show("la cadena es incorrecta");
            }
            return etiqueta;
        }

        #endregion




        private void button1_Click(object sender, EventArgs e)
        {
             Analizar_Codigo(txtarea.Text);
            
            

        }

       
        

        private void txtarea_TextChanged(object sender, EventArgs e){

            listBox1.Items.Clear();
            for (int i = 0; i < txtarea.Lines.Length; i++){
                listBox1.Items.Add(i);
            }
            listBox1.SelectedItems.Add(txtarea.GetLineFromCharIndex(txtarea.SelectionStart));


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   MessageBox.Show("me muevo entre los tab del control "+tabControl1.SelectedIndex.ToString());
        }

        private void claseToolStripMenuItem_Click(object sender, EventArgs e){

            if (Directorio.Equals("")) {
                MessageBox.Show("NO SE HA CREADO PROYECTO");

            }else {
                string NombreClase = "";
                if (InputBox("Crear nuevo proyecto", "Nombre del proyecto", ref NombreClase) == DialogResult.OK)
                {
                    if (NombreClase.Equals("")){
                        MessageBox.Show("El nombre esta vacio");

                    }else {

                        if (DirSecundarioActivo ==true) {// si nos encontramos en un directorio que no es el principal

                            Crear_ArchivoJAVA(NombreClase, DirectorioSecundario);// crea una en la carpeta y una en el tabcontrol1
                            Mostrar_Treeview(treeView1, DirectorioSecundario);

                        }
                        else { //  si es ==false continuamos en el principal
                            Crear_ArchivoJAVA(NombreClase, Directorio);// crea una en la carpeta y una en el tabcontrol1
                            Mostrar_Treeview(treeView1, Directorio);
                        }

                      
                    }

                }
               
            }
          

        }

        private void proyectoToolStripMenuItem_Click(object sender, EventArgs e){//----------------------->Crear Nuevo proyecto
            DirSecundarioActivo = false;
            string value = ""; //---> aca se almacenara el nombre del proyecto, que ingrese el usuario
            if (InputBox("Crear nuevo proyecto", "Nombre del proyecto", ref value) == DialogResult.OK) {
                    if (value.Equals("")){

                    MessageBox.Show("Debe colocarle nombre al proyecto");
                } else {
                    
                    Crear_Proyecto(value); // crea una carpeta en la carpeta (bin)
                    Mostrar_Treeview(treeView1, Directorio);

                }
            }// cierre if input


        }
        private void Limpiar_Proyecto(){
            ClasesExistentes.Clear();// nueva lista 
            lista_Errores.Clear(); // nueva lista
            Gramatica.Gramatica.ErrorFatal = false;// la colocamos denuevo en false
            colaRaices = new Queue();// inicializamos la cola, pero se llena en ref linea::251

        }

        private void ejecutarToolStripMenuItem_Click(object sender, EventArgs e){

            Limpiar_Proyecto(); // Creamos todo nuevo para ejecutar un proyecto denuevo

            if (Directorio.Equals("")) {
                MessageBox.Show("DEBE SELECCIONAR UN PROYECTO ANTES DE EJECUTAR");

            }else {
                  if (DirSecundarioActivo==false) { // ---->El principal es el Directorio
                    MessageBox.Show("Proyecto principal ejecutandose");
                    var nuevoDir = new DirectoryInfo(Directorio);
                 
                    string etiquetasNodo = ""; // almacenara el string en forma de etiqueta que devuelva el analisis de la raiz
                    foreach (var dir in nuevoDir.GetFiles()) {
                        ClasesExistentes.Add(dir.ToString().Replace(".java","")); // almacenar cada clase, por si una clase extiende de otra verificar si existe....    
      
                        string codigo = File.ReadAllText(dir.FullName);// obtener el codigo en cada "(archivo).java"
                        etiquetasNodo += Analizar_Codigo(codigo)+"\n";// almacenara cada etiqueta de cada clase.java analizada
                      
                    }
                    if (Gramatica.Gramatica.ErrorFatal ==true) {// existen errores en algun archivo
                        MessageBox.Show("El proyeto No se puede ejecutar, ya que existen errores");

                    }else { // si no existen erroes lexicos o sintacticos deja seguir

                         while (colaRaices.Count!=0) {
                      
                        ParseTreeNode ext = (ParseTreeNode)colaRaices.Dequeue();

                        etiquetasNodo += verificadorControl.verificacion(ext, ClasesExistentes, "") + "\n";// verifica si se puede usar extends 

                    }
                    GrafoUml grafo = new GrafoUml();
                    grafo.GrafoUML_Dot(etiquetasNodo);//--> genera en graphviz el grafo
                    }
                   

                } else {//---> proyecto secundario
                    MessageBox.Show("seleccionando un proyecto diferente");
                    Limpiar_Proyecto();

                    var nuevoDir = new DirectoryInfo(DirectorioSecundario);
                    string etiquetasNodo = ""; // almacenara el string en forma de etiqueta que devuelva el analisis de la raiz

                    foreach (var dir in nuevoDir.GetFiles()) {
                        ClasesExistentes.Add(dir.ToString().Replace(".java","")); // almacenar cada clase, por si una clase extiende de otra verificar si existe....    
      
                        string codigo = File.ReadAllText(dir.FullName);// obtener el codigo en cada "(archivo).java"
                        etiquetasNodo += Analizar_Codigo(codigo)+"\n";// almacenara cada etiqueta de cada clase.java analizada
                      
                    }// cierre foreach

                    if (Gramatica.Gramatica.ErrorFatal ==true) {// existen errores en algun archivo
                        MessageBox.Show("El proyeto No se puede ejecutar, ya que existen errores");

                    }else { // si no existen erroes lexicos o sintacticos deja seguir

                         while (colaRaices.Count!=0) {
                      
                        ParseTreeNode ext = (ParseTreeNode)colaRaices.Dequeue();

                        etiquetasNodo += verificadorControl.verificacion(ext, ClasesExistentes, "") + "\n";// verifica si se puede usar extends 

                    }
                      GrafoUml grafo = new GrafoUml();
                      grafo.GrafoUML_Dot(etiquetasNodo);//--> genera en graphviz el grafo
                    }
                   

                }       
                  
          }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // Mostrar_Treeview(treeView1,Directorio);
            //treeView1.Nodes.Add("Persona");
         //   treeView1.Nodes[0].Nodes.Add("carro");
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void claseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int x = tabControl1.SelectedIndex; // # de pestaña 
            
            RichTextBox caja = (RichTextBox)tabControl1.TabPages[x].Controls[0]; // caja = texto escrito en la clase que estamos ejectando
            TabPage ClaseActual = tabControl1.TabPages[x];// obtener que pestaña se esta ejecutando.
                   string path = ClaseActual.Name;
            Guardar_Archivo(ClaseActual.Text, caja.Text,path);
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e){


            DirectoryInfo DirectorioActual = new DirectoryInfo(Directorio);
            string Seleccionado = treeView1.SelectedNode.FullPath;
         
            if (DirectorioActual.Name.Equals(Seleccionado)){//--->paso 1
                MessageBox.Show("si se ha seleccionado el directorio actual");
                if (DirectorioActual.GetFiles().Count()>0) {
           
                    if (Entrada("Proyecto principal", "Desea establecerlo como proyecto principal") == DialogResult.OK){
                     //   DirectorioSecundario = Directorio;

                    }
                }else {
                    MessageBox.Show("No se puede establecer como proyecto principal");
                }


            } else {
                //paso 2--->Si no es un directorio Padre, entonces puede ser un directorio hijo o un archivo.java

                //paso 2.1----> quitarle el primero del full path ya que este se repite, por eso el ciclo comienza en 1. omitiendo el 0
                string []nuevoDirectorio = treeView1.SelectedNode.FullPath.ToString().Split('\\');
                string reensamblar = "";
                for (int i = 1; i < nuevoDirectorio.Length; i++) {
                    reensamblar += "\\"+ nuevoDirectorio[i] ; 
                }
              

                //   MessageBox.Show(DirectorioActual+reensamblar);
                string aux = DirectorioActual + reensamblar;
                if (Directory.Exists(aux) == true){ // nos dirijimos a la carpeta que se quiere ejecutar

                   
                    if (Entrada("Proyecto principal", "Desea establecerlo como proyecto principal")==DialogResult.OK) {
                        DirectorioSecundario =aux;
                        DirSecundarioActivo = true;

                    }
                   

                } else{ // se da si se quiere abrir un archivo.java, y saber en donde se debe almacenar
                  
                    string Filetext = File.ReadAllText(aux); // codigo que existe adentro del archivo
                    int numpestaña = tabControl1.TabCount;   // pestaña en la que se colocara el archivo (tab)
                    string nombre = treeView1.SelectedNode.Text;          // nombre del archivo
                    string ruta = aux;                       // ruta donde se encuentra el archivo seleccionado
                    clasejava nueva = new clasejava(numpestaña,nombre,Filetext,ruta); // creamos el objeto de una clasejava.
                                                                                      //  ListaClasesAbiertas.Add(nueva); // al momento de darle en guadar, para conocer en donde se debe gudardar
                    MessageBox.Show("la ruta es "+ruta);
                   Crear_Pestaña(nombre,ruta,Filetext);
              
                    



                }

            }

        }

        private void proyectoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            if (folderBrowserDialog1.ShowDialog()==DialogResult.OK) {
                DirSecundarioActivo = false;
                Directorio = folderBrowserDialog1.SelectedPath;
                Mostrar_Treeview(treeView1, Directorio);
                // MessageBox.Show(folderBrowserDialog1.SelectedPath);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void erroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Genera un html con todos los erroes que se encontraron durante la ejecucion

            html.Generar_Html(Form1.lista_Errores);
        }
    }
}
