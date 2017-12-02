
public class Auxiliar extends Estudiante{
	public char seccion;
	public int cantidadAlumnos;
	public Alumno primerAlumno;
	private EnunciadoProyecto1 enundiado;

	public Auxiliar(String nombre, int edad, double estatura, char sexo2, int carnet, int creditos, String correo) {
		super(nombre, edad, estatura, sexo2, carnet, creditos, correo);
	}

	public void Calificar(){
		Alumno actual = primerAlumno;
		for(int i=1; i<=this.cantidadAlumnos; i++){
			if(actual.aplicacion.terminado == "Si"){
				actual.punteo = 100;
			}else{
				actual.punteo = 0;
			}
			actual = actual.siguiente;
		}
	}

}
