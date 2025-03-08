using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaEnemigo : MonoBehaviour
{
    public int vida = 100;
    public Slider BarraVida;

    // Update is called once per frame
    void Update()
    {
        BarraVida.value = vida;
    }
}
