/* Personaje -> MainCamera -> Holder -> Lazo  

    si el lazo entra en el trigger de un objeto con el tag "Enlazable" 
    accede al script del lazo y modifica los parametros enlazado a true 
    y asigna dicho objeto como el objetoEnlazable
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazoDetector : MonoBehaviour
{
    public GameObject player;// jugador


    void OnTriggerEnter(Collider other) {
        if(other.tag == "Enlazable") {
            player.GetComponent<LazoScript>().enlazado = true;
            player.GetComponent<LazoScript>().objetoEnlazable = other.gameObject;
        }
    }
}
