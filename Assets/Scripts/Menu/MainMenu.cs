﻿// GameManagerMenu en la escena "Menu".

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void EscenaJuego(){
        SceneManager.LoadScene("Tutorial");
    }

    public void Salir(){
        Application.Quit();
    }
    public void Menu(){
        SceneManager.LoadScene("Menu");
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;    
    }
}
