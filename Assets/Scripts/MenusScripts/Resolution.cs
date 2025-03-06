using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicaFullScreen : MonoBehaviour
{
    public TMP_Dropdown DropDownResolution;
    Resolution[] Resolution;

    void Start()
    {
        RevisarResolucion();
    }

    public void RevisarResolucion()
    {
        Resolution = Screen.resolutions;
        DropDownResolution.ClearOptions();

        List<string> opciones = new List<string>();
        int resolucionActual = 0;

        if (Resolution.Length > 1) 
        {
            for (int i = 0; i < Resolution.Length; i++)
            {
                string opcion = Resolution[i].width + " x " + Resolution[i].height;
                opciones.Add(opcion);

                if (Resolution[i].width == Screen.currentResolution.width &&
                    Resolution[i].height == Screen.currentResolution.height)
                {
                    resolucionActual = i;
                }
            }
        }
        else //SOLO ME DETECTABA UNA RESOLUCION ASIQ AÑADI ESTO
        {
            List<Resolution> resolucionesPersonalizadas = new List<Resolution>
            {
                new Resolution { width = 1280, height = 720 },
                new Resolution { width = 1600, height = 900 },
                new Resolution { width = 1920, height = 1080 },
                new Resolution { width = 2560, height = 1440 },
                new Resolution { width = 3840, height = 2160 }
            };

            for (int i = 0; i < resolucionesPersonalizadas.Count; i++)
            {
                string opcion = resolucionesPersonalizadas[i].width + " x " + resolucionesPersonalizadas[i].height;
                opciones.Add(opcion);

                if (Screen.currentResolution.width == resolucionesPersonalizadas[i].width &&
                    Screen.currentResolution.height == resolucionesPersonalizadas[i].height)
                {
                    resolucionActual = i;
                }
            }
        }

        DropDownResolution.AddOptions(opciones);
        DropDownResolution.value = resolucionActual;
        DropDownResolution.RefreshShownValue();
    }

    public void CambiarResolucion(int indiceResolucion)
    {
        if (Resolution.Length > 1) 
        {
            Resolution resolucion = Resolution[indiceResolucion];
            Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
        }
        else 
        {
            List<Resolution> resolucionesPersonalizadas = new List<Resolution>
            {
                new Resolution { width = 1280, height = 720 },
                new Resolution { width = 1600, height = 900 },
                new Resolution { width = 1920, height = 1080 },
                new Resolution { width = 2560, height = 1440 },
                new Resolution { width = 3840, height = 2160 }
            };

            Resolution resolucion = resolucionesPersonalizadas[indiceResolucion];
            Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
        }
    }
}
