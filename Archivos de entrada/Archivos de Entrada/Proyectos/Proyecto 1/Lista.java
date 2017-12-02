
public class Lista {
	public Nodo segundo;
	
	public void AgregarNodo(String nombre, int valor){
		if(primero==null){
				primero = new Nodo(nombre, valor);
		}else{
			Nodo aux = primero;
			while(aux.siguiente!=null){
				aux = aux.siguiente;
			}
			aux.siguiente = new Nodo(nombre, valor); 
		}
	}
	
	public void EliminarPorNombre(String nombre){
		Nodo actual = primero;
		Nodo anterior = null;
		while(actual!=null){
			if(actual.nombre.equals(nombre)){
				if(anterior==null){
					primero = primero.siguiente;
					actual = primero;
				}else{
					anterior.siguiente = actual.siguiente;
					actual = actual.siguiente;
				}
			}else{
				anterior = actual;
				actual = actual.siguiente;
			}
		}
	}
	
	public void EliminarPorPosicion(int posicion){
		Nodo actual = primero;
		Nodo anterior = null;
		
		int contador = 1;
		while(actual!=null){
			if(posicion==contador){
				if(anterior==null){
					primero = primero.siguiente;
				}else{
					anterior.siguiente = actual.siguiente;
				}
				break;
			}else{
				anterior = actual;
				actual = actual.siguiente;
				contador++;
			}
		}
	}

}

