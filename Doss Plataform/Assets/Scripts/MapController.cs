using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MapController : MonoBehaviour
{

    private GameObject planetPanel;
    private Text planetName, planetDescription,playerName;
    public GameObject cookie;
    public Sprite Lion;
    public Sprite Dolphin;
    private Image mascota;

    public Button jugar;
    void Start()
    {
        planetPanel = GameObject.Find("PlanetInfo");        

        planetName = GameObject.Find("PlanetInfo").GetComponentInChildren<UnityEngine.UI.Text>();
        planetDescription = GameObject.Find("PlanetDescription").GetComponent<UnityEngine.UI.Text>();
        playerName = GameObject.Find("NamePanel").GetComponentInChildren<UnityEngine.UI.Text>();
        planetPanel.SetActive(false);
        //planetName.enabled = false;
        //planetDescription.enabled = false;
        cookie = GameObject.Find("Cookies");
        Dictionary<string,string> cook = cookie.GetComponent<sesion>().getcookie();
        Debug.Log("Imprimiendo desde cookies = "+ cook["apellidos"]);
        playerName.text = cook["nombres"] + " " + cook["apellidos"];

        mascota = GameObject.Find("Mascota").GetComponent<Image>();

        //Poner la mascota
        if(cook["grupo"] == "A"){
            mascota.sprite = Dolphin;
        }
        if(cook["grupo"] == "b"){
            mascota.sprite = Lion;
        }
        

        jugar.onClick.AddListener(entrarJuego);
    }

    void entrarJuego(){
        SceneManager.LoadScene("Nivel0");
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        //Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name == "Planeta0" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Numeros 1 - 10";
                planetDescription.text = "Cuenta las naves y elige en numero correcto para ganar. ";

            }

            if (hit.transform.name == "Planeta1" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Numeracion con letra";
                planetDescription.text = "Escribe en letra el numero.";

            }

            if (hit.transform.name == "Planeta2" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Sumas";
                planetDescription.text = "Ejercicios de sumas basicas.";

            }

            if (hit.transform.name == "Planeta3" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Sumas 2";
                planetDescription.text = "Ejercicios de sumas un poco mas complicadas. ";

            }

            if (hit.transform.name == "Planeta4" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Restitas";
                planetDescription.text = "Ejercicios de restas sencillos.";

            }

            if (hit.transform.name == "Planeta5" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Restotas";
                planetDescription.text = "Ejercicios de restas mas grandotas. ";

            }

            if (hit.transform.name == "Planeta6" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Sumas Verticales";
                planetDescription.text = "Cambio de sumas horizontales a verticales. ";

            }

            if (hit.transform.name == "Planeta7" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Restas Verticales ";
                planetDescription.text = "Cambio de restas horizontales a verticales. ";

            }

            if (hit.transform.name == "Planeta8" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Sumas y restas. ";
                planetDescription.text = "Combinacion de sumas y restas";

            }

            if (hit.transform.name == "Planeta9" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "No se ";
                planetDescription.text = "";

            }

            if (hit.transform.name == "Planeta10" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "Npi";
                planetDescription.text = "";

            }

            if (hit.transform.name == "Planeta11" && Input.GetMouseButtonDown(0))
            {
                planetPanel.SetActive(true);
                planetName.text = "I'm lost";
                planetDescription.text = "";

            }
            // Pendientes, desaparecer el menu                 

        }
    }
}
