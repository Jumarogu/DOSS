using UnityEngine;
using System.Collections;

public class naveNiv2 : MonoBehaviour {

	private float speed;
	private Vector3 startPosition;
	// Use this for initialization
	void Start () {
		
		 speed = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0,0,Time.deltaTime * speed);
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.name == "havay"){
			Destroy(this.gameObject);
			//Debug.Log("Choque");
		} 
	}
}
