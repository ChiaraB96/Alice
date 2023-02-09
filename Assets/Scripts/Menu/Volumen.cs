using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    public Slider slider;
    private float sliderValor;

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
