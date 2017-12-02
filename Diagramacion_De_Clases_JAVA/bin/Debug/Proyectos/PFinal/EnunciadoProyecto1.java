
public class EnunciadoProyecto1{
	public String texto;
	public int punteo;
	protected Fecha fechaEntrega = null;
	
	EnunciadoProyecto1(String texto, int punteo, Fecha fechaEntrega){
		this.texto = texto;
		this.punteo = punteo;
		this.fechaEntrega = fechaEntrega;
	}
}
