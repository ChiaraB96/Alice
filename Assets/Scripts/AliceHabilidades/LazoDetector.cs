// Personaje -> MainCamera -> Holder -> Lazo 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazoDetector : MonoBehaviour
{
    public GameObject player;


    void OnTriggerEnter(Collider other) {
        if(other.tag == "Enlazable") {
            player.GetComponent<LazoScript>().enlazado = true;
            player.GetComponent<LazoScript>().objetoEnlazable = other.gameObject;
        }
    }
}
