public class Lista {

public Nodo primero ;

public void AgregarNodo(String nombre,int valor){

   if(primero == null){
      Nodo aux = new Nodo("jorge",2);
       primero = aux;
       
  }else {
        Nodo aux = new Nodo("jorge",2);
       primero.siguiente = aux;
       primero = aux;
      tamano++;
  }
}

public void EliminarPorNombre(String nombre){

        Nodo nuevo = new Nodo();

        nuevo.setValor(valor);

        if (!esVacia()) {

            if (buscar(referencia)) {

                Nodo aux = inicio;

                while (aux.getValor() != referencia) {
                    aux = aux.getSiguiente();
                }

                Nodo siguiente = aux.getSiguiente();

                aux.setSiguiente(nuevo);

                nuevo.setSiguiente(siguiente);
                
                tamanio++;
            }
        }


}

public void EliminarPorPosicion(int posicion){

        if(posicion>=0 && posicion<tamanio){
      
            if(posicion == 0){
               
                inicio = inicio.getSiguiente();
            }
           
            else{
             
                Nodo aux = inicio;
                
                for (int i = 0; i < posicion-1; i++) {
                    aux = aux.getSiguiente();
                }
                
                Nodo siguiente = aux.getSiguiente();
          
                aux.setSiguiente(siguiente.getSiguiente());
            }
            // Disminuye el contador de tamaño de la lista.
            tamanio--;
        }
}


}