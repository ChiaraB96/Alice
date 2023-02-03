using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abreMenuPausa : MonoBehaviour
{
    public GameObject menuDePausa;
    private bool menuOn = false;
    public GameObject confirmar;

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
            if(menuDePausa.activeSelf) {
                DesactivarMenu();
            }
        }
    }
    
     public void Continuar() 
    {
       DesactivarMenu();
    }

    public void Salir() 
    {
        confirmar.SetActive(true);
    }

    private void DesactivarMenu(){
        menuDePausa.SetActive(false);
       Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
