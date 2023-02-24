/* EventSystemMenu dentro del personaje.

    abre el menú al presionar escape o la tecla p 
    abre el menú de confirmación
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class abreMenuPausa : MonoBehaviour
{
    public GameObject menuDePausa; // menú de pausa
    private bool menuOn = false;
    public GameObject confirmar; // menú de confirmación

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("p")){
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
        Application.Quit();
    }


}
