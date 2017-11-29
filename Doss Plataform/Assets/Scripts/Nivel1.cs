using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Nivel1 : MonoBehaviour {

	private float height,width,separacionNaves,i, posInicial;
	private Camera cam; 
	private Text ganaste, textoNumero, textoRespuesta, erroresTxt;
	private string [] numeros = {"uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez"}; 
	private string respuesta, respuestaNino; 
	private int numeroDeJuegos , j, juegoActual, respuestaActual, letraActual, errores;
	private int [] numerosArray;
	private InputField respuestaInField;
	private GameObject cookie;
	private Dictionary<string,string> cook;
	private int seconds=0;
    private float secondsCounter=0;
    private float secondsToCount=1;

	// Use this for initialization
	void Start () {

		//Referencia a la base de datos 
		cookie = GameObject.Find("Cookies");
        cook = cookie.GetComponent<sesion>().getcookie();
		
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

	void Update(){
		secondsCounter += Time.deltaTime;
		if (secondsCounter >= secondsToCount)
		{
			secondsCounter=0;
			seconds++;
		}

	}

	void numerosRandom(){
		//Chechar si el juego se acabo
		if(juegoActual >= numeroDeJuegos){
			/*string respuestaC = "Escribe el número R: " + respuesta;
			string date= System.DateTime.Now.ToString("dd/MM/yyyy");
			Debug.Log("la respuesta del morro es " + respuestaNino);
			subirInfo(cook["id"],"02",seconds,respuestaNino,respuestaC,date,isOK());			*/
			SceneManager.LoadScene("planet");
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
			string respuestaC = "Escribe el número R: " + respuesta;
			respuestaNino = ans;
			string date= System.DateTime.Now.ToString("dd/MM/yyyy");
			Debug.Log("la respuesta del morro es " + respuestaNino);
			subirInfo(cook["id"],"02",seconds,respuestaNino,respuestaC,date,isOK());			
			numerosRandom();
			seconds = 0;
		}
		if(errores <1){
			respuestaNino = ans;
			errores = 3;
			juegoActual++;
			textoRespuesta.text = "";
			erroresTxt.text = "Vidas: " + errores;
			letraActual = 0;	
			string respuestaC = "Escribe el número R: " + respuesta;
			string date= System.DateTime.Now.ToString("dd/MM/yyyy");
			subirInfo(cook["id"],"02",seconds,respuestaNino,respuestaC,date,isOK());		
			numerosRandom();
			seconds = 0;
			
		}
		

	}

	IEnumerator Pausa(){
		ganaste.enabled = true;  
		yield return new WaitForSeconds(1);
		ganaste.enabled = false;
		  
	}

	IEnumerator Connection(string alumnoid,string juegoid,int time,string respuestas,string respuestaCorrecta,string fecha,int correcto)
    {
        WWWForm form = new WWWForm();
        form.AddField("alumnoId", alumnoid);
        form.AddField("juegoId", juegoid);
        form.AddField("tiempo", time);
        form.AddField("respuesta", respuestas);
        form.AddField("respuestaCorrecta",respuestaCorrecta); //respuesta correcta
        form.AddField("fecha", fecha);
        form.AddField("correcto", correcto);
        using (UnityWebRequest www = UnityWebRequest.Post( "http://10.43.59.23:8080/api/juega", form))
        {
            yield return www.Send();
            if (!www.isError) {
                Debug.Log ("Se subio informacion correctamente");
            } else {
                Debug.Log ("Error: Algo ocurrio al momento de subir datos");
            }
        }
    }

	void subirInfo(string alumnoid,string juegoid,int time,string respuesta,string respuestaCorrecta,string fecha,int correcto){
        StartCoroutine(Connection(alumnoid,juegoid,time,respuesta,respuestaCorrecta,fecha,correcto));
    }

	int isOK(){
		if(respuesta == respuestaNino){
			return 1;
		}else{
			return 0;
		}
	}

	
}
