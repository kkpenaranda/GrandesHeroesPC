using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;

public class DayChanger : MonoBehaviour
{
    public Animator animator;

    private JsonData gameData;

    private string tomoRegaloCarta;

    private void Update()
    {
        GameObject p = GameObject.Find("Personaje");
        if (p.GetComponent<Movimiento>().trigger)
        {
            //print("entra a transicion");
            animator.SetTrigger("fade");
        }
        else
        {
            animator.SetTrigger("returnn");
        }
    }


    public void onFadeComplete()
    {
        gameData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Gamedata.json")); ;
        tomoRegaloCarta = "" + gameData[4];
        GameObject p = GameObject.Find("Personaje");
        p.GetComponent<Movimiento>().animator.SetTrigger("despierta");
        p.GetComponent<Movimiento>().panelOpcionesCama.SetActive(false);

        GameObject fondo = GameObject.Find("Background");
        GameObject camara = GameObject.Find("Main Camera");


        fondo.GetComponent<TimeDayFunction>().dia = fondo.GetComponent<TimeDayFunction>().dia + 1;
        fondo.GetComponent<TimeDayFunction>().red = 1.0f;
        fondo.GetComponent<TimeDayFunction>().green = 1.0f;
        fondo.GetComponent<TimeDayFunction>().blue = 1.0f;
        fondo.GetComponent<TimeDayFunction>().inicio = 0.0f;
        fondo.GetComponent<TimeDayFunction>().hora = 6;
        fondo.GetComponent<TimeDayFunction>().segundoActual = 0.0;
        fondo.GetComponent<TimeDayFunction>().ultimoSegundo = 0.0;
        //print("se aumento el dia");

        camara.GetComponent<JSONWriter>().reescribirJSON(fondo.GetComponent<TimeDayFunction>().dia,
         new int[] { int.Parse(camara.GetComponent<JSONLoaderJuego0>().cantidadAlimento1.text),
         int.Parse(camara.GetComponent<JSONLoaderJuego0>().cantidadAlimento2.text),
         int.Parse(camara.GetComponent<JSONLoaderJuego0>().cantidadAlimento3.text),
         int.Parse(camara.GetComponent<JSONLoaderJuego0>().cantidadAlimento4.text),
         int.Parse(camara.GetComponent<JSONLoaderJuego0>().cantidadAlimento5.text),
         int.Parse(camara.GetComponent<JSONLoaderJuego0>().cantidadAlimento6.text),
         int.Parse(camara.GetComponent<JSONLoaderJuego0>().cantidadAlimento7.text),
         int.Parse(camara.GetComponent<JSONLoaderJuego0>().cantidadAlimento8.text) },
         (int)camara.GetComponent<EnergyBar>().Energy,
         fondo.GetComponent<TimeDayFunction>().hora,
         tomoRegaloCarta,
         fondo.GetComponent<TimeDayFunction>().inicio,
         fondo.GetComponent<TimeDayFunction>().ultimoSegundo,
         fondo.GetComponent<TimeDayFunction>().segundoActual,
         new string[] { "Arroz", "Huevos", "Agua", "Arroz con leche", "Chocolate", "Dulces", "Granos", "Pan" });

         GameObject aS = GameObject.Find("AudioObject");
         aS.GetComponent<AudioScript>().verificarAudioDia(fondo.GetComponent<TimeDayFunction>().dia);
    }

    public void pasarEstado()
    {
        GameObject p = GameObject.Find("Personaje");
        p.GetComponent<Movimiento>().trigger = false;
        p.GetComponent<Movimiento>().permiteMoverse = true;
    }
}