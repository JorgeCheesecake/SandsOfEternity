using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuiaTextoCamara : MonoBehaviour
{
    public TextMeshProUGUI texto; 
    public float tiempoParaMostrar = 3f; 
    private bool textoMostrado = false; 
    public float tiempoParaocultar = 2f;
    private Coroutine ocultarCoroutine;

    void Start()
    {
        if (texto != null)
        {
            texto.gameObject.SetActive(false); 
            Invoke("MostrarTexto", tiempoParaMostrar); 
        }
    }

    void MostrarTexto()
    {
        if (texto != null)
        {
            texto.gameObject.SetActive(true); 
            textoMostrado = true;
        }
    }

    void Update()
    {
        if (textoMostrado && texto != null)
        {
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                if (ocultarCoroutine != null)
                {
                    StopCoroutine(ocultarCoroutine);
                }
                ocultarCoroutine = StartCoroutine(OcultarTextoConRetraso());
            }
        }
    }

    IEnumerator OcultarTextoConRetraso()
    {
        yield return new WaitForSeconds(tiempoParaocultar);
        texto.gameObject.SetActive(false);
        textoMostrado = false;
    }
}
