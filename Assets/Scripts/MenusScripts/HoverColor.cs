using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverColor : MonoBehaviour
{
    public Button buttonPlayInicion;
    public Color wantedColor;
    private Color originalColor;
    private ColorBlock cb;

    void Start()
    {
        cb = buttonPlayInicion.colors;
        originalColor = cb.selectedColor;
    }

    void Update()
    {
    }

    public void changeWhenHover()
    {
        cb.selectedColor = wantedColor;
        buttonPlayInicion.colors = cb;
    }

    public void changeWhenLeaves()
    {
        cb.selectedColor = originalColor;
        buttonPlayInicion.colors = cb;
    }
}

