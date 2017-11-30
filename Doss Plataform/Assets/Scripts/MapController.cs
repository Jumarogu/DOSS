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
    public Sprite [] LeonSprites;
    public Sprite [] DolphinSprites;
    private Image mascota;
    public Button jugar,regresar,tienda;
    private Vector3 [] cameraPosition;
    public GameObject [] candados;
    private string selectedPlanetName;
    
    void Start(){
        planetPanel = GameObject.Find("PlanetInfo");        

        planetName = GameObject.Find("PlanetInfo").GetComponentInChildren<UnityEngine.UI.Text>();
        planetDescription = GameObject.Find("PlanetDescription").GetComponent<UnityEngine.UI.Text>();
        playerName = GameObject.Find("NamePanel").GetComponentInChildren<UnityEngine.UI.Text>();
        planetPanel.SetActive(false);
        
        regresar.onClick.AddListener(regresarCamara);
        jugar.onClick.AddListener(entrarJuego);
        tienda.onClick.AddListener(irATienda);
        
        cameraPosition = new Vector3 [12];
        cameraPosition[0] = new Vector3(14.5f,-7.5f,-44.5f);
        cameraPosition[1] = new Vector3(16f,62.5f,-20f);
        cameraPosition[2] = new Vector3(75f,35f,-20f);
        cameraPosition[3] = new Vector3(140f,72f,-36f);
        cameraPosition[4] = new Vector3(88f,-46f,-35f);
        cameraPosition[5] = new Vector3(150f,-103f,-17f);
        cameraPosition[6] = new Vector3(-41f,-68f,-17f);
        cameraPosition[7] = new Vector3(20f,-98f,-27f);
        cameraPosition[8] = new Vector3(-105f,-70f,-40f);
        //cameraPosition[9] = new Vector3(,,);
        //cameraPosition[10] = new Vector3(,,);
        cameraPosition[11] = transform.position;

        cookie = GameObject.Find("Cookies");
        Dictionary<string,string> cook = cookie.GetComponent<sesion>().getcookie();
        playerName.text = cook["nombres"] + " " + cook["apellidos"];
        mascota = GameObject.Find("Mascota").GetComponent<Image>();
        
        //Poner la mascota
        if(cook["grupo"] == "A"){
            //mascota.sprite = Dolphin;
            string icono = cook["icono"];
            switch (icono)
            {
                case("1"):
                    mascota.sprite = DolphinSprites[1];
                break;

                case("2"):
                    mascota.sprite = DolphinSprites[2];
                break;

                case("3"):
                    mascota.sprite = DolphinSprites[3];
                break;

                default:
                    mascota.sprite = DolphinSprites[0];
                break;
            }
        }
        if(cook["grupo"] == "b"){
            //mascota.sprite = Leon;
        }

        
    }

    void entrarJuego(){
        
        switch (selectedPlanetName)
        {
            case ("Planeta0"):
                SceneManager.LoadScene("Nivel0");
                break;
            case ("Planeta1"):
                SceneManager.LoadScene("Nivel1");
                break;
            case ("Planeta2"):
                SceneManager.LoadScene("Nivel2");
                break;
            case ("Planeta3"):
                SceneManager.LoadScene("Nivel2Dificil");
                break;
            case ("Planeta4"):
                SceneManager.LoadScene("Nivel3");
                break;
            case ("Planeta5"):
                SceneManager.LoadScene("Nivel3Dificil");
                break;
            case ("Planeta6"):
                SceneManager.LoadScene("Nivel4");
                break;
        }
    }

    void regresarCamara(){
        this.transform.position = cameraPosition[11];
        planetPanel.SetActive(false);
    }

    void irATienda(){
        SceneManager.LoadScene("tienda");
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
                planetDescription.text = "Cuenta las naves y elige el numero correcto para ganar. ";
                this.transform.position = cameraPosition[0];  
                this.selectedPlanetName = hit.transform.name;              
            }

            if (hit.transform.name == "Planeta1" && Input.GetMouseButtonDown(0))
            {
                if(!candados[0].active){
                    planetPanel.SetActive(true);
                    planetName.text = "Numeracion con letra";
                    planetDescription.text = "Escribe en letra el numero.";
                    this.transform.position = cameraPosition[1];    
                    this.selectedPlanetName = hit.transform.name;   
                }
            }

            if (hit.transform.name == "Planeta2" && Input.GetMouseButtonDown(0))
            {
                if(!candados[1].active){
                    planetPanel.SetActive(true);
                    planetName.text = "Sumitas";
                    planetDescription.text = "Ejercicios de sumas basicas.";
                    this.transform.position = cameraPosition[2];
                    this.selectedPlanetName = hit.transform.name;
                }
            }

            if (hit.transform.name == "Planeta3" && Input.GetMouseButtonDown(0))
            {
                if(!candados[2].active){
                    planetPanel.SetActive(true);
                     planetName.text = "Sumotas";
                    planetDescription.text = "Ejercicios de sumas un poco mas complicadas. ";
                    this.transform.position = cameraPosition[3];
                    this.selectedPlanetName = hit.transform.name;
                }
            }

            if (hit.transform.name == "Planeta4" && Input.GetMouseButtonDown(0))
            {
                if(!candados[3].active){
                    planetPanel.SetActive(true);
                    planetName.text = "Restitas";
                    planetDescription.text = "Ejercicios de restas sencillos.";
                    this.transform.position = cameraPosition[4];
                    this.selectedPlanetName = hit.transform.name;
                }
            }

            if (hit.transform.name == "Planeta5" && Input.GetMouseButtonDown(0))
            {
                if(!candados[4].active){
                    planetPanel.SetActive(true);
                    planetName.text = "Restotas";
                    planetDescription.text = "Ejercicios de restas mas grandotas. ";
                    this.transform.position = cameraPosition[5];
                    this.selectedPlanetName = hit.transform.name;
                }
            }

            if (hit.transform.name == "Planeta6" && Input.GetMouseButtonDown(0))
            {
                if(!candados[5].active){
                    planetPanel.SetActive(true);
                    planetName.text = "Sumas y Restas";
                    planetDescription.text = "Cuenta cuantas naves salen y regresan al planeta.";
                    this.transform.position = cameraPosition[6];
                    this.selectedPlanetName = hit.transform.name;
                }
            }

            if (hit.transform.name == "Planeta7" && Input.GetMouseButtonDown(0))
            {
                if(!candados[6].active){
                    planetPanel.SetActive(true);
                    planetName.text = "En Construcción ";
                    planetDescription.text = " Seguimos trabajando para ustedes.";
                    this.transform.position = cameraPosition[7];
                    this.selectedPlanetName = hit.transform.name;
                }
            }

            if (hit.transform.name == "Planeta8" && Input.GetMouseButtonDown(0))
            {
                if(!candados[7].active){
                    planetPanel.SetActive(true);
                    planetName.text = "Sumas y restas. ";
                    planetDescription.text = "Combinacion de sumas y restas";
                    this.transform.position = cameraPosition[8];
                    this.selectedPlanetName = hit.transform.name;
                }
            }

            if (hit.transform.name == "Planeta9" && Input.GetMouseButtonDown(0))
            {
                if(!candados[8].active){
                    planetPanel.SetActive(true);
                    planetName.text = "No se ";
                    planetDescription.text = "";
                    this.selectedPlanetName= hit.transform.name;
                }
            }

            if (hit.transform.name == "Planeta10" && Input.GetMouseButtonDown(0))
            {
                if(!candados[9].active){
                    planetPanel.SetActive(true);
                    planetName.text = "Npi";
                    planetDescription.text = "";
                    this.selectedPlanetName = hit.transform.name;
                }
            }

            if (hit.transform.name == "Planeta11" && Input.GetMouseButtonDown(0))
            {
                if(!candados[10].active){
                    planetPanel.SetActive(true);
                    planetName.text = "I'm lost";
                    planetDescription.text = "";
                    this.selectedPlanetName = hit.transform.name;
                }

            }
            // Pendientes, desaparecer el menu                 

        }
    }
}
