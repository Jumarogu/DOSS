using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Nodo : MonoBehaviour {

	public Nodo[] vecinos;
	public List<Nodo> history;

	public float g,h ;

	public float F {
		get{
			return g + h;
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere (transform.position,15);

		Gizmos.color = Color.white;
		for (int i = 0; i < vecinos.Length; i++) {
			Gizmos.DrawLine (transform.position, vecinos [i].transform.position);

		}

	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position,15);
	}
}
