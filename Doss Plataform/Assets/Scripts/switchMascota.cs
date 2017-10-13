using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class switchMascota : MonoBehaviour {

	public Dropdown Grupo;
	public Sprite leon;
	public Sprite delfin;


	// Use this for initialization
	void Start () {
		Grupo.onValueChanged.AddListener(delegate {
			myDropdownValueChangedHandler(Grupo);
		});
	}

	private void myDropdownValueChangedHandler(Dropdown target) {
		Debug.Log("selected: "+target.value);

		if (target.value==1) {
			gameObject.GetComponent<Image> ().sprite = leon;
			Debug.Log ("Se eligio un Leon");
		}
		if (target.value==0) {
			gameObject.GetComponent<Image> ().sprite = delfin;
			Debug.Log ("Se eligio un Delfin");

		}
	}
}
