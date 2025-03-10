using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeControl: MonoBehaviour // Nuevo nombre
{
    public void ChangeToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
