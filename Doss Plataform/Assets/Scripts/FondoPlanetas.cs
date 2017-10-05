using UnityEngine;
using System.Collections;

public class FondoPlanetas : MonoBehaviour
{

    private float speed, tileSize;

    private Vector3 startPosition;
    void Start()
    {
        startPosition = gameObject.transform.position;
        tileSize = 400f;
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * speed, tileSize);
        gameObject.transform.position = startPosition + Vector3.up * newPosition;
    }
}
