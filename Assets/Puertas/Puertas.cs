
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public GameObject door; // Asigna la puerta en el Inspector de Unity
    public GameObject key; // Asigna la llave en el Inspector de Unity

    private bool hasKey = false; // Almacena si el jugador tiene la llave o no

    void OnTriggerEnter(Collider other)
    {
        CheckKey(); // Verifica si el jugador tiene la llave
    }

    void CheckKey()
    {
        if (hasKey = true)
        {
            OpenDoor(); // Abre la puerta
        }
        else
        {
            Debug.Log("No tienes la llave necesaria para abrir esta puerta"); // Muestra un mensaje al jugador
        }
    }

    void OpenDoor()
    {
        //door.GetComponent<BoxCollider>().enabled = false; // Desactiva el collider de la puerta
        Destroy(door);
        //door.transform.Rotate(0, 90, 0); // Rota la puerta 90 grados en el eje Y
    }
}

