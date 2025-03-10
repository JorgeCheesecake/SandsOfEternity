using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysCursor : MonoBehaviour
{
    // Start es llamado antes del primer frame de actualización
    void Start()
    {
        // Configura el cursor para que siempre esté visible
        Cursor.visible = true;
        // Configura el cursor para que no se esconda cuando se mueve sobre un objeto
        Cursor.lockState = CursorLockMode.None;
    }

    // Update es llamado una vez por frame
    void Update()
    {
        // Configura el cursor para que siempre esté visible
        Cursor.visible = true;
        // Configura el cursor para que no se esconda cuando se mueve sobre un objeto
        Cursor.lockState = CursorLockMode.None;    }
}