using UnityEngine;
using UnityEngine.UI;

public class SliderMirarCamara : MonoBehaviour
{
    public Camera camara; // La cámara hacia la que el slider debe mirar

    private void LateUpdate()
    {
        // Calcula la dirección desde el slider hacia la cámara
        Vector3 direccion = camara.transform.position - transform.position;

        // Normaliza la dirección
        direccion = direccion.normalized;

        // Establece la rotación del slider para que mire hacia la cámara
        transform.rotation = Quaternion.LookRotation(direccion, Vector3.up);
    }
}