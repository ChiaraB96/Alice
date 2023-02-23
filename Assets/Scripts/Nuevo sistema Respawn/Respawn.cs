using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
   
    public Transform inicial; 
    public Transform punto1;
    public Transform punto2;
    public Transform punto3;
    public Transform punto4;
    public Transform punto5;
    public Transform punto6;
    public Transform final;



    private UltimaPlataforma ultimaPlataforma;


    // Mueve el objeto en el que está inserto este script a una nueva ubicación, indicada por el argumento nuevaPosicion.
    public void Reposicionar (string nuevaPosicion) {
        switch (nuevaPosicion) {
            case "RInicial":
                transform.position = inicial.position;
                break;
            case "R1":
                transform.position = punto1.position;
                break;
            case "R2":
                transform.position = punto2.position;
                break;
            case "R3":
                transform.position = punto3.position;
                break;
            case "R4":
                transform.position = punto4.position;
                break;
            case "R5":
                transform.position = punto5.position;
                break;
            case "R6":
                transform.position = punto6.position;
                break;
            case "RFinal":
                transform.position = final.position;
                break;
            default:
                transform.position = inicial.position;
                break;
        }

    }

    private void Start () {
        ultimaPlataforma = GetComponent<UltimaPlataforma>();
    }


    void OnTriggerEnter(Collider other) {
        if(other.tag == "Respawn") {
            Reposicionar(ultimaPlataforma.Nombre());
        }

    }

}


