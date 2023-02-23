using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UltimaPlataforma : MonoBehaviour {


    private string ultimaPlataforma = "RInicial";


    public string Nombre () {
        return ultimaPlataforma;
    }

    private void OnCollisionEnter (Collision other) {
        if (other.collider.tag == "Plataforma") {
            ultimaPlataforma = other.collider.name;
        }
    }
}


