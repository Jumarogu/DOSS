using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tienda : MonoBehaviour {

	public Sprite [] iconosDelfin;
	public Sprite [] iconosLeon;
	public Image [] imgProducto;
	public Button comprarProducto1,comprarProducto2,comprarProducto3, regresar;
	private GameObject [] productPanel;
	private Text [] preciosTxt;
	private Text dineroTxt, errorTxt;
	public GameObject cookie;
	private Dictionary<string,string> cook;


	// Use this for initialization
	void Start () {
		preciosTxt = new Text [3];
		productPanel = new GameObject[3];
		string txt = "ProductInfo";
		for(int i = 0; i<3;i++){
			productPanel[i] = GameObject.Find(txt+i);
			preciosTxt[i]= GameObject.Find(txt+i).GetComponentInChildren<UnityEngine.UI.Text>();
			//Debug.Log(txt+i);
		}
		cookie = GameObject.Find("Cookies");
        cook = cookie.GetComponent<sesion>().getcookie();
		//Poner la mascota
        if(cook["grupo"] == "A"){
            for(int i = 0;i<3;i++ ){
				preciosTxt[i].text = "$50";
				imgProducto[i].sprite = iconosDelfin[i];
			}
        }
        if(cook["grupo"] == "b"){
            for(int i = 0;i<3;i++ ){
				preciosTxt[i].text = "$50";
				imgProducto[i].sprite = iconosLeon[i];
			}
        }

		comprarProducto1.onClick.AddListener(comprar1);
		comprarProducto2.onClick.AddListener(comprar2);
		comprarProducto3.onClick.AddListener(comprar3);
		regresar.onClick.AddListener(regresarMenu);

		dineroTxt = GameObject.Find("Dinero").GetComponent<UnityEngine.UI.Text>();
		dineroTxt.text = "Dinero: " + cook["dinero"];

		errorTxt = GameObject.Find("sinDinero").GetComponent<UnityEngine.UI.Text>();
		errorTxt.enabled = false;
	}

	void comprar1(){
		int dinero = int.Parse(cook["dinero"]);
		if(dinero>50){
			cook["icono"]="1";
			//actualizar la bd
		}else
		{
			StartCoroutine(showError());
		}
		
		
	}
	void comprar2(){
		int dinero = int.Parse(cook["dinero"]);
		if(dinero>50){
			cook["icono"]="2";
			//actualizar la bd
		}else
		{
			StartCoroutine(showError());
		}
	}
	void comprar3(){
		int dinero = int.Parse(cook["dinero"]);
		if(dinero>50){
			cook["icono"]="3";
			//actualizar la bd
		}else
		{
			StartCoroutine(showError());
		}
	}

	void regresarMenu(){
		SceneManager.LoadScene("planet");
	}

	IEnumerator showError(){
		errorTxt.enabled = true;
		yield return new WaitForSeconds(4f);
		errorTxt.enabled =  false;
	}
}
