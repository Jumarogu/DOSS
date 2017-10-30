﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Nivel0 : MonoBehaviour {

	public GameObject [] nave;
	private int [] numerosArray ;
	private int numeroDeJuegos, j , juegoActual;
	private float height,width,separacionNaves,i, posInicial;
	private string respuesta;
	private string []respuestas;
	private Camera cam; 
	private UnityEngine.UI.Text ans1Txt, ans2Txt, ans3Txt;
	private Button ans1Btn,ans2Btn,ans3Btn;
	private Text ganaste;
	private GameObject[] ships;

	private Naves patron;
	private bool sacarNaves;
	private Vector3 currentPosition;

	// Use this for initialization
	void Start () {

		sacarNaves = false;
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
		ans1Txt = GameObject.Find("TextAns1").GetComponent<UnityEngine.UI.Text>();
		ans2Txt = GameObject.Find("TextAns2").GetComponent<UnityEngine.UI.Text>();
		ans3Txt = GameObject.Find("TextAns3").GetComponent<UnityEngine.UI.Text>();

		//Inicializar los botones
		ans1Btn = GameObject.Find("Answer1").GetComponent<UnityEngine.UI.Button>();
		ans2Btn = GameObject.Find("Answer2").GetComponent<UnityEngine.UI.Button>();
		ans3Btn = GameObject.Find("Answer3").GetComponent<UnityEngine.UI.Button>();


		//Recuperar la respuesta
		ans1Btn.onClick.AddListener(respuesta1);
		ans2Btn.onClick.AddListener(respuesta2);
		ans3Btn.onClick.AddListener(respuesta3);

		numerosRandom();
		respuestasRandom();
		generarNaves();

	}

	void Update(){
		if(sacarNaves && ships[0] != null){
			for(j= 0; j<numerosArray[juegoActual] - 1;j++){
				currentPosition = ships[j].transform.position;
				ships[j].transform.position = currentPosition + new Vector3(0.0f, 2f * Time.deltaTime, 0.0f);
			}
		}
	}

	void desactivarPatron(){
		for(j= 0; j<numerosArray[0] - 1;j++){
				patron = ships[j].GetComponent<Naves>();
				patron.enabled = false;
			}
			sacarNaves = true;
	}

	void numerosRandom(){
		//generar el arreglo de numero de naves de forma aleatoria
		numerosArray =  new int[numeroDeJuegos];
		for(j=0;j<numeroDeJuegos;j++){
			numerosArray[j]= Random.Range(2,10);
		}
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

	void generarNaves(){
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
	}

	

	void respuesta1(){
		if(ans1Txt.text == respuestas[juegoActual]){
			ganaste.enabled = true;
			desactivarPatron();
		}

	}

	void respuesta2(){
		if(ans2Txt.text == respuestas[juegoActual]){
			ganaste.enabled = true;
			desactivarPatron();
		}

	}

	void respuesta3(){
		if(ans3Txt.text == respuestas[juegoActual]){
			ganaste.enabled = true;
			desactivarPatron();
		}

	}



}
