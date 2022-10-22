using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuDePausa;
    private bool menuOn;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            menuOn = !menuOn;
        }
        if(menuOn==true){
            menuDePausa.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        else{
            menuDesactivado();
        }
    }
    public void Continuar(){
        menuDesactivado();
        menuOn = false; 
    }
    public void Salir(){
        Application.Quit();
    }
    private void menuDesactivado(){
        menuDePausa.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
