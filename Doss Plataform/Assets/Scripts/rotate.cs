using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	public GameObject [] planetas;
	private float speed;	
	private int i;
	void Start(){
		speed = 5;
	} 

	void Update () {
		for(i =0; i<12;i++){
			planetas[i].transform.Rotate(Vector3.up, speed * Time.deltaTime);
		}
	}
}
