using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Desactivar el objeto al inicio
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si se pulsa la tecla "E"
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Activar el objeto
            gameObject.SetActive(true);
        }
    }
}