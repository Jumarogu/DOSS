using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Tienda : MonoBehaviour {

	public Sprite [] iconosDelfin;
	public Sprite [] iconosLeon;
	public Image [] imgProducto;
	public Button comprarProducto1,comprarProducto2,comprarProducto3, regresar;
	private GameObject [] productPanel;
	private Text [] preciosTxt;
	private Text dineroTxt, errorTxt,compraTxt;
	public GameObject cookie;
	private Dictionary<string,string> cook;
	private int dinero, icono;
	private string URL = "http://10.43.59.23:8080/api/compra";


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

		compraTxt = GameObject.Find("compraHecha").GetComponent<UnityEngine.UI.Text>();
		compraTxt.enabled = false;
	}

	void comprar1(){
		dinero = int.Parse(cook["dinero"]);
		if(dinero>50){
			icono = 1;
			StartCoroutine(shoCompra());
			
			//actualizar la bd
			StartCoroutine(Connection(cook["id"],50));
		}else
		{
			StartCoroutine(showError());
		}
	}
	void comprar2(){
		dinero = int.Parse(cook["dinero"]);
		if(dinero>50){
			icono = 2;
			StartCoroutine(shoCompra());
			//actualizar la bd
			StartCoroutine(Connection(cook["id"],50));
		}else
		{
			StartCoroutine(showError());
		}
	}
	void comprar3(){
		dinero = int.Parse(cook["dinero"]);
		if(dinero>50){
			icono =3;
			StartCoroutine(shoCompra());
			//actualizar la bd
			StartCoroutine(Connection(cook["id"],50));
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

	IEnumerator shoCompra(){
		compraTxt.enabled = true;
		yield return new WaitForSeconds(3f);
		compraTxt.enabled = false;
	}

	IEnumerator Connection(string alumnoid, int gasto){
		WWWForm form = new WWWForm();
		form.AddField("alumnoid",alumnoid);
		form.AddField("gasto",gasto);
		using (UnityWebRequest www = UnityWebRequest.Post( URL, form))
        {
            yield return www.Send();
            if (!www.isError) {
				string resp = www.downloadHandler.text.Replace ('"', ' ').Replace ('{', ' ').Replace ('}', ' ').Trim ();
				Dictionary<string,string> dictionary = ConvertDictionary (resp);
				cookie.GetComponent<sesion>().setcookie(dictionary);
				Dictionary<string,string> cook=cookie.GetComponent<sesion>().getcookie();
				//SceneManager.LoadScene("planet");
			} else {
				Debug.Log ("Error: Contrasena o Usuario incorrectos");
				
			}
        }
		dineroTxt.text = "Dinero: " + cook["dinero"];
	}

	Dictionary<string,string> ConvertDictionary(string resp){
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string[] items = resp.TrimEnd(',').Split(',');
		foreach (string item in items)
		{
			string[] keyValue = item.Split(':');
			dictionary.Add(keyValue[0].Trim(), keyValue[1].Trim());
		}
		dictionary.Add("icono",icono + "");
		return dictionary;
	}
}
