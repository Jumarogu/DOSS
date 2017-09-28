using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Planeta")
            {
                Debug.Log("This is Planet " + hit.transform.name);
            }
        
        }
    }
}
