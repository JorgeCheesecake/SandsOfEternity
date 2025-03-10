using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
    {

    public GameObject pausa;
    public GameObject alertaSalir; 
    public GameObject panelOpciones;
    public GameObject panelOpciones2;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isActive = !pausa.activeSelf;
            pausa.SetActive(isActive);
            ControllerCamara.LockCursor(!isActive);
        }
    }

    public void RestartGame() 
    {
        pausa.SetActive(false);
        ControllerCamara.LockCursor(true);
        Time.timeScale = 1; 
    }

    public void MuestrameAlert() 
    {
        alertaSalir.SetActive(true);
    }

    public void CerrarAlerta() 
    {
        alertaSalir.SetActive(false);
    }

    public void MostrarOpciones()
    {
    pausa.SetActive(false); 
    panelOpciones.SetActive(true);
    }

    public void VolverDeOpciones()
    {
    panelOpciones.SetActive(false);
    pausa.SetActive(true);          
    }

    public void MostrarOpciones2()
    {
    pausa.SetActive(false); 
    panelOpciones2.SetActive(true);
    }

    public void VolverDeOpciones2()
    {
    panelOpciones2.SetActive(false);
    pausa.SetActive(true);          
    }





}