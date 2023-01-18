using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public GameObject door; // Asigna la puerta en el Inspector de Unity
    public int keyCount = 0; // contador de llaves
    public int requiredKeys = 2; // número de llaves necesarias para abrir la puerta
    public GameObject player; // Asigna la referencia al jugador en el inspector

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (keyCount >= requiredKeys)
            {
                OpenDoor();
            }
            else
            {
                Debug.Log("No tienes suficientes llaves para abrir esta puerta. Necesitas " + requiredKeys + " llaves.");
            }
        }
    }

    void OpenDoor()
    {
        Destroy(door); // Destruye la puerta
    }
}
