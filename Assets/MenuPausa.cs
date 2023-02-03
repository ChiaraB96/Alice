using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuDePausa;
    public GameObject confirmar;

    // Update is called once per frame

    public void Continuar () 
    {
       menuDePausa.SetActive(false);
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void Salir() 
    {
        confirmar.SetActive(true);
    }

   
}
