using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Nivel0 : MonoBehaviour {

	public GameObject [] nave;
	private int [] numerosArray = {5,2,6 }; // Número de naves  = número del arreglo -1
	private int numeroDeJuegos;
	private float height,width,separacionNaves,i, posInicial;
	private string respuesta;
	private Camera cam; 
	private UnityEngine.UI.Text ans1Txt, ans2Txt, ans3Txt;
	private Button ans1Btn,ans2Btn,ans3Btn;
	private Text ganaste;

	// Use this for initialization
	void Start () {
		//referencia al texto de ganar 
		ganaste = GameObject.Find("Ganaste").GetComponent<UnityEngine.UI.Text>();
		ganaste.enabled = false;
		cam = GameObject.Find("Main Camera").GetComponent<Camera>(); // Obtener la referencia a la camara
		numeroDeJuegos = 3; 
		respuesta = "3";
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

		//Poner las opciones en los botones
		ans1Txt.text="5";
		ans2Txt.text="3";
		ans3Txt.text="1";

		//Recuperar la respuesta
		ans1Btn.onClick.AddListener(respuesta1);
		ans2Btn.onClick.AddListener(respuesta2);
		ans3Btn.onClick.AddListener(respuesta3);

		//ubicar el generador en el borde de la pantalla
		
		gameObject.transform.position= new Vector3(-posInicial,1,0);
		
		//Instansiar las naver con base al numero 
		separacionNaves = width / numerosArray[0]; // Calcular el espacio entre naves 
		for(i=separacionNaves;i<width;i+=separacionNaves){
			Instantiate (nave[0],
						new Vector3(transform.position.x + i , transform.position.y, transform.position.z),
				Quaternion.Euler(90,-90,90));
			//Naves nav = gameObject.GetComponent<Naves>;
		}


	}
	
	void respuesta1(){
		if(ans1Txt.text == respuesta){
			Debug.Log ("Ganaste la respuesta es " + ans1Txt.text);
			ganaste.enabled = true;
		}

	}

	void respuesta2(){
		if(ans2Txt.text == respuesta){
			Debug.Log ("Ganaste la respuesta es " + ans2Txt.text);
			ganaste.enabled = true;
		}

	}

	void respuesta3(){
		if(ans3Txt.text == respuesta){
			Debug.Log ("Ganaste la respuesta es " + ans3Txt.text);
			ganaste.enabled = true;
		}

	}

}
