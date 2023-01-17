using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public GameObject door; // Asigna la puerta en el Inspector de Unity
    public bool hasKey = false; // Almacena si el jugador tiene la llave o no

    void CheckKey()
    {
        if (hasKey == true)
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
        Destroy(door); // Destruye la puerta
    }
}
