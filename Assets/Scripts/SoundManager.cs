using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip dormir, abrirAlgo, cocinar, 
    comer, campanaColegio, vocesColegio, hablarGente, patearBalon, hablaPlayer, hablaNina, hablaCalvo, hablaMama, wow;
    static AudioSource audioSource; 
    void Start()
    {
        dormir = Resources.Load<AudioClip>("audios/dormir");
        abrirAlgo = Resources.Load<AudioClip>("audios/abrir");
        cocinar = Resources.Load<AudioClip>("audios/cocinando");
        comer = Resources.Load<AudioClip>("audios/comerCorto");
        campanaColegio = Resources.Load<AudioClip>("audios/campColegio");
        vocesColegio = Resources.Load<AudioClip>("audios/ninosEscuela");
        hablarGente = Resources.Load<AudioClip>("audios/genteHabla");
        patearBalon = Resources.Load<AudioClip>("audios/patearBalon");
        hablaPlayer = Resources.Load<AudioClip>("audios/habla2");
        hablaNina = Resources.Load<AudioClip>("audios/risaNina");
        hablaCalvo = Resources.Load<AudioClip>("audios/heyHombre");
        hablaMama = Resources.Load<AudioClip>("audios/mom");
        wow = Resources.Load<AudioClip>("audios/wow");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip){
        audioSource.volume = 0.5f;
        switch(clip){
        case "dormir":
            audioSource.PlayOneShot(dormir);
            break;
        case "abrirAlgo":
            audioSource.PlayOneShot(abrirAlgo);
            break;   
        case "cocinar":
            audioSource.PlayOneShot(cocinar);
            break;
        case "comer":
            audioSource.PlayOneShot(comer);
            break;
        case "campanaColegio":
            audioSource.PlayOneShot(campanaColegio);
            break;
        case "vocesColegio":
            audioSource.PlayOneShot(vocesColegio);
            break;
        case "hablarGente":
            audioSource.PlayOneShot(hablarGente);
            break;
        case "patearBalon":
            audioSource.volume = 0.2f;
            audioSource.PlayOneShot(patearBalon);
            break; 
        case "hablaNina":
            audioSource.PlayOneShot(hablaNina);
            break; 
        case "hablaCalvo":
            audioSource.PlayOneShot(hablaCalvo);
            break; 
        case "hablaPlayer":
            audioSource.volume = 0.4f;
            audioSource.PlayOneShot(hablaPlayer);
            break; 
        case "hablaMama":
            audioSource.PlayOneShot(hablaMama);
            break; 
        case "wow":
            audioSource.PlayOneShot(wow);
            break; 
        }
        
    }
}
