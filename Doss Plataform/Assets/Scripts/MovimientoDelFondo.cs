using UnityEngine;
using System.Collections;

public class MovimientoDelFondo : MonoBehaviour {

	private float speed, tileSize;
	
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = gameObject.transform.position;
		tileSize = 20f;
		speed = -0.30f;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat(Time.time * speed,tileSize);
		gameObject.transform.position = startPosition + Vector3.up * newPosition;
	}
}
