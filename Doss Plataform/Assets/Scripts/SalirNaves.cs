using UnityEngine;
using System.Collections;

public class SalirNaves : MonoBehaviour {

	//private Vector3 curPosition;
	private float timer;
	// Use this for initialization
	void Start () {
		timer = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		
		//transform.position = curPosition + new Vector3 (0.0f, 2f * Time.deltaTime, 0.0f);
		transform.Translate(0,0,Time.deltaTime * -2f);
		timer -= Time.deltaTime;
		if(timer < 0){
			Destroy(this.gameObject);
		}
	}
}
