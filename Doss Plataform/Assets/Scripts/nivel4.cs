﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Networking;

public class nivel4 : MonoBehaviour {
	
	private Text ganaste, numPlaneta, erroresTxt; 
	private UnityEngine.UI.Text[] ansTextArray;
	private Button ansBtn1,ansBtn2,ansBtn3;
	private int numeroDeJuegos,juegoActual,i,navesQueCruzaron,navesQueRegresaron,respuestaJuegoActual,respuestaNino,errores;
	private int [] navesEnPlaneta;
	private Vector3 posGenerarNav, posGenerarNavRegreso;
	public GameObject [] naves;
	public GameObject planetaVecino;
	private GameObject cookie;
	private Dictionary<string,string> cook;
	private int seconds=0;
    private float secondsCounter=0;
    private float secondsToCount=1;
	private string URL = "http://10.43.59.23:8080/api/juega";

	
	// Use this for initialization
	void Start () {

		//Referencia a la base de datos 
		cookie = GameObject.Find("Cookies");
        cook = cookie.GetComponent<sesion>().getcookie();
		ganaste = GameObject.Find("Ganaste").GetComponent<UnityEngine.UI.Text>();
		ganaste.enabled = false;
		numeroDeJuegos = 3;
		juegoActual = 0;
		errores = 2;
		posGenerarNav = new Vector3(transform.position.x + 2f,transform.position.y,transform.position.z);
		posGenerarNavRegreso = new Vector3(planetaVecino.transform.position.x - 2f,planetaVecino.transform.position.y,planetaVecino.transform.position.z);
		
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
		respuestasRandom();
		StartCoroutine(navesIda());

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
		
		int numPas , numActual;
		numPas = 0;
		i = 0;
		while (i<numeroDeJuegos)
		{
			numActual = Random.Range(1,10);
			if(numActual != numPas){
				navesEnPlaneta[i] =  numActual;
				i++;
			}
			numPas = numActual;
			
		}
		//Poner el numero en el text del planeta 
		numPlaneta.text = navesEnPlaneta[juegoActual] + " naves";
		navesQueCruzaron = Random.Range(1,5);
		navesQueRegresaron = Random.Range (1,5);
	}
	

	IEnumerator navesIda(){
		Debug.Log("naves que van " + navesQueCruzaron);
		for(i=0;i<navesQueCruzaron;i++){
			Instantiate(naves[0],posGenerarNav,Quaternion.Euler(0,90,-90));
			yield return new WaitForSeconds(2f);
		}
		yield return new WaitForSeconds(2f);
		StartCoroutine(navesRegreso());
	}

	IEnumerator navesRegreso(){
		Debug.Log("naves que regresan " + navesQueRegresaron);
		for(i =0 ; i<navesQueRegresaron;i++){
			Instantiate(naves[1],posGenerarNavRegreso,Quaternion.Euler(0,-90,90));
			
			yield return new WaitForSeconds(2f);
		}
		
	}

	void respuestasRandom(){
		respuestaJuegoActual = (navesEnPlaneta[juegoActual] - navesQueCruzaron ) + navesQueRegresaron ; 
		Debug.Log("la respuesta es " + respuestaJuegoActual);
		int j = 0;
		while(j<3){
			int ran = Random.Range(5,15);
			if(ran != respuestaJuegoActual){
				ansTextArray[j].text = ran + "";
				j++;
			}else
			{
				ran = Random.Range(5,15);
			}
		}
		int num = Random.Range(0,2);
		ansTextArray[num].text = respuestaJuegoActual + "";
	}

	void terminarJuego(){
		
		errores = 3;
		erroresTxt.text = "Vidas: " + errores;
		//Subir info base de datos
		string respuestaC = "¿Cuantas naves quedaron en el planeta? R: " +respuestaJuegoActual;
		string date= System.DateTime.Now.ToString("dd/MM/yyyy");
        subirInfo(cook["id"],"07",seconds,respuestaNino+"",respuestaC,date,isOK());
        seconds = 0;
		juegoActual ++;
		if(juegoActual == numeroDeJuegos){
			SceneManager.LoadScene("planet");
		}
		numerosRandom();
		respuestasRandom();
		StartCoroutine(navesIda());
	}
	
	void listenerBtn1(){
		if(ansTextArray[0].text == (respuestaJuegoActual + "") ){
			StartCoroutine(Pausa());
			terminarJuego();
		}else{
			errores --;
			erroresTxt.text = "Vidas: " + errores;
			if(errores == 0){
				string nino = ansTextArray[0].text ;
				respuestaNino = int.Parse(nino);
				terminarJuego();
			}
		}
	}
	void listenerBtn2(){
		if(ansTextArray[1].text == (respuestaJuegoActual + "") ){
			StartCoroutine(Pausa());
			terminarJuego();
		}else{
			errores --;
			erroresTxt.text = "Vidas: " + errores;
			if(errores ==0){
				string nino = ansTextArray[1].text ;
				respuestaNino = int.Parse(nino);
				terminarJuego();
			}
		}
	}
	void listenerBtn3(){
		if(ansTextArray[2].text == (respuestaJuegoActual + "") ){
			StartCoroutine(Pausa());
			terminarJuego();
		}else
		{
			errores --;
			erroresTxt.text = "Vidas: " + errores;
			if(errores==0){
				string nino = ansTextArray[2].text ;
				respuestaNino = int.Parse(nino);
				terminarJuego();
			}
		}
	}

	IEnumerator Pausa(){
		ganaste.enabled = true;  
		yield return new WaitForSeconds(1);
		ganaste.enabled = false;
		  
	}
	IEnumerator Connection(string alumnoid,string juegoid,int time,string respuesta,string respuestaCorrecta,string fecha,int correcto)
    {
        WWWForm form = new WWWForm();
        form.AddField("alumnoId", alumnoid);
        form.AddField("juegoId", juegoid);
        form.AddField("tiempo", time);
        form.AddField("respuesta", respuesta);
        form.AddField("respuestaCorrecta",respuestaCorrecta); //respuesta correcta
        form.AddField("fecha", fecha);
        form.AddField("correcto", correcto);
        using (UnityWebRequest www = UnityWebRequest.Post( URL, form))
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
		//Debug.Log(respuestaNino + " " + respuestaJuegoActual );
		if(respuestaNino == respuestaJuegoActual){
			return 1;
		}else{
			return 0;
		}
	}
}