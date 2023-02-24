/* Personaje

    cuando el personaje entra el collider una plataforma con el tag plataforma, se guarda el nombre de la misma
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UltimaPlataforma : MonoBehaviour {


    private string ultimaPlataforma = "RInicial";// ultima plataforma que tocó el jugador. Inicializada en RInicial


    public string Nombre () {
        return ultimaPlataforma;
    }

    private void OnCollisionEnter (Collision other) {
        if (other.collider.tag == "Plataforma") {
            ultimaPlataforma = other.collider.name;
        }
    }
}


