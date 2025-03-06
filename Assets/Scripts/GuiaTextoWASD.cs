using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuiaTextoWASD : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public float tiempoMostrado = 2f;
    public float tiempoParaOcultar = 2f;

    void Start()
    {
        if (texto != null)
        {
            texto.gameObject.SetActive(false);
            Invoke("MostrarTexto", tiempoMostrado);
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
        if (texto != null && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)))
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
