using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Nivel1 : MonoBehaviour {

	private float height,width,separacionNaves,i, posInicial;
	private Camera cam; 
	private UnityEngine.UI.Text ans1Txt, ans2Txt, ans3Txt;
	private Button ans1Btn,ans2Btn,ans3Btn;
	private Text ganaste;
	private string [] numeros = {"Uno", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Ocho", "Nueve", "Diez"}; 
	private string [] respuestas; 
	private int numeroDeJuegos , j;
	private int [] numerosArray;

	// Use this for initialization
	void Start () {
		cam = GameObject.Find("Main Camera").GetComponent<Camera>(); // Obtener la referencia a la camara
		
		//Calcular el tamaño de la pantalla 
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		posInicial = width / 2; 

		//ubicar el generador en el borde de la pantalla
		gameObject.transform.position= new Vector3(-posInicial,1,0);

		//Referencias al Texto de los botones
		ans1Txt = GameObject.Find("TextAns1").GetComponent<UnityEngine.UI.Text>();
		ans2Txt = GameObject.Find("TextAns2").GetComponent<UnityEngine.UI.Text>();
		ans3Txt = GameObject.Find("TextAns3").GetComponent<UnityEngine.UI.Text>();

		//Inicializar los botones
		ans1Btn = GameObject.Find("Answer1").GetComponent<UnityEngine.UI.Button>();
		ans2Btn = GameObject.Find("Answer2").GetComponent<UnityEngine.UI.Button>();
		ans3Btn = GameObject.Find("Answer3").GetComponent<UnityEngine.UI.Button>();

		//referencia al texto de ganar 
		ganaste = GameObject.Find("Ganaste").GetComponent<UnityEngine.UI.Text>();
		ganaste.enabled = false;

		//Settear el numero de juegos
		numeroDeJuegos = 3;

		//inicializar el arreglo de números
		numerosArray =  new int[numeroDeJuegos];

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void respuestasRandom(){
		respuestas = new string[numeroDeJuegos];
		int num = 0;
		for(j=0;j<numeroDeJuegos;j++){
			num = numerosArray[j] - 1; 
			respuestas[j]= num + "";
			//Debug.Log("la respuesta es: " + num);
		}
		//Poner las opciones en los botones
		ans1Txt.text= respuestas[0];
		ans2Txt.text= respuestas[1];
		ans3Txt.text= respuestas[2];

	}

	void respuesta1(){

	}

	void respuesta2(){
		
	}

	void respuesta3(){
		
	}	
}
