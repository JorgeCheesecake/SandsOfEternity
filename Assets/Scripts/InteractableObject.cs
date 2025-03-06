using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena



public class InteractableObject : MonoBehaviour
{
    public string sceneToLoad = "Continuara"; // Nombre de la escena que deseas cargar
    public float interactionDistance = 3f;  // Distancia m�xima para interactuar
    private bool isPlayerInRange = false;   // Para saber si el jugador est� cerca

    private void Update()
    {
        // Si el jugador est� cerca y presiona "E", se realiza la interacci�n
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {
        // Cambiar de escena
        Debug.Log("Interaccion con: " + gameObject.name);
        SceneManager.LoadScene(sceneToLoad);  // Carga la escena especificada
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el jugador entra en el �rea de interacci�n, activamos el rango
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del �rea de interacci�n, desactivamos el rango
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

}
