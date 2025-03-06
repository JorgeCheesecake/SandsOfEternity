using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena



public class InteractableObject : MonoBehaviour
{
    public string sceneToLoad = "Continuara"; // Nombre de la escena que deseas cargar
    public float interactionDistance = 3f;  // Distancia máxima para interactuar
    private bool isPlayerInRange = false;   // Para saber si el jugador está cerca

    private void Update()
    {
        // Si el jugador está cerca y presiona "E", se realiza la interacción
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
        // Si el jugador entra en el área de interacción, activamos el rango
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del área de interacción, desactivamos el rango
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

}
