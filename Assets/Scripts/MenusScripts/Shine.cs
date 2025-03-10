using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shine : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image panelBrillo;

    void Start()
    {
        sliderValue = Mathf.Clamp(PlayerPrefs.GetFloat("brillo", 0.7f), 0.2f, 0.8f);
        slider.value = sliderValue;
        UpdateBrightness();
    }

    void Update()
    {
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = Mathf.Clamp(valor, 0.2f, 0.8f);
        slider.value = sliderValue;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        PlayerPrefs.Save();
        UpdateBrightness();
    }

    private void UpdateBrightness()
    {
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, sliderValue);
    }
}
