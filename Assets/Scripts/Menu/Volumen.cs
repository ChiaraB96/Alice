/* EventSystemMenu dentro del personaje o GameManagerMenu en la escena "MenuPrincipal".

    sube y baja el volumen del juego
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    public Slider slider; // barra de volumen
    private float sliderValor;//valor del volumen

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
    }

    public void ModificarVolumen(float valor)
    {
        sliderValor = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValor);
        AudioListener.volume = slider.value;
    }
}
