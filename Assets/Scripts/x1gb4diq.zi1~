using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public static string prevScene = "";
    public static string currentScene = "";

    public virtual void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void LoadScene(string sceneName)
    {
        prevScene = currentScene;
        SceneManager.LoadScene(sceneName);
    }

}