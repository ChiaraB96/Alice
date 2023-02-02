using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour
{
    public GameObject menuSalir;
    private bool menuOn;

    public void Si(){
        Application.Quit();
    }
    
}
