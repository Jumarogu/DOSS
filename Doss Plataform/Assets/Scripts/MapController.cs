using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{

    private GameObject planetPanel;
    private Text planetName, planetDescription;

    void Start()
    {
        planetPanel = GameObject.Find("PlanetInfo");

        planetName = GameObject.Find("PlanetInfo").GetComponentInChildren<UnityEngine.UI.Text>();
        planetDescription = GameObject.Find("PlanetDescription").GetComponent<UnityEngine.UI.Text>();
        planetPanel.SetActive(false);
        //planetName.enabled = false;
        //planetDescription.enabled = false;

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
            if (hit.transform.name == "Planeta0" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Numeros 1 - 10";
                planetDescription.text = "Me pelan la verga todos";

            }

            if (hit.transform.name == "Planeta1" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Sistema Monetario";
                planetDescription.text = "Me pelan la verga todos";

            }

            if (hit.transform.name == "Planeta2" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Culichilandia";
                planetDescription.text = "Me pelan la verga todos";

            }

            if (hit.transform.name == "Planeta3" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Pastocas";
                planetDescription.text = "Me pelan la verga todos";

            }

            if (hit.transform.name == "Planeta4" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Sexo Anal";
                planetDescription.text = "Me pelan la verga todos";

            }

            if (hit.transform.name == "Planeta5" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Weed Planet";
                planetDescription.text = "Me pelan la verga todos";

            }

            if (hit.transform.name == "Planeta6" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Numeros 1 - 10";
                planetDescription.text = "Me pelan la verga todos";

            }

            if (hit.transform.name == "Planeta7" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Numeros 1 - 10";
                planetDescription.text = "Me pelan la verga todos";

            }

            if (hit.transform.name == "Planeta8" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Numeros 1 - 10";
                planetDescription.text = "Me pelan la verga todos";

            }

            if (hit.transform.name == "Planeta9" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Numeros 1 - 10";
                planetDescription.text = "Me pelan la verga todos";

            }

            if (hit.transform.name == "Planeta10" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Numeros 1 - 10";
                planetDescription.text = "Me pelan la verga todos";

            }

            if (hit.transform.name == "Planeta11" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Numeros 1 - 10";
                planetDescription.text = "Me pelan la verga todos";

            }

            

        }
    }
}
