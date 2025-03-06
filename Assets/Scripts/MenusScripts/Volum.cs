using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volum : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;

    
    void Start()
    {
        sliderValue = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = sliderValue; 
        RevisarSiEstoyMute();
    }

    public void RevisarSiEstoyMute()
    {
        if (sliderValue == 0) 
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        AudioListener.volume = sliderValue;
        RevisarSiEstoyMute();
    }

    
    void Update()
    {
        
    }
}
