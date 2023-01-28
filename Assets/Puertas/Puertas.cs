using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public GameObject door; // Asigna la puerta en el Inspector de Unity
    public int keyCounter = 0; // Almacena la cantidad de particulas que el jugador tiene
    public int requiredKeys = 1; // Almacena la cantidad de particulas necesarias para abrir la puerta
    public GameObject player; // Asigna la referencia al jugador en el inspector
    public InventoryItemData itemData; // Asigna el item en el inspector

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (keyCounter >= requiredKeys)
            {
                OpenDoor();
            }
            else
            {
                Debug.Log("No tienes la cantidad de particulas necesarias para abrir esta puerta");
            }
        }
    }

    void OpenDoor()
    {
        for (int i = 0; i < keyCounter; i++)
        {
            InventorySystem.Instance.Remove(itemData, keyCounter);
        }
        Destroy(door);
    }
}
