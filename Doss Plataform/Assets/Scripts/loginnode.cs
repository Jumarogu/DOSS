using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class loginnode : MonoBehaviour
{
	public Button delfin, leon;
	public Dropdown NoLista, day, month;
	public GameObject cookie;
	private string grupo, url;
	public Text error;

	void Start(){
		//blogin.onClick.AddListener(action);
		delfin.onClick.AddListener(delfinBtnListener);
		leon.onClick.AddListener(leonBtnListener);
		error.enabled = false;
		url = "http://10.43.59.23:8080/api/login-alumno";

	}

	void delfinBtnListener(){
		grupo = "A";
		StartCoroutine(Connection());	
	}

	void leonBtnListener(){
		grupo = "B";
		StartCoroutine(Connection());
	}


	IEnumerator Connection()
	{
		WWWForm form = new WWWForm();
		form.AddField("cumpleanos", day.options[day.value].text+"/"+month.options[month.value].text);
		form.AddField("noLista", NoLista.options[NoLista.value].text);
		form.AddField("grupo", grupo);
		//Debug.Log(grupo);

		using (UnityWebRequest www = UnityWebRequest.Post(url, form))
		{
			yield return www.Send();
			if (!www.isError) {
				string resp = www.downloadHandler.text.Replace ('"', ' ').Replace ('{', ' ').Replace ('}', ' ').Trim ();
				Dictionary<string,string> dictionary = ConvertDictionary (resp);
				cookie.GetComponent<sesion>().setcookie(dictionary);
				Dictionary<string,string> cook=cookie.GetComponent<sesion>().getcookie();
				SceneManager.LoadScene("planet");
			} else {
				Debug.Log ("Error: Contrasena o Usuario incorrectos");
				StartCoroutine(pausa());
			}
		}

	}

	Dictionary<string,string> ConvertDictionary(string resp){
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string[] items = resp.TrimEnd(',').Split(',');
		foreach (string item in items)
		{
			string[] keyValue = item.Split(':');
			dictionary.Add(keyValue[0].Trim(), keyValue[1].Trim());
		}
		dictionary.Add("icono","0");
		return dictionary;
	}

	IEnumerator pausa(){
		error.enabled = true;
		yield return new WaitForSeconds(5f);
		error.enabled = false;
	}
}
