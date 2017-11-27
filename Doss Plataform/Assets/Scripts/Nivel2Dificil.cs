using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Nivel2Dificil : MonoBehaviour {

	private Text ganaste, numPlaneta, erroresTxt; 
	private UnityEngine.UI.Text[] ansTextArray;
	private Button ansBtn1,ansBtn2,ansBtn3;
	private int numeroDeJuegos,juegoActual,i,navesQueCruzaron,respuestaJuegoActual,respuestaNino,errores;
	private int [] navesEnPlaneta;
	private float timer;
	private Vector3 posGenerarNav;
	public GameObject nave;


	
	// Use this for initialization
	void Start () {
		ganaste = GameObject.Find("Ganaste").GetComponent<UnityEngine.UI.Text>();
		ganaste.enabled = false;
		numeroDeJuegos = 3;
		juegoActual = 0;
		errores = 3;
		posGenerarNav = new Vector3(transform.position.x + 2f,transform.position.y,transform.position.z);

		//Hacer las referencias al Text del botón de respuestas
		ansTextArray = new Text[3];
		for(i = 0;i<3;i++){
			string txt = "TextAns"+i;
			ansTextArray[i] =  GameObject.Find(txt).GetComponent<UnityEngine.UI.Text>();
		}
		numPlaneta = GameObject.Find("navesEnPlaneta").GetComponent<UnityEngine.UI.Text>();
		//Settear las oportunidades
		erroresTxt = GameObject.Find("Errores").GetComponent<UnityEngine.UI.Text>();
		erroresTxt.text = "Vidas: " + errores;

		//Hacer las referencias a los botones de respuesta 
		ansBtn1 = GameObject.Find("Answer1").GetComponent<UnityEngine.UI.Button>();
		ansBtn2 = GameObject.Find("Answer2").GetComponent<UnityEngine.UI.Button>();
		ansBtn3 = GameObject.Find("Answer3").GetComponent<UnityEngine.UI.Button>();
		//Hacer las referencias a los listeners de los botones 
		ansBtn1.onClick.AddListener(listenerBtn1);
		ansBtn2.onClick.AddListener(listenerBtn2);
		ansBtn3.onClick.AddListener(listenerBtn3);

		//Inicializar el arreglo de numero de naves 
		navesEnPlaneta = new int [numeroDeJuegos];
		numerosRandom();
		StartCoroutine(corrutinaNaves());
		respuestasRandom();
		
	}

	
	void numerosRandom(){
		
		int numPas , numActual;
		numPas = 0;
		i = 0;
		while (i<numeroDeJuegos)
		{
			numActual = Random.Range(5,15);
			if(numActual != numPas){
				navesEnPlaneta[i] =  numActual;
				i++;
			}
			numPas = numActual;
			
		}
		//Poner el numero en el text del planeta 
		numPlaneta.text = navesEnPlaneta[juegoActual] + " naves";
	}
	

	void respuestasRandom(){
		respuestaJuegoActual = navesQueCruzaron + navesEnPlaneta[juegoActual];
		Debug.Log("la respuesta es " + respuestaJuegoActual );
		int j = 0 ; 
		while(j<3){
			int ran = Random.Range(navesEnPlaneta[juegoActual],15);
			if(ran != respuestaJuegoActual){
				ansTextArray[j].text = ran + "";
				j++;
			}else{
				ran = Random.Range(navesEnPlaneta[juegoActual],15);
			}
		}
		int num = Random.Range(0,2);
		ansTextArray[num].text = respuestaJuegoActual + "";
		
	}

	
	IEnumerator corrutinaNaves(){
		navesQueCruzaron = Random.Range(3,8);
		Debug.Log("Van a pasar " + navesQueCruzaron +" naves");
		for(i=0;i<navesQueCruzaron;i++){
			Instantiate(nave,posGenerarNav,Quaternion.Euler(0,90,-90));
			Debug.Log("Genere la nave num " + i);
			yield return new WaitForSeconds(2f);
		}
		
	}
	void terminarJuego(){
		numerosRandom();
		StartCoroutine(corrutinaNaves());
		respuestasRandom();
		errores = 3;
		erroresTxt.text = "Vidas: " + errores;
		juegoActual ++;
		if(juegoActual == numeroDeJuegos){
			SceneManager.LoadScene("planet");
		}
	}

	//Listeners para los botones
	void listenerBtn1(){
		if(errores < 1){
			terminarJuego();
		}
		string nino = ansTextArray[0].text ;
		respuestaNino = int.Parse(nino);
		if(ansTextArray[0].text == (respuestaJuegoActual + "") ){
			StartCoroutine(Pausa());
			terminarJuego();
		}else{
			errores --;
			erroresTxt.text = "Vidas: " + errores;
		}
	}
	void listenerBtn2(){
		if(errores < 1){
			terminarJuego();
		}
		string nino = ansTextArray[0].text ;
		respuestaNino = int.Parse(nino);
		if(ansTextArray[1].text == (respuestaJuegoActual + "") ){
			StartCoroutine(Pausa());
			terminarJuego();
		}else{
			errores --;
			erroresTxt.text = "Vidas: " + errores;
		}
	}
	void listenerBtn3(){
		if(errores< 1){
			terminarJuego();
		}
		string nino = ansTextArray[0].text ;
		respuestaNino = int.Parse(nino);
		if(ansTextArray[2].text == (respuestaJuegoActual + "") ){
			StartCoroutine(Pausa());
			terminarJuego();
		}else
		{
			errores --;
			erroresTxt.text = "Vidas: " + errores;
		}
	}

	IEnumerator Pausa(){
		ganaste.enabled = true;  
		yield return new WaitForSeconds(1);
		ganaste.enabled = false;
		  
	}
}
