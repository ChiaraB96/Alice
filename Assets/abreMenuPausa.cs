using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class abreMenuPausa : MonoBehaviour
{
    public GameObject menuDePausa;
    private bool menuOn = false;
    public GameObject confirmar;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            menuOn = true;
        }
        if(menuOn==true){
            menuDePausa.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }
    
     public void Continuar() 
    {
        menuDePausa.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        menuOn= false;
    }

    public void Salir() 
    {
        confirmar.SetActive(true);
    }

    public void Si() {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }


}
