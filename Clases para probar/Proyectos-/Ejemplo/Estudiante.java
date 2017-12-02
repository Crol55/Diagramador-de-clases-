
public class Estudiante extends Persona{
	int carnet;
	public int creditos;
	public String correo;

	public Estudiante(String nombre, int edad, double estatura, char sexo2, int carnet, int creditos, String correo) {
		super(nombre, edad, estatura, sexo2);
		this.carnet = carnet;
		this.creditos = creditos;
		this.correo = correo;
	//Alumno x;
	}
	
	@Override
	public boolean CalcularMayor(int edad){
		return edad >= 18;
	}
}
