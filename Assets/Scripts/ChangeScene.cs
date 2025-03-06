using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas

public class ChangeScene : MonoBehaviour
{
    // Campo p�blico para que puedas ingresar el nombre de la escena en el Inspector
    public string sceneName;

    // Este m�todo cambiar� a la escena que se haya especificado en el campo 'sceneName'
    public void ChangeToScene() 
    {
        // Cambiar a la escena especificada
        SceneManager.LoadScene(sceneName); 
    }
}
