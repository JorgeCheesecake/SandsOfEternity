using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaEnemigo : MonoBehaviour
{
    public int vida = 100;
    public Slider BarraVida;
    private bool colisionDetectada = false;

    // Update is called once per frame
    void Update()
    {
        BarraVida.value = vida;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("espada") && !colisionDetectada)
        {
            colisionDetectada = true;
            vida -= 10;
            if (vida < 0) vida = 0; // Evita que el valor de vida sea negativo
            Invoke("RestablecerColision", 1f); // Restablece la colisión después de 2 segundos
        }
    }

    void RestablecerColision()
    {
        colisionDetectada = false;
    }
}