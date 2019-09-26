using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;
using System.Collections;

public class Teleport : MonoBehaviour
{
    [SerializeField] private string levelToLoad;
    //public LoadSceneTransition ls;
    private JsonData gameData;

    private string tomoRegaloCarta;

    private SceneController sceneController;

    private JSONLoaderJuego0 jsonLoader;


    void Awake()
    {
        jsonLoader = GameObject.FindObjectOfType<JSONLoaderJuego0>();
    }

    void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
        if (File.Exists(Application.dataPath + "/Gamedata.json"))
        {
            gameData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Gamedata.json"));
            tomoRegaloCarta = ""+gameData[4];
        }
    }

    public void OnTriggerEnter2D(Collider2D cTrigger)
    { 
        gameData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Gamedata.json")); ;
        tomoRegaloCarta = "" + gameData[4];
        GameObject camara = GameObject.Find("Main Camera");
        GameObject fondo = GameObject.Find("Background");  
        camara.GetComponent<JSONWriter>().reescribirJSON(fondo.GetComponent<TimeDayFunction>().dia, new int[] { int.Parse(camara.GetComponent<JSONLoaderJuego0>().cantidadAlimento1.text), int.Parse(camara.GetComponent<JSONLoaderJuego0>().cantidadAlimento2.text), int.Parse(camara.GetComponent<JSONLoaderJuego0>().cantidadAlimento3.text), int.Parse(camara.GetComponent<JSONLoaderJuego0>().cantidadAlimento4.text), int.Parse(camara.GetComponent<JSONLoaderJuego0>().cantidadAlimento5.text), int.Parse(camara.GetComponent<JSONLoaderJuego0>().cantidadAlimento6.text), int.Parse(camara.GetComponent<JSONLoaderJuego0>().cantidadAlimento7.text), int.Parse(camara.GetComponent<JSONLoaderJuego0>().cantidadAlimento8.text) }, (int)camara.GetComponent<EnergyBar>().Energy, fondo.GetComponent<TimeDayFunction>().hora, tomoRegaloCarta, fondo.GetComponent<TimeDayFunction>().inicio, fondo.GetComponent<TimeDayFunction>().ultimoSegundo, fondo.GetComponent<TimeDayFunction>().segundoActual, new string[] { "Arroz", "Huevos", "Agua", "Arroz con leche", "Chocolate", "Dulces", "Granos", "Pan de centeno" });

        if (cTrigger.tag != "Player") { return; }

        if(fondo.GetComponent<TimeDayFunction>().dia == 4 && ((levelToLoad.Equals("Sala") && SceneManager.GetActiveScene().name.Equals("Calle")) || levelToLoad.Equals("Colegio")  || levelToLoad.Equals("Coorporacion")))
        {
            SceneManager.LoadScene("Fin");
        }         
        else{
            if (fondo.GetComponent<TimeDayFunction>().hora >17 && levelToLoad.Equals("Colegio"))
            {
                jsonLoader.darInformacion("El colegio se encuentra cerrado.");
            }
            else {
                sceneController.LoadScene(levelToLoad);
            }
            
        }
    }

}