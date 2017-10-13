using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Nivel1 : MonoBehaviour {

	private float height,width,separacionNaves,i, posInicial;
	private Camera cam; 
	private UnityEngine.UI.Text ans1Txt, ans2Txt, ans3Txt;
	private Button ans1Btn,ans2Btn,ans3Btn;
	private Text ganaste;
	
	// Use this for initialization
	void Start () {
		cam = GameObject.Find("Main Camera").GetComponent<Camera>(); // Obtener la referencia a la camara
		
		//Calcular el tamaño de la pantalla 
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		posInicial = width / 2; 

		//ubicar el generador en el borde de la pantalla
		gameObject.transform.position= new Vector3(-posInicial,1,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
