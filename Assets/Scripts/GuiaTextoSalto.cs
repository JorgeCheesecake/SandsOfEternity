using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuiaTextoSalto : MonoBehaviour
{
    public TextMeshProUGUI texto; 
    public KeyCode teclaParaOcultar = KeyCode.E;
    public float tiempoParaMostrar = 3f;
    public float tiempoParaOcultar = 2f;

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
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(teclaParaOcultar) && texto != null)
        {
            StartCoroutine(OcultarTextoConRetraso());
        }
    }

    IEnumerator OcultarTextoConRetraso()
    {
        yield return new WaitForSeconds(tiempoParaOcultar);
        texto.gameObject.SetActive(false);
    }
}
