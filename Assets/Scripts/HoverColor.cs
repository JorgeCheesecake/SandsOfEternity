using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Aseg�rate de que tienes esta directiva de using

public class HoverColor : MonoBehaviour
{
    public Button buttonPlayInicion;  // Nombre de la variable puede estar relacionado con la funcionalidad de este bot�n
    public Color wantedColor;  // Usamos Color (con C may�scula)
    private Color originalColor;  // Usamos Color tambi�n aqu�
    private ColorBlock cb;  // Aqu� deber�a ser ColorBlock (con C may�scula)

    // Start is called before the first frame update
    void Start()
    {
        cb = buttonPlayInicion.colors;  // Aqu� asignamos los colores del bot�n
        originalColor = cb.selectedColor;  // Obtenemos el color original
    }

    // Update is called once per frame 
    void Update()
    {
        // No es necesario hacer nada aqu� por ahora
    }

    // M�todo para cambiar el color cuando se pasa el rat�n sobre el bot�n
    public void changeWhenHover()
    {
        cb.selectedColor = wantedColor;  // Asignamos el color deseado cuando el rat�n pasa sobre el bot�n
        buttonPlayInicion.colors = cb;  // Aplicamos los cambios al bot�n
    }

    // M�todo para restaurar el color original cuando el rat�n deja el bot�n
    public void changeWhenLeaves()
    {
        cb.selectedColor = originalColor;  // Restauramos el color original
        buttonPlayInicion.colors = cb;  // Aplicamos los cambios al bot�n
    }
}

