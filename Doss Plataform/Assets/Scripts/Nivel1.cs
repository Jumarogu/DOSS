using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Nivel1 : MonoBehaviour {

	private float height,width,separacionNaves,i, posInicial;
	private Camera cam; 
	private Text ganaste, textoNumero, textoRespuesta;
	private string [] numeros = {"uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez"}; 
	private string respuesta; 
	private int numeroDeJuegos , j, juegoActual, respuestaActual, letraActual;
	private int [] numerosArray;
	private InputField respuestaInField;

	// Use this for initialization
	void Start () {
		/*cam = GameObject.Find("Main Camera").GetComponent<Camera>(); // Obtener la referencia a la camara
		
		//Calcular el tamaño de la pantalla 
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		posInicial = width / 2; 

		//ubicar el generador en el borde de la pantalla
		gameObject.transform.position= new Vector3(-posInicial,1,0);
		*/

		//Buscar los elementos en la escena 
		textoNumero = GameObject.Find("Numero").GetComponent<UnityEngine.UI.Text>();
		textoRespuesta = GameObject.Find("Respuesta").GetComponent<UnityEngine.UI.Text>();
		respuestaInField = GameObject.Find("InputField").GetComponent<UnityEngine.UI.InputField>();

		//Settear el numero de juegos
		numeroDeJuegos = 3;
		juegoActual = 0;
		textoRespuesta.text = "";

		respuestaInField.onValueChange.AddListener(delegate {leerRespuesta();});

		//inicializar el arreglo de números
		numerosArray =  new int[numeroDeJuegos];

		numerosRandom();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void numerosRandom(){
		//Chechar si el juego se acabo
		if(juegoActual >= numeroDeJuegos){
				SceneManager.LoadScene("planet");
				Debug.Log("GAME OVER");

		}

		//generar los numeros random
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
		respuestaInField.text = "";
		Debug.Log(respuesta);
	}

	void leerRespuesta(){
		string ans = respuestaInField.text;
		//Debug.Log("numero de letra: " + letraActual);
		//Debug.Log("ans.Length: " + ans.Length);
		if(ans.Length != 0){
			if(ans[letraActual] == respuesta[letraActual]){
				textoRespuesta.text = ans;
				letraActual++;
			}
		}
		
		if(ans == respuesta){
			juegoActual++;
			textoRespuesta.text = "";
			letraActual = 0;
			numerosRandom();
		}
		

	}

	
}
