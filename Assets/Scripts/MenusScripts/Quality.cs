using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//NO TOCAR FUNCIONA 

public class Quality : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int quality;

   
    private string[] qualityNames = { "Baja", "Medio", "Alto" };

    void Start()
    {

        quality = PlayerPrefs.GetInt("numeroDeQuality", 1);
        quality = Mathf.Clamp(quality, 0, 2);

   
        dropdown.value = quality;

   
        dropdown.onValueChanged.AddListener(delegate { AjustarQuality(); });

        
        AjustarQuality();
    }
//NO TOCAR FUNCIONA 
    public void AjustarQuality()
    {
        int nivelCalidad = Mathf.Clamp(dropdown.value, 0, 2); 
        QualitySettings.SetQualityLevel(nivelCalidad, true); 
        PlayerPrefs.SetInt("numeroDeQuality", nivelCalidad); 
        quality = nivelCalidad;

        Debug.Log("Calidad cambiada a: " + qualityNames[nivelCalidad]);
    }
}


