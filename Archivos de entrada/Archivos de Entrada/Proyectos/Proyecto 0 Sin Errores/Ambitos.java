
public class Ambitos extends Sintaxis{
	
	
	// **************************************** Sobrescritura de metodos o funciones de la clase padre **************************************************
	@Override
	public int funcion_8(int atributo1, String atributo2, boolean atributo3, double atributo4, char atributo5, Sintaxis atributo6 ){
		return (1);
	}
	
	@Override
	public void metodo_8(int atributo1, String atributo2, boolean atributo3, double atributo4, char atributo5, Sintaxis atributo6 ){
		return;
	}
	
	
	/*************************************************** Variables locales Ambitos anidados **************************************************/
	
	public int FUNCION(){
		int variable1 = 1;
		String variable2 = "Hola Mundo "+"en Compi 1";
		boolean variable3 = (true || false);
		double variable4 = (1+2+3+4*5*(6/7))/(80*90);
		char variable5 = '%';
		Sintaxis variable6 = new Sintaxis();

		// ***************************************************************************************** IF
		if ( variable6.atributo6.atributo6.atributo6.atributo3){
			variable1 = 10;
		}

		if ( variable6.atributo2 == "S"){
			variable6.atributo2 = "xD";
		} else if ( variable6.atributo2 == "E"){
			variable6.atributo2 = "xD";
		} else if ( variable6.atributo2 == "T"){
			variable6.atributo2 = "xD";
		}

		if ( variable6.atributo2 == "S"){
			variable6.atributo2 = "xD";
		} else if ( variable6.atributo2 == "E"){
			variable6.atributo2 = "xD";
		} else if ( variable6.atributo2 == "T"){
			variable6.atributo2 = "xD";
		} else {
			variable6.atributo2 = "xD";
		}

		// ***************************************************************************************** SWITCH

		switch ( variable6.atributo2 ){
			case "Hola mundo":
				variable6.atributo2 = "xD";
				break;
			default:
				variable6.atributo2 = "xD";
				break;
		}

		switch ( this.atributo6.atributo2 ) {
			case "S":
				variable6.atributo2 = "xD";
				break;
			case "E":
				variable6.atributo2 = "xD";
				break; 
			case "T":
				variable6.atributo2 = "xD";
				break; 
			default:
				variable6.atributo2 = "xD";
				break;
		}






		if(variable1==1-2 &&  variable2=="Hola Mundo en Compi 1" && variable3==(false||true)){
			
			// ************************************************************************************* WHILE
			while(true){
				// ************************************************************************************* DO WHILE
				do{
					while(true){
						if(true){
							// ************************************************************************************* FOR
							for (int i=0; i<100 || i==100; i=i+1) {
								if(i==99){
									variable1 = -1;
									variable2 = "Hola Mundo "+"en Compi 1";
									variable3 = (true || false) && (!false);
									variable4 = (1+2+3-4*5*(6/7))/(80*90);
									variable5 = '%';
									return 10;
								}else{
									continue;
								}
							}
							continue;
						}
					}
				}while(true);
			}

			/*************************************************************************************
			**************************************************************************************
			********** DESCOMENNTAR BREAK Y CONTINUE PARA VALIDAR CORRECTA SINTAXIS **************
			**************************************************************************************
			*************************************************************************************/
			// break;
			// continue;
			
			
		}else{
			/*************************************************************************************
			**************************************************************************************
			*************** DESCOMENNTAR RETURN PARA VALIDAR CORRECTA SINTAXIS *******************
			**************************************************************************************
			*************************************************************************************/
			// return;
		}
	
		return 20;
	}
	

	public void METODO(){
		int variable1 = -1;
		String variable2 = "Hola Mundo "+"en Compi 1";
		boolean variable3 = (true || false) && (!false);
		double variable4 = (1+2+3-4*5*(6/7))/(80*90);
		char variable5 = '%';
		Sintaxis variable6 = new Sintaxis();

		// ***************************************************************************************** IF
		if ( variable6.atributo6.atributo6.atributo6.funcion_3()){
			variable1 = 10;
		}

		if (true){
			variable6.atributo2 = "xD";
		} else if ( variable6.atributo2 == "E"){
			variable6.atributo2 = "xD";
		} else if ( variable6.atributo2 == "T"){
			variable6.atributo2 = "xD";
		}

		if ( variable6.atributo2 == "S"){
			variable6.atributo2 = "xD";
		} else if ( variable6.atributo2 == "E"){
			variable6.atributo2 = "xD";
		} else if ( variable6.atributo2 == "T"){
			variable6.atributo2 = "xD";
		} else {
			variable6.atributo2 = "xD";
		}

		// ***************************************************************************************** SWITCH

		switch ( variable6.atributo2 ){
			case "Hola mundo":
				variable6.atributo2 = "xD";
				break;
			default:
				variable6.atributo2 = "xD";
				break;
		}

		switch ( this.atributo6.atributo2 ) {
			case "S":
				variable6.atributo2 = "xD";
				break;
			case "E":
				variable6.atributo2 = "xD";
				break; 
			case "T":
				variable6.atributo2 = "xD";
				break; 
			default:
				variable6.atributo2 = "xD";
				break;
		}






		if(variable1==1-2 &&  variable2=="Hola Mundo en Compi 1" && variable3==(false||true)){
			
			// ************************************************************************************* WHILE
			while(true){
				// ************************************************************************************* DO WHILE
				do{
					while(true){
						if(true){
							// ************************************************************************************* FOR
							for (int i=0; i<100 || i==100; i=i+1) {
								if(i==99){
									variable1 = -1;
									variable2 = "Hola Mundo "+"en Compi 1";
									variable3 = (true || false) && (!false);
									variable4 = (1+2+3-4*5*(6/7))/(80*90);
									variable5 = '%';
									return;
								}else{
									continue;
								}
							}
							continue;
						}
					}
				}while(true);
			}
			
		}else{
			/*************************************************************************************
			**************************************************************************************
			*************** DESCOMENNTAR RETURN PARA VALIDAR CORRECTA SINTAXIS *******************
			**************************************************************************************
			*************************************************************************************/
			// return 20;
		}
	}
	
}
