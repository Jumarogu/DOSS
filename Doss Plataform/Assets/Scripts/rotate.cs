using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	private float speed;	
	void Start(){
		speed = 5;
	} 

	void Update () {
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
		
	}
}
