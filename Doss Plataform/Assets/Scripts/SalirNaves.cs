using UnityEngine;
using System.Collections;

public class SalirNaves : MonoBehaviour {

	private Vector3 curPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		curPosition = transform.position; 
		transform.position = curPosition + new Vector3 (0.0f, 2f * Time.deltaTime, 0.0f);
		//Debug.Log("Estoy saliendo");
	}
}
