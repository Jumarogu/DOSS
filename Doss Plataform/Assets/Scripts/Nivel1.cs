using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Nivel1 : MonoBehaviour {

	private float height,width,separacionNaves,i, posInicial;
	private Camera cam; 
	private Text ganaste, textoNumero;
	private string [] numeros = {"uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez"}; 
	private string respuesta; 
	private int numeroDeJuegos , j, juegoActual, respuestaActual, letraActual;
	private int [] numerosArray;
	private InputField respuestaInField;

	// Use this for initialization
	void Start () {
		cam = GameObject.Find("Main Camera").GetComponent<Camera>(); // Obtener la referencia a la camara
		
		//Calcular el tamaño de la pantalla 
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		posInicial = width / 2; 

		//ubicar el generador en el borde de la pantalla
		gameObject.transform.position= new Vector3(-posInicial,1,0);

	
		//referencia al texto de ganar 
		//ganaste = GameObject.Find("Ganaste").GetComponent<UnityEngine.UI.Text>();
		//ganaste.enabled = false;
		
		//Buscar los elementos en la escena 
		textoNumero = GameObject.Find("Numero").GetComponent<UnityEngine.UI.Text>();
		respuestaInField = GameObject.Find("InputField").GetComponent<UnityEngine.UI.InputField>();

		//Settear el numero de juegos
		numeroDeJuegos = 3;
		juegoActual = 0;

		respuestaInField.onValueChange.AddListener(delegate {leerRespuesta();});

		//inicializar el arreglo de números
		numerosArray =  new int[numeroDeJuegos];

		numerosRandom();
	
		//respuestasRandom();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void numerosRandom(){

		int numPas, numActual;
		numPas = 0 ;

		while (j<numeroDeJuegos)
		{
			numActual = Random.Range(2,11);
			if(numActual != numPas){
				numerosArray[j] = numActual;
				j++;
			}
			numPas = numActual;
		}
		respuestaActual = numerosArray[juegoActual] ; 
		textoNumero.text = respuestaActual + "";
		respuesta = numeros[respuestaActual-1];
		Debug.Log(respuesta);
	}

	/*void respuestasRandom(){
		textoNumero.text = respuestaActual + "";
		string palabra = numeros[respuestaActual-1];
		int rand;
		respuestaActual = 0;
		for(j=0;j<3;j++){
			rand = Random.Range(0,palabra.Length);
			ansTextArray[j].text = palabra[rand].ToString(); 
		}
		j = Random.Range(1,3);
		ansTextArray[j].text = palabra[letraActual].ToString();

	}*/


	void leerRespuesta(){
		string ans = respuestaInField.text;
		if(ans[letraActual] == respuesta[letraActual]){
			Debug.Log("Que pedo");
		}
		

	}

	void respuesta2(){
		
	}

	void respuesta3(){
		
	}	
}
