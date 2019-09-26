using LitJson;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioScript : MonoBehaviour
{

    // audio clip
    public AudioClip MusicClip;
    public AudioClip MusicFinalOut;
    public AudioClip MusicFinalIns;


    // the component that Unity uses to play the clip
    public AudioSource MusicSource;

    //private Movimiento movimiento;
    public JsonData jsonData;
    public int diaActual;

    public GameObject rain;
    
    void Start () {
        if(rain!=null){
            rain.SetActive(false);
        }

        if (File.Exists(Application.dataPath + "/Gamedata.json"))
        {
            jsonData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Gamedata.json"));
            diaActual = (int)jsonData[0];
        }

        verificarAudioDia(diaActual);           
	}

    public void verificarAudioDia(int dia){
        print(dia);
        if(dia!=4){
            
            MusicSource.clip = MusicClip;
            MusicSource.Play();	
        }
        else
        {
            if(SceneManager.GetActiveScene().name.Equals("Calle")){
                MusicSource.clip = MusicFinalOut;
                rain.SetActive(true);
                GameObject bg = GameObject.Find("Background");
                bg.GetComponent<TimeDayFunction>().oscurecer();
            }
            else if(SceneManager.GetActiveScene().name.Equals("Cuarto") || SceneManager.GetActiveScene().name.Equals("Cocina") || SceneManager.GetActiveScene().name.Equals("Sala")){
                MusicSource.clip = MusicFinalIns;
            }
            MusicSource.volume = 1;
            MusicSource.Play();	
        }  
            
    }

	

    
}
