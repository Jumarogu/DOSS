using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Nivel0 : MonoBehaviour {

	public GameObject [] nave;
	private int [] numerosArray ;
	private int numeroDeJuegos, j , juegoActual, numNavesEnJuegoActual;
	private float height,width,separacionNaves,i, posInicial;
	private string []respuestas;
	private string respuestaNino;
	private Camera cam; 
	private UnityEngine.UI.Text ans1Txt, ans2Txt, ans3Txt ;
	private UnityEngine.UI.Text [] ansTextArray;
	private Button ans1Btn,ans2Btn,ans3Btn;
	private Text ganaste;
	private GameObject[] ships;

	private Naves patron;
	private SalirNaves salida;
	private Vector3 currentPosition;

	// Use this for initialization
	void Start () {

		
		//referencia al texto de ganar 
		ganaste = GameObject.Find("Ganaste").GetComponent<UnityEngine.UI.Text>();
		ganaste.enabled = false;
		cam = GameObject.Find("Main Camera").GetComponent<Camera>(); // Obtener la referencia a la camara
		numeroDeJuegos = 3; 
		juegoActual = 0;
		
		//Calcular el tamaño de la pantalla 
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		posInicial = width / 2; 

		//Referencias al Texto de los botones
		ansTextArray = new Text [3];
		for(int k = 0 ;k<3;k++){
			string txt = "TextAns"+k;
			Debug.Log(txt);
			ansTextArray[k] = GameObject.Find(txt).GetComponent<UnityEngine.UI.Text>();
		}
		/*ans1Txt = GameObject.Find("TextAns1").GetComponent<UnityEngine.UI.Text>();
		ans2Txt = GameObject.Find("TextAns2").GetComponent<UnityEngine.UI.Text>();
		ans3Txt = GameObject.Find("TextAns3").GetComponent<UnityEngine.UI.Text>();*/

		//Inicializar los botones
		ans1Btn = GameObject.Find("Answer1").GetComponent<UnityEngine.UI.Button>();
		ans2Btn = GameObject.Find("Answer2").GetComponent<UnityEngine.UI.Button>();
		ans3Btn = GameObject.Find("Answer3").GetComponent<UnityEngine.UI.Button>();


		//Recuperar la respuesta
		ans1Btn.onClick.AddListener(respuesta1);
		ans2Btn.onClick.AddListener(respuesta2);
		ans3Btn.onClick.AddListener(respuesta3);

		//inicializar el arreglo de números
		numerosArray =  new int[numeroDeJuegos];

		numerosRandom();
		respuestasRandom();
		generarNaves();
		
	}

	void Update(){

		//Debug.Log("numero de naves en el juego: " + numNavesEnJuegoActual);
		if(ships[0] ==  null){
			juegoActual ++;
			if(juegoActual > numeroDeJuegos){
				SceneManager.LoadScene("planet");
				Debug.Log("GAME OVER");

			}
			respuestasRandom();
			generarNaves();
			ganaste.enabled = false;
			
			
		}
	}

	void desactivarPatron(){
		for(j= 0; j<numerosArray[juegoActual] - 1;j++){
				patron = ships[j].GetComponent<Naves>();
				patron.enabled = false;
			}
			
		for(j=0; j<numerosArray[juegoActual] - 1; j++){
				salida = ships[j].GetComponent<SalirNaves>();
				salida.enabled = true;
		}
	}

	void numerosRandom(){

		int numPas, numActual;
		numPas = 0 ;respuestaNino = ansTextArray[0].text;
		//generar el arreglo de numero de naves de forma aleatoria
		/*for(j=0;j<numeroDeJuegos;j++){
			numActual = Random.Range(1,10);
			if(numActual != numPas){
				Debug.Log(numActual + "");
				numerosArray[j]= numActual;
			}
			numPas = numActual;
		}*/

		while (j<numeroDeJuegos)
		{
			numActual = Random.Range(2,11);
			if(numActual != numPas){
				numerosArray[j] = numActual;
				Debug.Log("Numero de naves en el juego " + j + ": " + numActual);
				j++;
			}
			numPas = numActual;
		}
		
	}

	void respuestasRandom(){
		/*
		respuestas = new string[numeroDeJuegos];
		int num = 0;
		for(j=0;j<numeroDeJuegos;j++){
			num = numerosArray[j] - 1; 
			respuestas[j]= num + "";

			//Debug.Log("la respuesta es: " + num);
		}
		//Poner las opciones en los botones
		ans1Txt.text= respuestas[2] ;
		ans2Txt.text= respuestas[0] ;
		ans3Txt.text= respuestas[1] ;
		*/
		for(j=0;j<3;j++){
			ansTextArray[j].text = Random.Range(1,10)  + "";
		}
		j = Random.Range(0,2);
		int num = numerosArray[juegoActual] - 1;
		ansTextArray[j].text = num + "";
		
	}

	void generarNaves(){
		numNavesEnJuegoActual = numerosArray[juegoActual] ;
		//ubicar el generador en el borde de la pantalla		
		gameObject.transform.position= new Vector3(-posInicial,1,0);
		ships = new GameObject [numerosArray[juegoActual]];
		
		//Instansiar las naver con base al numero 
		separacionNaves = width / numerosArray[juegoActual]; // Calcular el espacio entre naves 
		j = 0; 
		for(i=separacionNaves;i<width;i+=separacionNaves){
			ships[j] = Instantiate (nave[0],
						new Vector3(transform.position.x + i , transform.position.y, transform.position.z),
				Quaternion.Euler(90,-90,90)) as GameObject;
				j++;
			
		}
		//Debug.Log(separacionNaves + "");
	}

	

	void respuesta1(){
		respuestaNino = ansTextArray[0].text;
		Debug.Log(respuestaNino);
		if(ansTextArray[0].text == (numNavesEnJuegoActual-1) + ""){
			ganaste.enabled = true;
			desactivarPatron();
		}

	}

	void respuesta2(){
		respuestaNino = ansTextArray[1].text;
		Debug.Log(respuestaNino);
		if(ansTextArray[1].text == (numNavesEnJuegoActual-1) + ""){
			ganaste.enabled = true;
			desactivarPatron();
		}

	}

	void respuesta3(){
		respuestaNino = ansTextArray[2].text;
		Debug.Log(numNavesEnJuegoActual + "");
		if(ansTextArray[2].text == (numNavesEnJuegoActual -1) +  ""){
			ganaste.enabled = true;
			desactivarPatron();
		}

	}



}
