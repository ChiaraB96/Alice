using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void EscenaJuego(){
        SceneManager.LoadScene("Tutorial");
    }

    public void Salir(){
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void Menu(){
        SceneManager.LoadScene("Menu");
    }
}
