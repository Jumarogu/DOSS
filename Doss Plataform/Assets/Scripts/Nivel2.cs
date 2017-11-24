using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Nivel2 : MonoBehaviour {

	private Text ganaste, numPlaneta; 
	private UnityEngine.UI.Text[] ansTextArray;
	private Button ansBtn1,ansBtn2,ansBtn3;
	private int numeroDeJuegos,juegoActual,i, contador,navesQueCruzaron,respuestaJuegoActual;
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
		contador=0;
		posGenerarNav = new Vector3(transform.position.x + 2f,transform.position.y,transform.position.z);

		//Hacer las referencias al Text del botón de respuestas
		ansTextArray = new Text[3];
		for(i = 0;i<3;i++){
			string txt = "TextAns"+i;
			ansTextArray[i] =  GameObject.Find(txt).GetComponent<UnityEngine.UI.Text>();
		}
		numPlaneta = GameObject.Find("navesEnPlaneta").GetComponent<UnityEngine.UI.Text>();

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
	
	// Update is called once per frame
	void Update () {

		
	}

	void numerosRandom(){
		int numPas , numActual;
		numPas = 0;
		i = 0;
		while (i<numeroDeJuegos)
		{
			numActual = Random.Range(1,20);
			if(numActual != numPas){
				navesEnPlaneta[i] =  numActual;
				i++;
			}
			numPas = numActual;
			
		}
		//Poner el numero en el text del planeta 
		numPlaneta.text = navesEnPlaneta[juegoActual] + "";
	}
	

	void generarNave(){
		Instantiate(nave,posGenerarNav,Quaternion.Euler(0,90,-90));
		Debug.Log("genere la nave " + contador);
		contador++;
	}

	void respuestasRandom(){
		respuestaJuegoActual = navesQueCruzaron + navesEnPlaneta[juegoActual];
		for(i=0;i<3;i++){
			ansTextArray[i].text = Random.Range(1,30)  + "";
		}
		i = Random.Range(0,2);
		ansTextArray[i].text = respuestaJuegoActual + "";
	}

	
	IEnumerator corrutinaNaves(){
		navesQueCruzaron = Random.Range(1,10);
		Debug.Log("Van a pasar " + navesQueCruzaron +" naves");
		for(i=0;i<navesQueCruzaron;i++){
			generarNave();
			yield return new WaitForSeconds(3f);
		}
		
	}

	//Listeners para los botones
	void listenerBtn1(){

	}
	void listenerBtn2(){

	}
	void listenerBtn3(){

	}
}
