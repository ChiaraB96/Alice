/* Personaje

    cuando el jugador entra en un trigger con el tag respawn se modifica su posicion
    al punto de respawn correspondiente a la ultima plataforma que tocó
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
   
    //punto de respawn
    public Transform inicial; 
    public Transform punto1;
    public Transform punto2;
    public Transform punto3;
    public Transform punto4;
    public Transform punto5;
    public Transform punto6;
    public Transform punto7;
    public Transform punto8;
    public Transform punto9;
    public Transform final;

    private UltimaPlataforma ultimaPlataforma; //ultima plataforma que tocó el jugador


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
            case "R7":
                transform.position = punto7.position;
                break;
            case "R8":
                transform.position = punto8.position;
                break;
            case "R9":
                transform.position = punto9.position;
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


