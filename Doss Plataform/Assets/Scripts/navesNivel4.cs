using UnityEngine;
using System.Collections;

public class navesNivel4 : MonoBehaviour {

	private float speed;
	private Vector3 startPosition;
	// Use this for initialization
	void Start () {
		speed = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0,0,Time.deltaTime * speed);
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.name == "egipt"){
			Destroy(this.gameObject);
		} 
	}
}
