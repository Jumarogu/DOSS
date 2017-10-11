using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class sesion : MonoBehaviour {
	private Dictionary<string,string> cookie;
	// Use this for initialization
	void Start () {
		//Awake ();
	}

	public void setcookie(Dictionary<string,string> cookie){
		this.cookie = cookie;
	}
	public Dictionary<string,string> getcookie(){
		return cookie;
	}
	void Awake() {
		DontDestroyOnLoad(this);
		}
		
}
