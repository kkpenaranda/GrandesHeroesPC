using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PanelInicio : MonoBehaviour
{
    public GameObject panelIF;
    public Image imagenLider;
    public TextMeshProUGUI  infoLider;

    void Start()
    {
        infoLider.text = "";
        StartCoroutine(quitImage());
    }

     IEnumerator quitImage()
    { 
        yield return new WaitForSeconds(4.5f);
        imagenLider.sprite = null;
        infoLider.text = "Kevin Julian Leon";
        yield return new WaitForSeconds(5);
        SceneManager.LoadSceneAsync("Cuarto");
    }
}
