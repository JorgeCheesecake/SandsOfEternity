using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Asegúrate de que tienes esta directiva de using

public class HoverColor : MonoBehaviour
{
    public Button buttonPlayInicion;  // Nombre de la variable puede estar relacionado con la funcionalidad de este botón
    public Color wantedColor;  // Usamos Color (con C mayúscula)
    private Color originalColor;  // Usamos Color también aquí
    private ColorBlock cb;  // Aquí debería ser ColorBlock (con C mayúscula)

    // Start is called before the first frame update
    void Start()
    {
        cb = buttonPlayInicion.colors;  // Aquí asignamos los colores del botón
        originalColor = cb.selectedColor;  // Obtenemos el color original
    }

    // Update is called once per frame
    void Update()
    {
        // No es necesario hacer nada aquí por ahora
    }

    // Método para cambiar el color cuando se pasa el ratón sobre el botón
    public void changeWhenHover()
    {
        cb.selectedColor = wantedColor;  // Asignamos el color deseado cuando el ratón pasa sobre el botón
        buttonPlayInicion.colors = cb;  // Aplicamos los cambios al botón
    }

    // Método para restaurar el color original cuando el ratón deja el botón
    public void changeWhenLeaves()
    {
        cb.selectedColor = originalColor;  // Restauramos el color original
        buttonPlayInicion.colors = cb;  // Aplicamos los cambios al botón
    }
}

