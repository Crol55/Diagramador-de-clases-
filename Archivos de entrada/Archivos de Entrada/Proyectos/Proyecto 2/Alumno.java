public class Alumno extends Estudiante{
	public int punteo;
	public Alumno siguiente;
	public Aplicacion aplicacion;
	public EnunciadoProyecto1 copiaEnunciado;

	public Alumno(String nombre, int edad, double estatura, char sexo2, int carnet, int creditos, String correo) {
		super(nombre, edad, estatura, sexo2, carnet, creditos, correo);
	}

}
