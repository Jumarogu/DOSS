using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class loginnode : MonoBehaviour
{
	public Button blogin;
	public Dropdown NoLista, Grupo, day, month;
	public GameObject cookie;
	void Start(){
		blogin.onClick.AddListener(action);

	}
	void action()
	{
		StartCoroutine(Connection());
	}

	void Upload(){
		
	}

	IEnumerator Connection()
	{
		WWWForm form = new WWWForm();
		form.AddField("cumpleanos", day.options[day.value].text+"/"+month.options[month.value].text);
		form.AddField("noLista", NoLista.options[NoLista.value].text);
		form.AddField("grupo", Grupo.options[Grupo.value].text);

		using (UnityWebRequest www = UnityWebRequest.Post("http://10.43.52.177:8080/api/login-alumno", form))
		{
			yield return www.Send();
			if (!www.isError) {
				string resp = www.downloadHandler.text.Replace ('"', ' ').Replace ('{', ' ').Replace ('}', ' ').Trim ();
				Dictionary<string,string> dictionary = ConvertDictionary (resp);
				//Debug.Log (dictionary["apellidos"]);
				Debug.Log (dictionary ["nombres"]);
				cookie.GetComponent<sesion>().setcookie(dictionary);
				Dictionary<string,string> cook=cookie.GetComponent<sesion>().getcookie();
				SceneManager.LoadScene("planet");
			} else {
				Debug.Log ("Error: Contrasena o Usuario incorrectos");
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
		return dictionary;
	}
}
