using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public GameObject door; // Asigna la puerta en el Inspector de Unity
    public bool hasKey = false; // Almacena si el jugador tiene la llave o no
    public GameObject player; // Asigna la referencia al jugador en el inspector

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (hasKey)
            {
                OpenDoor();
            }
            else
            {
                Debug.Log("No tienes la llave necesaria para abrir esta puerta");
            }
        }
    }

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
