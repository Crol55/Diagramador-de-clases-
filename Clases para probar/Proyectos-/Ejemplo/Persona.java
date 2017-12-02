
public class Persona {
	String nombre = ""+"";
	public int edad = 0*0;
	public double estatura = 0.0+0.0;
	protected char sexo = ' ';
	private boolean mayorEdad;
	
	public Persona(String nombre, int edad, double estatura, char sexo2){
		this.nombre = nombre;
		this.edad = edad;
		this.estatura = estatura;
		sexo = sexo2;
		mayorEdad = CalcularMayor(this.edad);
	}

	public boolean CalcularMayor(int edad){
		if(edad >= 18){
			return true;
		}else{
			return false;
		}
	}

	public boolean getMayorEdad(){
		return mayorEdad;	
	}


}


	
