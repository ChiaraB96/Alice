using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazoDetector : MonoBehaviour
{
    public GameObject jugador;


    void OnTriggerEnter(Collider other) {
        if(other.tag == "Enlazable") {
            jugador.GetComponent<LazoScript>().enlazado = true;
            jugador.GetComponent<LazoScript>().objetoEnlazable = other.gameObject;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
