// GameManagerMenu en la escena "Menu". y EscenaFinal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void CambiaEscena(string name){
        SceneManager.LoadScene(name);
    }

    public void Salir(){
        Application.Quit();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;    
    }
}
