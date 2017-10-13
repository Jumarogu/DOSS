using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Nivel0 : MonoBehaviour {

	public GameObject [] nave;
	private int [] numerosArray = {4,2,6 }; // Número de naves  = número del arreglo -1
	private int numeroDeJuegos, j ;
	private float height,width,separacionNaves,i, posInicial;
	private string respuesta;
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
		ships = new GameObject [numerosArray[0]];
		
		//Instansiar las naver con base al numero 
		separacionNaves = width / numerosArray[0]; // Calcular el espacio entre naves 
		j = 0; 
		for(i=separacionNaves;i<width;i+=separacionNaves){
			ships[j] = Instantiate (nave[0],
						new Vector3(transform.position.x + i , transform.position.y, transform.position.z),
				Quaternion.Euler(90,-90,90)) as GameObject;
				j++;
			
		}


	}

	void Update(){
		if(sacarNaves){
			for(j= 0; j<numerosArray[0] - 1;j++){
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

	

	void respuesta1(){
		if(ans1Txt.text == respuesta){
			ganaste.enabled = true;
			desactivarPatron();
		}

	}

	void respuesta2(){
		if(ans2Txt.text == respuesta){
			ganaste.enabled = true;
			desactivarPatron();
		}

	}

	void respuesta3(){
		if(ans3Txt.text == respuesta){
			ganaste.enabled = true;
			desactivarPatron();
		}

	}



}
