using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Nivel1 : MonoBehaviour {

	private float height,width,separacionNaves,i, posInicial;
	private Camera cam; 
	private Text ganaste, textoNumero, textoRespuesta, erroresTxt;
	private string [] numeros = {"uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez"}; 
	private string respuesta; 
	private int numeroDeJuegos , j, juegoActual, respuestaActual, letraActual, errores;
	private int [] numerosArray;
	private InputField respuestaInField;

	// Use this for initialization
	void Start () {
		
		ganaste = GameObject.Find("Ganaste").GetComponent<UnityEngine.UI.Text>();
		ganaste.enabled = false;

		//Buscar los elementos en la escena 
		textoNumero = GameObject.Find("Numero").GetComponent<UnityEngine.UI.Text>();
		textoRespuesta = GameObject.Find("Respuesta").GetComponent<UnityEngine.UI.Text>();
		erroresTxt = GameObject.Find("Errores").GetComponent<UnityEngine.UI.Text>();
		respuestaInField = GameObject.Find("InputField").GetComponent<UnityEngine.UI.InputField>();

		//Settear el numero de juegos
		numeroDeJuegos = 3;
		juegoActual = 0;
		textoRespuesta.text = "";
		errores = 3;
		erroresTxt.text = "Vidas: " + errores;

		respuestaInField.onValueChange.AddListener(delegate {leerRespuesta();});

		//inicializar el arreglo de números
		numerosArray =  new int[numeroDeJuegos];

		numerosRandom();
	
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
			}else
			{
				errores --;
				erroresTxt.text = "Vidas: " + errores;
			}
		}
		
		if(ans == respuesta){
			StartCoroutine(Pausa());
			errores = 3;
			juegoActual++;
			textoRespuesta.text = "";
			erroresTxt.text = "Vidas: " + errores;
			letraActual = 0;			
			numerosRandom();
		}
		if(errores <1){
			errores = 3;
			juegoActual++;
			textoRespuesta.text = "";
			erroresTxt.text = "Vidas: " + errores;
			letraActual = 0;			
			numerosRandom();
			
		}
		

	}

	IEnumerator Pausa(){
		ganaste.enabled = true;  
		yield return new WaitForSeconds(1);
		ganaste.enabled = false;
		  
	}

	
}
