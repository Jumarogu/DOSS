using UnityEngine;
using System.Collections;

public class Naves : MonoBehaviour {

	private Vector3 _startPosition;
	public float amplitud;
	private float speed;
 	void Start () 
	 {
     	_startPosition = transform.position;
		 speed = 2.4f;
	 }
 
	 void Update()
 	{
		transform.position = _startPosition + new Vector3(0.0f, Mathf.Sin(Time.time* speed) * amplitud, 0.0f);
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.name == "Destructor"){
			Destroy(this.gameObject);
		}
	}

}
