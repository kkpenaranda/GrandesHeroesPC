using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PanelFin : MonoBehaviour
{
    public GameObject panelIF;
    public Image imagenLider;
    public Image lideresCaidos;
    public Image i1;
    public Image i2;

    public TextMeshProUGUI  infoLider;
    public TextMeshProUGUI  creditos;
    public TextMeshProUGUI  mem;

    public AudioClip disparos;
    public AudioClip vacio;
    public AudioSource MusicSource;

    void Start()
    {
        i1.enabled = false;
        i2.enabled = false;
        lideresCaidos.enabled = false;
        StartCoroutine(playDisparos());
        infoLider.text = "";
        creditos.text = "";
        mem.text = "";
        StartCoroutine(quitImage());
    }

        IEnumerator playDisparos(){
            yield return new WaitForSeconds(2);
            MusicSource.clip = disparos;
            MusicSource.volume = 0.1f;
            MusicSource.Play();	
        }

     IEnumerator quitImage()
    { 
        yield return new WaitForSeconds(4);
        imagenLider.color = Color.white;
        MusicSource.volume = 0.7f;
        MusicSource.clip = vacio;
        MusicSource.Play();	
        yield return new WaitForSeconds(5);
        imagenLider.color = Color.black;
        infoLider.text = "Kevin Julian León \n Promotor de paz \n 2002-2018";
        yield return new WaitForSeconds(5);
        infoLider.text = "";
        creditos.text = "Créditos: \n \n Historia original:  PACIFISTA.TV \n Adaptación al videojuego:  Vivian Gómez, Kelly Peñaranda \n Ilustración de postal:   http://postalesparalamemoria.com/ \n Sonidos: freesound.org"; 
        yield return new WaitForSeconds(5);
        lideresCaidos.enabled = true;
        i1.enabled = true;
        i2.enabled = true;
        infoLider.text = "";
        creditos.text = "";
        mem.text = " \n  \n  \n \n  \n En memoria de todos los líderes sociales caídos";
    }
}
